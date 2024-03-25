using Business.Entities;
using Business.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace UI.Web
{
    public partial class Index : ApplicationForm
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (GetSession() == null)
            {
                Response.Redirect("Loguin.aspx");
            }
            else
            {
                SetInterfaceByUser(GetSession());
            }
        }
    }
}