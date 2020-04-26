<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="harita.aspx.cs" Inherits="Emlak_Sitesi.harita" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <%Response.Write(haritaa); %>
        </div>
    </form>
</body>
</html>
