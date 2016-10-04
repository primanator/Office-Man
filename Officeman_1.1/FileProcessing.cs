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
    /// <summary>
    /// This class presents processes of saving ingame leaders names and records. 
    /// </summary>

    static class FileProcessing
    {
        public static void FindYourPlaceInLeadertable(int place, int new_record, ref Label fstNicknameLabel, ref Label fstRecordLabel, ref Label secNicknameLabel, ref Label secRecordLabel, ref Label thrdNicknameLabel, ref Label thrdRecordLabel)
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
            br.Close();
            br.Dispose();
            fs.Close();
            fs.Dispose();

            int counter = 0;
            foreach (DictionaryEntry kvp in leaders)
            {
                switch (counter)
                {
                    case 0:
                        {
                            if (place == 1)
                            {
                                fstNicknameLabel.ResetText();
                                fstRecordLabel.Text = new_record.ToString();
                            }
                            else
                            {
                                fstNicknameLabel.Text = kvp.Key.ToString();
                                fstRecordLabel.Text = kvp.Value.ToString();
                            }
                            break;
                        }
                    case 1:
                        {
                            if (place == 2)
                            {
                                secNicknameLabel.ResetText();
                                secRecordLabel.Text = new_record.ToString();
                            }
                            else
                            {
                                secNicknameLabel.Text = kvp.Key.ToString();
                                secRecordLabel.Text = kvp.Value.ToString();
                            }
                            break;
                        }
                    case 2:
                        {
                            if (place == 3)
                            {
                                thrdNicknameLabel.ResetText();
                                thrdRecordLabel.Text = new_record.ToString();
                            }
                            else
                            {
                                thrdNicknameLabel.Text = kvp.Key.ToString();
                                thrdRecordLabel.Text = kvp.Value.ToString();
                            }
                            break;
                        }
                }
                counter++;
            }
        }

        public static void CreateHighscoreTable()
        {
            FileStream fs = new FileStream ("..\\..\\highscore.txt", FileMode.Create, FileAccess.Write, FileShare.None);
            BinaryWriter bw = new BinaryWriter(fs);
            Hashtable leaders = new Hashtable();
            leaders.Add("eee", 1200);
            leaders.Add("www", 900);
            leaders.Add("qqq", 600);
            foreach (DictionaryEntry kvp in leaders)
            {
                bw.Write(kvp.Key.ToString());
                bw.Write((int)kvp.Value);
            }
            bw.Close();
            bw.Dispose();
            fs.Close();
            fs.Dispose();
        }

        public static void AddRecordToHighrecordTable(string key, int value)
        {
            FileStream fs = new FileStream("..\\..\\highscore.txt", FileMode.Append, FileAccess.Write, FileShare.None);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(key);
            bw.Write(value);

            bw.Close();
            bw.Dispose();
            fs.Close();
            fs.Dispose();
        }


        public static void CreateHighscoreTable(string nick1, int res1, string nick2, int res2, string nick3, int res3)
        {
            FileStream fs = new FileStream("..\\..\\highscore.txt", FileMode.Create, FileAccess.Write, FileShare.None);
            BinaryWriter bw = new BinaryWriter(fs);
            Hashtable leaders = new Hashtable();
            leaders.Add(nick1, res1);
            leaders.Add(nick2, res2);
            leaders.Add(nick3, res3);
            foreach (DictionaryEntry kvp in leaders)
            {
                bw.Write(kvp.Key.ToString());
                bw.Write((int)kvp.Value);
            }
            bw.Close();
            bw.Dispose();
            fs.Close();
            fs.Dispose();
        }

        public static void ReadSingleLeader(ref Label Nick, ref Label Score, BinaryReader br)
        {
            Nick.Text = br.ReadString();
            Score.Text = (br.ReadInt32()).ToString();
        }

        public static void ReadWholeLeadertable(ref Label fstNicknameLabel, ref Label fstRecordLabel, ref Label secNicknameLabel, ref Label secRecordLabel, ref Label thrdNicknameLabel, ref Label thrdRecordLabel)
        {
            fstNicknameLabel.ResetText();
            secNicknameLabel.ResetText();
            thrdNicknameLabel.ResetText();
            fstRecordLabel.ResetText();
            secRecordLabel.ResetText();
            thrdRecordLabel.ResetText();
            
            FileStream fs = new FileStream("..\\..\\highscore.txt", FileMode.Open, FileAccess.Read, FileShare.None);
            BinaryReader br = new BinaryReader(fs);

            ReadSingleLeader(ref fstNicknameLabel, ref fstRecordLabel, br);
            ReadSingleLeader(ref secNicknameLabel, ref secRecordLabel, br);
            ReadSingleLeader(ref thrdNicknameLabel, ref thrdRecordLabel, br);

            br.Close();
            br.Dispose();
            fs.Close();
            fs.Dispose();
        }

        public static bool CheckHighscore(int newscore)
        {
            FileStream fs = new FileStream("..\\..\\highscore.txt", FileMode.Open, FileAccess.Read, FileShare.None);
            BinaryReader br = new BinaryReader(fs);
            for(int i = 0; i < 3; i++)
            {
                string nickname = br.ReadString();
                int highscore = br.ReadInt32();
                if (highscore < newscore)
                {
                    br.Close();
                    br.Dispose();
                    fs.Close();
                    fs.Dispose();
                    return true;
                }
            }
            br.Close();
            br.Dispose();
            fs.Close();
            fs.Dispose();
            return false;
        }

        public static int GetPositionInLeaderBoard(int newscore)
        {
            int place = 0;
            FileStream fs = new FileStream("..\\..\\highscore.txt", FileMode.Open, FileAccess.Read, FileShare.None);
            BinaryReader br = new BinaryReader(fs);
            for (int i = 1; i <= 3; i++)
            {
                string nickname = br.ReadString();
                int highscore = br.ReadInt32();
                if (newscore > highscore)
                {
                    br.Dispose();
                    place = i;
                    return place;
                }
            }
            br.Close();
            br.Dispose();
            fs.Close();
            fs.Dispose();
            return place;
        }


        public static void RewriteHighscore(int place, int newscore, string nickname)
        {
            FileStream fs = new FileStream("..\\..\\highscore.txt", FileMode.Open, FileAccess.Read, FileShare.None);
            BinaryReader br = new BinaryReader(fs);
            Hashtable leaders = new Hashtable();
            for (int i = 0; i < 3; i++)
            {
                string nick = br.ReadString();
                int highscore = br.ReadInt32();
                leaders.Add(nick, highscore);
            }
            br.Close();
            br.Dispose();
            fs.Close();
            fs.Dispose();


            File.Delete("..\\..\\highscore.txt");
            int count = 1;
            foreach (DictionaryEntry kvp in leaders)
            {
                if (count != place)
                    AddRecordToHighrecordTable(kvp.Key.ToString(), (int)kvp.Value);
                else
                    AddRecordToHighrecordTable(nickname, newscore);
                count++;
            }
        }
    }
}