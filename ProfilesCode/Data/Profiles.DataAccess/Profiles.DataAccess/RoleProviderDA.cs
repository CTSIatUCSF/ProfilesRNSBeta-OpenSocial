using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

/// <summary>
/// Summary description for RoleProviderDA
/// </summary>
public class RoleProviderDA
{
    private string MembershipDBConnectionName;
	public RoleProviderDA()
	{
        MembershipDBConnectionName = "ProfilesDB";
	}

    public IDataReader GetAllRolesNames()
    {
        IDataReader reader = null;
        try
        {
            Database db = DatabaseFactory.CreateDatabase(MembershipDBConnectionName);

            string sqlCommand = "p_Role_sl";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

            reader = db.ExecuteReader(dbCommand);
        }
        catch (Exception ex)
        {
            bool l_Rethrow = ExceptionPolicy.HandleException(ex, GlobalConst.LogOnlyPolicy);
            if (l_Rethrow)
                throw;
        }

        return reader;
    }

    public IDataReader GetUsersInRole(string roleName)
    {
        IDataReader reader = null;
        int? l_RoleId = GetRoleIDByName(roleName);
        if (l_RoleId.HasValue)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(MembershipDBConnectionName);
                string sqlCommand = "p_UserRole_sl_byRoleID";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                db.AddInParameter(dbCommand, "RoleID", DbType.Int32, l_RoleId.Value);

                reader = db.ExecuteReader(dbCommand);
                
            }
            catch (Exception ex)
            {
                bool l_Rethrow = ExceptionPolicy.HandleException(ex, GlobalConst.LogOnlyPolicy);
                if (l_Rethrow)
                    throw;
            }
        }
        return reader;
    }

    public IDataReader FindUsersInRole(string roleName, string usernameToMatch)
    {
        IDataReader reader = null;
        int? l_RoleId = GetRoleIDByName(roleName);
        if (l_RoleId.HasValue)
        {
            Database db = DatabaseFactory.CreateDatabase(MembershipDBConnectionName);
            string sqlCommand = "p_User_sl_byRoleName";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
            db.AddInParameter(dbCommand, "RoleID", DbType.Int32, l_RoleId.Value);
            db.AddInParameter(dbCommand, "UserName", DbType.String, usernameToMatch);

            reader = db.ExecuteReader(dbCommand);
        }
        return reader;
    }

    public int? GetRoleIDByName(string p_RoleName)
    {
        int? l_RoleID = null;
        IDataReader reader = null;
        try
        {
            Database db = DatabaseFactory.CreateDatabase(MembershipDBConnectionName);

            string sqlCommand = "p_Role_s_byName";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

            db.AddInParameter(dbCommand, "RoleName", DbType.String, p_RoleName);
            reader = db.ExecuteReader(dbCommand);
            
            if (reader.Read())
            {
                l_RoleID = reader.GetInt32(0);
            }
        }
        catch (Exception ex)
        {
            bool l_Rethrow = ExceptionPolicy.HandleException(ex, GlobalConst.LogOnlyPolicy);
            if (l_Rethrow)
                throw;
        }
        
        return l_RoleID;
    }


    public DataTable GetUserRoles(int p_UserID)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase(MembershipDBConnectionName);
            string sqlCommand = "p_UserRole_s_byUserID";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
            db.AddInParameter(dbCommand, "UserID", DbType.Int32, p_UserID);
            return db.ExecuteDataSet(dbCommand).Tables[0];
        }
        catch (Exception ex)
        {
            bool l_Rethrow = ExceptionPolicy.HandleException(ex, GlobalConst.LogOnlyPolicy);
            if (l_Rethrow)
                throw;
            else return null;
        }
    }

    public void AddUserRole(int p_UserID, int p_RoleID)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase(MembershipDBConnectionName);
            string sqlCommand = "p_UserRole_i";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
            db.AddInParameter(dbCommand, "UserID", DbType.Int32, p_UserID);
            db.AddInParameter(dbCommand, "RoleID", DbType.Int32, p_RoleID);
            db.ExecuteNonQuery(dbCommand);
        }
        catch (Exception ex)
        {
            bool l_Rethrow = ExceptionPolicy.HandleException(ex, GlobalConst.LogOnlyPolicy);
            if (l_Rethrow)
                throw;
        }
    }

    public void CreateRole(string p_RoleName)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase(MembershipDBConnectionName);
            string sqlCommand = "p_Role_iu";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
            db.AddInParameter(dbCommand, "RoleID", DbType.Int32, DBNull.Value);
            db.AddInParameter(dbCommand, "RoleName", DbType.String, p_RoleName == null ? DBNull.Value : (object)p_RoleName.Trim());
            db.ExecuteNonQuery(dbCommand);
        }
        catch (Exception ex)
        {
            bool l_Rethrow = ExceptionPolicy.HandleException(ex, GlobalConst.LogOnlyPolicy);
            if (l_Rethrow)
                throw;
        }
    }

    public bool DeleteRole(string p_RoleName)
    {
        int? l_RoleID = GetRoleIDByName(p_RoleName);
        if (l_RoleID.HasValue)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(MembershipDBConnectionName);
                string sqlCommand = "p_Role_d";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                db.AddInParameter(dbCommand, "RoleID", DbType.Int32, l_RoleID.Value);
                return db.ExecuteNonQuery(dbCommand) > 0;
            }
            catch (Exception ex)
            {
                bool l_Rethrow = ExceptionPolicy.HandleException(ex, GlobalConst.LogOnlyPolicy);
                if (l_Rethrow)
                    throw;
            }
        }

        return false;
    }

    public void RemoveUserFromRole(int p_UserID, int p_RoleID)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase(MembershipDBConnectionName);
            string sqlCommand = "p_UserRole_d";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
            db.AddInParameter(dbCommand, "UserID", DbType.Int32, p_UserID);
            db.AddInParameter(dbCommand, "RoleID", DbType.Int32, p_RoleID);
            db.ExecuteNonQuery(dbCommand);
        }
        catch (Exception ex)
        {
            bool l_Rethrow = ExceptionPolicy.HandleException(ex, GlobalConst.LogOnlyPolicy);
            if (l_Rethrow)
                throw;
        }
    }

    
}
