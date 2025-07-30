<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddParticipants.aspx.cs" Inherits="Sample_ASP_NET.AddParticipants" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Participants List</title>
    <link href="Content/Site.css" rel="stylesheet" />
    <script type="text/javascript">
        function sendParticipants() {
            var hdn = document.getElementById("hdnSelectedParticipantsJson");
            if (hdn && window.opener && typeof window.opener.receiveParticipants === "function") {
                window.opener.receiveParticipants(hdn.value);
                window.close();
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Participants</h2>
            <asp:GridView ID="ParticipantsGrid" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:CheckBox ID="chkSelect" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Name" HeaderText="Name" />
                    <asp:BoundField DataField="Email" HeaderText="Email" />
                </Columns>
            </asp:GridView>
            <asp:Button ID="btnIncludeParticipants" runat="server" Text="Include Participants" CssClass="btn btn-primary" OnClick="btnIncludeParticipants_Click" />
            <input type="hidden" id="hdnSelectedParticipantsJson" name="hdnSelectedParticipantsJson" />
        </div>
    </form>
</body>
</html>