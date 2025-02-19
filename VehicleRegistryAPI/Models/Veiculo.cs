using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Models;

public class Veiculo
{
    [BsonId]
    [BsonRepresentation(BsonType.Binary)]
    [BsonGuidRepresentation(GuidRepresentation.Standard)]
    public Guid Id { get; set; }
    public string placa { get; set; }
    public string modelo { get; set; }
    public int ano { get; set; }
    public double quilometragem { get; set; }
    public Status status { get; set; }
}

public enum Status
{
    Ativo,
    Desativado
}