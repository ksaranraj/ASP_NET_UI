using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sample_ASP_NET
{
    public partial class AddParticipants : System.Web.UI.Page
    {
        public class Participant
        {
            public string Name { get; set; }
            public string Email { get; set; }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                var participants = new List<Participant>
                {
                    new Participant { Name = "Alice", Email="alice@example.com"},
                    new Participant { Name= "Bob", Email="bob@example.com" }
                };
                ParticipantsGrid.DataSource = participants;
                ParticipantsGrid.DataBind();
            }
        }

        protected void btnIncludeParticipants_Click(object sender, EventArgs e)
        {
            var dtSelectedParticipants = new System.Data.DataTable();
            dtSelectedParticipants.Columns.Add("name", typeof(string));
            dtSelectedParticipants.Columns.Add("email", typeof(string));

            foreach (GridViewRow row in ParticipantsGrid.Rows)
            {
                var chkSelect = row.FindControl("chkSelect") as CheckBox;
                if (chkSelect != null && chkSelect.Checked)
                {
                    var name = row.Cells[1].Text.Trim();
                    var email = row.Cells[2].Text.Trim();
                    dtSelectedParticipants.Rows.Add(name, email);
                }
            }

            // Convert DataTable to a list of dictionaries for serialization
            var resultList = new List<Dictionary<string, object>>();
            foreach (System.Data.DataRow dr in dtSelectedParticipants.Rows)
            {
                var rowDict = new Dictionary<string, object>();
                foreach (System.Data.DataColumn col in dtSelectedParticipants.Columns)
                {
                    rowDict[col.ColumnName] = dr[col];
                }
                resultList.Add(rowDict);
            }

            // Serialize and register client script to return data
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            var json = serializer.Serialize(resultList);
            var script = $"window.opener.receiveParticipants('" + json + "'); window.close();";
            ClientScript.RegisterStartupScript(GetType(), "Script", script, true);
        }
    }
}