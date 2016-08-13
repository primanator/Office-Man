using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Officeman_1._1
{
    static class Sounds
    {
        private static System.Media.SoundPlayer Audio;

        static public void Audio_TurnOff()
        {
            Audio.Stop();
        }
        static public void Audio_TurnOn()
        {
            Audio.Play();
        }

        static public void Audio_Init()
        {
            Audio = new System.Media.SoundPlayer("..\\..\\sounds\\main.wav");
            Audio.Load(); Audio.PlayLooping();
        }
    }
}
