<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucNeighbors.ascx.cs" Inherits="UserControls_ucNeighbors" %>
 <%--
    Copyright (c) 2008-2010 by the President and Fellows of Harvard College. All rights reserved.  
    Profiles Research Networking Software was developed under the supervision of Griffin M Weber, MD, PhD.,
    and Harvard Catalyst: The Harvard Clinical and Translational Science Center, with support from the 
    National Center for Research Resources and Harvard University.


    Code licensed under a BSD License. 
    For details, see: LICENSE.txt 
 --%> 
<script type="text/javascript" language="javascript">

  function togNeighbors(){      
      
            if (document.getElementById("divNeighbors").style.display == "none") {
                document.getElementById("divNeighbors").style.display="block";                
            } else {
                document.getElementById("divNeighbors").style.display="none";
            }        
    }
</script>

<asp:GridView ID="grdNeighbors" runat="server" AutoGenerateColumns="false" OnRowCreated="grdNeighbors_OnRowCreated"
    DataKeyNames="PersonID" GridLines="None" ShowFooter="false" Width="100%">
    <Columns>
        <asp:BoundField DataField="PersonID" ReadOnly="true" Visible="false" />
        <asp:TemplateField HeaderStyle-CssClass="menuWidgetTitleRight">
            <HeaderTemplate>
                Physical Neighbors&nbsp;<img onclick="javascript:togNeighbors();" style="cursor: pointer" src="<%=Page.ResolveUrl("~/Images/Info.png")%>"
                    id="imgNeighbors" />&nbsp;
                <div class="passive_section_description" id="divNeighbors" style="display: none">
                    People whose addresses are nearby this person.</div>
            </HeaderTemplate>
            <ItemTemplate>
                <asp:HyperLink ID="hypLnkNeighbors" runat="server" Text='<%# Eval("MyNeighbors") %>' />
            </ItemTemplate>
            <ControlStyle CssClass="rightColumnLink" />
        </asp:TemplateField>
    </Columns>
</asp:GridView>
