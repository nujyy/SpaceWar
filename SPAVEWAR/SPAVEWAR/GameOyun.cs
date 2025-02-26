using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Numerics;
using System.Windows.Forms;
using static System.Formats.Asn1.AsnWriter;
//using System.Text;
//using System.Threading.Tasks;

namespace SPAVEWAR
{
    public class GameOyun
    {
        private object score;

        // Spaceship player: Oyuncunun uzay aracı.
        public SpaceShip Player { get; private set; }
        //List<Enemy> enemies: Oyundaki düşman gemilerin listesi.
        public List<Enemy> Enemies { get; private set; }
        //bool isGameOver: Oyun bitiş durumu.
        public bool IsGameOver { get; private set; }
        public PictureBox SpaceShip1 { get; private set; }

        // Constructor
        public GameOyun()
        {
            Enemies = new List<Enemy>();
            IsGameOver = false;
        }

        // StartGame(): Oyunu başlatmalıdır, oyuncu ve düşmanları oluşturur.
        public void StartGame()
           {
            // Oyuncu uzay gemisi oluşturuluyor
            Player = new SpaceShip(SpaceShip1); // SpaceShip1, Form'daki oyuncu PictureBox'ıdır

            // Düşmanların PictureBox kontrollerini oluştur
            PictureBox basicEnemyPictureBox = new PictureBox
            {
                Size = new Size(50, 50), // Örnek boyutlar
                Location = new Point(100, 0), // Başlangıç konumu
                BackColor = Color.Red, // Görünürlük için renk
                Tag = "enemy"
            };

            PictureBox fastEnemyPictureBox = new PictureBox
            {
                Size = new Size(50, 50),
                Location = new Point(200, 0),
                BackColor = Color.Blue,
                Tag = "enemy"
            };

            PictureBox strongEnemyPictureBox = new PictureBox
            {
                Size = new Size(50, 50),
                Location = new Point(300, 0),
                BackColor = Color.Green,
                Tag = "enemy"
            };

            PictureBox bossEnemyPictureBox = new PictureBox
            {
                Size = new Size(80, 80), // Daha büyük bir boyut
                Location = new Point(400, 0),
                BackColor = Color.Purple,
                Tag = "enemy"
            };

            // Bu PictureBox'ları forma ekleyin
            Form gameForm = Application.OpenForms[0];
            gameForm.Controls.Add(basicEnemyPictureBox);
            gameForm.Controls.Add(fastEnemyPictureBox);
            gameForm.Controls.Add(strongEnemyPictureBox);
            gameForm.Controls.Add(bossEnemyPictureBox);

            // Düşman nesnelerini oluştur ve listeye ekle
            Enemies.Add(new BasicEnemy1(basicEnemyPictureBox));
            Enemies.Add(new FastEnemy1(fastEnemyPictureBox));
            Enemies.Add(new StrongEnemy1(strongEnemyPictureBox));
            Enemies.Add(new BossEnemy1(bossEnemyPictureBox));

            IsGameOver = false;
            Console.WriteLine("Oyun başladı!");
           }

        

        // Oyunu her frame günceller
        public void UpdateGame()
        {
            if (IsGameOver) return;

            // Oyuncu hareketi ve atışları
            Player.Move();
            //Player.Shoot();

            // Düşman hareketleri ve atışları
            foreach (var enemy in Enemies)
            {
                enemy.Move();
                //enemy.Shoot();
            }

            // Çarpışmaları kontrol et
            CheckCollisions();

            // Oyun bitti mi kontrol et
            if (Player.Health <= 0)
            {
                EndGame();
            }
        }

        // Çarpışmaları kontrol eder
        public void CheckCollisions()
        {
            //var collisionDetector = new CollisionDetector();
            CollisionDetector collisionDetector = new CollisionDetector();

            // Oyuncu ile düşman çarpışmaları
            foreach (var enemy in Enemies)
            {
                if (collisionDetector.CheckCollision(Player, enemy))
                {
                    Player.TakeDamage(enemy.Damage);
                    enemy.Destroy();
                }
            }

            // Mermiler ve düşmanlar arası çarpışmalar
            collisionDetector.CheckBulletCollision(Player.Bullets, Enemies);

            // Yok edilen düşmanları ve mermileri temizle
            Enemies.RemoveAll(e => e.IsDestroyed());
            Player.Bullets.RemoveAll(b => b.Top < 0);
        }

        // Oyunu sonlandırır
        public void EndGame()
        {
            IsGameOver = true;

            //Skor hesapla ve göster
            int score = Enemies.Count == 0 ? 100 : 100 - Enemies.Count * 10;
            Console.WriteLine("Oyun sona erdi! Skor: " + score);

            // Skoru dosyaya kaydet
            string filePath = @"C:\Users\nurjahangurbanova\Documents\SPAVEWAR\SPAVEWAR\GameScore.txt";
            File.WriteAllText(filePath, "Oyun Skoru: " + score);

            Console.WriteLine("Skor kaydedildi: " + filePath);
            //string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "score.txt");
            try
            {
                // skor bilgisini dosyaya yaz
                using (StreamWriter writer = new StreamWriter(filePath, true)) // "true", dosyaya ekleme yapar
                {
                    writer.WriteLine($"oyun sonu skoru: {score} - tarih: {DateTime.Now}");
                }

                // oyuncuya skor kaydedildi mesajını göster
                MessageBox.Show($"oyun sona erdi! skorunuz: {score}\nskorunuz 'score.txt' dosyasına kaydedildi.", "oyun bitti", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // hata durumunda mesaj göster
                MessageBox.Show($"skor kaydedilemedi: {ex.Message}", "hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    public class SpaceShip   // SPACESHIP CLASS
    {
        public int Health { get; set; }
        public int Damage { get; set; }
        public int Speed { get; set; }
        public PictureBox SpaceShipPictureBox { get; set; }
        public List<PictureBox> Bullets { get; set; }
        public string Score { get; internal set; }
        public int X { get; internal set; }
        public int Height { get; internal set; }
        public int Y { get; internal set; }
        public int Width { get; internal set; }

        // Constructor: Sağlık, hasar ve hız başlangıç değerleri
        public SpaceShip(PictureBox SpaceShip1)
        {
            Health = 100;        //  INT HEALTH OZELLIGI
            Damage = 10;         //  INT DAMAGE OZELLIGI
            Speed = 20;          //  INT SPEED OZELLIGI
            SpaceShipPictureBox = SpaceShip1;
            Bullets = new List<PictureBox>(); // Listeyi başlatıyoruz
        }

        public void Move(string direction)    // MOVE(direction) METOTU
        {
            if (direction == "left" && SpaceShipPictureBox.Left > 10) // Sol sınır kontrolü
            {
                SpaceShipPictureBox.Left -= Speed;
            }
            else if (direction == "right" && SpaceShipPictureBox.Left < 600) // Sağ sınır kontrolü
            {
                SpaceShipPictureBox.Left += Speed;
            }
        }

        public PictureBox Shoot()       // SHOT() METOTU
        {
            PictureBox bullet = new PictureBox
            {
                SizeMode = PictureBoxSizeMode.AutoSize,
                Image = Properties.Resources.bullet,
                BackColor = System.Drawing.Color.Transparent,
                Tag = "bullet",
                Left = SpaceShipPictureBox.Left + SpaceShipPictureBox.Width / 2 - 5, // Mermi tam ortadan çıkar
                Top = SpaceShipPictureBox.Top - 20 // Aracın önünden çıkar
            };

            Bullets.Add(bullet);
            return bullet;
        }

        public void TakeDamage(int amount)   // TAKE DAMAGE(int amount) METOTU
        {
            Health -= amount;
            if (Health < 0)
            {
                Health = 0;
            }
        }

        public bool IsDestroyed()
        {
            return Health <= 0;
        }

        internal void Move()
        {
            throw new NotImplementedException();
        }
    }
    public abstract class Enemy
    {
        public int Health { get; set; } // Düşmanın can seviyesi
        public int Speed { get; set; }  // Düşmanın hareket hızı
        public int Damage { get; set; } // Düşmanın verdiği hasar
        public PictureBox EnemyPictureBox { get; set; } // Düşman resmi
        public int ScoreValue { get; set; } // Düşman öldürüldüğünde kazanılacak puan
        public int Width { get; internal set; }
        public int X { get; internal set; }
        public int Y { get; internal set; }
        public int Height { get; internal set; }

        public Enemy(PictureBox enemyPictureBox, int health, int speed, int damage, int scoreValue)
        {
            EnemyPictureBox = enemyPictureBox;
            Health = health;
            Speed = speed;
            Damage = damage;
            ScoreValue = scoreValue;
        }

        protected Enemy(PictureBox fastEnemyPictureBox, int v1, int v2, int v3)
        {
        }

        // Soyut metotlar
        public abstract void Move();   // SOYUT METOT
        public abstract void Attack(SpaceShip SpaceShip1); // SOYUT METOT

        // Hasar alma metodu
        public void TakeDamage(int amount)
        {
            Health -= amount;
            if (Health <= 0)
            {
                Health = 0;
                Destroy();
            }
        }

        // Düşmanı yok etme metodu
        public void Destroy()
        {
            if (EnemyPictureBox != null && EnemyPictureBox.Parent != null)
            {
                EnemyPictureBox.Parent.Controls.Remove(EnemyPictureBox);
                EnemyPictureBox.Dispose();
            }

            spaceship gameForm = (spaceship)EnemyPictureBox.FindForm();
            gameForm.score += ScoreValue; // Her düşman yok edildiğinde 10 puan artır
            gameForm.lbl_score.Text = "score : " + gameForm.score;
        }

        internal bool IsDestroyed()
        {
            throw new NotImplementedException();
        }
    }

    // BasicEnemy sınıfı
    public class BasicEnemy1 : Enemy
    {
        public BasicEnemy1(PictureBox BasicEnemyPictureBox)
            : base(BasicEnemyPictureBox, 30, 5, 5, 10) // Sağlık: 50, Hız: 5, Hasar: 5, Puan: 10
        {
        }

        public override void Move()
        {
            EnemyPictureBox.Top += Speed;
            if (EnemyPictureBox.Top > 706)
            {
                Random rnd = new Random();
                int x = rnd.Next(0, 300);
                EnemyPictureBox.Location = new Point(x, 0);
            }
        }

        public override void Attack(SpaceShip SpaceShip1)
        {
            SpaceShip1.TakeDamage(Damage);
        }
    }

    // FastEnemy sınıfı
    public class FastEnemy1 : Enemy
    {
        private Random _rnd = new Random();
        private int _directionChangeCounter = 0; // Kaçınma hareketi sayacı

        public FastEnemy1(PictureBox FastEnemyPictureBox)
                : base(FastEnemyPictureBox, 30, 10, 3, 15) // Sağlık: 30, Hız: 10, Hasar: 3, Puan: 15
        {
        }

        public override void Move()
        {

            EnemyPictureBox.Top += Speed;
            // Kaçınma hareketi için belirli aralıklarla sağa/sola hareket ettiriyoruz
            _directionChangeCounter++;
            if (_directionChangeCounter % 30 == 0) // Her 30 tickte bir yön değiştir
            {
                int newDirection = _rnd.Next(0, 2); // 0: sola, 1: sağa
                if (newDirection == 0)
                {
                    EnemyPictureBox.Left -= 20; // Sola doğru hareket
                }
                else
                {
                    EnemyPictureBox.Left += 20; // Sağa doğru hareket
                }
            }

            if (EnemyPictureBox.Top > 706)
            {
                Random rnd = new Random();
                int x = rnd.Next(0, 300);
                EnemyPictureBox.Location = new Point(x, 0);
            }
        }

        public override void Attack(SpaceShip SpaceShip1)
        {
            SpaceShip1.TakeDamage(Damage);
        }
    }

    // StrongEnemy sınıfı
    public class StrongEnemy1 : Enemy
    {
        private DateTime lastMoveTime;
        private TimeSpan moveInterval;
        public StrongEnemy1(PictureBox StrongEnemyPictureBox)
                : base(StrongEnemyPictureBox, 100, 2, 15, 20) // Sağlık: 100, Hız: 3, Hasar: 15, Puan: 20
        {
            lastMoveTime = DateTime.Now;
            moveInterval = TimeSpan.FromMilliseconds(50); // 50 ms arayla hareket et
        }

        public override void Move()
        {
            EnemyPictureBox.Top += Speed;
            if (EnemyPictureBox.Top > 706)
            {
                Random rnd = new Random();
                int x = rnd.Next(0, 300);
                EnemyPictureBox.Location = new Point(x, 0);
            }
        }

        public override void Attack(SpaceShip SpaceShip1)
        {
            SpaceShip1.TakeDamage(Damage);
        }
        // Oyuncuya yönelme hareketi
        public void MoveToPlayer(SpaceShip SpaceShip1)
        {
            // Belirli zaman diliminde oyuncuya yaklaşma işlemi
            if (DateTime.Now - lastMoveTime >= moveInterval)
            {
                int playerX = SpaceShip1.SpaceShipPictureBox.Location.X;
                int enemyX = EnemyPictureBox.Location.X;

                // Oyuncuya doğru hareket et
                if (enemyX < playerX)
                {
                    EnemyPictureBox.Left += Speed;
                }
                else if (enemyX > playerX)
                {
                    EnemyPictureBox.Left -= Speed;
                }

                lastMoveTime = DateTime.Now;
            }
        }
    }

    // BossEnemy sınıfı
    public class BossEnemy1 : Enemy
    {
        private DateTime lastMoveTime;
        private TimeSpan moveInterval;
        private SpaceShip SpaceShip1;
        public BossEnemy1(PictureBox BossEnemyPictureBox)
                : base(BossEnemyPictureBox, 200, 1, 25, 25) // Sağlık: 200, Hız: 2, Hasar: 20, Puan: 25
        {
            this.SpaceShip1 = SpaceShip1;
            lastMoveTime = DateTime.Now;
            moveInterval = TimeSpan.FromMilliseconds(100); // 100 ms arayla hareket et
        }

        public override void Move()
        {
            // Eğer yeterli zaman geçmişse, hareket et
            if (DateTime.Now - lastMoveTime >= moveInterval)
            {
                // Oyuncuya doğru hareket et
                MoveTowardsPlayer();

                lastMoveTime = DateTime.Now; // Son hareket zamanını güncelle
            }
            //EnemyPictureBox.Top += Speed;
            //if (EnemyPictureBox.Top > 706)
            //{
            //    Random rnd = new Random();
            //    int x = rnd.Next(0, 300);
            //    EnemyPictureBox.Location = new Point(x, 0);
            //}
        }

        public override void Attack(SpaceShip SpaceShip1)
        {
            SpaceShip1.TakeDamage(Damage);
        }
        private void MoveTowardsPlayer()
        {
            // Oyuncunun X ve Y koordinatlarını al
            int playerX = SpaceShip1.SpaceShipPictureBox.Location.X;
            int playerY = SpaceShip1.SpaceShipPictureBox.Location.Y;

            // Boss düşmanının mevcut konumu
            int enemyX = EnemyPictureBox.Location.X;
            int enemyY = EnemyPictureBox.Location.Y;

            // X ve Y eksenlerinde oyuncuya doğru hareket et
            if (enemyX < playerX)
            {
                EnemyPictureBox.Left += Speed; // X ekseninde sağa doğru
            }
            else if (enemyX > playerX)
            {
                EnemyPictureBox.Left -= Speed; // X ekseninde sola doğru
            }

            if (enemyY < playerY)
            {
                EnemyPictureBox.Top += Speed; // Y ekseninde aşağıya doğru
            }
            else if (enemyY > playerY)
            {
                EnemyPictureBox.Top -= Speed; // Y ekseninde yukarıya doğru
            }
        }
        public void SpecialAttack(SpaceShip SpaceShip1)
        {
            // Boss düşmanının özel saldırısı (örneğin, daha fazla hasar)
            SpaceShip1.TakeDamage(Damage * 2); // Özel saldırı için hasarı iki katına çıkar
        }
    }
}
