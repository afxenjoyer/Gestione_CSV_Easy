using Core;

int scelta = -1;

List<Persona> listaPersone = new List<Persona>
{
    new Persona("Mario", "Rossi", "RSSMRA80A01H501U"),
    new Persona("Giuseppe", "Verdi", "VRDGPP75B02F205Z"),
    new Persona("Laura", "Bianchi", "BNCLRA90C41L219K")
};

Console.WriteLine("Interfaccia linea di comando CSV");
while (scelta != 0)
{
    Console.WriteLine("1|Mostra rubrica");
    Console.WriteLine("2|Salva su CSV");
    Console.WriteLine("3|Carica su CSV");
    Console.WriteLine("0|Esci dal programma");

    while (!int.TryParse(Console.ReadLine(), out scelta))
    {
        Console.WriteLine("ERRORE: L'input inserito non è un numero");
    }

    switch (scelta)
    {
        case 1:
            Console.WriteLine("Nome, Cognome, Codice Fiscale");
            foreach (var persona in listaPersone)
            {
                Console.WriteLine("{0}, {1}, {2}", persona.Nome, persona.Cognome, persona.CodiceFiscale);
            }
            Console.WriteLine();
            break;
        case 2:
            GestoreCsv.SalvaSuCsv("rubrica.csv", listaPersone);
            Console.WriteLine("La rubrica è stata salvata");
            break;
        case 3:
            listaPersone = GestoreCsv.CaricaDaCsv("rubrica.csv");
            Console.WriteLine("La rubrica è stata caricata");
            break;
        case 0:
            Console.WriteLine("Arrivederci");
            break;
        default:
            Console.WriteLine("ERRORE: L'input inserito non corrisponde ad un'opzione");
            break;
    }
}