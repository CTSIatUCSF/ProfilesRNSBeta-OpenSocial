/*  
 
    Copyright (c) 2008-2010 by the President and Fellows of Harvard College. All rights reserved.  
    Profiles Research Networking Software was developed under the supervision of Griffin M Weber, MD, PhD.,
    and Harvard Catalyst: The Harvard Clinical and Translational Science Center, with support from the 
    National Center for Research Resources and Harvard University.


    Code licensed under a BSD License. 
    For details, see: LICENSE.txt 
  
*/
using System;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Web.Configuration;
using System.Web.Security;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

namespace Connects.Profiles.DataAccess
{
    public class ProfilesDBMembershipProviderDA
    {
        private string ConnectionStringName
        {
            get { return m_ConnectionStringName; }
        }

        private readonly string m_ConnectionStringName;

        public ProfilesDBMembershipProviderDA()
        {
            //Configuration cfg =
            //    WebConfigurationManager.OpenWebConfiguration(
            //        System.Web.Hosting.HostingEnvironment.ApplicationVirtualPath);
            //ConnectionStringsSection connections = cfg.ConnectionStrings;

            m_ConnectionStringName ="ProfilesDB";

            //foreach (ConnectionStringSettings l_ConnectionString in connections.ConnectionStrings)
            //{
            //    m_ConnectionStringName = l_ConnectionString.Name;
            //}
        }

        public string GetUserPassword(string username, string questionAnswer)
        {
            string password = null;
            try
            {
                Database db = DatabaseFactory.CreateDatabase(ConnectionStringName);
                DbCommand dbCommand = db.GetStoredProcCommand("p_User_getPassword");
                db.AddInParameter(dbCommand, "UserName", DbType.String, username);
                db.AddInParameter(dbCommand, "PasswordAnswer", DbType.String, questionAnswer);

                DataTable l_Table = db.ExecuteDataSet(dbCommand).Tables[0];
                if (l_Table.Rows.Count == 1)
                {
                    password = (string)l_Table.Rows[0]["password"];
                }
            }
            catch (Exception ex)
            {
                bool l_Rethrow = ExceptionPolicy.HandleException(ex, GlobalConst.LogOnlyPolicy);
                if (l_Rethrow) throw;
            }

            return password;
        }

        public bool ChangePassword(string username, string oldPwd, string newPwd)
        {
            int rowsAffected = 0;
            try
            {
                Database db = DatabaseFactory.CreateDatabase(ConnectionStringName);
                DbCommand dbCommand = db.GetStoredProcCommand("usp_membership_setpassword");
                db.AddInParameter(dbCommand, "ApplicationName", DbType.String, GlobalConst.ApplicationName);
                db.AddInParameter(dbCommand, "UserName", DbType.String, username);
                db.AddInParameter(dbCommand, "NewPassword", DbType.String, newPwd);
                db.AddInParameter(dbCommand, "PasswordSalt", DbType.String, DBNull.Value);
                db.AddInParameter(dbCommand, "CurrentTimeUtc", DbType.DateTime, DateTime.Now);
                db.AddInParameter(dbCommand, "PasswordFormat", DbType.Int32, GlobalConst.PasswordFormat);

                rowsAffected = db.ExecuteNonQuery(dbCommand);
            }
            catch (Exception ex)
            {
                bool l_Rethrow = ExceptionPolicy.HandleException(ex, GlobalConst.LogOnlyPolicy);
                if (l_Rethrow) throw;
            }

            if (rowsAffected > 0)
            {
                return true;
            }

            return false;
        }

        public bool ChangePasswordQuestionAndAnswer(string username, string newPwdQuestion, string newPwdAnswer)
        {
            int rowsAffected = 0;

            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                string sqlCommand = "USP_RESETPW";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

                db.AddInParameter(dbCommand, "Question", DbType.String, newPwdQuestion);
                db.AddInParameter(dbCommand, "Answer", DbType.String, newPwdAnswer);
                db.AddInParameter(dbCommand, "Username", DbType.String, username);

                rowsAffected = dbCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                bool l_Rethrow = ExceptionPolicy.HandleException(ex, GlobalConst.LogOnlyPolicy);
                if (l_Rethrow) throw;
            }

            if (rowsAffected > 0)
            {
                return true;
            }

            return false;
        }

        public MembershipUser CreateUser(int userId, string username, string firstName, string lastName, string email, string officePhone,
                   string institutionFullname, string departmentFullname, string divisionFullname, string p_Password, int p_PasswordFormat,
                   string p_PasswordQuestion, string p_PasswordAnswer, string p_ApplicationName, string p_Comment, bool p_IsApproved)
        {
            ProfilesMembershipUser l_ProfilesMembershipUser = null;
            try
            {
                Database db = DatabaseFactory.CreateDatabase(ConnectionStringName);
                string sqlCommand = "usp_membership_createuser";

                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                db.AddInParameter(dbCommand, "UserID", DbType.Int32, userId);
                db.AddInParameter(dbCommand, "FirstName", DbType.String, firstName);
                db.AddInParameter(dbCommand, "LastName ", DbType.String, lastName);
                db.AddInParameter(dbCommand, "OfficePhone", DbType.String, officePhone);
                db.AddInParameter(dbCommand, "EmailAddr", DbType.String, email);
                db.AddInParameter(dbCommand, "InstitutionFullname", DbType.String, institutionFullname);
                db.AddInParameter(dbCommand, "DepartmentFullname", DbType.String, departmentFullname);
                db.AddInParameter(dbCommand, "DivisionFullname", DbType.String, divisionFullname);
                db.AddInParameter(dbCommand, "UserName", DbType.String, username);
                db.AddInParameter(dbCommand, "PasswordSalt", DbType.String, "");
                db.AddInParameter(dbCommand, "Password", DbType.String, p_Password);
                db.AddInParameter(dbCommand, "PasswordFormat", DbType.Int32, p_PasswordFormat);
                db.AddInParameter(dbCommand, "PasswordQuestion", DbType.String, p_PasswordQuestion);
                db.AddInParameter(dbCommand, "PasswordAnswer", DbType.String, p_PasswordAnswer);
                db.AddInParameter(dbCommand, "ApplicationName", DbType.String, p_ApplicationName);
                db.AddInParameter(dbCommand, "Comment", DbType.String, p_Comment);
                db.AddInParameter(dbCommand, "IsApproved", DbType.Boolean, p_IsApproved);

                int rowsAffected = db.ExecuteNonQuery(dbCommand);
                if (rowsAffected > 0)
                {
                    DataRow l_UserRow = GetUser(username, false);
                    l_ProfilesMembershipUser = GetUserFromTableRow(l_UserRow);
                }
            }
            catch (Exception ex)
            {
                bool l_Rethrow = ExceptionPolicy.HandleException(ex, GlobalConst.LogOnlyPolicy);
                if (l_Rethrow) throw;
            }
            return l_ProfilesMembershipUser;
        }

        public MembershipUser CreateUser(string username, string password, string email, string passwordQuestion,
            string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            status = MembershipCreateStatus.Success;
            ProfilesMembershipUser l_ProfilesMembershipUser = null;
            try
            {
                Database db = DatabaseFactory.CreateDatabase(ConnectionStringName);
                string sqlCommand = "usp_membership_createuser";

                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                db.AddInParameter(dbCommand, "ApplicationName", DbType.String, GlobalConst.ApplicationName);
                db.AddInParameter(dbCommand, "UserName", DbType.String, username);
                db.AddInParameter(dbCommand, "Password", DbType.String, password);
                db.AddInParameter(dbCommand, "PasswordSalt", DbType.String, null);
                db.AddInParameter(dbCommand, "Email", DbType.String, email);
                db.AddInParameter(dbCommand, "PasswordQuestion", DbType.String, passwordQuestion);
                db.AddInParameter(dbCommand, "PasswordAnswer", DbType.String, passwordAnswer);
                db.AddInParameter(dbCommand, "IsApproved", DbType.Boolean, isApproved);
                db.AddInParameter(dbCommand, "CurrentTimeUtc", DbType.DateTime, DateTime.Now);
                db.AddInParameter(dbCommand, "CreateDate", DbType.DateTime, DateTime.Now);
                db.AddInParameter(dbCommand, "UniqueEmail", DbType.Int32, 1);
                db.AddInParameter(dbCommand, "PasswordFormat", DbType.Int32, GlobalConst.PasswordFormat);
                db.AddOutParameter(dbCommand, "UserId", DbType.Int32, sizeof(int));

                int affectedRows = db.ExecuteNonQuery(dbCommand);
                if (affectedRows > 0)
                {
                    IDataReader l_Reader = db.ExecuteReader(dbCommand);
                    l_ProfilesMembershipUser = GetUserFromReader(l_Reader);
                }
            }
            catch (Exception ex)
            {
                bool l_Rethrow = ExceptionPolicy.HandleException(ex, GlobalConst.LogOnlyPolicy);
                if (l_Rethrow) throw;
                status = MembershipCreateStatus.ProviderError;
            }
            return l_ProfilesMembershipUser;
        }


        public bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            bool isDeleted = false;
            try
            {
                Database db = DatabaseFactory.CreateDatabase(ConnectionStringName);
                string sqlCommand = "p_user_d";

                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                db.AddInParameter(dbCommand, "UserName", DbType.String, username);

                int affectedRows = db.ExecuteNonQuery(dbCommand);
                isDeleted = affectedRows > 0;
            }
            catch (Exception ex)
            {
                bool l_Rethrow = ExceptionPolicy.HandleException(ex, GlobalConst.LogOnlyPolicy);
                if (l_Rethrow) throw;
            }
            return isDeleted;
        }

        public MembershipUserCollection GetUsersByName(string name)
        {
            MembershipUserCollection users = new MembershipUserCollection();

            try
            {
                Database db = DatabaseFactory.CreateDatabase(ConnectionStringName);

                string sqlCommand = "p_User_sl_filter";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                db.AddInParameter(dbCommand, "ApplicationName", DbType.String, GlobalConst.ApplicationName);
                db.AddInParameter(dbCommand, "SearchValue", DbType.String, name);

                DataSet l_DataSet = db.ExecuteDataSet(dbCommand);
                foreach (DataTable l_Table in l_DataSet.Tables)
                {
                    foreach (DataRow l_Row in l_Table.Rows)
                    {
                        MembershipUser oneUser = GetUserFromTableRow(l_Row);
                        if (oneUser != null)
                        {
                            users.Add(oneUser);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                bool l_Rethrow = ExceptionPolicy.HandleException(ex, GlobalConst.LogOnlyPolicy);
                if (l_Rethrow) throw;
            }
            return users;
        }


        public MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, string searchValue, out int totalRecords)
        {
            MembershipUserCollection users = new MembershipUserCollection();

            totalRecords = 0;

            try
            {
                Database db = DatabaseFactory.CreateDatabase(ConnectionStringName);

                string sqlCommand = "usp_membership_getallusers";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                db.AddInParameter(dbCommand, "ApplicationName", DbType.String, GlobalConst.ApplicationName);
                db.AddInParameter(dbCommand, "PageIndex", DbType.Int32, pageIndex);
                db.AddInParameter(dbCommand, "PageSize", DbType.Int32, pageSize);
                db.AddInParameter(dbCommand, "SearchValue", DbType.String, searchValue);

                DataSet l_DataSet = db.ExecuteDataSet(dbCommand);
                foreach (DataTable l_Table in l_DataSet.Tables)
                {
                    foreach (DataRow l_Row in l_Table.Rows)
                    {
                        MembershipUser oneUser = GetUserFromTableRow(l_Row);
                        if (oneUser != null)
                        {
                            users.Add(oneUser);
                        }
                    }
                }

                totalRecords = db.ExecuteNonQuery(dbCommand);
            }
            catch (Exception ex)
            {
                bool l_Rethrow = ExceptionPolicy.HandleException(ex, GlobalConst.LogOnlyPolicy);
                if (l_Rethrow) throw;
            }

            return users;
        }

        public int GetUserPosition(int p_UserID)
        {
            int position = 0;
            try
            {
                Database db = DatabaseFactory.CreateDatabase(ConnectionStringName);

                string sqlCommand = "p_User_s_position";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                db.AddInParameter(dbCommand, "UserId", DbType.Int32, p_UserID);
                position = (int)db.ExecuteScalar(dbCommand);

            }
            catch (Exception ex)
            {
                bool l_Rethrow = ExceptionPolicy.HandleException(ex, GlobalConst.LogOnlyPolicy);
                if (l_Rethrow) throw;
            }

            return position;
        }

        public int GetNumberOfUsersOnline()
        {
            TimeSpan onlineSpan = new TimeSpan(0, System.Web.Security.Membership.UserIsOnlineTimeWindow, 0);
            DateTime compareTime = DateTime.Now.Subtract(onlineSpan);

            int numOnline = 0;

            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                string sqlCommand = "USP_RESETPW";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

                db.AddInParameter(dbCommand, "CompareDate", DbType.DateTime, compareTime);

                numOnline = (int)dbCommand.ExecuteScalar();
            }
            catch (Exception ex)
            {
                bool l_Rethrow = ExceptionPolicy.HandleException(ex, GlobalConst.LogOnlyPolicy);
                if (l_Rethrow) throw;
                return 0;
            }

            return numOnline;
        }


        public string GetPassword(string username, string answer)
        {
            string password = "";
            string passwordAnswer = "";
            IDataReader reader = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase(ConnectionStringName);
                DbCommand dbCommand = db.GetStoredProcCommand("usp_membership_getpassword");
                db.AddInParameter(dbCommand, "ApplicationName", DbType.String, GlobalConst.ApplicationName);
                db.AddInParameter(dbCommand, "UserName", DbType.String, username);
                db.AddInParameter(dbCommand, "MaxInvalidPasswordAttempts", DbType.Int32, 1);
                db.AddInParameter(dbCommand, "PasswordAttemptWindow", DbType.Int32, 1);
                db.AddInParameter(dbCommand, "CurrentTimeUtc", DbType.DateTime, DateTime.Now);
                db.AddInParameter(dbCommand, "PasswordAnswer", DbType.String, answer);


                reader = db.ExecuteReader(dbCommand);

                if (reader != null)
                {
                    if (reader.Read())
                    {
                        password = reader.GetString(0);
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                bool l_Rethrow = ExceptionPolicy.HandleException(ex, GlobalConst.LogOnlyPolicy);
                if (l_Rethrow) throw;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }

            return password;
        }

        public DataRow GetUser(string username, bool updateUserActivity)
        {
            DataRow row = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase(ConnectionStringName);

                string sqlCommand = "usp_membership_getuserbyname";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

                db.AddInParameter(dbCommand, "UserName", DbType.String, username);
                db.AddInParameter(dbCommand, "CurrentTimeUtc", DbType.DateTime, DateTime.Now);
                db.AddInParameter(dbCommand, "UpdateLastActivity", DbType.Boolean, updateUserActivity);

                DataSet ds = db.ExecuteDataSet(dbCommand);
                if (ds != null)
                {
                    if (ds.Tables.Count == 1)
                    {
                        DataTable l_tbl = ds.Tables[0];
                        if (l_tbl.Rows.Count == 1)
                            row = l_tbl.Rows[0];
                    }
                }
            }
            catch (Exception ex)
            {
                bool l_Rethrow = ExceptionPolicy.HandleException(ex, GlobalConst.LogOnlyPolicy);
                if (l_Rethrow) throw;
            }

            return row;
        }

        public IDataReader GetUser(object providerUserKey, bool userIsOnline)
        {
            IDataReader reader = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                string sqlCommand = "USP_RESETPW";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

                db.AddInParameter(dbCommand, "PKID", DbType.String, providerUserKey);

                reader = dbCommand.ExecuteReader();
            }
            catch (Exception ex)
            {
                bool l_Rethrow = ExceptionPolicy.HandleException(ex, GlobalConst.LogOnlyPolicy);
                if (l_Rethrow) throw;
            }
            finally
            {
                if (reader != null) { reader.Close(); }
            }

            return reader;
        }





        //
        // MembershipProvider.UnlockUser
        //
        public bool UnlockUser(string username)
        {
            int rowsAffected = 0;

            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                string sqlCommand = "USP_RESETPW";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

                db.AddInParameter(dbCommand, "LastLockedOutDate", DbType.DateTime, DateTime.Now);
                db.AddInParameter(dbCommand, "Username", DbType.String, username);

                rowsAffected = dbCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                bool l_Rethrow = ExceptionPolicy.HandleException(ex, GlobalConst.LogOnlyPolicy);
                if (l_Rethrow) throw;
            }

            // PRG: check this
            if (rowsAffected > 0)
                return true;

            return false;
        }


        //
        // MembershipProvider.GetUserNameByEmail
        //

        public string GetUserNameByEmail(string email)
        {
            string username = "";

            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                string sqlCommand = "USP_RESETPW";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

                db.AddInParameter(dbCommand, "Email", DbType.String, email);

                username = (string)dbCommand.ExecuteScalar();
            }
            catch (Exception ex)
            {
                bool l_Rethrow = ExceptionPolicy.HandleException(ex, GlobalConst.LogOnlyPolicy);
                if (l_Rethrow) throw;
            }

            if (username == null)
                username = "";

            return username;
        }

        // Check Lockout
        public string CheckUserLockOutCondition(string username)
        {
            string passwordAnswer = "";
            IDataReader reader = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                string sqlCommand = "USP_RESETPW";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

                db.AddInParameter(dbCommand, "Username", DbType.String, username);

                reader = dbCommand.ExecuteReader(CommandBehavior.SingleRow);

                if (reader != null)
                {
                    reader.Read();

                    passwordAnswer = reader.GetString(0);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                bool l_Rethrow = ExceptionPolicy.HandleException(ex, GlobalConst.LogOnlyPolicy);
                if (l_Rethrow) throw;
            }
            finally
            {
                if (reader != null) { reader.Close(); }
            }

            return passwordAnswer;
        }


        //
        // MembershipProvider.ResetPassword
        //
        public string ResetPassword(string username, string newPassword)
        {
            int rowsAffected = 0;

            try
            {
                Database db = DatabaseFactory.CreateDatabase(ConnectionStringName);
                DbCommand dbCommand = db.GetStoredProcCommand("usp_membership_setpassword");
                db.AddInParameter(dbCommand, "ApplicationName", DbType.String, GlobalConst.ApplicationName);
                db.AddInParameter(dbCommand, "UserName", DbType.String, username);
                db.AddInParameter(dbCommand, "NewPassword", DbType.String, newPassword);
                db.AddInParameter(dbCommand, "PasswordSalt", DbType.String, DBNull.Value);
                db.AddInParameter(dbCommand, "CurrentTimeUtc", DbType.DateTime, DateTime.Now);
                db.AddInParameter(dbCommand, "PasswordFormat", DbType.Int32, GlobalConst.PasswordFormat);

                rowsAffected = db.ExecuteNonQuery(dbCommand);
            }
            catch (Exception ex)
            {
                bool l_Rethrow = ExceptionPolicy.HandleException(ex, GlobalConst.LogOnlyPolicy);
                if (l_Rethrow) throw;
            }

            if (rowsAffected > 0)
            {
                return newPassword;
            }
            else
            {
                return null;
                // new MembershipPasswordException("User not found, or user is locked out. Password not Reset.");
            }
        }


        public void UpdateUser(MembershipUser user)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                string sqlCommand = "USP_RESETPW";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

                db.AddInParameter(dbCommand, "Email", DbType.String, user.Email);
                db.AddInParameter(dbCommand, "Comment", DbType.String, user.Comment);
                db.AddInParameter(dbCommand, "IsApproved", DbType.Boolean, user.IsApproved);
                db.AddInParameter(dbCommand, "Username", DbType.String, user.UserName);

                dbCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                bool l_Rethrow = ExceptionPolicy.HandleException(ex, GlobalConst.LogOnlyPolicy);
                if (l_Rethrow) throw;
            }
        }

        public string GetUserPassword(string username, int maxInvalidPasswordAttempts, int passwordAttemptWindow)
        {
            IDataReader reader = null;
            string pwd = "";

            try
            {
                Database db = DatabaseFactory.CreateDatabase(ConnectionStringName);

                string sqlCommand = "usp_membership_getpassword";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

                db.AddInParameter(dbCommand, "ApplicationName", DbType.String, GlobalConst.ApplicationName);
                db.AddInParameter(dbCommand, "Username", DbType.String, username);
                db.AddInParameter(dbCommand, "MaxInvalidPasswordAttempts", DbType.Int32, maxInvalidPasswordAttempts);
                db.AddInParameter(dbCommand, "PasswordAttemptWindow", DbType.Int32, passwordAttemptWindow);
                db.AddInParameter(dbCommand, "CurrentTimeUtc", DbType.DateTime, DateTime.Now);
                db.AddInParameter(dbCommand, "PasswordAnswer", DbType.String, null);

                reader = db.ExecuteReader(dbCommand);

                if (((System.Data.SqlClient.SqlDataReader)reader).HasRows)
                {
                    reader.Read();
                    pwd = reader.GetString(0);
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                bool l_Rethrow = ExceptionPolicy.HandleException(ex, GlobalConst.LogOnlyPolicy);
                if (l_Rethrow) throw;
            }


            return pwd;
        }

        public void LogLastUserLogin(string username)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                string sqlCommand = "USP_LOGLAST_LOGIN";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

                db.AddInParameter(dbCommand, "LastLoginDate", DbType.DateTime, DateTime.Now);
                db.AddInParameter(dbCommand, "Username", DbType.String, username);

                dbCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                bool l_Rethrow = ExceptionPolicy.HandleException(ex, GlobalConst.LogOnlyPolicy);
                if (l_Rethrow) throw;
            }
        }

        //
        // UpdateFailureCount
        //   A helper method that performs the checks and updates associated with
        // password failure tracking.
        //
        public void UpdateFailureCount(string username, string failureType, int passwordAttemptWindow, int maxInvalidPasswordAttempts)
        {
            IDataReader reader = null;
            DateTime windowStart = new DateTime();
            int failureCount = 0;

            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                string sqlCommand = "USP_RESETPW";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

                db.AddInParameter(dbCommand, "Username", DbType.String, username);

                reader = dbCommand.ExecuteReader(CommandBehavior.SingleRow);

                if (reader != null)
                {
                    reader.Read();

                    if (failureType == "password")
                    {
                        failureCount = reader.GetInt32(0);
                        windowStart = reader.GetDateTime(1);
                    }

                    if (failureType == "passwordAnswer")
                    {
                        failureCount = reader.GetInt32(2);
                        windowStart = reader.GetDateTime(3);
                    }
                }

                reader.Close();

                DateTime windowEnd = windowStart.AddMinutes(passwordAttemptWindow);

                if (failureCount == 0 || DateTime.Now > windowEnd)
                {
                    // First password failure or outside of PasswordAttemptWindow. 
                    // Start a new password failure count from 1 and a new window starting now.

                    // reset the SQL command
                    sqlCommand = "";

                    if (failureType == "password")
                        sqlCommand = "SPGOESHERE";

                    if (failureType == "passwordAnswer")
                        sqlCommand = "OTHER_SPGOESHERE";

                    dbCommand.Parameters.Clear();

                    db.AddInParameter(dbCommand, "Count", DbType.Int32, 1);
                    db.AddInParameter(dbCommand, "WindowStart", DbType.DateTime, DateTime.Now);
                    db.AddInParameter(dbCommand, "Username", DbType.String, username);

                    dbCommand.ExecuteNonQuery();
                }
                else
                {
                    if (failureCount++ >= maxInvalidPasswordAttempts)
                    {
                        // Password attempts have exceeded the failure threshold. Lock out
                        // the user

                        sqlCommand = "SPGOESHERE";

                        dbCommand.Parameters.Clear();

                        db.AddInParameter(dbCommand, "IsLockedOut", DbType.Boolean, true);
                        db.AddInParameter(dbCommand, "LastLockedOutDate", DbType.DateTime, DateTime.Now);
                        db.AddInParameter(dbCommand, "Username", DbType.String, username);

                        dbCommand.ExecuteNonQuery();
                    }
                    else
                    {
                        // Password attempts have not exceeded the failure threshold. Update
                        // the failure counts. Leave the window the same.
                        // reset the SQL command
                        sqlCommand = "";

                        if (failureType == "password")
                            sqlCommand = "SPGOESHERE";

                        if (failureType == "passwordAnswer")
                            sqlCommand = "OTHER_SPGOESHERE";

                        dbCommand.Parameters.Clear();

                        db.AddInParameter(dbCommand, "Count", DbType.Int32, failureCount);
                        db.AddInParameter(dbCommand, "Username", DbType.String, username);

                        dbCommand.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                bool l_Rethrow = ExceptionPolicy.HandleException(ex, GlobalConst.LogOnlyPolicy);
                if (l_Rethrow) throw;
            }
            finally
            {
                if (reader != null) { reader.Close(); }
            }
        }


        //
        // MembershipProvider.FindUsersByName
        //

        public MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            MembershipUserCollection users = new MembershipUserCollection();

            IDataReader reader = null;
            totalRecords = 0;

            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                string sqlCommand = "USERNAME SEARCH";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

                db.AddInParameter(dbCommand, "UsernameSearch", DbType.String, usernameToMatch);

                totalRecords = (int)dbCommand.ExecuteScalar();

                if (totalRecords <= 0) { return users; }

                sqlCommand = "GET USER BY USERNAME";

                // Using the previously added parameter
                reader = dbCommand.ExecuteReader();

                int counter = 0;
                int startIndex = pageSize * pageIndex;
                int endIndex = startIndex + pageSize - 1;

                while (reader.Read())
                {
                    if (counter >= startIndex)
                    {
                        MembershipUser u = GetUserFromReader(reader);
                        users.Add(u);
                    }

                    if (counter >= endIndex) { dbCommand.Cancel(); }

                    counter++;
                }
            }
            catch (Exception ex)
            {
                bool l_Rethrow = ExceptionPolicy.HandleException(ex, GlobalConst.LogOnlyPolicy);
                if (l_Rethrow) throw;
            }
            finally
            {
                if (reader != null) { reader.Close(); }
            }

            return users;
        }

        //
        // MembershipProvider.FindUsersByEmail
        //

        public MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            MembershipUserCollection users = new MembershipUserCollection();

            IDataReader reader = null;
            totalRecords = 0;

            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                string sqlCommand = "EMAIL SEARCH";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

                db.AddInParameter(dbCommand, "EmailSearch", DbType.String, emailToMatch);

                totalRecords = (int)dbCommand.ExecuteScalar();

                if (totalRecords <= 0) { return users; }

                sqlCommand = "GET USER BY EMAIL";

                // Using the previously added parameter
                reader = dbCommand.ExecuteReader();

                int counter = 0;
                int startIndex = pageSize * pageIndex;
                int endIndex = startIndex + pageSize - 1;

                while (reader.Read())
                {
                    if (counter >= startIndex)
                    {
                        MembershipUser u = GetUserFromReader(reader);
                        users.Add(u);
                    }

                    if (counter >= endIndex) { dbCommand.Cancel(); }

                    counter++;
                }
            }
            catch (Exception ex)
            {
                bool l_Rethrow = ExceptionPolicy.HandleException(ex, GlobalConst.LogOnlyPolicy);
                if (l_Rethrow) throw;
            }
            finally
            {
                if (reader != null) { reader.Close(); }
            }

            return users;
        }

        public DataRow GetUserByID(int p_UserID)
        {
            DataRow userRow = null;
            try
            {
                Database db = DatabaseFactory.CreateDatabase(ConnectionStringName);

                string sqlCommand = "p_User_s_byID";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

                db.AddInParameter(dbCommand, "UserID", DbType.Int32, p_UserID);
                DataSet ds = db.ExecuteDataSet(dbCommand);
                if (ds != null)
                {
                    if (ds.Tables.Count == 1)
                    {
                        DataTable l_tbl = ds.Tables[0];
                        if (l_tbl.Rows.Count == 1)
                            userRow = l_tbl.Rows[0];
                    }
                }
            }
            catch (Exception ex)
            {
                bool l_Rethrow = ExceptionPolicy.HandleException(ex, GlobalConst.LogOnlyPolicy);
                if (l_Rethrow) throw;
            }
            return userRow;
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
            object providerUserKey = reader.GetValue(0);
            string username = reader.GetString(1);
            string email = reader.GetString(0);

            string passwordQuestion = "";
            if (reader.GetValue(1) != DBNull.Value)
                passwordQuestion = reader.GetString(1);

            string comment = "";
            if (reader.GetValue(2) != DBNull.Value)
                comment = reader.GetString(2);

            bool isApproved = reader.GetBoolean(3);
            bool isLockedOut = reader.GetBoolean(10);
            DateTime creationDate = reader.GetDateTime(5);

            DateTime lastLoginDate = new DateTime();
            if (reader.GetValue(6) != DBNull.Value)
                lastLoginDate = reader.GetDateTime(6);

            DateTime lastActivityDate = reader.GetDateTime(7);
            DateTime lastPasswordChangedDate = reader.GetDateTime(8);

            DateTime lastLockedOutDate = new DateTime();
            if (reader.GetValue(11) != DBNull.Value)
                lastLockedOutDate = reader.GetDateTime(11);

            int userId = reader.GetInt32(9);
            bool hasProfile = reader.GetBoolean(12);

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
                                                                  displayName, firstName, lastName, departmentFullname,
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
                    int.TryParse((string)tableRow["profileId"], out profileId);
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