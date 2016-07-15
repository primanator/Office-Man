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

namespace Officeman_1._1
{
    static class FormElement
    {
        public static void DrawPoints(Label PointLabel)
        {
            int value = Int32.Parse(PointLabel.Text);
            value++;
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
    }
}
