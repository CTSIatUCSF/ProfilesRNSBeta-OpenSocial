using System;
using System.Web;

namespace Subgurim.Controles
{
    /// <summary>
    /// Summary description for PostedFileAJAX
    /// </summary>
    [Serializable]
    public class HttpPostedFileAJAX
    {
        #region Properties

        private string separator = "??;;~¡!::~??";

        private string _ID = string.Empty;

        public string ID
        {
            get
            {
                if (string.IsNullOrEmpty(_ID))
                    _ID = Guid.NewGuid().ToString().Replace("-", "_");
                return _ID;
            }
            set { _ID = value; }
        }


        private string _FileName = string.Empty;

        public string FileName
        {
            get { return _FileName; }
            set
            {
                _FileName = value;
                _FileName = _FileName.Replace('\\', '/');
                _FileName = _FileName.Trim(new char[] {'/'});

                int i = _FileName.LastIndexOf('/');
                if (i >= 0)
                {
                    _FileName = _FileName.Substring(_FileName.LastIndexOf('/') + 1);
                }
            }
        }

        private string _FileName_SavedAs = string.Empty;

        /// <summary>
        /// El nombre de fichero con que fue guardado
        /// The name of the save file
        /// </summary>
        public string FileName_SavedAs
        {
            get { return _FileName_SavedAs; }
            set { _FileName_SavedAs = value; }
        }

        public string FileName_Path
        {
            get { return adaptPath(FileName_SavedAs); }
        }

        private string _ContentType;

        public string ContentType
        {
            get { return _ContentType; }
            set { _ContentType = value.ToLower(); }
        }

        private int _ContentLength;

        public int ContentLength
        {
            get { return _ContentLength; }
            set { _ContentLength = value; }
        }

        private string _responseMessage_Uploaded = string.Empty;

        public string responseMessage_Uploaded
        {
            get
            {
                if (string.IsNullOrEmpty(_responseMessage_Uploaded))
                {
                    if (Saved)
                        _responseMessage_Uploaded = responseMessage_Uploaded_Saved;
                    else
                        _responseMessage_Uploaded = responseMessage_Uploaded_NotSaved;
                }
                return _responseMessage_Uploaded;
            }
            set { _responseMessage_Uploaded = value; }
        }

        private string _responseMessage_Uploaded_Saved = string.Empty;

        public string responseMessage_Uploaded_Saved
        {
            get
            {
                if (string.IsNullOrEmpty(_responseMessage_Uploaded_Saved))
                    _responseMessage_Uploaded_Saved =
                        string.Format("<a href=\"{3}\" target=\"_blank\">{0}</a> (<i>{1}</i>) {2}KB",
                                      FileName, ContentType, ContentLength/1024, adaptPath(FileName_SavedAs));
                return _responseMessage_Uploaded_Saved;
            }
            set { _responseMessage_Uploaded_Saved = value; }
        }

        private string _responseMessage_Uploaded_NotSaved = string.Empty;

        public string responseMessage_Uploaded_NotSaved
        {
            get
            {
                if (string.IsNullOrEmpty(_responseMessage_Uploaded_NotSaved))
                    _responseMessage_Uploaded_NotSaved =
                        string.Format("{0} not saved", FileName);
                return _responseMessage_Uploaded_NotSaved;
            }
            set { _responseMessage_Uploaded_NotSaved = value; }
        }


        private bool _Saved = false;

        public bool Saved
        {
            get { return _Saved; }
            set { _Saved = value; }
        }

        private bool _Deleted = false;

        public bool Deleted
        {
            get { return _Deleted; }
            set { _Deleted = value; }
        }

        private fileType _type = fileType.unknow;

        /// <summary>
        /// Tipo de fichero
        /// </summary>
        public fileType Type
        {
            get
            {
                if ((_type == fileType.unknow) && (!string.IsNullOrEmpty(ContentType)))
                    _type = findType();

                return _type;
            }
            set { _type = value; }
        }

        #endregion

        #region FileType

        public enum fileType
        {
            image,
            audio,
            video,
            text,
            application,
            office,
            zip,
            others,
            unknow
        }

        private fileType findType()
        {
            if (string.IsNullOrEmpty(ContentType))
                return fileType.unknow;
            else if (ContentType.StartsWith("image/"))
                return fileType.image;
            else if (ContentType.StartsWith("audio/"))
                return fileType.audio;
            else if (ContentType.StartsWith("video/"))
                return fileType.video;
            else if (ContentType.Equals("application/vnd.ms-excel")
                     || ContentType.Equals("application/vnd.ms-powerpoint")
                     || ContentType.Equals("application/msword")
                     || ContentType.Equals("application/x-mspublisher")
                     || ContentType.Equals("application/vnd.ms-project")
                     || ContentType.Equals("application/x-msaccess"))
                return fileType.office;
            else if (ContentType.Equals("application/zip")
                     || ContentType.Equals("application/x-zip")
                     || ContentType.Equals("application/x-zip-compressed"))
                return fileType.zip;
            else if (ContentType.StartsWith("application/"))
                return fileType.application;
            else if (ContentType.StartsWith("text/"))
                return fileType.text;
            else
                return fileType.others;
        }

        #endregion

        #region Initialization

        public HttpPostedFileAJAX()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public HttpPostedFileAJAX(string FileName, string ContentType, int ContentLength)
        {
            this.FileName = FileName;
            this.ContentType = ContentType;
            this.ContentLength = ContentLength;
        }

        #endregion

        #region Methods

        internal static string adaptPath(string path)
        {
            if (!path.StartsWith("~/"))
                return path;

            path = path.Replace("~/", string.Empty);

            Uri uri = HttpContext.Current.Request.Url;

            string domain = uri.Scheme + Uri.SchemeDelimiter + uri.Authority + "/";

            if (uri.Authority.Contains("localhost:"))
                domain += uri.Segments[1];

            return domain + path;
        }

        #endregion

        #region ToString

        public override string ToString()
        {
            return FileName + separator
                   + ContentType + separator
                   + ContentLength + separator
                   + ID;
        }

        public void FromString(string backup)
        {
            string[] array = backup.Split(new string[] {separator}, StringSplitOptions.RemoveEmptyEntries);

            if (array.Length >= 4)
            {
                FileName = array[0];
                ContentType = array[1];
                ContentLength = Convert.ToInt32(array[2]);
                ID = array[3];
            }
        }

        #endregion
    }
}