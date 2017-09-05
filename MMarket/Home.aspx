<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="MMarket.Home" %>
<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>--%>

<%--Content2 je za SAMO ZA Slide Show --%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
            <div class="col-xs-12">

                <div id="imageCarousel" class="carousel slide" data-interval="2000"
                     data-ride="carousel" data-pause="hover" data-wrap="true">

                    <ol class="carousel-indicators">
                        <li data-target="#imageCarousel" data-slide-to="0" class="active"></li>
                        <li data-target="#imageCarousel" data-slide-to="1"></li>
                        <li data-target="#imageCarousel" data-slide-to="2"></li>
                        <li data-target="#imageCarousel" data-slide-to="3"></li>
                    </ol>

                    <div class="carousel-inner">
                        <div class="item active">
                            <div class="row">
                                <div class="col-xs-4" >
                                    <a href="Images/1.jpg"><img src="Images/1.jpg" class="img-responsive">
                                    <div class="carousel-caption">
                                        <h3>Desert</h3>
                                        <p>Desert Image Description</p>
                                    </div></a>
                                </div>
                                <div class="col-xs-4">
                                    <a href="Images/2.jpg"><img src="Images/2.jpg" class="img-responsive">
                                    <div class="carousel-caption">
                                        <h3>Jellyfish</h3>
                                        <p>Jellyfish Image Description</p>
                                    </div></a>
                                </div>
                                <div class="col-xs-4">
                                    <a href="Images/3.jpg"><img src="Images/3.jpg" class="img-responsive">
                                    <div class="carousel-caption">
                                        <h3>Penguins</h3>
                                        <p>Penguins Image Description</p>
                                    </div></a>
                                </div>
                            </div>
                        </div>
                        <div class="item">
                            <div class="row">
                                <div class="col-xs-4">
                                    <a href="Images/4.jpg"><img src="Images/4.jpg" class="img-responsive">
                                    <div class="carousel-caption">
                                        <h3>Lighthouse</h3>
                                        <p>Lighthouse Image Description</p>
                                    </div></a>
                                </div>
                                <div class="col-xs-4">
                                    <a href="Images/5.jpg"><img src="Images/5.jpg" class="img-responsive">
                                    <div class="carousel-caption">
                                        <h3>Hydrangeas</h3>
                                        <p>Hydrangeas Image Description</p>
                                    </div></a>
                                </div>
                                <div class="col-xs-4">
                                    <a href="Images/6.jpg"><img src="Images/6.jpg" class="img-responsive">
                                    <div class="carousel-caption">
                                        <h3>Koala</h3>
                                        <p>Koala Image Description</p>
                                    </div></a>
                                </div>
                            </div>
                        </div>

                        <div class="item">
                            <div class="row">
                                <div class="col-xs-4">
                                    <a href="Images/7.jpg"><img src="Images/7.jpg" class="img-responsive">
                                    <div class="carousel-caption">
                                        <h3>Tulips</h3>
                                        <p>Tulips Image Description</p>
                                    </div></a>
                                </div>
                                <div class="col-xs-4">
                                    <a href="Images/8.jpg"><img src="Images/8.jpg" class="img-responsive">
                                    <div class="carousel-caption">
                                        <h3>Chrysanthemum</h3>
                                        <p>Chrysanthemum Image Description</p>
                                    </div></a>
                                </div>
                                <div class="col-xs-4">
                                    <a href="Images/9.jpg"><img src="Images/9.jpg" class="img-responsive">
                                    <div class="carousel-caption">
                                        <h3>Stripes</h3>
                                        <p>Stripes Image Description</p>
                                    </div></a>
                                </div>
                            </div>
                        </div>

                        <div class="item">
                            <div class="row">
                                <div class="col-xs-4">
                                    <a href="Images/10.jpg"><img src="Images/10.jpg" class="img-responsive">
                                    <div class="carousel-caption">
                                        <h3>Lighthouse</h3>
                                        <p>Lighthouse Image Description</p>
                                    </div></a>
                                </div>
                                <div class="col-xs-4">
                                    <a href="Images/11.jpg"><img src="Images/11.jpg" class="img-responsive">
                                    <div class="carousel-caption">
                                        <h3>Hydrangeas</h3>
                                        <p>Hydrangeas Image Description</p>
                                    </div></a>
                                </div>
                                <div class="col-xs-4">
                                    <a href="Images/12.jpg"><img src="Images/12.jpg" class="img-responsive">
                                    <div class="carousel-caption">
                                        <h3>Koala</h3>
                                        <p>Koala Image Description</p>
                                    </div></a>
                                </div>
                            </div>
                        </div>
                    </div>

                    <a href="#imageCarousel" class="carousel-control left" data-slide="prev">
                        <span class="glyphicon glyphicon-chevron-left"></span>
                    </a>
                    <a href="#imageCarousel" class="carousel-control right" data-slide="next">
                        <span class="glyphicon glyphicon-chevron-right"></span>
                    </a>
                </div>

            </div>
        </div>
</asp:Content>

<%--Content3 je za sve ostalo--%>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="row">
        <div class="col-lg-6 col-md-8 col-sm-12">
    <div class="row" style="width:100%">
        <div class="col-lg-12">
            <h2>Proizvodi na AKCIJI</h2>
        </div>
        <div class="col-lg-3 col-md-4 col-sm-6">
            <a href="Images/1.jpg" class="thumbnail">
                <p>Chrysanthemum</p>
                <img src="Images/1.jpg" />
            </a>
        </div>
        <div class="col-lg-3 col-md-4 col-sm-6">
            <a href="Images/2.jpg" class="thumbnail">
                <p>Desert</p>
                <img src="Images/2.jpg" />
            </a>
        </div>
        <div class="col-lg-3 col-md-4 col-sm-6">
            <a href="Images/3.jpg" class="thumbnail">
                <p>Hydrangeas</p>
                <img src="Images/3.jpg" />
            </a>
        </div>
        <div class="col-lg-3 col-md-4 col-sm-6">
            <a href="Images/4.jpg" class="thumbnail">
                <p>Jellyfish</p>
                <img src="Images/4.jpg" />
            </a>
        </div>
        <div class="col-lg-3 col-md-4 col-sm-6">
            <a href="Images/5.jpg" class="thumbnail">
                <p>Koala</p>
                <img src="Images/5.jpg" />
            </a>
        </div>
        <div class="col-lg-3 col-md-4 col-sm-6">
            <a href="Images/6.jpg" class="thumbnail">
                <p>Lighthouse</p>
                <img src="Images/6.jpg" />
            </a>
        </div>
        <div class="col-lg-3 col-md-4 col-sm-6">
            <a href="Images/7.jpg" class="thumbnail">
                <p>Penguins</p>
                <img src="Images/7.jpg" />
            </a>
        </div>
        <div class="col-lg-3 col-md-4 col-sm-6">
            <a href="Images/8.jpg" class="thumbnail">
                <p>Tulips</p>
                <img src="Images/8.jpg" />
            </a>
        </div>
       </div></div>
        
        <div class="col-lg-6 col-md-8 col-sm-12">
            <div class="row">
        <div class="col-lg-12">

    <div>
        <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d2783.15947314275!2d15.93905251556764!3d45.76799417910569!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x4765d43ba34f8727%3A0xe97ed758c57f65b!2sMarita+Market!5e0!3m2!1shr!2shr!4v1504394070429" width="100%" height="400" frameborder="0" style="border:0" allowfullscreen></iframe>
     </div>

    </div>
    </div>
        </div>
    </div>
    <h1>Test</h1>
    <h1>Test</h1>
    <h1>Test</h1>
    <h1>Test</h1>
    <h1>Test</h1>
    <h1>Test</h1>
    <h1>Test</h1>
    <h1>Test</h1>
    <h1>Test</h1>
    <h1>Test</h1>
    <h1>Test</h1>
    <h1>Test</h1>
    <h1>Test</h1>
    <h1>Test</h1>
    <h1>Test</h1>
    <h1>Test</h1>
    <h1>Test</h1>
    <h1>Test</h1>
    <h1>Test</h1>
    <h1>Test</h1>
    <h1>Test</h1>
    <h1>Test</h1>
    <h1>Test</h1>
    <h1>Test</h1>
    <h1>Test</h1>
    <h1>Test</h1>
    <h1>Test</h1>
    <h1>Test</h1>
    <h1>Test</h1>
    <h1>Test</h1>
    <h1>Test</h1>
    <h1>Test</h1>
    <h1>Test</h1>
    <h1>Test</h1>
    <h1>Test</h1>
    <h1>Test</h1>
    <h1>Test</h1>
    <h1>Test</h1>
    <h1>Test</h1>
</asp:Content>