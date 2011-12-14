/*  
 
    Copyright (c) 2008-2010 by the President and Fellows of Harvard College. All rights reserved.  
    Profiles Research Networking Software was developed under the supervision of Griffin M Weber, MD, PhD.,
    and Harvard Catalyst: The Harvard Clinical and Translational Science Center, with support from the 
    National Center for Research Resources and Harvard University.


    Code licensed under a BSD License. 
    For details, see: LICENSE.txt 
  
*/
using System;
using System.Data;
using System.Data.Common;
using System.Xml;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;



namespace Connects.Profiles.DataAccess
{
    public class ProfileSearchDA
    {
        public XmlReaderScope ProfileSearch(string searchQuery, bool isSecure)
        {
            string spName = "usp_GetPersonList_xml";
            XmlReaderScope scope = null;

            try
            {

                SqlDatabase db = DatabaseFactory.CreateDatabase() as SqlDatabase;

                DbCommand dbCommand = db.GetStoredProcCommand(spName);

                db.AddInParameter(dbCommand, "xMessage", DbType.Xml, searchQuery);

                if (isSecure)
                    db.AddInParameter(dbCommand, "isSecure", DbType.Boolean, isSecure);

                XmlReader reader = db.ExecuteXmlReader(dbCommand);
                scope = new XmlReaderScope(dbCommand.Connection, reader);

            }
            catch (Exception ex)
            {

                XmlDataUtility.logit("---- ERROR==> " + ex.Message + " STACK:" + ex.StackTrace + " SOURCE:" + ex.Source); ;

                throw ex;
            }

            return scope;
        }

        public XmlReaderScope GetMatchingKeywords(string keyword, string queryID, bool exactKeyword)
        {
            string spName = "usp_GetMatchingKeywords_xml ";
            XmlReaderScope scope = null;
            // Defaults
            bool returnXML = true;

            try
            {

                SqlDatabase db = DatabaseFactory.CreateDatabase() as SqlDatabase;

                DbCommand dbCommand = db.GetStoredProcCommand(spName);

                db.AddInParameter(dbCommand, "Keyword", DbType.String, keyword);

                if (queryID.Length > 0)
                    db.AddInParameter(dbCommand, "QueryID", DbType.String, null);
                else
                    db.AddInParameter(dbCommand, "QueryID", DbType.String, DBNull.Value);

                db.AddInParameter(dbCommand, "ExactKeyword", DbType.Boolean, exactKeyword);
                db.AddInParameter(dbCommand, "ReturnXML", DbType.Boolean, returnXML);

                XmlReader reader = db.ExecuteXmlReader(dbCommand);
                scope = new XmlReaderScope(dbCommand.Connection, reader);

            }
            catch (Exception ex)
            {
                XmlDataUtility.logit("ERROR==> " + ex.Message + " STACK:" + ex.StackTrace + " SOURCE:" + ex.Source); ;

                throw ex;
            }

            return scope;
        }

        public IDataReader GetAutoCompleteKeywords(string prefixText, int count, bool orderByRelevance)
        {
            IDataReader reader = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                string sqlCommand = "usp_GetAutoCompleteKeywords";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

                db.AddInParameter(dbCommand, "PrefixText", DbType.String, prefixText);
                db.AddInParameter(dbCommand, "Count", DbType.Int32, count);
                db.AddInParameter(dbCommand, "OrderByRelevance", DbType.Boolean, orderByRelevance);

                reader = db.ExecuteReader(dbCommand);
            }
            catch (Exception ex)
            {
                XmlDataUtility.logit("ERROR==> " + ex.Message + " STACK:" + ex.StackTrace + " SOURCE:" + ex.Source); ;

                throw ex;                
            }

            return reader;
        }

    }
}
