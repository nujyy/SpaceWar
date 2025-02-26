using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using SPAVEWAR;
using static SPAVEWAR.spaceship;
using System.Windows.Forms;

namespace SPAVEWAR
{
    public class CollisionDetector
    {
        // CheckCollision(Spaceship player, Enemy enemy): Oyuncunun uzay aracı ile düşmanın çarpışmasını kontrol eder
        public bool CheckCollision(SpaceShip player, Enemy enemy)
        {
            // Basit dikdörtgen çarpışma algılama
            return player.X < enemy.X + enemy.Width &&
                   player.X + player.Width > enemy.X &&
                   player.Y < enemy.Y + enemy.Height &&
                   player.Y + player.Height > enemy.Y;
        }

        // CheckBulletCollision(List<Bullet> bullets, List<Enemy> enemies): Mermilerin düşmanlara veya oyuncuya isabet edip etmediğini kontrol eder.
        public void CheckBulletCollision(List<Bullet> bullets, List<Enemy> enemies)
        {
            foreach (var bullet in bullets)
            {
                foreach (var enemy in enemies)
                {
                    // Eğer mermi bir düşmana çarptıysa
                    if (bullet.X < enemy.X + enemy.Width &&
                        bullet.X + bullet.Width > enemy.X &&
                        bullet.Y < enemy.Y + enemy.Height &&
                        bullet.Y + bullet.Height > enemy.Y)
                    {
                        enemy.TakeDamage(bullet.Damage); // Düşmana hasar ver
                        bullet.IsDestroyed = true; // Mermiyi yok et
                        break;
                    }
                }
            }
        }

        internal void CheckBulletCollision(List<PictureBox> bullets, List<Enemy> enemies)
        {
            throw new NotImplementedException();
        }
    }
}

