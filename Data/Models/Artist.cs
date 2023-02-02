namespace Data.Models;

public class Artist
{
    public long ID { get; set; }
    public string Name { get; set; }
    public string Birthday { get; set; }
    public List<Artwork> Artworks { get; set; }
}