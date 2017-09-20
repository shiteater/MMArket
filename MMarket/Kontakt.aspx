
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
                                       <label for="form_name">Ime *</label>
                                        <asp:TextBox ID="TbxName" runat="server" class="form-control" placeholder="Molimo unesite svoje ime *"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RfvName" runat="server" ErrorMessage="Molimo unesite svoje ime *" ValidationGroup="1" ControlToValidate="TbxName"></asp:RequiredFieldValidator>
                                        <%--<input id="form_name" type="text" name="name" class="form-control" placeholder="Please enter your firstname *" required="required" data-error="Firstname is required.">--%>
                                        <div class="help-block with-errors"></div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="form_lastname">Prezime *</label>
                                        <asp:TextBox ID="TbxLastName" runat="server" class="form-control" placeholder="Molimo unesite svoje prezime *"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RfvLastName" runat="server" ErrorMessage="Molimo unesite svoje prezime *" ControlToValidate="TbxLastName" ValidationGroup="1"></asp:RequiredFieldValidator>
                                        <%--                                        <input id="form_lastname" type="text" name="surname" class="form-control" placeholder="Please enter your lastname *" required="required" data-error="Lastname is required.">--%>
                                        <div class="help-block with-errors"></div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="form_email">Email *</label><asp:TextBox ID="TbxMail" runat="server" class="form-control" placeholder="Molimo unesite svoj email *"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RfvMail" runat="server" ErrorMessage="Molimo unesite svoj email *" ControlToValidate="TbxMail" ValidationGroup="1"></asp:RequiredFieldValidator>
                                        <%--<input id="form_email" type="email" name="email" class="form-control" placeholder="Please enter your email *" required="required" data-error="Valid email is required.">--%>
                                        <div class="help-block with-errors"></div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="form_phone">Telefon*</label><asp:TextBox ID="TbxPhone" runat="server" class="form-control" placeholder="Molimo unesite svoj broj telefona*"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RfvPhone" runat="server" ErrorMessage="Molimo unesite svoj broj telefona*" ControlToValidate="TbxPhone" ValidationGroup="1"></asp:RequiredFieldValidator>  
                                        <%-- <input id="form_phone" type="tel" name="phone"  class="form-control" placeholder="Please enter your phone*" required oninvalid="setCustomValidity('Plz enter your correct phone number ')"
    onchange="try{setCustomValidity('')}catch(e){}">--%>
                                        
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <label for="form_message">Poruka *</label>
                                        <asp:TextBox ID="textarea1" runat="server"  class="form-control" placeholder="Poruka: *" rows="4"/>
                                        <asp:RequiredFieldValidator ID="RfvPoruka" runat="server" ErrorMessage="Please,leave us a message." ValidationGroup="1" ControlToValidate="textarea1"></asp:RequiredFieldValidator>
                                        <%--                                        <textarea id="form_message" name="message" class="form-control" placeholder="Message for me *" rows="4" required="required" data-error="Please,leave us a message."></textarea>--%>
                                        <div class="help-block with-errors"></div>
                                    </div>
                                </div>
                                <div class="col-md-12">
                                    <asp:Button ID="Button1" runat="server" class="btn btn-black" Text="Pošalji" OnClick="Button1_Click1" ValidationGroup="1" />
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
                   <%--                   <iframe width="100%" height="230" frameborder="0" style="border-radius:0px;" scrolling="no" marginheight="0" marginwidth="0" src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d2783.15947314275!2d15.93905251556764!3d45.76799417910569!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x4765d43ba34f8727%3A0xe97ed758c57f65b!2sMarita+Market!5e0!3m2!1shr!2shr!4v1504394070429"></iframe>--%>
                   <div class="row col1">
                       <div class="col-xs-4">
                           <i class="fa fa-map-marker" style="font-size:16px;"></i>   Address
                       </div>
                       <div class="col-xs-8">
                            <a href="https://goo.gl/maps/PSfpxqr94422">Jaruščica 9a, Zagreb, Croatia</a>
                       </div>
                   </div>
                    <div class="row col1">
                        <div class="col-sm-4">
                            <i class="fa fa-phone"></i>   Phone
                        </div>
                        <div class="col-sm-8">
                             <a href="tel:+385912202044">+(385) 91 2202044</a>
                        </div>
                    </div>
                    <div class="row col1">
                        <div class="col-sm-4">
                            <i class="fa fa-envelope"></i>   Email
                        </div>
                        <div class="col-sm-8">
                             <a href="mailto:info@al-pasha.eu">info@al-pasha.eu</a> <br> 
                        </div>
                    </div>
               </div>
           </div>
          </div>
       </div>
   </div>

</asp:Content>
