<%@ Page Title="Roles" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="AllRoles.aspx.cs" Inherits="AllRoles" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="fieldset">
        <div class="top">
            <div>
                <div>
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <th>
                                All Roles
                            </th>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
        <div class="middle">
            <div class="right">

<div style="text-align:right;height:30px">
<asp:ImageButton ID="lbNew" runat="server" onclick="lbNew_Click" ToolTip="New" ImageUrl="~/images/newButton.gif" />
</div>
<asp:Repeater ID="rRoles" runat="server" onitemcommand="rptBrand_ItemCommand" 
        onitemdatabound="rptBrand_ItemDataBound">
        <HeaderTemplate>
            <table cellpadding="0" cellspacing="0" class="results" width="100%">
                <tr>
                    <th align="left">Role Name
                    </th>                    
                    <th width="35">
                    </th>
                    <th width="35">
                    </th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
                <tr id="trRepeaterRow" runat="server">
                    <td>
                        <%# DataBinder.Eval(Container.DataItem, "RoleName")%>
                    </td>                    
                    <td>
                        <asp:LinkButton ID="lbEdit" runat="server" 
                            CommandArgument='<%# Bind("RoleName") %>' CommandName="Edit">Edit</asp:LinkButton>
                            
                        <asp:LinkButton ID="lbCancel" runat="server" 
                            CommandArgument='<%# Bind("RoleName") %>' CommandName="Cancel">Cancel</asp:LinkButton>
                    </td>
                     <td>
                        <asp:LinkButton ID="lbDelete" runat="server" 
                            CommandArgument='<%# Bind("RoleName") %>' CommandName="Delete" OnClientClick="return window.confirm('Are you sure thet you want to delete this role?');">Delete</asp:LinkButton>                            
                    </td>
                </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
</asp:Repeater>
<asp:Label ID="lNoItems" Text="No records were found." runat="server" />
<asp:Label ID="lSuccess" runat="server" Text="Role was saved successfully." CssClass="SuccessField" EnableViewState="false" Visible="false"></asp:Label>
<asp:Label ID="lGeneralError" runat="server" Text="Error." CssClass="ErrorField" EnableViewState="false" Visible="false"></asp:Label>

<div id="divEditor" runat="server" style="display:none">
<table class="edit" align="center">
<tr>    
    <td width="510">
        <table class="edit">
            <tr>
                <th>
                    Role Name <span class="RequiredField">*</span>:
                </th>
                <td><asp:TextBox ID="tbRoleName" runat="server"></asp:TextBox>
                    <asp:Label ID="lInvalidRole" Visible="false" EnableViewState="false" CssClass="ErrorField" runat="server" Text="This role allready exists in system"></asp:Label>
                </td>        
            </tr>            
        </table>
    </td>
</tr>
<tr>
    <td align="center">       
        
        <asp:ImageButton ID="lbSave" runat="server" ToolTip="Save" OnClick="lbSave_Click" ImageUrl="~/images/saveButton.gif" />
        <asp:ImageButton ID="lbCancel" runat="server" ToolTip="Cancel" OnClick="lbCancel_Click" ImageUrl="~/images/cancelButton.gif" />
    </td>
</tr>
</table>

    
</div> 
            </div>
        </div>
        <div class="bottom">
            <div>
                <div></div>
            </div>
        </div>
    </div>

</asp:Content>

