<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ProductThumb.ascx.vb" Inherits="webapp_assignment.ProductThumb" %>

<div class="col-sm-12 col-md-12 col-lg-4 ftco-animate d-flex">
    <div class="product d-flex flex-column">
        <a href='<%= String.Format("Product.aspx?id={0}", Product.id) %>' class="img-prod">
            <img class="img-fluid" src='<%= Product.imageLoc.Substring(1) %>' alt="Colorlib Template">
            <div class="overlay"></div>
        </a>
        <div class="text py-3 pb-4 px-3">
            <div class="d-flex">
                <div class="cat">
                    <span><%=Product.Category1.name %></span>
                </div>
            </div>
            <h3><a href='<%= String.Format("Product.aspx?id={0}", Product.id) %>'><%=Product.name %></a></h3>
            <div class="pricing">
                <p class="price"><span>RM <%=Product.price %></span></p>
            </div>
            <p class="bottom-area d-flex px-3">
                <a href='<%= String.Format("Product.aspx?id={0}", Product.id) %>' class="add-to-cart text-center py-2 mr-1"><span>View product <i class="ion-ios-add ml-1"></i></span></a>
            </p>
        </div>
    </div>
</div>
