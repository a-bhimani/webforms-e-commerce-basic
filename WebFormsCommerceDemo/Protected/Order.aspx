<%@ Page Title="Order" Language="C#" MasterPageFile="~/Protected/protected1.Master" CodeBehind="Order.aspx.cs" Inherits="WebFormsCommerceDemo.Protected.OrderWf" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">
<!-- Order Section Starts -->
<div class="row">
    <asp:Label style="display:block;" runat="server" ID="lblOrderSummary" CssClass="col-sm-12 alert alert-warning control-label red bold" Visible="false">There was an error completing the order.</asp:Label>
</div>
<div runat="server" id="pnlOrder" class="row" >
    <div class="col-sm-6">
        <div class="panel panel-smart">
            <div class="panel-heading">
                <h3 class="panel-title">Order Summary</h3>
            </div>
            <div class="panel-body">
                <table class="table table-condensed">
                    <thead>
                        <tr>
                        <th>&nbsp;</th>
                        <th>Product</th>
                        <th>Quantity</th>
                        <th>Price</th>
                        <th>Total</th>
                        </tr>
                    </thead>
                    <tbody>
                    <asp:ListView ID="lvwCheckout"
                        ItemType="WebFormsCommerceDemo.Models.CartItem" 
                        runat="server"
                        visible="true"
                        SelectMethod="FetchCartItems">
                        <ItemTemplate>
                            <tr>
                                <th class="text-left"><%#: Container.DisplayIndex+1 %></th>
                                <td class="text-left"><a href="/Product/?product_id=<%#: Item.ProductID %>"><%# Item.Product.Name %></a></td>
                                <td class="text-center cart-text">x <%#: Item.Quantity %></td>
                                <td class="text-right cart-text"><%#: string.Format("{0:C}", Item.ItemPrice / Item.Quantity) %></td>
                                <td class="text-right cart-text"><%#: string.Format("{0:C}", Item.ItemPrice) %></td>
                            </tr>
                        </ItemTemplate>
                    </asp:ListView>
                    </tbody>
                    <tfoot>
                        <tr>
                            <td colspan="3">Total</td>
                            <td colspan="2" class="text-right"><%=string.Format("{0:C}", TotalAmount) %></td>
                        </tr>
                        <tr>
                            <td colspan="3">Tax @ 10%</td>
                            <td colspan="2" class="text-right"><%=string.Format("{0:C}", TotalTax) %></td>
                        </tr>
                        <tr>
                            <th colspan="3">Total Payable</th>
                            <th colspan="2" class="text-right"><%=string.Format("{0:C}", TotalOrderAmount) %></th>
                        </tr>
                        <tr><td colspan="5">&nbsp;</td></tr>
                        <tr>
                            <td colspan="2">Comments</td>
                            <td colspan="3" class="text-right">
                                <asp:TextBox runat="server" ID="txtNotes" TextMode="MultiLine" MaxLength="255"></asp:TextBox>
                            </td>
                        </tr>
                    </tfoot>
                </table>
            </div>
        </div>
    </div>
    <div class="col-sm-6">
        <!-- Manage Panel Starts -->
        <div class="panel panel-smart">
            <div class="panel-heading">
                <h3 class="panel-title">Order</h3>
            </div>
            <div class="panel-body">
                <!-- Manage Form Starts -->
                <!-- Manage Starts -->
                <div class="form-group">
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
                    <asp:Button runat="server" ClientIDMode="Static" ID="btnOrder" CssClass="btn btn-success right" OnClick="btnOrder_Click" Text="Order" />
                </div>
                <!-- Password Area Ends -->
                <!-- Manage Form Ends -->
            </div>
        </div>
        <!-- Manage Panel Ends -->
    </div>
</div>
<!-- Order Section Ends -->
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

    $('input#btnOrder').click(function(e){
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

        thisEl=$('#txtMBillingAddress');
        thisEl.removeClass("redline");
        if(thisEl.val().length<3){
            thisEl.addClass("redline");
            if(firstFocus==null) firstFocus=thisEl;
            t=false;
        }

        thisEl=$('#txtMBillingCity');
        thisEl.removeClass("redline");
        if(thisEl.val().length<3){
            thisEl.addClass("redline");
            if(firstFocus==null) firstFocus=thisEl;
            t=false;
        }

        thisEl=$('#txtMBillingState');
        thisEl.removeClass("redline");
        if(thisEl.val().length<2){
            thisEl.addClass("redline");
            if(firstFocus==null) firstFocus=thisEl;
            t=false;
        }

        thisEl=$('#txtMBillingZip');
        thisEl.removeClass("redline");
        if(true){
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

        if(!($('#chkMShippingIsSame').is(':checked'))){
            thisEl=$('#txtMShippingAddress');
            thisEl.removeClass("redline");
            if(thisEl.val().length<3){
                thisEl.addClass("redline");
                if(firstFocus==null) firstFocus=thisEl;
                t=false;
            }

            thisEl=$('#txtMShippingCity');
            thisEl.removeClass("redline");
            if(thisEl.val().length<3){
                thisEl.addClass("redline");
                if(firstFocus==null) firstFocus=thisEl;
                t=false;
            }

            thisEl=$('#txtMShippingState');
            thisEl.removeClass("redline");
            if(thisEl.val().length<2){
                thisEl.addClass("redline");
                if(firstFocus==null) firstFocus=thisEl;
                t=false;
            }

            thisEl=$('#txtMShippingZip');
            thisEl.removeClass("redline");
            if(true){
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
        }else{
            $('#txtMShippingAddress, #txtMShippingCity, #txtMShippingState, #txtMShippingZip')
                .val(null)
                .removeClass('redline');
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

