/*  
 
    Copyright (c) 2008-2010 by the President and Fellows of Harvard College. All rights reserved.  
    Profiles Research Networking Software was developed under the supervision of Griffin M Weber, MD, PhD.,
    and Harvard Catalyst: The Harvard Clinical and Translational Science Center, with support from the 
    National Center for Research Resources and Harvard University.


    Code licensed under a BSD License. 
    For details, see: LICENSE.txt 
  
*/
using System;
using System.Data;
using System.Web.Security;
using Connects.Profiles.DataAccess;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

namespace Connects.Profiles.BusinessLogic
{
    public class ProfilesDBMembershipProviderBL //: BaseBL
    {
        public bool ChangePassword(string username, string oldPwd, string newPwd)
        {
            return new ProfilesDBMembershipProviderDA().ChangePassword(username, oldPwd, newPwd);
        }

        public bool ChangePasswordQuestionAndAnswer(string username, string newPwdQuestion, string newPwdAnswer)
        {
            return new ProfilesDBMembershipProviderDA().ChangePasswordQuestionAndAnswer(username, newPwdQuestion, newPwdAnswer);
        }

        public MembershipUser CreateUser(string username, string password, string email, string passwordQuestion,
            string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            return new ProfilesDBMembershipProviderDA().CreateUser(username, password, email, passwordQuestion, passwordAnswer, isApproved, providerUserKey, out status);
        }

        public MembershipUser CreateUser(string username, string firstName, string lastName, string email, string officePhone, string institutionFullname, string departmentFullname, string divisionFullname,
        string p_Password, int p_PasswordFormat, string p_PasswordQuestion, string p_PasswordAnswer, string p_ApplicationName, string p_Comment, bool p_IsApproved)
        {
            return new ProfilesDBMembershipProviderDA().CreateUser(0, username, firstName, lastName, email,
                                                                   officePhone,
                                                                   institutionFullname, departmentFullname,
                                                                   divisionFullname, p_Password, p_PasswordFormat,
                                                                   p_PasswordQuestion, p_PasswordAnswer,
                                                                   p_ApplicationName, p_Comment, p_IsApproved);
        }

        public MembershipUser UpdateUser(int userId, string username, string firstName, string lastName, string email,
            string officePhone, string institutionFullname, string departmentFullname, string divisionFullname,
            string p_Password, int p_PasswordFormat, string p_PasswordQuestion, string p_PasswordAnswer,
            string p_ApplicationName, string p_Comment, bool p_IsApproved)
        {
            return new ProfilesDBMembershipProviderDA().CreateUser(userId, username, firstName, lastName, email,
                                                                   officePhone,
                                                                   institutionFullname, departmentFullname,
                                                                   divisionFullname, p_Password, p_PasswordFormat,
                                                                   p_PasswordQuestion, p_PasswordAnswer,
                                                                   p_ApplicationName, p_Comment, p_IsApproved);
        }

        //this Method invoke by ObjectDataSource
        public MembershipUserCollection GetAllUsers(string search, int startRowIndex, int maximumRows)
        {
            int totalRecords;
            int pageIndex = 0;
            if (maximumRows != 0) pageIndex = startRowIndex / maximumRows;

            MembershipUserCollection users = new ProfilesDBMembershipProviderDA().GetAllUsers(pageIndex,
                                                                                              maximumRows, search,
                                                                                              out totalRecords);
            return users;
        }

        public ProfilesMembershipUserCollection GetAllProfileUsers(string search, int startRowIndex, int maximumRows)
        {
            MembershipUserCollection users = GetAllUsers(search, startRowIndex, maximumRows);
            ProfilesMembershipUserCollection profileUsers = new ProfilesMembershipUserCollection();
            foreach (MembershipUser l_User in users)
            {
                profileUsers.Add((ProfilesMembershipUser)l_User);
            }
            return profileUsers;
        }

        public MembershipUserCollection GetAllUsers(int startRowIndex, int maximumRows, out int totalRecords)
        {
            return new ProfilesDBMembershipProviderDA().GetAllUsers(startRowIndex, maximumRows, string.Empty,
                                                                    out totalRecords);
        }

        public int GetAllUsersCount(string search)
        {
            int Count;
            new ProfilesDBMembershipProviderDA().GetAllUsers(0, int.MaxValue, search, out Count);
            return Count;
        }

        public int GetUserPosition(int p_UserID)
        {
            return new ProfilesDBMembershipProviderDA().GetUserPosition(p_UserID);
        }

        public int GetNumberOfUsersOnline()
        {
            return new ProfilesDBMembershipProviderDA().GetNumberOfUsersOnline();
        }

        public string GetPassword(string username, string answer)
        {
            return new ProfilesDBMembershipProviderDA().GetPassword(username, answer);
        }

        public string GetPasswordByAnswer(string username, string answer)
        {
            return new ProfilesDBMembershipProviderDA().GetUserPassword(username, answer);
        }


        public ProfilesMembershipUser GetUser(string username, bool updateUserActivity)
        {
            DataRow userRow = null;
            ProfilesMembershipUser memberUser = null;

            userRow = new ProfilesDBMembershipProviderDA().GetUser(username, updateUserActivity);
            memberUser = GetUserFromTableRow(userRow);


            return memberUser;
        }

        public ProfilesMembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            IDataReader userReader;
            ProfilesMembershipUser memberUser = null;

            userReader = new ProfilesDBMembershipProviderDA().GetUser(providerUserKey, userIsOnline);

            if (((System.Data.SqlClient.SqlDataReader)userReader).HasRows)
            {
                userReader.Read();
                memberUser = this.GetUserFromReader(userReader);
            }

            return memberUser;
        }

        public bool UnlockUser(string username)
        {
            return new ProfilesDBMembershipProviderDA().UnlockUser(username);
        }

        public string GetUserNameByEmail(string email)
        {
            return new ProfilesDBMembershipProviderDA().GetUserNameByEmail(email);
        }

        public string CheckUserLockOutCondition(string username)
        {
            return new ProfilesDBMembershipProviderDA().CheckUserLockOutCondition(username);
        }

        public string GetUserPassword(string username, int maxInvalidPasswordAttempts, int passwordAttemptWindow)
        {
            return new ProfilesDBMembershipProviderDA().GetUserPassword(username, maxInvalidPasswordAttempts, passwordAttemptWindow);
        }

        public MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            MembershipUserCollection users = new ProfilesDBMembershipProviderDA().GetUsersByName(usernameToMatch);
            totalRecords = users.Count;
            return users;
            //return new ProfilesDBMembershipProviderDA().FindUsersByName(usernameToMatch, pageIndex, pageSize, out totalRecords);
        }

        public MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            return new ProfilesDBMembershipProviderDA().FindUsersByEmail(emailToMatch, pageIndex, pageSize, out totalRecords);
        }

        public void LogLastUserLogin(string username)
        {
            new ProfilesDBMembershipProviderDA().LogLastUserLogin(username);
        }

        public bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            return new ProfilesDBMembershipProviderDA().DeleteUser(username, deleteAllRelatedData);
        }

        public MembershipUser GetUserByID(int p_UserID)
        {
            MembershipUser user = null;
            try
            {
                DataRow userRow = new ProfilesDBMembershipProviderDA().GetUserByID(p_UserID);
                user = GetUserFromTableRow(userRow);
            }
            catch (Exception ex)
            {
                bool l_Rethrow = ExceptionPolicy.HandleException(ex, GlobalConst.LogOnlyPolicy);
                if (l_Rethrow) throw;
            }
            return user;
        }

        #region Membership Helper Functions


        // PRG: Refactor these ordinal references
        //
        // GetUserFromReader
        //    A helper function that takes the current row from the OdbcDataReader
        // and hydrates a MembershiUser from the values. Called by the 
        // MembershipUser.GetUser implementation.
        //


        private ProfilesMembershipUser GetUserFromReader(IDataReader reader)
        {
            if (reader == null) return null;

            object providerUserKey = reader.GetValue(0);

            string username = "";
            if (reader.GetValue(14) != DBNull.Value)
                username = reader.GetString(14);

            string email = "";
            if (reader.GetValue(0) != DBNull.Value)
                email = reader.GetString(0);

            string passwordQuestion = "";
            if (reader.GetValue(1) != DBNull.Value)
                passwordQuestion = reader.GetString(1);

            string comment = "";
            if (reader.GetValue(2) != DBNull.Value)
                comment = reader.GetString(2);

            bool isApproved = false;
            if (reader.GetValue(3) != DBNull.Value)
                isApproved = reader.GetBoolean(3);

            bool isLockedOut = false;
            if (reader.GetValue(10) != DBNull.Value)
                isApproved = reader.GetBoolean(10);

            DateTime creationDate = new DateTime();
            if (reader.GetValue(5) != DBNull.Value)
                creationDate = reader.GetDateTime(5);

            DateTime lastLoginDate = new DateTime();
            if (reader.GetValue(6) != DBNull.Value)
                lastLoginDate = reader.GetDateTime(6);

            DateTime lastActivityDate = new DateTime();
            if (reader.GetValue(7) != DBNull.Value)
                lastLoginDate = reader.GetDateTime(7);

            DateTime lastPasswordChangedDate = new DateTime();
            if (reader.GetValue(8) != DBNull.Value)
                lastLoginDate = reader.GetDateTime(8);

            DateTime lastLockedOutDate = new DateTime();
            if (reader.GetValue(11) != DBNull.Value)
                lastLockedOutDate = reader.GetDateTime(11);

            int userId = 0;
            if (reader.GetValue(9) != DBNull.Value)
                userId = reader.GetInt32(9);

            bool hasProfile = false;
            if (reader.GetValue(12) != DBNull.Value)
                hasProfile = reader.GetBoolean(12);

            int profileId = 0;
            if (reader.GetValue(13) != DBNull.Value)
                profileId = reader.GetInt32(13);

            string displayName = "";
            if (reader.GetValue(4) != DBNull.Value)
                displayName = reader.GetString(4);

            string firstName = null;
            string lastName = null;
            string departmentFullname = null;
            string divisionFullName = null;
            string institutionFullname = null;
            string officePhone = null;
            string passwordAnswer = null;


            ProfilesMembershipUser u = new ProfilesMembershipUser("ProfilesDBMembershipProvider",
                                                                  username,
                                                                  providerUserKey,
                                                                  email,
                                                                  passwordQuestion,
                                                                  comment,
                                                                  isApproved,
                                                                  isLockedOut,
                                                                  creationDate,
                                                                  lastLoginDate,
                                                                  lastActivityDate,
                                                                  lastPasswordChangedDate,
                                                                  lastLockedOutDate,
                                                                  hasProfile,
                                                                  userId,
                                                                  profileId,
                                                                  displayName,
                                                                  firstName, lastName, departmentFullname,
                                                                  divisionFullName, institutionFullname, officePhone,
                                                                  passwordAnswer);

            return u;
        }

        private static ProfilesMembershipUser GetUserFromTableRow(DataRow tableRow)
        {
            if (tableRow == null) return null;

            object providerUserKey = null;
            if (tableRow.Table.Columns.Contains("providerUserKey"))
            {
                providerUserKey = tableRow["providerUserKey"] == DBNull.Value
                                      ? null
                                      : tableRow["providerUserKey"];
            }

            string username = null;
            if (tableRow.Table.Columns.Contains("username"))
            {
                username = tableRow["username"] == DBNull.Value
                               ? null
                               : (string)tableRow["username"];
            }

            string email = null;
            if (tableRow.Table.Columns.Contains("EmailAddr"))
            {
                email = tableRow["EmailAddr"] == DBNull.Value
                               ? null
                               : (string)tableRow["EmailAddr"];
            }

            string passwordQuestion = "";
            if (tableRow.Table.Columns.Contains("PasswordQuestion"))
            {
                passwordQuestion = tableRow["PasswordQuestion"] == DBNull.Value
                            ? null
                            : (string)tableRow["PasswordQuestion"];
            }

            string comment = "";
            if (tableRow.Table.Columns.Contains("comment"))
            {
                comment = tableRow["comment"] == DBNull.Value
                            ? null
                            : (string)tableRow["comment"];
            }

            bool isApproved = false;
            if (tableRow.Table.Columns.Contains("IsApproved"))
            {
                isApproved = tableRow["IsApproved"] == DBNull.Value
                            ? false
                            : (bool)tableRow["IsApproved"];
            }


            bool isLockedOut = false;
            if (tableRow.Table.Columns.Contains("IsLockedOut"))
            {
                isLockedOut = tableRow["IsLockedOut"] == DBNull.Value
                            ? false
                            : (bool)tableRow["IsLockedOut"];
            }

            DateTime creationDate = new DateTime();
            if (tableRow.Table.Columns.Contains("CreateDate"))
            {
                creationDate = tableRow["CreateDate"] == DBNull.Value
                            ? DateTime.Now
                            : (DateTime)tableRow["CreateDate"];
            }


            DateTime lastLoginDate = new DateTime();
            if (tableRow.Table.Columns.Contains("LastLoginDate"))
            {
                lastLoginDate = tableRow["LastLoginDate"] == DBNull.Value
                            ? DateTime.Now
                            : (DateTime)tableRow["LastLoginDate"];
            }


            DateTime lastActivityDate = new DateTime();
            if (tableRow.Table.Columns.Contains("LastActivityDate"))
            {
                lastActivityDate = tableRow["LastActivityDate"] == DBNull.Value
                            ? DateTime.Now
                            : (DateTime)tableRow["LastActivityDate"];
            }

            DateTime lastPasswordChangedDate = new DateTime();
            if (tableRow.Table.Columns.Contains("LastPasswordChangedDate"))
            {
                lastPasswordChangedDate = tableRow["LastPasswordChangedDate"] == DBNull.Value
                            ? DateTime.Now
                            : (DateTime)tableRow["LastPasswordChangedDate"];
            }

            DateTime lastLockedOutDate = new DateTime();
            if (tableRow.Table.Columns.Contains("LastLockoutDate"))
            {
                lastLockedOutDate = tableRow["LastLockoutDate"] == DBNull.Value
                            ? DateTime.Now
                            : (DateTime)tableRow["LastLockoutDate"];
            }

            int userId = 0;
            if (tableRow.Table.Columns.Contains("userId"))
            {
                if (tableRow["userId"] != DBNull.Value)
                {
                    userId = (int)tableRow["userId"];
                }
            }

            bool hasProfile = false;
            if (tableRow.Table.Columns.Contains("hasProfile"))
            {
                hasProfile = tableRow["hasProfile"] == DBNull.Value
                            ? false
                            : (bool)tableRow["hasProfile"];
            }

            int profileId = 0;
            if (tableRow.Table.Columns.Contains("profileId"))
            {
                if (tableRow["profileId"] != DBNull.Value)
                {
                    int.TryParse(Convert.ToString(tableRow["profileId"]), out profileId);
                }
            }

            string displayName = "";
            if (tableRow.Table.Columns.Contains("displayName"))
            {
                displayName = tableRow["displayName"] == DBNull.Value
                            ? null
                            : (string)tableRow["displayName"];
            }


            string firstName = null;
            if (tableRow.Table.Columns.Contains("firstName"))
            {
                firstName = tableRow["firstName"] == DBNull.Value
                            ? null
                            : (string)tableRow["firstName"];
            }

            string lastName = null;
            if (tableRow.Table.Columns.Contains("lastName"))
            {
                lastName = tableRow["lastName"] == DBNull.Value
                            ? null
                            : (string)tableRow["lastName"];
            }


            string departmentFullname = null;
            if (tableRow.Table.Columns.Contains("departmentFullname"))
            {
                departmentFullname = tableRow["departmentFullname"] == DBNull.Value
                            ? null
                            : (string)tableRow["departmentFullname"];
            }


            string divisionFullName = null;
            if (tableRow.Table.Columns.Contains("divisionFullName"))
            {
                divisionFullName = tableRow["divisionFullName"] == DBNull.Value
                                       ? null
                                       : (string)tableRow["divisionFullName"];
            }


            string institutionFullname = null;
            if (tableRow.Table.Columns.Contains("institutionFullname"))
            {
                institutionFullname = tableRow["institutionFullname"] == DBNull.Value
                                       ? null
                                       : (string)tableRow["institutionFullname"];
            }

            string officePhone = null;
            if (tableRow.Table.Columns.Contains("officePhone"))
            {
                officePhone = tableRow["officePhone"] == DBNull.Value
                                  ? null
                                  : (string)tableRow["officePhone"];
            }

            string passwordAnswer = null;
            if (tableRow.Table.Columns.Contains("passwordAnswer"))
            {
                passwordAnswer = tableRow["passwordAnswer"] == DBNull.Value
                                  ? null
                                  : (string)tableRow["passwordAnswer"];
            }

            ProfilesMembershipUser u = new ProfilesMembershipUser("ProfilesDBMembershipProvider",
                                                                  username,
                                                                  providerUserKey,
                                                                  email,
                                                                  passwordQuestion,
                                                                  comment,
                                                                  isApproved,
                                                                  isLockedOut,
                                                                  creationDate,
                                                                  lastLoginDate,
                                                                  lastActivityDate,
                                                                  lastPasswordChangedDate,
                                                                  lastLockedOutDate,
                                                                  hasProfile,
                                                                  userId,
                                                                  profileId,
                                                                  displayName, firstName, lastName, departmentFullname,
                                                                  divisionFullName, institutionFullname, officePhone,
                                                                  passwordAnswer);

            return u;
        }

        #endregion

    }


}
