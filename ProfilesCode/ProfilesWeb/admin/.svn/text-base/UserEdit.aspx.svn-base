<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="UserEdit.aspx.cs" Inherits="UserEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server" />
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="fieldset">
        <div class="top">
            <div>
                <div>
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <th>
                                <asp:Label ID="lbHeader" runat="server"></asp:Label>                                
                            </th>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
        
        <div class="middle">
            <div class="right">
             
             <asp:PlaceHolder ID="phContent" runat="server">                
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
                            <asp:ImageButton ID="lbSave" runat="server" ToolTip="Save" OnClick="lbSave_Click" ImageUrl="~/images/saveButton.gif" />
                            <asp:HyperLink ID="hlCancel" runat="server" ToolTip="Cancel" ImageUrl="~/images/cancelButton.gif" NavigateUrl="~/AllUsers.aspx"></asp:HyperLink>
                            <asp:HyperLink ID="hlPasword" runat="server" ToolTip="Change Password" ImageUrl="~/images/passwordButton.gif" NavigateUrl="~/ChangePassword.aspx" Visible="false"></asp:HyperLink>
                        </td>
                    </tr>
                    </table>
                    <asp:Label ID="lGeneralError" runat="server" Text="Error." CssClass="ErrorField" EnableViewState="false" Visible="false"></asp:Label>
             </asp:PlaceHolder>   
             
             <asp:PlaceHolder ID="phMainError" runat="server" Visible="false">
                <p>
                    <asp:Label ID="lbMainError" runat="server" CssClass="ErrorField" EnableViewState="false"></asp:Label>
                </p>
             </asp:PlaceHolder>
            
            </div>
        </div>
        
        
        <div class="bottom">
            <div>
                <div></div>
            </div>
        </div>
        
    </div>
</asp:Content>

