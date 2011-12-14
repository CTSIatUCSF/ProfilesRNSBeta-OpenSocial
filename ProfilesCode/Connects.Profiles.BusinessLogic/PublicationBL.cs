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
