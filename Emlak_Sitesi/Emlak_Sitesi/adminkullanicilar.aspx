<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminkullanicilar.aspx.cs" Inherits="Emlak_Sitesi.adminkullanicilar" %>


<!DOCTYPE html>
<html lang="en">
<head>
  <title>POLAT EMLAK | Admin</title>
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>

     <script type="text/javascript">
        $(document).ready(function () {
            $("#ddgorev").animate({ borderRadius: '20px' });
            $("#btnekle").animate({ borderRadius: '20px' });
            $("#btnsil").animate({ borderRadius: '20px' });
            $("#btnduzenle").animate({ borderRadius: '20px' });
            $("#tbad").animate({ borderRadius: '20px' });
            $("#tbsoyad").animate({ borderRadius: '30px' });
            $("#tbposta").animate({ borderRadius: '30px' });
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


    background-image: url(gray.png);  /* Resim Dosyası */
    </style>

    <style type="text/css">
        .auto-style1 {
            width: 1818px;
            height: 154px;
        }
        .auto-style2 {
            width: 96px;
        }
        .auto-style3 {
            width: 17px;
        }
        .auto-style4 {
            width: 170px;
        }
        .auto-style5 {
            width: 853px;
        }
    </style>
</head>
<body>

    <form id="form1" runat="server">

<nav class="navbar navbar-inverse">
  <div class="container-fluid">
    <ul class="nav navbar-nav">
     <li><a href="admin.aspx">Ana Sayfa</a></li>
      <li><a href="adminkullanicilar.aspx">Kullanıcılar</a></li>
      <li><a href="adminduyurular.aspx">Duyurular</a></li>
      <li><a href="adminozelislemler.aspx">Özel İşlemler</a></li>
 <li> <asp:LinkButton ID="cikis" runat="server" OnClick="cikis_Click">Çıkış Yap</asp:LinkButton></li>
    </ul>
  </div>
</nav>



<div class="container">
</div>

        <table class="auto-style1">
            <tr>
                <td class="auto-style2" style="font-style: italic">&nbsp;&nbsp;&nbsp; İsim:</td>
                <td class="auto-style3">:</td>
                <td class="auto-style4">
                    <br />
                    <asp:TextBox ID="tbad" runat="server"></asp:TextBox>
                    <br />
                    <br />
                </td>
                <td class="auto-style5" rowspan="7">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Height="352px" Width="312px" DataSourceID="SqlDataSource1" AllowPaging="True" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" DataKeyNames="id" ForeColor="Black" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" />
                            <asp:BoundField DataField="id" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                            <asp:BoundField DataField="ka" HeaderText="Kullanıcı Adı" SortExpression="ka" />
                            <asp:BoundField DataField="sifre" HeaderText="Şifre" SortExpression="sifre" />
                            <asp:BoundField DataField="isim" HeaderText="İsim" SortExpression="isim" />
                            <asp:BoundField DataField="soyisim" HeaderText="Soyisim" SortExpression="soyisim" />
                            <asp:BoundField DataField="eposta" HeaderText="Email" SortExpression="eposta" />
                        </Columns>
                        <FooterStyle BackColor="#CCCCCC" />
                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                        <RowStyle BackColor="White" />
                        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#808080" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#383838" />
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:odevConnectionString3 %>" ProviderName="<%$ ConnectionStrings:odevConnectionString3.ProviderName %>" SelectCommand="SELECT [id], [ka], [isim], [soyisim], [sifre], [eposta], [gorev] FROM [uyeler]"></asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td class="auto-style2" style="font-style: italic">&nbsp;&nbsp; Soyisim</td>
                <td class="auto-style3">:</td>
                <td class="auto-style4">
                    <br />
                    <asp:TextBox ID="tbsoyad" runat="server"></asp:TextBox>
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td class="auto-style2" style="font-style: italic">&nbsp;&nbsp; E-Posta&nbsp;</td>
                <td class="auto-style3">:</td>
                <td class="auto-style4">
                    <br />
                    <asp:TextBox ID="tbposta" runat="server"></asp:TextBox>
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td class="auto-style2" style="font-style: italic">&nbsp;&nbsp; Kullanıcı Adı&nbsp;</td>
                <td class="auto-style3">:</td>
                <td class="auto-style4">
                    <br />
                    <asp:TextBox ID="tbka" runat="server"></asp:TextBox>
                    <br />
                    <br />
                </td>
            </tr>
            <tr>

                <td class="auto-style2" style="font-style: italic">&nbsp;&nbsp; Şifre&nbsp;</td>
                <td class="auto-style3">:</td>
                <td class="auto-style4">
                    <br />
                    <asp:TextBox ID="tbsifre" runat="server"></asp:TextBox>
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td style="font-style: italic" colspan="3">&nbsp;&nbsp; </td>
            </tr>
            <tr>
                <td style="font-style: italic" colspan="3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                     <br />
                   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnekle" runat="server" Text="Ekle" Width="82px" OnClick="btnekle_Click" />
                    &nbsp;&nbsp;
                    <asp:Button ID="btnsil" runat="server" Text="Sil" Width="79px" OnClick="btnsil_Click" />
&nbsp;&nbsp;
                    <asp:Button ID="btnduzenle" runat="server" Text="Düzenle" OnClick="btnduzenle_Click" />
                </td>
            </tr>
        </table>
    </form>
    <script src="jquery-2.2.3.js"></script>
</body>
</html>