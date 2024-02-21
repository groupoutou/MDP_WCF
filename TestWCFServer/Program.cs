using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TestWCFServer
{
    static class Program
    {
        public static int nb_max_joueur = 3;
        public static int[] etat = new int[nb_max_joueur];

        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            for (int i =0; i < nb_max_joueur; i++){
                Program.etat[i] = -1;
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormServeur());
        }
    }
}
