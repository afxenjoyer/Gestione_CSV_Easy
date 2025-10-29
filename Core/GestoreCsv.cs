using System.Text;

namespace Core;

public static class GestoreCsv
{
    private const string INTESTAZIONE = "Nome,Cognome,CodiceFiscale";
    private const char SEPARATORE = ',';

    public static void SalvaSuCsv(string filePath, List<Persona> persone)
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(INTESTAZIONE);

        foreach (var p in persone)
        {
            // Semplice implementazione (senza gestione virgole nei campi)
            sb.AppendLine($"{p.Nome}{SEPARATORE}{p.Cognome}{SEPARATORE}{p.CodiceFiscale}");
        }

        // File.WriteAllText gestisce già le eccezioni (es. file bloccato)
        // che verranno catturate nel gestore del click
        File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8);
    }

    public static List<Persona> CaricaDaCsv(string filePath)
    {
        List<Persona> personeCaricate = new List<Persona>();

        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException($"Il file '{filePath}' non è stato trovato.");
        }

        string[] righe = File.ReadAllLines(filePath);

        for (int i = 1; i < righe.Length; i++) // Salta intestazione
        {
            string riga = righe[i];
            if (string.IsNullOrWhiteSpace(riga)) continue;

            string[] campi = riga.Split(SEPARATORE);

            if (campi.Length == 3)
            {
                personeCaricate.Add(new Persona
                {
                    Nome = campi[0],
                    Cognome = campi[1],
                    CodiceFiscale = campi[2]
                });
            }
            else
            {
                throw new InvalidDataException($"Riga malformata nel CSV (riga {i + 1}) skippata: '{riga}'");
            }
        }
        return personeCaricate;
    }
}