using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sample_ASP_NET
{
    public partial class ParticipantDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                // Check if data is posted via a hidden field
                string json = hdnSelectedParticipantsJson.Value;
                if (!string.IsNullOrEmpty(json))
                {
                    var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                    // var participants = serializer.Deserialize<dynamic>(json);
                    // var participants = serializer.Deserialize<System.Collections.Generic.Dictionary<string, object>[]>(json);
                    var participants = serializer.Deserialize<List<Dictionary<string, string>>>(json);

                    DataTable dt = new DataTable();
                    dt.Columns.Add("name", typeof(string));
                    dt.Columns.Add("email", typeof(string));

                    foreach (var p in participants)
                    {
                        // Access properties dynamically
                        string name = p["name"];
                        string email = p["email"];

                        dt.Rows.Add(name, email);
                    }

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        dt.AcceptChanges();
                        Session["dtParticipants"] = dt;
                        hdnSelectedParticipantsJson.Value = string.Empty;
                        RefreshParticipantList(dt);
                    }
                }
            }
        }

        private void RefreshParticipantList(DataTable dt)
        {
            lstSelectedParticipants.DataTextField = dt.Columns["name"].ToString();
            lstSelectedParticipants.DataValueField = dt.Columns["email"].ToString();
            lstSelectedParticipants.DataSource = dt;
            lstSelectedParticipants.DataBind();
        }

        protected void btnRemove_Click(object sender, EventArgs e)
        {
            DataTable dtSelectedParticipants = (DataTable)Session["dtParticipants"];
            foreach (ListItem li in this.lstSelectedParticipants.Items)
            {
                if (li.Selected)
                {
                    System.Text.StringBuilder FXCOPStringBuilder = new System.Text.StringBuilder();
                    FXCOPStringBuilder.Length = 0;
                    DataRow[] drs = dtSelectedParticipants.Select(FXCOPStringBuilder.Append("email = '").Append(li.Value).Append("'").ToString());
                    if (drs.Length == 1)
                    {
                        drs[0].Delete();
                    }
                }
            }
            dtSelectedParticipants.AcceptChanges();
            lstSelectedParticipants.DataSource = dtSelectedParticipants;
            lstSelectedParticipants.DataBind();
        }


    }
}