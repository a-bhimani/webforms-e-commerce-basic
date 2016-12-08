<%@ Page Title="My Account" MasterPageFile="~/Protected/protected1.Master" CodeBehind="Account.aspx.cs" Inherits="WebFormsCommerceDemo.Protected.Account" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">
<!-- Manage Form Section Starts -->
<div class="row">
    <div class="col-sm-6">
        <!-- Manage Panel Starts -->
        <div class="panel panel-smart">
            <div class="panel-heading">
                <h3 class="panel-title">Manage</h3>
            </div>
            <div class="panel-body">
                <!-- Manage Form Starts -->
                <!-- Manage Starts -->
                <div class="form-group">
                    <asp:Label style="display:block;" runat="server" ID="lblUpdateSummary" CssClass="alert alert-warning control-label red bold" Visible="false">There was an error saving your details into the system.</asp:Label>
                    <div id="UpdateValidationError" class="alert alert-danger control-label bold hide-n">Please correct all the fields highlighted in red:</div>
                </div>
                <div class="form-group">
                    <label for="txtMFirstName" class="col-sm-3 control-label">First Name :</label>
                    <asp:TextBox runat="server" MaxLength="30" ClientIDMode="Static" ID="txtMFirstName" CssClass="form-control" placeholder="First Name"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="txtMLastName" class="col-sm-3 control-label">Last Name :</label>
                    <asp:TextBox runat="server" MaxLength="30" ClientIDMode="Static" ID="txtMLastName" CssClass="form-control" placeholder="Last Name"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="txtMEmailAddress" class="col-sm-3 control-label">Email :</label>
                    <asp:TextBox runat="server" ReadOnly="true" ClientIDMode="Static" ID="txtMEmailAddress" CssClass="form-control" placeholder="Email Address"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="txtMPhone" class="col-sm-3 control-label">Phone :</label>
                    <asp:TextBox runat="server" MaxLength="10" ReadOnly="true" ClientIDMode="Static" ID="txtMPhone" CssClass="form-control" placeholder="Phone"></asp:TextBox>
                </div>
                <div class="form-group">
                    <hr />
                    <h5>Billing</h5>
                </div>
                <div class="form-group">
                    <label for="txtMBillingAddress" class="col-sm-3 control-label">Address :</label>
                    <asp:TextBox runat="server" MaxLength="180" ClientIDMode="Static" ID="txtMBillingAddress" CssClass="form-control" placeholder="Address"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="txtMBillingCity" class="col-sm-3 control-label">City :</label>
                    <asp:TextBox runat="server" MaxLength="60" ClientIDMode="Static" ID="txtMBillingCity" CssClass="form-control" placeholder="City"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="txtMBillingState" class="col-sm-3 control-label">State :</label>
                    <asp:TextBox runat="server" MaxLength="60" ClientIDMode="Static" ID="txtMBillingState" CssClass="form-control" placeholder="State"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="txtMBillingZip" class="col-sm-3 control-label">Zip :</label>
                    <asp:TextBox runat="server" MaxLength="5" ClientIDMode="Static" ID="txtMBillingZip" data-show-id="MBillingZip" CssClass="form-control" placeholder="Zip"></asp:TextBox>
                    <span id="spnMBillingZip" class="red hide-n">Enter only numbers.</span>
                </div>
                <div class="form-group">
                    <hr />
                    <h5>Shipping</h5>
                </div>
                <div class="form-group">
                    <label for="chkMShippingIsSame" class="col-sm-3 control-label">Same as Billing :</label>
                    <asp:CheckBox runat="server" ClientIDMode="Static" ID="chkMShippingIsSame" CssClass="" />
                </div>
                <div class="form-group shipping">
                    <label for="txtMShippingAddress" class="col-sm-3 control-label">Address :</label>
                    <asp:TextBox runat="server" MaxLength="180" ClientIDMode="Static" ID="txtMShippingAddress" CssClass="form-control" placeholder="Address"></asp:TextBox>
                </div>
                <div class="form-group shipping">
                    <label for="txtMShippingCity" class="col-sm-3 control-label">City :</label>
                    <asp:TextBox runat="server" MaxLength="60" ClientIDMode="Static" ID="txtMShippingCity" CssClass="form-control" placeholder="City"></asp:TextBox>
                </div>
                <div class="form-group shipping">
                    <label for="txtMShippingState" class="col-sm-3 control-label">State :</label>
                    <asp:TextBox runat="server" MaxLength="60" ClientIDMode="Static" ID="txtMShippingState" CssClass="form-control" placeholder="State"></asp:TextBox>
                </div>
                <div class="form-group shipping">
                    <label for="txtMShippingZip" class="col-sm-3 control-label">Zip :</label>
                    <asp:TextBox runat="server" MaxLength="5" ClientIDMode="Static" ID="txtMShippingZip" data-show-id="MShippingZip" CssClass="form-control" placeholder="Zip"></asp:TextBox>
                    <span id="spnMShippingZip" class="red hide-n">Enter only numbers.</span>
                </div>
                <!-- Manage Ends -->
                <div class="form-group">
                    <asp:Button runat="server" ClientIDMode="Static" ID="btnUpdate" CssClass="btn btn-black" OnClick="btnUpdate_Click" Text="Update" />
                </div>
                <!-- Password Area Ends -->
                <!-- Manage Form Ends -->
            </div>
        </div>
        <!-- Manage Panel Ends -->
    </div>
</div>
<!-- Manage Form Section Ends -->
</asp:Content>

<asp:Content ID="PostScripts" ContentPlaceHolderID="PostScripts" runat="server">
<script type="text/javascript">
$(document).ready(function(){
    var exprEmail=/\S+@\S+\.\S+/;

    $('#txtMBillingZip, #txtMShippingZip').keyup(function(){
        var that=$(this);
        setTimeout(function(){
            $('#spn'+ that.attr('data-show-id')).show(0);
        }, 800);
    });

    $('input#chkMShippingIsSame').change(function(){
        $('.shipping').show(0);
        if($(this).is(":checked")){
            $('.shipping').hide(0);
        }
    });

    $('input#btnUpdate').click(function(e){
        var t=true;
        var firstFocus=null;

        $('div#UpdateValidationError').hide(0);

        var thisEl=$('#txtMFirstName');
        thisEl.removeClass("redline");
        if(thisEl.val().length<3){
            thisEl.addClass("redline");
            if(firstFocus==null) firstFocus=thisEl;
            t=false;
        }
        
        thisEl=$('#txtMLastName');
        thisEl.removeClass("redline");
        if(thisEl.val().length<3){
            thisEl.addClass("redline");
            if(firstFocus==null) firstFocus=thisEl;
            t=false;
        }

        thisEl=$('#txtMBillingZip');
        thisEl.removeClass("redline");
        if(thisEl.val().length>0){
            var b=false;
            try{
                var Zip=parseInt(thisEl.val(), 10);
                if((thisEl.val().length<5) || isNaN(Zip) || (Zip<10000) || (Zip>99999)){
                    b=true;
                }
            }catch(ex){
                b=true;
            }
            if(b){
                thisEl.addClass("redline");
                if(firstFocus==null) firstFocus=thisEl;
                t=false;  
            }
        }

        thisEl=$('#txtMShippingZip');
        thisEl.removeClass("redline");
        if(thisEl.val().length>0){
            var b=false;
            try{
                var Zip=parseInt(thisEl.val(), 10);
                if((thisEl.val().length<5) || isNaN(Zip) || (Zip<10000) || (Zip>99999)){
                    b=true;
                }
            }catch(ex){
                b=true;
            }
            if(b){
                thisEl.addClass("redline");
                if(firstFocus==null) firstFocus=thisEl;
                t=false;  
            }
        }

        if(!t){
            $('div#UpdateValidationError').show(0);
            firstFocus.focus();
            e.preventDefault();
        }
        return t;
    });
});
</script>
</asp:Content>

