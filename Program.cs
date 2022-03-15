using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FuelEconomyCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            var filepath = Path.Combine(Directory.GetCurrentDirectory(), "VehicleFuelConsumption.txt");

            using (var reader = new StreamReader(File.OpenRead(filepath)))
            {
                string? header = reader.ReadLine();

                string lines;

                double pricePerLitre;
                
                List<string> VehicleName = new List<string>();
                List<double> LitersPer100KM = new List<double>();

                while ((lines = reader.ReadLine()) != null)
                {
                    var values = lines.Split(',');

                    VehicleName.Add(values[0]);
                    LitersPer100KM.Add(double.Parse(values[1]));
                }
                var Vehicle = VehicleName.ToArray();
                var LitersPr100KM = LitersPer100KM.ToArray();

                Console.WriteLine("Please enter price per litre \n");

                if (!double.TryParse(Console.ReadLine(), out pricePerLitre))
                {
                    Console.WriteLine("Entered Price is Invalid \n");
                }

                Console.WriteLine("\n{0,-35} {1,-20} {2,-20} {3,-20} {4,-20}\n",
                  "VehicleName", "Litre per KM", "Miles per Gallon", "Cost per KM", "Cost per Mile");

                for (int ctr = 0; ctr < LitersPr100KM.Length; ctr++)

                    Console.WriteLine("{0,-35} {1,-20:N2} {2,-20:N2} {3,-20:N2} {4,-20:N2}\n",
                      VehicleName[ctr], LitersPr100KM[ctr] / 100, 235.21 / LitersPr100KM[ctr], (LitersPr100KM[ctr] * pricePerLitre) / 100, (LitersPr100KM[ctr] * pricePerLitre * 0.62) / 100);

                Console.ReadKey();

            }
        }

    }
}