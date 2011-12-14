using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Subgurim.Controles
{
    [DefaultProperty("MaxFiles"),
     ToolboxData("<{0}:FileUploaderAJAX runat=server></{0}:FileUploaderAJAX>")]
    public partial class FileUploaderAJAX
    {
        #region Public properties

        private byte[] buffer = null;
        public byte[] FileBytes
        {
            get
            {
                if (IsPosting)
                {
                    if (buffer == null)
                    using (Stream InputStream = Request.Files[0].InputStream)
                    {

                        lock (thisLock2)
                        {
                            buffer = new byte[InputStream.Length];
                            InputStream.Read(buffer, 0, (int)InputStream.Length);
                            InputStream.Close();
                        }
                    }

                    return buffer;
                }
                else
                    return null;
            }
        }
        public Stream FileContent
        {
            get
            {
                if (IsPosting)
                    return Request.Files[0].InputStream;
                else
                    return null;
            }
        }




        [Bindable(true),
         Category("Subgurim"),
         Description("The Max Number of files to being uploaded"),
         DefaultValue("1")]
        public int MaxFiles
        {
            get
            {
                if (null != ViewState[clave + "MaxFiles"])
                {
                    return Convert.ToInt32(ViewState[clave + "MaxFiles"]);
                }
                return 1;
            }
            set { ViewState[clave + "MaxFiles"] = value; }
        }

        [Bindable(true),
         Category("Subgurim"),
         Description("The CssClass")]
        public new string CssClass
        {
            get
            {
                if (null != ViewState[clave + "CssClass"])
                    return ViewState[clave + "CssClass"].ToString();
                return string.Empty;
            }
            set { ViewState[clave + "CssClass"] = value; }
        }

        [Bindable(true),
         Category("Subgurim"),
         Description("The Style of the individual uploader")]
        public new string Style
        {
            get
            {
                if (null != ViewState[clave + "Style"])
                    return ViewState[clave + "Style"].ToString();
                return string.Empty;
            }
            set { ViewState[clave + "Style"] = value; }
        }

        #region Ficheros y directorios

        [Bindable(true),
         Category("Subgurim"),
         Description("Creates the directory if it doesn't exists")]
        public bool Directory_CreateIfNotExists
        {
            get
            {
                if (null != ViewState[clave + "Directory_CreateIfNotExists"])
                    return Convert.ToBoolean(ViewState[clave + "Directory_CreateIfNotExists"].ToString());
                return true;
            }
            set { ViewState[clave + "Directory_CreateIfNotExists"] = value; }
        }

        [Bindable(true),
         Category("Subgurim"),
         Description("Renames a file if it already exists")]
        public bool File_RenameIfAlreadyExists
        {
            get
            {
                if (null != ViewState[clave + "File_RenameIfAlreadyExists"])
                    return Convert.ToBoolean(ViewState[clave + "File_RenameIfAlreadyExists"].ToString());
                return true;
            }
            set { ViewState[clave + "File_RenameIfAlreadyExists"] = value; }
        }

        #endregion

        #region Texto

        [Bindable(true),
         Category("Subgurim"),
         Description("The ADD text")]
        public string text_Add
        {
            get
            {
                if (null != ViewState[clave + "text_Add"])
                    return ViewState[clave + "text_Add"].ToString();
                return "Add";
            }
            set { ViewState[clave + "text_Add"] = value; }
        }

        [Bindable(true),
         Category("Subgurim"),
         Description("The UPLOADING text")]
        public string text_Uploading
        {
            get
            {
                if (null != ViewState[clave + "text_Uploading"])
                    return ViewState[clave + "text_Uploading"].ToString();
                return "Uploading";
            }
            set { ViewState[clave + "text_Uploading"] = value; }
        }

        [Bindable(true),
         Category("Subgurim"),
         Description("The DELETE text")]
        public string text_Delete
        {
            get
            {
                if (null != ViewState[clave + "text_Delete"])
                    return ViewState[clave + "text_Delete"].ToString();
                return "[Delete]";
            }
            set { ViewState[clave + "text_Delete"] = value; }
        }

        [Bindable(true),
         Category("Subgurim"),
         Description("The HIDE text")]
        public string text_X
        {
            get
            {
                if (null != ViewState[clave + "text_X"])
                    return ViewState[clave + "text_X"].ToString();
                return "[x]";
            }
            set { ViewState[clave + "text_X"] = value; }
        }

        [Bindable(true),
         Category("Subgurim"),
         Description("Show Deleted Files On PostBack")]
        public bool showDeletedFilesOnPostBack
        {
            get
            {
                if (null != ViewState[clave + "showDeletedFilesOnPostBack"])
                    return Convert.ToBoolean(ViewState[clave + "showDeletedFilesOnPostBack"]);
                return true;
            }
            set { ViewState[clave + "showDeletedFilesOnPostBack"] = value; }
        }

        #endregion

        #region Accesibles

        private HttpPostedFileAJAX _PostedFile = null;

        [Browsable(false),
         Description("The file which is being posted")]
        public HttpPostedFileAJAX PostedFile
        {
            get
            {
                if ((_PostedFile == null) && (IsPosting))
                {
                    HttpPostedFile file = Request.Files[0];
                    _PostedFile = new HttpPostedFileAJAX(file.FileName, file.ContentType, file.ContentLength);
                }

                return _PostedFile;
            }
            private set { _PostedFile = value; }
        }

        private List<HttpPostedFileAJAX> _history = null;

        [Browsable(false),
         Description("The uploaded files history")]
        public List<HttpPostedFileAJAX> History
        {
            get
            {
                if ((null == _history) && (null != Session[ClavePrincipal]))
                    _history = (List<HttpPostedFileAJAX>) Session[ClavePrincipal];

                return _history;
            }
            private set { Session[ClavePrincipal] = value; }
        }

        [Browsable(false),
         Description("FileUploaderAJAX is requesting")]
        public bool IsRequesting
        {
            get { return !string.IsNullOrEmpty(Request.QueryString[clave1]); }
        }

        [Browsable(false),
         Description("FileUploaderAJAX is posting a file")]
        public bool IsPosting
        {
            get { return IsRequesting && clave1Value.Equals(clave1Values.sUploading) && (Request.Files.Count > 0); }
        }

        [Browsable(false),
         Description("FileUploaderAJAX is deleting a file")]
        public bool IsDeleting
        {
            get { return IsRequesting && clave1Value.Equals(clave1Values.sEliminar); }
        }

        #endregion

        #endregion

        #region Private properties

        private object thisLock = new object();
        private object thisLock2 = new object();

        private HttpRequest Request
        {
            get { return HttpContext.Current.Request; }
        }

        private HttpResponse Response
        {
            get { return HttpContext.Current.Response; }
        }

        private HttpSessionState Session
        {
            get { return HttpContext.Current.Session; }
        }

        private HttpServerUtility Server
        {
            get { return HttpContext.Current.Server; }
        }

        private string action
        {
            get { return Request.Url.AbsoluteUri; }
        }

        private string clave
        {
            get { return "Subgurim_" + ID; }
        }

        private string clave1
        {
            get { return clave + "1"; }
        }

        private clave1Values clave1Value
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString[clave1]))
                {
                    string _aux = Request.QueryString[clave1];
                    int _iAux = Convert.ToInt32(_aux);
                    return (clave1Values) _iAux;
                }
                return clave1Values.sInicio;
            }
        }

        private string clave2
        {
            get { return clave + "2"; }
        }

        private string clave2Value
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString[clave2]))
                    return Request.QueryString[clave2];
                return string.Empty;
            }
        }

        private string clave3
        {
            get { return clave + "3"; }
        }

        private string clave3Value
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString[clave3]))
                    return Request.QueryString[clave3];
                return string.Empty;
            }
        }

        private enum clave1Values
        {
            sUploading,
            sNormal,
            sInicio,
            sEliminar,
            sRecuperar
        }

        private string ClavePrincipal
        {
            get
            {
                string _clave = clave + "_myKey";

                if (!string.IsNullOrEmpty(Request.QueryString[clave]))
                    return Request.QueryString[clave];
                else if (null != ViewState[_clave])
                    return ViewState[_clave].ToString();

                return string.Empty;
            }
            set
            {
                string _clave = clave + "_myKey";
                ViewState.Add(_clave, value);
            }
        }

        #region CustomJS

        /// <summary>
        /// Diccionario de los controles que se van a añadir al Mapa
        /// </summary>
        private Dictionary<customJSevent, string> customJS
        {
            get
            {
                if (ViewState[clave + CustomJS] != null)
                {
                    return (Dictionary<customJSevent, string>) ViewState[clave + CustomJS];
                }
                return new Dictionary<customJSevent, string>();
            }
            set { ViewState[clave + CustomJS] = value; }
        }

        public enum customJSevent
        {
            preLoad,
            postLoad,
            preUpload,
            postUpload,
            preDelete,
            postDelete,
            preHide,
            postHide,
            preAdd,
            postAdd
        }

        private const string CustomJS = "CustomJS";

        #endregion

        #endregion

        public FileUploaderAJAX()
        {
        }


        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (string.IsNullOrEmpty(ClavePrincipal))
                ClavePrincipal = "Subgurim_" + Guid.NewGuid().ToString().Replace("-", "_");

            if (!DesignMode && !Page.IsPostBack)
            {
                switch (clave1Value)
                {
                    case clave1Values.sNormal:
                        normal();
                        break;
                    case clave1Values.sUploading:
                        uploaded();
                        break;
                    case clave1Values.sEliminar:
                        Remove();
                        break;
                    case clave1Values.sRecuperar:
                        recuperar();
                        break;
                }
            }
        }

        protected override void Render(HtmlTextWriter output)
        {
            string retorno = string.Empty;
            if (DesignMode)
            {
                retorno = "<input type=\"file\" />";
            }
            else if (!Page.IsPostBack)
            {
                switch (clave1Value)
                {
                        //case clave1Values.sNormal:
                        //    normal();
                        //    break;
                        //case clave1Values.sUploading:
                        //    uploaded();
                        //    break;
                        //case clave1Values.sEliminar:
                        //    Remove();
                        //    break;
                        //case clave1Values.sRecuperar:
                        //    recuperar();
                        //    break;
                    default:
                        if (History != null)
                            History.Clear();
                        retorno = initialization();

                        break;
                }
            }
            else
            {
                retorno = initialization();
            }

            output.WriteLine("<!--");
            output.WriteLine("////////******* BEGIN - COMIENZA - COMENÇA ******** ///////");
            output.WriteLine("////////******* FILE UPLOAD AJAX CONTROL FOR ASP.NET BY SUBGURIM ******** ///////");
            output.WriteLine("//////// ******* http://fileuploadajax.subgurim.net ******** ///////");
            output.WriteLine("-->");

            output.WriteLine(Utilidades.prepareJS(retorno, false));
            //output.WriteLine(retorno);

            output.WriteLine("<!--");
            output.WriteLine("////////******* http://fileuploadajax.subgurim.net ******** ///////");
            output.WriteLine("////////******* FILEUPLOAD AJAX CONTROL FOR ASP.NET BY SUBGURIM ******** ///////");
            output.WriteLine("////////******* THE END - FINAL - FINALIÇA ******** ///////");
            output.WriteLine("-->");
            output.WriteLine();
        }

        #region Configuration

        public void addCustomJS(customJSevent JSevent, string JS)
        {
            if (customJS.Count == 0)
            {
                customJS = new Dictionary<customJSevent, string>();
            }
            customJS.Add(JSevent, JS);
        }

        internal string takeCustomJS(customJSevent JSevent)
        {
            return customJS.ContainsKey(JSevent) ? customJS[JSevent] : string.Empty;
        }

        #endregion

        #region Methods

        public void Reset()
        {
            History = null;
        }

        #endregion
    }
}