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

using System.IO;
using System.Configuration;

namespace Connects.Profiles.DataAccess
{
    public sealed class XmlDataUtility
    {
        /// <summary>
        /// populate business entity object from xml stored proc w/o input parameter
        /// </summary>
        /// <param name="ds">an instance of typed dataset derived from xml schema</param>
        /// <returns>populated typed dataset from xml storeproc</returns>
        public static DataSet FillXmlDataSet(string spName, DataSet ds)
        {
            using (XmlReaderScope scope = ExecuteXmlReader(spName, null))
            {
                ds.ReadXml(scope.Reader);
                return ds;
            }
  
        }

        /// <summary>
        /// populate business entity object from xml stored proc xml input parameter
        /// </summary>
        /// <param name="xml">input parameter in xml format</param>
        /// <param name="ds">an instance of typed dataset derived from xml schema</param>
        /// <returns>populated typed dataset from xml storeproc</returns>
        public static DataSet FillXmlDataSet(string spName, string xml, DataSet ds)
        {
            using (XmlReaderScope scope = ExecuteXmlReader(spName, xml))
            {
                ds.ReadXml(scope.Reader);
                return ds;
            }

        }

        /// <summary>
        /// Get xml in xmlreader by xml parameter
        /// </summary>
        /// <param name="spName">xml storproc name</param>
        /// <param name="id">input xml paramter of sp, null indicates parameter-less sp</param>
        /// <returns>XmlReaderScope that encapsulates xmlreader</returns>
        public static XmlReaderScope ExecuteXmlReader(string spName, string xml)
        {
            SqlDatabase db = DatabaseFactory.CreateDatabase() as SqlDatabase;

            DbCommand dbCommand = db.GetStoredProcCommand(spName);

            db.AddInParameter(dbCommand, "xMessage", DbType.Xml, xml);

            XmlReader reader = db.ExecuteXmlReader(dbCommand);
            XmlReaderScope scope = new XmlReaderScope(dbCommand.Connection, reader);

            return scope;
        }


        public static void logit(string msg)
        {
            try
            {
                if (Convert.ToBoolean(ConfigurationManager.AppSettings["LogService"]) == true)
                {
                    //Each error that occurs will trigger this event.
                    try
                    {

                        using (StreamWriter w = File.AppendText(AppDomain.CurrentDomain.BaseDirectory + "/ProfilesAPILog.txt"))
                        {
                            // write a line of text to the file
                            w.WriteLine(DateTime.Now.ToLongDateString() + ": " + DateTime.Now.ToLongTimeString() + " " + msg);

                            // close the stream
                            w.Close();

                        }
                        //EventLog.WriteEntry("ProfilesAPI",
                        //  msg,
                        //EventLogEntryType.Information);

                    }
                    catch (Exception ex) { throw ex; }

                }
            }
            catch { }

        }
    }

    /// <summary>
    /// Wraper xmlreader so that database connection and xmlreader will be closed 
    /// after XmlReaderScope is disposed
    /// </summary>
    public class XmlReaderScope:IDisposable
    {
        private DbConnection _dbConnection = null;
        private XmlReader _reader = null;

        public XmlReader Reader
        {
            get { return _reader; }
        }

        /// <summary>
        /// constructor, this class is only for internal use
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="reader"></param>
        internal XmlReaderScope(DbConnection conn, XmlReader reader)
        {
            _dbConnection = conn;
            _reader = reader;
            
        }

        private void Close()
        {

            if (_dbConnection != null && _dbConnection.State != ConnectionState.Closed)
                _dbConnection.Close();

            if (_reader != null)
                _reader.Close();
        }

        #region IDisposable Members

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
                Close();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }





        #endregion
    }


}
