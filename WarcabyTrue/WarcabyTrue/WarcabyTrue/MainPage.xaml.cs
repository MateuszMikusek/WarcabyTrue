using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace WarcabyTrue
{
    public partial class MainPage : ContentPage
    {
        Button[,] przyciski = new Button[8, 8];
        bool dupa = false;
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
                        dupa = false;
                    }
                    else
                    {
                        przyciski[i, j] = new Pole(dupa);
                        przyciski[i, j].BackgroundColor = Color.White;
                        dupa = true;
                    }
                    PlanszaLayout.Children.Add(przyciski[i, j], i, j);
                }
                if (dupa == true)
                {
                    dupa = false;
                }
                else { dupa = true; }
            }
        }
    }
}
