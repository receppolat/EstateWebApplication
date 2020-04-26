<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminduyurular.aspx.cs" Inherits="Emlak_Sitesi.adminduyurular" %>

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
            $("#btnekle").animate({ borderRadius: '20px' });
            $("#btnsil").animate({ borderRadius: '20px' });
            $("#btnduzenle").animate({ borderRadius: '20px' });
            $("#tbbaslik").animate({ borderRadius: '20px' });
            $("#tbicerik").animate({ borderRadius: '30px' });
        });


    </script>
    <style type="text/css">
    body{


    background-image: url(gray.png);  /* Resim Dosyası */
    </style>



    <style type="text/css">
        .auto-style1 {
            width: 912px;
            height: 335px;
        }
        .auto-style3 {
            width: 13px;
        }
        .auto-style4 {
            width: 290px;
        }
        .auto-style5 {
            width: 353px;
        }
        .auto-style6 {
            width: 110px
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
                <td class="auto-style6" style="font-style: italic">&nbsp;&nbsp;Başlık</td>
                <td class="auto-style3">:</td>
                <td class="auto-style4">
                    <br />
                    <asp:TextBox ID="tbbaslik" runat="server"></asp:TextBox>
                    <br />
                    <br />
                </td>
                <td class="auto-style5" rowspan="6">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Height="352px" Width="312px" DataSourceID="SqlDataSource1" AllowPaging="True" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" DataKeyNames="duyuruid" ForeColor="Black" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" />
                            <asp:BoundField DataField="duyuruid" HeaderText="Duyuru ID" InsertVisible="False" ReadOnly="True" SortExpression="duyuruid" />
                            <asp:BoundField DataField="baslik" HeaderText="Başlık" SortExpression="baslik" />
                            <asp:BoundField DataField="icerik" HeaderText="İçerik" SortExpression="icerik" />
                            <asp:BoundField DataField="tarih" HeaderText="Tarih" SortExpression="tarih" />
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
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:odevConnectionString9 %>" ProviderName="<%$ ConnectionStrings:odevConnectionString9.ProviderName %>" SelectCommand="SELECT [duyuruid], [baslik], [icerik], [tarih] FROM [duyurular]"></asp:SqlDataSource>
                    </td>
            </tr>
            <tr>
                <td class="auto-style6" style="font-style: italic">&nbsp;&nbsp; İçerik</td>
                <td class="auto-style3">:</td>
                <td class="auto-style4">
                    <br />
                    <asp:TextBox ID="tbicerik" runat="server"></asp:TextBox>
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td class="auto-style6" style="font-style: italic">&nbsp;&nbsp; Fotoğraf</td>
                <td class="auto-style3">:</td>
                <td class="auto-style4">
                    <br />
                    <br />
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                    <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <br />
                </td>
            </tr>
            <tr>
                <td style="font-style: italic" colspan="3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                     <br />
                   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnekle" runat="server" Text="Ekle" Width="127px" Height="38px" OnClick="btnekle_Click" />
                    &nbsp;&nbsp;
                    <asp:Button ID="btnsil" runat="server" Text="Sil" Width="129px" Height="36px" OnClick="btnsil_Click" />
&nbsp;&nbsp;
                    <asp:Button ID="btnduzenle" runat="server" Text="Düzenle" Height="36px" Width="128px" OnClick="btnduzenle_Click" />
                </td>
            </tr>
        </table>
    </form>
    <script src="jquery-2.2.3.js"></script>
</body>
</html>
