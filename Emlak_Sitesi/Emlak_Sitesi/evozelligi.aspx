<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="evozelligi.aspx.cs" Inherits="Emlak_Sitesi.evozelligi" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta charset="UTF-8">
    <meta name="description" content="">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <!-- The above 4 meta tags *must* come first in the head; any other head content must come *after* these tags -->

    <!-- Title  -->
    <title>POLAT EMLAK| Ev</title>

    <!-- Style CSS -->
    <link rel="stylesheet" href="style.css">
    <link href="css/kutuphane.css" rel="stylesheet" />
    <link href="css/animate.css" rel="stylesheet" />
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/classy-nav.min.css" rel="stylesheet" />
    <link href="css/font-awesome.min.css" rel="stylesheet" />
    <link href="css/jquery-ui.min.css" rel="stylesheet" />
    <link href="css/magnific-popup.css" rel="stylesheet" />
    <link href="css/nice-select.css" rel="stylesheet" />
    <link href="css/owl.carousel.css" rel="stylesheet" />
    <link href="css/themify-icons.css" rel="stylesheet" />



</head>
<body>
    <form id="form1" runat="server">

      <header class="header-area">
              <div class="main-header-area" id="stickyHeader">
              <div class="classy-nav-container breakpoint-off">
                  <nav class="classy-navbar justify-content-between" id="southNav">
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

                                <asp:LinkButton ID="giris" runat="server" OnClick="giris_Click">Giriş Yap</asp:LinkButton>
                                <asp:LinkButton ID="kayit" runat="server" OnClick="kayit_Click">Kayıt Ol</asp:LinkButton>
                             </div>

                         </div>
                  </nav>  
              </div>
       </div>
     </header>

     <section class="breadcumb-area bg-img" style="background-image: url(img/bg-img/hero3.jpg);">
        <div class="container h-100">
            <div class="row h-100 align-items-center">
                <div class="col-12">
                    <div class="breadcumb-content">
                        <h2 class="breadcumb-title">ÖZELLİKLER</h2>
                    </div>
                </div>
            </div>
        </div>
    </section>
      

        <div class="south-search-area">
          <div class="container">
              <div>
                   <div>
                        
                       </div>
                  </div>
              </div>
         </div>


          <section class="listings-content-wrapper section-padding-100">
               <div class="container">
                    <div class="row">
                        <div class="col-12">
                             <%Response.Write(resimler); %>
                         </div>
                  </div>

                  <div class="row justify-content-center">
                       <div class="col-12 col-lg-8">
                           <%Response.Write(evler); %>
                        </div>
                  </div>

                    <div class="col-12 col-md-6 col-lg-4">
                        <div class="contact-realtor-wrapper">
                             <div class="realtor-info">
                                  <img src="img/bg-img/recep_polat.jpg" alt="">
                                    <div class="realtor---info">
                                        <h2>Recep Polat</h2>
                                        <p>Gayrimenkul Danışmanı</p>
                                         <h6><img src="img/icons/phone-call.png" alt=""> +90 534 215 8920</h6>
                                         <h6><img src="img/icons/envelope.png" alt=""> receppolat95@gmail.com</h6>
                                   </div>
                                  <div class="realtor--contact-form">
                                       <div class="form-group">

                                       </div>

                                  </div>
                             </div>
                        </div>
                    </div>
               </div>
              
          </section>

          <footer class="footer-area section-padding-100-0 bg-img gradient-background-overlay" style="background-image: url(img/bg-img/cta.jpg);">
      
        <div class="main-footer-area">
            <div class="container">
                <div class="row">

                    <div class="col-12 col-sm-6 col-xl-3">
                        <div class="footer-widget-area mb-100">
                            <div class="widget-title">
                                <h6>Hakkımzda</h6>
                            </div>

                            <img src="img/bg-img/footer.jpg" alt="">
                            <div class="footer-logo my-4">
                                <img src="img/core-img/logo.png" alt="">
                            </div>
                            <p>POLAT EMLAK 1980'den beri İstanbul'un Beyoğlu ilçesinde bütün herkesi uygun fiyattan ev sahibi yapmaya çalışan bir kuruluştur. Siz de mi eve çıkmayı düşünüyorsunuz hemen biziarayın</p>
                        </div>
                    </div>

             
                    <div class="col-12 col-sm-6 col-xl-3">
                        <div class="footer-widget-area mb-100">
                            
                            <div class="widget-title">
                                <h6>Çalışma Saatleri</h6>
                            </div>
                            <div class="weekly-office-hours">
                                <ul>
                                    <li class="d-flex align-items-center justify-content-between"><span>Pazartesi-Cuma</span> <span>09.00 - 19.00 </span></li>
                                    <li class="d-flex align-items-center justify-content-between"><span>Cumartesi</span> <span>09.00 - 13.00</span></li>
                                    <li class="d-flex align-items-center justify-content-between"><span>Pazar</span> <span>Kapalı</span></li>
                                </ul>
                            </div>
                          
                            <div class="address">
                                <h6> +90 534 215 89 20</h6>
                                <h6> info@polatemlak.com</h6>
                                <h6>Zincirli Kuyu Caddesi, Kasımpaşa Mahallesi No: 4, 34440, Beyoğlu, İstanbul</h6>
                            </div>
                        </div>
                    </div>

              
                    <div class="col-12 col-sm-6 col-xl-3">
                        <div class="footer-widget-area mb-100">
                       
                            <div class="widget-title">
                                <h6>Sayfalar</h6>
                            </div>
                           
                            <%Response.Write(altmenu); %>
                        </div>
                    </div>

                   
                    <div class="col-12 col-sm-6 col-xl-3">
                        <div class="footer-widget-area mb-100">
                           
                            <div class="widget-title">
                                <h6>Evler</h6>
                            </div>
                            
                            <div class="featured-properties-slides owl-carousel">
                               <%Response.Write(altevler); %>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </footer>

        
<!-- jQuery (Necessary for All JavaScript Plugins) -->
    <script src="js/jquery/jquery-2.2.4.min.js"></script>
    <!-- Popper js -->
    <script src="js/popper.min.js"></script>
    <!-- Bootstrap js -->
    <script src="js/bootstrap.min.js"></script>
    <!-- Plugins js -->
    <script src="js/plugins.js"></script>
    <script src="js/classy-nav.min.js"></script>
    <script src="js/jquery-ui.min.js"></script>
    <!-- Active js -->
    <script src="js/active.js"></script>



    </form>
</body>
</html>
