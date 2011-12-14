<%@ Page Title="ChangePassword" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server" />

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="fieldset">
        <div class="top">
            <div>
                <div>
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <th>
                                Change Password
                            </th>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
        <div class="middle">
            <div class="right">
                <table align="center"><tr><td><asp:ChangePassword
                    OnCancelButtonClick="ChangePassword1_Cancel" 
    OnContinueButtonClick="ChangePassword1_ContinueButtonClick"
                 ID="ChangePassword1" runat="server" CssClass="password" ChangePasswordButtonImageUrl="~/images/changeButton.gif" ToolTip="Change" ChangePasswordButtonType="Image" CancelButtonImageUrl="~/images/cancelButton.gif" CancelButtonType="Image" LabelStyle-CssClass="passLabel" TitleTextStyle-CssClass="passTit" SuccessTextStyle-CssClass="passSuc" ContinueButtonImageUrl="~/images/continueButton.gif" ContinueButtonType="Image" /></td></tr></table>
            </div>
        </div>
        <div class="bottom">
            <div>
                <div></div>
            </div>
        </div>
    </div>
</asp:Content>

