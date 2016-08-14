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
using System.Drawing.Text;

namespace Officeman_1._1
{
    static class FormElement
    {
        public static void MakeLeaderNicknameVisible_Leaderboard(ref Label NicknameLabel)
        {
            NicknameLabel.BackColor = Color.FromArgb(241, 220, 254);
            NicknameLabel.ForeColor = Color.FromArgb(255, 255, 255);
            NicknameLabel.Visible = true;
        }

        public static void MakeLeaderScoreVisible_Leaderboard(ref Label ScoreLabel)
        {
            ScoreLabel.BackColor = Color.FromArgb(241, 220, 254);
            ScoreLabel.ForeColor = Color.FromArgb(120, 25, 179);
            ScoreLabel.Visible = true;
        }

        public static void MakeLeaderScoreVisible(ref Label LeaderScoreLabel)
        {
            LeaderScoreLabel.BackColor = Color.FromArgb(241, 220, 254);
            LeaderScoreLabel.ForeColor = Color.FromArgb(120, 25, 179);
            LeaderScoreLabel.Visible = true;
        }
        public static void MakeLeaderNicknameVisible(ref Label LeaderNickLabel)
        {
            LeaderNickLabel.BackColor = Color.FromArgb(241, 220, 254);
            LeaderNickLabel.ForeColor = Color.FromArgb(255, 255, 255);
            LeaderNickLabel.Visible = true;
        }

        public static void Hunted_PigeonsLabel_GetResult(ref Label PigeonAmountLabel, int Hunted_PigeonCounter)
        {
            PigeonAmountLabel.BackColor = Color.FromArgb(255, 231, 188);
            PigeonAmountLabel.ForeColor = Color.FromArgb(231, 163, 39);
            PigeonAmountLabel.Text = Hunted_PigeonCounter.ToString();
        }

        public static void Hunted_CleanerLabel_GetResult(ref Label CleanerAmountLabel, int Hunted_CleanerCounter)
        {
            CleanerAmountLabel.BackColor = Color.FromArgb(255, 231, 188);
            CleanerAmountLabel.ForeColor = Color.FromArgb(231, 163, 39);
            CleanerAmountLabel.Text = Hunted_CleanerCounter.ToString();
        }

        public static void Hunted_SmokerLabel_GetResult(ref Label SmokerAmountLabel, int Hunted_SmokerCounter)
        {
            SmokerAmountLabel.BackColor = Color.FromArgb(255, 231, 188);
            SmokerAmountLabel.ForeColor = Color.FromArgb(231, 163, 39);
            SmokerAmountLabel.Text = Hunted_SmokerCounter.ToString();
        }

        public static void TimeAmountLabel_GetResult(ref Label TimeAmountLabel, double globalGameTime)
        {
            TimeAmountLabel.BackColor = Color.FromArgb(255, 231, 188);
            TimeAmountLabel.ForeColor = Color.FromArgb(231, 163, 39);
            TimeAmountLabel.Text = ((int)globalGameTime).ToString();  // change format of output!!
        }
        public static void TotalScore(ref Label HighscorePointsLabel, Label PointsLabel)
        {
            HighscorePointsLabel.BackColor = Color.FromArgb(255, 231, 188);
            HighscorePointsLabel.ForeColor = Color.FromArgb(231, 163, 39);
            HighscorePointsLabel.Text = PointsLabel.Text;
        }

        public static void DrawPoints(Label PointLabel)
        {
            PrivateFontCollection newFont = new PrivateFontCollection();
            newFont.AddFontFile("..\\..\\font\\Chava-Regular.ttf");
            FontFamily chava = new FontFamily("Chava", newFont);
            PointLabel.Font = new System.Drawing.Font(chava, 10, System.Drawing.FontStyle.Regular);

            int value = Int32.Parse(PointLabel.Text);
            value++;
            PointLabel.Text = value.ToString();
        }
        public static void Add20Points(Label PointLabel)
        {
            int value = Int32.Parse(PointLabel.Text);
            value += 20;
            PointLabel.Text = value.ToString();
        }

        public static void Add50Points(Label PointLabel)
        {
            int value = Int32.Parse(PointLabel.Text);
            value += 50;
            PointLabel.Text = value.ToString();
        }

        public static void Add100Points(Label PointLabel)
        {
            int value = Int32.Parse(PointLabel.Text);
            value += 100;
            PointLabel.Text = value.ToString();
        }

        public static void ShowPauseMenuItems(Label PauseMenu_ContinueLabel, Label PauseMenu_FAQLabel, Label PauseMenu_LeaderboardLabel, Label PauseMenu_ExitLabel)
        {
            PauseMenu_ContinueLabel.Visible = true;
            PauseMenu_FAQLabel.Visible = true;
            PauseMenu_LeaderboardLabel.Visible = true;
            PauseMenu_ExitLabel.Visible = true;
        }

        public static void HidePauseMenuItems(Label PauseMenu_ContinueLabel, Label PauseMenu_FAQLabel, Label PauseMenu_LeaderboardLabel, Label PauseMenu_ExitLabel)
        {
            PauseMenu_ContinueLabel.Visible = false;
            PauseMenu_FAQLabel.Visible = false;
            PauseMenu_LeaderboardLabel.Visible = false;
            PauseMenu_ExitLabel.Visible = false;
        }

        public static void ShowTotalScore(Label TotalScoreLabel)
        {
            TotalScoreLabel.Visible = true;
        }

        public static void HideTotalScore(Label TotalScoreLabel)
        {
            TotalScoreLabel.Visible = false;
        }

        public static void TotalScore_ChangeImage(Label TotalScoreLabel, Sources e)
        {
            int what_pic = 1;
            Random pegion_probability = new Random();
            what_pic = pegion_probability.Next(2);
            if (what_pic == 1)
                TotalScoreLabel.Image = e.TotalPointsBlueFrame();
            if (what_pic == 0)
                TotalScoreLabel.Image = e.TotalPointsGoldFrame();
        }

        public static void InitTotalScore(Label TotalScoreLabel, Label PointsLabel)
        {
            TotalScoreLabel.Text = PointsLabel.Text;
        }

        public static int GetTotalScore(Label TotalScoreLabel)
        {
            int result = Int32.Parse(TotalScoreLabel.Text);
            return result;
        }

        public static void ShowButtonOK(Label OK)
        {
            OK.Visible = true;
        }

        public static void HideButtonOK(Label OK)
        {
            OK.Visible = false;
        }

        public static void ShowHighScoreLabels(Label HighScoreLabel1, Label HighScoreLabel2, Label NewNicknameLabel, Sources source)
        {
            int what_pic = 1;
            Random pegion_probability = new Random();
            what_pic = pegion_probability.Next(2);
            if (what_pic == 1)
            {
                NewNicknameLabel.Image = source.NicknameLabel_BG_Init();
                HighScoreLabel2.Visible = false;
                HighScoreLabel1.Visible = true;
            }
            if (what_pic == 0)
            {
                NewNicknameLabel.Image = source.NicknameLabel_BG_Next();
                HighScoreLabel1.Visible = false;
                HighScoreLabel2.Visible = true;
            }
        }

        public static void ShowNewNicknameLabel(Label NewNicknameLabel)
        {
            NewNicknameLabel.Visible = true;
        }

        public static void ShowNicknameLabel(Label NicknameLabel)
        {
            NicknameLabel.Visible = true;
        }

        public static string GetNickname(Label NicknameLabel)
        {
            return NicknameLabel.Text.ToString();
        }

        public static void ChangeFontToChava_Statistics(ref Label Lab)
        {
            PrivateFontCollection newFont = new PrivateFontCollection();
            newFont.AddFontFile("..\\..\\font\\Chava-Regular.ttf");
            FontFamily chava = new FontFamily("Chava", newFont);
            Lab.Font = new System.Drawing.Font(chava, 18, System.Drawing.FontStyle.Regular);
        }
    }
}