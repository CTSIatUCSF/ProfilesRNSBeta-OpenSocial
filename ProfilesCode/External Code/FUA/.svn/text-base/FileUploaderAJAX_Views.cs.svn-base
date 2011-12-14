using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI.WebControls;

namespace Subgurim.Controles
{
    public partial class FileUploaderAJAX : CompositeControl
    {
        #region Views

        #region Init

        private string initialization()
        {
            javascript();
            return creaDivs();
        }

        private string creaDivs()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("<div{0}>", !string.IsNullOrEmpty(CssClass) ? " class=\"" + CssClass + "\"" : string.Empty);
            sb.AppendFormat(
                @"            
            <div id=""{0}"" style=""padding:0px; margin:0px;"">
                <!--<a href=""http://fileuploadajax.subgurim.net"">FileUpload AJAX ASP.NET</a> Powered By Subgurim-->
            </div>
            <a href=""javascript:void(0)"" onclick=""{0}add('{2}', '{3}')"" id=""{0}Add"">{1}</a>
            </div>",
                clave, text_Add, (int) clave1Values.sNormal, (int) clave1Values.sRecuperar);

            return sb.ToString();
        }

        /// <summary>
        /// Crea el javascript básico y llama a los constructores del javascript importante
        /// Fills the basic javascript and calls the contructors of the important javascript
        /// </summary>
        /// <returns></returns>
        private void javascript()
        {
            ClientScriptProxy cs2 = ClientScriptProxy.Current;

            cs2.RegisterStartupScript(Page,
                                      Page.GetType(),
                                      clave,
                                      loadJS(),
                                      true);
        }

        private string loadJS()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(loadJSCore());

            if (Page.IsPostBack)
                sb.AppendFormat("setTimeout('load_{0}()', 200);", clave);
            else
                sb.Append(initializeJS());

            return sb.ToString();
        }

        private string loadJSCore()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat(
                @" 
	                var i = 1;

                function load_{0}()
                {{
                    {3}
                    
                    if ({4})
                        {0}add('{1}', '{2}');
                    ",
                clave, (int) clave1Values.sNormal, (int) clave1Values.sRecuperar, takeCustomJS(customJSevent.preLoad),
                UnderMaxFiles() ? "true" : "false");


            if (History != null)
                foreach (HttpPostedFileAJAX pf in History)
                {
                    if (!pf.Deleted || showDeletedFilesOnPostBack)
                        sb.AppendFormat("{2}add('{0}', '{1}');", (int) clave1Values.sRecuperar, pf.FileName_SavedAs,
                                        clave);
                }

            sb.AppendFormat(
                @"
            }}

	        function {3}add(clave1Value, clave3Value)
	        {{
                if ((i>1) && (clave1Value != {7}))
                {{
                    {8}
                }}


	            i++;
	            var SFUA_id = '{4}SFUA' + i;
                var SFUA_Div_Id = '{4}SFUA_Div' + i; 


                var myDiv = document.createElement('div');	
                myDiv.id = SFUA_Div_Id;
                myDiv.style.margin = '0px';
                myDiv.style.padding = '0px';

	            var new_iframe = document.createElement('iframe');
	            new_iframe.frameBorder = '0';
	            new_iframe.height = '22px';
	            new_iframe.width = '400px';
	            new_iframe.scrolling = 'no';
	            new_iframe.id = SFUA_id;
	            new_iframe.name = SFUA_id;
	            new_iframe.marginwidth = '0px';
	            new_iframe.marginheight = '0px';
	            new_iframe.hspace = '0px';
	            new_iframe.vspace = '0px';

                                
	            var padre = document.getElementById('{3}');
                myDiv.appendChild(new_iframe);
	            padre.appendChild(myDiv);

                var _href = window.location.href;
                var _sharp = _href.lastIndexOf('#');
                if (_sharp>-1)
                {{
                    _href = _href.substring(0, _sharp);
                }}

                var infoQuery = '{0}='+clave1Value+'&{1}='+SFUA_Div_Id+'&{3}={4}&{6}='+clave3Value;
                var separador = (window.location.search=='') ? '?' : '&';
                var action = _href + separador + infoQuery;
                document.getElementById(SFUA_id).src = action;
                {3}postAdd();

                if ((i>2) && clave1Value != {7})
                {{
                    {9}
	            }}
                else if (clave1Value != {7})
                {{
                    {10}
	            }}
	        }}

            {2}
            function {3}postAdd()
            {{
                {3}assureMaxFilesLimit();
            }}



            ",
                clave1, clave2, AssureMaxFilesLimit(false, false), clave, ClavePrincipal, action, clave3,
                (int) clave1Values.sRecuperar
                , takeCustomJS(customJSevent.preAdd)
                , takeCustomJS(customJSevent.postAdd)
                , takeCustomJS(customJSevent.postLoad));

            return sb.ToString();
        }

        private string initializeJS()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat(
                @"
                function addEvent(elm, evType, fn, useCapture) 
                {{
                    if (elm.addEventListener) 
                    {{
                        elm.addEventListener(evType, fn, useCapture);
                        return true;
                    }}
                    else if (elm.attachEvent) 
                    {{
                        var r = elm.attachEvent('on' + evType, fn);
                        return r;
                    }}
                    else 
                    {{
                        elm['on' + evType] = fn;
                    }}
                }} 
                addEvent(window,'load',load_{0}, false);
                    ",
                clave);

            return sb.ToString();
        }

        #endregion

        private void normal()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(preIframe(true));

            sb.AppendFormat(
                @"
                <div id=""FUA_myIframe"">
                <input id=""file"" type=""file"" name=""image"" onchange=""{4}upload()"" />
                 <a href=""javascript:void(0)"" onclick=""{2}ocultarDiv('{0}')"">{3}</a>       
                </div>            
                <div id=""FUA_uploading"">
                <span id=""FUA_uploading_span"">{1}</span>
                </div>

            ",
                clave2Value,
                text_Uploading,
                clave,
                text_X,
                clave1);


            sb.AppendFormat(
                @"<script language=""javascript"">

            {0}show(0);


            function {0}upload()
            {{          
                {8}
  	
                {0}show(1);

                var action = '{6}';
                var separador = action.lastIndexOf('?');
                action = action.substring(0, separador + 1);
                action += '{0}={3}&{1}={2}&{4}={5}';

                document.forms[0].action = action;
	            setTimeout('document.iform.submit()',1);
            }}

            function {0}show(N)
            {{
                var alldivs = document.getElementsByTagName('div')
                for (i = 0; i < alldivs.length; i++)
                {{
                    if (i!=N)
                    {{
                        alldivs[i].style.display = 'none';
                    }}
                    else
                    {{
                        alldivs[i].style.display = '';
                    }}
                }}
            }}

            {7}           

            </script>"
                , clave1, clave2, clave2Value, (int) clave1Values.sUploading, clave, ClavePrincipal, action,
                ocultarDiv()
                , takeCustomJS(customJSevent.preUpload));

            sb.Append(postIframe(true));

            mostrarHTML(sb.ToString());
        }

        private void uploaded()
        {
            if (IsPosting)
            {
                mostrarHTML(uploadedAux(PostedFile));
            }
        }

        private void recuperar()
        {
            int historialIndex = FindHistorialIndex(clave3Value);
            HttpPostedFileAJAX _MyPostedFile = History[historialIndex];

            if (_MyPostedFile.Deleted)
                mostrarHTML(RemoveAux(historialIndex));
            else
                mostrarHTML(uploadedAux(_MyPostedFile));
        }

        private string uploadedAux(HttpPostedFileAJAX _MyPostedFile)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(preIframe(true));

            sb.Append(_MyPostedFile.responseMessage_Uploaded);

            if (_MyPostedFile.Saved)
            {
                sb.AppendFormat(" <a href=\"javascript:void(0)\" onclick=\"{1}delete('{0}')\">{2}</a>",
                                _MyPostedFile.FileName_SavedAs, clave, text_Delete);
                sb.AppendFormat(" <input type=\"hidden\" id=\"{0}\">", clave);
            }
            else
            {
                sb.AppendFormat(" <a href=\"javascript:void(0)\" onclick=\"{2}ocultarDiv('{0}')\">{3}</a>", clave2Value,
                                clave1, clave, text_X);
            }

            sb.AppendFormat(
                @"
                    <script language=""javascript"">

                    var FileName = '{12}';
                    var FileName_SavedAs = '{13}';
                    var FileName_Path = '{22}';
                    var ContentType = '{14}';
                    var ContentLength = {15};
                    var responseMessage_Uploaded = '{16}';
                    var responseMessage_Uploaded_Saved = '{17}';
                    var responseMessage_Uploaded_NotSaved = '{18}';
                    var Saved = {19};
                    var Deleted = {20};
                    var Type = '{21}';

                    {11}

                    function {6}delete()
                    {{   
                        {10}

                        var action = '{8}';
                        var separador = action.lastIndexOf('?');
                        action = action.substring(0, separador + 1);
                        action += '{0}={3}&{1}={4}&{2}={5}&{6}={7}';

                        document.forms[0].action = action;
	                    setTimeout('document.iform.submit()',1);
                    }}

                    {9}

                    </script>"
                , clave1, clave2, clave3, (int) clave1Values.sEliminar, clave2Value, _MyPostedFile.FileName_SavedAs,
                clave, ClavePrincipal, action, ocultarDiv()
                , takeCustomJS(customJSevent.preDelete), takeCustomJS(customJSevent.postUpload)
                , _MyPostedFile.FileName
                , _MyPostedFile.FileName_SavedAs
                , _MyPostedFile.ContentType
                , _MyPostedFile.ContentLength
                , HttpUtility.HtmlEncode(Utilidades.prepareJS(_MyPostedFile.responseMessage_Uploaded))
                , HttpUtility.HtmlEncode(Utilidades.prepareJS(_MyPostedFile.responseMessage_Uploaded_NotSaved))
                , HttpUtility.HtmlEncode(Utilidades.prepareJS(_MyPostedFile.responseMessage_Uploaded_Saved))
                , _MyPostedFile.Saved.ToString().ToLower()
                , _MyPostedFile.Deleted.ToString().ToLower()
                , _MyPostedFile.Type.ToString(),
                _MyPostedFile.FileName_Path);

            sb.Append(postIframe(true));

            return sb.ToString();
        }

        private void Remove()
        {
            mostrarHTML(RemoveAux(Delete(clave3Value)));
        }

        private string RemoveAux(int historyIndex)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(preIframe(true));


            sb.Append("<span style=\"text-decoration: line-through;\">");
            string mensaje = History[historyIndex].responseMessage_Uploaded;

            string pattern_entreTags = "<[^<>]*>";
            mensaje = Regex.Replace(mensaje, pattern_entreTags, string.Empty);


            sb.Append(mensaje);
            sb.Append("</span>");
            sb.AppendFormat(" <a href=\"javascript:void(0)\" onclick=\"{2}ocultarDiv('{0}')\">{3}</a>", clave2Value,
                            clave1, clave, text_X);

            sb.AppendFormat(
                @"
                    <script language=""javascript"">
                    {1}

                    {0}
                    </script>"
                , ocultarDiv(), takeCustomJS(customJSevent.postDelete));

            return sb.ToString();
        }

        #region Auxiliares

        private string ocultarDiv()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat(
                @"
            function {0}ocultarDiv(SFUA_Div_Id, forceShowAdd)
            {{
                {1}

                var par = window.parent.document;
                var myDiv = par.getElementById(SFUA_Div_Id);
                myDiv.style.display = 'none';

                var _Add = par.getElementById('{0}Add');
                _Add.style.display = '';

                {3}

                {2}
                return true;
            }}
        ",
                clave,
                takeCustomJS(customJSevent.preHide),
                takeCustomJS(customJSevent.postHide),
                AssureMaxFilesLimit(true, true)
                );

            return sb.ToString();
        }

        private string AssureMaxFilesLimit(bool addCall, bool getParent)
        {
            bool underMaxFiles = UnderMaxFiles();

            StringBuilder sb = new StringBuilder();


            sb.AppendFormat(
                @"
            function {0}assureMaxFilesLimit()
            {{
                var _Add = {3}document.getElementById('{0}Add');
                if (_Add && ({2} || ({0}ficherosGuardados() >= {1})))
                {{
                    _Add.style.display = 'none';
                }}
            }}

            function {0}ficherosGuardados()
            {{
	            var padre = {3}document.getElementById('{0}');
                var divs = padre.getElementsByTagName(""div"");

                var contador = 0;
                for ( j = 0; j < divs.length; j++ )
                {{
                    if (divs[j].style.display == '') {{ contador++ }};
                }}
                return contador;
            }}
    ",
                clave,
                MaxFiles,
                !underMaxFiles ? "true" : "false",
                getParent ? "window.parent." : string.Empty);

            if (addCall)
                sb.AppendFormat("{0}assureMaxFilesLimit();", clave);

            return sb.ToString();
        }


        private string preIframe(bool withForm)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("<html>");
            sb.Append("<head>");

            sb.Append("<style>");
            sb.Append("body{margin: 0;padding: 0;}");
            sb.Append(Style);
            sb.Append("</style>");

            sb.Append("</head>");
            sb.Append("<body>");

            if (withForm)
                sb.Append("<form name=\"iform\" method=\"post\" enctype=\"multipart/form-data\">");


            return sb.ToString();
        }

        private string postIframe(bool withForm)
        {
            StringBuilder sb = new StringBuilder();

            if (withForm)
                sb.Append("</form>");
            sb.Append("</body>");
            sb.Append("</html>");

            return sb.ToString();
        }

        private void mostrarHTML(string html)
        {
            Session["Subgurim"] = "http://fileuploadajax.subgurim.net";
            Response.Clear();
            Response.ContentType = "text/html";
            Response.Write(html);
            Response.End();
        }

        #endregion

        #endregion

        #region Methods

        private bool UnderMaxFiles()
        {
            if (History != null)
            {
                int validFiles = History.FindAll(
                    delegate(HttpPostedFileAJAX file) { return !file.Deleted; }).Count;

                return validFiles < MaxFiles;
            }

            return true;
        }

        #endregion
    }
}