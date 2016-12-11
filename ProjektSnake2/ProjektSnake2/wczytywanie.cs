using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace ProjektSnake2
{
    class wczytywanie
    {
        //Wczytywanie listy wolnych klawiszy
        private static Hashtable klucztab = new Hashtable();

        //Sprawdza czy wybranych przycisk jest wcisniety
        public static bool WcisPrzycisk(Keys klucz)
        {
            if(klucztab[klucz]==null)
            {
                return false;
            }
            return (bool)klucztab[klucz];
        }
        // Wyszukuje jesli przycisk jest wcisniety
        public static void ZmianaStanu(Keys klucz,bool state)
        {
            klucztab[klucz] = state;
        }
    }
}
