using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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
        string piont = "😎";
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
                        przyciski[i, j].BorderWidth = 2;
                        przyciski[i, j].Text = pion;

                        dupa = false;
                    }
                    else
                    {
                        przyciski[i, j] = new Pole(dupa);
                        przyciski[i, j].BackgroundColor = Color.White;
                        przyciski[i, j].BorderWidth = 2;
                        dupa = true;
                    }
                    przyciski[i, j].Clicked += new EventHandler(this.Ruch);
                    PlanszaLayout.Children.Add(przyciski[i, j], j, i);
                }
                if (i == 2)
                    pion = null;
                if (i == 4)
                    pion = "😎";
                if (dupa == true)
                {
                    dupa = false;
                }
                else { dupa = true; }
            }
        }
        private void Ruch(object sender, System.EventArgs e)
        {
            Deb();
            var but = sender as Pole;
            if (but.BorderColor == Color.Red)
            {
                but.BorderColor = Color.Green;
                
                if(Math.Abs(Grid.GetColumn(but)- tempx) == 2)
                {
                    przyciski[tempy + (Grid.GetRow(but) - tempy)/2, tempx+(Grid.GetColumn(but) - tempx)/2].Text = null;
                }
                but.Text = pion;
                przyciski[tempy, tempx].Text = null;
                TipClear();
                if (piont == "😎")
                    piont = "😡";
                else
                    piont = "😎";
            }
            else if(but.Text == piont)
            {
                TipClear();
                tempx = Grid.GetColumn(but);
                tempy = Grid.GetRow(but);
                pion = but.Text;
                if (przyciski[tempy, tempx].Text != null)
                    for (int i = -1; i <= 1; i += 2)
                        for (int j = -1; j <= 1; j += 2)
                        {
                            if (tempy + i >= 0 && tempy + i < 8 && tempx + j >= 0 && tempx + j < 8 && przyciski[tempy + i, tempx + j].Text == null)
                            {
                                if (przyciski[tempy, tempx].Text == "😎")
                                    if (i < 0)
                                    {
                                        przyciski[tempy + i, tempx + j].BorderColor = Color.Red;
                                    }

                                if (przyciski[tempy, tempx].Text == "😡")
                                    if (i > 0)
                                    {
                                        przyciski[tempy + i, tempx + j].BorderColor = Color.Red;
                                    }
                            }
                            else if (tempy + i >= 0 && tempy + i < 8 && tempx + j >= 0 && tempx + j < 8 && przyciski[tempy + i, tempx + j].Text != pion && przyciski[tempy + i, tempx + j].Text != null)
                            {
                                if (tempy + (i * 2) < 8 && tempy + (i * 2) > 0 && tempx + (i * 2) < 8 && tempx + (i * 2) > 0)
                                    if (przyciski[tempy + (i * 2), tempx + (j * 2)].Text == null)
                                    {
                                        przyciski[tempy + (i * 2), tempx + (j * 2)].BorderColor = Color.Red;
                                    }
                            }

                        }
            }
        }

        private void TipClear()
        {
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    przyciski[i, j].BorderColor = Color.Transparent;
        }
        protected void Deb()
        {
            string s="";
            Debug.WriteLine("---------- OnStart called!");
            for(int i = 0; i < 8; i++)
            {
                for(int j = 0; j <8; j++)
                {
                    if (przyciski[i, j].Text != null)
                        s += przyciski[i, j].Text;
                    else
                        s += "  ";
                }
                Debug.WriteLine(s);
                s = "";
            }
            
        }
    }
}
