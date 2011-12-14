/*  
 
    Copyright (c) 2008-2010 by the President and Fellows of Harvard College. All rights reserved.  
    Profiles Research Networking Software was developed under the supervision of Griffin M Weber, MD, PhD.,
    and Harvard Catalyst: The Harvard Clinical and Translational Science Center, with support from the 
    National Center for Research Resources and Harvard University.


    Code licensed under a BSD License. 
    For details, see: LICENSE.txt 
  
*/
using System.Collections;
using System.Data;
using Connects.Profiles.DataAccess;

namespace Connects.Profiles.BusinessLogic
{
    public class PublicationBL
    {
        #region Custom Publications

        public void DeletePublications(int personId, bool deletePMID, bool deleteMPID)
        {
            new PublicationDA().DeletePublications(personId, deletePMID, deleteMPID);
        }

        public void AddUserPublication(int userId, int pmId)
        {
            new PublicationDA().AddUserPublication(userId, pmId);
        }

        public void AddCustomPublication(Hashtable parameters)
        {
            new PublicationDA().AddCustomPublication(parameters);
        }

        public void EditCustomPublication(Hashtable parameters)
        {
            new PublicationDA().EditCustomPublication(parameters);
        }

        public IDataReader GetCustomPublication(string mpid)
        {
            return new PublicationDA().GetCustomPublication(mpid);
        }

        #endregion

        #region PubMed Publications

        public bool CheckPublicationExists(string pmid)
        {
            return new PublicationDA().CheckPublicationExists(pmid);
        }

        public void InsertPublication(string pmid, string xml)
        {
            new PublicationDA().InsertPublication(pmid, xml);
        }

        #endregion
    }
}
