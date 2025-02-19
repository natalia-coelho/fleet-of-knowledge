using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Models;

[BsonIgnoreExtraElements]
public class Movie
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("plot")]
    public string Plot { get; set; }
    [BsonElement("genres")]
    public List<string> Genres { get; set; }
    [BsonElement("runtime")]
    public int Runtime { get; set; }
    [BsonElement("cast")]
    public List<string> Cast { get; set; }
    [BsonElement("poster")]
    public string Poster { get; set; }
    [BsonElement("title")]
    public string Title { get; set; }
    [BsonElement("fullplot")]
    public string FullPlot { get; set; }
}

