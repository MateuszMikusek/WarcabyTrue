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

        private void zbijanie_Check(int tempx, int tempy)
        {
            for(int i = 0;  i < 4; i++)
            {
                
                switch(i)
                {

                    case 1:
                        
                            if (tempy != 0 || tempx != 0 || tempx != 1 || tempy != 1)
                            {
                                if (przyciski[tempy, tempx].Text != przyciski[tempy - 1, tempx - 1].Text || przyciski[tempy - 1, tempx - 1].Text != "")
                                {
                                    if (przyciski[tempy - 2, tempx - 2].Text == "")
                                    {
                                        przyciski[tempy - 2, tempx - 2].BorderColor = Color.Red;
                                    }
                                }
                            }
                        
                        break; 
                    case 2:
                        if (tempy != 0 || tempx != 6 || tempx != 7 || tempy != 1)
                        {
                            if (przyciski[tempy, tempx].Text != przyciski[tempy + 1, tempx - 1].Text || przyciski[tempy + 1, tempx - 1].Text != "")
                            {
                                if (przyciski[tempy + 2, tempx - 2].Text == "")
                                {
                                    przyciski[tempy + 2, tempx - 2].BorderColor = Color.Red;
                                }
                            }
                        }
                        break;
                    case 3:
                        if (tempy != 7 || tempx != 0 || tempx != 1 || tempy != 7)
                        {
                            if (przyciski[tempy, tempx].Text != przyciski[tempy - 1, tempx + 1].Text || przyciski[tempy - 1, tempx + 1].Text != "")
                            {
                                if (przyciski[tempy - 2, tempx + 2].Text == "")
                                {
                                    przyciski[tempy - 2, tempx + 2].BorderColor = Color.Red;
                                }
                            }
                        }
                        break;
                    case 4:
                        if (tempy != 7 || tempx != 6 || tempx != 7 || tempy != 6)
                        {
                            if (przyciski[tempy, tempx].Text != przyciski[tempy - 1, tempx - 1].Text || przyciski[tempy - 1, tempx - 1].Text != "")
                            {
                                if (przyciski[tempy - 2, tempx - 2].Text == "")
                                {
                                    przyciski[tempy - 2, tempx - 2].BorderColor = Color.Red;
                                }
                            }
                        }
                        break;
                }
            }

        }
    }
}
