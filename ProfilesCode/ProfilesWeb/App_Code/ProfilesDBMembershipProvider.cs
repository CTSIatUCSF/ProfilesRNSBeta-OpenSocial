using System.Web.Security;
using System.Configuration.Provider;
using System.Collections.Specialized;
using System;
using System.Data;
using System.Data.Odbc;
using System.Configuration;
using System.Diagnostics;
using System.Web;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using System.Web.Configuration;
using Connects.Profiles.BusinessLogic;

public sealed class ProfilesDBMembershipProvider : MembershipProvider
{
    //
    // Global connection string, generated password length, generic exception message, event log info.
    //


    private ProfilesDBMembershipProviderBL _membershipBL = new ProfilesDBMembershipProviderBL();

    //
    // Used when determining encryption key values.
    //

    private MachineKeySection machineKey;

    //
    // If false, exceptions are thrown to the caller. If true,
    // exceptions are written to the event log.
    //

    private bool pWriteExceptionsToEventLog;

    public bool WriteExceptionsToEventLog
    {
        get { return pWriteExceptionsToEventLog; }
        set { pWriteExceptionsToEventLog = value; }
    }


    //
    // System.Configuration.Provider.ProviderBase.Initialize Method
    //
    public override void Initialize(string name, NameValueCollection config)
    {
        //
        // Initialize values from web.config.
        //

        if (string.IsNullOrEmpty(name))
            name = "ProfilesDBMembershipProvider";

        if (String.IsNullOrEmpty(config["description"]))
        {
            config.Remove("description");
            config.Add("description", "Profiles DB Membership provider");
        }

        // Initialize the abstract base class.
        base.Initialize(name, config);

        pApplicationName = GetConfigValue(config["applicationName"],
                                        System.Web.Hosting.HostingEnvironment.ApplicationVirtualPath);
        pMaxInvalidPasswordAttempts = Convert.ToInt32(GetConfigValue(config["maxInvalidPasswordAttempts"], "5"));
        pPasswordAttemptWindow = Convert.ToInt32(GetConfigValue(config["passwordAttemptWindow"], "10"));
        pMinRequiredNonAlphanumericCharacters = Convert.ToInt32(GetConfigValue(config["minRequiredNonAlphanumericCharacters"], "1"));
        pMinRequiredPasswordLength = Convert.ToInt32(GetConfigValue(config["minRequiredPasswordLength"], "7"));
        pPasswordStrengthRegularExpression = Convert.ToString(GetConfigValue(config["passwordStrengthRegularExpression"], ""));
        pEnablePasswordReset = Convert.ToBoolean(GetConfigValue(config["enablePasswordReset"], "true"));
        pEnablePasswordRetrieval = Convert.ToBoolean(GetConfigValue(config["enablePasswordRetrieval"], "true"));
        pRequiresQuestionAndAnswer = Convert.ToBoolean(GetConfigValue(config["requiresQuestionAndAnswer"], "false"));
        pRequiresUniqueEmail = Convert.ToBoolean(GetConfigValue(config["requiresUniqueEmail"], "true"));
        pWriteExceptionsToEventLog = Convert.ToBoolean(GetConfigValue(config["writeExceptionsToEventLog"], "true"));

        string temp_format = config["passwordFormat"];
        if (temp_format == null)
        {
            temp_format = "Encrypted";
        }

        switch (temp_format)
        {
            case "Hashed":
                pPasswordFormat = MembershipPasswordFormat.Hashed;
                break;
            case "Encrypted":
                pPasswordFormat = MembershipPasswordFormat.Encrypted;
                break;
            case "Clear":
                pPasswordFormat = MembershipPasswordFormat.Clear;
                break;
            default:
                break;
        }


        // Get encryption and decryption key information from the configuration.
        //Configuration cfg =
        //  WebConfigurationManager.OpenWebConfiguration(System.Web.Hosting.HostingEnvironment.ApplicationVirtualPath);
        //machineKey = (MachineKeySection)cfg.GetSection("system.web/machineKey");

        //if (machineKey.ValidationKey.Contains("AutoGenerate"))
        //    if (PasswordFormat != MembershipPasswordFormat.Clear)
        //        throw new ProviderException("Hashed or Encrypted passwords " +
        //                                    "are not supported with auto-generated keys.");
    }


    //
    // A helper function to retrieve config values from the configuration file.
    //

    private static string GetConfigValue(string configValue, string defaultValue)
    {
        if (String.IsNullOrEmpty(configValue))
            return defaultValue;

        return configValue;
    }

    #region System.Web.Security.MembershipProvider properties

    //
    // System.Web.Security.MembershipProvider properties.
    //
    private string pApplicationName;
    private bool pEnablePasswordReset;
    private bool pEnablePasswordRetrieval;
    private bool pRequiresQuestionAndAnswer;
    private bool pRequiresUniqueEmail;
    private int pMaxInvalidPasswordAttempts;
    private int pPasswordAttemptWindow;
    private MembershipPasswordFormat pPasswordFormat;

    public override string ApplicationName
    {
        get { return pApplicationName; }
        set { pApplicationName = value; }
    }

    public override bool EnablePasswordReset
    {
        get { return pEnablePasswordReset; }
    }


    public override bool EnablePasswordRetrieval
    {
        get { return pEnablePasswordRetrieval; }
    }


    public override bool RequiresQuestionAndAnswer
    {
        get { return pRequiresQuestionAndAnswer; }
    }


    public override bool RequiresUniqueEmail
    {
        get { return pRequiresUniqueEmail; }
    }


    public override int MaxInvalidPasswordAttempts
    {
        get { return pMaxInvalidPasswordAttempts; }
    }


    public override int PasswordAttemptWindow
    {
        get { return pPasswordAttemptWindow; }
    }


    public override MembershipPasswordFormat PasswordFormat
    {
        get { return pPasswordFormat; }
    }

    private int pMinRequiredNonAlphanumericCharacters;

    public override int MinRequiredNonAlphanumericCharacters
    {
        get { return pMinRequiredNonAlphanumericCharacters; }
    }

    private int pMinRequiredPasswordLength;

    public override int MinRequiredPasswordLength
    {
        get { return pMinRequiredPasswordLength; }
    }

    private string pPasswordStrengthRegularExpression;

    public override string PasswordStrengthRegularExpression
    {
        get { return pPasswordStrengthRegularExpression; }
    }

    #endregion

    //
    // System.Web.Security.MembershipProvider methods.
    //

    //
    // MembershipProvider.ChangePassword
    //

    public override bool ChangePassword(string username, string oldPwd, string newPwd)
    {
        if (!ValidateUser(username, oldPwd))
            return false;

        ValidatePasswordEventArgs args =
          new ValidatePasswordEventArgs(username, newPwd, true);

        OnValidatingPassword(args);

        if (args.Cancel)
            if (args.FailureInformation != null)
                return false;
            //throw args.FailureInformation;
            else
                return false;
        //throw new MembershipPasswordException("Change password canceled due to new password validation failure.");

        return _membershipBL.ChangePassword(username, oldPwd, EncodePassword(newPwd));
    }



    //
    // MembershipProvider.ChangePasswordQuestionAndAnswer
    //

    public override bool ChangePasswordQuestionAndAnswer(string username,
                  string password,
                  string newPwdQuestion,
                  string newPwdAnswer)
    {
        if (!ValidateUser(username, password))
            return false;

        return _membershipBL.ChangePasswordQuestionAndAnswer(username, newPwdQuestion, EncodePassword(newPwdAnswer));
    }

    // PRG - rewrite this
    //
    // MembershipProvider.CreateUser
    //
    public override MembershipUser CreateUser(string username,
             string password,
             string email,
             string passwordQuestion,
             string passwordAnswer,
             bool isApproved,
             object providerUserKey,
             out MembershipCreateStatus status)
    {
        MembershipUser l_User = _membershipBL.CreateUser(username, password, email, passwordQuestion, passwordAnswer,
                                                         isApproved,
                                                         providerUserKey, out status);
        status = MembershipCreateStatus.ProviderError;
        return l_User;
    }

    public MembershipUser CreateUser(string username, string firstName, string lastName, string email,
        string officePhone, string institutionFullname, string departmentFullname, string divisionFullname,
        string p_Password, int p_PasswordFormat, string p_PasswordQuestion, string p_PasswordAnswer,
        string p_ApplicationName, string p_Comment, bool p_IsApproved)
    {
        MembershipUser l_User = _membershipBL.CreateUser(username, firstName, lastName, email, officePhone,
                                                         institutionFullname, departmentFullname,
                                                         divisionFullname, p_Password, p_PasswordFormat,
                                                         p_PasswordQuestion, p_PasswordAnswer,
                                                         p_ApplicationName, p_Comment, p_IsApproved);
        return l_User;
    }

    public MembershipUser UpdateUser(int userId, string username, string firstName, string lastName, string email,
        string officePhone, string institutionFullname, string departmentFullname, string divisionFullname,
        string p_Password, int p_PasswordFormat, string p_PasswordQuestion, string p_PasswordAnswer,
        string p_ApplicationName, string p_Comment, bool p_IsApproved)
    {
        return _membershipBL.UpdateUser(userId, username, firstName, lastName, email, officePhone,
                                        institutionFullname, departmentFullname,
                                        divisionFullname, p_Password, p_PasswordFormat,
                                        p_PasswordQuestion, p_PasswordAnswer,
                                        p_ApplicationName, p_Comment, p_IsApproved);
    }


    // PRG - rewrite this
    //
    // MembershipProvider.DeleteUser
    //

    public override bool DeleteUser(string username, bool deleteAllRelatedData)
    {
        return _membershipBL.DeleteUser(username, deleteAllRelatedData);
    }



    //
    // MembershipProvider.GetAllUsers
    //
    public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
    {
        return _membershipBL.GetAllUsers(pageIndex, pageSize, out totalRecords);
    }


    //
    // MembershipProvider.GetNumberOfUsersOnline
    //

    public override int GetNumberOfUsersOnline()
    {
        return _membershipBL.GetNumberOfUsersOnline();
    }


    // PRG - rewrite this
    //
    // MembershipProvider.GetPassword
    //
    //
    public override string GetPassword(string username, string answer)
    {
        return "";
    }


    //
    // MembershipProvider.GetUser(string, bool)
    //

    public override MembershipUser GetUser(string username, bool updateUserActivity)
    {

        ProfilesMembershipUser user = null;

        user = _membershipBL.GetUser(username, updateUserActivity);

        return user;
    }


    //
    // MembershipProvider.GetUser(object, bool)
    //

    public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
    {
        ProfilesMembershipUser user = null;

        user = _membershipBL.GetUser(providerUserKey, userIsOnline);

        if (userIsOnline)
            _membershipBL.LogLastUserLogin(user.UserName);

        return user;
    }


    //
    // MembershipProvider.UnlockUser
    //
    public override bool UnlockUser(string username)
    {
        return _membershipBL.UnlockUser(username);
    }


    //
    // MembershipProvider.GetUserNameByEmail
    //
    public override string GetUserNameByEmail(string email)
    {
        return _membershipBL.GetUserNameByEmail(email);
    }


    // PRG: Fix this
    //
    //MembershipProvider.ResetPassword

    public override string ResetPassword(string username, string answer)
    {
        string l_resultPass = null;

        string l_Pass = new ProfilesDBMembershipProviderBL().GetPasswordByAnswer(username, answer);
        if (!string.IsNullOrEmpty(l_Pass))
        {
            l_Pass = UnEncodePassword(l_Pass);
            string l_newPass = Membership.GeneratePassword(MinRequiredPasswordLength + 2, 1);

            if (ChangePassword(username, l_Pass, l_newPass))
                l_resultPass = l_newPass;
        }
        return l_resultPass;
    }


    // PRG: Fix this
    //
    // MembershipProvider.UpdateUser
    //
    public override void UpdateUser(MembershipUser user)
    {
    }


    /// <summary>
    /// The ValidateUser method is called first during login processing.  
    /// </summary>
    /// <param name="username"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    public override bool ValidateUser(string username, string password)
    {
        bool isValid = false;
        string pwd = "";

        pwd = _membershipBL.GetUserPassword(username, this.MaxInvalidPasswordAttempts, this.PasswordAttemptWindow);

        if (!string.IsNullOrEmpty(pwd))
        {
            if (CheckPassword(password, pwd))
                isValid = true;
            //else
            //UpdateFailureCount(username, "password"); 
        }

        return isValid;
    }


    //
    // MembershipProvider.FindUsersByName
    //

    public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
    {
        MembershipUserCollection users = new MembershipUserCollection();

        //users = _membershipBL.FindUsersByName(usernameToMatch, pageIndex, pageSize, out totalRecords);
        users = _membershipBL.FindUsersByName(usernameToMatch, 0, int.MaxValue, out totalRecords);
        return users;
    }

    //
    // MembershipProvider.FindUsersByEmail
    //

    public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
    {
        MembershipUserCollection users = new MembershipUserCollection();

        users = _membershipBL.FindUsersByEmail(emailToMatch, pageIndex, pageSize, out totalRecords);
        return users;
    }

    #region Password Helper Functions

    //
    // CheckPassword
    //   Compares password values based on the MembershipPasswordFormat.
    //

    private bool CheckPassword(string password, string dbpassword)
    {
        string pass1 = password;
        string pass2 = dbpassword;

        //TODO: while method CreateUser not created comment this code
        switch (PasswordFormat)
        {
            case MembershipPasswordFormat.Encrypted:
                pass2 = UnEncodePassword(dbpassword);
                break;
            case MembershipPasswordFormat.Hashed:
                pass1 = EncodePassword(password);
                break;
            default:
                break;
        }

        if (pass1 == pass2)
        {
            return true;
        }

        return false;
    }


    //
    // EncodePassword
    //   Encrypts, Hashes, or leaves the password clear based on the PasswordFormat.
    //

    public string EncodePassword(string password)
    {
        string encodedPassword = password;

        switch (PasswordFormat)
        {
            case MembershipPasswordFormat.Clear:
                break;
            case MembershipPasswordFormat.Encrypted:
                encodedPassword =
                    Convert.ToBase64String(EncryptPassword(Encoding.Unicode.GetBytes(password)));
                break;
            case MembershipPasswordFormat.Hashed:
                //HMACSHA1 hash = new HMACSHA1();
                //hash.Key = HexToByte(machineKey.ValidationKey);
                //encodedPassword =
                //    Convert.ToBase64String(hash.ComputeHash(Encoding.Unicode.GetBytes(password)));
                break;
            default:
                throw new ProviderException("Unsupported password format.");
        }

        return encodedPassword;
    }


    //
    // UnEncodePassword
    //   Decrypts or leaves the password clear based on the PasswordFormat.
    //

    public string UnEncodePassword(string encodedPassword)
    {
        string password = encodedPassword;


        //string l_s = Convert.ToBase64String(EncryptPassword(Encoding.Unicode.GetBytes("1111")));
        //string output = Encoding.Unicode.GetString(DecryptPassword(Convert.FromBase64String(l_s)));

        switch (PasswordFormat)
        {
            case MembershipPasswordFormat.Clear:
                break;
            case MembershipPasswordFormat.Encrypted:
                password =
                    Encoding.Unicode.GetString(DecryptPassword(Convert.FromBase64String(password)));
                break;
            case MembershipPasswordFormat.Hashed:
                //throw new ProviderException("Cannot unencode a hashed password.");
                break;
            default:
                throw new ProviderException("Unsupported password format.");
        }

        return password;
    }

    //
    // HexToByte
    //   Converts a hexadecimal string to a byte array. Used to convert encryption
    // key values from the configuration.
    //

    private byte[] HexToByte(string hexString)
    {
        byte[] returnBytes = new byte[hexString.Length / 2];
        for (int i = 0; i < returnBytes.Length; i++)
            returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
        return returnBytes;
    }

    #endregion

}