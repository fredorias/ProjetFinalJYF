using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetFinalJYF.Models
{
    public static class Tools
    {
        public static DateTime ConvertCodeToDate(string code)
        {
            // Convertit le code en tableau de 4 string avec '_' comme séparateur
            var tab = code.Split('_');

            //Convertit [0] en mois et [3] en année 
            DateTime jour = new DateTime(
                DateTime.Now.Year + int.Parse(tab[3]),
                int.Parse(tab[0]),
                1);

            //[1] Samedi ou Dimanche
            DayOfWeek jourDeLaSemaine = DayOfWeek.Sunday;
            if (tab[1] == "S") jourDeLaSemaine = DayOfWeek.Saturday;

            //[2] N ième samedi ou dimanche du mois
            var max = int.Parse(tab[2]);
            var n = 0;
            var trouve = false;
            while (!trouve)
            {
                if (jour.DayOfWeek == jourDeLaSemaine)
                {
                    n++;
                    if (n == max)
                    {
                        trouve = true;
                    }
                }
                if (!trouve) jour = jour.AddDays(1);
            }

            return jour;
        }

        public static string ConvertDateToCode(DateTime date)
        {
            string[] code = new string[4];

            //Reconstituer les 4 parties du codes
            //1ère partie: MOIS
            code[0] = date.Month.ToString();

            //2ème partie: SAMEDI OU DIMANCHE
            code[1] = "D";
            if (date.DayOfWeek == DayOfWeek.Saturday) code[1] = "S";

            //3ème partie: Nième SAMEDI ou DIMANCHE du mois
            int compteur = 0;
            for (DateTime d = new DateTime(date.Year, date.Month, 1); d <= date; d= d.AddDays(1))
            {
                if (d.DayOfWeek == date.DayOfWeek) compteur++;

            }
            code[2] = compteur.ToString();

            //4ème partie: ANNEE
            code[3] = (date.Year - DateTime.Now.Year).ToString();

            // Définir '_' comme séparateur
            return string.Join("_", code);

        }
    }
}