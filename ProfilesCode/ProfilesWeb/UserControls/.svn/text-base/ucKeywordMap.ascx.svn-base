<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucKeywordMap.ascx.cs"
    Inherits="UserControls_ucKeywordMap" %>
     <%--
    Copyright (c) 2008-2010 by the President and Fellows of Harvard College. All rights reserved.  
    Profiles Research Networking Software was developed under the supervision of Griffin M Weber, MD, PhD.,
    and Harvard Catalyst: The Harvard Clinical and Translational Science Center, with support from the 
    National Center for Research Resources and Harvard University.


    Code licensed under a BSD License. 
    For details, see: LICENSE.txt 
 --%> 
<script type="text/javascript" src="scripts/querystring.js"></script>
<script type="text/javascript">

    var qs = new Querystring();
    var personId = qs.get("Person", "0");
    
    function set_Categories() {
        window.location = 'Categories.aspx?Person=' + personId;
    }     

</script>

<div class="pageSubTitle">
    <asp:Literal ID="ltsubHeader" runat="server" /></div>
Concepts are derived automatically from a person's publications.
<br />
<div class='tabContainer'>
    <div class='activeTab'>
        <div class='tabLeft'>
        </div>
        <div class='tabCenter'>
            Keyword Cloud</div>
        <div class='tabRight'>
        </div>
    </div>
    <div class='disabledTab'>
        <a href='javascript:set_Categories();'>
            <div class='tabLeft'>
            </div>
            <div class='tabCenter'>
                Categories</div>
            <div class='tabRight'>
            </div>
    </div>
    </a>
</div>
<div class="tabInfoText">
    In this concept "cloud", the sizes of the concepts are based not only on the number
    of corresponding publications, but also how relevant the concepts are to the overall
    topics of the publications, how long ago the publications were written, whether
    the person was the first or senior author, and how many other people have written
    about the same topic. The largest concepts are those that are most unique to this
    person.</div>
<div style="margin-left: 6px">
    <asp:DataList ID="dlMeSH" runat="server" RepeatColumns="2" RepeatLayout="Table" OnItemDataBound="dlMeSH_OnItemDataBound"
        Visible="true" Width="100%">
        <ItemTemplate>
            <asp:HyperLink ID="hypLnkMeSHlist" runat="server" Text='<%#Eval("link_text") %>' />
        </ItemTemplate>
    </asp:DataList>
</div>
