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
        bool zbicie = false;
        int tempoy;
        int tempox;
        bool zbijacz = false;
        
        public MainPage()
        {
            InitializeComponent();
            GeneratePlansza();
        }

        private void GeneratePlansza()
        {
            pion = "😡";
            piont = "😎";
            dupa = false;
            zbicie = false;
            zbijacz = false;
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
            var but = sender as Pole;
            
            Przymus();
            if (but.BorderColor == Color.Red)
                Bicie(but);
                
            else
                TipClear();
            
            pion = but.Text;
            Propozycja(but);

        }
        public void Propozycja(Pole but)
        {
            tempx = Grid.GetColumn(but);
            tempy = Grid.GetRow(but);
            bool bici = true;
            if (przyciski[tempy, tempx].Text == piont && przyciski[tempy, tempx].Movable)
            {
                for (int i = -1; i <= 1; i += 2)
                    for (int j = -1; j <= 1; j += 2)
                    {

                        if (tempy + i >= 0 && tempy + i < 8 && tempx + j >= 0 && tempx + j < 8 && przyciski[tempy + i, tempx + j].Text != przyciski[tempy, tempx].Text && przyciski[tempy + i, tempx + j].Text != null)
                        {
                            if (tempy + (i * 2) >= 0 && tempy + (i * 2) < 8 && tempx + (j * 2) >= 0 && tempx + (j * 2) < 8)
                            {
                                if (przyciski[tempy + (i * 2), tempx + (j * 2)].Text == null)
                                {
                                    TipClear();
                                    przyciski[tempy + (i * 2), tempx + (j * 2)].BorderColor = Color.Red;
                                    zbicie = true;
                                    tempoy = tempy + i;
                                    tempox = tempx + j;
                                    bici = false;


                                }
                            }
                        }
                    }
                if (bici)
                {
                    for (int i = -1; i <= 1; i += 2)
                        for (int j = -1; j <= 1; j += 2)
                        {
                            if (tempy + i >= 0 && tempy + i < 8 && tempx + j >= 0 && tempx + j < 8 && przyciski[tempy + i, tempx + j].Text == null)
                            {
                                if (przyciski[tempy, tempx].Text == "😎" && przyciski[tempy, tempx].BackgroundColor == Color.Black)
                                {
                                    if (i < 0)
                                    {

                                        przyciski[tempy + i, tempx + j].BorderColor = Color.Red;

                                    }
                                }
                                else if (przyciski[tempy, tempx].Text == "😎" && przyciski[tempy, tempx].BackgroundColor == Color.Gold)
                                {
                                    KrolewskiRuch(tempy, tempx);
                                }

                                if (przyciski[tempy, tempx].Text == "😡" && przyciski[tempy, tempx].BackgroundColor == Color.Black)
                                {
                                    if (i > 0)
                                    {

                                        przyciski[tempy + i, tempx + j].BorderColor = Color.Red;

                                    }
                                }
                                else if (przyciski[tempy, tempx].Text == "😡" && przyciski[tempy, tempx].BackgroundColor == Color.Gold)
                                {
                                    KrolewskiRuch(tempy, tempx);
                                }

                            }
                        }
                }
            }
        }
        
        private void Przymus()
        {
            zbijacz = false;
            for (int tempy = 0; tempy < 8; tempy++)
            {
                for (int tempx = 0; tempx < 8; tempx++)
                {
                    przyciski[tempy, tempx].Movable = false;
                }
            }

            for (int tempy = 0; tempy < 8; tempy++)
            {
                for (int tempx = 0; tempx < 8; tempx++)
                {
                    if (przyciski[tempy, tempx].Text == piont && przyciski[tempy, tempx].BackgroundColor == Color.Black)
                        for (int i = -1; i <= 1; i += 2)
                            for (int j = -1; j <= 1; j += 2)
                            {
                                if (tempy + i >= 0 && tempy + i < 8 && tempx + j >= 0 && tempx + j < 8 && przyciski[tempy + i, tempx + j].Text != przyciski[tempy, tempx].Text && przyciski[tempy + i, tempx + j].Text != null)
                                {
                                    if (tempy + (i * 2) >= 0 && tempy + (i * 2) < 8 && tempx + (j * 2) >= 0 && tempx + (j * 2) < 8)
                                    {
                                        if (przyciski[tempy + (i * 2), tempx + (j * 2)].Text == null)
                                        {
                                            przyciski[tempy, tempx].Movable = true;

                                            zbijacz = true;
                                            



                                        }
                                    }
                                }
                            }
                    else if (przyciski[tempy, tempx].Text == piont && przyciski[tempy, tempx].BackgroundColor == Color.Gold)
                    {

                    }
                }
            }
            if (zbijacz == false)
            {
                for (int tempy = 0; tempy < 8; tempy++)
                {
                    for (int tempx = 0; tempx < 8; tempx++)
                    {
                        przyciski[tempy, tempx].Movable = true;
                    }
                }
            }

        }
        private void EndTurn() // zmienia turę
        {
            if (piont == "😎")
                piont = "😡";
            else if (piont == "😡")
                piont = "😎";
            zbicie = false;
            
        }

        public bool PropozycjaPoBiciu(int tempx, int tempy)
        {
            Debug.WriteLine(tempx + "   " + tempy);

            for (int i = -1; i <= 1; i += 2)
                for (int j = -1; j <= 1; j += 2)
                {

                    if (tempy + i >= 0 && tempy + i < 8 && tempx + j >= 0 && tempx + j < 8 && przyciski[tempy + i, tempx + j].Text != przyciski[tempy, tempx].Text && przyciski[tempy + i, tempx + j].Text != null)
                    {
                        Debug.WriteLine("1");
                        if (tempy + (i * 2) >= 0 && tempy + (i * 2) < 8 && tempx + (j * 2) >= 0 && tempx + (j * 2) < 8)
                        {
                            Debug.WriteLine("2");
                            if (przyciski[tempy + (i * 2), tempx + (j * 2)].Text == null)
                            {
                                zbicie = true;
                                tempoy = tempy + i;
                                tempox = tempx + j;
                                Debug.WriteLine("Tru");
                                return true;

                            }
                        }
                    }
                }


            Debug.WriteLine("Falso");
            return false;
        }

        private void Bicie(Pole but)    //Zbicie + przesunięcie
        {
            if (zbicie == true)
            {

                przyciski[tempoy, tempox].Text = null;
                przyciski[tempoy, tempox].BackgroundColor = Color.Black;
                zbicie = false;
                tempoy = 0;
                
                if (PropozycjaPoBiciu(Grid.GetRow(but), Grid.GetColumn(but)))
                    EndTurn();
                
            }
            else
            {
                EndTurn();
            }
            but.BackgroundColor = przyciski[tempy, tempx].BackgroundColor;
            przyciski[tempy, tempx].BackgroundColor = Color.Black;
            but.Text = pion;
            CreateKrolowa(Grid.GetColumn(but), Grid.GetRow(but));
            przyciski[tempy, tempx].Text = null;
            
            TipClear();
            
            
            Win();
        }
        public void MovableBlock() //przy podwójnym biciu blokuje resztę pionków
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    przyciski[i, j].Movable = false;
                }
            }
        }
        public void MovableReset() //robi odblok pionków po MovableBlock
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    przyciski[i, j].Movable = true;
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
            string s = "";
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
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

        public async void Win()
        {
            bool cool = false, mad = false;
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                {
                    if (przyciski[i, j].Text == "😡")
                        mad = true;
                    else if (przyciski[i, j].Text == "😎")
                        cool = true;
                }
            if (!cool) {
                await DisplayAlert("koniec gry", "Wygrywa 😡 ", "OK");
                GeneratePlansza();
            }

            if (!mad)
            {
                await DisplayAlert("koniec gry", "Wygrywa 😎 ", "OK");
                GeneratePlansza();
            }
        }

            public void CreateKrolowa(int Y, int X)
            {
                if (piont == "😎" && X == 0)
                {
                    przyciski[X, Y].BackgroundColor = Color.Gold;

                }
                else if (piont == "😡" && X == 7)
                {
                    przyciski[X, Y].BackgroundColor = Color.Gold;
                }

            }

            public void KrolewskiRuch(int Y, int X)
            {
                int blok = 0;
                bool blok_truel = false;
                for (int m = -1; m <= 1; m += 2) // Y
                {
                    for (int n = -1; n <= 1; n += 2) // X
                    {
                        blok = 0;
                        blok_truel = false;
                        for (int i = 1; i <= 7; i++)
                        {
                            if (Y + (m * i) >= 0 && Y + (m * i) < 8 && X + (n * i) >= 0 && X + (n * i) < 8 && przyciski[Y + (m * i), X + (n * i)].Text == null && blok_truel == false)
                            {
                                blok = 0;
                                przyciski[Y + (m * i), X + (n * i)].BorderColor = Color.Red;
                            }
                            else if (Y + (m * i) >= 0 && Y + (m * i) < 8 && X + (n * i) >= 0 && X + (n * i) < 8 && przyciski[Y + (m * i), X + (n * i)].Text == przyciski[Y, X].Text)
                            {
                                blok += 2;
                            }
                            else if (Y + (m * i) >= 0 && Y + (m * i) < 8 && X + (n * i) >= 0 && X + (n * i) < 8 && przyciski[Y + (m * i), X + (n * i)].Text != przyciski[Y, X].Text)
                            {
                                blok += 1;
                            }
                            if (blok == 2)
                            {
                                blok_truel = true;
                            }

                        }
                    }
                }










            }


        }
    }
