using System;
using System.Collections.Generic;
using System.Text;

namespace WarcabyTrue
{
    public class Pionek
    {
        public int Id;
        public int Kolor;
        public bool Zbity;
        public Pionek() { }

        public Pionek(int id, int kolor, bool zbity)
        {
            Id = id;
            Kolor = kolor;
            Zbity = zbity;
        }
    }
}
