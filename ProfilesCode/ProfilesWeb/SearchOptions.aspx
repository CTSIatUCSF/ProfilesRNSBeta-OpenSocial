<%@ Page Language="C#" MasterPageFile="~/ProfilesPage.master" AutoEventWireup="true" CodeFile="SearchOptions.aspx.cs" Inherits="SearchOptions" Title="Search Options" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MiddleContentPlaceHolder" Runat="Server">
<div id="about">
<div class="pageTitle">Search Tips</div> 

<div class="sectionHeader">Searching by Keyword in UCSF Profiles</div>
<h3>How do I execute a keyword search for a single term?</h3>
<ol>
  <li>In the text box next to Keyword, enter the topic for which you want to find a UCSF expert (e.g. diabetes) and click search.</li>
  <li>On the Search Results page, click one of the names listed to view their profile or click the "Why?" link for a list of that person’s publications that matched the keyword from your search.</li>
</ol>

<h3>How do I execute a keyword search for multiple terms?</h3>
<ol>
  <li>Multiple words are searched as "AND" (e.g. child health = child AND health = child+health).</li>
  <li>In the text box next to Keyword, enter the terms (e.g. child health) and click search.</li>
  <li>On the Search Results page, click one of the names listed to view their profile or click the "Why?" link for a list of that person’s publications that matched the keywords from your search.</li>
</ol>

<h3>How do I search by a phrase?</h3>
<ol>
  <li>To search for two or more words as a phrase (<em>adrenal gland</em>, not <em>adrenal</em> AND <em>gland</em>):
    <ul>
      <li><strong>Search for keywords that INCLUDE a phrase</strong>: Use double quotes around your phrase and your search results will return records that contain that phrase. For example: a search for "adrenal gland" will match publications with the term <em>adrenal gland</em> and also with the term <em>adrenal gland neoplasms</em>.</li>
      <li><strong>Search by EXACT phrase</strong>: Check the box next to “Search for exact phrase” and your search results will return records that only contain the exact phrase. For example, if you search for the exact phrase <em>adrenal gland</em>, UCSF Profiles will only return publications with the term <em>adrenal gland</em> rather than results containing the term <em>adrenal gland neoplasms</em>.</li>
    </ul>
  </li>
</ol>

<h3>Search Tips</h3>
<ol>
  <li>You do not need to include commas, plus signs or other operands in your search. </li>
  <li>The search tool does not recognize the Boolean search operator "OR".</li>
  <li>This search does not recognize single quotes. </li>
</ol>

<div class="sectionHeader">July 2010 UCSF Profiles Release Notes</div>
<ol>
  <li>Currently when searching for a Last or First name that contains an apostrophe (e.g., O’Sullivan), type in only the first letter of the name and execute your search. Including the apostrophe will not result in accurate search results. This issue will be fixed in the near future.</li>
</ol>

</div>
</asp:Content>