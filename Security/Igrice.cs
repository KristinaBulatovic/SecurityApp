using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security
{
    class Igrice
    {

        Random rnd = new Random();
        int id_pitanja;
        int id_odgovora;
        int id_memorije;
        int i = 0;
        List<int> br_pitanja = new List<int>();
        List<int> br_odgovora = new List<int>();
        //List<int> br_memorije = new List<int>();

        int[] x = new int[24];

        private void generisanje_liste()
        {
            for (int i = 1; i < 13; i++)
            {
                br_pitanja.Add(i);
            }
        }

        public int random_pitanje(string generisanje)
        {
            if (generisanje == "generisi")
            {
                br_pitanja = new List<int>();
                generisanje_liste();
            }

            id_pitanja = rnd.Next(1, 13);

            bool isInList = br_pitanja.IndexOf(id_pitanja) != -1;

            if (isInList == false)
            {
                random_pitanje("nastavi");
            }

            br_pitanja.Remove(id_pitanja);
            return id_pitanja;
        }  
        
        public int random_odgovor(string isprazni)
        {
            if(isprazni == "isprazni")
            {
                br_odgovora = new List<int>();
            }
            id_odgovora = rnd.Next(2, 6);
            bool isInList = br_odgovora.IndexOf(id_odgovora) != -1;
            if (isInList == false)
            {
                br_odgovora.Add(id_odgovora);
            }
            else random_odgovor("");
            return id_odgovora;
        }

        public int[] random_mem()
        {
            for (int i = 0; i < 24; i++) x[i] = i + 1;
            Random rnd = new Random();
            int[] x1 = x.OrderBy(x => rnd.Next()).ToArray();
            return x1;
        }

        //public int random_memorija()
        //{
        //    id_memorije = rnd.Next(1, 7);
        //    bool isInList = br_memorije.IndexOf(id_memorije) != -1;
        //    if (isInList == false)
        //    {
        //        br_memorije.Add(id_memorije);
        //    }
        //    else random_memorija();
        //    return id_memorije;
        //}
    }
}
