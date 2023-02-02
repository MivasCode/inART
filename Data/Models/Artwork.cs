namespace Data.Models;

public class Artwork
{
    public long ID { get; set; }
    public Style Style { get; set; }
    public long StyleID { get; set; }
    public Artist Artist { get; set; }
    public long ArtistID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Picture { get; set; }
}