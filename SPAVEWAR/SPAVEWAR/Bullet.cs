using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPAVEWAR
{
    public class Bullet    //MERMI CLASSI
    {
        public PictureBox BulletPictureBox { get; set; } // Merminin resmi
        public int Speed { get; set; } // Merminin hızı
        public int Damage { get; set; } // Merminin verdiği hasar
        public int Direction { get; set; } // Merminin hareket yönü (1: yukarı, -1: aşağı)
        public bool IsDestroyed { get; internal set; }
        public int Height { get; internal set; }
        public int Y { get; internal set; }
        public int X { get; internal set; }
        public int Width { get; internal set; }

        public Bullet(PictureBox bulletPictureBox, int speed, int damage, int direction)
        {
            BulletPictureBox = bulletPictureBox;
            Speed = speed;
            Damage = damage;
            Direction = direction;
        }

        // Merminin ekranda ilerlemesini sağlar
        public void Move()
        {
            BulletPictureBox.Top -= Speed * Direction;

            // Eğer ekran dışına çıktıysa mermiyi kaldır
            if (BulletPictureBox.Top < 0 || BulletPictureBox.Top > 706)
            {
                Destroy();
            }
        }

        // Mermi bir hedefe çarptığında hasarı uygular ve yok edilir
        public void OnHit(Enemy enemy)
        {
            if (enemy != null)
            {
                enemy.TakeDamage(Damage); // Düşmanın canından hasarı çıkar
                Destroy(); // Mermiyi yok et
            }
        }

        // Mermiyi yok etme işlemi
        public void Destroy()
        {
            if (BulletPictureBox != null && BulletPictureBox.Parent != null)
            {
                BulletPictureBox.Parent.Controls.Remove(BulletPictureBox);
                BulletPictureBox.Dispose();
            }
        }
    }
}
