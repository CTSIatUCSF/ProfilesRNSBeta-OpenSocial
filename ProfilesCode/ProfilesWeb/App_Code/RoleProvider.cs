using System;
using System.Collections.Specialized;
using System.Web.Security;

/// <summary>
/// Summary description for RoleProvider
/// </summary>
public class CustomRoleProvider : RoleProvider
{
    private string m_ApplicationName;
    public override void Initialize(string name, NameValueCollection config)
    {
        base.Initialize(name, config);
        m_ApplicationName = GetConfigValue(config["applicationName"],
                                           System.Web.Hosting.HostingEnvironment.ApplicationVirtualPath);
    }

    private static string GetConfigValue(string configValue, string defaultValue)
    {
        if (String.IsNullOrEmpty(configValue))
            return defaultValue;

        return configValue;
    }

    public override bool IsUserInRole(string username, string roleName)
    {
        return new RoleProviderBL().UserExistsInRole(username, roleName);
    }

    public override string[] GetRolesForUser(string username)
    {
        return new RoleProviderBL().GetRolesForUser(username);
    }

    public override void CreateRole(string roleName)
    {
        new RoleProviderBL().CreateRole(roleName);
    }

    public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
    {
        return new RoleProviderDA().DeleteRole(roleName);
    }
    
    public override bool RoleExists(string roleName)
    {
        return new RoleProviderBL().ExistsRole(roleName);
    }

    public override void AddUsersToRoles(string[] usernames, string[] roleNames)
    {
        new RoleProviderBL().AddUsersToRoles(usernames, roleNames);
    }

    public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
    {
        new RoleProviderBL().RemoveUsersFromRoles(usernames, roleNames);
    }

    public override string[] GetUsersInRole(string roleName)
    {
        return new RoleProviderBL().GetUsersInRole(roleName);
    }

    public override string[] GetAllRoles()
    {
        return new RoleProviderBL().GetAllRolesNames(); 
    }

    public override string[] FindUsersInRole(string roleName, string usernameToMatch)
    {
        return new RoleProviderBL().FindUsersInRole(roleName, usernameToMatch);
    }

    public override string ApplicationName
    {
        get { return m_ApplicationName; }
        set { m_ApplicationName = value; }
    }

    public override string Name
    {
        get
        {
            return "CustomRoleProvider";
        }
    }
}