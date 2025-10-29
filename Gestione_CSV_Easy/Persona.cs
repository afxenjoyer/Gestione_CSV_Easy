namespace WinFormsCsvTest;

public class Persona
{
    public string Nome { get; set; }
    public string Cognome { get; set; }
    public string CodiceFiscale { get; set; }

    public Persona() { }

    public Persona(string nome, string cognome, string codiceFiscale)
    {
        Nome = nome;
        Cognome = cognome;
        CodiceFiscale = codiceFiscale;
    }
}