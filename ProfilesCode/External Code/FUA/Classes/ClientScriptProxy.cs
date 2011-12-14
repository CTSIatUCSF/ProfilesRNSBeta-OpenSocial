using System;
using System.Reflection;
using System.Web;
using System.Web.UI;

namespace Subgurim.Controles
{
    /// <summary>
    /// This is a proxy object for the Page.ClientScript and MS Ajax ScriptManager
    /// object that can operate when MS Ajax is not present. Because MS Ajax
    /// may not be available accessing the methods directly is not possible
    /// and we are required to indirectly reference client script methods through
    /// this class.
    ///
    /// This class should be invoked at the Control's start up and be used
    /// to replace all calls Page.ClientScript. Scriptmanager calls are made
    /// through Reflection
    /// 
    /// http://www.west-wind.com/WebLog/posts/9601.aspx
    /// </summary>
    public class ClientScriptProxy
    {
        private static Type scriptManagerType = null;

        // *** Register proxied methods of ScriptManager
        private static MethodInfo RegisterClientScriptBlockMethod;
        private static MethodInfo RegisterStartupScriptMethod;
        private static MethodInfo RegisterClientScriptIncludeMethod;
        private static MethodInfo RegisterClientScriptResourceMethod;
        private static MethodInfo RegisterHiddenFieldMethod;
        //private static MethodInfo RegisterPostBackControlMethod;
        //private static MethodInfo GetWebResourceUrlMethod;

        /// <summary>
        /// Determines if MsAjax is available in this Web application
        /// </summary>
        public bool IsMsAjax
        {
            get
            {
                if (scriptManagerType == null)
                    CheckForMsAjax();

                return _IsMsAjax;
            }
        }

        private static bool _IsMsAjax = false;

        /// <summary>
        /// Current instance of this class which should always be used to
        /// access this object. There are no public constructors to
        /// ensure the reference is used as a Singleton to further
        /// ensure that all scripts are written to the same clientscript
        /// manager.
        /// </summary>
        public static ClientScriptProxy Current
        {
            get
            {
                return
                    (HttpContext.Current.Items["__ClientScriptProxy"] ??
                     (HttpContext.Current.Items["__ClientScriptProxy"] =
                      new ClientScriptProxy()))
                    as ClientScriptProxy;
            }
        }

        /// <summary>
        /// No public constructor - use ClientScriptProxy.Current to
        /// get an instance to ensure you once have one instance per
        /// page active.
        /// </summary>
        protected ClientScriptProxy()
        {
        }


        /// <summary>
        /// Checks to see if MS Ajax is registered with the current
        /// Web application.
        ///
        /// Note: Method is static so it can be directly accessed from
        /// anywhere
        /// </summary>
        /// <returns></returns>
        public static bool CheckForMsAjax()
        {
            // *** Easiest but we don't want to hardcode the version here
            // scriptManagerType = Type.GetType("System.Web.UI.ScriptManager, System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35", false);


            // *** To be safe and compliant we need to look through all loaded assemblies
            Assembly ScriptAssembly = null; // Assembly.LoadWithPartialName("System.Web.Extensions");

            foreach (Assembly ass in AppDomain.CurrentDomain.GetAssemblies())
            {
                string fn = ass.FullName;

                if (fn.StartsWith("System.Web.Extensions"))
                {
                    ScriptAssembly = ass;
                    break;
                }
            }

            if (ScriptAssembly == null)
                return false;


            //Assembly ScriptAssembly = Assembly.LoadWithPartialName("System.Web.Extensions");
            //if (ScriptAssembly != null)
            scriptManagerType = ScriptAssembly.GetType("System.Web.UI.ScriptManager");

            if (scriptManagerType != null)
            {
                _IsMsAjax = true;
                return true;
            }

            _IsMsAjax = false;
            return false;
        }

        public bool IsInAsyncPostBack
        {
            get
            {
                if (IsMsAjax)
                {
                    if (HttpContext.Current.Items["IsInAsyncPostBack"] == null)
                        HttpContext.Current.Items["IsInAsyncPostBack"] =
                            scriptManagerType.GetProperty(("IsInAsyncPostBack"));

                    return Convert.ToBoolean(HttpContext.Current.Items["IsInAsyncPostBack"]);
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Registers a client script block in the page.
        /// </summary>
        /// <param name="control"></param>
        /// <param name="type"></param>        
        /// <param name="key"></param>
        /// <param name="script"></param>
        /// <param name="addScriptTags"></param>
        public void RegisterClientScriptBlock(Control control, Type type, string key, string script, bool addScriptTags)
        {
            if (IsMsAjax)
            {
                if (RegisterClientScriptBlockMethod == null)
                    RegisterClientScriptBlockMethod =
                        scriptManagerType.GetMethod("RegisterClientScriptBlock",
                                                    new Type[5]
                                                        {
                                                            typeof (Control), typeof (Type), typeof (string),
                                                            typeof (string), typeof (bool)
                                                        });

                RegisterClientScriptBlockMethod.Invoke(null, new object[5] {control, type, key, script, addScriptTags});
            }
            else
                control.Page.ClientScript.RegisterClientScriptBlock(type, key, script, addScriptTags);
        }


        /// <summary>
        /// Registers a startup code snippet that gets placed at the bottom of the page
        /// </summary>
        /// <param name="control"></param>
        /// <param name="type"></param>
        /// <param name="key"></param>
        /// <param name="script"></param>
        /// <param name="addStartupTags"></param>
        public void RegisterStartupScript(Control control, Type type, string key, string script, bool addStartupTags)
        {
            if (IsMsAjax)
            {
                if (RegisterStartupScriptMethod == null)
                    RegisterStartupScriptMethod =
                        scriptManagerType.GetMethod("RegisterStartupScript",
                                                    new Type[5]
                                                        {
                                                            typeof (Control), typeof (Type), typeof (string),
                                                            typeof (string), typeof (bool)
                                                        });

                RegisterStartupScriptMethod.Invoke(null, new object[5] {control, type, key, script, addStartupTags});
            }
            else
                control.Page.ClientScript.RegisterStartupScript(type, key, script, addStartupTags);
        }


        /// <summary>
        /// Registers a script include tag into the page for an external script url
        /// </summary>
        /// <param name="control"></param>
        /// <param name="type"></param>
        /// <param name="key"></param>
        /// <param name="url"></param>
        public void RegisterClientScriptInclude(Control control, Type type, string key, string url)
        {
            if (IsMsAjax)
            {
                if (RegisterClientScriptIncludeMethod == null)
                    RegisterClientScriptIncludeMethod =
                        scriptManagerType.GetMethod("RegisterClientScriptInclude",
                                                    new Type[4]
                                                        {
                                                            typeof (Control), typeof (Type), typeof (string),
                                                            typeof (string)
                                                        });

                RegisterClientScriptIncludeMethod.Invoke(null, new object[4] {control, type, key, url});
            }
            else
                control.Page.ClientScript.RegisterClientScriptInclude(type, key, url);
        }


        /// <summary>
        /// Returns a WebResource or ScriptResource URL for script resources that are to be
        /// embedded as script includes.
        /// </summary>
        /// <param name="control"></param>
        /// <param name="type"></param>
        /// <param name="resourceName"></param>
        public void RegisterClientScriptResource(Control control, Type type, string resourceName)
        {
            if (IsMsAjax)
            {
                if (RegisterClientScriptResourceMethod == null)
                    RegisterClientScriptResourceMethod =
                        scriptManagerType.GetMethod("RegisterClientScriptResource",
                                                    new Type[3] {typeof (Control), typeof (Type), typeof (string)});

                RegisterClientScriptResourceMethod.Invoke(null, new object[3] {control, type, resourceName});
            }
            else
                control.Page.ClientScript.RegisterClientScriptResource(type, resourceName);
        }


        /// <summary>
        /// Returns a WebResource URL for non script resources
        /// </summary>
        /// <param name="control"></param>
        /// <param name="type"></param>
        /// <param name="resourceName"></param>
        /// <returns></returns>
        public string GetWebResourceUrl(Control control, Type type, string resourceName)
        {
            //if (this.IsMsAjax)
            //{
            //    if (GetWebResourceUrlMethod == null)
            //        GetWebResourceUrlMethod = scriptManagerType.GetMethod("GetScriptResourceUrl");
            //    return GetWebResourceUrlMethod.Invoke(null, new object[2] { resourceName, control.GetType().Assembly }) as string;
            //}
            //else
            return control.Page.ClientScript.GetWebResourceUrl(type, resourceName);
        }


        /// <summary>
        /// Injects a hidden field into the page
        /// </summary>
        /// <param name="control"></param>
        /// <param name="hiddenFieldName"></param>
        /// <param name="hiddenFieldInitialValue"></param>
        public void RegisterHiddenField(Control control, string hiddenFieldName, string hiddenFieldInitialValue)
        {
            if (IsMsAjax)
            {
                if (RegisterHiddenFieldMethod == null)
                    RegisterHiddenFieldMethod =
                        scriptManagerType.GetMethod("RegisterHiddenField",
                                                    new Type[3] {typeof (Control), typeof (string), typeof (string)});

                RegisterHiddenFieldMethod.Invoke(null, new object[3] {control, hiddenFieldName, hiddenFieldInitialValue});
            }
            else
                control.Page.ClientScript.RegisterHiddenField(hiddenFieldName, hiddenFieldInitialValue);
        }
    }
}