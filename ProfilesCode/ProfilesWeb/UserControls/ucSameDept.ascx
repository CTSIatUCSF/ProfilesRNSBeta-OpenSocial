<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucSameDept.ascx.cs" Inherits="UserControls_ucSameDept" %>

<script type="text/javascript" language="javascript">


    function togDepartment() {

        if (document.getElementById("divDepartmentInfo").style.display == "none") {
            document.getElementById("divDepartmentInfo").style.display = "block";
        } else {
        document.getElementById("divDepartmentInfo").style.display = "none";
        }
    }    
  
</script>

<asp:GridView ID="grdSameDepartment" runat="server" AutoGenerateColumns="false" OnRowCreated="grdSameDepartment_OnRowCreated"
    DataKeyNames="PersonID" GridLines="None" ShowFooter="true" Width="100%">
    <Columns>
        <asp:BoundField DataField="PersonID" ReadOnly="true" Visible="false" />
        <asp:TemplateField>
            <HeaderTemplate>
                Same Department&nbsp;<img  onclick="javascript:togDepartment();" style="cursor:pointer" src="<%=Page.ResolveUrl("~/Images/Info.png")%>" id="imgDepartmentInfo" />&nbsp;
                <div class="passive_section_description" id="divDepartmentInfo" style="display: none">
                    People who are also in this person's primary department.</div>
            </HeaderTemplate>
            <HeaderStyle CssClass="menuWidgetTitleRight" />
            <ItemTemplate>
                <asp:HyperLink ID="hypLnkDepartment" runat="server" Text='<%# String.Format("{0}, {1}", Eval("Name.LastName"), Eval("Name.FirstName")) %>'
                    NavigateUrl='<%# String.Format("~\\ProfileDetails.aspx?From=Pinfo&Person={0}", Eval("PersonID"))  %>' />
            </ItemTemplate>
            <ControlStyle CssClass="rightColumnLink" />
            <FooterTemplate>
                <asp:HyperLink ID="hypLnkSameDepartments" runat="Server" CssClass="rightColumnLinkAll" />
            </FooterTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
