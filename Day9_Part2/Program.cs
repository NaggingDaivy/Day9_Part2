using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day9_Part2
{
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, Dictionary<string, int>> dictionary = new Dictionary<string, Dictionary<string, int>>();
            #region Dictionaries initialisation

            dictionary["AlphaCentauri"] = new Dictionary<string, int>();
            dictionary["Snowdin"] = new Dictionary<string, int>();
            dictionary["Tambi"] = new Dictionary<string, int>();
            dictionary["Faerun"] = new Dictionary<string, int>();
            dictionary["Norrath"] = new Dictionary<string, int>();
            dictionary["Straylight"] = new Dictionary<string, int>();
            dictionary["Tristram"] = new Dictionary<string, int>();
            dictionary["Arbre"] = new Dictionary<string, int>();

            //ALPHACENTAURI
            dictionary["AlphaCentauri"]["Snowdin"] = 66;
            dictionary["AlphaCentauri"]["Tambi"] = 28;
            dictionary["AlphaCentauri"]["Faerun"] = 60;
            dictionary["AlphaCentauri"]["Norrath"] = 34;
            dictionary["AlphaCentauri"]["Straylight"] = 34;
            dictionary["AlphaCentauri"]["Tristram"] = 3;
            dictionary["AlphaCentauri"]["Arbre"] = 108;

            dictionary["Snowdin"]["AlphaCentauri"] = 66;
            dictionary["Tambi"]["AlphaCentauri"] = 28;
            dictionary["Faerun"]["AlphaCentauri"] = 60;
            dictionary["Norrath"]["AlphaCentauri"] = 34;
            dictionary["Straylight"]["AlphaCentauri"] = 34;
            dictionary["Tristram"]["AlphaCentauri"] = 3;
            dictionary["Arbre"]["AlphaCentauri"] = 108;


            //SNOWDIN
            dictionary["Snowdin"]["Tambi"] = 22;
            dictionary["Snowdin"]["Faerun"] = 12;
            dictionary["Snowdin"]["Norrath"] = 91;
            dictionary["Snowdin"]["Straylight"] = 121;
            dictionary["Snowdin"]["Tristram"] = 111;
            dictionary["Snowdin"]["Arbre"] = 71;

            dictionary["Tambi"]["Snowdin"] = 22;
            dictionary["Faerun"]["Snowdin"] = 12;
            dictionary["Norrath"]["Snowdin"] = 91;
            dictionary["Straylight"]["Snowdin"] = 121;
            dictionary["Tristram"]["Snowdin"] = 111;
            dictionary["Arbre"]["Snowdin"] = 71;

            //TAMBI
            dictionary["Tambi"]["Faerun"] = 39;
            dictionary["Tambi"]["Norrath"] = 113;
            dictionary["Tambi"]["Straylight"] = 130;
            dictionary["Tambi"]["Tristram"] = 35;
            dictionary["Tambi"]["Arbre"] = 40;

            dictionary["Faerun"]["Tambi"] = 39;
            dictionary["Norrath"]["Tambi"] = 113;
            dictionary["Straylight"]["Tambi"] = 130;
            dictionary["Tristram"]["Tambi"] = 35;
            dictionary["Arbre"]["Tambi"] = 40;


            //FAERUN
            dictionary["Faerun"]["Norrath"] = 63;
            dictionary["Faerun"]["Straylight"] = 21;
            dictionary["Faerun"]["Tristram"] = 57;
            dictionary["Faerun"]["Arbre"] = 83;

            dictionary["Norrath"]["Faerun"] = 63;
            dictionary["Straylight"]["Faerun"] = 21;
            dictionary["Tristram"]["Faerun"] = 57;
            dictionary["Arbre"]["Faerun"] = 83;

            //NORRATH
            dictionary["Norrath"]["Straylight"] = 9;
            dictionary["Norrath"]["Tristram"] = 50;
            dictionary["Norrath"]["Arbre"] = 60;

            dictionary["Straylight"]["Norrath"] = 9;
            dictionary["Tristram"]["Norrath"] = 50;
            dictionary["Arbre"]["Norrath"] = 60;

            //STRAYLIGHT
            dictionary["Straylight"]["Tristram"] = 27;
            dictionary["Straylight"]["Arbre"] = 81;

            dictionary["Tristram"]["Straylight"] = 27;
            dictionary["Arbre"]["Straylight"] = 81;

            //TRISTRAM
            dictionary["Tristram"]["Arbre"] = 90;

            //ARbre
            dictionary["Arbre"]["Tristram"] = 90;

            #endregion Dictionaries

            int shortestDistance = 0;

            //string[] cities =
            //{
            //    "AlphaCentauri", "Snowdin", "Tambi", "Faerun", "Norrath", "Straylight", "Tristram",
            //    "Arbre"
            //};

            List<string> listCities = new List<string>();
            listCities.Add("AlphaCentauri");
            listCities.Add("Snowdin");
            listCities.Add("Tambi");
            listCities.Add("Faerun");
            listCities.Add("Norrath");
            listCities.Add("Straylight");
            listCities.Add("Tristram");
            listCities.Add("Arbre");


            foreach (string city in listCities)
            {
                List<string> templistCities = new List<string>(listCities);


                templistCities.Remove(city);

                int dist = DistanceMax(city, templistCities, dictionary);
                Console.WriteLine(dist);
            }

        }

        private static int DistanceMax(string city1, List<string> otherCities, Dictionary<string, Dictionary<string, int>> dictionary)
        {
            int dist = 0;

            foreach (string city2 in otherCities)
            {
                List<string> tempOtherCities = new List<string>(otherCities);

                tempOtherCities.Remove(city2);

                if (tempOtherCities.Count != 0)
                {
                    int dist1 = DistanceMax(city2, tempOtherCities, dictionary) + dictionary[city1][city2];
                    dist = Math.Max(dist, dist1);
                }
                else
                {
                    int dist1 = dictionary[city1][city2];
                    dist = Math.Max(dist, dist1);
                }

            }

            return dist;
        }
    }
}
