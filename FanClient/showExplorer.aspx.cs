using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class showExplorer : System.Web.UI.Page
{
    FanServices.FanServiceClient showtracker = new FanServices.FanServiceClient();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Fill_Artist_Dropdown();
            Fill_Venue_Dropdown();
            Fill_Show_Dropdown();
        }
        nodata.Text = "";
    }
    protected void Fill_Artist_Dropdown()
    {
        FanServices.ArtistNames[] artists = showtracker.GetArtistNames();
        ArtistDropDownList.DataSource = artists;
        ArtistDropDownList.DataValueField = "ArtistKey";
        ArtistDropDownList.DataTextField = "ArtistName";
        ArtistDropDownList.DataBind();
    }

    protected void Fill_Venue_Dropdown()
    {
        string[] venues = showtracker.GetVenueNames();
        VenueDropDownList.DataSource = venues;
        VenueDropDownList.DataBind();
    }
    protected void Fill_Show_Dropdown()
    {
        string[] shows = showtracker.GetShowNames();
        ShowDropDownList.DataSource = shows;
        ShowDropDownList.DataBind();
    }
    protected void ShowsbyArtistButton_Click(object sender, EventArgs e)
    {
        string artist = ArtistDropDownList.SelectedItem.Text;
        FanServices.ShowsPerArtist[] spa = showtracker.GetArtistShows(artist);
        ShowGridView.DataSource = spa;
        ShowGridView.DataBind();
    }
    protected void ShowsbyVenueButton_Click(object sender, EventArgs e)
    {

        string venue = VenueDropDownList.SelectedItem.Text;
        FanServices.ShowsPerVenue[] spv = showtracker.GetVenueShows(venue);
        if (spv.Length == 0)
        {
            nodata.Text = "There are no shows for this venue";
        }
        ShowGridView.DataSource = spv;
        ShowGridView.DataBind();
    }
    protected void loginButton_Click(object sender, EventArgs e)
    {
        FanLogin();
    }

    protected void FanLogin()
    {

        FanServices.FanServiceClient rs = new FanServices.FanServiceClient();
        int key = rs.FanLogin(userTextBox.Text, passTextBox.Text);
        if (key != 0)
        {
            //errorLabel.Text = "Welcome!";
            Session["Userkey"] = key;
            Response.Redirect("Fans.aspx");

        }
        else
        {
            errorLabel.Text = "Invalid Login";
        }
    }
}