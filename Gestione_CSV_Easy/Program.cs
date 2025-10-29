/* * Questo è un singolo file che contiene TUTTO il necessario.
 * Sostituisci il contenuto del tuo 'Program.cs' con questo codice.
 * (Puoi cancellare i file Form1.cs, Form1.Designer.cs, ecc. 
 * generati da Visual Studio, perché questo codice 
 * ricrea tutto il necessario).
*/

using System;
using System.Collections.Generic;
using System.Drawing;       // Aggiunto per Size, Point, ecc.
using System.IO;
using System.Linq;
using System.Windows.Forms; // Aggiunto per WinForms

namespace WinFormsCsvTest
{
    // --- 1. L'entry point dell'applicazione ---
    // (Questo sostituisce il Program.cs standard)
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Avviamo la nostra finestra personalizzata 'FormPrincipale'
            Application.Run(new FormPrincipale());
        }
    }

    // --- 2. La finestra principale (Form) ---
    // (Questo sostituisce Form1.cs e Form1.Designer.cs)


    // --- 3. La classe che definisce l'oggetto ---
    // (Identica a prima)

    // --- 4. La classe statica per la logica CSV ---
    // (Modificata per usare MessageBox invece di Console)
}