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
        private const int MaxFormWidth = 500, MaxFormHeight = 500;
        Sources source = new Sources();
        Mechanics mech = new Mechanics();
        Timer timerGame = new Timer();
        Rectangle CharacterPlace = new Rectangle(160, 40, 23, 36);
        Rectangle PegionPlace = new Rectangle(450, 450, 13, 7);
        int stand_pic = 0;
        int jump_anim_pic = -1;
        int pegion_pic = 0;
        int fall_pic = 0;
        int buldingY1 = 0;
        int buldingY2 = 500;
        int sky_fontX = 0;
        int sky_fontY = 0;
        int sky_trans_fontX = 0;
        int sky_trans_fontY = 0;
        int points100_anim = 0;
        Rectangle[] PegionFlock_Place = new Rectangle[5];
        
        public Form1()
        {
            Rectangle screen = Screen.PrimaryScreen.Bounds;
            Point maximizedLocation = new Point((screen.Width - MaxFormWidth) / 2, (screen.Height - MaxFormHeight) / 2);
            this.MaximumSize = new Size(MaxFormWidth, MaxFormHeight);
            this.MaximizedBounds = new Rectangle(maximizedLocation, this.MaximumSize);
            this.StartPosition = FormStartPosition.CenterScreen;

            //System.Media.SoundPlayer Audio;
            //Audio = new System.Media.SoundPlayer("..\\..\\sounds\\main.wav");
            //Audio.Load(); Audio.PlayLooping();

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
                    PegionPlace.X = 450;
                    PegionPlace.Y = 450;   
                    Random pegion_probability = new Random();
                    int s = pegion_probability.Next(2);
                    if (s == 1)
                        mech[Mechanics.game.bird] = true;
                }
                if (!mech[Mechanics.game.birds])
                {
                    PegionFlock_Place[0] = new Rectangle(600, 280, 13, 7);
                    PegionFlock_Place[1] = new Rectangle(470, 250, 13, 7);
                    PegionFlock_Place[2] = new Rectangle(485, 315, 13, 7);
                    PegionFlock_Place[3] = new Rectangle(530, 265, 13, 7);
                    PegionFlock_Place[4] = new Rectangle(560, 330, 13, 7);
                    Random pegion_probability = new Random();
                    int s = pegion_probability.Next(2);
                    if (s == 1)
                        mech[Mechanics.game.birds] = true;
                }
                Invalidate();
            };
            timerGame.Interval = 1000;
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
                    e.Graphics.DrawImage(source.DrawMan_Stand(ref stand_pic), 122, 14);
                if (mech[Mechanics.character.jumping])
                    e.Graphics.DrawImage(source.JumpPic(ref jump_anim_pic, ref CharacterPlace, mech), CharacterPlace.X, CharacterPlace.Y);
            }
            if (mech[Mechanics.character.falling])
            {
                e.Graphics.DrawImage(source.Clouds_When_Fall(ref sky_fontX, ref sky_fontY), sky_fontX, sky_fontY);
                e.Graphics.DrawImage(source.Transparent_Clouds_When_Fall(ref sky_trans_fontX, ref sky_trans_fontY), sky_trans_fontX, sky_trans_fontY, 10000, 10000);
                e.Graphics.DrawImage(source.DrawBuilding_Fall(ref buldingY1), 0, buldingY1, 165, MaxFormHeight);
                e.Graphics.DrawImage(source.DrawBuilding_Fall(ref buldingY2), 0, buldingY2, 165, MaxFormHeight);
                e.Graphics.DrawImage(source.DrawMan_Fall(ref fall_pic), CharacterPlace.X, CharacterPlace.Y);
                if (buldingY1 <= -MaxFormHeight)
                {
                    buldingY1 = -5;
                    buldingY2 = MaxFormHeight - 5;
                }
            }
            DrawAllBirds(e);
            CheckIntersection(e, ref points100_anim);
            Draw100pointsAnimation(e, ref points100_anim);
            if (mech[Mechanics.game.pause])
                DrawMenu(e);
            e.Dispose();
        }

        private void CheckIntersection(PaintEventArgs e, ref int points100_anim)
        {
            if (Rectangle.Intersect(CharacterPlace, PegionPlace) != Rectangle.Empty)
            {
                points100_anim = 1;
                FormElement.Add100Points(PointsLabel);
                return;
            }
            for (int i = 0; i < 5; i++)
                if (Rectangle.Intersect(CharacterPlace, PegionFlock_Place[i]) != Rectangle.Empty)
                {
                    points100_anim = 1;
                    FormElement.Add100Points(PointsLabel);
                    return;
                }
        }

        private void Draw100pointsAnimation(PaintEventArgs e, ref int points100_anim)
        {
            switch(points100_anim)
            {
                case 0:
                        break;
                case 1:
                    {
                        e.Graphics.DrawImage(source.Get100Points(), CharacterPlace.X, CharacterPlace.Y - 30);
                        points100_anim = 2;
                        break;
                    }
                case 2:
                    {
                        points100_anim = 3;
                        break;
                    }
                case 3:
                    {
                        e.Graphics.DrawImage(source.Get100PointsHalfTransparent(), CharacterPlace.X, CharacterPlace.Y - 40);
                        points100_anim = 4;
                        break;
                    }
                case 4:
                    {
                        points100_anim = 5;
                        break;
                    }
                case 5:
                    {
                        e.Graphics.DrawImage(source.Get100PointsTransparent(), CharacterPlace.X, CharacterPlace.Y - 50);
                        points100_anim = 0;
                        break;
                    }
                default:
                    break;
            }
        }

        private void DrawAllBirds(PaintEventArgs e)
        {
            if (mech[Mechanics.game.bird])
            {
                if (PegionPlace.X >= 0)
                {
                    e.Graphics.DrawImage(source.PegionPic(ref pegion_pic), PegionPlace.X, PegionPlace.Y);
                    mech.PegionFly(ref PegionPlace);
                }
                else
                    mech[Mechanics.game.bird] = false;
            }
            if (mech[Mechanics.game.birds])
            {
                int gone = 0;
                for (int i = 0; i < 5; i++)
                {
                    if (PegionFlock_Place[i].X >= 0)
                    {
                        e.Graphics.DrawImage(source.PegionPic(ref pegion_pic), PegionFlock_Place[i].X, PegionFlock_Place[i].Y);
                        mech.PegionFly(ref PegionFlock_Place[i]);
                    }
                    else
                        gone++;
                }
                if (gone == 5)
                    mech[Mechanics.game.birds] = false;
            }
        }

        private void DrawMenu(PaintEventArgs e)
        {
            e.Graphics.DrawImage(source.GetMenuFont(), 150, 100);
            timerGame.Stop();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (!mech[Mechanics.game.pause])
                {
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
                    mech.TurnLeft(ref CharacterPlace);
            }
            if (e.KeyCode == Keys.D)
            {
                if (!mech[Mechanics.character.stand] & mech[Mechanics.character.falling])
                    mech.TurnRight(ref CharacterPlace);
            }
            if (e.KeyCode == Keys.W)
            {
                if (!mech[Mechanics.character.stand] & mech[Mechanics.character.falling])                
                    mech.TurnUp(ref CharacterPlace);
            }
            if (e.KeyCode == Keys.S)
            {
                if (!mech[Mechanics.character.stand] & mech[Mechanics.character.falling])                
                    mech.TurnDown(ref CharacterPlace);
            }
        }
    }
}