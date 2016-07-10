using Officeman_1._1;
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
    class Sources
    {
        Image building_init, building_fall;
        Image sky_clouds, transparent_clouds;
        static int man_stand_size = 4;
        static int man_fall_size = 3;
        static int pegion_fly_size = 4;
        static int man_jump_size = 6;
        static Image[] man_stand = new Image[man_stand_size];
        Image[] man_jump = new Image[man_jump_size];
        static Image[] man_fall = new Image[man_fall_size];
        Image[] pegion_fly = new Image[pegion_fly_size];

        public Sources()
        {
            building_init = Image.FromFile("..\\..\\images\\building_prev2.png");
            building_fall = Image.FromFile("..\\..\\images\\building_flight1.png");
            sky_clouds = Image.FromFile("..\\..\\images\\sky_clouds.png");
            transparent_clouds = Image.FromFile("..\\..\\images\\transparent_clouds.png");
            man_stand[0] = Image.FromFile("..\\..\\images\\stand1.png");
            man_stand[1] = Image.FromFile("..\\..\\images\\stand2.png");
            man_stand[2] = Image.FromFile("..\\..\\images\\stand3.png");
            man_stand[3] = Image.FromFile("..\\..\\images\\stand4.png");
            man_fall[0] = Image.FromFile("..\\..\\images\\fall1.png");
            man_fall[1] = Image.FromFile("..\\..\\images\\fall2.png");
            man_fall[2] = Image.FromFile("..\\..\\images\\fall3.png");
            man_jump[0] = Image.FromFile("..\\..\\images\\jump1.png");
            man_jump[1] = Image.FromFile("..\\..\\images\\jump2.png");
            man_jump[2] = Image.FromFile("..\\..\\images\\jump3.png");
            man_jump[3] = Image.FromFile("..\\..\\images\\jump4.png");
            man_jump[4] = Image.FromFile("..\\..\\images\\jump5.png");
            pegion_fly[0] = Image.FromFile("..\\..\\images\\pegion1.png");
            pegion_fly[1] = Image.FromFile("..\\..\\images\\pegion2.png");
            pegion_fly[2] = Image.FromFile("..\\..\\images\\pegion3.png");
            pegion_fly[3] = Image.FromFile("..\\..\\images\\pegion4.png");
        }

        public static void RotateCharacterPictures()
        {
            for (int i = 0; i < Sources.ManFallSizeProp; i++)
                man_fall[i].RotateFlip(RotateFlipType.Rotate180FlipY);
            for (int i = 0; i < Sources.ManStandSizeProp; i++)
                man_stand[i].RotateFlip(RotateFlipType.Rotate180FlipY);
        }

        public static int ManStandSizeProp
        {
            get { return man_stand_size; }
        }

        public static int ManFallSizeProp
        {
            get { return man_fall_size; }
        }

        public Image Clouds_When_Stand(ref int sky_fontX)
        {
            sky_fontX -= 3;
            return sky_clouds;
        }
        public Image Clouds_When_Fall(ref int skyX, ref int skyY)
        {
            skyX -= 3;
            skyY -= 3;
            return sky_clouds;
        }
        public Image Transparent_Clouds_When_Stand(ref int sky_trans_fontX)
        {
            sky_trans_fontX -= 10;
            return transparent_clouds;
        }

        public Image Transparent_Clouds_When_Fall(ref int sky_trans_fontX, ref int sky_trans_fontY)
        {
            sky_trans_fontX -= 10;
            sky_trans_fontY -= 10;
            return transparent_clouds;
        }

        public Image DrawBuilding()
        {
            return building_init;
        }

        public Image DrawBuilding_Fall(ref int buildingY)
        {
            buildingY -= 50;
            return building_fall;
        }

        public Image JumpPic(ref int index, out int manX, out int manY, Mechanics mech)
        {
            switch (index)
            {
                case 0:
                    {
                        manX = 124;
                        manY = 3;
                        index = 1;
                        break;
                    }
                case 1:
                    {
                        manX = 124;
                        manY = 3;
                        index = 2;
                        break;
                    }
                case 2:
                    {
                        manX = 124;
                        manY = 3;
                        index = 3;
                        break;
                    }
                case 3:
                    {
                        manX = 145;
                        manY = -3;
                        index = 4;
                        break;
                    }
                case 4:
                    {
                        manX = 160;
                        manY = 40;
                        index = 0;
                        mech[Mechanics.character.jumping] = false;
                        mech[Mechanics.character.falling] = true;
                        break;
                    }
                default:
                    {
                        manX = 124;
                        manY = 3;
                        index = 0;
                        break;
                    }
            }
            return man_jump[index];
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
            return pegion_fly[index];
        }

        public Image DrawMan_Fall(ref int index)
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
                        index = 0;
                        break;
                    }
                default:
                    {
                        index = 0;
                        break;
                    }
            }
            return man_fall[index];
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
