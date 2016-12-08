<%@ Page Title="Home" Language="C#" MasterPageFile="~/submap1.Master" CodeBehind="Default.aspx.cs" ViewStateMode="Disabled" EnableViewState="false" Inherits="WebFormsCommerceDemo._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<!-- Specials Products Starts -->
<section class="products-list">
    <!-- Heading Starts -->
    <h2 class="product-head"><asp:Literal runat="server" ID="ltlCategory">Featured Products</asp:Literal></h2>
    <!-- Heading Ends -->
    <!-- Products Row Starts -->
    <div runat="server" id="vwAddedCart" visible="false" class="alert alert-success">You have successfully added {{Product}} to your cart.</div>
    <asp:ListView ID="lvwProducts1"  
        ItemType="WebFormsCommerceDemo.Models.Product" 
        runat="server"
        SelectMethod="FetchProducts">
        <ItemTemplate>
            <%# (((Container.DisplayIndex+1)%3)==0)? "<div class=\"row\">": "" %>
            <div class="col-md-4 col-sm-6">
                <div class="product-col">
                    <div class="image">
                        <a href="/Product?product_id=<%#: Item.ProductID %>"><img src="<%#: Item.ImagePath %>" alt="product" class="img-responsive" /></a>
                    </div>
                    <div class="caption">
                        <h4>
                            <a href="/Product?product_id=<%#: Item.ProductID %>"><%# Item.Name %></a>
                        </h4>
                        <div class="description">
                            <%# (Item.Description.Length > 80)?
                                    Item.Description.Substring(0, (int) Math.Floor(Item.Description.Length * 0.5)).Trim() +"...":
                                    Item.Description %>
                        </div>
                        <div class="price">
                            <span class="price-new"><%#: string.Format("{0:C}", Item.UnitPrice) %></span>
                        </div>
                        <div class="cart-button<%#: Item.IsAvailable? string.Empty: " alert alert-danger" %>">
                            <%# Item.IsAvailable? string.Empty: "<h5 class=\"bold red\">Sold out</h5>" %>
                            <asp:LinkButton Enabled="<%# Item.IsAvailable %>" runat="server" ID="btnAddToCart" OnCommand="btnAddToCart_Click" CommandArgument="<%#: Item.ProductID %>" CssClass="btn btn-cart">
                                Add to cart <i class="fa fa-shopping-cart"></i>
                            </asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
            <%# (((Container.DisplayIndex+1)%3)==0)? "</div>": "" %>
        </ItemTemplate>
        <EmptyDataTemplate>
            <div class="col-md-4 col-sm-6">
                <div class="product-col red">
                There are no items in this category.
                </div>
            </div>
        </EmptyDataTemplate>
    </asp:ListView>
    <!-- Products Row Ends -->
</section>
<!-- Specials Products Ends -->
</asp:Content>
