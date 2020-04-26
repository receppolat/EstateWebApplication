<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="Emlak_Sitesi.admin" %>

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
            $("#ddsatilik").animate({ borderRadius: '20px' });
            $("#btnekle").animate({ borderRadius: '20px' });
            $("#btnsil").animate({ borderRadius: '20px' });
            $("#btnduzenle").animate({ borderRadius: '20px' });
            $("#ddtur").animate({ borderRadius: '20px' });
            $("#tbozellik").animate({ borderRadius: '30px' });
            $("#tbfiyat").animate({ borderRadius: '30px' });
            $("#tbaciklama").animate({ borderRadius: '30px' });
            $("#tbadres").animate({ borderRadius: '30px' });
            $("#ddsehirler").animate({ borderRadius: '30px' });
           
        });


    </script>
    <style type="text/css">
    body{


    background-image: url(gray.png);  /* Resim Dosyası */
    </style>


    <style type="text/css">
        .auto-style1 {
            width: 170px;
        }
        .auto-style2 {
            width: 13px;
        }
        .auto-style3 {
            width: 268px;
        }
        .auto-style4 {
            width: 100%;
            height: 348px;
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

        <table class="auto-style4">
            <tr>
                <td class="auto-style1">&nbsp;&nbsp; Tür&nbsp;</td>
                <td class="auto-style2">:</td>
                <td class="auto-style3">
                    <asp:DropDownList ID="ddtur" runat="server" Height="30px" Width="175px">
                    </asp:DropDownList>
                </td>
                <td rowspan="12">
                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" DataKeyNames="evid" DataSourceID="SqlDataSource1" ForeColor="Black" Height="325px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="485px">
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" />
                            <asp:BoundField DataField="evid" HeaderText="Ev ID" InsertVisible="False" ReadOnly="True" SortExpression="evid" />
                            <asp:BoundField DataField="adres" HeaderText="Adres" SortExpression="adres" />
                            <asp:BoundField DataField="fiyat" HeaderText="Fiyat" SortExpression="fiyat" />
                            <asp:BoundField DataField="satilik" HeaderText="Satılık" SortExpression="satilik" />
                            <asp:BoundField DataField="tur" HeaderText="Tür" SortExpression="tur" />
                            <asp:BoundField DataField="sehir" HeaderText="Şehir" SortExpression="sehir" />
                            <asp:BoundField DataField="odasayisi" HeaderText="Oda Sayisi" SortExpression="odasayisi" />
                            <asp:BoundField DataField="salonsayisi" HeaderText="Salon Sayisi" SortExpression="salonsayisi" />
                            <asp:BoundField DataField="ozellik" HeaderText="Özellik" SortExpression="ozellik" />
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
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:odevConnectionString8 %>" ProviderName="<%$ ConnectionStrings:odevConnectionString8.ProviderName %>" SelectCommand="SELECT [evid], [adres], [fiyat], [satilik], [tur], [sehir], [odasayisi], [salonsayisi], [ozellik] FROM [evler]"></asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;&nbsp; Özellik&nbsp;</td>
                <td class="auto-style2">:</td>
                <td class="auto-style3">
                    <asp:TextBox ID="tbozellik" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;&nbsp; Fiyat&nbsp;</td>
                <td class="auto-style2">:</td>
                <td class="auto-style3">
                    <asp:TextBox ID="tbfiyat" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;&nbsp; Satılık-Kiralık&nbsp;</td>
                <td class="auto-style2">:</td>
                <td class="auto-style3">
                    <asp:DropDownList ID="ddsatilik" runat="server" Height="30px" Width="175px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;&nbsp; Açıklama&nbsp;</td>
                <td class="auto-style2">:</td>
                <td class="auto-style3">
                    <asp:TextBox ID="tbaciklama" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;&nbsp;&nbsp;Fotoğraf</td>
                <td class="auto-style2">:</td>
                <td class="auto-style3">
                    <asp:FileUpload ID="FileUpload1" runat="server" Width="171px" />
                </td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;&nbsp; Adres&nbsp;</td>
                <td class="auto-style2">:</td>
                <td class="auto-style3">
                    <asp:TextBox ID="tbadres" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;&nbsp; Şehir&nbsp;</td>
                <td class="auto-style2">:</td>
                <td class="auto-style3">
                    <asp:DropDownList ID="ddsehirler" runat="server" Height="30px" Width="175px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;&nbsp; Oda Sayısı&nbsp;</td>
                <td class="auto-style2">:</td>
                <td class="auto-style3">
                    <asp:TextBox ID="tboda" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;&nbsp; Salon Sayısı&nbsp;</td>
                <td class="auto-style2">:</td>
                <td class="auto-style3">
                    <asp:TextBox ID="tbsalon" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>&nbsp;&nbsp; Müsait mi?&nbsp;</td>
                <td>:</td>
                <td>
                    <asp:CheckBox ID="CheckBox1" runat="server" Text="Evet" />
                </td>
            </tr>
            <tr>
                <td colspan="3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;<asp:Button ID="btnekle" runat="server" Text="Ekle" Width="82px" OnClick="btnekle_Click" style="height: 26px" />
                    &nbsp;&nbsp;
                    <asp:Button ID="btnsil" runat="server" Text="Sil" Width="79px" OnClick="btnsil_Click" />
&nbsp;&nbsp;
                    <asp:Button ID="btnduzenle" runat="server" Text="Düzenle" OnClick="btnduzenle_Click" />
                    &nbsp;&nbsp;</td>
            </tr>
        </table>
    </form>

</body>
</html>

