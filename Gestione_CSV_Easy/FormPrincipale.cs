namespace WinFormsCsvTest;

public partial class FormPrincipale : Form
{


    public FormPrincipale()
    {
        InitializeComponent();
        // Richiama il metodo per costruire l'interfaccia
        InizializzaComponentiGrafici();

        // Carichiamo alcuni dati d'esempio all'avvio
        CaricaDatiDiEsempio();
    }

    private void InizializzaComponentiGrafici()
    {
    }

    private void CaricaDatiDiEsempio()
    {
        List<Persona> listaIniziale = new List<Persona>
        {
            new Persona("Mario", "Rossi", "RSSMRA80A01H501U"),
            new Persona("Giuseppe", "Verdi", "VRDGPP75B02F205Z"),
            new Persona("Laura", "Bianchi", "BNCLRA90C41L219K")
        };

        // Il DataGridView crea automaticamente le colonne
        // basate sulle proprietà pubbliche di 'Persona'
        dgvPersone.DataSource = listaIniziale;
    }

    // --- Gestori Eventi (Click dei bottoni) ---

    private void btnCaricaDaCsv_Click(object sender, EventArgs e)
    {
        // 1. Mostra il FileChooser per APRIRE
        if (openFileDialogCsv.ShowDialog() == DialogResult.OK)
        {
            try
            {
                string filePath = openFileDialogCsv.FileName;

                // 2. Chiama la logica di caricamento
                List<Persona> personeCaricate = GestoreCsv.CaricaDaCsv(filePath);

                // 3. Aggiorna la griglia
                dgvPersone.DataSource = null; // Forza l'aggiornamento
                dgvPersone.DataSource = personeCaricate;

                MessageBox.Show($"Caricamento completato!\n{personeCaricate.Count} record letti.",
                    "Successo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errore durante il caricamento del file:\n{ex.Message}",
                    "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private void btnSalvaSuCsv_Click(object sender, EventArgs e)
    {
        // 1. Recupera la lista di persone attualmente nella griglia
        List<Persona> listaDaSalvare = dgvPersone.DataSource as List<Persona>;

        // NOTA: Se l'utente ha aggiunto/modificato righe, la 'listaDaSalvare'
        // (DataSource) potrebbe non essere perfettamente aggiornata finché 
        // non si lascia la cella. Per un'app robusta, si dovrebbe
        // leggere la griglia cella per cella. Ma per questo esempio,
        // salvare il DataSource è sufficiente.

        // Gestione alternativa se il DataSource non è una Lista (es. se vuoto)
        if (listaDaSalvare == null)
        {
            // Proviamo a leggere manualmente dalla griglia (più complesso)
            listaDaSalvare = new List<Persona>();
            foreach (DataGridViewRow row in dgvPersone.Rows)
            {
                if (row.IsNewRow) continue; // Salta la riga vuota per l'inserimento

                listaDaSalvare.Add(new Persona
                {
                    Nome = row.Cells["Nome"]?.Value?.ToString(),
                    Cognome = row.Cells["Cognome"]?.Value?.ToString(),
                    CodiceFiscale = row.Cells["CodiceFiscale"]?.Value?.ToString()
                });
            }
            // Rimuoviamo eventuali righe create male
            listaDaSalvare.RemoveAll(p =>
                string.IsNullOrWhiteSpace(p.Nome) &&
                string.IsNullOrWhiteSpace(p.Cognome) &&
                string.IsNullOrWhiteSpace(p.CodiceFiscale));
        }

        if (listaDaSalvare.Count == 0)
        {
            MessageBox.Show("Nessun dato da salvare.", "Attenzione",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        // 2. Mostra il FileChooser per SALVARE
        if (saveFileDialogCsv.ShowDialog() == DialogResult.OK)
        {
            try
            {
                string filePath = saveFileDialogCsv.FileName;

                // 3. Chiama la logica di salvataggio
                GestoreCsv.SalvaSuCsv(filePath, listaDaSalvare);

                MessageBox.Show($"Salvataggio completato!\n{listaDaSalvare.Count} record scritti.",
                    "Successo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errore durante il salvataggio del file:\n{ex.Message}",
                    "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}