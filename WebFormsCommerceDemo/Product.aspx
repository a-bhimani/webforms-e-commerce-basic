<%@ Page Title="Product" MasterPageFile="~/submap1.Master" CodeBehind="Product.aspx.cs" Inherits="WebFormsCommerceDemo.Protected.Product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<!-- Breadcrumb Starts -->
<ol runat="server" id="plhBreadCrumbs" class="breadcrumb">
    <li><a href="\">Home</a></li>
    <li><asp:LinkButton runat="server" ID="lnkCategory"></asp:LinkButton></li>
    <li class="active">Product</li>
</ol>
<!-- Breadcrumb Ends -->
<!-- Product Info Starts -->
<div runat="server" id="plhProductDetails" class="row product-info">
    <div runat="server" id="vwAddedCart" visible="false" class="alert alert-success">You have successfully added {{Product}} to your cart.</div>
    <!-- Left Starts -->
    <div class="col-sm-5 images-block">
        <p><asp:Image runat="server" ID="imgProduct" AlternateText="Image" CssClass="img-responsive thumbnail" /></p>
    </div>
    <!-- Left Ends -->
    <!-- Right Starts -->
    <div class="col-sm-7 product-details">
        <!-- Product Name Starts -->
        <h2><asp:Literal runat="server" ID="ltlProductName"></asp:Literal></h2>
        <!-- Product Name Ends -->
        <hr />
        <!-- Manufacturer Starts -->
        <ul class="list-unstyled manufacturer">
            <li>
                <span>Availability:</span> <asp:Label runat="server" ID="lblStock" ForeColor="White" CssClass="bold label label-success">In Stock</asp:Label>
            </li>
        </ul>
        <!-- Manufacturer Ends -->
        <hr />
        <!-- Price Starts -->
        <div class="price">
            <span class="price-head">Price :</span>
            <span class="price-new"><asp:Literal runat="server" ID="ltlPrice"></asp:Literal></span>
        </div>
        <!-- Price Ends -->
        <hr />
        <!-- Available Options Starts -->
        <div class="options">
            <div class="cart-button button-group">
                <button runat="server" id="btnAddToCart" onserverclick="btnAddToCart_Click" type="button" class="btn btn-cart">
                    Add to cart
				<i class="fa fa-shopping-cart"></i>
                </button>
            </div>
        </div>
        <!-- Available Options Ends -->
    </div>
    <!-- Right Ends -->
</div>
<!-- product Info Ends -->
<!-- Product Description Starts -->
<div runat="server" id="plhProductDescription" class="product-info-box">
    <h4 class="heading">Description</h4>
    <div class="content panel-smart">
        <asp:Literal runat="server" ID="ltlDescription"></asp:Literal>
    </div>
</div>
<div runat="server" id="plhNoContent" visible="false" class="panel panel-warning">
    <div class="content panel-body">
        <h6 class="red">
            There is no product to display.
        </h6>
    </div>
</div>
<!-- Product Description Ends -->
</asp:Content>
