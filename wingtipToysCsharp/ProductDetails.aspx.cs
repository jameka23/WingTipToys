using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;
using wingtipToysCsharp.Models;

namespace wingtipToysCsharp
{
    public partial class ProductDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // this function will return the details of one product provided the productID
        public IQueryable<Product> GetProduct([QueryString("productID")] int? productId)
        {
            var _db = new wingtipToysCsharp.Models.ProductContext(); // call the db for products 
            IQueryable<Product> query = _db.Products;       // declare a query on the db 

            // if the productId has a value and more than 0, then set the query where the product is equal to the productId
            if (productId.HasValue && productId > 0)  
            {
                query = query.Where(p => p.ProductID == productId);
            }
            else
            { // else fails, return null, meaning there is not product with said productId
                query = null;
            }
            return query;
        }
    }
}