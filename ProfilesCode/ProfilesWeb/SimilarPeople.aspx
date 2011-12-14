<%@ Page Language="C#" MasterPageFile="~/ProfilesPage.master" AutoEventWireup="true"
    CodeFile="SimilarPeople.aspx.cs" Inherits="SimilarPeople" EnableEventValidation="false"
    ValidateRequest="false" %>

<%@ Register Src="UserControls/ucSimilarPeopleMap.ascx" TagName="SimilarPeopleMap"
    TagPrefix="ucSimilarPeopleMap" %>
<%@ Register Src="UserControls/ucProfileRightSide.ascx" TagName="ProfileRightSide"
    TagPrefix="ucProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MiddleContentPlaceHolder" runat="Server">


    <script type="text/javascript" src="scripts/querystring.js"></script>
    <script src="Scripts/JScript.js" type="text/jscript"></script>

<script type="text/javascript">
    var qs = new Querystring();
    var personId = qs.get("Person", "0");

    function set_MapView() {
        window.location = 'gpeople.aspx?Person=' + personId;
    }    
        
    </script>


    <table width="100%" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <div class="pageTitle">
                    <asp:Literal ID="ltProfileName" runat="server" /></div>
            </td>          
            <td>
                <div style="text-align: right; padding-right: 8px;">
                    <asp:PlaceHolder ID="phEditModeLabel" runat="server" Visible="false">
                        <asp:Label ID="lblEditMode" runat="server" Text="EDIT MODE" Style="font-weight: bold;
                            color: #cc0000;"></asp:Label>
                        &nbsp;|&nbsp;<asp:HyperLink ID="hypLnkReturn" runat="server" Text="View profile"
                            CssClass="hypLinks" />
                    </asp:PlaceHolder>
                    <asp:HyperLink ID="hypLnkViewProfile" runat="server" Text="Back to Profile" CssClass="hypLinks"
                        Visible="false" />
                    <asp:HyperLink ID="hypBack" runat="server" Style="cursor: pointer;" Visible="false">Back</asp:HyperLink>
                    <asp:HiddenField ID="hdnBack" runat="server" />
                </div>
            </td>
        </tr>
        <tr>       
        </tr>
        <tr>
            <td colspan="2">
                <ucSimilarPeopleMap:SimilarPeopleMap ID="SimilarPeopleMap" runat="server" />
                <asp:HiddenField ID="hdnValue" runat="server" Visible="true" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RightContentPlaceHolder" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="rightColumnWidget">
                <ucProfile:ProfileRightSide ID="ProfileRightSide1" runat="server" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
