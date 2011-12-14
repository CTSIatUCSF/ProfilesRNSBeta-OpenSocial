<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucSimilarPeople.ascx.cs"
    Inherits="UserControls_ucSimilarPeople" %>
 <%--
    Copyright (c) 2008-2010 by the President and Fellows of Harvard College. All rights reserved.  
    Profiles Research Networking Software was developed under the supervision of Griffin M Weber, MD, PhD.,
    and Harvard Catalyst: The Harvard Clinical and Translational Science Center, with support from the 
    National Center for Research Resources and Harvard University.


    Code licensed under a BSD License. 
    For details, see: LICENSE.txt 
 --%> 
<script type="text/javascript" language="javascript">

    function togSimilarPeople() {

        if (document.getElementById("divSimilarPeople").style.display == "none") {
            document.getElementById("divSimilarPeople").style.display = "block";
        } else {
        document.getElementById("divSimilarPeople").style.display = "none";
        }
    }    
   
</script>

<asp:GridView ID="grdSimilarPeople" runat="server" AutoGenerateColumns="false" OnRowCreated="grdSimilarPeople_OnRowCreated"
    DataKeyNames="PersonID" GridLines="None" ShowFooter="true" Width="100%">
    <Columns>
        <asp:BoundField DataField="PersonID" ReadOnly="true" Visible="false" />
        <asp:TemplateField HeaderStyle-CssClass="menuWidgetTitleRight">
            <HeaderTemplate>
                Similar People &nbsp;<img onclick="javascript:togSimilarPeople();" style="cursor: pointer" src="<%=Page.ResolveUrl("~/Images/Info.png")%>"
                    id="imgSimilarPeople" />&nbsp;
                <div class="passive_section_description" id="divSimilarPeople" style="display: none">
                    People who share similar concepts with this person.</div>
            </HeaderTemplate>
            <ItemTemplate>
                <asp:HyperLink ID="hypLnkSimilarPeople" runat="server" Text='<%# Eval("SimilarPeople") %>' />
            </ItemTemplate>
            <ControlStyle CssClass="rightColumnLink" />
            <FooterTemplate>
                <asp:HyperLink ID="hypLnkSimiPeople" runat="server" CssClass="rightColumnLinkAll" /></FooterTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
