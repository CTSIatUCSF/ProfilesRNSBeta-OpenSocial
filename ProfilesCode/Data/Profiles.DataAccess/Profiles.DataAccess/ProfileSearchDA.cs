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
                bool rethrow = ExceptionPolicy.HandleException(ex, "Log Only Policy");
                if (rethrow)
                    throw;
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
                bool rethrow = ExceptionPolicy.HandleException(ex, "Log Only Policy");
                if (rethrow)
                    throw;
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
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return reader;
        }

    }
}
