using System.Collections.Generic;
using System.Data;
using Connects.Profiles.DataAccess;

/// <summary>
/// Summary description for RoleProviderBL
/// </summary>
public class RoleProviderBL
{
	public RoleProviderBL()
	{
        
	}

    public string[] GetAllRolesNames()
    {
        IDataReader l_RoleReader = new RoleProviderDA().GetAllRolesNames();
        
        List<string> l_Roles = new List<string>();
        if (l_RoleReader != null)
        {
            if (((System.Data.SqlClient.SqlDataReader)l_RoleReader).HasRows)
            {
                while (l_RoleReader.Read())
                {
                    l_Roles.Add(l_RoleReader.GetString(1));
                }

                if (!l_RoleReader.IsClosed)
                {
                    l_RoleReader.Close();
                }
            }
        }

        return l_Roles.ToArray();
    }

    public string[] GetUsersInRole(string p_RoleName)
    {
        IDataReader l_RoleReader = new RoleProviderDA().GetUsersInRole(p_RoleName);

        List<string> l_Users = new List<string>();
        if (l_RoleReader != null)
        {
            if (((System.Data.SqlClient.SqlDataReader)l_RoleReader).HasRows)
            {
                while (l_RoleReader.Read())
                {
                    l_Users.Add(l_RoleReader.GetString(0));
                }

                if (!l_RoleReader.IsClosed)
                {
                    l_RoleReader.Close();
                }
            }
        }

        return l_Users.ToArray();
    }

    public string[] GetRolesForUser(string username)
    {
        DataRow l_UserRow = new ProfilesDBMembershipProviderDA().GetUser(username, false);
        if (l_UserRow != null)
        {
            int l_UserID = (int) l_UserRow["UserID"];
            DataTable l_userRoleTable = GetUserRoles(l_UserID);

            List<string> roleNames = new List<string>();
            foreach (DataRow l_RoleRow in l_userRoleTable.Rows)
            {
                //int l_RoleID = (int)l_RoleRow["RoleName"];
                //string l_RoleName = dbRole.GetRoleName(l_RoleID);
                roleNames.Add(l_RoleRow["RoleName"].ToString());
            }
            return roleNames.ToArray();
        }

        return null;
    }

    public string[] FindUsersInRole(string p_RoleName, string p_usernameToMatch)
    {
        IDataReader l_RoleReader = new RoleProviderDA().FindUsersInRole(p_RoleName, p_usernameToMatch);

        List<string> l_Users = new List<string>();
        if (l_RoleReader != null)
        {
            if (((System.Data.SqlClient.SqlDataReader)l_RoleReader).HasRows)
            {
                while (l_RoleReader.Read())
                {
                    l_Users.Add(l_RoleReader.GetString(13));
                }

                if (!l_RoleReader.IsClosed)
                {
                    l_RoleReader.Close();
                }
            }
        }

        return l_Users.ToArray();
    }

    public void AddUsersToRoles(string[] usernames, string[] roleNames)
    {
        if (usernames != null && roleNames != null)
        {
            foreach (string l_Username in usernames)
            {
                foreach (string l_RoleName in roleNames)
                {
                    AddUserToRole(l_Username, l_RoleName);
                }
            }
        }
    }

    public void CreateRole(string p_RoleName)
    {
        if (!ExistsRole(p_RoleName))
        {
            new RoleProviderDA().CreateRole(p_RoleName);
        }
    }

    public bool DeleteRole(string p_RoleName)
    {
        return new RoleProviderDA().DeleteRole(p_RoleName);
    }

    public bool ExistsRole(string p_RoleName)
    {
        return new RoleProviderDA().GetRoleIDByName(p_RoleName).HasValue;
    }

    private void AddUserToRole(string p_UserName, string p_UserRole)
    {
        DataRow l_DataRowUser = new ProfilesDBMembershipProviderDA().GetUser(p_UserName, false);
        int? l_RoleID = new RoleProviderDA().GetRoleIDByName(p_UserRole);

        if (l_DataRowUser != null && l_RoleID.HasValue)
        {
            int l_UserID = (int)l_DataRowUser["UserID"];

            if (!UserExistsInRole(l_UserID, l_RoleID.Value))
                AddUserRole(l_UserID, l_RoleID.Value);
        }
    }

    public DataTable GetUserRoles(int p_UserID)
    {
        return new RoleProviderDA().GetUserRoles(p_UserID);
    }

    public bool UserExistsInRole(string username, string rolename)
    {
        DataRow l_DataRowUser = new ProfilesDBMembershipProviderDA().GetUser(username, false);
        int? l_RoleID = new RoleProviderDA().GetRoleIDByName(rolename);

        if (l_DataRowUser != null && l_RoleID.HasValue)
        {
            int l_UserID = (int)l_DataRowUser["UserID"];
            return UserExistsInRole(l_UserID, l_RoleID.Value);
        }
        return false;
    }

    private bool UserExistsInRole(int p_UserID, int p_RoleID)
    {
        DataTable l_tblUserRoles = GetUserRoles(p_UserID);

        foreach (DataRow l_Row in l_tblUserRoles.Rows)
        {
            int l_userRoleID = (int)l_Row["RoleID"];
            if (p_RoleID == l_userRoleID)
                return true;
        }
        return false;
    }

    public void AddUserRole(int p_UserID, int p_RoleID)
    {
        new RoleProviderDA().AddUserRole(p_UserID, p_RoleID);
    }

    public void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
    {
        if (usernames != null && roleNames != null)
        {
            foreach (string l_RoleName in roleNames)
            {
                foreach (string l_Username in usernames)
                {
                    RemoveUserFromRole(l_Username, l_RoleName);
                }
            }
        }
    }

    private void RemoveUserFromRole(string username, string rolename)
    {
        if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(rolename))
        {
            DataRow l_UserRow = new ProfilesDBMembershipProviderDA().GetUser(username, false);

            int? l_RoleId = new RoleProviderDA().GetRoleIDByName(rolename);

            RoleProviderDA l_RPDA = new RoleProviderDA();

            if (l_UserRow != null && l_RoleId.HasValue)
            {
                int l_UserId = (int) l_UserRow["UserID"];
                l_RPDA.RemoveUserFromRole(l_UserId, l_RoleId.Value);
            }
        }
    }
}
