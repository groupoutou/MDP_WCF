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
            int nb_joueur = 3; // nombre de client a crée
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            for (int i = 0; i < nb_joueur; i++)
            {
                Thread.Sleep(2000); // temporisation pour éviter les collision et améliorer le débogage
                var thread = new Thread(CreateClient);
                thread.TrySetApartmentState(ApartmentState.STA);
                thread.Start();
            }
        }

        static private void CreateClient()
        {
            try
            {
                Application.Run(new FormClient()); // on lance le programme
            }
            catch
            {
                Thread.CurrentThread.Abort(); //si  erreur dans le programme on supprime le thread
            }
        }
    }
}