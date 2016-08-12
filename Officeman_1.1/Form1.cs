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

// myLabel.ForeColor = Color.FromArgb(231, 163, 39);

namespace OfficeMan_1._1
{
    public partial class Form1 : Form
    {
        private bool repaint = false;
        private int buildingsMoveCounter = 0;
        private int gradientMoveCounter = 0;
        private int changeTransparency = 0;
        private double globalGameTime = 0;
        private const int MaxFormWidth = 500, MaxFormHeight = 500;
        private Sources source = new Sources();
        private Mechanics mech = new Mechanics();
        private Timer timerGame = new Timer();
        private Rectangle CharacterForm = new Rectangle(150, 102, 40, 75);
        private Rectangle PegionForm = new Rectangle(450, 450, 27, 17);
        private Rectangle CleanerForm = new Rectangle(0, 200, 136, 82); // 25, 36 prev size
        private Rectangle BuildingForm1 = new Rectangle(0, 0, 442, 462); // 442 462
        private Rectangle BuildingForm2 = new Rectangle(0, 462, 442, 462);
        private Rectangle BuildingEnterForm = new Rectangle(0, 462, 442, 462);
        private Rectangle CloudsBackForm = new Rectangle(0, 0, 4200, 4200);
        private Rectangle CloudsFontForm = new Rectangle(0, 0, 9000, 9000);
        private Rectangle BuildingsBackForm = new Rectangle(-37, 35, 521, 521);
        private Rectangle BuildingsMidForm = new Rectangle(-29, 65, 521, 521);
        private Rectangle BuildingsFrontForm = new Rectangle(-29, 45, 521, 521);
        private Rectangle BackgroundGradientBForm = new Rectangle(50, -140, 450, 500);
        private Rectangle BackgroundGradientFForm = new Rectangle(40, 140, 500, 500);
        private Rectangle BackgroundForm = new Rectangle(25, 0, 500, 500);
        private Rectangle HighscoreForm = new Rectangle(0, 0, 500, 500);
        private Rectangle SmokerForm = new Rectangle(92, 297, 38, 71);
        private Rectangle TreesForm = new Rectangle(195, 785, 300, 120);
        private Rectangle CarOneForm = new Rectangle(345, 870, 113, 49);
        private Rectangle CarTwoForm = new Rectangle(205, 870, 105, 49);
        private Rectangle CharacterCrashForm = new Rectangle(400, 200, 122, 56);
        private Rectangle BannerForm = new Rectangle(10, 682, 190, 75);
        private Rectangle TotalScoreForm = new Rectangle(0, 0, 484, 462);
        private Rectangle Points100Form = new Rectangle(0, 0, 25, 11);
        private Rectangle Points50and20Form = new Rectangle(0, 0, 18, 11);
        private int stand_pic = 0;
        private int jump_anim_pic = -1;
        private int cleaner_anim = -1;
        private int pegion_pic = -1;
        private int [] pegion_flock_pic = new int[5];
        private int fall_pic = 0;
        private int points100_anim = 0;
        private int points50_anim = 0;
        private int points20_anim = 0;
        private int smoker_anim_pic = -1;
        private int crash_pic = -1;
        private int banner_trickle_anim = 0;
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
                
                if (globalGameTime >= 60) /// ADD HERE NEW GAME STATES!!!!!!!!!!!!!!!!!!!!!!!!!!!
                {
                    if ((!mech[Mechanics.character.landing]) & (!mech[Mechanics.character.crashing]) & (!mech[Mechanics.game.post_death_animation]) & (!mech[Mechanics.game.totascore]))
                    {
                        BuildingEnterForm = BuildingForm2;
                        BannerForm.Y = BuildingEnterForm.Y + 220;
                        TreesForm.Y = BuildingEnterForm.Y + 335;
                        CarOneForm.Y = BuildingEnterForm.Y + 410;
                        CarTwoForm.Y = BuildingEnterForm.Y + 410;
                        mech[Mechanics.character.falling] = false;
                        mech[Mechanics.character.landing] = true;
                        repaint = false;
                    }
                }
                if (mech[Mechanics.character.falling] | mech[Mechanics.character.landing])
                {
                    globalGameTime += 0.150;
                }
                if (mech[Mechanics.game.cleaner])
                {
                    if (CleanerForm.Y <= -CleanerForm.Height)
                        mech[Mechanics.game.cleaner] = false;
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
                    pegion_flock_pic[0] = -1;
                    PegionFlock_Form[0] = new Rectangle(600, 280, 27, 17);
                    PegionFlock_Form[1] = new Rectangle(470, 250, 27, 17);
                    pegion_flock_pic[1] = -1;
                    PegionFlock_Form[2] = new Rectangle(485, 315, 27, 17);
                    pegion_flock_pic[2] = -1;
                    PegionFlock_Form[3] = new Rectangle(530, 265, 27, 17);
                    pegion_flock_pic[3] = -1;
                    PegionFlock_Form[4] = new Rectangle(560, 330, 27, 17);
                    pegion_flock_pic[4] = -1;
                    Random pegion_probability = new Random();
                    int s = pegion_probability.Next(2);
                    if (s == 1)
                        mech[Mechanics.game.birds] = true;
                }
                Invalidate();
            };
            timerGame.Interval = 70;
            timerGame.Start();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(source.Background(), BackgroundForm.X, BackgroundForm.Y, BackgroundForm.Width, BackgroundForm.Height);
            if (mech[Mechanics.character.stand])
            {
                e.Graphics.DrawImage(source.Background_Gradient_B(), BackgroundGradientBForm.X, BackgroundGradientBForm.Y, BackgroundGradientBForm.Width, BackgroundGradientBForm.Height);
                e.Graphics.DrawImage(source.Background_Gradient_F(), BackgroundGradientFForm.X, BackgroundGradientFForm.Y, BackgroundGradientFForm.Width, BackgroundGradientFForm.Height);                    
               
                e.Graphics.DrawImage(source.Clouds_When_Stand(ref CloudsBackForm), CloudsBackForm.X, CloudsBackForm.Y, CloudsBackForm.Width, CloudsBackForm.Height);
                e.Graphics.DrawImage(source.Buildings_Back(), BuildingsBackForm.X, BuildingsBackForm.Y, BuildingsBackForm.Width, BuildingsBackForm.Height);
                e.Graphics.DrawImage(source.Buildings_Mid(), BuildingsMidForm.X, BuildingsMidForm.Y, BuildingsMidForm.Width, BuildingsMidForm.Height);
                e.Graphics.DrawImage(source.Buildings_Front(), BuildingsFrontForm.X, BuildingsFrontForm.Y, BuildingsFrontForm.Width, BuildingsFrontForm.Height);
                e.Graphics.DrawImage(source.DrawBuilding(), BuildingForm1.X, BuildingForm1.Y, BuildingForm1.Width, BuildingForm1.Height);
                if (mech[Mechanics.game.smoker])
                    DrawSmoker(source, e);
                if (mech[Mechanics.game.cleaner])
                    DrawCleaner(source, e);
                e.Graphics.DrawImage(source.DrawMan_Stand(ref stand_pic), CharacterForm.X, CharacterForm.Y, CharacterForm.Width, CharacterForm.Height);///////////// !!!!!!!!!
                e.Graphics.DrawImage(source.Transparent_Clouds_When_Stand(ref CloudsFontForm), CloudsFontForm.X, CloudsFontForm.Y, 10000, 10000);
                DrawAllBirds(e);
            }
            if (mech[Mechanics.character.jumping])
            {
                
                e.Graphics.DrawImage(source.Background_Gradient_B(), BackgroundGradientBForm.X, BackgroundGradientBForm.Y, BackgroundGradientBForm.Width, BackgroundGradientBForm.Height);
                e.Graphics.DrawImage(source.Background_Gradient_F(), BackgroundGradientFForm.X, BackgroundGradientFForm.Y, BackgroundGradientFForm.Width, BackgroundGradientFForm.Height);                    
                
                e.Graphics.DrawImage(source.Clouds_When_Stand(ref CloudsBackForm), CloudsBackForm.X, CloudsBackForm.Y, CloudsBackForm.Width, CloudsBackForm.Height);
                e.Graphics.DrawImage(source.Buildings_Back(), BuildingsBackForm.X, BuildingsBackForm.Y, BuildingsBackForm.Width, BuildingsBackForm.Height);
                e.Graphics.DrawImage(source.Buildings_Mid(), BuildingsMidForm.X, BuildingsMidForm.Y, BuildingsMidForm.Width, BuildingsMidForm.Height);                
                e.Graphics.DrawImage(source.Buildings_Front(), BuildingsFrontForm.X, BuildingsFrontForm.Y, BuildingsFrontForm.Width, BuildingsFrontForm.Height);
                e.Graphics.DrawImage(source.DrawBuilding(), BuildingForm1.X, BuildingForm1.Y, BuildingForm1.Width, BuildingForm1.Height);
                if (mech[Mechanics.game.smoker])
                    DrawSmoker(source, e);
                if (mech[Mechanics.game.cleaner])
                    DrawCleaner(source, e);
                e.Graphics.DrawImage(source.JumpPic(ref jump_anim_pic, ref CharacterForm), CharacterForm.X, CharacterForm.Y);
                DrawAllBirds(e);                
                e.Graphics.DrawImage(source.Transparent_Clouds_When_Stand(ref CloudsFontForm), CloudsFontForm.X, CloudsFontForm.Y, 10000, 10000);
                if (jump_anim_pic == 4)
                {
                    mech[Mechanics.character.jumping] = false;
                    mech[Mechanics.character.falling] = true;
                    return;
                }
            }
            if (mech[Mechanics.character.falling])
            {
                e.Graphics.DrawImage(source.Clouds_When_Fall(ref CloudsBackForm), CloudsBackForm.X, CloudsBackForm.Y, CloudsBackForm.Width, CloudsBackForm.Height);
                if (mech[Mechanics.game.frontclouds])
                    e.Graphics.DrawImage(source.Transparent_Clouds_When_Fall(ref CloudsFontForm), CloudsFontForm.X, CloudsFontForm.Y, 10000, 10000);
                if (!repaint)
                {
                    buildingsMoveCounter++;
                    gradientMoveCounter++;
                    e.Graphics.DrawImage(source.Background_Gradient_B(), BackgroundGradientBForm.X, BackgroundGradientBForm.Y, BackgroundGradientBForm.Width, BackgroundGradientBForm.Height);
                    e.Graphics.DrawImage(source.Background_Gradient_F(), BackgroundGradientFForm.X, BackgroundGradientFForm.Y, BackgroundGradientFForm.Width, BackgroundGradientFForm.Height);                    
                    e.Graphics.DrawImage(source.Clouds_Back(), CloudsBackForm.X, CloudsBackForm.Y, CloudsBackForm.Width, CloudsBackForm.Height);
                    e.Graphics.DrawImage(source.Buildings_Back(), BuildingsBackForm.X, BuildingsBackForm.Y, BuildingsBackForm.Width, BuildingsBackForm.Height);
                    e.Graphics.DrawImage(source.Buildings_Mid(), BuildingsMidForm.X, BuildingsMidForm.Y, BuildingsMidForm.Width, BuildingsMidForm.Height);
                    e.Graphics.DrawImage(source.Buildings_Front(), BuildingsFrontForm.X, BuildingsFrontForm.Y, BuildingsFrontForm.Width, BuildingsFrontForm.Height);
                    if (buildingsMoveCounter == 9)
                    {
                        source.Buildings_Back_Move(ref BuildingsBackForm);
                        source.Buildings_Front_Move(ref BuildingsFrontForm);
                        source.Buildings_Mid_Move(ref BuildingsMidForm);
                        buildingsMoveCounter = 0;
                    }
                    if (gradientMoveCounter == 5)
                    {
                        source.Background_GradientB_Move(ref BackgroundGradientBForm);
                        source.Background_GradientF_Move(ref BackgroundGradientFForm);
                        gradientMoveCounter = 0;
                    }
                    e.Graphics.DrawImage(source.DrawBuilding_Fall(ref BuildingForm1), BuildingForm1.X, BuildingForm1.Y, BuildingForm1.Width, BuildingForm1.Height);
                    e.Graphics.DrawImage(source.DrawBuilding_Fall(ref BuildingForm2), BuildingForm2.X, BuildingForm2.Y, BuildingForm2.Width, BuildingForm2.Height);
                    source.Smoker_Move(ref SmokerForm);
                    source.Cleaner_Move(ref CleanerForm);
                    if (mech[Mechanics.game.smoker])
                        DrawSmoker(source, e);
                    if (mech[Mechanics.game.cleaner])
                        DrawCleaner(source, e);
                    DrawAllBirds(e);                
                    e.Graphics.DrawImage(source.DrawMan_Fall(ref fall_pic), CharacterForm.X, CharacterForm.Y);
                    if (mech[Mechanics.game.frontclouds])
                        e.Graphics.DrawImage(source.Clouds_Front(), CloudsFontForm.X, CloudsFontForm.Y, 10000, 10000);
                    CheckIntersection(e, ref points100_anim, ref points50_anim, ref points20_anim);
                    Draw20pointsAnimation(e, ref points20_anim);
                    Draw50pointsAnimation(e, ref points50_anim);
                    Draw100pointsAnimation(e, ref points100_anim);
                    FormElement.DrawPoints(PointsLabel);
                    repaint = true;
                    PointsLabel.Visible = true;
                }
                else
                    repaint = false;
            }
            if (mech[Mechanics.character.landing])
            {
                e.Graphics.DrawImage(source.Clouds_When_Fall(ref CloudsBackForm), CloudsBackForm.X, CloudsBackForm.Y, CloudsBackForm.Width, CloudsBackForm.Height);
                if (!repaint)
                {
                    buildingsMoveCounter++;
                    gradientMoveCounter++;
                    e.Graphics.DrawImage(source.Background_Gradient_B(), BackgroundGradientBForm.X, BackgroundGradientBForm.Y, BackgroundGradientBForm.Width, BackgroundGradientBForm.Height);
                    e.Graphics.DrawImage(source.Background_Gradient_F(), BackgroundGradientFForm.X, BackgroundGradientFForm.Y, BackgroundGradientFForm.Width, BackgroundGradientFForm.Height);
                    e.Graphics.DrawImage(source.Clouds_Back(), CloudsBackForm.X, CloudsBackForm.Y, CloudsBackForm.Width, CloudsBackForm.Height);
                    e.Graphics.DrawImage(source.Buildings_Back(), BuildingsBackForm.X, BuildingsBackForm.Y, BuildingsBackForm.Width, BuildingsBackForm.Height);
                    e.Graphics.DrawImage(source.Buildings_Mid(), BuildingsMidForm.X, BuildingsMidForm.Y, BuildingsMidForm.Width, BuildingsMidForm.Height);                    
                    e.Graphics.DrawImage(source.Buildings_Front(), BuildingsFrontForm.X, BuildingsFrontForm.Y, BuildingsFrontForm.Width, BuildingsFrontForm.Height);
                    if (buildingsMoveCounter == 9)
                    {
                        source.Buildings_Back_Move(ref BuildingsBackForm);
                        source.Buildings_Front_Move(ref BuildingsFrontForm);
                        source.Buildings_Mid_Move(ref BuildingsMidForm);
                        buildingsMoveCounter = 0;
                    }
                    if (gradientMoveCounter == 5)
                    {
                        source.Background_GradientB_Move(ref BackgroundGradientBForm);
                        source.Background_GradientF_Move(ref BackgroundGradientFForm);
                        gradientMoveCounter = 0;
                    }
                    e.Graphics.DrawImage(source.TreesMoveAnimation(e, ref TreesForm), TreesForm);
                    e.Graphics.DrawImage(source.CarOneMove(ref CarOneForm), CarOneForm);
                    e.Graphics.DrawImage(source.CarTwoMove(ref CarTwoForm), CarTwoForm);
                    e.Graphics.DrawImage(source.DrawBuilding_Fall(ref BuildingForm1), BuildingForm1.X, BuildingForm1.Y, BuildingForm1.Width, BuildingForm1.Height);
                    e.Graphics.DrawImage(source.BuildingEnterMove(ref BuildingEnterForm), BuildingEnterForm.X, BuildingEnterForm.Y, BuildingEnterForm.Width, BuildingEnterForm.Height); // PAINT IN FROM!!!!!!!!!
                    e.Graphics.DrawImage(source.BannerMove(ref BannerForm), BannerForm.X, BannerForm.Y, BannerForm.Width, BannerForm.Height);

                    source.Smoker_Move(ref SmokerForm);
                    source.Cleaner_Move(ref CleanerForm);
                    if (mech[Mechanics.game.smoker])
                        DrawSmoker(source, e);
                    if (mech[Mechanics.game.cleaner])
                        DrawCleaner(source, e);
                    DrawAllBirds(e);
                    e.Graphics.DrawImage(source.DrawMan_Fall(ref fall_pic), CharacterForm.X, CharacterForm.Y);
                    CheckIntersection(e, ref points100_anim, ref points50_anim, ref points20_anim);
                    Draw20pointsAnimation(e, ref points20_anim);
                    Draw50pointsAnimation(e, ref points50_anim);
                    Draw100pointsAnimation(e, ref points100_anim);
                    FormElement.DrawPoints(PointsLabel);
                    repaint = true;
                    PointsLabel.Visible = true;

                    if (BuildingEnterForm.Y == 0)
                    {
                        mech[Mechanics.character.landing] = false;
                        mech[Mechanics.character.crashing] = true;
                        return;
                    }
                }
                  else
                    repaint = false;
            }
            if(mech[Mechanics.character.crashing])
            {
                e.Graphics.DrawImage(source.Clouds_When_Stand(ref CloudsBackForm), CloudsBackForm.X, CloudsBackForm.Y, CloudsBackForm.Width, CloudsBackForm.Height);
                if (!repaint)
                {
                    e.Graphics.DrawImage(source.Background_Gradient_B(), BackgroundGradientBForm.X, BackgroundGradientBForm.Y, BackgroundGradientBForm.Width, BackgroundGradientBForm.Height);
                    e.Graphics.DrawImage(source.Background_Gradient_F(), BackgroundGradientFForm.X, BackgroundGradientFForm.Y, BackgroundGradientFForm.Width, BackgroundGradientFForm.Height);
                    e.Graphics.DrawImage(source.Clouds_When_Stand(ref CloudsBackForm), CloudsBackForm.X, CloudsBackForm.Y, CloudsBackForm.Width, CloudsBackForm.Height);
                    e.Graphics.DrawImage(source.Buildings_Back(), BuildingsBackForm.X, BuildingsBackForm.Y, BuildingsBackForm.Width, BuildingsBackForm.Height);
                    e.Graphics.DrawImage(source.Buildings_Mid(), BuildingsMidForm.X, BuildingsMidForm.Y, BuildingsMidForm.Width, BuildingsMidForm.Height);                    
                    e.Graphics.DrawImage(source.Buildings_Front(), BuildingsFrontForm.X, BuildingsFrontForm.Y, BuildingsFrontForm.Width, BuildingsFrontForm.Height);
                    source.TreesAnimation(e, TreesForm);
                    e.Graphics.DrawImage(source.CarOneInit(), CarOneForm);
                    e.Graphics.DrawImage(source.CarTwoInit(), CarTwoForm);
                    e.Graphics.DrawImage(source.BuildingEnter(), BuildingEnterForm.X, BuildingEnterForm.Y, BuildingEnterForm.Width, BuildingEnterForm.Height);
                    e.Graphics.DrawImage(source.Banner_Init(), BannerForm.X, BannerForm.Y, BannerForm.Width, BannerForm.Height);
                    //
                    if (mech[Mechanics.game.cleaner])
                        DrawCleaner(source, e);
                    DrawAllBirds(e);
                    mech.TurnDown(ref CharacterForm);
                    if (CharacterForm.Y >= 400)
                        DrawCrash(e);
                    else
                        e.Graphics.DrawImage(source.DrawMan_Fall(ref fall_pic), CharacterForm.X, CharacterForm.Y);
                    CheckIntersection(e, ref points100_anim, ref points50_anim, ref points20_anim);
                    Draw20pointsAnimation(e, ref points20_anim);
                    Draw50pointsAnimation(e, ref points50_anim);
                    Draw100pointsAnimation(e, ref points100_anim);
                    FormElement.DrawPoints(PointsLabel);
                    repaint = true;
                    PointsLabel.Visible = true;
                }
                else
                    repaint = false;
            }
            if(mech[Mechanics.game.post_death_animation])
            {
                 e.Graphics.DrawImage(source.Clouds_When_Stand(ref CloudsBackForm), CloudsBackForm.X, CloudsBackForm.Y, CloudsBackForm.Width, CloudsBackForm.Height);
                 if (!repaint)
                 {
                     e.Graphics.DrawImage(source.Background_Gradient_B(), BackgroundGradientBForm.X, BackgroundGradientBForm.Y, BackgroundGradientBForm.Width, BackgroundGradientBForm.Height);
                     e.Graphics.DrawImage(source.Background_Gradient_F(), BackgroundGradientFForm.X, BackgroundGradientFForm.Y, BackgroundGradientFForm.Width, BackgroundGradientFForm.Height);
                     e.Graphics.DrawImage(source.Clouds_When_Stand(ref CloudsBackForm), CloudsBackForm.X, CloudsBackForm.Y, CloudsBackForm.Width, CloudsBackForm.Height);
                     e.Graphics.DrawImage(source.Buildings_Back(), BuildingsBackForm.X, BuildingsBackForm.Y, BuildingsBackForm.Width, BuildingsBackForm.Height);
                     e.Graphics.DrawImage(source.Buildings_Mid(), BuildingsMidForm.X, BuildingsMidForm.Y, BuildingsMidForm.Width, BuildingsMidForm.Height);                     
                     e.Graphics.DrawImage(source.Buildings_Front(), BuildingsFrontForm.X, BuildingsFrontForm.Y, BuildingsFrontForm.Width, BuildingsFrontForm.Height);
                     source.TreesAnimation(e, TreesForm);
                     e.Graphics.DrawImage(source.CarOneInit(), CarOneForm);
                     e.Graphics.DrawImage(source.CarTwoInit(), CarTwoForm);
                     e.Graphics.DrawImage(source.BuildingEnter(), BuildingEnterForm.X, BuildingEnterForm.Y, BuildingEnterForm.Width, BuildingEnterForm.Height);
                     e.Graphics.DrawImage(source.Banner_Trickle(ref banner_trickle_anim, ref BannerForm), BannerForm.X, BannerForm.Y, BannerForm.Width, BannerForm.Height);                         
                     if (mech[Mechanics.game.cleaner])
                         DrawCleaner(source, e);
                     DrawAllBirds(e);
                    e.Graphics.DrawImage(source.DrawDead(), CharacterCrashForm.X, CharacterCrashForm.Y, CharacterCrashForm.Width, CharacterCrashForm.Height);
                     repaint = true;
                 }
                 else
                     repaint = false;
            }
            if (mech[Mechanics.game.totascore])
            {
                ShowTotalScore(e);
            }
            if (mech[Mechanics.game.pause])
                DrawPauseMenu(e);
            else
                HidePauseMenu();
            if (mech[Mechanics.game.end])
            {
                OKLabel.Visible = true;
                e.Graphics.DrawImage(source.Background_Gradient_B(), BackgroundGradientBForm.X, BackgroundGradientBForm.Y, BackgroundGradientBForm.Width, BackgroundGradientBForm.Height);
                e.Graphics.DrawImage(source.Background_Gradient_F(), BackgroundGradientFForm.X, BackgroundGradientFForm.Y, BackgroundGradientFForm.Width, BackgroundGradientFForm.Height);
                
                e.Graphics.DrawImage(source.Clouds_When_Stand(ref CloudsBackForm), CloudsBackForm.X, CloudsBackForm.Y, CloudsBackForm.Width, CloudsBackForm.Height);
                e.Graphics.DrawImage(source.Buildings_Back(), BuildingsBackForm.X, BuildingsBackForm.Y, BuildingsBackForm.Width, BuildingsBackForm.Height);
                e.Graphics.DrawImage(source.Buildings_Front(), BuildingsFrontForm.X, BuildingsFrontForm.Y, BuildingsFrontForm.Width, BuildingsFrontForm.Height);
                source.TreesAnimation(e, TreesForm);
                e.Graphics.DrawImage(source.CarOneInit(), CarOneForm);
                e.Graphics.DrawImage(source.CarTwoInit(), CarTwoForm);
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
            if (BuildingForm1.Y <= -462)
            {
                BuildingForm1.Y = 0;
                BuildingForm2.Y = 462;
                if (SmokerForm.Y <= -SmokerForm.Height)
                    CreateSmoker();
            }
            if (!mech[Mechanics.game.cleaner])
            {
                if (CleanerForm.Y <= -CleanerForm.Height)
                    CreateCleaner();
            }
            if ((crash_pic == 4) & (mech[Mechanics.character.crashing]))
            {
                mech[Mechanics.character.crashing] = false;
                mech[Mechanics.game.post_death_animation] = true;
                repaint = true;
            }
            if (banner_trickle_anim == 5 & mech[Mechanics.game.post_death_animation])
            {
                PointsLabel.Visible = false;
                mech[Mechanics.character.falling] = false;
                mech[Mechanics.character.landing] = false;
                mech[Mechanics.character.crashing] = false;
                mech[Mechanics.game.post_death_animation] = false;
                mech[Mechanics.game.totascore] = true;
                //repaint = true;
            }
            //if ((banner_trickle_anim == 5) & (mech[Mechanics.character.crashing]))
            //{
            //    mech[Mechanics.character.crashing] = false;
            //    mech[Mechanics.game.post_death_animation] = true;
            //    repaint = true;
            //}
            e.Dispose();
        }

        public void ShowTotalScore(PaintEventArgs e)
        {
            if (source.highscore == '1')
            {
                source.highscore = '2';
                e.Graphics.DrawImage(source.TotalScoreBG1(), TotalScoreForm.X, TotalScoreForm.Y, TotalScoreForm.Width, TotalScoreForm.Height);
                return;
            }
            if (source.highscore == '2')
            {
                source.highscore = '1';
                e.Graphics.DrawImage(source.TotalScoreBG2(), TotalScoreForm.X, TotalScoreForm.Y, TotalScoreForm.Width, TotalScoreForm.Height);
            }
            //FormElement.PigeonAmountLabel_Score(PigeonAmountLabel);
            //FormElement.CleanerAmountLabel_Score(CleanerAmountLabel);
            //FormElement.SmokerAmountLabel_Score(SmokerAmountLabel);
            //FormElement.TimeAmountLabel_Score(TimeAmountLabel);
            //FormElement.TotalScore(TotalScoreLabel);
        }

        public void DrawCrash(PaintEventArgs e)
        {
            switch(crash_pic)
            {
                case 0:
                    {
                        crash_pic = 1;
                        CharacterCrashForm.Y -= 20;
                        CharacterCrashForm.Width = 115;
                        CharacterCrashForm.Height = 77;
                        break;
                    }
                    case 1:
                    {
                        crash_pic = 2;
                        CharacterCrashForm.X -= 9;
                        CharacterCrashForm.Y -= 19;
                        CharacterCrashForm.Width = 147;
                        CharacterCrashForm.Height = 97;
                        break;
                    }
                    case 2:
                    {
                        crash_pic = 3;
                        CharacterCrashForm.X -= 25;
                        CharacterCrashForm.Y -= 16;
                        CharacterCrashForm.Width = 178;
                        CharacterCrashForm.Height = 113;
                        break;
                    }
                    case 3:
                    {
                        crash_pic = 4;
                        CharacterCrashForm.Y += 75;
                        CharacterCrashForm.Width = 161;
                        CharacterCrashForm.Height = 11;
                        break;
                    }
                default:
                    {
                        crash_pic = 0;
                        CharacterCrashForm.X = CharacterForm.X - 20;
                        CharacterCrashForm.Y = CharacterForm.Y;
                        CharacterCrashForm.Width = 122;
                        CharacterCrashForm.Height = 56;
                        break;
                    }
            }
            e.Graphics.DrawImage(source.CrashPictures(crash_pic), CharacterCrashForm.X,CharacterCrashForm.Y, CharacterCrashForm.Width, CharacterCrashForm.Height);
        }
        private void CreateCleaner()
        {
            CleanerForm.Y = 554;
            Random place_rand = new Random();
            int s = place_rand.Next(2);
            if (s == 1)
                CleanerForm.X = 15;
            else
                CleanerForm.X = 80;
            //Random cleaner_rand = new Random();
            //int k = place_rand.Next(2);
            //if (k == 1)
            mech[Mechanics.game.cleaner] = true;
        }

        private void CreateSmoker()
        {
            SmokerForm.Y = 511;
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

        private void DrawCleaner(Sources source, PaintEventArgs e)
        {
            {
                if (source.cleaner_way == 'f')
                    e.Graphics.DrawImage(source.CleanerPic_AnimationForward(ref cleaner_anim), CleanerForm.X, CleanerForm.Y, CleanerForm.Width, CleanerForm.Height);
                else
                {
                    e.Graphics.DrawImage(source.CleanerPic_AnimationBackward(cleaner_anim), CleanerForm.X, CleanerForm.Y, CleanerForm.Width, CleanerForm.Height);
                    cleaner_anim--;
                }
            }
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

        private void CheckIntersection(PaintEventArgs e, ref int points100_anim, ref int points50_anim, ref int points20_anim)
        {
            if (Rectangle.Intersect(CharacterForm, new Rectangle(SmokerForm.X + 6, SmokerForm.Y + 11, 13, 23)) != Rectangle.Empty)
            {
                points50_anim = 1;
                FormElement.Add50Points(PointsLabel);
                return;
            }
            if (Rectangle.Intersect(CharacterForm, new Rectangle(CleanerForm.X + 27, CleanerForm.Y, 14, 35)) != Rectangle.Empty)
            {
                points20_anim = 1;
                FormElement.Add20Points(PointsLabel);
                return;
            }
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

        private void Draw20pointsAnimation(PaintEventArgs e, ref int points20_anim)
        {
            switch (points20_anim)
            {
                case 0:
                    break;
                case 1:
                    {
                        e.Graphics.DrawImage(source.Get20Points(), CharacterForm.X, CharacterForm.Y - 30, Points50and20Form.Width, Points50and20Form.Height);
                        points20_anim = 2;
                        break;
                    }
                case 2:
                    {
                        e.Graphics.DrawImage(source.Get20PointsHalfTransparent(), CharacterForm.X, CharacterForm.Y - 40, Points50and20Form.Width, Points50and20Form.Height);
                        points20_anim = 3;
                        break;
                    }
                case 3:
                    {
                        e.Graphics.DrawImage(source.Get20PointsTransparent(), CharacterForm.X, CharacterForm.Y - 50, Points50and20Form.Width, Points50and20Form.Height);
                        points20_anim = 0;
                        break;
                    }
                default:
                    break;
            }
        }

        private void Draw50pointsAnimation(PaintEventArgs e, ref int points50_anim)
        {
            switch (points50_anim)
            {
                case 0:
                    break;
                case 1:
                    {
                        e.Graphics.DrawImage(source.Get50Points(), CharacterForm.X, CharacterForm.Y - 30, Points50and20Form.Width, Points50and20Form.Height);
                        points50_anim = 2;
                        break;
                    }
                case 2:
                    {
                        e.Graphics.DrawImage(source.Get50PointsHalfTransparent(), CharacterForm.X, CharacterForm.Y - 40, Points50and20Form.Width, Points50and20Form.Height);
                        points50_anim = 3;
                        break;
                    }
                case 3:
                    {
                        e.Graphics.DrawImage(source.Get50PointsTransparent(), CharacterForm.X, CharacterForm.Y - 50, Points50and20Form.Width, Points50and20Form.Height);
                        points50_anim = 0;
                        break;
                    }
                default:
                    break;
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
                        e.Graphics.DrawImage(source.Get100Points(), CharacterForm.X, CharacterForm.Y - 30, Points100Form.Width, Points100Form.Height);
                        points100_anim = 2;
                        break;
                    }
                case 2:
                    {
                        e.Graphics.DrawImage(source.Get100PointsHalfTransparent(), CharacterForm.X, CharacterForm.Y - 40, Points100Form.Width, Points100Form.Height);
                        points100_anim = 3;
                        break;
                    }
                case 3:
                    {
                        e.Graphics.DrawImage(source.Get100PointsTransparent(), CharacterForm.X, CharacterForm.Y - 50, Points100Form.Width, Points100Form.Height);
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
                        e.Graphics.DrawImage(source.PegionPic(ref pegion_flock_pic[i]), PegionFlock_Form[i].X, PegionFlock_Form[i].Y, PegionFlock_Form[i].Width, PegionFlock_Form[i].Height);
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
                mech[Mechanics.character.landing] = true;
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
                if (mech[Mechanics.character.stand])
                {
                    mech[Mechanics.character.stand] = false;
                    mech[Mechanics.character.jumping] = true;
                }
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