<%@ Application Language="C#" %>
<%@ Import Namespace="System.Diagnostics" %>
<%@ Import Namespace="System.Web.Security" %>
 <%--
    Copyright (c) 2008-2010 by the President and Fellows of Harvard College. All rights reserved.  
    Profiles Research Networking Software was developed under the supervision of Griffin M Weber, MD, PhD.,
    and Harvard Catalyst: The Harvard Clinical and Translational Science Center, with support from the 
    National Center for Research Resources and Harvard University.


    Code licensed under a BSD License. 
    For details, see: LICENSE.txt 
 --%> 
<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        // Code that runs on application startup

    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown
        
    }

    
    /// <summary>
    /// 
    ///     Global Error Handler.
    ///     
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
        
    void Application_Error(object sender, EventArgs e) 
    {

        //Each error that occurs will trigger this event.
        try
        {           
            if (HttpContext.Current.Session["GLOBAL_ERROR"] == null)
            {
                //get reference to the source of the exception chain
                Exception ex = Server.GetLastError().GetBaseException();

                EventLog.WriteEntry("Profiles",
                  "MESSAGE: " + ex.Message +
                  "\nSOURCE: " + ex.Source +
                  "\nFORM: " + Request.Form.ToString() +
                  "\nQUERYSTRING: " + Request.QueryString.ToString() +
                  "\nTARGETSITE: " + ex.TargetSite +
                  "\nSTACKTRACE: " + ex.StackTrace,
                  EventLogEntryType.Error);

                HttpContext.Current.Session.Add("GLOBAL_ERROR", "MESSAGE: " + ex.Message +
                   "\nSOURCE: " + ex.Source +
                   "\nFORM: " + Request.Form.ToString() +
                   "\nQUERYSTRING: " + Request.QueryString.ToString());
                
                
                //After the error is written to the event log, a copy of the same message is loaded into a session variable and then
                //displayed in the ErrorPage.aspx file.
                
                Response.Redirect("ErrorPage.aspx");


            }


            Response.End();
        }
        catch { }
    }

    void Session_Start(object sender, EventArgs e) 
    {
        // Code that runs when a new session is started
    }

    void Session_End(object sender, EventArgs e) 
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.
        

    }
       
</script>
