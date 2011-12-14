using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Connects.Profiles.BusinessLogic;
using System.Collections.Specialized;

/// <summary>
/// This membership provider allows for custom authentication using an external mechanism
/// </summary>
public class ProfilesExtMembershipProvider : MembershipProvider
{
    private ProfilesDBMembershipProviderBL _membershipBL = new ProfilesDBMembershipProviderBL();

    //
    // System.Configuration.Provider.ProviderBase.Initialize Method
    //
    public override void Initialize(string name, NameValueCollection config)
    {
        //
        // Initialize values from web.config.
        //
        if (config == null)
            throw new ArgumentNullException("config");

        if (name == null || name.Length == 0)
            name = "ProfilesExtMembershipProvider";

        if (String.IsNullOrEmpty(config["description"]))
        {
            config.Remove("description");
            config.Add("description", "Profiles External Membership Provider");
        }

        // Initialize the abstract base class.
        base.Initialize(name, config);

        // Read configuration parameters and map them to properties of this membership provider
        // See ProfilesHMSMembershipProvider.cs for an example of how to do this
    }

    /// <summary>
    /// The ValidateUser method is called first during login processing. 
    ///
    /// Additional Information: Depending on the implementation of your external authentication mechanism
    /// you may want to consider customizing the login.aspx page to simulate the forms login process, which
    /// will, in turn, call this method to validate the user.
    /// 
    /// In an SSO situation, you may have a one-time security token vs. a password, but this token can be
    /// used in the login process and then verified using the ValidateUser method.
    /// 
    /// Alternatively, your implementation may choose to call this method directly.
    /// </summary>
    /// <param name="username"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    public override bool ValidateUser(string username, string password)
    {
        bool isValid = false;

        // In the case of SSO with a one-time token, here is the psuedo-code for one
        // way this mechanism can be used.
        // 1.  Envoke ASP.NET login process, either with login.aspx or some other means
        // 2.  Pass the username and token (as password) into the login process
        // 3.  Use this method (ValidateUser) to check the token
        // 4.  Return true or false depending on the outcome of the check
        
        return isValid;
    }

    #region Required Methods

    /// <summary>
    /// GetUser retrieves information from the users table into the 
    /// profile of the asp.net application.
    /// </summary>
    /// <param name="username"></param>
    /// <param name="updateUserActivity"></param>
    /// <returns></returns>
    public override MembershipUser GetUser(string username, bool updateUserActivity)
    {
        MembershipUser user = null;

        user = _membershipBL.GetUser(username, updateUserActivity);

        return user;
    }

    #endregion

    #region Stubs for other MembershipProvidor Methods
    
    // Depending on your implementation you may choose to supply custom code for some or all
    // of these methods.  In the case of SSO where users are maintained outside of Profiles
    // it is likely that you will not need to provide these.

    public override MembershipUser GetUser(object providerUserKey, bool userIsOnline) { return null; }
    public override string GetUserNameByEmail(string email) { return ""; }
    public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion,
        string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status) { status = MembershipCreateStatus.ProviderError;  return null; }
    public override bool DeleteUser(string username, bool deleteAllRelatedData) { return false; }
    public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords) { totalRecords = 0;  return null; }
    public override int GetNumberOfUsersOnline() { return 0; }
    public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords) { totalRecords = 0;  return null; }
    public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords) { totalRecords = 0; return null; }


    public override bool ChangePassword(string username, string oldPwd, string newPwd) { return false; }
    public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPwdQuestion, string newPwdAnswer) { return false; }
    public override string GetPassword(string username, string answer) { return ""; }
    public override bool UnlockUser(string username) { return false; }
    public override string ResetPassword(string username, string answer) { return ""; }
    public override void UpdateUser(MembershipUser user) { }

    #endregion

    #region Stubs for System.Web.Security.MembershipProvider Properties

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

    #region Helper Functions

    //
    // A helper function to retrieve config values from the configuration file.
    //

    private string GetConfigValue(string configValue, string defaultValue)
    {
        if (String.IsNullOrEmpty(configValue))
            return defaultValue;

        return configValue;
    }

    #endregion


}
