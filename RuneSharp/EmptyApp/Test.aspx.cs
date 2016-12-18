using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RuneSharp;


namespace EmptyApp
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Models.ItemsResponse iResp = RuneMethods.getItems(Models.ItemCategory.FoodAndDrink, 's');
            if (iResp.items.Count > 0)
            {
                var testID = iResp.items[0].id;
                Models.DetailResponse dResp = RuneMethods.getDetail(testID);
                Models.CatalogueResponse cResp = RuneMethods.getCatalogue(Models.ItemCategory.Familiars);
                var gResp = RuneMethods.getGraph(21787);
             }
        }
    }
}