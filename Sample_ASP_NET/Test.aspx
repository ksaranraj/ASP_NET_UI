<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="Sample_ASP_NET.Test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Test Page</title>
</head>
<script src="Scripts/jquery-3.7.1.min.js" type="text/javascript"></script>
<script language="javascript">
    $(document).ready(function () {
        $('#btnAddParticipant').click(function showDialogPref() {
            var scrWidth = screen.width;
            var scrLeft = screen.width - 650;
            window.open('AddSpecificParticipantSelection.aspx', '');
        });
    });
    function setParticipantSelectedValue(value) {
        alert(value);
    }
    //function GoToMaritalStatus() {
    //    top.location.href = "https://" + top.location.host + "/btui/benetracking_maritalstatus.aspx";
    //}
</script>
<body>
    <form id="form1" runat="server">
        <%--<div>
              <b>Beneficiary Designation</b><br />
            You may elect or update your beneficiaries onlie at any time.
            <a href="javascript:GoToMaritalStatus()" runat="server">Beneficiary Designations / Updates</a>
        </div>--%>
        <asp:LinkButton ID="btnAddParticipant" runat="server">Add Specific Participant(s)</asp:LinkButton>
    </form>
</body>
</html>
