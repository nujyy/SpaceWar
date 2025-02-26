using System;
using System.Drawing;
using System.Windows.Forms;
using static System.Formats.Asn1.AsnWriter;
using System.Collections.Generic;
using SPAVEWAR;

namespace SPAVEWAR
{

    public partial class spaceship : Form
    {

        // Çarpışma Algılama Classinin Cagirilmasi
        private CollisionDetector collisionDetector;
        // Oyun Classinin Cagirilmasi
        private GameOyun game;
  
        // SpaceShip sınıfından bir nesne oluşturuyoruz
        private SpaceShip playerShip;
        private List<Bullet> bullets; // Mermiler için bir liste
        public spaceship()
        {
            InitializeComponent();
            lbl_over.Hide();
            playerShip = new SpaceShip(SpaceShip1);
            collisionDetector = new CollisionDetector();
            game = new GameOyun();
            bullets = new List<Bullet>(); // Mermileri saklamak için bir liste oluştur
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            game.StartGame(); // Oyunu başlat
        }

        bool right, left, space;
        public int score;

        public void CheckHealth()
        {
            if (playerShip.IsDestroyed())
            {
                timer1.Stop();
                lbl_over.Show();
                lbl_over.BringToFront();
            }
        }

        public void game_result()
        {
            // Kontrol edilen mermiler ve düşmanlar listesini topluca değiştirmek için bir liste tanımlıyoruz
            List<Control> bulletsToRemove = new List<Control>();

            foreach (Control j in this.Controls)
            {
                if (j is PictureBox && j.Tag == "bullet")
                {
                    foreach (Control i in this.Controls)
                    {                  
                        if (i is PictureBox && i.Tag == "enemy")
                        {
                            if (j.Bounds.IntersectsWith(i.Bounds))
                            {
                                // Düşman yok ediliyor
                                i.Top = -100; // Yeniden başlatmak için yukarı gönderiyoruz
                                              // Düşman türüne göre puan ekleme
                                if (i is BasicEnemy1)
                                {
                                    score += 10;
                                }
                                else if (i is FastEnemy1)
                                {
                                    score += 15;
                                }
                                else if (i is StrongEnemy1)
                                {
                                    score += 20;
                                }
                                else if (i is BossEnemy1)
                                {
                                    score += 25;
                                }
                                // Mermi kaldırılmak üzere işaretleniyor
                                bulletsToRemove.Add(j);

                                // Skoru artırıyoruz
                                score += 10;
                                lbl_score.Text = "score : " + score;

                                // Her çarpışma sadece bir kez işlenir
                                break;
                            }
                        }
                    }
                }
            }

            // Çarpışan mermileri kontrol listesinden kaldırıyoruz
            foreach (Control bullet in bulletsToRemove)
            {
                this.Controls.Remove(bullet);
                bullet.Dispose();  // bullet nesnesini serbest bırakır.
            }

            // Oyunun bitiş durumunu kontrol ediyoruz
            if (SpaceShip1.Bounds.IntersectsWith(BasicEnemy1.Bounds) ||
                SpaceShip1.Bounds.IntersectsWith(FastEnemy1.Bounds) ||
                SpaceShip1.Bounds.IntersectsWith(StrongEnemy1.Bounds) ||
                SpaceShip1.Bounds.IntersectsWith(BossEnemy1.Bounds))
            {
                timer1.Stop();
                lbl_over.Show();
                lbl_over.BringToFront();
            }
        }


        public void star()
        {
            foreach (Control j in this.Controls)
            {
                if (j is PictureBox && j.Tag == "stars")
                {
                    j.Top += 15;
                    if (j.Top > 606)
                    {
                        j.Top = 0;
                    }
                }
            }
        }

        void Add_Bullet()
        {
            PictureBox bullet = playerShip.Shoot();
            this.Controls.Add(bullet);
            bullet.BringToFront();
        }

        public void Bullet_Movement()
        {
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && x.Tag == "bullet")
                {
                    Bullet bullet = new Bullet((PictureBox)x, 10, 20, 1); // Örnek olarak hız=10, hasar=20, yön=1 (yukarı)
                    bullet.Move();
                }
            }
        }

        public void Enemy_Movement()
        {
            Random rnd = new Random();
            int x, y, z, d;
            if (BasicEnemy1.Top >= 706)
            {
                x = rnd.Next(0, 300);
                BasicEnemy1.Location = new Point(x, 0);
            }
            if (FastEnemy1.Top >= 706)
            {
                y = rnd.Next(0, 300);
                FastEnemy1.Location = new Point(y, 0);
            }
            if (StrongEnemy1.Top >= 706)
            {
                z = rnd.Next(0, 300);
                StrongEnemy1.Location = new Point(z, 0);
            }
            if (BossEnemy1.Top >= 706)
            {
                d = rnd.Next(0, 300);
                BossEnemy1.Location = new Point(d, 0);
            }
            else
            {
                BasicEnemy1.Top += 15;
                FastEnemy1.Top += 19;
                StrongEnemy1.Top += 10;
                BossEnemy1.Top += 10;
            }
        }

        public void Asteroid_Movement()
        {
            foreach (Control control in this.Controls)
            {
                if (control is PictureBox && (control.Name == "asteroid" || control.Name == "asteroid1" || control.Name == "asteroid2" || control.Name == "asteroid3"))
                {
                    control.Top += 10;

                    if (control.Top > this.Height)
                    {
                        control.Top = 0;
                        control.Left = new Random().Next(0, this.Width - control.Width);
                    }

                    if (control.Bounds.IntersectsWith(SpaceShip1.Bounds))
                    {
                        playerShip.TakeDamage(10); // Çarpışma durumunda hasar uygula
                    }
                }
            }
        }

        public void Arrow_key_Movement()
        {
            if (right == true)
            {
                playerShip.Move("right");
                //if (SpaceShip1.Left < 600)
                //{
                //    SpaceShip1.Left += 20;
                //}
            }
            if (left == true)
            {
                playerShip.Move("left");
                //if (SpaceShip1.Left > 10)
                //{
                //    SpaceShip1.Left -= 20;
                //}
            }
        }

        private void spaceship_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                right = true;
            }
            if (e.KeyCode == Keys.Left)
            {
                left = true;
            }
            if (e.KeyCode == Keys.Space)
            {
                space = true; 
                Add_Bullet();
            }
        }

        private void spaceship_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                right = false;
            }
            if (e.KeyCode == Keys.Left)
            {
                left = false;
            }
            if (e.KeyCode == Keys.Space)
            {
                space = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Arrow_key_Movement();
            Enemy_Movement();
            Bullet_Movement();
            star();
            game_result();
            CheckHealth();
            Asteroid_Movement();
        }
    }
}

