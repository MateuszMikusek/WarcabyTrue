using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace WarcabyTrue
{
    public partial class MainPage : ContentPage
    {
        Pole[,] przyciski = new Pole[8, 8];
        bool dupa = false;
        string pion = "😡";
        int tempx;
        int tempy;
        public MainPage()
        {
            InitializeComponent();
            GeneratePlansza();
            

            
            
            
        }

        private void GeneratePlansza()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    
                    if (dupa == true)
                    {
                        przyciski[i, j] = new Pole(dupa);
                        przyciski[i, j].BackgroundColor = Color.Black;
                        przyciski[i,j].Text=pion;
                        dupa = false;
                    }
                    else
                    {
                        przyciski[i, j] = new Pole(dupa);
                        przyciski[i, j].BackgroundColor = Color.White;
                        dupa = true;
                    }
                    PlanszaLayout.Children.Add(przyciski[i, j], j, i);
                }
                if (i == 2)
                    pion = null;
                if (i == 4)
                    pion ="😎";
                if (dupa == true)
                {
                    dupa = false;
                }
                else { dupa = true; }
            }
        }
        private void Ruch(object sender, System.EventArgs e)
        {
            var but = sender as Pole;
            if (tempx == null)
            {
                tempx = Grid.GetColumn(but);
                tempy = Grid.GetRow(but);
            }
            else
            {

            }
            
            
        }

        private void zbijanie_Check(int tempx, int tempy, Pionek pionek)
        {
            for(int i = 0;  i < 4; i++)
            {
                switch(i)
                {

                    case 1:
                        if(tempy != 0 || tempx != 0)
                        {
                            if (pionek.Kolor == przyciski[] )
                            {

                            }
                        }
                        break; 
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                }
            }

        }
    }
}
