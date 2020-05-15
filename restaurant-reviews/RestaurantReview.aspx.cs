using System;
using System.IO;
using System.Xml.Serialization;
using System.Web.UI.WebControls;

public partial class RestaurantReview : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        restaurants allRestaurants = null;
        if (Session["allRestaurants"] == null)
        {
            string xmlFile = MapPath(@"~/restaurant-reviews.xml");
            using (FileStream fs = new FileStream(xmlFile, FileMode.Open))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(restaurants));
                allRestaurants = (restaurants)serializer.Deserialize(fs);
            }
            Session["allRestaurants"] = allRestaurants;
        }
        else
        {
            allRestaurants = Session["allRestaurants"] as restaurants;
        }
        if (!IsPostBack)
        {
            drpRestaurants.DataSource = allRestaurants.restaurant;
            drpRestaurants.DataTextField = "name";
            drpRestaurants.DataBind();
            drpRestaurants.Items.Insert(0, new ListItem("Please select one...", "0"));
            drpRestaurants.Visible = true;
            details.Visible = false;
        }
    }
    protected void drpRestaurants_SelectedIndexChanged(object sender, EventArgs e)
    {
        restaurants allRestaurants = Session["allRestaurants"] as restaurants;
        if (drpRestaurants.SelectedValue == "0")
        {
            drpRestaurants.Visible = true;
            details.Visible = false;
            return;
        }
        else
        {
            drpRestaurants.Visible = true;
            ShowRestaurant(allRestaurants.restaurant[drpRestaurants.SelectedIndex - 1]);
        }
    }
    protected void ShowRestaurant (restaurant r)
    {
        details.Visible = true;
        txtAddress.Text = r.location.address + ", "
                        + r.location.city + ", "
                        + r.location.province + " "
                        + r.location.postalCode;
        txtSummary.Text = r.summary;
        drpRating.SelectedValue = r.rating.Value.ToString();
        lblConfirmation.Visible = false;
    }
    protected void btnSaveChanges_Click(object sender, EventArgs e)
    {
        restaurants allRestaurants = Session["allRestaurants"] as restaurants;
        if (drpRestaurants.SelectedValue != "0")
        {
            restaurant r = allRestaurants.restaurant[drpRestaurants.SelectedIndex - 1];
            r.summary = txtSummary.Text;
            r.rating.Value = decimal.Parse(drpRating.SelectedValue);
            string xmlFile = MapPath(@"~/restaurant-reviews.xml");
            using (FileStream fs = new FileStream(xmlFile, FileMode.Create))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(restaurants));
                serializer.Serialize(fs, allRestaurants);
            }
            lblConfirmation.Visible = true;
            lblConfirmation.Text = "Revised Restaurant Review has been saved to" + xmlFile;
        }
    }
}