<%@ Page Title="Order History" Language="C#" MasterPageFile="~/map1.Master" CodeBehind="Order-History.aspx.cs" Inherits="WebFormsCommerceDemo.Protected.Order_History" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="Viewport" runat="server">
<div class="row">
<div class="col-sm-12">
    <asp:ListView ID="lvwCheckout"
                    ItemType="WebFormsCommerceDemo.Models.Order" 
                    runat="server"
                    SelectMethod="FetchOrderHistory">
    <ItemTemplate>
    <div class="panel panel-smart">
        <div class="panel-heading">
            <h4 class="panel-title left">Order# : <%#: Item.UniqueOrderNumber %></h4>
            <h4 class="panel-title right"><%#: Item.OrderDate.ToString("MMM dd, yyyy") %></h4>
            <div class="clearfix"></div>
        </div>
        <div class="panel-body">
            <div class="col-sm-6">
                <h5>Billing To</h5>
                <%#: Item.BillingAddress %>,<br />
                <%#: Item.BillingCity %>,<br />
                <%#: Item.BillingState %>,<br />
                <%#: Item.BillingZip %>.
            </div>
            <div class="col-sm-6">
                <h5>Shipping To</h5>
                <%#: Item.ShippingAddress %>,<br />
                <%#: Item.ShippingCity %>,<br />
                <%#: Item.ShippingState %>,<br />
                <%#: Item.ShippingZip %>.
            </div>
            <div class="col-sm-12">
                <p>&nbsp;</p>
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
                        <asp:ListView runat="server" ID="lstCartItems" DataSource="<%# Item.CartItems %>"
                            ItemType="WebFormsCommerceDemo.Models.CartItem">
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
                            <td colspan="2" class="text-right"><%#: string.Format("{0:C}", (Item.TotalSum-Item.TaxSum)) %></td>
                        </tr>
                        <tr>
                            <td colspan="3">Tax @ 10%</td>
                            <td colspan="2" class="text-right"><%#: string.Format("{0:C}", Item.TaxSum) %></td>
                        </tr>
                        <tr>
                            <th colspan="3">Total Payable</th>
                            <th colspan="2" class="text-right"><%#: string.Format("{0:C}", Item.TotalSum) %></th>
                        </tr>
                        <tr><td colspan="5">&nbsp;</td></tr>
                        <tr>
                            <td colspan="5" class="text-left">
                                <%#: Item.Notes %>
                            </td>
                        </tr>
                    </tfoot>
                </table>
            </div>
        </div>
    </div>
    </ItemTemplate>
    </asp:ListView>
</div>
</div>
</asp:Content>
