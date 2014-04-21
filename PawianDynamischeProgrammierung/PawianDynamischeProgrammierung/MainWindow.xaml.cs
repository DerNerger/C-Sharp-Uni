using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PawianDynamischeProgrammierung
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            int[] nutiValue = { 11, 15, 20, 28, 9, 3 };
            int[] size = { 8, 12, 13, 20, 7, 4 };
            int[][] sorts = { nutiValue, size };

            DateTime before = DateTime.Now;
            int [] perfektFeed = findOptimum(sorts, 115);

            TimeSpan runtime = DateTime.Now - before;

            Console.WriteLine("Runtime = " + runtime);

            //print perfekt feed
            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine("Gemüse index =" + i + ", Menge=" + perfektFeed[i]); // Output: 3*Gemüse0 + 7*Gemüse2
            }
            Console.WriteLine("Perfekter Nährstoffgehalt="+perfektFeed[6]); //Output=173


        }


        public int[] findOptimum(int[][] sorts, int m) 
        {
            int[,] results = new int[m+1,sorts[0].Length+1];

            //berechne sukzessive optimale Teillösungen wenn der Affe noch eine Gesamtgröße von i fangen kann
            for (int i = 1; i <= m; i++)
            {
                int optiValue = 0;
                int optIndex = 0;
                for (int j = 0; j < i/2; j++)
                {
                    int value = results[j, 6] + results[i - j, 6];
                    if (value > optiValue)
                    {
                        optiValue = value;
                        optIndex = j;
                    }
                }

                //existiert eine Sorte mit höherem Nährwert als der Nährwert der berechneten Kombination?
                int [] betterSortInfos = getSortBySize(i, sorts);
                if (betterSortInfos != null && betterSortInfos[1]>optiValue)
                {
                    //für eine Größe von i ist es besser das Gemüse mit index betterSortInfos[0] und Nährwert betterSortInfos[1] zu benutzen
                    results[i, betterSortInfos[0]] = 1;
                    results[i, 6] = betterSortInfos[1];
                }
                else 
                {
                    //zusammensetzen der Optimalen Teillösung für eine Größe von i aus der Kombination der gefundenen kleineren Optimalen Teillösungen
                    //speichern dieser Teillösung in der Tabelle -> Memoization
                    for (int j = 0; j < 7; j++)
                    {
                        results[i,j]= results[optIndex,j]+results[i-optIndex,j];
                    }
                }
            }

            //zeigt alle Perfekten Teillösungen an
            //perfekte Endlösung ist Zeile 115
            showTable(results);
            
            //gebe Array mit perfekter Mischration zück
            int[] perfektFeed = new int[7];
            for (int i = 0; i < perfektFeed.Length; i++)
            {
                perfektFeed[i] = results[115,i];
            }
            return perfektFeed;
        }

        private void showTable(int[,] results)
        {
            for (int i = 0; i < 116; i++)
            {
                Console.Write("Line " + i + ": ");
                for (int j = 0; j < 7; j++)
                {
                    Console.Write(results[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("-----------------------");
            Console.WriteLine();
        }

        //Wurde eine Sorte mit angegebener Größe gefunden wird Index und Nährwert zurückgegeben
        //Wurde nichts gefunden wird null zurückgegeben
        private int[] getSortBySize(int size, int[][] sorts)
        {
            for (int i = 0; i < sorts[0].Length; i++)
            {
                if (sorts[1][i] == size)
                {
                    int[] toReturn = {i,sorts[0][i]};
                    return toReturn;
                }
            }
            return null;
        }




    }
}
