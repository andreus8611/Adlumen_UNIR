<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AdlumenMVC.WebUI.Reports.Default" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845DCD8080CC91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">        
        body {
            margin: 0;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">

    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>

        <rsweb:ReportViewer ID="viewer" runat="server" ProcessingMode="Remote" Width="100%" Height="100%" 
            BackColor="#dee7f2" BorderColor="#a4b7d8" SplitterBackColor="#a4b7d8">
        </rsweb:ReportViewer>
    </div>

    </form>
    <script>
    function pageLoad() {
        try {
            var element = document.querySelector('table[id*=_fixedTable] > tbody > tr:last-child > td:last-child > div');
            if (element) {
                element.style.overflow = "visible";
            }
        } 
        catch (e) {
            console.log(e);
        }
    }
    </script>
</body>
</html>
