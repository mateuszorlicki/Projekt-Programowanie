using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektSnake2
{
    public enum Kierunek {
        Gora,Dol,Lewo,Prawo
    };
    class Ustawienia
    {
        public static int Szerokosc { get; set; }
        public static int Wysokosc { get; set; }
        public static  int SzybWez { get; set; }
        public static int Zdobpkt { get; set; }
        public static int Punkty { get; set; }
        public static bool KoniecGry { get; set; }
        public static Kierunek kierunek { get; set; }

        public Ustawienia()
        {
            Szerokosc = 16;
            Wysokosc = 16;
            SzybWez = 5;
            Zdobpkt = 0;
            Punkty = 1;
            KoniecGry = false;
            kierunek = Kierunek.Prawo;
        }
    }
}
