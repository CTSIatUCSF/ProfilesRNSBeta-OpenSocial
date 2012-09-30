

select * from nih.PIID_ProfilesID; --1355

select count(*) from [grant] where xml2 is not null;

--with http://www.w3.org/2001/XMLSchema-instance
WITH XMLNAMESPACES ('http://www.w3.org/2001/XMLSchema-instance' as pd)
select top 10 g.[xml].value('(//pd:APPLICATION_ID)[1]', 'varchar'), * from [grant] g;

select top 10 g.[xml].value('(//TOTAL_COST)[1]', 'int'), * from [grant] g;

update g set g.TOTAL_COST = g.[xml].value('(//TOTAL_COST)[1]', 'int') from [grant] g;

select top 10 * from [grant]
data;

update g set g.xml2 = cast(g.[xml] as xml) from [grant] g;

select p.DisplayName, p.internalusername, g.TOTALCOST, g.FY, fullprojectnum, projecttitle, icname, orgname, orgdept
from nih.PIID_ProfilesID a join agPrincipalInvestigator b on 
cast(a.PIID as int) = b.PrincipalInvestigatorID join aggrantprincipal gp on gp.principalinvestigatorpk 
= b.principalinvestigatorpk join [aggrant] g on gp.grantpk = g.grantpk
join person p on p.personid = a.profilesId where p.internalusername in ( --; -- 1355
'020256038',
'021473301',
'022124192',
'023637812',
'023734445',
'023915853',
'025179789',
'025692542',
'026749622',
'027940386',
'028643609',
'028557569',
'020821534',
'021961818',
'022612162',
'022936298',
'023653496',
'025455965',
'026173831',
'028390631',
'020298451',
'020713194',
'022702344',
'023038797',
'023717580',
'023972557',
'025129578',
'025364803',
'026687392',
'027013457',
'027157528',
'028077899',
'028393320',
'020003539',
'024847154',
'027474535',
'029919057',
'020928503',
'022231187',
'022435127',
'025112236',
'025979121',
'026353656',
'026477299',
'026643270',
'028097244',
'028826113',
'022310221',
'026546846',
'020126348',
'022754816',
'024422990',
'028442564',
'028377315',
'028512531',
'029744133',
'029745338',
'029833894',
'029677374',
'029914264',
'021601091',
'022268403',
'023240658',
'024277493',
'024353831',
'024466518',
'024798126',
'025164385',
'025089228',
'025204967',
'025588377',
'025544016',
'026147413',
'027979210',
'028823250')
order by p.DisplayName;

select * from 

<row>    <APPLICATION_ID>7391545</APPLICATION_ID>    <ACTIVITY>R01</ACTIVITY>    <ADMINISTERING_IC>HL</ADMINISTERING_IC>    <APPLICATION_TYPE>5</APPLICATION_TYPE>    <ARRA_FUNDED p2:nil="true" xmlns:p2="http://www.w3.org/2001/XMLSchema-instance" />    <BUDGET_START>04/01/2008</BUDGET_START>    <BUDGET_END>03/31/2009</BUDGET_END>    <FOA_NUMBER p2:nil="true" xmlns:p2="http://www.w3.org/2001/XMLSchema-instance" />    <FULL_PROJECT_NUM>5R01HL075033-04</FULL_PROJECT_NUM>    <FUNDING_ICs>NHLBI:359123\</FUNDING_ICs>    <FY>2008</FY>    <NIH_SPENDING_CATS>  <CATEGORY>Genetics</CATEGORY>  </NIH_SPENDING_CATS>    <ORG_CITY>SAN FRANCISCO</ORG_CITY>    <ORG_COUNTRY>UNITED STATES</ORG_COUNTRY>    <ORG_DISTRICT>12</ORG_DISTRICT>    <ORG_DUNS>073133571</ORG_DUNS>    <ORG_DEPT>SURGERY</ORG_DEPT>    <ORG_FIPS>US</ORG_FIPS>    <ORG_STATE>CA</ORG_STATE>    <ORG_ZIPCODE>941430962</ORG_ZIPCODE>    <IC_NAME>NATIONAL HEART, LUNG, AND BLOOD INSTITUTE</IC_NAME>    <ORG_NAME>UNIVERSITY OF CALIFORNIA SAN FRANCISCO</ORG_NAME>    <PIS>  <PI>  <PI_NAME>WANG, RONG </PI_NAME>  <PI_ID>7597309</PI_ID>  </PI>  </PIS>    <PROJECT_TERMS>  <TERM>2-Naphthacenecarboxamide, 4-(dimethylamino)-1,4,4a,5,5a,6,11,12a-octahydro-3,6,10,12,12a-pentahydroxy-6-methyl-1,11-dioxo-, (4S-(4alpha,4aalpha,5aalpha,6beta,12aalpha))-</TERM>  <TERM>21+ years old</TERM>  <TERM>Achromycin</TERM>  <TERM>Adult</TERM>  <TERM>Angioblast</TERM>  <TERM>Aorta</TERM>  <TERM>Arteries</TERM>  <TERM>Arteriogram</TERM>  <TERM>Biologic Marker</TERM>  <TERM>Biological</TERM>  <TERM>Biological Markers</TERM>  <TERM>Blood Circulation</TERM>  <TERM>Blood Vessels</TERM>  <TERM>Blood flow</TERM>  <TERM>Bloodstream</TERM>  <TERM>Brachydanio rerio</TERM>  <TERM>Candidate Disease Gene</TERM>  <TERM>Candidate Gene</TERM>  <TERM>Cardinal vein</TERM>  <TERM>Cell Adhesion</TERM>  <TERM>Cell Communication</TERM>  <TERM>Cell Communication and Signaling</TERM>  <TERM>Cell Growth in Number</TERM>  <TERM>Cell Interaction</TERM>  <TERM>Cell Isolation</TERM>  <TERM>Cell Multiplication</TERM>  <TERM>Cell Proliferation</TERM>  <TERM>Cell Segregation</TERM>  <TERM>Cell Separation</TERM>  <TERM>Cell Separation Technology</TERM>  <TERM>Cell Signaling</TERM>  <TERM>Cell Survival</TERM>  <TERM>Cell Viability</TERM>  <TERM>Cell-to-Cell Interaction</TERM>  <TERM>Cells</TERM>  <TERM>Cellular Adhesion</TERM>  <TERM>Cellular Proliferation</TERM>  <TERM>Cessation of life</TERM>  <TERM>Circulation</TERM>  <TERM>Complex</TERM>  <TERM>Condition</TERM>  <TERM>DISSEC</TERM>  <TERM>Danio rerio</TERM>  <TERM>Death</TERM>  <TERM>Defect</TERM>  <TERM>Development</TERM>  <TERM>Dissection</TERM>  <TERM>Dorsal</TERM>  <TERM>Down-Regulation</TERM>  <TERM>Down-Regulation (Physiology)</TERM>  <TERM>Downregulation</TERM>  <TERM>Drug Delivery</TERM>  <TERM>Drug Delivery Systems</TERM>  <TERM>Drug Targeting</TERM>  <TERM>Drug Targetings</TERM>  <TERM>EPHB4 Protein</TERM>  <TERM>Embryo</TERM>  <TERM>Embryonic</TERM>  <TERM>Endothelial Cells</TERM>  <TERM>Endothelium</TERM>  <TERM>EphB4 Receptor</TERM>  <TERM>Equilibrium</TERM>  <TERM>Event</TERM>  <TERM>Feedback</TERM>  <TERM>Future</TERM>  <TERM>Gene Expression</TERM>  <TERM>Genes</TERM>  <TERM>Genetic</TERM>  <TERM>Goals</TERM>  <TERM>Hepatoma Transmembrane Kinase</TERM>  <TERM>Human, Adult</TERM>  <TERM>Image</TERM>  <TERM>Intracellular Communication and Signaling</TERM>  <TERM>Investigation</TERM>  <TERM>Investigators</TERM>  <TERM>Knockout Mice</TERM>  <TERM>Lead</TERM>  <TERM>Leiomyocyte</TERM>  <TERM>Lesion</TERM>  <TERM>Link</TERM>  <TERM>Liver</TERM>  <TERM>Lung</TERM>  <TERM>Maintenance</TERM>  <TERM>Maintenances</TERM>  <TERM>Mammals, Mice</TERM>  <TERM>Methods</TERM>  <TERM>Methods and Techniques</TERM>  <TERM>Methods, Other</TERM>  <TERM>Mice</TERM>  <TERM>Mice, Knock-out</TERM>  <TERM>Mice, Knockout</TERM>  <TERM>Mice, Transgenic</TERM>  <TERM>Modeling</TERM>  <TERM>Molecular</TERM>  <TERM>Molecular Marker</TERM>  <TERM>Molecular Probes</TERM>  <TERM>Morphogenesis</TERM>  <TERM>Murine</TERM>  <TERM>Mus</TERM>  <TERM>Myocytes, Smooth Muscle</TERM>  <TERM>Null Mouse</TERM>  <TERM>Pathogenesis</TERM>  <TERM>Pathway interactions</TERM>  <TERM>Pattern</TERM>  <TERM>Pb element</TERM>  <TERM>Phenotype</TERM>  <TERM>Pressure</TERM>  <TERM>Pressure- physical agent</TERM>  <TERM>Process</TERM>  <TERM>Programs (PT)</TERM>  <TERM>Programs [Publication Type]</TERM>  <TERM>Receptor, EphB4</TERM>  <TERM>Regulation</TERM>  <TERM>Research Personnel</TERM>  <TERM>Researchers</TERM>  <TERM>Respiratory System, Lung</TERM>  <TERM>Role</TERM>  <TERM>Seminal</TERM>  <TERM>Signal Transduction</TERM>  <TERM>Signal Transduction Systems</TERM>  <TERM>Signaling</TERM>  <TERM>Signature Molecule</TERM>  <TERM>Smooth Muscle Cells</TERM>  <TERM>Smooth Muscle Myocytes</TERM>  <TERM>Smooth Muscle Tissue Cell</TERM>  <TERM>Specific qualifier value</TERM>  <TERM>Specified</TERM>  <TERM>Staging</TERM>  <TERM>TCN</TERM>  <TERM>Techniques</TERM>  <TERM>Testing</TERM>  <TERM>Tet</TERM>  <TERM>Tetanus Helper Peptide</TERM>  <TERM>Tetracycline</TERM>  <TERM>Tetracycline Antibiotic</TERM>  <TERM>Tetracyclines</TERM>  <TERM>Therapeutic Intervention</TERM>  <TERM>Time</TERM>  <TERM>Transgenes</TERM>  <TERM>Transgenic Mice</TERM>  <TERM>Up-Regulation</TERM>  <TERM>Up-Regulation (Physiology)</TERM>  <TERM>Upregulation</TERM>  <TERM>Vascular Diseases</TERM>  <TERM>Vascular Disorder</TERM>  <TERM>Veins</TERM>  <TERM>Venous</TERM>  <TERM>Work</TERM>  <TERM>Yolk Sac</TERM>  <TERM>Zebra Danio</TERM>  <TERM>Zebra Fish</TERM>  <TERM>Zebrafish</TERM>  <TERM>adult human (21+)</TERM>  <TERM>arterial imaging</TERM>  <TERM>balance</TERM>  <TERM>balance function</TERM>  <TERM>biological signal transduction</TERM>  <TERM>biomarker</TERM>  <TERM>blood vessel disorder</TERM>  <TERM>body system, hepatic</TERM>  <TERM>cell sorting</TERM>  <TERM>cell type</TERM>  <TERM>embryo culture</TERM>  <TERM>experiment</TERM>  <TERM>experimental research</TERM>  <TERM>experimental study</TERM>  <TERM>gene function</TERM>  <TERM>heavy metal Pb</TERM>  <TERM>heavy metal lead</TERM>  <TERM>imaging</TERM>  <TERM>interest</TERM>  <TERM>intervention therapy</TERM>  <TERM>loss of function</TERM>  <TERM>member</TERM>  <TERM>mouse model</TERM>  <TERM>mutant</TERM>  <TERM>notch</TERM>  <TERM>notch protein</TERM>  <TERM>notch receptors</TERM>  <TERM>novel</TERM>  <TERM>organ system, hepatic</TERM>  <TERM>pathway</TERM>  <TERM>postnatal</TERM>  <TERM>prenatal</TERM>  <TERM>pressure</TERM>  <TERM>programs</TERM>  <TERM>pulmonary</TERM>  <TERM>research study</TERM>  <TERM>social role</TERM>  <TERM>transgene expression</TERM>  <TERM>unborn</TERM>  <TERM>vascular</TERM>  <TERM>vitelline sac</TERM>  </PROJECT_TERMS>    <PROJECT_TITLE>Notch Signaling in Mouse Arterial-Venous Specification</PROJECT_TITLE>    <PROJECT_START>04/01/2005</PROJECT_START>    <PROJECT_END>03/31/2010</PROJECT_END>    <PHR p2:nil="true" xmlns:p2="http://www.w3.org/2001/XMLSchema-instance" />    <SERIAL_NUMBER>75033</SERIAL_NUMBER>    <STUDY_SECTION>ZRG1</STUDY_SECTION>    <STUDY_SECTION_NAME>Special Emphasis Panel</STUDY_SECTION_NAME>    <SUPPORT_YEAR>4</SUPPORT_YEAR>    <SUFFIX p2:nil="true" xmlns:p2="http://www.w3.org/2001/XMLSchema-instance" />    <SUBPROJECT_ID p2:nil="true" xmlns:p2="http://www.w3.org/2001/XMLSchema-instance" />    <TOTAL_COST>359123</TOTAL_COST>    <TOTAL_COST_SUB_PROJECT p2:nil="true" xmlns:p2="http://www.w3.org/2001/XMLSchema-instance" />    <CORE_PROJECT_NUM>R01HL075033</CORE_PROJECT_NUM>    <CFDA_CODE>837</CFDA_CODE>    <PROGRAM_OFFICER_NAME>SRINIVAS, POTHUR R</PROGRAM_OFFICER_NAME>    <ED_INST_TYPE>SCHOOLS OF MEDICINE</ED_INST_TYPE>    <AWARD_NOTICE_DATE>2008-03-14</AWARD_NOTICE_DATE>  </row>

select *  from shindig_appdata where appid = 108 and userId = 5258671
keyname = 'nih_n';

--delete from  shindig_appdata where appid = 108;

exec [sp_Create_shinding_appdata];

--insert into shindig_appdata
--select distinct userid, 108, 'VISIBLE', 'Y', getdate(), getdate() from  shindig_appdata where appid = 108;

select top 10 * from [grant];

-- new grant stuff;

select '''' + INDIVIDUAL_ID + ''',' from vw_UCSFPRO1 where E_mail_address is not null and e_mail_address in (
'carolyn.calfee@ucsf.edu',
'ahuang@medicine.ucsf.edu',
'leek@pharmacy.ucsf.edu',
'lesliegillum@hotmail.com',
'ekezirian@ohns.ucsf.edu',
'agreen@ucsf.edu',
'mary.beattie@ucsfmedctr.org',
'campos@surgery.wisc.edu',
'monica.gandhi@ucsf.edu',
'kellerr@peds.ucsf.edu',
'kathleen.liu@ucsf.edu',
'whitedb@upmc.edu',
'zhtseng@medicine.ucsf.edu',
'yangk@pharmacy.ucsf.edu',
'jyu-lin.chen@nursing.ucsf.edu',
'abryant@partners.org',
'marcusg@medicine.ucsf.edu',
'bradley.aouizerat@nursing.ucsf.edu',
'tangy@stanfordalumni.org',
'Fernando.Velayos@ucsf.edu',
'Max.Wintermark@gmail.com',
'pnahid@ucsf.edu',
'judith.tsui@bmc.org',
'FlahermanV@peds.ucsf.edu',
'nisha.acharya@ucsf.edu',
'Beth.Cohen@ucsf.edu',
'duboiss@peds.ucsf.edu',
'jennifer.gibbs@datajockey.org',
'Jade.Hiramoto@ucsfmedctr.org',
'sei.lee@ucsf.edu',
'ejorgenson@gallo.ucsf.edu',
'carmenalicia.peralta@ucsf.edu',
'cdehlendorf@fcm.ucsf.edu',
'Antonio.Westphalen@ucsf.edu',
'hseligman@medsfgh.ucsf.edu',
'Hannah.Glass@ucsf.edu',
'LeeHC@peds.ucsf.edu',
'sharon.chung@ucsf.edu',
'arrons@derm.ucsf.edu',
'genge@php.ucsf.edu',
'Renee.Hsia@emergency.ucsf.edu',
'Audrey.Lyndon@nursing.ucsf.edu',
'Wendy.Anderson@ucsf.edu',
'heather.leutwyler@nursing.ucsf.edu',
'aksmith@ucsf.edu',
'Newmann@obgyn.ucsf.edu',
'adam.l.hersh@gmail.com',
'john.metcalfe@ucsf.edu',
'bardachn@peds.ucsf.edu',
'megan.huchko@ucsf.edu',
'maria.orellana@budubai.ae',
'patela@peds.ucsf.edu',
'mary.margaretten@ucsf.edu',
'linos@stanford.edu',
'christina.mangurian@ucsf.edu',
'marlene.grenon@ucsfmedctr.org',
'walduraj@nccc.ucsf.edu',
'lisa.thompson@nursing.ucsf.edu',
'joshua.galanter@ucsf.edu',
'somsoukma@medsfgh.ucsf.edu',
'delphine.tuot@ucsf.edu',
'Lyndsay.A.Avalos@kp.org',
'zotaar@obgyn.ucsf.edu',
'choudhrys@urology.ucsf.edu',
'laura.fejerman@ucsf.edu',
'bruce.gaynor@ucsf.edu',
'omachi@ucsf.edu',
'anne.schafer@ucsf.edu',
'julia.steinberg@ucsf.edu',
'adibij@obgyn.ucsf.edu',
'susan.meffert@ucsf.edu',
'grubbsv@medsfgh.ucsf.edu',
'emowry1@jhmi.edu',
'nisha.bansal@ucsf.edu',
'brie.williams@ucsf.edu',
'dorie.apollonio@ucsf.edu',
'achat@medsfgh.ucsf.edu',
'chengy@obgyn.ucsf.edu',
'akim@ucsf.edu',
'prasanthi.ramanujam@emergency.ucsf.edu',
'wendy.katzman@ucsfmedctr.org',
'legoldman@medsfgh.ucsf.edu',
'wojcicki@gmail.com',
'madhu.rao@ucsf.edu',
'acattamanchi@medsfgh.ucsf.edu',
'jeremy.keenan@ucsf.edu',
'copphl@urology.ucsf.edu',
'mgarcia@urology.ucsf.edu',
'ng719@yahoo.com',
'jmturan@gmail.com',
'SapruA@peds.ucsf.edu',
'usarkar@medsfgh.ucsf.edu',
'mktamura@stanford.edu',
'kimhel@anesthesia.ucsf.edu',
'lucian.davis@ucsf.edu',
'scott.biggins@ucdenver.edu')
order by e_mail_address;


--- pubs
select p.DisplayName, p.internalusername, pm.* from person p join publications_include pb on p.personid =
pb.personid join pm_pubs_general pm on pm.PMID = pb.PMID where pb.PMID is not null and p.internalusername in (
'020256038',
'021473301',
'022124192',
'023637812',
'023734445',
'023915853',
'025179789',
'025692542',
'026749622',
'027940386',
'028643609',
'028557569',
'020821534',
'021961818',
'022612162',
'022936298',
'023653496',
'025455965',
'026173831',
'028390631',
'020298451',
'020713194',
'022702344',
'023038797',
'023717580',
'023972557',
'025129578',
'025364803',
'026687392',
'027013457',
'027157528',
'028077899',
'028393320',
'020003539',
'024847154',
'027474535',
'029919057',
'020928503',
'022231187',
'022435127',
'025112236',
'025979121',
'026353656',
'026477299',
'026643270',
'028097244',
'028826113',
'022310221',
'026546846',
'020126348',
'022754816',
'024422990',
'028442564',
'028377315',
'028512531',
'029744133',
'029745338',
'029833894',
'029677374',
'029914264',
'021601091',
'022268403',
'023240658',
'024277493',
'024353831',
'024466518',
'024798126',
'025164385',
'025089228',
'025204967',
'025588377',
'025544016',
'026147413',
'027979210',
'028823250');

select name from syscolumns where id=object_id('pm_pubs_general');