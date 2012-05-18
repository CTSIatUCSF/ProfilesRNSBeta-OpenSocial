select * from person where lastname = 'meeks';
exec usp_GetPersonList_xml '<Profiles xmlns="http://connects.profiles.schema/profiles/query" Operation="GetPersonList"><QueryDefinition><PersonID>5138614</PersonID></QueryDefinition><OutputOptions SortType="LastFirstName" StartRecord="1" MaxRecords="100"/></Profiles>';

exec usp_GetPersonList_xml '<Profiles xmlns="http://connects.profiles.schema/profiles/query" Operation="GetPersonList"><QueryDefinition><PersonID>14154</PersonID></QueryDefinition><OutputOptions SortType="LastFirstName" StartRecord="1" MaxRecords="100"/></Profiles>';


exec usp_GetPersonList_xml '<Profiles xmlns="http://connects.profiles.schema/profiles/query" Operation="GetPersonList"><QueryDefinition><InternalIdList><InternalId Name="025693078"/></InternalIdList></QueryDefinition><OutputOptions SortType="LastFirstName" StartRecord="1" MaxRecords="1"/></Profiles>';


select * from [user] where LastName = 'Lowenstein';

exec usp_GetPersonList_xml '<Profiles xmlns="http://connects.profiles.schema/profiles/query" Operation="GetPersonList"><QueryDefinition><PersonID>5138614</PersonID></QueryDefinition><OutputOptions SortType="LastFirstName" StartRecord="1" MaxRecords="100"/></Profiles>';

exec usp_cache_clear_api;

exec usp_GetPersonList_xml '<Profiles xmlns="http://connects.profiles.schema/profiles/query" Operation="GetPersonList"><QueryDefinition>
<Name><LastName MatchType="left" /><FirstName /></Name><PersonFilterList /><AffiliationList>  <Affiliation Primary="false" />
</AffiliationList><Keywords>  <KeywordString MatchType="and">Epilepsy</KeywordString></Keywords></QueryDefinition>
<OutputOptions SortType="QueryRelevance" StartRecord="1" MaxRecords="15" /></Profiles>';


exec usp_GetPersonList_xml '<Profiles xmlns="http://connects.profiles.schema/profiles/query" Operation="GetPersonList"><QueryDefinition>
<PersonID>5138614</PersonID></QueryDefinition>
<OutputOptions SortType="LastNameFirst" StartRecord="1" MaxRecords="15" /></Profiles>';

exec usp_GetPersonList_xml '<Profiles xmlns="http://connects.profiles.schema/profiles/query" Operation="GetPersonList"><QueryDefinition>
<Name><LastName MatchType="left">Meeks</LastName><FirstName /></Name><PersonFilterList /><AffiliationList>  <Affiliation Primary="false" />
</AffiliationList><Keywords>  <KeywordString MatchType="and"/></Keywords></QueryDefinition>
<OutputOptions SortType="QueryRelevance" StartRecord="1" MaxRecords="15" /></Profiles>';


select * from profiles_parameters;
select * from api_query_history;
select * from api_query_results;

exec usp_GetPersonList_xml '<Profiles xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns="http://connects.profiles.schema/profiles/query" Operation="GetPersonList">
  <QueryDefinition>
    <Name>
      <LastName MatchType="left" />
      <FirstName />
    </Name>
    <PersonFilterList />
    <AffiliationList>
      <Affiliation Primary="false" />
    </AffiliationList>
    <Keywords>
      <KeywordString MatchType="and">ear</KeywordString>
    </Keywords>
  </QueryDefinition>
  <OutputOptions SortType="QueryRelevance" StartRecord="1" MaxRecords="15" />
</Profiles>';

exec usp_GetPersonList_xml '<Profiles xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns="http://connects.profiles.schema/profiles/query" Operation="GetPersonList" Version="2">
  <QueryDefinition>
	<PersonID/>    
	<Name>
      <LastName MatchType="left">Lowenstein</LastName>
      <FirstName />
    </Name>
    <PersonFilterList />
    <AffiliationList>
      <Affiliation Primary="false" />
    </AffiliationList>
    <Keywords>
      <KeywordString MatchType="and"/>
    </Keywords>
  </QueryDefinition>
  <OutputOptions SortType="QueryRelevance" StartRecord="1" MaxRecords="15">
    <OutputFilterList Default="all">
      <OutputFilter Summary="false">KeywordList</OutputFilter>
    </OutputFilterList>
  </OutputOptions>
</Profiles>';

-- Show summary
exec usp_GetPersonList_xml '<Profiles xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" Operation="GetPersonList" Version="2" xmlns="http://connects.profiles.schema/profiles/query">
  <QueryDefinition>
    <PersonID>5077125</PersonID>
  </QueryDefinition>
  <OutputOptions SortType="QueryRelevance" StartRecord="0">
    <OutputFilterList Default="none">
      <OutputFilter Summary="true"></OutputFilter>
    </OutputFilterList>
  </OutputOptions>
</Profiles>';

exec usp_GetPersonList_xml '<Profiles xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" Operation="GetPersonList" Version="2" xmlns="http://connects.profiles.schema/profiles/query">
  <QueryDefinition>
    <PersonID>5077125</PersonID>
  </QueryDefinition>
  <OutputOptions SortType="QueryRelevance" StartRecord="0">
    <OutputFilterList Default="auto">
      <OutputFilter Summary="false">KeywordList</OutputFilter>
    </OutputFilterList>
  </OutputOptions>
</Profiles>';

exec usp_GetPersonList_xml '<Profiles xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" Operation="GetPersonList" Version="2" xmlns="http://connects.profiles.schema/profiles/query">
  <QueryDefinition>
    <PersonID>5077125</PersonID>
  </QueryDefinition>
  <OutputOptions SortType="QueryRelevance" StartRecord="0">
    <OutputFilterList Default="auto">
      <OutputFilter Summary="false">KeywordList</OutputFilter>
    </OutputFilterList>
  </OutputOptions>
</Profiles>';


exec usp_GetPersonList_xml '<Profiles xmlns="http://connects.profiles.schema/profiles/query" Operation="GetPersonList" Version="2" >
  <QueryDefinition>
    <PersonID>5138614</PersonID>
  </QueryDefinition>
  <OutputOptions SortType="QueryRelevance" StartRecord="0">
    <OutputFilterList Default="auto">
      <OutputFilter Summary="false">CoAuthorList</OutputFilter>
    </OutputFilterList>
  </OutputOptions>
</Profiles>';


-- these next two work as of 6-22-11
exec usp_GetPersonList_xml '<Profiles xmlns="http://connects.profiles.schema/profiles/query" Operation="GetPersonList" Version="2">
  <QueryDefinition>
    <PersonID>5138614</PersonID>
  </QueryDefinition>
  <OutputOptions SortType="QueryRelevance" StartRecord="0"/>
</Profiles>';

exec usp_GetPersonList_xml '<Profiles xmlns="http://connects.profiles.schema/profiles/query" Operation="GetPersonList" Version="2">
  <QueryDefinition>
	<InternalIdList>
		<InternalId Name="EcommonsUsername">025693078</InternalId>
    </InternalIdList>
  </QueryDefinition>
  <OutputOptions SortType="QueryRelevance" StartRecord="0"/>
</Profiles>';

exec usp_GetPersonList_xml '<Profiles xmlns="http://connects.profiles.schema/profiles/query" Operation="GetPersonList" Version="2">
  <QueryDefinition>
    <AffiliationList><Affiliation><DepartmentName>Radiology and Biomedical Imaging</DepartmentName></Affiliation></AffiliationList>
  </QueryDefinition>
  <OutputOptions SortType="QueryRelevance" StartRecord="0"/>
</Profiles>';

exec usp_GetPersonList_xml '<Profiles xmlns="http://connects.profiles.schema/profiles/query" Operation="GetPersonList" Version="2">
  <QueryDefinition>
    <PersonFilterList><PersonFilter>Mentor</PersonFilter></PersonFilterList>
  </QueryDefinition>
  <OutputOptions SortType="QueryRelevance" StartRecord="0"/>
</Profiles>';


exec usp_GetPersonList_xml '<Profiles xmlns="http://connects.profiles.schema/profiles/query" Operation="GetPersonList" Version="1"><QueryDefinition><PersonID>5138614</PersonID></QueryDefinition><OutputOptions SortType="LastFirstName" StartRecord="1" MaxRecords="100"/></Profiles>';

select * from person_filters;

select * from user_relationships;

"<?xml version=\"1.0\" encoding=\"utf-16\"?>\r\n<Profiles xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" Operation=\"GetPersonList\" Version=\"VersionPlaceHolder\" xmlns=\"http://connects.profiles.schema/profiles/query\">\r\n  <QueryDefinition>\r\n    <Name>\r\n      <LastName MatchType=\"left\" />\r\n      <FirstName />\r\n    </Name>\r\n    <PersonFilterList>\r\n      <PersonFilter>Mentor</PersonFilter>\r\n    </PersonFilterList>\r\n    <AffiliationList>\r\n      <Affiliation Primary=\"false\" />\r\n    </AffiliationList>\r\n    <Keywords>\r\n      <KeywordString MatchType=\"and\" />\r\n    </Keywords>\r\n  </QueryDefinition>\r\n  <OutputOptions SortType=\"QueryRelevance\" StartRecord=\"1\" MaxRecords=\"15\" />\r\n</Profiles>"

select * from api_query_history;
select * from api_query_results;