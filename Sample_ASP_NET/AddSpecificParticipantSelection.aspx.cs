using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace Sample_ASP_NET
{
    public partial class AddSpecificParticipantSelection : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string strReturnValue = "participantSelected";
            StringBuilder sb = new StringBuilder();
            sb.Length = 0;
            sb.Append("<script type=text/javascript>");
            sb.Append("window.opener.setParticipantSelectedValue('" + strReturnValue + "');");
            //sb.Append("window.returnValue = 'participantSelected';");
            sb.Append("window.close();");
            sb.Append("</script>");
            Page.RegisterStartupScript("Script", sb.ToString());
        }
    }
}