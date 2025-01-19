namespace Models;

public class Veiculo
{
    public Guid Id { get; set; }
    public string Placa { get; set; }
    public string Modelo { get; set; }
    public int Ano { get; set; }
    public double Quilometragem { get; set; }
    public Status Status { get; set; }
}

public enum Status
{
    Ativo,
    Desativado
}