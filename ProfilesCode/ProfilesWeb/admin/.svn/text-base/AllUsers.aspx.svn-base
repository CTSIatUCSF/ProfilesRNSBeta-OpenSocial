<%@ Page Title="All Users" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="AllUsers.aspx.cs" Inherits="AllUsers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server" >
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script src="JQuery/jquery.js" type="text/javascript"></script>
   <script type="text/javascript">
       jQuery.noConflict();
       $(document).ready(function() {
       $("#<%=lstColumns.ClientID %>").dropdownchecklist({ maxDropHeight: 120, width: 170 });
       });

    </script>
    
    <div class="fieldset">
        <div class="top">
            <div>
                <div>
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <th>
                                All Users
                            </th>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
        <div class="middle">
            <div class="right">
<table cellpadding="0" cellspacing="0" width="100%">
    <tr><td>
    <table cellpadding="0" cellspacing="0"><tr>
        <th>
            Search:
        </th>
        <td style="padding:0 5px">
            <asp:TextBox Width="100"  runat="server" ID="tbSearch" />
        </td>
        <td>
            <asp:ImageButton runat="server" ID="lbSearch" OnClick="lbSearch_Click" AlternateText="Search" ImageUrl="~/images/btnSearch.gif" />
        </td>
        <th style="padding-left:25px">
            Columns:
        </th>
        <td style="padding:0 5px">
            <asp:ListBox SelectionMode="Multiple" runat="server" ID="lstColumns" Height="20" />
        </td>
        <td>
       <asp:ImageButton runat="server" ID="bShowSelectedColumns" AlternateText="Filter by Columns" 
        onclick="bShowSelectedColumns_Click" ImageUrl="~/images/btnFilter.gif" />&nbsp;&nbsp;
        </td>
</tr></table></td>
        <td align="right">
         <asp:ImageButton ID="lbNew" runat="server" onclick="lbNew_Click" ToolTip="New" ImageUrl="~/images/newButton.gif" />
        </td>
        
  
    </tr>
</table>                        

 <asp:ObjectDataSource ID="dataSourceUsers" runat="server"
EnableCaching="True" CacheKeyDependency="CacheKeyDependency"
EnablePaging="True"
SelectMethod="GetAllProfileUsers" SelectCountMethod="GetAllUsersCount"
TypeName="Connects.Profiles.BusinessLogic.ProfilesDBMembershipProviderBL">
<SelectParameters >
 <asp:ControlParameter ControlID="tbSearch" DefaultValue="" 
              Name="search" PropertyName="Text" />
</SelectParameters>
</asp:ObjectDataSource>

<asp:Label ID="lSuccess" runat="server" Text="User was saved successfully." CssClass="SuccessField" EnableViewState="false" Visible="false"></asp:Label>
<asp:Label ID="lGeneralError" runat="server" Text="Error." CssClass="ErrorField" EnableViewState="false" Visible="false"></asp:Label>

<div id="divEditor" runat="server" style="display:none">
<table class="edit" align="center">
<tr>
    <td valign="top" width="170">
        <b>Please specify user roles:</b><br />
        <asp:Literal ID="lNoRoles" Visible="false" runat="server" Text="There are no roles added in system."></asp:Literal>
        <asp:CheckBoxList ID="cblRoles" runat="server">
        </asp:CheckBoxList>
    </td>
    <td width="510">
        <table class="edit">
            <tr>
                <th>
                    First Name <span class="RequiredField">*</span>:
                </th>
                <td><asp:TextBox ID="tbFirstName" runat="server"></asp:TextBox></td>        
            </tr>
            <tr>
                <th>
                    Last Name <span class="RequiredField">*</span>:
                </th>
                <td><asp:TextBox ID="tbLastName" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <th>
                    Login <span class="RequiredField">*</span>:
                </th>
                <td><asp:TextBox ID="tbLogin" runat="server"></asp:TextBox>
                    <asp:Label ID="lInvalidLogin" Visible="false" EnableViewState="false" CssClass="ErrorField" runat="server" Text="This login allready exists in system"></asp:Label>
                </td>
            </tr>
            <div runat="server" id="divPassworArea">
                <tr>
                    <th>Password <span class="RequiredField">*</span>:
                    </th>
                    <td><asp:TextBox ID="tbPassword" TextMode="Password" runat="server"></asp:TextBox>
                        <asp:Label ID="lInvalidPassword" Visible="false" EnableViewState="false" CssClass="ErrorField" runat="server" Text="Password and confirm password do not match"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <th>Confirm <span class="RequiredField">*</span>:
                    </th>
                    <td><asp:TextBox ID="tbConfirmPassword" TextMode="Password" runat="server"></asp:TextBox>
                    </td>
                </tr>
            </div>
            <tr>
                <th>
                    Email <span class="RequiredField">*</span>:
                </th>
                <td><asp:TextBox ID="tbEmail" runat="server"></asp:TextBox>
                    <asp:Label ID="lInvalidEmail" Visible="false" EnableViewState="false" CssClass="ErrorField" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>Security Question <span class="RequiredField">*</span>:
                </th>
                <td>
                    <asp:TextBox ID="tbPasswordQuestion" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>Security Answer <span class="RequiredField">*</span>:
                </th>
                <td>
                    <asp:TextBox ID="tbPasswordAnswer" runat="server"></asp:TextBox>
                </td>
            </tr> 
            <tr>
                <th>Office Phone:</th>
                <td>
                    <asp:TextBox ID="tbOfficePhone" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>Institution:</th>
                <td>
                    <asp:TextBox ID="tbInstitutionFullname" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>Department:</th>
                <td>
                    <asp:TextBox ID="tbDepartmentFullname" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>Division:</th>
                <td>
                    <asp:TextBox ID="tbDivisionFullname" runat="server"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <th valign="top">Comment:</th>
                <td>
                    <asp:TextBox ID="tbComments" TextMode="MultiLine" Rows="4" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
    </td>
</tr>
<tr>
    <td colspan="2" align="center">       
    </td>
</tr>
</table>

    
</div> 

<div style="overflow-x:scroll;margin:10px 0">
<asp:GridView runat="server" ID="gridUsers" 
 OnDataBound="gridUsers_DataBound" 
DataSourceID="dataSourceUsers" AllowPaging="True" onrowcommand="gridUsers_RowCommand" 
                    CellPadding="0" CssClass="results" Width="100%" 
                    PagerStyle-CssClass="pager" AutoGenerateColumns="False">
    <Columns>
        <asp:CheckBoxField DataField="HasProfile" HeaderText="HasProfile" 
            ReadOnly="True" SortExpression="HasProfile" />
        <asp:BoundField DataField="UserID" HeaderText="UserID" ReadOnly="True" 
            SortExpression="UserID" />
        <asp:BoundField DataField="ProfileID" HeaderText="ProfileID" 
            SortExpression="ProfileID" ReadOnly="True" />
        <asp:BoundField DataField="DisplayName" HeaderText="DisplayName" 
            ReadOnly="True" SortExpression="DisplayName" />
        <asp:BoundField DataField="FirstName" HeaderText="FirstName" 
            SortExpression="FirstName" ReadOnly="True" />
        <asp:BoundField DataField="LastName" HeaderText="LastName" ReadOnly="True" 
            SortExpression="LastName" />
        <asp:BoundField DataField="FullName" HeaderText="FullName" ReadOnly="True" 
            SortExpression="FullName" />
        <asp:BoundField DataField="DepartmentFullname" HeaderText="DepartmentFullname" 
            ReadOnly="True" SortExpression="DepartmentFullname" />
        <asp:BoundField DataField="DivisionFullname" HeaderText="DivisionFullname" 
            ReadOnly="True" SortExpression="DivisionFullname" />
        <asp:BoundField DataField="InstitutionFullname" 
            HeaderText="InstitutionFullname" ReadOnly="True" 
            SortExpression="InstitutionFullname" />
        <asp:BoundField DataField="OfficePhone" HeaderText="OfficePhone" 
            ReadOnly="True" SortExpression="OfficePhone" />
        <asp:BoundField DataField="PasswordAnswer" HeaderText="PasswordAnswer" 
            ReadOnly="True" SortExpression="PasswordAnswer" />
        <asp:BoundField DataField="UserName" HeaderText="UserName" ReadOnly="True" 
            SortExpression="UserName" />
        <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
        <asp:BoundField DataField="PasswordQuestion" HeaderText="PasswordQuestion" 
            ReadOnly="True" SortExpression="PasswordQuestion" />
        <asp:BoundField DataField="Comment" HeaderText="Comment" 
            SortExpression="Comment" />
        <asp:CheckBoxField DataField="IsApproved" HeaderText="IsApproved" 
            SortExpression="IsApproved" />
        <asp:CheckBoxField DataField="IsLockedOut" HeaderText="IsLockedOut" 
            ReadOnly="True" SortExpression="IsLockedOut" />
        <asp:BoundField DataField="LastLockoutDate" HeaderText="LastLockoutDate" 
            ReadOnly="True" SortExpression="LastLockoutDate" />
        <asp:BoundField DataField="CreationDate" HeaderText="CreationDate" 
            ReadOnly="True" SortExpression="CreationDate" />
        <asp:BoundField DataField="LastLoginDate" HeaderText="LastLoginDate" 
            SortExpression="LastLoginDate" />
        <asp:BoundField DataField="LastActivityDate" HeaderText="LastActivityDate" 
            SortExpression="LastActivityDate" />
        <asp:BoundField DataField="LastPasswordChangedDate" 
            HeaderText="LastPasswordChangedDate" ReadOnly="True" 
            SortExpression="LastPasswordChangedDate" />
        <asp:CheckBoxField DataField="IsOnline" HeaderText="IsOnline" ReadOnly="True" 
            SortExpression="IsOnline" />
        <asp:BoundField DataField="ProviderName" HeaderText="ProviderName" 
            ReadOnly="True" SortExpression="ProviderName" />
            
                       <asp:TemplateField>
                <ItemTemplate>             
                        <asp:LinkButton CommandArgument='<%# Bind("UserID") %>' CommandName="EditUser" ID="lbEditUser" runat="server">Edit</asp:LinkButton>
                    </ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField>
             <ItemTemplate>
                      <asp:LinkButton ID="lbDelete" runat="server" 
                            CommandArgument='<%# Bind("UserName") %>' CommandName="DeleteUser" OnClientClick="return window.confirm('Are you sure thet you want to delete this user?');">Delete</asp:LinkButton>     
             </ItemTemplate>
           </asp:TemplateField>
            
    </Columns>

<PagerStyle CssClass="pager"></PagerStyle>
</asp:GridView></div>
<table cellpadding="0" cellspacing="0">
    <tr>
        <th align="left" width="65">
            Page Size:
        </th>
        <td>
            <asp:DropDownList runat="server" ID="ddlPageSizes" AutoPostBack="true" onselectedindexchanged="ddlPageSizes_SelectedIndexChanged">
                <asp:ListItem Value="25" Selected="True"  />
                <asp:ListItem Value="50" />
                <asp:ListItem Value="100" />
            </asp:DropDownList>
        </td>
    </tr>
</table>

            </div>
        </div>
        <div class="bottom">
            <div>
                <div></div>
            </div>
        </div>
    </div>
</asp:Content>

