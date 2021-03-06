﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucMiniSearch.ascx.cs"
    Inherits="UserControls_ucMiniSearch" %>
     <%--
    Copyright (c) 2008-2010 by the President and Fellows of Harvard College. All rights reserved.  
    Profiles Research Networking Software was developed under the supervision of Griffin M Weber, MD, PhD.,
    and Harvard Catalyst: The Harvard Clinical and Translational Science Center, with support from the 
    National Center for Research Resources and Harvard University.


    Code licensed under a BSD License. 
    For details, see: LICENSE.txt 
 --%> 
<asp:Panel ID="pnlMiniSearch" runat="server" Visible="true" DefaultButton="BtnMiniSearch">
    <!--***** Table Mini Search *****-->
    <div style="font-weight: bold; padding-top: 4px;">
        Keyword
    </div>
    <div>
        <asp:TextBox ID="txtKword" runat="server" Width="140px" />
    </div>
    <div style="font-weight: bold;">
        Last Name
    </div>
    <div>
        <asp:TextBox ID="txtLName" runat="server" Width="140px" />
    </div>
    <div id="divInstitution" runat="server">
        <div style="font-weight: bold; padding-top: 4px;">
            Institution
        </div>
        <div>
            <asp:DropDownList ID="ddlInst" runat="server" Width="98%" />
        </div>
    </div>    
    <div id="divDepartment" runat="server">
        <div style="font-weight: bold; padding-top: 4px;">
            Department
        </div>
        <div>
            <asp:DropDownList ID="ddlDepartment" runat="server" Width="98%" />
        </div>
    </div>
     <div id="divDiv" runat="server">
        <div style="font-weight: bold; padding-top: 4px;">
            Division
        </div>
        <div>
            <asp:DropDownList ID="ddlDiv" runat="server" Width="98%" />
        </div>
    </div>
    <div style="margin-top: 12px; text-align: center;">
        <asp:Button ID="BtnMiniSearch" runat="server" Text="Search" OnClick="BtnMiniSearch_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnMiniClear" runat="server" Text="Clear" OnClick="BtnMiniClear_Click" />
    </div>
    <div style="text-align: center; margin-top: 10px;">
        <%--<asp:LinkButton ID="hyplnkOptions" runat="server" CssClass="SearchListLink" OnClientClick="window.location.reload( true );">More Search Options</asp:LinkButton>--%>
        <asp:HyperLink ID="hyplnkOptions" runat="server" Text="More Search Options" NavigateUrl="~/Search.aspx"
            CssClass="SearchListLink" />
    </div>
</asp:Panel>
