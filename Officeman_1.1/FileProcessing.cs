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
using System.Collections;

namespace Officeman_1._1
{
    static class FileProcessing
    {

        public static void CreateHighscoreTable()
        {
            FileStream fs = new FileStream ("..\\..\\highscore.txt", FileMode.Create, FileAccess.Write, FileShare.None);
            BinaryWriter bw = new BinaryWriter(fs);
            Hashtable leaders = new Hashtable();
            leaders.Add("qqq", 600);
            leaders.Add("www", 900);
            leaders.Add("eee", 1200);
            foreach (DictionaryEntry kvp in leaders)
            {
                bw.Write(kvp.Key.ToString());
                bw.Write((int)kvp.Value);
            }
            bw.Dispose();
        }

        public static bool CheckHighscore(int newscore)
        {
            FileStream fs = new FileStream("..\\..\\highscore.txt", FileMode.Open, FileAccess.Read, FileShare.None);
            BinaryReader br = new BinaryReader(fs);
            Hashtable leaders = new Hashtable();
            for(int i = 0; i < 3; i++)
            {
                string nickname = br.ReadString();
                int highscore = br.ReadInt32();
                leaders.Add(nickname, highscore);
            }
            br.Dispose();
            foreach (DictionaryEntry kvp in leaders)
                if ((int)kvp.Value < newscore)
                    return true;
            return false;
        }

        public static int GetPositionInLeaderBoard(int newscore)
        {
            FileStream fs = new FileStream("..\\..\\highscore.txt", FileMode.Open, FileAccess.Read, FileShare.None);
            BinaryReader br = new BinaryReader(fs);
            for (int i = 3; i >= 1; i--)
            {
                string nickname = br.ReadString();
                int highscore = br.ReadInt32();
                if (newscore > highscore)
                {
                    br.Dispose();
                    return i;
                }
            }
            br.Dispose();
            return 0;
        }


        public static void RewriteHighscore(int place, int newscore, Label NicknameLabel)
        {
            FileStream fs = new FileStream("..\\..\\highscore.txt", FileMode.Open, FileAccess.Read, FileShare.None);
            BinaryReader br = new BinaryReader(fs);
            Hashtable leaders = new Hashtable();
            for (int i = 0; i < 3; i++)
            {
                string nickname = br.ReadString();
                int highscore = br.ReadInt32();
                leaders.Add(nickname, highscore);
            }
            br.Dispose();

            FileStream fs1 = new FileStream("..\\..\\highscore.txt", FileMode.Create, FileAccess.Write, FileShare.None);
            BinaryWriter bw = new BinaryWriter(fs1);
            int count = 3;
            foreach (DictionaryEntry kvp in leaders)
            {
                if (count == place)
                {
                    bw.Write(FormElement.GetNickname(NicknameLabel)); /// NEW PLAYERS NICKNAME!!!!!!!!!!!!!
                    bw.Write(newscore); /// NEW PLAYERS HIGHSCORE!!!!!!!!!!!!
                    count--;
                    continue;
                }
                bw.Write(kvp.Key.ToString());
                bw.Write((int)kvp.Value);
                count--;
            }
            bw.Dispose();
        }

        public static void DeleteHighscoreFile()
        {
            File.Delete("..\\..\\highscore.txt"); // deletes highscore file
        }
    }
}