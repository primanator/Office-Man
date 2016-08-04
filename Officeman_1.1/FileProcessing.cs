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

namespace Officeman_1._1
{
    static class FileProcessing
    {
        public static int ReadHighscore()
        {
            FileStream fs = new FileStream("..\\..\\highscore.txt", FileMode.Open, FileAccess.Read, FileShare.None);
            StreamReader sr = new StreamReader(fs);
            int highscore = Int32.Parse(sr.ReadLine());
            sr.Dispose();
            return highscore;
        }

        public static void RewriteHighscore(int newscore)
        {
            FileStream fs1 = new FileStream("..\\..\\highscore.txt", FileMode.Create, FileAccess.Write, FileShare.None);
            StreamWriter sw = new StreamWriter(fs1);
            sw.WriteLine(newscore.ToString());
            sw.Dispose();
        }
    }
}
