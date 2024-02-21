using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace TestWCFClient
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            int nb_joueur = 2; // nombre de client a crée
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            for (int i = 0; i < nb_joueur; i++)
            {
                var thread = new Thread(CreateClient);
                thread.TrySetApartmentState(ApartmentState.STA);
                thread.Start();
            }
        }

        static private void CreateClient()
        {
            Application.Run(new FormClient());
        }
    }
}
