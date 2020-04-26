<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="uye_giris.aspx.cs" Inherits="Emlak_Sitesi.uye_giris" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>
        Polat Emlak | Üye Girişi
    </title>
    <script src="jquery-2.2.3.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            $("#tbka").animate({ borderRadius: '30px' });
            $("#tbsifre").animate({ borderRadius: '30px' });
            $("#tbka").focusout(function () {
                $(this).animate({ width: '180px', opacity: '1' }, "fast");
            });
            $("#tbka").focusin(function () {
                $(this).animate({ width: '200px', opacity: '0.4' }, "fast");
            });
            $("#tbsifre").focusout(function () {
                $(this).animate({ width: '180px', opacity: '1' }, "fast");
            });
            $("#tbsifre").focusin(function () {
                $(this).animate({ width: '200px', opacity: '0.4' }, "fast");
            });
        });


    </script>

    <style type="text/css">
    body{


    background-image: url(arkaplan.png);  /* Resim Dosyası */


    color: #FFF;


}
        .auto-style4 {
            margin-left: 570px;
        }
        .auto-style7 {
            margin-left: 400px;
        }
        .auto-style8 {
            margin-left: 520px;
            width: 423px;
        }
      
        </style>
</head>


<body>
    <form id="form1" runat="server" style="font-size: medium">
        <p class="auto-style4" style="font-size: xx-large">
            &nbsp;</p>
        <p class="auto-style4" style="font-size: xx-large">
            &nbsp;</p>
        <p class="auto-style4" style="font-size: xx-large">
            &nbsp;</p>
        <p class="auto-style4" style="font-size: xx-large; font-family: 'Times New Roman', Times, serif; text-decoration: underline overline;">
            &nbsp;HOSGELDINIZ</p>
        <p class="auto-style8" style="font-size: large">
            Sisteme giriş yapmak için bilgilerinizi giriniz.</p>
        <p class="auto-style7">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/user.png" Width="30px" Height="30px" />
            <asp:TextBox ID="tbka" runat="server" Width="180px" Height="30px" Font-Bold="False" Font-Italic="True" Font-Overline="False" Font-Size="Medium" Font-Strikeout="False" BackColor="#ffffff" OnTextChanged="tbka_TextChanged"></asp:TextBox>
       
        </p>
        <p class="auto-style7">


            <asp:Image ID="Image2" runat="server" ImageUrl="~/password.png" Width="30px" />
            <asp:TextBox ID="tbsifre" runat="server" Width="180px" Height="30px" Font-Italic="True" Font-Size="Medium" BackColor="#ffffff"  OnTextChanged="tbsifre_TextChanged" TextMode="Password"></asp:TextBox>
        </p>
        <p class="auto-style7">


            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btngrs" runat="server" BackColor="#4B6183" Text="Giriş Yap" Width="112px" Height="32px" OnClick="btngrs_Click" />
        &nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnkyt" runat="server" Text="Kayıt Ol" BackColor="#4B6183" Width="112px" Height="32px" OnClick="btnkyt_Click"/>
        </p>
    </form>
</body>
</html>
