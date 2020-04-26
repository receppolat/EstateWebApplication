<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminozelislemler.aspx.cs" Inherits="Emlak_Sitesi.adminozelislemler" %>

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
            $("#tbsehirler").animate({ borderRadius: '20px' });
            $("#btnekle").animate({ borderRadius: '20px' });
            $("#btnsilsehir").animate({ borderRadius: '20px' });
            $("#btnekle0").animate({ borderRadius: '20px' });
            $("#btnsiltur").animate({ borderRadius: '20px' });
            $("#tbturler").animate({ borderRadius: '20px' });
            $("#btnanasayfa").animate({ borderRadius: '20px' });
            $("#btnanasayfaSil").animate({ borderRadius: '20px' });
             $("#tbmenu").animate({ borderRadius: '20px' });
        });


    </script>
    <style type="text/css">
    body{


    background-image: url(gray.png);  /* Resim Dosyası */
    }
        .auto-style1 {
            width: 176px;
        }
        .auto-style3 {
            width: 320px;
        }
        .auto-style4 {
            width: 2px;
        }
        .auto-style5 {
            height: 25px;
        }
        .auto-style7 {
            width: 176px;
            height: 28px;
        }
        .auto-style8 {
            height: 28px;
        }
        .auto-style9 {
            width: 320px;
            height: 28px;
        }
        .auto-style11 {
            margin-left: 0px;
        }
        .auto-style12 {
            width: 214px;
        }
        .auto-style13 {
            width: 178px;
        }
        .auto-style14 {
            width: 295px;
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

        <table class="nav-justified">
            <tr>
                <td class="auto-style1">&nbsp;&nbsp;&nbsp; Şehirler</td>
                <td colspan="2">:</td>
                <td class="auto-style3">
                    <asp:TextBox ID="tbsehirler" runat="server"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
                    <br />
&nbsp;<asp:Button ID="btnekle0" runat="server" Text="Ekle" Width="50px" OnClick="btnekle0_Click" style="height: 26px" />
                    &nbsp;&nbsp;
                    &nbsp;&nbsp;
                    <asp:Button ID="btnsilsehir" runat="server" Text="Sil" Width="50px" OnClick="btnsilsehir_Click" />
                    </td>
                <td rowspan="2" class="auto-style12">
                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="sehirid" DataSourceID="SqlDataSource1" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" />
                            <asp:BoundField DataField="sehirid" HeaderText="Şehir ID" InsertVisible="False" ReadOnly="True" SortExpression="sehirid" />
                            <asp:BoundField DataField="sehir" HeaderText="Şehirler" SortExpression="sehir" />
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
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:odevConnectionString4 %>" ProviderName="<%$ ConnectionStrings:odevConnectionString4.ProviderName %>" SelectCommand="SELECT [sehirid], [sehir] FROM [sehirler]"></asp:SqlDataSource>
                </td>
                <td rowspan="2" class="auto-style13">
                    <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="turid" DataSourceID="SqlDataSource2" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" CssClass="auto-style11" ForeColor="Black" OnSelectedIndexChanged="GridView2_SelectedIndexChanged1" Width="126px">
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" />
                            <asp:BoundField DataField="turid" HeaderText="Tür ID" InsertVisible="False" ReadOnly="True" SortExpression="turid" />
                            <asp:BoundField DataField="tur" HeaderText="Tür" SortExpression="tur" />
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
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:odevConnectionString5 %>" ProviderName="<%$ ConnectionStrings:odevConnectionString5.ProviderName %>" SelectCommand="SELECT [turid], [tur] FROM [turler]"></asp:SqlDataSource>
                </td>
                <td rowspan="2" class="auto-style14">
                    &nbsp;&nbsp;<asp:GridView ID="GridView3" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" DataKeyNames="id" DataSourceID="SqlDataSource3" ForeColor="Black" Width="143px">
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" />
                            <asp:BoundField DataField="id" HeaderText="Resim ID" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                            <asp:BoundField DataField="link" HeaderText="URL Adresi" SortExpression="link" />
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
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:odevConnectionString6 %>" ProviderName="<%$ ConnectionStrings:odevConnectionString6.ProviderName %>" SelectCommand="SELECT [id], [link] FROM [resimler]"></asp:SqlDataSource>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
                <td rowspan="2">
                    <asp:GridView ID="GridView4" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" DataKeyNames="id" DataSourceID="SqlDataSource4" ForeColor="Black" OnSelectedIndexChanged="GridView4_SelectedIndexChanged">
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" />
                            <asp:BoundField DataField="id" HeaderText="Menu ID" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                            <asp:BoundField DataField="baslik" HeaderText="Başlık" SortExpression="baslik" />
                            <asp:BoundField DataField="link" HeaderText="Link" SortExpression="link" />
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
                    <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:odevConnectionString10 %>" ProviderName="<%$ ConnectionStrings:odevConnectionString10.ProviderName %>" SelectCommand="SELECT [link], [baslik], [id] FROM [menuler]"></asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td class="auto-style7">&nbsp;&nbsp;&nbsp; Türler</td>
                <td colspan="2" class="auto-style8">:</td>
                <td class="auto-style9">
                    <asp:TextBox ID="tbturler" runat="server"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <br />
&nbsp;
                    <br />
&nbsp;<asp:Button ID="btnekle" runat="server" Text="Ekle" Width="50px" OnClick="btnekle_Click" />
                    &nbsp;
                    &nbsp;&nbsp;
                    <asp:Button ID="btnsiltur" runat="server" Text="Sil" Width="50px" OnClick="btnsiltur_Click" />
                    </td>
            </tr>
            <tr>
                <td colspan="4" class="auto-style5">&nbsp;&nbsp;Toplam Ziyaretçi :
                    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="4">&nbsp;
                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
&nbsp;online ziyaretçi var.</td>
            </tr>
            <tr>
                <td colspan="2">&nbsp;&nbsp;&nbsp; Ana Ekran Görseli&nbsp;</td>
                <td class="auto-style4">:</td>
                <td class="auto-style3">
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                </td>
                <td colspan="4">
                    Site Haritası:
                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Tıklayınız..</asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td colspan="4">&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnanasayfa" runat="server" Text="Ekle" OnClick="btnanasayfa_Click" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnanasayfaSil" runat="server" Text="Sil" OnClick="btnanasayfaSil_Click" Width="43px" />
                </td>
                <td colspan="4">Menü Ekleme :
                    <asp:TextBox ID="tbmenu" runat="server"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btneklemenu" runat="server" OnClick="btneklemenu_Click" Text="Ekle" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnsilmenu" runat="server" OnClick="btnsilmenu_Click" Text="Sil" Width="53px" />
                </td>
            </tr>
        </table>
    </form>

</body>
</html>
