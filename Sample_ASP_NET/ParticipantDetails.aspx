<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ParticipantDetails.aspx.cs" Inherits="Sample_ASP_NET.ParticipantDetails" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Participants Selection</title>
    <style>
        .main-panel { padding: 25px; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="main-panel">
            <asp:Button ID="btnSpecificParticipant" runat="server" Text="Add Specific Participant(s)" OnClientClick="openAddParticipantPopup(); return false;" CssClass="btn btn-secondary" />

            <div id="selectedParticipantsContainer" style="margin-top:20px;">
                <asp:ListBox ID="lstSelectedParticipants" runat="server" Width="300px" Rows="10" SelectionMode="Multiple" 
                    value="opt" />
            </div>
            <asp:HiddenField ID="hdnSelectedParticipantsJson" runat="server" />
            <asp:Button ID="btnRemove" runat="server" Text="Remove Selected" CssClass="btn btn-danger" OnClick="btnRemove_Click" />

        </div>
    </form>

    <script type="text/javascript">
        function openAddParticipantPopup() {
            window.open('AddParticipants.aspx', 'AddParticipantPopup', 'width=600,height=400,resizable=yes,scrollbars=yes');
        }

        function receiveParticipants(jsonData) {
            try {
                var participants = JSON.parse(jsonData);
            } catch (e) {
                alert("Invalid participant data received.");
                return;
            }
            var json = JSON.stringify(participants);
            document.getElementById('<%= hdnSelectedParticipantsJson.ClientID %>').value = json;
            document.forms[0].submit();
        }
    </script>
</body>
</html>
