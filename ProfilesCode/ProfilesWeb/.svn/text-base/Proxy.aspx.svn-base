<%@ Page Language="C#" MasterPageFile="~/ProfilesPage.master" AutoEventWireup="true"
    CodeFile="Proxy.aspx.cs" Inherits="Proxy" Title="Proxies | Profiles | Harvard Catalyst" %>
 <%--
    Copyright (c) 2008-2010 by the President and Fellows of Harvard College. All rights reserved.  
    Profiles Research Networking Software was developed under the supervision of Griffin M Weber, MD, PhD.,
    and Harvard Catalyst: The Harvard Clinical and Translational Science Center, with support from the 
    National Center for Research Resources and Harvard University.


    Code licensed under a BSD License. 
    For details, see: LICENSE.txt 
 --%> 
<asp:Content ID="Content1" ContentPlaceHolderID="MiddleContentPlaceHolder" runat="Server">
    <table width="100%">
        <tr>
            <td>
                <div style="padding: 8px 6px;">
                    <div class="pageTitle">
                        <asp:Literal ID="ltHeader" runat="server" />
                    </div>
                    <div class="sectionText">
                        Proxies are people who can edit other people&#39;s profiles on their behalf. For
                        example faculty can designate their assistants as proxies to edit their profiles.
                        If you have a profile, then one or more proxies might be assigned to you automatically
                        by your department or institution. You also have the option of designating your
                        own proxies.</div>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <div id="phProfilesICanEdit" runat="server" class="sectionText" visible="false">
                    <asp:ImageButton ID="imgBtnProfilesIEdit" runat="server" ImageUrl="~/Images/icon_roundArrow.gif"
                        OnClick="btnProfilesIEdit_OnClick" CssClass="sectionText" />
                    <asp:LinkButton ID="btnProfilesIEdit" runat="server" OnClick="btnProfilesIEdit_OnClick">View Profiles I can edit</asp:LinkButton>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <div class="sectionText">
                    <asp:PlaceHolder ID="phDesignatedProxies" runat="server" Visible="false">
                        <div class="sectionHeader">
                            Designated Proxies</div>
                        <div class="sectionText">
                            Below are proxies that you have designated to edit your profile.</div>
                        <asp:GridView ID="GridView1" runat="server" DataKeyNames="UserId" EmptyDataText="No proxies have been designated."
                            AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
                            OnRowDeleting="GridView1_RowDeleting" CssClass="proxyGrid">
                            <RowStyle CssClass="proxyGridRow" />
                            <AlternatingRowStyle CssClass="proxyGridAltRow" />
                            <HeaderStyle CssClass="proxyGridHeader" />
                            <FooterStyle CssClass="proxyGridFooter" />
                            <PagerStyle CssClass="proxyGridPager" />
                            <Columns>
                                <asp:TemplateField HeaderText="Name">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="HyperLink1" runat="server" CssClass="hypLinks" Text='<%# Bind("displayname") %>'></asp:HyperLink>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="institutionfullname" HeaderText="Institution" SortExpression="" />
                                <asp:TemplateField ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton4" runat="server" CausesValidation="False" ToolTip="Delete"
                                            CommandName="Delete" OnClientClick="Javascript:return confirm('Are you sure you want to delete this proxy?');"
                                            Text="X"></asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="10px" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <div class="sectionText">
                            <asp:ImageButton ID="imgBtnAddProxy" runat="server" ImageUrl="~/Images/icon_roundArrow.gif"
                                OnClick="btnAddProxy_OnClick" />&nbsp;
                            <asp:LinkButton ID="btnAddProxy" runat="server" OnClick="btnAddProxy_OnClick">Add a Proxy</asp:LinkButton>
                        </div>
                        <div class="sectionHeader">
                            Default Proxies</div>
                        <div class="sectionText">
                            Below are proxies who have been assigned to you automatically.</div>
                        <asp:GridView ID="GridView2" runat="server" DataKeyNames="UserId" EmptyDataText="No proxies have been assigned."
                            AutoGenerateColumns="False" OnRowDataBound="GridView2_RowDataBound" OnSelectedIndexChanged="GridView2_SelectedIndexChanged"
                            CssClass="proxyGrid">
                            <RowStyle CssClass="proxyGridRow" />
                            <AlternatingRowStyle CssClass="proxyGridAltRow" />
                            <HeaderStyle CssClass="proxyGridHeader" />
                            <FooterStyle CssClass="proxyGridFooter" />
                            <PagerStyle CssClass="proxyGridPager" />
                            <Columns>
                                <asp:TemplateField HeaderText="Name">
                                    <ItemTemplate>
                                        <%--<asp:Label ID="Label1" runat="server" Text='<%# Bind("display_name") %>'></asp:Label>--%>
                                        <asp:HyperLink ID="HyperLink2" runat="server" CssClass="hypLinks" Text='<%# Bind("displayname") %>'></asp:HyperLink>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="institutionfullname" HeaderText="Institution" SortExpression="" />
                            </Columns>
                        </asp:GridView>
                    </asp:PlaceHolder>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
