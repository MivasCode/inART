namespace Data.Models;

public class Style
{
    public long ID { get; set; }
    public ArtType ArtType { get; set; }
    public long ArtTypeID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Picture { get; set; }
    public List<Artwork> Artworks { get; set; }

}