<%@ Application Language="C#" %>
<script RunAt="server">

    void Application_Start(object sender, EventArgs e)
    {
        // Code that runs on application startup

    }

    void Application_End(object sender, EventArgs e)
    {
        //  Code that runs on application shutdown

    }

    void Application_Error(object sender, EventArgs e)
    {
        // Code that runs when an unhandled error occurs

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


    protected void Application_BeginRequest(object sender, System.EventArgs e)
    {
        string strrawredirecturl=string.Empty;
        strrawredirecturl = Request.RawUrl;

        if (!string.IsNullOrEmpty(strrawredirecturl))
        {
            strrawredirecturl = strrawredirecturl.TrimStart('/');
            if (!string.IsNullOrEmpty(strrawredirecturl))
            {
                Hashtable parameters = new Hashtable();
                mainclass clsm = new mainclass();
                parameters.Add("@redirectFrom", strrawredirecturl);
                string strdbvalue = Convert.ToString(clsm.SendValue_Parameter("select redirectTo from  redirectmanagement where status=1 and redirectFrom=@redirectFrom", parameters));
                
                if (!string.IsNullOrEmpty(strdbvalue))
                {
                    if (strdbvalue.Contains("http") == true || strdbvalue.Contains("https") == true)
                    {
                        string newUrl =strdbvalue;
                        Response.Status = "301 Moved Permanently";
                        Response.AddHeader("Location", newUrl);
                    }
                    else
                    {
                       //Response.Write(strdbvalue);
                        string newUrl = "/" + strdbvalue;
                        Response.Status = "301 Moved Permanently";
                        Response.AddHeader("Location", newUrl);
                    }
                    
                }
            }
        }
    }
       
</script>
