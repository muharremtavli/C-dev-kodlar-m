using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace arabaYarisiOyunum
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int SeritSayisi = 1, Road = 0, Speed = 70;

        Random R = new Random();

        class Random_Car
        {
            public bool FakeHaveCar = false;
            public PictureBox FakeCar;
            public bool vakit = false;
        }

        Random_Car[] rndCar = new Random_Car[2];

        void BringRandomCar(PictureBox pb)
        {
            int rnd = R.Next(0, 4);

            switch (rnd)
            {
                case 0:
                    pb.Image = Properties.Resources.car0;
                    break;
                case 1:
                    pb.Image = Properties.Resources.car1;
                    break;
                case 2:
                    pb.Image = Properties.Resources.car2;
                    break;
                case 3:
                    pb.Image = Properties.Resources.car3;
                    break;
            }

            pb.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void AracYerine()
        {
            if (SeritSayisi == 1)
            {
                RedCar.Location = new Point(291, 442);
            }
            else if (SeritSayisi == 0)
            {
                RedCar.Location = new Point(75, 442);
            }
            else if (SeritSayisi == 2)
            {
                RedCar.Location = new Point(520, 442);
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
            {
                if (SeritSayisi < 2)
                    SeritSayisi++;
            }
            else if ( e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
            {
                if (SeritSayisi > 0)
                    SeritSayisi--;
            }

            AracYerine();
        }

        private void RabdomMusicEkle()
        {
            int MuzikDeger = R.Next(1,4);
            axWindowsMediaPlayer1.URL = @"music/track" + MuzikDeger.ToString() + ".mp3";
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for( var i = 0; i< rndCar.Length; i++)
            {
                rndCar[i] = new Random_Car();
            }
            rndCar[0].vakit = true;

            AracYerine();
            RabdomMusicEkle();
        }

        bool SesKontrol = true;
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (SesKontrol == true)
            {
                SesKontrol = false;
                axWindowsMediaPlayer1.Ctlcontrols.pause();
                pictureBox2.Image = Properties.Resources.volumeOff;
            }
            else if ( SesKontrol == false)
            {
                SesKontrol = true;
                axWindowsMediaPlayer1.Ctlcontrols.play();
                pictureBox2.Image = Properties.Resources.volumeON;
            }
        }

        private void timerRandomCar_Tick(object sender, EventArgs e)
        {
            for(int i = 0; i < rndCar.Length; i++)
            {
                if ( !rndCar[i].FakeHaveCar && rndCar[i].vakit)
                {
                    rndCar[i].FakeCar = new PictureBox();
                    BringRandomCar(rndCar[i].FakeCar);
                    rndCar[i].FakeCar.Size = new Size(90, 150);
                    rndCar[i].FakeCar.Top = -rndCar[i].FakeCar.Height;

                    int SeriteYerlestir = R.Next(0, 3);
                    
                    if (SeriteYerlestir == 0)
                    {
                        rndCar[i].FakeCar.Left = 75;
                    }
                    if (SeriteYerlestir == 1)
                    {
                        rndCar[i].FakeCar.Left = 291;
                    }
                    if (SeriteYerlestir == 0)
                    {
                        rndCar[i].FakeCar.Left = 520;
                    }

                    this.Controls.Add(rndCar[i].FakeCar);
                    rndCar[i].FakeHaveCar = true;
                }
                else
                {
                    if (rndCar[i].vakit)
                    {
                        rndCar[i].FakeCar.Top += 20;
                        if (rndCar[i].FakeCar.Top >= 154)
                        {
                            for (int j = 0; j < rndCar.Length; j++)
                            {
                                if (!rndCar[j].vakit)
                                {
                                    rndCar[j].vakit = true;
                                    break;
                                }
                            }
                        }
                        if (rndCar[i].FakeCar.Top >= this.Height - 20)
                        {
                            rndCar[i].FakeCar.Dispose();
                            rndCar[i].FakeHaveCar = false;
                            rndCar[i].vakit = false;
                        }
                    }

                }

                // Kaza durumu

            if (rndCar[i].vakit)
                {
                    float MutlakX = Math.Abs((RedCar.Left + (RedCar.Width / 2)) - (rndCar[i].FakeCar.Left + (rndCar[i].FakeCar.Width/ 2)));
                    float MutlakY = Math.Abs((RedCar.Top + (RedCar.Height / 2)) - (rndCar[i].FakeCar.Top + (rndCar[i].FakeCar.Height / 2)));
                    float FarkGenislik = (RedCar.Width / 2) + (rndCar[i].FakeCar.Width / 2);
                    float FarkYukseklik = (RedCar.Height / 2) + (rndCar[i].FakeCar.Height / 2);

                    if ((FarkGenislik > MutlakX) && (FarkYukseklik > MutlakY))
                    {
                        timerRandomCar.Enabled = false;
                        timerSerit.Enabled = false;
                        axWindowsMediaPlayer1.Ctlcontrols.pause();
                        axWindowsMediaPlayer1.URL = @"music/crash.mp3";
                        axWindowsMediaPlayer1.Ctlcontrols.play();

                        if (Road > Settings1.Default.HighScore)
                        {
                            MessageBox.Show("New High Score ==> " + Road.ToString() + "m", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Settings1.Default.HighScore = Road;
                            Settings1.Default.Save();

                            labelRekor.Text = Settings1.Default.HighScore.ToString();
                        }

                        DialogResult dr = MessageBox.Show("Oyun bitti ! Yeniden denemek ister misiniz?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dr == DialogResult.Yes)
                        {
                            AracYerine();
                            
                            for (int j = 0; j < rndCar.Length; j++)
                            {
                                rndCar[j].FakeCar.Dispose();
                                rndCar[j].FakeHaveCar = false;
                                rndCar[j].vakit = false;
                            }

                            Road = 0;
                            Speed = 70;
                            rndCar[0].vakit = true;
                            timerRandomCar.Enabled = true;
                            timerRandomCar.Interval = 200;

                            RabdomMusicEkle();
                            axWindowsMediaPlayer1.Ctlcontrols.play();

                            labelRekor.Text = Settings1.Default.ToString();
                        }
                        else
                        {
                            this.Close();
                        }
                    }
                }
            }
        }

        bool SeritHareket = false;

        void HizLevel()
        {
            //2. seviye
            if (Road > 150 && Road < 300)
            {
                Speed = 100;
                timerSerit.Interval = 125;
                timerRandomCar.Interval = 100;
            }

            //3. seviye
            else if (Road > 300 && Road < 550)
            {
                Speed = 130;
                timerSerit.Interval = 100;
                timerRandomCar.Interval = 80;
            }

            //4. seviye
            else if (Road > 550)
            {
                Speed = 170;
                timerSerit.Interval = 80;
                timerRandomCar.Interval = 20;
            }
        }


        private void timerSerit_Tick(object sender, EventArgs e)
        {
            if (SeritHareket == false)
            {
                Road++;

                HizLevel();

                for ( int i = 1; i < 7; i++)
                {
                    this.Controls.Find("labelSolSerit" + i.ToString(), true)[0].Top -= 25;
                    this.Controls.Find("labelSagSerit" + i.ToString(), true)[0].Top -= 25;
                    SeritHareket = true;
                }
            }
            else
            {
                for (int i = 1; i < 7; i++)
                {
                    this.Controls.Find("labelSolSerit" + i.ToString(), true)[0].Top += 25;
                    this.Controls.Find("labelSagSerit" + i.ToString(), true)[0].Top += 25;
                    SeritHareket = false;
                }
            }
            labelYol.Text = Road.ToString() + "m";
            labelHiz.Text = Speed.ToString() + "km/h";
        }
    }
}
