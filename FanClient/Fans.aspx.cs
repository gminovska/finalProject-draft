using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Fans : System.Web.UI.Page
{
    FanServices.FanServiceClient showtracker = new FanServices.FanServiceClient();
    protected void Page_Load(object sender, EventArgs e)
    {
        var userKey = Session["Userkey"];
        if (userKey == null)
        {
            Response.Redirect("showExplorer.aspx");
        }
        if (!IsPostBack)
        {
            Fill_Artist_Dropdown();
            Fill_Following_Artists();
        }
    }

    protected void Fill_Artist_Dropdown()
    {
        FanServices.ArtistNames[] artists = showtracker.GetArtistNames();
        ArtistDropDownList.DataSource = artists;
        ArtistDropDownList.DataValueField = "ArtistKey";
        ArtistDropDownList.DataTextField = "ArtistName";
        ArtistDropDownList.DataBind();
    }

    protected void Fill_Following_Artists()
    {
        int fanKey = Convert.ToInt32(Session["Userkey"]);
        string[] myArtists = showtracker.GetFanArtists(fanKey);
        followArtistRadioButtonList.DataSource = myArtists;
        followArtistRadioButtonList.DataBind();
    }
    protected void FollowArtistButton_Click(object sender, EventArgs e)
    {
        FollowThisArtist();
    }

    protected void FollowThisArtist()
    {
        FanServices.FanServiceClient rs = new FanServices.FanServiceClient();
        int fanKey = Convert.ToInt32(Session["Userkey"]);
        string artistName = ArtistDropDownList.SelectedItem.Text;

        bool result = rs.AddFanArtist(fanKey, artistName);

        if(result)
        {
            artistAdded.Text = " The artist was added to your follow list";
        }
        else
        {
            artistAdded.Text = "Adding the artist was not successful";
        }
    }

    protected void ShowsbyArtistButton_Click(object sender, EventArgs e)
    {
        string artist = followArtistRadioButtonList.SelectedItem.Text;
        FanServices.ShowsPerArtist[] spa = showtracker.GetArtistShows(artist);
        ShowGridView.DataSource = spa;
        ShowGridView.DataBind();
    }
}