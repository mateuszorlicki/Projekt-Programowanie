using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjektSnake2
{
    public partial class Form1 : Form
    {
        private List<okrag> Snake = new List<okrag>();
        private okrag jedzenie = new okrag();
        public Form1()
        {
            InitializeComponent();

            //Ustawienia domyslne 
            new Ustawienia();
            // Ustawia szybkosci i czas gry
           // CzasGry.Interval = 1000 / Ustawienia.SzybWez;
            CzasGry.Tick += AktObraz;
            CzasGry.Start();
            
            //Zacznij nowa gre
            
            PoczatekGry();
        }
        private void PoczatekGry()
        {
            lblGameOver.Visible = false;

            //Ustawienia domyslne 
            new Ustawienia();
            //Tworzy obiekt nowy zawodnik
            Snake.Clear();
            okrag head = new okrag();
            head.X = 10;
            head.Y = 5;
            Snake.Add(head);
            labelscore.Text = Ustawienia.Zdobpkt.ToString();
            TworzenieJedzenia();

        }
        // Tworzy obiekt jedzenie na planszy gry randomowo
        private void TworzenieJedzenia()
        {
            int maxXPos = oknogry.Size.Width / Ustawienia.Szerokosc;
            int maxYPos = oknogry.Size.Height / Ustawienia.Wysokosc;

            Random random = new Random();
            jedzenie = new okrag();
            jedzenie.X = random.Next(0, maxXPos);
            jedzenie.Y = random.Next(0, maxYPos);
        }

        private void AktObraz(object sender, EventArgs e)
        {
             //Sprawdza czy gra zakonczona
             if(Ustawienia.KoniecGry==true)
            {
                //Sprawdza czy enter jest wcisniety
                if(wczytywanie.WcisPrzycisk(Keys.Enter))
                {
                    PoczatekGry();
                }
            }
             else
            {
                if (wczytywanie.WcisPrzycisk(Keys.Right) && Ustawienia.kierunek != Kierunek.Lewo)
                    Ustawienia.kierunek = Kierunek.Prawo;
                else if (wczytywanie.WcisPrzycisk(Keys.Left) && Ustawienia.kierunek != Kierunek.Prawo)
                    Ustawienia.kierunek = Kierunek.Lewo;
                else if (wczytywanie.WcisPrzycisk(Keys.Up) && Ustawienia.kierunek != Kierunek.Dol)
                    Ustawienia.kierunek = Kierunek.Gora;
                else if (wczytywanie.WcisPrzycisk(Keys.Down) && Ustawienia.kierunek != Kierunek.Gora)
                    Ustawienia.kierunek = Kierunek.Dol;
                RuchGracza();
            }
            oknogry.Invalidate();
        }

        private void oknogry_Paint(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;

            if (!Ustawienia.KoniecGry)
            {
                //Ustawia kolor weza
                Brush snakeColor;

                //Rysuje weza
                for (int i = 0; i < Snake.Count; i++)
                {

                    if (i == 0)
                    {


                        //Rysuje glowe
                        snakeColor = Brushes.Black;
                        canvas.FillRectangle(snakeColor,
                        new Rectangle(Snake[i].X * Ustawienia.Szerokosc,
                        Snake[i].Y * Ustawienia.Wysokosc,
                        Ustawienia.Szerokosc, Ustawienia.Wysokosc));
                        if (Ustawienia.kierunek == Kierunek.Lewo)
                        {
                            canvas.FillEllipse(Brushes.White, 
                                new Rectangle(Snake[i].X * Ustawienia.Szerokosc,
                                Snake[i].Y * Ustawienia.Szerokosc , 5, 5));

                            canvas.FillEllipse(Brushes.White, 
                                new Rectangle(Snake[i].X * Ustawienia.Szerokosc, 
                                Snake[i].Y * Ustawienia.Szerokosc+10, 5, 5));
                        }
                        if (Ustawienia.kierunek == Kierunek.Prawo)
                        {
                            canvas.FillEllipse(Brushes.White, 
                                new Rectangle(Snake[i].X * Ustawienia.Szerokosc + 10, 
                                Snake[i].Y * Ustawienia.Szerokosc, 5, 5));

                            canvas.FillEllipse(Brushes.White, 
                                new Rectangle(Snake[i].X * Ustawienia.Szerokosc + 10, 
                                Snake[i].Y * Ustawienia.Szerokosc + 10, 5, 5));
                        }
                        if (Ustawienia.kierunek == Kierunek.Gora)
                        {
                            canvas.FillEllipse(Brushes.White, 
                                new Rectangle(Snake[i].X * Ustawienia.Szerokosc, 
                                Snake[i].Y * Ustawienia.Szerokosc, 5, 5));

                            canvas.FillEllipse(Brushes.White, 
                                new Rectangle(Snake[i].X * Ustawienia.Szerokosc + 10, 
                                Snake[i].Y * Ustawienia.Szerokosc, 5, 5));
                        }
                        if (Ustawienia.kierunek == Kierunek.Dol)
                        {
                            canvas.FillEllipse(Brushes.White, new Rectangle(Snake[i].X * Ustawienia.Szerokosc + 10, Snake[i].Y * Ustawienia.Szerokosc + 10, 5, 5));
                            canvas.FillEllipse(Brushes.White, new Rectangle(Snake[i].X * Ustawienia.Szerokosc, Snake[i].Y * Ustawienia.Szerokosc + 10, 5, 5));
                        }

                    }
                    else
                    {
                        snakeColor = Brushes.Green;
                        canvas.FillRectangle(snakeColor,
                        new Rectangle(Snake[i].X * Ustawienia.Szerokosc,
                        Snake[i].Y * Ustawienia.Wysokosc,
                        Ustawienia.Szerokosc, Ustawienia.Wysokosc));
                    }
                        //Rysuje reszte ciala
                        snakeColor = Brushes.Green;
                    //Rysuje weza

                    
                    //Rysuje jedzenie
                    canvas.FillEllipse(Brushes.Red,
                        new Rectangle(jedzenie.X * Ustawienia.Szerokosc,
                                 jedzenie.Y * Ustawienia.Wysokosc,
                                 Ustawienia.Szerokosc, Ustawienia.Wysokosc));



                }
            }
            else
            {
                string KoniecGry = "Koniec Gry!\n Twoj wynik to: " + Ustawienia.Zdobpkt  + "\nNacisnij Enter aby zagrac jeszcze raz";
                lblGameOver.Text = KoniecGry;
                lblGameOver.Visible = true;
            }
        }
            private void RuchGracza()
        {
            for (int i = Snake.Count-1;i>=0;i--)
            {
                // Rusza glowa
                if ( i ==0 )
                {
                    switch(Ustawienia.kierunek)
                    {
                        case Kierunek.Prawo:
                        Snake[i].X++;
                            break;
                        case Kierunek.Lewo:
                            Snake[i].X--;
                            break;
                        case Kierunek.Dol:
                            Snake[i].Y++;
                            break;
                        case Kierunek.Gora:
                            Snake[i].Y--;
                            break;

                    }

                    //Max pozycja X i Y 
                    int maxXPos = oknogry.Size.Width / Ustawienia.Szerokosc;
                    int maxYPos = oknogry.Size.Height / Ustawienia.Wysokosc;

                    //kolizja z ramka, gdy kolizja = koniecgry
                    if (Snake[i].X<0 || Snake[i].Y<0 
                        || Snake[i].X >=maxXPos || Snake[i].Y>=maxYPos)
                   
                    {
                        fkoniecgry();
                    }

                    //kolizja z cialem weza, kolizja = koneicgry
                    for (int j = 1;j<Snake.Count;j++)
                    {
                        if(Snake[i].X==Snake[j].X && Snake[i].Y==Snake[j].Y)
                        {
                           fkoniecgry();
                        }

                    }
                    //kolizja z jedzeniem, kolizja = wyk, fjedzenie (dodaje klocek do dl weza)

                if(Snake[0].X==jedzenie.X && Snake[0].Y==jedzenie.Y)
                    {
                        fjedzenie(); 
                    }
                }
                else
                {
                    //Przesuwa cialo

                    Snake[i].X = Snake[i - 1].X;
                    Snake[i].Y = Snake[i - 1].Y;
                } 
            }
        }

        private void fkoniecgry()
        {
            Ustawienia.KoniecGry = true;
        }

        private void fjedzenie()
        {
            //Dodanie okreagu do ciala weza
            okrag jedzenie = new okrag();
            jedzenie.X = Snake[Snake.Count - 1].X;
            jedzenie.Y = Snake[Snake.Count - 1].Y;
            Ustawienia.SzybWez = Ustawienia.SzybWez + 2;
            Snake.Add(jedzenie);

            //aktualizuje wynik
            Ustawienia.Zdobpkt += Ustawienia.Punkty;
            labelscore.Text = Ustawienia.Zdobpkt.ToString();
            TworzenieJedzenia();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            wczytywanie.ZmianaStanu(e.KeyCode,true);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            wczytywanie.ZmianaStanu(e.KeyCode, false);
        }

        private void oknogry_Click(object sender, EventArgs e)
        {

        }
    }
    }

