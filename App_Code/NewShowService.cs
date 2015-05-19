using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "NewShowService" in code, svc and config file together.
public class NewShowService : INewShowService
{
    ShowTrackerEntities ste = new ShowTrackerEntities();

    public bool AddArtist(Artist a)
    {
        bool result = true;

        try
        {
            Artist arts = new Artist();
            arts.ArtistName = a.ArtistName;
            arts.ArtistEmail = a.ArtistEmail;
            arts.ArtistWebPage = a.ArtistWebPage;
            arts.ArtistDateEntered = DateTime.Now;

            ste.Artists.Add(arts);
            ste.SaveChanges();
        }
        catch
        {
            result = false;
        }
        return result;
    }

    public bool AddShow(ShowLite s, string artist)
    {
        bool result = true;

        try
        {
            Show sh = new Show();
            sh.ShowName = s.ShowName;
            sh.ShowDate = s.ShowDate;
            sh.ShowTime = s.ShowTime;
            sh.ShowTicketInfo = s.ShowTicketinfo;
            sh.ShowDateEntered = DateTime.Now;

            ste.Shows.Add(sh);

            ShowDetail shdt = new ShowDetail();
            //Artist arts = ste.Artists.FirstOrDefault(a => a.ArtistName == artist);   
            shdt.ArtistKey = s.ArtistKey;

            shdt.Show = sh;
            shdt.ShowDetailAdditional = s.ShowDetailAdditional;
            shdt.ShowDetailArtistStartTime = s.ShowDetailArtistStartTime;

            ste.ShowDetails.Add(shdt);
            ste.SaveChanges();

        }
        catch
        {
            result = false;
        }
        return result;
    }

    public List<string> GetArtists()
    {
        var arts = from a in ste.Artists
                   orderby a.ArtistName
                   select new { a.ArtistKey, a.ArtistName };
        List<string> artists = new List<string>();
        foreach (var a in arts)
        {
            artists.Add(a.ArtistName);
        }
        return artists;
    }

    public List<string> GetVenue()
    {
        var vne = from v in ste.Venues
                  orderby v.VenueName
                  select new { v.VenueKey, v.VenueName };
        List<string> venues = new List<string>();
        foreach (var v in vne)
        {
            venues.Add(v.VenueName);
        }
        return venues;
    }

}
