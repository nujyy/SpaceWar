namespace SPAVEWAR
{
    partial class spaceship
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            SpaceShip1 = new PictureBox();
            timer1 = new System.Windows.Forms.Timer(components);
            BasicEnemy1 = new PictureBox();
            FastEnemy1 = new PictureBox();
            StrongEnemy1 = new PictureBox();
            BossEnemy1 = new PictureBox();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            lbl_score = new Label();
            pictureBox3 = new PictureBox();
            pictureBox4 = new PictureBox();
            pictureBox5 = new PictureBox();
            lbl_over = new Label();
            asteroid = new PictureBox();
            asteroid1 = new PictureBox();
            asteroid2 = new PictureBox();
            asteroid3 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)SpaceShip1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)BasicEnemy1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)FastEnemy1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)StrongEnemy1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)BossEnemy1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)asteroid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)asteroid1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)asteroid2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)asteroid3).BeginInit();
            SuspendLayout();
            // 
            // SpaceShip1
            // 
            SpaceShip1.Image = Properties.Resources.spaceship;
            SpaceShip1.Location = new Point(279, 453);
            SpaceShip1.Name = "SpaceShip1";
            SpaceShip1.Size = new Size(80, 93);
            SpaceShip1.SizeMode = PictureBoxSizeMode.AutoSize;
            SpaceShip1.TabIndex = 0;
            SpaceShip1.TabStop = false;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Tick += timer1_Tick;
            // 
            // BasicEnemy1
            // 
            BasicEnemy1.Image = Properties.Resources.basicenemy;
            BasicEnemy1.Location = new Point(54, 54);
            BasicEnemy1.Name = "BasicEnemy1";
            BasicEnemy1.Size = new Size(80, 80);
            BasicEnemy1.SizeMode = PictureBoxSizeMode.AutoSize;
            BasicEnemy1.TabIndex = 1;
            BasicEnemy1.TabStop = false;
            BasicEnemy1.Tag = "enemy";
            // 
            // FastEnemy1
            // 
            FastEnemy1.Image = Properties.Resources.fastenemy;
            FastEnemy1.Location = new Point(209, 63);
            FastEnemy1.Name = "FastEnemy1";
            FastEnemy1.Size = new Size(80, 71);
            FastEnemy1.SizeMode = PictureBoxSizeMode.AutoSize;
            FastEnemy1.TabIndex = 2;
            FastEnemy1.TabStop = false;
            FastEnemy1.Tag = "enemy";
            // 
            // StrongEnemy1
            // 
            StrongEnemy1.Image = Properties.Resources.strongenemy;
            StrongEnemy1.Location = new Point(370, 74);
            StrongEnemy1.Name = "StrongEnemy1";
            StrongEnemy1.Size = new Size(80, 60);
            StrongEnemy1.SizeMode = PictureBoxSizeMode.AutoSize;
            StrongEnemy1.TabIndex = 3;
            StrongEnemy1.TabStop = false;
            StrongEnemy1.Tag = "enemy";
            // 
            // BossEnemy1
            // 
            BossEnemy1.Image = Properties.Resources.bossenemy;
            BossEnemy1.Location = new Point(543, 74);
            BossEnemy1.Name = "BossEnemy1";
            BossEnemy1.Size = new Size(80, 60);
            BossEnemy1.SizeMode = PictureBoxSizeMode.AutoSize;
            BossEnemy1.TabIndex = 4;
            BossEnemy1.TabStop = false;
            BossEnemy1.Tag = "enemy";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.star2;
            pictureBox1.Location = new Point(-4, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(695, 275);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            pictureBox1.Tag = "stars";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.star2;
            pictureBox2.Location = new Point(-4, 295);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(695, 277);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 6;
            pictureBox2.TabStop = false;
            pictureBox2.Tag = "stars";
            // 
            // lbl_score
            // 
            lbl_score.AutoSize = true;
            lbl_score.BackColor = Color.Transparent;
            lbl_score.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_score.ForeColor = Color.FromArgb(255, 128, 128);
            lbl_score.Location = new Point(-4, 0);
            lbl_score.Name = "lbl_score";
            lbl_score.Size = new Size(125, 37);
            lbl_score.TabIndex = 7;
            lbl_score.Text = "Score : 0";
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.star2;
            pictureBox3.Location = new Point(-2, 146);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(695, 275);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 8;
            pictureBox3.TabStop = false;
            pictureBox3.Tag = "stars";
            // 
            // pictureBox4
            // 
            pictureBox4.Image = Properties.Resources.star2;
            pictureBox4.Location = new Point(-4, -75);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(695, 277);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 9;
            pictureBox4.TabStop = false;
            pictureBox4.Tag = "stars";
            // 
            // pictureBox5
            // 
            pictureBox5.Image = Properties.Resources.star2;
            pictureBox5.Location = new Point(-4, 393);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(695, 277);
            pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox5.TabIndex = 10;
            pictureBox5.TabStop = false;
            pictureBox5.Tag = "stars";
            // 
            // lbl_over
            // 
            lbl_over.AutoSize = true;
            lbl_over.BackColor = Color.Transparent;
            lbl_over.Font = new Font("Impact", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_over.ForeColor = Color.FromArgb(255, 128, 128);
            lbl_over.Location = new Point(190, 257);
            lbl_over.Name = "lbl_over";
            lbl_over.Size = new Size(249, 60);
            lbl_over.TabIndex = 11;
            lbl_over.Text = "Game-Over";
            // 
            // asteroid
            // 
            asteroid.Image = Properties.Resources.asteroid;
            asteroid.Location = new Point(108, 168);
            asteroid.Name = "asteroid";
            asteroid.Size = new Size(10, 9);
            asteroid.SizeMode = PictureBoxSizeMode.AutoSize;
            asteroid.TabIndex = 12;
            asteroid.TabStop = false;
            asteroid.Tag = "asteroid";
            // 
            // asteroid1
            // 
            asteroid1.Image = Properties.Resources.asteroid1;
            asteroid1.Location = new Point(381, 146);
            asteroid1.Name = "asteroid1";
            asteroid1.Size = new Size(10, 10);
            asteroid1.SizeMode = PictureBoxSizeMode.AutoSize;
            asteroid1.TabIndex = 13;
            asteroid1.TabStop = false;
            asteroid1.Tag = "asteroid";
            // 
            // asteroid2
            // 
            asteroid2.Image = Properties.Resources.asteroid2;
            asteroid2.Location = new Point(259, 168);
            asteroid2.Name = "asteroid2";
            asteroid2.Size = new Size(25, 19);
            asteroid2.SizeMode = PictureBoxSizeMode.AutoSize;
            asteroid2.TabIndex = 14;
            asteroid2.TabStop = false;
            asteroid2.Tag = "asteroid";
            // 
            // asteroid3
            // 
            asteroid3.Image = Properties.Resources.asteroid3;
            asteroid3.Location = new Point(492, 168);
            asteroid3.Name = "asteroid3";
            asteroid3.Size = new Size(25, 22);
            asteroid3.SizeMode = PictureBoxSizeMode.AutoSize;
            asteroid3.TabIndex = 15;
            asteroid3.TabStop = false;
            asteroid3.Tag = "asteroid";
            // 
            // spaceship
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(690, 567);
            Controls.Add(asteroid3);
            Controls.Add(asteroid2);
            Controls.Add(asteroid1);
            Controls.Add(asteroid);
            Controls.Add(lbl_over);
            Controls.Add(lbl_score);
            Controls.Add(BossEnemy1);
            Controls.Add(StrongEnemy1);
            Controls.Add(FastEnemy1);
            Controls.Add(BasicEnemy1);
            Controls.Add(SpaceShip1);
            Controls.Add(pictureBox1);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox4);
            Controls.Add(pictureBox5);
            Name = "spaceship";
            StartPosition = FormStartPosition.CenterScreen;
            KeyDown += spaceship_KeyDown;
            KeyUp += spaceship_KeyUp;
            ((System.ComponentModel.ISupportInitialize)SpaceShip1).EndInit();
            ((System.ComponentModel.ISupportInitialize)BasicEnemy1).EndInit();
            ((System.ComponentModel.ISupportInitialize)FastEnemy1).EndInit();
            ((System.ComponentModel.ISupportInitialize)StrongEnemy1).EndInit();
            ((System.ComponentModel.ISupportInitialize)BossEnemy1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)asteroid).EndInit();
            ((System.ComponentModel.ISupportInitialize)asteroid1).EndInit();
            ((System.ComponentModel.ISupportInitialize)asteroid2).EndInit();
            ((System.ComponentModel.ISupportInitialize)asteroid3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public PictureBox SpaceShip1;
        private System.Windows.Forms.Timer timer1;
        public PictureBox BasicEnemy1;
        public PictureBox FastEnemy1;
        public PictureBox StrongEnemy1;
        public PictureBox BossEnemy1;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        public Label lbl_score;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
        private PictureBox pictureBox5;
        public Label lbl_over;
        private PictureBox asteroid;
        private PictureBox asteroid1;
        private PictureBox asteroid2;
        private PictureBox asteroid3;
    }
}
