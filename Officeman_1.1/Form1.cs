using Officeman_1._1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OfficeMan_1._1
{
    public partial class Form1 : Form
    {
        private bool repaint = false;
        private int buildingsBackMoveCounter = 0;
        private int buildingsFrontMoveCounter = 0;
        private int changeTransparency = 0;
        private double globalGameTime = 0;
        private const int MaxFormWidth = 500, MaxFormHeight = 500;
        private Sources source = new Sources();
        private Mechanics mech = new Mechanics();
        private Timer timerGame = new Timer();
        private Rectangle CharacterForm = new Rectangle(130, 120, 45, 56);
        private Rectangle PegionForm = new Rectangle(450, 450, 16, 10);
        private Rectangle CleanerForm = new Rectangle(-70, 70, 100, 120); // 25, 36 prev size
        private Rectangle BuildingForm1 = new Rectangle(0, 0, 400, 462);
        private Rectangle BuildingForm2 = new Rectangle(0, 462, 400, 462);
        private Rectangle CloudsBackForm = new Rectangle(0, 0, 4200, 4200);
        private Rectangle CloudsFontForm = new Rectangle(0, 0, 9000, 9000);
        private Rectangle BuildingsBackForm = new Rectangle(-95, 40, 590, 600);
        private Rectangle BuildingsFrontForm = new Rectangle(-95, 80, 590, 600);
        private Rectangle BackgroundGradientForm = new Rectangle(40, 150, 462, 462);
        private Rectangle BackgroundForm = new Rectangle(25, 0, 462, 462);
        private Rectangle HighscoreForm = new Rectangle(0, 0, 462, 462);
        private Rectangle SmokerForm = new Rectangle(92, 297, 38, 71);
        private int stand_pic = 0;
        private int jump_anim_pic = -1;
        //private int cleaner_anim = 0;
        private int pegion_pic = 0;
        private int fall_pic = 0;
        private int points100_anim = 0;
        private int smoker_anim_pic = -1;
        private Rectangle[] PegionFlock_Form = new Rectangle[5];
        Timer timerTotalScoreAnimation = new Timer();
        Timer timerHighscoreAnimation = new Timer();
        
        public Form1()
        {
            Rectangle screen = Screen.PrimaryScreen.Bounds;
            Point maximizedLocation = new Point((screen.Width - MaxFormWidth) / 2, (screen.Height - MaxFormHeight) / 2);
            this.MaximumSize = new Size(MaxFormWidth, MaxFormHeight);
            this.MaximizedBounds = new Rectangle(maximizedLocation, this.MaximumSize);
            this.StartPosition = FormStartPosition.CenterScreen;
            FileProcessing.CreateHighscoreTable();

            System.Media.SoundPlayer Audio;
            Audio = new System.Media.SoundPlayer("..\\..\\sounds\\main.wav");
            Audio.Load(); Audio.PlayLooping();

            timerHighscoreAnimation.Tick += delegate
            {
                FormElement.ShowHighScoreLabels(HighScoreLabel1, HighScoreLabel2, NewNicknameLabel, source);
            };
            timerHighscoreAnimation.Interval = 150;

            timerTotalScoreAnimation.Tick += delegate
            {
                FormElement.TotalScore_ChangeImage(TotalScoreLabel, source);
            };
            timerTotalScoreAnimation.Interval = 150;

            InitializeComponent();
            timerGame.Tick += delegate
            {
                if ((globalGameTime >= 10) & (changeTransparency == 0))
                {
                    source.MakeFrontCloudsMoreTransparent();
                    changeTransparency++;
                }
                if (globalGameTime >= 25 & (changeTransparency == 1))
                {
                    source.MakeFrontCloudsEvenMoreTransparent();
                    changeTransparency++;
                }
                if (globalGameTime >= 35 & (changeTransparency == 2))
                {
                    source.MakeFrontCloudsMaximumTransparent();
                    changeTransparency++;
                }
                if (globalGameTime >= 45 & (changeTransparency == 3))
                    mech[Mechanics.game.frontclouds] = false;
                if (globalGameTime >= 60)
                {
                    mech[Mechanics.character.falling] = false;
                    mech[Mechanics.game.end] = true;
                }
                if (mech[Mechanics.character.falling])
                {
                    globalGameTime += 0.150;
                    PointsLabel.Visible = true;

                }
                if (mech[Mechanics.game.smoker])
                {
                    if (SmokerForm.Y <= -SmokerForm.Height)
                        mech[Mechanics.game.smoker] = false;
                }
                if (!mech[Mechanics.game.bird])
                {
                    PegionForm.X = 450;
                    PegionForm.Y = 450;   
                    Random pegion_probability = new Random();
                    int s = pegion_probability.Next(2);
                    if (s == 1)
                        mech[Mechanics.game.bird] = true;
                }
                if (!mech[Mechanics.game.birds])
                {
                    PegionFlock_Form[0] = new Rectangle(600, 280, 16, 10);
                    PegionFlock_Form[1] = new Rectangle(470, 250, 16, 10);
                    PegionFlock_Form[2] = new Rectangle(485, 315, 16, 10);
                    PegionFlock_Form[3] = new Rectangle(530, 265, 16, 10);
                    PegionFlock_Form[4] = new Rectangle(560, 330, 16, 10);
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
            e.Graphics.DrawImage(source.Background(), BackgroundForm.X, BackgroundForm.Y, BackgroundForm.Width, BackgroundForm.Height);
            if (mech[Mechanics.character.stand])
            {
                e.Graphics.DrawImage(source.Background_Gradient(), BackgroundGradientForm.X, BackgroundGradientForm.Y, BackgroundGradientForm.Width, BackgroundGradientForm.Height);
                e.Graphics.DrawImage(source.Clouds_When_Stand(ref CloudsBackForm), CloudsBackForm.X, CloudsBackForm.Y, CloudsBackForm.Width, CloudsBackForm.Height);
                e.Graphics.DrawImage(source.Buildings_Back(), BuildingsBackForm.X, BuildingsBackForm.Y, BuildingsBackForm.Width, BuildingsBackForm.Height);
                e.Graphics.DrawImage(source.Buildings_Front(), BuildingsFrontForm.X, BuildingsFrontForm.Y, BuildingsFrontForm.Width, BuildingsFrontForm.Height);
                e.Graphics.DrawImage(source.DrawBuilding(), BuildingForm1.X, BuildingForm1.Y, BuildingForm1.Width, BuildingForm1.Height);
                if (mech[Mechanics.game.smoker])
                    DrawSmoker(source, e);                
                e.Graphics.DrawImage(source.DrawMan_Stand(ref stand_pic), CharacterForm.X, CharacterForm.Y, CharacterForm.Width, CharacterForm.Height);///////////// !!!!!!!!!
                e.Graphics.DrawImage(source.Transparent_Clouds_When_Stand(ref CloudsFontForm), CloudsFontForm.X, CloudsFontForm.Y, 10000, 10000);            
            }
            if (mech[Mechanics.character.jumping])
            {
                e.Graphics.DrawImage(source.Background_Gradient(), BackgroundGradientForm.X, BackgroundGradientForm.Y, BackgroundGradientForm.Width, BackgroundGradientForm.Height);
                e.Graphics.DrawImage(source.Clouds_When_Stand(ref CloudsBackForm), CloudsBackForm.X, CloudsBackForm.Y, CloudsBackForm.Width, CloudsBackForm.Height);
                e.Graphics.DrawImage(source.Buildings_Back(), BuildingsBackForm.X, BuildingsBackForm.Y, BuildingsBackForm.Width, BuildingsBackForm.Height);
                e.Graphics.DrawImage(source.Buildings_Front(), BuildingsFrontForm.X, BuildingsFrontForm.Y, BuildingsFrontForm.Width, BuildingsFrontForm.Height);
                e.Graphics.DrawImage(source.DrawBuilding(), BuildingForm1.X, BuildingForm1.Y, BuildingForm1.Width, BuildingForm1.Height);
                if (mech[Mechanics.game.smoker])
                    DrawSmoker(source, e);
                e.Graphics.DrawImage(source.JumpPic(ref jump_anim_pic, ref CharacterForm), CharacterForm.X, CharacterForm.Y);
                e.Graphics.DrawImage(source.Transparent_Clouds_When_Stand(ref CloudsFontForm), CloudsFontForm.X, CloudsFontForm.Y, 10000, 10000);
            }
            if (mech[Mechanics.character.falling])
            {
                e.Graphics.DrawImage(source.Clouds_When_Fall(ref CloudsBackForm), CloudsBackForm.X, CloudsBackForm.Y, CloudsBackForm.Width, CloudsBackForm.Height);
                if (mech[Mechanics.game.frontclouds])
                    e.Graphics.DrawImage(source.Transparent_Clouds_When_Fall(ref CloudsFontForm), CloudsFontForm.X, CloudsFontForm.Y, 10000, 10000);
                if (!repaint)
                {
                    buildingsBackMoveCounter++;
                    buildingsFrontMoveCounter++;
                    e.Graphics.DrawImage(source.Background_Gradient(), BackgroundGradientForm.X, BackgroundGradientForm.Y, BackgroundGradientForm.Width, BackgroundGradientForm.Height);
                    e.Graphics.DrawImage(source.Clouds_Back(), CloudsBackForm.X, CloudsBackForm.Y, CloudsBackForm.Width, CloudsBackForm.Height);
                    
                    e.Graphics.DrawImage(source.Buildings_Back(), BuildingsBackForm.X, BuildingsBackForm.Y, BuildingsBackForm.Width, BuildingsBackForm.Height);
                    e.Graphics.DrawImage(source.Buildings_Front(), BuildingsFrontForm.X, BuildingsFrontForm.Y, BuildingsFrontForm.Width, BuildingsFrontForm.Height);
                    if (buildingsBackMoveCounter == 13)
                    {
                        source.Buildings_Back_Move(ref BuildingsBackForm);
                        buildingsBackMoveCounter = 0;
                    }
                    if (buildingsFrontMoveCounter == 10)
                    {
                        source.Background_Gradient_Move(ref BackgroundGradientForm);
                        source.Buildings_Front_Move(ref BuildingsFrontForm);
                        buildingsFrontMoveCounter = 0;
                    }
                    e.Graphics.DrawImage(source.DrawBuilding_Fall(ref BuildingForm1), BuildingForm1.X, BuildingForm1.Y, BuildingForm1.Width, BuildingForm1.Height);
                    e.Graphics.DrawImage(source.DrawBuilding_Fall(ref BuildingForm2), BuildingForm2.X, BuildingForm2.Y, BuildingForm2.Width, BuildingForm2.Height);
                    source.Smoker_Move(ref SmokerForm);
                    if (mech[Mechanics.game.smoker])
                        DrawSmoker(source, e);
                    e.Graphics.DrawImage(source.DrawMan_Fall(ref fall_pic), CharacterForm.X, CharacterForm.Y);
                    if (mech[Mechanics.game.frontclouds])
                        e.Graphics.DrawImage(source.Clouds_Front(), CloudsFontForm.X, CloudsFontForm.Y, 10000, 10000);
                    CheckIntersection(e, ref points100_anim);
                    Draw100pointsAnimation(e, ref points100_anim);
                    FormElement.DrawPoints(PointsLabel);
                    repaint = true;
                }
                else
                    repaint = false;
            }
            DrawAllBirds(e);
            if (mech[Mechanics.game.pause])
                DrawPauseMenu(e);
            else
                HidePauseMenu();
            if (mech[Mechanics.game.end])
            {
                OKLabel.Visible = true;
                e.Graphics.DrawImage(source.Background_Gradient(), BackgroundGradientForm.X, BackgroundGradientForm.Y, BackgroundGradientForm.Width, BackgroundGradientForm.Height);
                e.Graphics.DrawImage(source.Clouds_When_Stand(ref CloudsBackForm), CloudsBackForm.X, CloudsBackForm.Y, CloudsBackForm.Width, CloudsBackForm.Height);
                e.Graphics.DrawImage(source.Buildings_Back(), BuildingsBackForm.X, BuildingsBackForm.Y, BuildingsBackForm.Width, BuildingsBackForm.Height);
                e.Graphics.DrawImage(source.Buildings_Front(), BuildingsFrontForm.X, BuildingsFrontForm.Y, BuildingsFrontForm.Width, BuildingsFrontForm.Height);
                e.Graphics.DrawImage(source.BuildingEnter(), 0, 0, BuildingForm2.Width, BuildingForm2.Height); // PAINT IN FROM!!!!!!!!!
                e.Graphics.DrawImage(source.DrawMan_Stand(ref stand_pic), CharacterForm.X, CharacterForm.Y);
                DrawTotalScore(e);
                timerGame.Stop();
                timerTotalScoreAnimation.Start();
            }
            if(mech[Mechanics.game.new_highscore])
            {
                timerHighscoreAnimation.Start();
            }
            if (jump_anim_pic == 4)
            {
                mech[Mechanics.character.jumping] = false;
                mech[Mechanics.character.falling] = true;
            }
            if (BuildingForm1.Y <= -462)
            {
                BuildingForm1.Y = 0;
                BuildingForm2.Y = 462;
                if (SmokerForm.Y <= -SmokerForm.Height)
                    CreateSmoker();
            }
            e.Dispose();
            //e.Graphics.RotateTransform(180); //  -- draws cleaner
            //e.Graphics.TranslateTransform(0, -MaxFormHeight);
            //e.Graphics.DrawImage(source.DrawCleaner(ref cleaner_anim), CleanerPlace);
            //e.Graphics.TranslateTransform(MaxFormWidth, MaxFormHeight);
            //e.Graphics.RotateTransform(180); // --X
        }

        private void CreateSmoker()
        {
            SmokerForm.Y = 481;
            Random place_rand = new Random();
            int s = place_rand.Next(2);
            if (s == 1)
                SmokerForm.X = 52;
            else
                SmokerForm.X = 92;
            //Random smoker_rand = new Random();
            //int k = place_rand.Next(2);
            //if (k == 1)
                mech[Mechanics.game.smoker] = true;
        }

        private void DrawSmoker(Sources source, PaintEventArgs e)
        {
            {
                if (source.smoker_way == 'f')
                    e.Graphics.DrawImage(source.SmokerPic_AnimationForward(ref smoker_anim_pic), SmokerForm.X, SmokerForm.Y, SmokerForm.Width, SmokerForm.Height);
                else
                {
                    e.Graphics.DrawImage(source.SmokerPic_AnimationBackward(smoker_anim_pic), SmokerForm.X, SmokerForm.Y, SmokerForm.Width, SmokerForm.Height);
                    smoker_anim_pic--;
                }
            }
        }

        private void CheckIntersection(PaintEventArgs e, ref int points100_anim)
        {
            if (Rectangle.Intersect(CharacterForm, PegionForm) != Rectangle.Empty)
            {
                points100_anim = 1;
                FormElement.Add100Points(PointsLabel);
                return;
            }
            for (int i = 0; i < 5; i++)
                if (Rectangle.Intersect(CharacterForm, PegionFlock_Form[i]) != Rectangle.Empty)
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
                        e.Graphics.DrawImage(source.Get100Points(), CharacterForm.X, CharacterForm.Y - 30);
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
                        e.Graphics.DrawImage(source.Get100PointsHalfTransparent(), CharacterForm.X, CharacterForm.Y - 40);
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
                        e.Graphics.DrawImage(source.Get100PointsTransparent(), CharacterForm.X, CharacterForm.Y - 50);
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
                if (PegionForm.X >= 0)
                {
                    e.Graphics.DrawImage(source.PegionPic(ref pegion_pic), PegionForm.X, PegionForm.Y, PegionForm.Width, PegionForm.Height);
                    mech.PegionFly(ref PegionForm);
                }
                else
                    mech[Mechanics.game.bird] = false;
            }
            if (mech[Mechanics.game.birds])
            {
                int gone = 0;
                for (int i = 0; i < 5; i++)
                {
                    if (PegionFlock_Form[i].X >= 0)
                    {
                        e.Graphics.DrawImage(source.PegionPic(ref pegion_pic), PegionFlock_Form[i].X, PegionFlock_Form[i].Y, PegionFlock_Form[i].Width, PegionFlock_Form[i].Height);
                        mech.PegionFly(ref PegionFlock_Form[i]);
                    }
                    else
                        gone++;
                }
                if (gone == 5)
                    mech[Mechanics.game.birds] = false;
            }
        }

        private void DrawPauseMenu(PaintEventArgs e)
        {
            e.Graphics.DrawImage(source.GetMenuFont(), 140, 100);
            FormElement.ShowPauseMenuItems(PauseMenu_ContinueLabel, PauseMenu_FAQLabel, PauseMenu_LeaderboardLabel, PauseMenu_ExitLabel);
        }

        private void DrawTotalScore(PaintEventArgs e)
        {
            FormElement.ShowTotalScore(TotalScoreLabel);
            FormElement.InitTotalScore(TotalScoreLabel, PointsLabel);
            FormElement.ShowButtonOK(OKLabel);
        }

        private void HideTotalScore()
        {
            FormElement.HideButtonOK(OKLabel);
            FormElement.HideTotalScore(TotalScoreLabel);
        }

        private void HidePauseMenu()
        {
            FormElement.HidePauseMenuItems(PauseMenu_ContinueLabel, PauseMenu_FAQLabel, PauseMenu_LeaderboardLabel, PauseMenu_ExitLabel);           
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Back) & (mech[Mechanics.game.new_highscore]))
            {
                if (NicknameLabel.Text.Length == 1)
                {
                    NicknameLabel.ResetText();
                    return;
                }
                if (NicknameLabel.Text.Length > 1)
                    NicknameLabel.Text = NicknameLabel.Text.Substring(0, NicknameLabel.Text.Length - 1);
            }
            if ((e.KeyCode != Keys.Back) & (mech[Mechanics.game.new_highscore]))
            {
                if (NicknameLabel.Text.Length < 11)
                    NicknameLabel.Text += e.KeyData.ToString();
            }     
            if ((e.KeyCode == Keys.Enter) & (mech[Mechanics.game.new_highscore]))
            {
                //FileProcessing.DeleteHighscoreFile();
                Application.Exit();
            }
            if (e.KeyCode == Keys.F4)
            {
                mech[Mechanics.character.falling] = false;  // CORE CONDITION PROBLEM!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                mech[Mechanics.game.end] = true;
            }
            if (e.KeyCode == Keys.Escape)
            {
                if (!mech[Mechanics.game.pause])
                {
                    mech[Mechanics.game.pause] = true;
                    return;
                }
                mech[Mechanics.game.pause] = false;
            }
            if (e.KeyCode == Keys.Space)
            {
                mech[Mechanics.character.stand] = false;
                mech[Mechanics.character.jumping] = true;  // CORE CONDITION PROBLEM!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            }
            if (e.KeyCode == Keys.A)
            {
                if (!mech[Mechanics.character.stand] & mech[Mechanics.character.falling])
                    mech.TurnLeft(ref CharacterForm);
            }
            if (e.KeyCode == Keys.D)
            {
                if (!mech[Mechanics.character.stand] & mech[Mechanics.character.falling])
                    mech.TurnRight(ref CharacterForm);
            }
            if (e.KeyCode == Keys.W)
            {
                if (!mech[Mechanics.character.stand] & mech[Mechanics.character.falling])                
                    mech.TurnUp(ref CharacterForm);
            }
            if (e.KeyCode == Keys.S)
            {
                if (!mech[Mechanics.character.stand] & mech[Mechanics.character.falling])                
                    mech.TurnDown(ref CharacterForm);
            }
        }

        private void PauseMenu_ContinueLabel_MouseClick(object sender, MouseEventArgs e)
        {
            KeyEventArgs k = new KeyEventArgs(Keys.Escape);
            Form1_KeyDown(sender, k);
        }

        private void PauseMenu_ContinueLabel_MouseHover(object sender, EventArgs e)
        {
            PauseMenu_ContinueLabel.Image = source.PauseMenu_Focus(0);
        }

        private void PauseMenu_ContinueLabel_MouseLeave(object sender, EventArgs e)
        {
            PauseMenu_ContinueLabel.Image = source.PauseMenu_Regular(0);
        }

        private void PauseMenu_ExitLabel_MouseHover(object sender, EventArgs e)
        {
            PauseMenu_ExitLabel.Image = source.PauseMenu_Focus(3);
        }

        private void PauseMenu_ExitLabel_MouseLeave(object sender, EventArgs e)
        {
            PauseMenu_ExitLabel.Image = source.PauseMenu_Regular(3);
        }

        private void PauseMenu_FAQLabel_MouseHover(object sender, EventArgs e)
        {
            PauseMenu_FAQLabel.Image = source.PauseMenu_Focus(1);
        }

        private void PauseMenu_FAQLabel_MouseLeave(object sender, EventArgs e)
        {
            PauseMenu_FAQLabel.Image = source.PauseMenu_Regular(1);
        }

        private void PauseMenu_LeaderboardLabel_MouseHover(object sender, EventArgs e)
        {
            PauseMenu_LeaderboardLabel.Image = source.PauseMenu_Focus(2);
        }

        private void PauseMenu_LeaderboardLabel_MouseLeave(object sender, EventArgs e)
        {
            PauseMenu_LeaderboardLabel.Image = source.PauseMenu_Regular(2);
        }

        private void ButtonOK_MouseDown(object sender, MouseEventArgs e)
        {
            OKLabel.Image = source.PressedButtonOK();
        }

        private void ButtonOK_MouseClick(object sender, MouseEventArgs e)
        {
            HideTotalScore();
            mech[Mechanics.game.end] = false; // ????????????
            timerTotalScoreAnimation.Stop();
            if (FileProcessing.CheckHighscore(FormElement.GetTotalScore(TotalScoreLabel)))
            {
                mech[Mechanics.game.new_highscore] = true;
                FormElement.ShowNicknameLabel(NicknameLabel);
                FormElement.ShowNewNicknameLabel(NewNicknameLabel);
                FileProcessing.RewriteHighscore(FileProcessing.GetPositionInLeaderBoard(FormElement.GetTotalScore(TotalScoreLabel)), FormElement.GetTotalScore(TotalScoreLabel), NicknameLabel);
            }
            //main menu exit
        }
    }
}