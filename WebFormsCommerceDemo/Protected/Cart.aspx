<%@ Page Title="Cart" Language="C#" MasterPageFile="~/Protected/protected1.Master" CodeBehind="Cart.aspx.cs" Inherits="WebFormsCommerceDemo.Protected.Cart" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">
<!-- Shopping Cart Table Starts -->
<div runat="server" id="vwNoItems" class="alert alert-danger">There are no items in your cart. <a href="/">Click here</a> to look for products and add them to your cart.</div>
<table class="table table-condensed">
    <thead runat="server" id="thCheckout" visible="false">
        <tr>
            <td class="text-center">&nbsp;</td>
            <td class="text-left">Product</td>
            <td class="text-center">Quantity</td>
            <td class="text-right">Price</td>
            <td class="text-right">Total</td>
            <td class="text-center">&nbsp;</td>
        </tr>
    </thead>
    <tbody>
    <asp:ListView ID="lvwCheckout"
        OnItemDataBound="lvwCheckout_RowBound"
        ItemType="WebFormsCommerceDemo.Models.CartItem" 
        runat="server"
        visible="false"
        SelectMethod="FetchCartItems">
        <ItemTemplate>
            <tr>
                <td class="text-center">
                    <a href="/Product/?product_id=<%#: Item.ProductID %>">
                        <img src="<%# Item.Product.ImagePath %>" alt="<%#: Item.Product.Name %>" title="<%#: Item.Product.Name %>" class="img-thumbnail" />
                    </a>
                </td>
                <td class="text-left">
                    <a href="/Product/?product_id=<%#: Item.ProductID %>"><%# Item.Product.Name %></a>
                    <br />
                    <p class="small">
                    <%# (Item.Product.Description.Length > 80)?
                                    Item.Product.Description.Substring(0, (int) Math.Floor(Item.Product.Description.Length * 0.5)).Trim() +"...":
                                    Item.Product.Description %>
                    </p>
                </td>
                <td class="text-center cart-text">
                    <div class="input-group btn-block">
                        <asp:DropDownList runat="server" ID="ddlQuantity" AutoPostBack="false"></asp:DropDownList>
                    </div>
                </td>
                <td class="text-right cart-text"><%#: string.Format("{0:C}", Item.ItemPrice / Item.Quantity) %></td>
                <td class="text-right cart-text"><%#: string.Format("{0:C}", Item.ItemPrice) %></td>
                <td class="text-center cart-text">
                    <asp:LinkButton runat="server" ID="btnUpdateItem" OnCommand="btnUpdateItem_Click" CommandArgument="<%#: Item.CartItemID %>" CssClass="btn btn-primary cart-update tool-tip">
                        <i class="fa fa-refresh"></i>
                    </asp:LinkButton>
                    <asp:LinkButton runat="server" ID="btnRemoveItem" OnCommand="btnRemoveItem_Click" OnClientClick="return confirm('Are you sure you want to remove this item from the cart?');" CommandArgument="<%#: Item.CartItemID %>" CssClass="btn btn-danger cart-remove tool-tip">
                        <i class="fa fa-times-circle"></i>
                    </asp:LinkButton>
                </td>
            </tr>
        </ItemTemplate>
    </asp:ListView>
    </tbody>
    <tfoot runat="server" id="tfCheckout" visible="false">
        <tr>
            <td colspan="4" class="text-right">
                <strong>Total :</strong>
            </td>
            <td colspan="1" class="text-right"><%=string.Format("{0:C}", TotalAmount) %>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td colspan="6" class="text-right">
                <a href="/Protected/Order" class="btn btn-black">Checkout</a>
            </td>
        </tr>
    </tfoot>
</table>
<!-- Shopping Cart Table Ends -->
</asp:Content>
