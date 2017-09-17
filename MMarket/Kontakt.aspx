<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="Kontakt.aspx.cs" Inherits="MMarket.Kontakt" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d2783.15947314275!2d15.93905251556764!3d45.76799417910569!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x4765d43ba34f8727%3A0xe97ed758c57f65b!2sMarita+Market!5e0!3m2!1shr!2shr!4v1504394070429" width="100%" height="400" frameborder="0" style="border:0" allowfullscreen></iframe>
</asp:Content>

<%--Upisuje se sve Samo u Content 3--%>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="contact-us">
       <div class="container">
          <div class="contact-form">
           <div class="row">
               <div class="col-sm-7">                  
                    <div id="ajax-contact"  method="post" action="contact-form-mail.php" role="form">
                        <div class="messages" id="form-messages"></div>
                        <div class="controls">
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="form_name">Firstname *</label>
                                        <input id="form_name" type="text" name="name" class="form-control" placeholder="Please enter your firstname *" required="required" data-error="Firstname is required.">
                                        <div class="help-block with-errors"></div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="form_lastname">Lastname *</label>
                                        <input id="form_lastname" type="text" name="surname" class="form-control" placeholder="Please enter your lastname *" required="required" data-error="Lastname is required.">
                                        <div class="help-block with-errors"></div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="form_email">Email *</label>
                                        <input id="form_email" type="email" name="email" class="form-control" placeholder="Please enter your email *" required="required" data-error="Valid email is required.">
                                        <div class="help-block with-errors"></div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="form_phone">Phone*</label>
                                        <input id="form_phone" type="tel" name="phone"  class="form-control" placeholder="Please enter your phone*" required oninvalid="setCustomValidity('Plz enter your correct phone number ')"
    onchange="try{setCustomValidity('')}catch(e){}">
                                        
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <label for="form_message">Message *</label>
                                        <asp:TextBox ID="textarea1" runat="server"  class="form-control" placeholder="Message from me*" rows="4" required="required" data-error="Please,leave us a message."/>
<%--                                        <textarea id="form_message" name="message" class="form-control" placeholder="Message for me *" rows="4" required="required" data-error="Please,leave us a message."></textarea>--%>
                                        <div class="help-block with-errors"></div>
                                    </div>
                                </div>
                                <div class="col-md-12">
                                    <asp:Button ID="Button1" runat="server" class="btn btn-black" Text="Send message" OnClick="Button1_Click1" />
                                    <%--<input type="submit" class="btn btn-black" value="Send message">--%>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                   <br>
                                    <small class="text-muted"><strong>*</strong> These fields are required.</small>
                                </div>
                            </div>
                        </div>

                    </div>
    
               </div>
               <div class="col-sm-5">
                   <div class="row col1">
                       <div class="col-xs-3">
                           <i class="fa fa-map-marker" style="font-size:16px;"></i>   Address
                       </div>
                       <div class="col-xs-9">
                            One Gateway Center, Suite 25500+,<br> Newark 23, NJ 10235
                       </div>
                   </div>
                   
                    <div class="row col1">
                        <div class="col-sm-3">
                            <i class="fa fa-phone"></i>   Phone
                        </div>
                        <div class="col-sm-9">
                             +(91) 123 277 4239
                        </div>
                    </div>
                    <div class="row col1">
                        <div class="col-sm-3">
                             <i class="fa fa-fax"></i>    Fax  
                        </div>
                        <div class="col-sm-9">
                              123 123 4567
                        </div>
                    </div>
                    <div class="row col1">
                        <div class="col-sm-3">
                            <i class="fa fa-envelope"></i>   Email
                        </div>
                        <div class="col-sm-9">
                             <a href="mailto:info@yourdomain.com">info@yourdomain.com</a> <br> <a href="mailto:support@yourdomain.com">support@yourdomain.com</a>
                        </div>
                    </div><br>
                    <iframe width="100%" height="230" frameborder="0" style="border-radius:0px;" scrolling="no" marginheight="0" marginwidth="0" src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d2783.15947314275!2d15.93905251556764!3d45.76799417910569!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x4765d43ba34f8727%3A0xe97ed758c57f65b!2sMarita+Market!5e0!3m2!1shr!2shr!4v1504394070429"></iframe>
               </div>
           </div>
           
          </div>
       </div>
   </div>

</asp:Content>
