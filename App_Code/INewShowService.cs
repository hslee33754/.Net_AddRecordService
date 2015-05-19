using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "INewShowService" in both code and config file together.
[ServiceContract]
public interface INewShowService
{
    [OperationContract]
    bool AddArtist(Artist a);

    [OperationContract]
    bool AddShow(ShowLite s, string artist);

    [OperationContract]
    List<string> GetArtists();

    [OperationContract]
    List<string> GetVenue();

}

[DataContract]
public class ShowLite
{
    [DataMember]
    public string ShowName { set; get; }

    [DataMember]
    public DateTime ShowDate { set; get; }

    [DataMember]
    public TimeSpan ShowTime { set; get; }

    [DataMember]
    public string ShowTicketinfo { set; get; }

    [DataMember]
    public DateTime ShowDateEntered { set; get; }

    [DataMember]
    public TimeSpan ShowDetailArtistStartTime { set; get; }

    [DataMember]
    public string ShowDetailAdditional { set; get; }

    [DataMember]
    public Int32 ArtistKey { set; get; }

}
