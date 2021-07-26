// Scrivere una funzione che dato un importo di denaro iniziale,
// un interesse annuo e un numero di anni permette di calcolare
// l’importo di denaro accresciuto degli interessi dopo il numero di anni passati

// Esempio
// Voglio vincolare 10000 euro per 3 anni con un interesse del 3%

// Dopo 1 anno : 10000 + (10000 * 3 / 100) = 10000 + 300 = 10300
// Dopo 2 anni : 10300 + (10300 * 3 / 100) = 10300 + 309 = 10609
// Dopo 3 anni : 10609 + (10609 * 3 / 100) = 10609 + 318,27 = 10927,27

using System;

namespace Week3
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isDouble = true;
            double importoDaVincolare = 0;
            int anni = 0;
            double interesseAnnuo = 0;

            do
            {
                Console.WriteLine("Quale importo vuoi vincolare?");
                isDouble = double.TryParse(Console.ReadLine(), out importoDaVincolare);

            } while (!isDouble);
           
            bool isInt = true;

            do
            {
                Console.WriteLine("Per quanti anni?");

                isInt = int.TryParse(Console.ReadLine(), out anni);

            } while (!isInt);

           
            bool isValid = false;

            Console.WriteLine("Inserisci il tasso di interesse annuo");

            while (!isValid)
            {
                isValid = double.TryParse(Console.ReadLine(), out interesseAnnuo);
            }

          
            Console.WriteLine($"\nDopo {anni} anni avrai maturato {CalcoloInteressiRicorsione( importoDaVincolare,  anni,  interesseAnnuo)} euro\n");
           
            CalcoloInteressiIterazione(importoDaVincolare, anni, interesseAnnuo);
        }

        private static void CalcoloInteressiIterazione( double importoDaVincolare,  int anni,  double interesseAnnuo)
        {

            double importoConInteressi = importoDaVincolare;
            for (var i = 0; i < anni; i++)
            {
                double importoAnnoPrecedente = importoConInteressi;

                double interessi = (importoConInteressi * interesseAnnuo) / 100;
                importoConInteressi += interessi;

                Console.WriteLine($"Dopo {i + 1} anni, da {importoAnnoPrecedente} euro avrai maturato {interessi} euro e il tuo nuovo capitale sarà: { importoConInteressi} euro");

            }
        }

        public static double CalcoloInteressiRicorsione( double importoDaVincolare,  int anni,  double interesseAnnuo)
        {
          
            if (anni > 0)
            {
               return CalcoloInteressiRicorsione( importoDaVincolare + (importoDaVincolare*interesseAnnuo / 100), --anni, interesseAnnuo);
              
            }
            else
            {
                return importoDaVincolare;
            }
        }
    }
}