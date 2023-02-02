namespace Data.Models;

public class ArtType
{
    public long ID { get; set; }
    public string Name { get; set; }
    public List<Style> Styles { get; set; }
}