﻿using Officeman_1._1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using OfficeMan_1._1;

namespace Officeman_1._1
{
    /// <summary>
    /// This class is presenting all pictures and functions which controls the logic of all animation.
    /// </summary>
    class Sources
    {
        Image building_init, building_fall, building_enter;
        Image sky_clouds;
        public char cleaner_way = 'f';
        public char smoker_way = 'f';
        public char highscore = '1';
        public char mainmenu_bg = '1';
        private char okaaay_state = 'i';
        private char mooore_state = 'i';
        public char new_record_bg = '1';
        public char leaderboard_state = '1';
        static int man_stand_size = 4;
        static int man_fall_size = 4;
        static int pegion_fly_size = 4;
        static int man_jump_size = 6;
        static int pausemenu_size = 4;
        static int cleaner_size = 4;
        static int smoker_size = 4;
        static int crash_pic_size = 5;
        static int banner_trickle_size = 6;
        static Image[] man_stand = new Image[man_stand_size];
        static Image[] cleaner = new Image[cleaner_size];
        static Image[] man_fall = new Image[man_fall_size];
        static Image[] smoker = new Image[smoker_size];
        Image[] man_jump = new Image[man_jump_size];
        Image[] pegion_fly = new Image[pegion_fly_size];
        Image[] pausemenu_reg = new Image[pausemenu_size];
        Image[] pausemenu_focus = new Image[pausemenu_size];
        Image[] crashpictures = new Image[crash_pic_size];
        Image[] banner_trickle = new Image[banner_trickle_size];
        Image menufont, totalscore_blue, totalscore_gold, button_ok, transparent_clouds;
        Image buildings_back, buildings_front, background, background_gradient_fst, background_gradient_sec, highscore_init, highscore_next, empty, new_nicknameLabel_bg_init;
        Image new_nicknameLabel_bg_next, tree_init, tree_next, car_one_init, buildings_mid;
        Image points100, points100ht, points100t, points50, points50ht, points50t, points20, points20ht, points20t;
        Image highscore1, highscore2, car_two_init, okaaay_init, okaaay_next, menu_background1, menu_background2, okaaay_pressed, menu_start_on;
        Image menu_start_press, menu_shop_on, menu_shop_press, menu_highscore_on, menu_highscore_press, menu_tutorial_on, menu_tutorial_press;
        Image menu_exit_on, menu_exit_press, menu_start_init, menu_shop_init, menu_highscore_init, menu_tutorial_init, menu_exit_init;
        Image newrecord_bg_init, newrecord_bg_next, mooore_init, mooore_next, mooore_pressed, leaderboard_init, leaderboard_next, woohoo_init, woohoo_next;
        Image woohoo_pressed, eh_init, eh_next, eh_pressed, audio_on, audio_off, audio_on_space, audio_off_space, audio_on_menu, audio_off_menu;
        Image audio_off_hightscore, audio_on_hightscore, audio_off_back, audio_on_back, tree1, tree2, tree3, lb_menu_gradient;

        public Sources()
        {
            building_init = Image.FromFile("..\\..\\images\\building_prev.png");
            building_fall = Image.FromFile("..\\..\\images\\building_flight.png");
            sky_clouds = Image.FromFile("..\\..\\images\\sky_clouds.png");
            man_stand[0] = Image.FromFile("..\\..\\images\\stand1.png");
            man_stand[1] = Image.FromFile("..\\..\\images\\stand2.png");
            man_stand[2] = Image.FromFile("..\\..\\images\\stand3.png");
            man_stand[3] = Image.FromFile("..\\..\\images\\stand4.png");
            man_fall[0] = Image.FromFile("..\\..\\images\\fall1.png");
            man_fall[1] = Image.FromFile("..\\..\\images\\fall2.png");
            man_fall[2] = Image.FromFile("..\\..\\images\\fall3.png");
            man_fall[3] = Image.FromFile("..\\..\\images\\fall4.png");
            man_jump[0] = Image.FromFile("..\\..\\images\\jump1.png");
            man_jump[1] = Image.FromFile("..\\..\\images\\jump2.png");
            man_jump[2] = Image.FromFile("..\\..\\images\\jump3.png");
            man_jump[3] = Image.FromFile("..\\..\\images\\jump4.png");
            man_jump[4] = Image.FromFile("..\\..\\images\\jump5.png");
            pegion_fly[0] = Image.FromFile("..\\..\\images\\pegion1.png");
            pegion_fly[1] = Image.FromFile("..\\..\\images\\pegion2.png");
            pegion_fly[2] = Image.FromFile("..\\..\\images\\pegion3.png");
            pegion_fly[3] = Image.FromFile("..\\..\\images\\pegion4.png");
            points100 = Image.FromFile("..\\..\\images\\points100.png");
            points100ht = Image.FromFile("..\\..\\images\\points100ht.png");
            points100t = Image.FromFile("..\\..\\images\\points100t.png");
            menufont = Image.FromFile("..\\..\\images\\menufont.png");
            pausemenu_reg[0] = Image.FromFile("..\\..\\images\\pausemenu_continue.png");
            pausemenu_focus[0] = Image.FromFile("..\\..\\images\\pausemenu_continue_focus.png");
            pausemenu_reg[1] = Image.FromFile("..\\..\\images\\pausemenu_faq.png");
            pausemenu_focus[1] = Image.FromFile("..\\..\\images\\pausemenu_faq_focus.png");
            pausemenu_reg[2] = Image.FromFile("..\\..\\images\\pausemenu_leaderboard.png");
            pausemenu_focus[2] = Image.FromFile("..\\..\\images\\pausemenu_leaderboard_focus.png");
            pausemenu_reg[3] = Image.FromFile("..\\..\\images\\pausemenu_exit.png");
            pausemenu_focus[3] = Image.FromFile("..\\..\\images\\pausemenu_exit_focus.png");
            totalscore_blue = Image.FromFile("..\\..\\images\\TotalPoints_Blue.png");
            totalscore_gold = Image.FromFile("..\\..\\images\\TotalPoints_Gold.png");
            button_ok = Image.FromFile("..\\..\\images\\ButtonOK_pressed.png");
            building_enter = Image.FromFile("..\\..\\images\\building_enter.png");
            transparent_clouds = Image.FromFile("..\\..\\images\\transparent_clouds0.png");
            buildings_back = Image.FromFile("..\\..\\images\\buildings_back.png");
            buildings_front = Image.FromFile("..\\..\\images\\buildings_front.png");
            buildings_mid = Image.FromFile("..\\..\\images\\buildings_mid.png");
            background = Image.FromFile("..\\..\\images\\background.png");
            background_gradient_sec = Image.FromFile("..\\..\\images\\bg_gradient2.png");
            background_gradient_fst = Image.FromFile("..\\..\\images\\bg_gradient1.png");
            highscore_init = Image.FromFile("..\\..\\images\\highscore_init.png");
            highscore_next = Image.FromFile("..\\..\\images\\highscore_next.png");
            empty = Image.FromFile("..\\..\\images\\empty.png");
            new_nicknameLabel_bg_init = Image.FromFile("..\\..\\images\\new_nicknamelabel_bg_init.png");
            new_nicknameLabel_bg_next = Image.FromFile("..\\..\\images\\new_nicknamelabel_bg_next.png");
            smoker[0] = Image.FromFile("..\\..\\images\\smoker1.png");
            smoker[1] = Image.FromFile("..\\..\\images\\smoker2.png");
            smoker[2] = Image.FromFile("..\\..\\images\\smoker3.png");
            smoker[3] = Image.FromFile("..\\..\\images\\smoker4.png");
            tree_init = Image.FromFile("..\\..\\images\\tree1.png");
            tree_next = Image.FromFile("..\\..\\images\\tree2.png");
            crashpictures[0] = Image.FromFile("..\\..\\images\\crash1.png");
            crashpictures[1] = Image.FromFile("..\\..\\images\\crash2.png");
            crashpictures[2] = Image.FromFile("..\\..\\images\\crash3.png");
            crashpictures[3] = Image.FromFile("..\\..\\images\\crash4.png");
            crashpictures[4] = Image.FromFile("..\\..\\images\\crash5.png");
            car_one_init = Image.FromFile("..\\..\\images\\car_one_init.png");
            car_two_init = Image.FromFile("..\\..\\images\\car_two_init.png");
            banner_trickle[0] = Image.FromFile("..\\..\\images\\baner1.png");
            banner_trickle[1] = Image.FromFile("..\\..\\images\\baner2.png");
            banner_trickle[2] = Image.FromFile("..\\..\\images\\baner3.png");
            banner_trickle[3] = Image.FromFile("..\\..\\images\\baner4.png");
            banner_trickle[4] = Image.FromFile("..\\..\\images\\baner5.png");
            banner_trickle[5] = Image.FromFile("..\\..\\images\\baner6.png");
            cleaner[0] = Image.FromFile("..\\..\\images\\cleaner1.png");
            cleaner[1] = Image.FromFile("..\\..\\images\\cleaner2.png");
            cleaner[2] = Image.FromFile("..\\..\\images\\cleaner3.png");
            cleaner[3] = Image.FromFile("..\\..\\images\\cleaner4.png");
            points20 = Image.FromFile("..\\..\\images\\points20.png");
            points20ht = Image.FromFile("..\\..\\images\\points20ht.png");
            points20t = Image.FromFile("..\\..\\images\\points20t.png");
            points50 = Image.FromFile("..\\..\\images\\points50.png");
            points50ht = Image.FromFile("..\\..\\images\\points50ht.png");
            points50t = Image.FromFile("..\\..\\images\\points50t.png");
            highscore1 = Image.FromFile("..\\..\\images\\highscore1.png");
            highscore2 = Image.FromFile("..\\..\\images\\highscore2.png");
            okaaay_next = Image.FromFile("..\\..\\images\\okaaay_next.png");
            okaaay_init = Image.FromFile("..\\..\\images\\okaaay_init.png");
            okaaay_pressed = Image.FromFile("..\\..\\images\\okaaay_pressed.png");
            menu_background1 = Image.FromFile("..\\..\\images\\menu_background1.png");
            menu_background2 = Image.FromFile("..\\..\\images\\menu_background2.png");
            menu_start_init = Image.FromFile("..\\..\\images\\menu_start.png");
            menu_start_on = Image.FromFile("..\\..\\images\\menu_start_on.png");
            menu_start_press = Image.FromFile("..\\..\\images\\menu_start_press.png");
            menu_shop_init = Image.FromFile("..\\..\\images\\menu_shop.png");
            menu_shop_on = Image.FromFile("..\\..\\images\\menu_shop_on.png");
            menu_shop_press = Image.FromFile("..\\..\\images\\menu_shop_press.png");
            menu_highscore_init = Image.FromFile("..\\..\\images\\menu_highscore.png");
            menu_highscore_on = Image.FromFile("..\\..\\images\\menu_highscore_on.png");
            menu_highscore_press = Image.FromFile("..\\..\\images\\menu_highscore_press.png");
            menu_tutorial_init = Image.FromFile("..\\..\\images\\menu_tutorial.png");
            menu_tutorial_on = Image.FromFile("..\\..\\images\\menu_tutorial_on.png");
            menu_tutorial_press = Image.FromFile("..\\..\\images\\menu_tutorial_press.png");
            menu_exit_init = Image.FromFile("..\\..\\images\\menu_exit.png");
            menu_exit_on = Image.FromFile("..\\..\\images\\menu_exit_on.png");
            menu_exit_press = Image.FromFile("..\\..\\images\\menu_exit_press.png");
            newrecord_bg_init = Image.FromFile("..\\..\\images\\new_record0.png");
            newrecord_bg_next = Image.FromFile("..\\..\\images\\new_record1.png");
            mooore_init = Image.FromFile("..\\..\\images\\mooore_init.png");
            mooore_next = Image.FromFile("..\\..\\images\\mooore_next.png");
            mooore_pressed = Image.FromFile("..\\..\\images\\mooore_pressed.png");
            leaderboard_init = Image.FromFile("..\\..\\images\\leaderboard0.png");
            leaderboard_next = Image.FromFile("..\\..\\images\\leaderboard1.png");
            woohoo_init = Image.FromFile("..\\..\\images\\woohoo_init.png");
            woohoo_next = Image.FromFile("..\\..\\images\\woohoo_next.png");
            woohoo_pressed = Image.FromFile("..\\..\\images\\woohoo_pressed.png");
            eh_init = Image.FromFile("..\\..\\images\\eh_init.png");
            eh_next = Image.FromFile("..\\..\\images\\eh_next.png");
            eh_pressed = Image.FromFile("..\\..\\images\\eh_pressed.png");
            audio_on = Image.FromFile("..\\..\\images\\audio_on.png");
            audio_off = Image.FromFile("..\\..\\images\\audio_off.png");
            audio_off_back = Image.FromFile("..\\..\\images\\audio_off_back.png");
            audio_on_back = Image.FromFile("..\\..\\images\\audio_on_back.png");
            audio_off_hightscore = Image.FromFile("..\\..\\images\\audio_off_highscore.png");
            audio_on_hightscore = Image.FromFile("..\\..\\images\\audio_on_highscore.png");
            audio_off_menu = Image.FromFile("..\\..\\images\\audio_off_menu.png");
            audio_on_menu = Image.FromFile("..\\..\\images\\audio_on_menu.png");
            audio_off_space = Image.FromFile("..\\..\\images\\audio_off_space.png");
            audio_on_space = Image.FromFile("..\\..\\images\\audio_on_space.png");
            tree1 = Image.FromFile("..\\..\\images\\tree1.png");
            tree2 = Image.FromFile("..\\..\\images\\tree2.png");
            tree3 = Image.FromFile("..\\..\\images\\tree3.png");
            lb_menu_gradient = Image.FromFile("..\\..\\images\\leaderboard_menu_anim.png");
        }

        public Image Lb_Menu_Gradient
        {
            get { return lb_menu_gradient; }
        }

        public Image AudioIcon_Menu_On
        {
            get { return audio_on_menu; }
        }
        public Image AudioIcon_Menu_Off
        {
            get { return audio_off_menu; }
        }
    
        public Image AudioIcon_Back_Off
        {
            get { return audio_off_back; }
        }

        public Image  AudioIcon_Back_On
        {
            get { return audio_on_back; }
        }

        public Image AudioIcon_Highscore_On
        {
            get { return audio_on_hightscore; }
        }
        public Image AudioIcon_Highscore_Off
        {
            get { return audio_off_hightscore; }
        }

        public Image AudioIcon_Space_On
        {
            get { return audio_on_space; }
        }

        public Image AudioIcon_Space_Off
        {
            get
            { return audio_off_space; }
        }

        public Image Audio_On
        {
            get { return audio_on; }
        }

        public Image Audio_Off
        {
            get { return audio_off; }
        }

        public Image WOOHOO_Init
        {
            get { return woohoo_init; }
        }

        public Image WOOHOO_Enter
        {
            get { return woohoo_next; }
        }

        public Image WOOHOO_Pressed
        {
            get { return woohoo_pressed; }
        }

        public Image Eh_Init
        {
            get { return eh_init; }
        }

        public Image Eh_Enter
        {
            get { return eh_next; }
        }
        public Image Eh_Pressed
        {
            get { return eh_pressed; }
        }

        public Image Leaderboard_Init
        {
            get { return leaderboard_init; }
        }
        public Image Leaderboard_Next
        {
            get { return leaderboard_next; }
        }

        public Image MOOORE_Pressed
        {
            get { return mooore_pressed; }
        }

        public void ChangeMOOOREImage(ref Label MOOORELabel)
        {
            if (mooore_state == 'i')
            {
                MOOORELabel.Image = mooore_next;
                mooore_state = 'n';
                return;
            }
            if (mooore_state == 'n')
            {
                MOOORELabel.Image = mooore_init;
                mooore_state = 'i';
            }
        }

        public Image NewRecordBG1
        {
            get { return newrecord_bg_init; }
        }

        public Image NewRecordBG2
        {
            get { return newrecord_bg_next; }
        }

        public Image Menu_Start_Init
        {
            get { return menu_start_init; }
        }
        public Image Menu_Start_Enter
        {
            get { return menu_start_on; }
        }

        public Image Menu_Start_Press
        {
            get { return menu_start_press; }
        }
        public Image Menu_Shop_Init
        {
            get { return menu_shop_init; }
        }

        public Image Menu_Shop_Enter
        {
            get { return menu_shop_on; }
        }

        public Image Menu_Shop_Press
        {
            get { return menu_shop_press; }
        }
        public Image Menu_Highscore_Init
        {
            get { return menu_highscore_init; }
        }

        public Image Menu_Highscore_Enter
        {
            get { return menu_highscore_on; }
        }

        public Image Menu_Highscore_Press
        {
            get { return menu_highscore_press; }
        }
        public Image Menu_Tutorial_Init
        {
            get { return menu_tutorial_init; }
        }

        public Image Menu_Tutorial_Enter
        {
            get { return menu_tutorial_on; }
        }

        public Image Menu_Tutorial_Press
        {
            get { return menu_tutorial_press; }
        }
        public Image Menu_Exit_Init
        {
            get { return menu_exit_init; }
        }

        public Image Menu_Exit_Enter
        {
            get { return menu_exit_on; }
        }

        public Image Menu_Exit_Press
        {
            get { return menu_exit_press; }
        }

        public Image MainMenuBG2
        {
            get { return menu_background2; }
        }

        public Image MainMenuBG1
        {
            get { return menu_background1; }
        }
        
        public Image OKAAAY_Pressed
        {
            get { return okaaay_pressed; }
        }

        public void ChangeOKAAAYImage(ref Label OKAAAYLabel)
        {
            if (okaaay_state == 'i')
            {
                OKAAAYLabel.Image = okaaay_next;
                okaaay_state = 'n';
                return;
            }
            if (okaaay_state == 'n')
            {
                OKAAAYLabel.Image = okaaay_init;
                okaaay_state = 'i';
            }
        }

        public Image TotalScoreBG1
        {
            get { return highscore1; }
        }

        public Image TotalScoreBG2
        {
            get { return highscore2; }
        }
        public Image CleanerPic_AnimationForward(ref int index)
        {
            switch (index)
            {
                case 0:
                    {
                        index = 1;
                        break;
                    }
                case 1:
                    {
                        index = 2;
                        break;
                    }
                case 2:
                    {
                        index = 3;
                        break;
                    }
                case 3:
                    {
                        index = 4;
                        return cleaner[3];
                    }
                case 4:
                    {
                        index = 5;
                        return cleaner[3];
                    }
                case 5:
                    {
                        cleaner_way = 'b';
                        index = 6;
                        return cleaner[3];
                    }
             
                default:
                    {
                        index = 0;
                        break;
                    }
            }
            return cleaner[index];
        }


        public Image CleanerPic_AnimationBackward(int index)
        {
            if (index == -1)
            {
                cleaner_way = 'f';
                return cleaner[0];
            }
            if (index > 3)
                return cleaner[3];
            return cleaner[index];
        }

        public Image Banner_Trickled
        {
            get { return banner_trickle[5]; }            
        }

        public Image Banner_Trickle(ref int banner_trickle_anim, ref Rectangle BannerForm)
        {
            switch(banner_trickle_anim)
            {
                case 0:
                    {
                        banner_trickle_anim = 1;
                        break;
                    }
                case 1:
                    {
                        banner_trickle_anim = 2;
                        break;
                    }
                case 2:
                    {
                        banner_trickle_anim = 3;
                        break;
                    }
                case 3:
                    {
                        BannerForm.Height = 63;
                        banner_trickle_anim = 4;
                        break;
                    }
                case 4:
                    {
                        banner_trickle_anim = 5;
                        break;
                    }
            }
            return banner_trickle[banner_trickle_anim];
        }

        public Image Banner_Init
        {
            get { return banner_trickle[0]; }
        }

        public Image BannerMove(ref Rectangle BannerForm)
        {
            BannerForm.Y -= 14;
            return banner_trickle[0];
        }

        public Image DrawDead
        {
            get {return crashpictures[4]; }
        }

        public Image CrashPictures(int crash_pic)
        {
            return crashpictures[crash_pic];
        }

        public Image CarTwoInit
        {
            get { return car_two_init; }
        }

        public Image CarOneInit
        {
            get { return car_one_init; }
        }
        public Image CarTwoMove(ref Rectangle CarTwoFrom)
        {
            CarTwoFrom.Y -= 14;
            return car_two_init;
        }

        public Image CarOneMove(ref Rectangle CarOneFrom)
        {
            CarOneFrom.Y -= 14;
            return car_one_init;
        }

        public Image TreesMoveAnimation(PaintEventArgs e, ref Rectangle TreesForm)
        {
            TreesForm.Y -= 14;
            int what_pic = 1;
            Random rand = new Random();
            what_pic = rand.Next(3);
            if (what_pic == 1)
                return tree1;
            if (what_pic == 2)
                return tree2;
            return tree3;
        }

        public void TreesAnimation(PaintEventArgs e, Rectangle TreesForm)
        {
            int what_pic = 1;
            Random rand = new Random();
            what_pic = rand.Next(2);
            if (what_pic == 1)
                e.Graphics.DrawImage(tree_init, TreesForm);
            if (what_pic == 0)
                e.Graphics.DrawImage(tree_next, TreesForm);
        }

        public Image TreeInit
        {
            get { return tree_init; }
        }

        public Image TreeNext
        {
            get { return tree_next; }
        }

        public Image NicknameLabel_BG_Init
        {
            get { return new_nicknameLabel_bg_init; }
        }

        public Image NicknameLabel_BG_Next
        {
            get { return new_nicknameLabel_bg_next; }
        }

        public Image HighScoreInit
        {
            get { return highscore_init; }
        }

        public Image HighScoreNext
        {
            get { return highscore_next; }
        }

        public void Background_GradientF_Move(ref Rectangle BackgroundGradientForm)
        {
            BackgroundGradientForm.Y += 2;
        }

        public void Background_GradientB_Move(ref Rectangle BackgroundGradientForm)
        {
            BackgroundGradientForm.Y += 1;
        }

        public void Buildings_Front_Move(ref Rectangle BuildingsFrontForm)
        {
            BuildingsFrontForm.Y -= 3;
        }

        public void Buildings_Mid_Move(ref Rectangle BuildingsMidForm)
        {
            BuildingsMidForm.Y -= 2;
        }

        public Image Background_Gradient_B
        {
            get { return background_gradient_fst; }
        }

        public Image Background_Gradient_F
        {
            get { return background_gradient_sec; }
        }

        public Image Buildings_Front
        {
            get { return buildings_front; }
        }

        public Image Buildings_Mid
        {
            get { return buildings_mid; }
        }

        public Image Background
        {
            get { return background; }
        }

        public void MakeFrontCloudsMoreTransparent()
        {
            transparent_clouds = Image.FromFile("..\\..\\images\\transparent_clouds1.png");
        }

        public void MakeFrontCloudsEvenMoreTransparent()
        {
            transparent_clouds = Image.FromFile("..\\..\\images\\transparent_clouds2.png");
        }

        public void MakeFrontCloudsAlmostMaximumTransparent()
        {
            transparent_clouds = Image.FromFile("..\\..\\images\\transparent_clouds3.png");
        }

        public void MakeFrontCloudsMaximumTransparent()
        {
            transparent_clouds = Image.FromFile("..\\..\\images\\transparent_clouds4.png");
        }

        public Image Buildings_Back
        {
            get { return buildings_back; }
        }

        public void Buildings_Back_Move(ref Rectangle BuildingsBackForm)
        {
            BuildingsBackForm.Y +=1;
        }

        public Image BuildingEnterMove(ref Rectangle BuildingEnterForm)
        {
            BuildingEnterForm.Y -= 14;
            return building_enter;
        }

        public Image BuildingEnter
        {
            get { return building_enter; }
        }

        public Image PressedButtonOK
        {
            get { return button_ok; }
        }

        public Image TotalPointsBlueFrame
        {
            get { return totalscore_blue; }
        }

        public Image TotalPointsGoldFrame
        {
            get { return totalscore_gold; }
        }

        public Image GetMenuFont
        {
            get { return menufont; }
        }

        public Image Get100Points
        {
            get { return points100; }
        }

        public Image Get100PointsHalfTransparent
        {
            get { return points100ht; }
        }

        public Image Get100PointsTransparent
        {
            get { return points100t; }
        }

        public Image Get50Points
        {
            get { return points50; }
        }

        public Image Get50PointsHalfTransparent
        {
            get { return points50ht; }
        }

        public Image Get50PointsTransparent
        {
            get { return points50t; }
        }
        
        public Image Get20Points
        {
            get { return points20; }
        }

        public Image Get20PointsHalfTransparent
        {
            get { return points20ht; }
        }

        public Image Get20PointsTransparent
        {
            get { return points20t; }
        }
        public Image PauseMenu_Regular(int index)
        {
            return pausemenu_reg[index];
        }

        public Image PauseMenu_Focus(int index)
        {
            return pausemenu_focus[index];
        }

        public static void RotateCleanerPicture()
        {
            for (int i = 0; i < cleaner_size; i++)
            {
                cleaner[i].RotateFlip(RotateFlipType.Rotate180FlipX);
                cleaner[i].RotateFlip(RotateFlipType.Rotate180FlipY);
            }
        }

        public static void RotateCharacterPictures()
        {
            for (int i = 0; i < man_fall_size; i++)
                man_fall[i].RotateFlip(RotateFlipType.Rotate180FlipY);
            for (int i = 0; i < man_stand_size; i++)
                man_stand[i].RotateFlip(RotateFlipType.Rotate180FlipY);
        }

        public Image Clouds_When_Stand(ref Rectangle CloudsBack)
        {
            CloudsBack.X -= 1;
            return sky_clouds;
        }
        public Image Clouds_When_Fall(ref Rectangle CloudsBack)
        {
            CloudsBack.X -= 1;
            CloudsBack.Y -= 1;            
            return sky_clouds;
        }

        public Image Clouds_Front
        {
            get { return transparent_clouds; }
        }

        public Image Clouds_Back
        {
            get { return sky_clouds; }
        }
        public Image Transparent_Clouds_When_Stand(ref Rectangle CloudsFont)
        {
            CloudsFont.X -= 10;
            return transparent_clouds;
        }

        public Image Transparent_Clouds_When_Fall(ref Rectangle CloudsFont)
        {
            CloudsFont.X -= 10;
            CloudsFont.Y -= 10;
            return transparent_clouds;
        }

        public Image DrawBuilding
        {
            get { return building_init; }
        }

        public Image DrawBuilding_Fall(ref Rectangle BuildingForm)
        {
            BuildingForm.Y -= 14;
            return building_fall;
        }

        public void Smoker_Move (ref Rectangle SmokerForm)
        {
            SmokerForm.Y -= 14;
        }

        public void Cleaner_Move(ref Rectangle CleanerForm)
        {
            CleanerForm.Y -= 14;
        }

        public Image SmokerPic_AnimationForward(ref int index)
        {
            switch(index)
            {
                case 0:
                    {
                        index = 1;
                        break;
                    }
                case 1:
                    {
                        index = 2;
                        break;
                    }
                case 2:
                    {
                        index = 3;
                        break;
                    }
                case 3:
                    {
                        index = 4;
                        return smoker[3];
                    }
                case 4:
                    {
                        index = 5;
                        return smoker[3];
                    }
                case 5:
                    {
                        index = 6;
                        return smoker[3];
                    }
                case 6:
                    {
                        smoker_way = 'b';
                        index = 7;
                        return smoker[3];
                    }
                default:
                    {
                        index = 0;
                        break;
                    }
            }
            return smoker[index];
        }

        public Image SmokerPic_AnimationBackward(int index)
        {
            if (index == -1)
            {
                smoker_way = 'f';
                return smoker[0];
            }
            if (index > 3)
                return smoker[3];
            return smoker[index];
        }

        public Image JumpPic(ref int index, ref Rectangle CharacterPlace)
        {
            switch (index)
            {
                case 0:
                    {
                        CharacterPlace.X += 23;
                        CharacterPlace.Y += 5;
                        index = 1;
                        break;
                    }
                case 1:
                    {
                        CharacterPlace.X += 4;
                        CharacterPlace.Y -= 5;
                        index = 2;
                        break;
                    }
                case 2:
                    {
                        CharacterPlace.X += 14;
                        CharacterPlace.Y -= 9;
                        index = 3;
                        break;
                    }
                case 3:
                    {
                        CharacterPlace.X += 45;
                        CharacterPlace.Y += 30;
                        index = 4;
                        break;
                    }
                default:
                    {
                        CharacterPlace.X -= 2;
                        CharacterPlace.Y += 1;
                        index = 0;
                        break;
                    }
            }
            return man_jump[index];
        }

        public Image DrawMan_Fall(ref int index)
        {
            switch (index)
            {
                case 0:
                    {
                        index = 1;
                        return man_fall[index - 1];
                    }
                case 1:
                    {
                        index = 2;
                        return man_fall[index - 1];
                    }
                case 2:
                    {
                        index = 3;
                        return man_fall[index - 1];
                    }
                case 3:
                    {
                        index = 0;
                        return man_fall[3];
                    }
                default:
                    {
                        index = 0; // NEVER GONNA REACH YOU UP! NEVER GONNA CRASH YOU DOWN!!
                        return empty;
                    }
            }
        }

        public Image PegionPic(ref int index)
        {
            switch (index)
            {
                case 0:
                    {
                        index = 1;
                        break;
                    }
                case 1:
                    {
                        index = 2;
                        break;
                    }
                case 2:
                    {
                        index = 3;
                        break;
                    }
                default:
                    {
                        index = 0;
                        break;
                    }
            }
            return pegion_fly[index];
        }

        public Image DrawMan_Stand(ref int index)
        {
            switch (index)
            {
                case 0:
                    {
                        index = 1;
                        break;
                    }
                case 1:
                    {
                        index = 2;
                        break;
                    }
                case 2:
                    {
                        index = 3;
                        break;
                    }
                case 3:
                    {
                        index = 0;
                        break;
                    }
                default:
                    {
                        index = 0;
                        break;
                    }
            }
            return man_stand[index];
        }
    }
}
