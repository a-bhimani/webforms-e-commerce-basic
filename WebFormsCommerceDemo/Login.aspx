<%@ Page Title="Login / Register" Language="C#" MasterPageFile="~/map1.Master" CodeBehind="Login.aspx.cs" Inherits="WebFormsCommerceDemo.Login" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="Viewport" runat="server">
<!-- Breadcrumb Starts -->
<ol class="breadcrumb">
    <li><a href="/">Home</a></li>
    <li class="active"><%=Page.Title %></li>
</ol>
<!-- Breadcrumb Ends -->
<!-- Login Form Section Starts -->
<div class="row">
    <div runat="server" id="vwLoginMessage" visible="false" class="alert alert-danger red">You must be logged in before you can add an item to the cart.</div>
    <div runat="server" id="vwLogoutMessage" visible="false" class="alert alert-info">You have successfully logged out.</div>
    <div class="col-sm-6">
        <!-- Login Panel Starts -->
        <div class="panel panel-smart">
            <div class="panel-heading">
                <h3 class="panel-title">Login</h3>
            </div>
            <div class="panel-body">
                <!-- Login Form Starts -->
                <div class="form-group">
                    <asp:Label style="display:block;" runat="server" ID="lblLoginError" CssClass="alert alert-warning control-label red bold" Visible="false">Incorrect Username or Password.</asp:Label>
                    <div id="LoginValidationError" class="alert alert-danger control-label bold hide-n">Please correct all the fields highlighted in red:</div>
                </div>
                <div class="form-group">
                    <label class="col-sm-3 control-label" for="txtUsername">Username</label>
                    <asp:TextBox runat="server" MaxLength="120" ClientIDMode="Static"  ID="txtUsername" CssClass="form-control" placeholder="Username"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label class="col-sm-3 control-label" for="txtPassword">Password</label>
                    <asp:TextBox runat="server" MaxLength="30" ClientIDMode="Static" TextMode="Password" ID="txtPassword" CssClass="form-control" placeholder="Password"></asp:TextBox>
                </div>
                <asp:Button runat="server" ClientIDMode="Static" ID="btnLogin" CssClass="btn btn-black" OnClick="btnLogin_Click" Text="Login" />
                <!-- Login Form Ends -->
            </div>
        </div>
        <!-- Login Panel Ends -->
    </div>
    <div class="col-sm-6">
        <!-- Account Panel Starts -->
        <div class="panel panel-smart">
            <div class="panel-heading">
                <h3 class="panel-title">Register</h3>
            </div>
            <div class="panel-body">
                <!-- Registration Form Starts -->
                <!-- Personal Information Starts -->
                <div class="form-group">
                    <asp:Label style="display:block;" runat="server" ID="lblRegistrationSummary" CssClass="alert alert-warning control-label red bold" Visible="false">There was an error saving your details into the system.</asp:Label>
                    <div id="RegisterValidationError" class="alert alert-danger control-label bold hide-n">Please correct all the fields highlighted in red:</div>
                </div>
                <div class="form-group">
                    <label for="txtRegisterFirstName" class="col-sm-3 control-label">First Name :</label>
                    <asp:TextBox runat="server" MaxLength="30" ClientIDMode="Static" ID="txtRegisterFirstName" CssClass="form-control" placeholder="First Name"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="txtRegisterLastName" class="col-sm-3 control-label">Last Name :</label>
                    <asp:TextBox runat="server" MaxLength="30" ClientIDMode="Static" ID="txtRegisterLastName" CssClass="form-control" placeholder="Last Name"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="txtRegisterUsername" class="col-sm-3 control-label">Email :</label>
                    <asp:TextBox runat="server" MaxLength="120" ClientIDMode="Static" ID="txtRegisterUsername" data-show-id="RegisterUsername" CssClass="form-control" placeholder="Email Address"></asp:TextBox>
                    <span id="spnRegisterUsername" class="red hide-n">Will be used as the Username.</span>
                </div>
                <div class="form-group">
                    <label for="txtRegisterPhone" class="col-sm-3 control-label">Phone :</label>
                    <asp:TextBox runat="server" MaxLength="10" ClientIDMode="Static" ID="txtRegisterPhone" data-show-id="RegisterPhone" CssClass="form-control" placeholder="Phone"></asp:TextBox>
                    <span id="spnRegisterPhone" class="red hide-n">Enter only numbers.</span>
                </div>
                <!-- Personal Information Ends -->
                <!-- Password Area Starts -->
                <div class="form-group">
                    <label for="txtRegisterPassword" class="col-sm-3 control-label">Password :</label>
                    <asp:TextBox runat="server" MaxLength="30" ClientIDMode="Static" TextMode="Password" ID="txtRegisterPassword" data-show-id="RegisterPassword" CssClass="form-control" placeholder="Password"></asp:TextBox>
                    <span id="spnRegisterPassword" class="red hide-n">Must be atleast 8 characters in length.</span>
                </div>
                <div class="form-group">
                    <label for="txtRegisterConfirmPassword" class="col-sm-3 control-label">Confirm Password :</label>
                    <asp:TextBox runat="server" MaxLength="30" ClientIDMode="Static" TextMode="Password" ID="txtRegisterConfirmPassword" CssClass="form-control" placeholder="Confirm Password"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Button runat="server" ClientIDMode="Static" ID="btnRegister" CssClass="btn btn-black" OnClick="btnRegister_Click" Text="Register" />
                </div>
                <!-- Password Area Ends -->
                <!-- Registration Form Ends -->
            </div>
        </div>
        <!-- Account Panel Ends -->
    </div>
</div>
<!-- Login Form Section Ends -->
</asp:Content>

<asp:Content ID="PostContent" ContentPlaceHolderID="PostScripts" runat="server">
<script type="text/javascript">
$(document).ready(function(){
    var exprEmail=/\S+@\S+\.\S+/;

    $('#txtUsername').focus();

    $('#txtRegisterUsername, #txtRegisterPhone, #txtRegisterPassword').keyup(function(){
        var that=$(this);
        setTimeout(function(){
            $('#spn'+ that.attr('data-show-id')).show(0);
        }, 800);
    });

    $('input#btnLogin').click(function(e){
        var t=true;
        var firstFocus=null;

        $('div#LoginValidationError').hide(0);
        
        thisEl=$('#txtUsername');
        thisEl.removeClass("redline");
        if(!(exprEmail.test(thisEl.val()))){
            thisEl.addClass("redline");
            if(firstFocus==null) firstFocus=thisEl;
            t=false;
        }

        thisEl=$('#txtPassword');
        thisEl.removeClass("redline");
        if(thisEl.val().length<8){
            thisEl.addClass("redline");
            if(firstFocus==null) firstFocus=thisEl;
            t=false;
        }

        if(!t){
            $('div#LoginValidationError').show(0);
            firstFocus.focus();
            e.preventDefault();
        }
        return t;
    });

    $('input#btnRegister').click(function(e){
        var t=true;
        var firstFocus=null;

        $('div#RegisterValidationError').hide(0);

        var thisEl=$('#txtRegisterFirstName');
        thisEl.removeClass("redline");
        if(thisEl.val().length<3){
            thisEl.addClass("redline");
            if(firstFocus==null) firstFocus=thisEl;
            t=false;
        }
        
        thisEl=$('#txtRegisterLastName');
        thisEl.removeClass("redline");
        if(thisEl.val().length<3){
            thisEl.addClass("redline");
            if(firstFocus==null) firstFocus=thisEl;
            t=false;
        }
        
        thisEl=$('#txtRegisterUsername');
        thisEl.removeClass("redline");
        if(!(exprEmail.test(thisEl.val()))){
            thisEl.addClass("redline");
            if(firstFocus==null) firstFocus=thisEl;
            t=false;
        }

        thisEl=$('#txtRegisterPhone');
        thisEl.removeClass("redline");
        if((thisEl.val()<1000000000) || (thisEl.val()>9999999999)){
            thisEl.addClass("redline");
            if(firstFocus==null) firstFocus=thisEl;
            t=false;
        }

        thisEl=$('#txtRegisterPassword');
        thisEl.removeClass("redline");
        if(thisEl.val().length<8){
            thisEl.addClass("redline");
            if(firstFocus==null) firstFocus=thisEl;
            t=false;
        }

        thisEl=$('#txtRegisterConfirmPassword');
        thisEl.removeClass("redline");
        if((thisEl.val().length<8) || (thisEl.val()!==$('#txtRegisterPassword').val())){
            thisEl.addClass("redline");
            if(firstFocus==null) firstFocus=thisEl;
            t=false;
        }

        if(!t){
            $('div#RegisterValidationError').show(0);
            firstFocus.focus();
            e.preventDefault();
        }
        return t;
    });
});
</script>
</asp:Content>

