using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace WarcabyTrue
{
    public class Pionek
    {
        public int Id;
        public int Kolor;
        public bool Zbity;
        public int X;
        public int Y;
        public Pionek() { }

        public Pionek(int id, int kolor, bool zbity, int x, int y)
        {
            Id = id;
            Kolor = kolor;
            Zbity = zbity;
            X = x;
            Y = y;
        }
    }
}
