<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="duyuruayrinti.aspx.cs" Inherits="Emlak_Sitesi.duyuruayrinti" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
 <meta charset="UTF-8">
    <meta name="description" content="">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <title>POLAT EMLAK | DUYURULAR</title>
    <link rel="stylesheet" href="style.css">
    <link href="css/animate.css" rel="stylesheet" />
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/classy-nav.min.css" rel="stylesheet" />
    <link href="css/font-awesome.min.css" rel="stylesheet" />
    <link href="css/jquery-ui.min.css" rel="stylesheet" />
    <link href="css/magnific-popup.css" rel="stylesheet" />
    <link href="css/nice-select.css" rel="stylesheet" />
    <link href="css/owl.carousel.css" rel="stylesheet" />
    <link href="css/themify-icons.css" rel="stylesheet" />
    <link href="css/kutuphane.css" rel="stylesheet" />
</head>
<body>
    <form id="form1"  action="#" runat="server" method="post">
        
       <header class="header-area"><!--Header baslama alani -->
        
           <div class="main-header-area" id="stickyHeader"><!--Main'in header baslangici -->
                <div class="classy-nav-container breakpoint-off">
                    <nav class="classy-navbar justify-content-between" id="southNav"><!--Classy Menusu -->
                          <a class="nav-brand" href="index.aspx"><img src="img/core-img/logo1.PNG" alt=""/></a>
                         <div class="classy-navbar-toggler">
                             <span class="navbarToggler"><span></span><span></span><span></span></span>
                         </div>
                        <div class="classy-menu">

                         <div class="classycloseIcon">
                            <div class="cross-wrap"><span class="top"></span><span class="bottom"></span></div>
                        </div>
                            <div class="classynav">
                                <!--STRİNGBUİLDER İLE MENU EKLEME KISMI -->
                               <%Response.Write(menuler); %>

                                <asp:LinkButton ID="giris" runat="server" OnClick="giris_Click">Giriş Yap   </asp:LinkButton>
                                <asp:LinkButton ID="kayit" runat="server" OnClick="kayit_Click">Kayıt Ol</asp:LinkButton>
                             </div>
                       </div>
                    </nav>
                </div>
           </div>
        
     </header>


        <section class="breadcumb-area bg-img" style="background-image: url(img/bg-img/hero1.jpg);">
        <div class="container h-100">
            <div class="row h-100 align-items-center">
                <div class="col-12">
                    <div class="breadcumb-content">
                        <h3 class="breadcumb-title">Duyuru Detayları</h3>
                    </div>
                </div>
            </div>
        </div>
    </section>

<section class="blog-area section-padding-100">
    <div class="container">
        <div class="row">
            <div class="col-12 col-lg-8">
                <% Response.Write(duyuru); %>
                <div class="comments-area">
                    <h5>YORUMLAR</h5><!--Yorum sayisi -->
                    <ol>
                        <%Response.Write(yorumlar); %>
                    </ol>
                </div>
                <div class="leave-comment-area mt-70 clearfix">
                    <div class="comment-form">
                        <div "form-group">
                            <asp:TextBox ID="tbad" class="form-control" placeholder="Görünen İsminiz" runat="server" ReadOnly="True"></asp:TextBox>
                            <br />
                            <br />
                        </div>
                        <div "form-group">
                            <asp:TextBox ID="tbmail" placeholder="E-Posta Adresiniz" class="form-control" runat="server" ReadOnly="True"></asp:TextBox>
                            <br /><br />
                        </div>
                        <div "form-group">
                            <asp:TextBox ID="tbyorum" placeholder="Yorumunuzu Yazınız..." class="form-control" runat="server" ReadOnly="True"></asp:TextBox>
                            <br /><br />
                        </div>
                        <asp:Button ID="btnonay" class="btn south-btn" runat="server" Text="Yorum Yaz" Enabled="False" OnClick="btnonay_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>



    </form>
</body>
</html>
