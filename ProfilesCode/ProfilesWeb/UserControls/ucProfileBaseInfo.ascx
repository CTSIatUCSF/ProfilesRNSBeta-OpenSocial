<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucProfileBaseInfo.ascx.cs"
    Inherits="UserControls_ucProfileBaseInfo" %>
<asp:DataList ID="dlistProfileInfo" runat="server" border="0" CellSpacing="0" CellPadding="0" OnItemDataBound="dlistProfileInfo_ItemDataBound" ShowHeader="false" ShowFooter="false" RepeatLayout="Flow">
    <ItemTemplate>
        <table>
            <tr id="Tr1" runat="server" visible='<%# GetJobTitle(Eval("AffiliationList"),0) == null ? false : true %>'>
                <td class="basicInfoLabelCol">
                    <asp:Label ID="lblAcademicTitleText" runat="server" Text="Title" CssClass="basicInfoLabel"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblAcademicTitle" runat="server" class="title role" Text='<%# GetJobTitle(Eval("AffiliationList"),0) %>'></asp:Label>
                </td>
            </tr>
          <tr id="Tr4" runat="server" visible='<%# GetInstitutionText(Eval("AffiliationList"),0) == null ? false : true %>'>
                <td class="basicInfoLabelCol">
                    <asp:Label ID="lblInstitutionText" runat="server" Text="School" CssClass="basicInfoLabel"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblInstitution" runat="server" class="org" Text='<%# GetInstitutionText(Eval("AffiliationList"),0) %>'></asp:Label>
                </td>
            </tr>
            <tr id="Tr3" runat="server" visible='<%# GetDepartmentText(Eval("AffiliationList"),0) == null ? false : true %>'>
                <td class="basicInfoLabelCol">
                    <asp:Label ID="lblDepartmentText" runat="server" Text="Department" CssClass="basicInfoLabel"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblDepartment" runat="server" Text='<%# GetDepartmentText(Eval("AffiliationList"),0) %>'></asp:Label>
                </td>
            </tr>
            <tr id="Tr8" runat="server" Visible='<%# GetDivisionText(Eval("AffiliationList"),0) == null ? false : true %>'>
                <td class="basicInfoLabelCol">
                    <asp:Label ID="lblDivisionText" runat="server" Text="Division" CssClass="basicInfoLabel"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblDivision" runat="server" Text='<%# GetDivisionText(Eval("AffiliationList"),0) %>'></asp:Label>
                </td>
            </tr>

            <tr>
                <td class="basicInfoLabelCol">
                    <asp:Label ID="lblAddressText" runat="server" Text="Address" CssClass="basicInfoLabel"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblAddress1" runat="server"
                        Visible='<%# Eval("Address.Address1")==null ? false : true %>'
                        Text='<%# DataBinder.Eval(Container.DataItem, "Address.Address1") + "<br>"%>'
                        CssClass="basicInfoAddress"></asp:Label>

                    <asp:Label ID="lblAddress2" runat="server"
                        Visible='<%# Eval("Address.Address2")==null ? false : true %>'
                        Text='<%# DataBinder.Eval(Container.DataItem, "Address.Address2") + "<br>"%>'
                        CssClass="basicInfoAddress"></asp:Label>

                    <asp:Label ID="lblAddress3" runat="server"
                        Visible='<%# Eval("Address.Address3")==null ? false : true %>'
                        Text='<%# DataBinder.Eval(Container.DataItem, "Address.Address3") + "<br>"%>'
                        CssClass="basicInfoAddress"></asp:Label>

                    <asp:Label ID="lblAddress4" runat="server" 
                        Visible='<%# Eval("Address.Address4")==null ? false : true %>'
                        Text='<%# DataBinder.Eval(Container.DataItem, "Address.Address4") + "<br>"%>'
                        CssClass="basicInfoAddress"></asp:Label>
                </td>
            </tr>
      
            <tr id="Tr5" runat="server" visible='<%# DataBinder.Eval(Container.DataItem, "Address.Telephone") == null ? false : true %>'>
                <td class="basicInfoLabelCol">
                    <asp:Label ID="lblTelePhoneText" runat="server" Text="Telephone" CssClass="basicInfoLabel"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblTelePhone" runat="server" class="tel" Text='<%# DataBinder.Eval(Container.DataItem, "Address.Telephone")%>'></asp:Label>
                </td>
            </tr>
            <tr id="Tr6" runat="server" visible='<%# DataBinder.Eval(Container.DataItem, "Address.Fax") == null ? false : true %>'>
                <td class="basicInfoLabelCol">
                    <asp:Label ID="lblFaxText" runat="server" Text="Fax" CssClass="basicInfoLabel"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblFax" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Address.Fax")%>'></asp:Label>
                </td>
            </tr>
            <tr id="Tr7" runat="server" visible='<%# DataBinder.Eval(Container.DataItem, "EmailImageUrl") == null ? false : true %>'>
                <td class="basicInfoLabelCol">
                    <asp:Label ID="lblEmailText" runat="server" Text="Email" CssClass="basicInfoLabel"></asp:Label>
                </td>
                <td>
                    <asp:Image ID="ImageEmail" runat="server" />
                    <asp:Label ID="lblReadEmail" runat="server" />
                </td>
            </tr>            
        </table>
    </ItemTemplate>
</asp:DataList>
<asp:Repeater ID="rptrTitles" runat="server">
    <HeaderTemplate>
        <div class="sectionHeader""><asp:Label ID="lblOtherPos" runat="server">Other Positions</asp:Label></div>
    </HeaderTemplate>
    <ItemTemplate>  
        <table cellpadding="0" cellspacing="0">
            <tr id="tr10" runat="server" visible='<%# Convert.ToString(DataBinder.Eval(Container.DataItem, "Title")).Length > 0 %>'>
                <td class="basicInfoLabelCol">
                    <asp:Label ID="lblTitleHdr" runat="server" Text="Title" CssClass="basicInfoLabel"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblTitle" runat="server" Text='<%#Eval("Title") %>' />
                </td>
            </tr>
            <tr id="tr11" runat="server" visible='<%# Convert.ToString(DataBinder.Eval(Container.DataItem, "InstitutionFullName")).Length > 0 %>'>
                <td class="basicInfoLabelCol">
                    <asp:Label ID="lblInstitutionHdr" runat="server" Text="Institution" CssClass="basicInfoLabel"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblInstitutionTitle" runat="server" Text='<%#Eval("InstitutionFullName") %>' />
                </td>
            </tr>
            <tr id="tr12" runat="server" visible='<%# Convert.ToString(DataBinder.Eval(Container.DataItem, "DepartmentFullName")).Length > 0 %>'>
                <td class="basicInfoLabelCol">
                    <asp:Label ID="lblDepartmentHdr" runat="server" Text="Department" CssClass="basicInfoLabel"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblDepartment" runat="server" Text='<%#Eval("DepartmentFullName") %>' />
                </td>
            </tr>
            <tr id="tr13" runat="server" visible='<%# Convert.ToString(DataBinder.Eval(Container.DataItem, "DivisionFullName")).Length > 0 %>'>
                <td class="basicInfoLabelCol">
                    <asp:Label ID="lblDivisionHdr" runat="server" Text="Division" CssClass="basicInfoLabel"></asp:Label></div>
                </td>
                <td>
                    <asp:Label ID="lblDivision" runat="server" Text='<%#Eval("DivisionFullName") %>' />
                </td>
            </tr>
        </table>
    </ItemTemplate>
</asp:Repeater>
