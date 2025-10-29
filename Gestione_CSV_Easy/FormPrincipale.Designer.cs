namespace WinFormsCsvTest
{
    partial class FormPrincipale
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            // --- Inizializza Controlli ---
            this.dgvPersone = new DataGridView();
            this.btnCaricaDaCsv = new Button();
            this.btnSalvaSuCsv = new Button();
            this.panelBottoni = new Panel();
            this.openFileDialogCsv = new OpenFileDialog();
            this.saveFileDialogCsv = new SaveFileDialog();

            // --- Configura Finestra (FormPrincipale) ---
            this.Text = "Gestore Persone CSV";
            this.Size = new Size(600, 400);
            this.StartPosition = FormStartPosition.CenterScreen;

            // --- Configura Pannello Bottoni ---
            this.panelBottoni.Dock = DockStyle.Bottom;
            this.panelBottoni.Height = 50;

            // --- Configura Bottone Salva ---
            this.btnSalvaSuCsv.Text = "Salva su CSV...";
            this.btnSalvaSuCsv.Size = new Size(120, 30);
            this.btnSalvaSuCsv.Location = new Point(10, 10);
            this.btnSalvaSuCsv.Click += new EventHandler(this.btnSalvaSuCsv_Click);

            // --- Configura Bottone Carica ---
            this.btnCaricaDaCsv.Text = "Carica da CSV...";
            this.btnCaricaDaCsv.Size = new Size(120, 30);
            this.btnCaricaDaCsv.Location = new Point(140, 10);
            this.btnCaricaDaCsv.Click += new EventHandler(this.btnCaricaDaCsv_Click);

            // --- Configura Griglia Dati ---
            this.dgvPersone.Dock = DockStyle.Fill; // Occupa tutto lo spazio rimanente
            this.dgvPersone.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPersone.ReadOnly = false; // Permettiamo la modifica
            this.dgvPersone.AllowUserToAddRows = true; // Permettiamo di aggiungere righe

            // --- Configura Finestre di Dialogo ---
            string filtroFile = "File CSV (*.csv)|*.csv|Tutti i file (*.*)|*.*";
            this.openFileDialogCsv.Filter = filtroFile;
            this.openFileDialogCsv.Title = "Seleziona file CSV da caricare";

            this.saveFileDialogCsv.Filter = filtroFile;
            this.saveFileDialogCsv.Title = "Salva persone su CSV";

            // --- Aggiungi Controlli al Form ---
            // Aggiungiamo prima i bottoni al pannello
            this.panelBottoni.Controls.Add(btnSalvaSuCsv);
            this.panelBottoni.Controls.Add(btnCaricaDaCsv);

            // Aggiungiamo i controlli "principali" al Form
            // L'ordine è importante per il Docking!
            this.Controls.Add(this.dgvPersone);     // Prima il contenuto (Fill)
            this.Controls.Add(this.panelBottoni); // Poi la barra in basso (Bottom)


            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "Form1";
        }

        #endregion

        // Controlli UI
        private DataGridView dgvPersone;
        private Button btnCaricaDaCsv;
        private Button btnSalvaSuCsv;
        private Panel panelBottoni;

        // Finestre di dialogo
        private OpenFileDialog openFileDialogCsv;
        private SaveFileDialog saveFileDialogCsv;
    }
}
