using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.ModelBinding;
using wingtipToysCsharp.Models;

namespace wingtipToysCsharp
{
    public partial class ProductList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // this function will get the categoryId and return back a query that holds all the products
        // with that categoryId

        public IQueryable<Product> GetProducts([QueryString("id")] int? categoryId)
        {
            var _db = new wingtipToysCsharp.Models.ProductContext();  // call the db for the products 
            IQueryable<Product> query = _db.Products;       // declare a list type of the products 


            // if the category from the query string has a value and more than 0, 
            // set the value of the query to be all the products with the categoryId
            if (categoryId.HasValue && categoryId > 0)
            {
                query = query.Where(p => p.CategoryID == categoryId);
            }
            return query;
        }
    }
}