<%@ Page Language="C#" MasterPageFile="~/ProfilesPage.master" AutoEventWireup="true" CodeFile="MyNetwork.aspx.cs" Inherits="MyNetwork" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MiddleContentPlaceHolder" runat="Server">
    <div class="pageTitle">My Network</div>
    <p></p>
    <div class="sectionText">To add people to your network, search for their profiles and indicate your relationship to them on the left sidebar.</div>
    <p></p>
    <%--<asp:UpdatePanel ID="upnlMyNetwork" runat="server">
        <ContentTemplate>--%>
            <table width="100%">
                <tr>
                    <td width="33%">
                        <asp:Label ID="lblCollaborator" runat="server" Text="Collaborators/Colleagues" />
                    </td>
                    <td width="33%">
                        <asp:Label ID="lblCurrentAdvisors" runat="server" Text="Advisors (Current)" />
                    </td>
                    <td width="33%">
                        <asp:Label ID="lblCurrentAdvisees" runat="server" Text="Advisees (Current)" />
                    </td>
                </tr>
                <tr>
                    <!--My Collaborators-->
                    <td rowspan="4" valign="top">
                        <asp:Panel ID="pnlContentCollaborators" runat="server">
                            <asp:GridView ID="grdCollaborators" runat="server" Width="100%" AutoGenerateColumns="False" GridLines="None" 
                            DataKeyNames="PersonId" OnRowCreated="grdCollaborators_OnRowCreated" OnRowDeleting="grdCollaborators_OnRowDeleting" 
                            ShowHeader="False" EmptyDataText="<i>None</i>" UseAccessibleHeader="False">
                                <Columns>
                                    <asp:TemplateField ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImageButton1" runat="server" style="margin-top:3px;" CausesValidation="False" 
                                            CommandName="Delete" ImageUrl="~/Images/Delete.png" Text="Delete" />
                                        </ItemTemplate>
                                        <ItemStyle Width="15px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:HyperLink ID="hypLnkCollaborators" runat="server" Text='<%#Eval("Collaborator") %>' />
                                        </ItemTemplate>
                                        <ControlStyle CssClass="institutionLink" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="PersonId" ReadOnly="true" Visible="false" />
                                </Columns>
                            </asp:GridView>
                        </asp:Panel>
                    </td>
                    <!--My Current Advisors-->
                    <td valign="top">
                        <asp:Panel ID="pnlContentCurrentAdvisors" runat="server">
                            <asp:GridView ID="grdCurrentAdvisor" runat="server" Width="100%" AutoGenerateColumns="False" GridLines="None" 
                            DataKeyNames="PersonId" EmptyDataText="<i>None</i>" OnRowCreated="grdCurrentAdvisor_OnRowCreated" OnRowDeleting="grdCurrentAdvisor_OnRowDeleting" ShowHeader="False">
                                <Columns>
                                    <asp:TemplateField ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImageButton2" runat="server" style="margin-top:3px;" CausesValidation="False"
                                             CommandName="Delete" ImageUrl="~/Images/Delete.png" Text="Delete" />
                                        </ItemTemplate>
                                        <ItemStyle Width="15px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:HyperLink ID="hypLnkCurrentAdvisor" runat="server" Text='<%#Eval("CurrentAdvisor") %>' />
                                        </ItemTemplate>
                                        <ControlStyle CssClass="institutionLink" />
                                    </asp:TemplateField>
                                    </Columns>
                            </asp:GridView>
                        </asp:Panel>
                    </td>
                    <!--My Current Advisees-->
                    <td valign="top">
                        <asp:Panel ID="pnlContentCurrentAdvisee" runat="server">
                            <asp:GridView ID="grdCurrentAdvisee" runat="server" Width="100%" AutoGenerateColumns="False" GridLines="None" DataKeyNames="PersonId"
                             EmptyDataText="<i>None</i>" OnRowCreated="grdCurrentAdvisee_OnRowCreated" OnRowDeleting="grdCurrentAdvisee_OnRowDeleting" ShowHeader="False">
                                <Columns>
                                    <asp:TemplateField ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImageButton3" runat="server" style="margin-top:3px;" CausesValidation="False" CommandName="Delete" ImageUrl="~/Images/Delete.png" Text="Delete" />
                                        </ItemTemplate>
                                        <ItemStyle Width="15px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:HyperLink ID="hypLnkCurrentAdvisee" runat="server" Text='<%#Eval("CurrentAdvisee") %>' />
                                        </ItemTemplate>
                                        <ControlStyle CssClass="institutionLink" />
                                    </asp:TemplateField>
                                <asp:BoundField DataField="PersonId" ReadOnly="true" Visible="false" />
                                    </Columns>
                            </asp:GridView>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;
                    </td>
                    <td>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblPastAdvisors" runat="server" Text="Advisors (Past)" />
                    </td>
                    <td>
                        <asp:Label ID="lblPastAdvisees" runat="server" Text="Advisees (Past)" />
                    </td>
                </tr>
                <tr>
                    <!--My Past Advisors-->
                    <td valign="top">
                        <asp:Panel ID="pnlContentPastAdvisors" runat="server">
                            <asp:GridView ID="grdPastAdvisor" runat="server" Width="100%" EmptyDataText="<i>None</i>" AutoGenerateColumns="False" 
                            GridLines="None" DataKeyNames="PersonId" OnRowCreated="grdPastAdvisor_OnRowCreated" OnRowDeleting="grdPastAdvisor_OnRowDeleting" ShowHeader="False">
                                <Columns>
                                    <asp:TemplateField ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImageButton4" runat="server" style="margin-top:3px;" CausesValidation="False" 
                                            CommandName="Delete" ImageUrl="~/Images/Delete.png" Text="Delete" />
                                        </ItemTemplate>
                                        <ItemStyle Width="15px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:HyperLink ID="hypLnkPastAdvisor" runat="server" Text='<%#Eval("PastAdvisor") %>' />
                                        </ItemTemplate>
                                        <ControlStyle CssClass="institutionLink" />
                                    </asp:TemplateField>
                                    </Columns>
                            </asp:GridView>
                        </asp:Panel>
                    </td>
                    <!--My Past Advisees-->
                    <td valign="top">
                        <asp:Panel ID="pnlContentPastAdvisee" runat="server">
                            <asp:GridView ID="grdPastAdvisee" runat="server" Width="100%" EmptyDataText="<i>None</i>" AutoGenerateColumns="False" 
                            GridLines="None" DataKeyNames="PersonId" OnRowCreated="grdPastAdvisee_OnRowCreated" OnRowDeleting="grdPastAdvisee_OnRowDeleting" ShowHeader="False">
                                <Columns>
                                    <asp:TemplateField ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImageButton5" runat="server" style="margin-top:3px;" CausesValidation="False" CommandName="Delete" ImageUrl="~/Images/Delete.png" Text="Delete" />
                                        </ItemTemplate>
                                        <ItemStyle Width="15px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:HyperLink ID="hypLnkPastAdvisee" runat="server" Text='<%#Eval("PastAdvisee") %>' />
                                        </ItemTemplate>
                                        <ControlStyle CssClass="institutionLink" />
                                    </asp:TemplateField>
                                    </Columns>
                            </asp:GridView>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
  <%--      </ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>
