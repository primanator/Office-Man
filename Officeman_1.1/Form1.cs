using Officeman_1._1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OfficeMan_1._1
{
    public partial class Form1 : Form
    {
        static bool WTF = false;
        private const int MaxFormWidth = 500, MaxFormHeight = 500;
        Sources source = new Sources();
        Mechanics mech = new Mechanics();
        Timer timerGame = new Timer();
        int stand_pic = 0;
        int jump_anim_pic = -1;
        int pegion_pic = 0;
        int fall_pic = 0;
        int buldingY1 = 0;
        int buldingY2 = 500;
        int manX = 160;
        int manY = 40;
        int sky_fontX = 0;
        int sky_fontY = 0;
        int sky_trans_fontX = 0;
        int sky_trans_fontY = 0;
        int pegion_coord = 450;
        int[,] pegion_flock = new int[5,2];
        
        public Form1()
        {
            Rectangle screen = Screen.PrimaryScreen.Bounds;
            Point maximizedLocation = new Point((screen.Width - MaxFormWidth) / 2, (screen.Height - MaxFormHeight) / 2);
            this.MaximumSize = new Size(MaxFormWidth, MaxFormHeight);
            this.MaximizedBounds = new Rectangle(maximizedLocation, this.MaximumSize);
            this.StartPosition = FormStartPosition.CenterScreen;

            System.Media.SoundPlayer Audio;
            Audio = new System.Media.SoundPlayer("..\\..\\sounds\\main.wav");
            Audio.Load(); Audio.PlayLooping();

            InitializeComponent();
            timerGame.Tick += delegate
            {
                if (mech[Mechanics.character.falling])
                {
                    PointsLabel.Visible = true;
                    FormElement.DrawPoints(PointsLabel);
                }
                if (!mech[Mechanics.game.bird])
                {
                    pegion_coord = 450;  
                    Random pegion_probability = new Random();
                    int s = pegion_probability.Next(2);
                    if (s == 1)
                        mech[Mechanics.game.bird] = true;
                }
                if (!mech[Mechanics.game.birds])
                {
                pegion_flock[0, 0] = 450;
                pegion_flock[0, 1] = 280;

                pegion_flock[1, 0] = 470;
                pegion_flock[1, 1] = 250;

                pegion_flock[2, 0] = 485;
                pegion_flock[2, 1] = 315;

                pegion_flock[3, 0] = 530;
                pegion_flock[3, 1] = 265;

                pegion_flock[4, 0] = 560;
                pegion_flock[4, 1] = 330;

                Random pegion_probability = new Random();
                int s = pegion_probability.Next(2);
                if (s == 1)
                    mech[Mechanics.game.birds] = true;
                }
                Invalidate();
            };
            timerGame.Interval = 150;
            timerGame.Start();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (!mech[Mechanics.character.falling])
            {
                e.Graphics.DrawImage(source.Clouds_When_Stand(ref sky_fontX), sky_fontX, sky_fontY);
                e.Graphics.DrawImage(source.Transparent_Clouds_When_Stand(ref sky_trans_fontX), sky_trans_fontX, sky_trans_fontY, 10000, 10000);
                e.Graphics.DrawImage(source.DrawBuilding(), 0, buldingY1, 165, MaxFormHeight);
                if (mech[Mechanics.character.stand])
                    e.Graphics.DrawImage(source.DrawMan_Stand(ref stand_pic), 124, 3, 72, 72);
                if (mech[Mechanics.character.jumping])
                    e.Graphics.DrawImage(source.JumpPic(ref jump_anim_pic, out manX, out manY, mech), manX, manY, 72, 72);
            }
            if (mech[Mechanics.character.falling])
            {
                e.Graphics.DrawImage(source.Clouds_When_Fall(ref sky_fontX, ref sky_fontY), sky_fontX, sky_fontY);
                e.Graphics.DrawImage(source.Transparent_Clouds_When_Fall(ref sky_trans_fontX, ref sky_trans_fontY), sky_trans_fontX, sky_trans_fontY, 10000, 10000);
                e.Graphics.DrawImage(source.DrawBuilding_Fall(ref buldingY1), 0, buldingY1, 165, MaxFormHeight);
                e.Graphics.DrawImage(source.DrawBuilding_Fall(ref buldingY2), 0, buldingY2, 165, MaxFormHeight);
                e.Graphics.DrawImage(source.DrawMan_Fall(ref fall_pic), manX, manY, 72, 72);
                if (buldingY1 <= -MaxFormHeight)
                {
                    buldingY1 = -5;
                    buldingY2 = MaxFormHeight - 5;
                }
            }
            DrawAllBirds(e);
            e.Dispose();
        }

        private void DrawAllBirds(PaintEventArgs e)
        {
            if (mech[Mechanics.game.bird])
            {
                if (pegion_coord >= 0)
                {
                    e.Graphics.DrawImage(source.PegionPic(ref pegion_pic), pegion_coord, pegion_coord);
                    mech.PegionFly(ref pegion_coord);
                }
                else
                    mech[Mechanics.game.bird] = false;
            }
            if (mech[Mechanics.game.birds])
            {
                int gone = 0;
                for (int i = 0; i < 5; i++)
                {
                    if (pegion_flock[i, 0] >= 0)
                    {
                        e.Graphics.DrawImage(source.PegionPic(ref pegion_pic), pegion_flock[i, 0], pegion_flock[i, 1]);
                        mech.PegionsFly(ref pegion_flock[i, 0], ref pegion_flock[i, 1]);
                    }
                    else
                        gone++;
                }
                if (gone == 5)
                    mech[Mechanics.game.birds] = false;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (!mech[Mechanics.game.pause])
                {
                    timerGame.Stop();
                    mech[Mechanics.game.pause] = true;
                    return;
                }
                mech[Mechanics.game.pause] = false;
                timerGame.Start();
            }
            if (e.KeyCode == Keys.Space)
            {
                mech[Mechanics.character.stand] = false;
                mech[Mechanics.character.jumping] = true;
            }
            if (e.KeyCode == Keys.A)
            {
                if (!mech[Mechanics.character.stand] & mech[Mechanics.character.falling])
                    mech.TurnLeft(ref manX);
            }
            if (e.KeyCode == Keys.D)
            {
                if (!mech[Mechanics.character.stand] & mech[Mechanics.character.falling])
                    mech.TurnRight(ref manX);
            }
            if (e.KeyCode == Keys.W)
            {
                if (!mech[Mechanics.character.stand] & mech[Mechanics.character.falling])                
                    mech.TurnUp(ref manY);
            }
            if (e.KeyCode == Keys.S)
            {
                if (!mech[Mechanics.character.stand] & mech[Mechanics.character.falling])                
                    mech.TurnDown(ref manY);
            }
        }
    }
}