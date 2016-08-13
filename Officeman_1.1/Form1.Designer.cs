using System.Drawing;
using System.Drawing.Text;
namespace OfficeMan_1._1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.PointsLabel = new System.Windows.Forms.Label();
            this.PauseMenu_ContinueLabel = new System.Windows.Forms.Label();
            this.PauseMenu_FAQLabel = new System.Windows.Forms.Label();
            this.PauseMenu_LeaderboardLabel = new System.Windows.Forms.Label();
            this.PauseMenu_ExitLabel = new System.Windows.Forms.Label();
            this.TotalScoreLabel = new System.Windows.Forms.Label();
            this.OKLabel = new System.Windows.Forms.Label();
            this.HighScoreLabel1 = new System.Windows.Forms.Label();
            this.HighScoreLabel2 = new System.Windows.Forms.Label();
            this.NewNicknameLabel = new System.Windows.Forms.Label();
            this.NicknameLabel = new System.Windows.Forms.Label();
            this.PigeonAmountLabel = new System.Windows.Forms.Label();
            this.CleanerAmountLabel = new System.Windows.Forms.Label();
            this.SmokerAmountLabel = new System.Windows.Forms.Label();
            this.TimeAmountLabel = new System.Windows.Forms.Label();
            this.OKAAAYLabel = new System.Windows.Forms.Label();
            this.HighscorePointsLabel = new System.Windows.Forms.Label();
            this.Menu_StartLabel = new System.Windows.Forms.Label();
            this.Menu_ShopLabel = new System.Windows.Forms.Label();
            this.Menu_HighscoreLabel = new System.Windows.Forms.Label();
            this.Menu_TutorialLabel = new System.Windows.Forms.Label();
            this.Menu_ExitLabel = new System.Windows.Forms.Label();
            this.MOOORELabel = new System.Windows.Forms.Label();
            this.fstNicknameLabel = new System.Windows.Forms.Label();
            this.secNicknameLabel = new System.Windows.Forms.Label();
            this.thrdNicknameLabel = new System.Windows.Forms.Label();
            this.fstRecordLabel = new System.Windows.Forms.Label();
            this.secRecordLabel = new System.Windows.Forms.Label();
            this.thrdRecordLabel = new System.Windows.Forms.Label();
            this.WOOHOOLabel = new System.Windows.Forms.Label();
            this.EHLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // PointsLabel
            // 
            this.PointsLabel.AutoSize = true;
            this.PointsLabel.BackColor = System.Drawing.Color.Transparent;
            this.PointsLabel.Location = new System.Drawing.Point(352, 9);
            this.PointsLabel.MinimumSize = new System.Drawing.Size(50, 20);
            this.PointsLabel.Name = "PointsLabel";
            this.PointsLabel.Size = new System.Drawing.Size(50, 20);
            this.PointsLabel.TabIndex = 0;
            this.PointsLabel.Text = "0";
            this.PointsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.PointsLabel.Visible = false;
            // 
            // PauseMenu_ContinueLabel
            // 
            this.PauseMenu_ContinueLabel.AutoSize = true;
            this.PauseMenu_ContinueLabel.Image = ((System.Drawing.Image)(resources.GetObject("PauseMenu_ContinueLabel.Image")));
            this.PauseMenu_ContinueLabel.Location = new System.Drawing.Point(140, 100);
            this.PauseMenu_ContinueLabel.MinimumSize = new System.Drawing.Size(200, 70);
            this.PauseMenu_ContinueLabel.Name = "PauseMenu_ContinueLabel";
            this.PauseMenu_ContinueLabel.Size = new System.Drawing.Size(200, 70);
            this.PauseMenu_ContinueLabel.TabIndex = 1;
            this.PauseMenu_ContinueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.PauseMenu_ContinueLabel.Visible = false;
            this.PauseMenu_ContinueLabel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PauseMenu_ContinueLabel_MouseClick);
            this.PauseMenu_ContinueLabel.MouseLeave += new System.EventHandler(this.PauseMenu_ContinueLabel_MouseLeave);
            this.PauseMenu_ContinueLabel.MouseHover += new System.EventHandler(this.PauseMenu_ContinueLabel_MouseHover);
            // 
            // PauseMenu_FAQLabel
            // 
            this.PauseMenu_FAQLabel.AutoSize = true;
            this.PauseMenu_FAQLabel.Image = ((System.Drawing.Image)(resources.GetObject("PauseMenu_FAQLabel.Image")));
            this.PauseMenu_FAQLabel.Location = new System.Drawing.Point(140, 170);
            this.PauseMenu_FAQLabel.MinimumSize = new System.Drawing.Size(200, 70);
            this.PauseMenu_FAQLabel.Name = "PauseMenu_FAQLabel";
            this.PauseMenu_FAQLabel.Size = new System.Drawing.Size(200, 70);
            this.PauseMenu_FAQLabel.TabIndex = 2;
            this.PauseMenu_FAQLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.PauseMenu_FAQLabel.Visible = false;
            this.PauseMenu_FAQLabel.MouseLeave += new System.EventHandler(this.PauseMenu_FAQLabel_MouseLeave);
            this.PauseMenu_FAQLabel.MouseHover += new System.EventHandler(this.PauseMenu_FAQLabel_MouseHover);
            // 
            // PauseMenu_LeaderboardLabel
            // 
            this.PauseMenu_LeaderboardLabel.AutoSize = true;
            this.PauseMenu_LeaderboardLabel.Image = ((System.Drawing.Image)(resources.GetObject("PauseMenu_LeaderboardLabel.Image")));
            this.PauseMenu_LeaderboardLabel.Location = new System.Drawing.Point(140, 240);
            this.PauseMenu_LeaderboardLabel.MinimumSize = new System.Drawing.Size(200, 70);
            this.PauseMenu_LeaderboardLabel.Name = "PauseMenu_LeaderboardLabel";
            this.PauseMenu_LeaderboardLabel.Size = new System.Drawing.Size(200, 70);
            this.PauseMenu_LeaderboardLabel.TabIndex = 4;
            this.PauseMenu_LeaderboardLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.PauseMenu_LeaderboardLabel.Visible = false;
            this.PauseMenu_LeaderboardLabel.MouseLeave += new System.EventHandler(this.PauseMenu_LeaderboardLabel_MouseLeave);
            this.PauseMenu_LeaderboardLabel.MouseHover += new System.EventHandler(this.PauseMenu_LeaderboardLabel_MouseHover);
            // 
            // PauseMenu_ExitLabel
            // 
            this.PauseMenu_ExitLabel.AutoSize = true;
            this.PauseMenu_ExitLabel.Image = ((System.Drawing.Image)(resources.GetObject("PauseMenu_ExitLabel.Image")));
            this.PauseMenu_ExitLabel.Location = new System.Drawing.Point(140, 310);
            this.PauseMenu_ExitLabel.MinimumSize = new System.Drawing.Size(200, 70);
            this.PauseMenu_ExitLabel.Name = "PauseMenu_ExitLabel";
            this.PauseMenu_ExitLabel.Size = new System.Drawing.Size(200, 70);
            this.PauseMenu_ExitLabel.TabIndex = 5;
            this.PauseMenu_ExitLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.PauseMenu_ExitLabel.Visible = false;
            this.PauseMenu_ExitLabel.MouseLeave += new System.EventHandler(this.PauseMenu_ExitLabel_MouseLeave);
            this.PauseMenu_ExitLabel.MouseHover += new System.EventHandler(this.PauseMenu_ExitLabel_MouseHover);
            // 
            // TotalScoreLabel
            // 
            this.TotalScoreLabel.AutoSize = true;
            this.TotalScoreLabel.Image = ((System.Drawing.Image)(resources.GetObject("TotalScoreLabel.Image")));
            this.TotalScoreLabel.Location = new System.Drawing.Point(140, 170);
            this.TotalScoreLabel.MinimumSize = new System.Drawing.Size(200, 70);
            this.TotalScoreLabel.Name = "TotalScoreLabel";
            this.TotalScoreLabel.Size = new System.Drawing.Size(200, 70);
            this.TotalScoreLabel.TabIndex = 6;
            this.TotalScoreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.TotalScoreLabel.Visible = false;
            // 
            // OKLabel
            // 
            this.OKLabel.AutoSize = true;
            this.OKLabel.Image = ((System.Drawing.Image)(resources.GetObject("OKLabel.Image")));
            this.OKLabel.Location = new System.Drawing.Point(214, 215);
            this.OKLabel.MinimumSize = new System.Drawing.Size(50, 22);
            this.OKLabel.Name = "OKLabel";
            this.OKLabel.Size = new System.Drawing.Size(50, 22);
            this.OKLabel.TabIndex = 7;
            this.OKLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.OKLabel.Visible = false;
            this.OKLabel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ButtonOK_MouseClick);
            this.OKLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonOK_MouseDown);
            // 
            // HighScoreLabel1
            // 
            this.HighScoreLabel1.AutoSize = true;
            this.HighScoreLabel1.Image = ((System.Drawing.Image)(resources.GetObject("HighScoreLabel1.Image")));
            this.HighScoreLabel1.Location = new System.Drawing.Point(0, 0);
            this.HighScoreLabel1.MinimumSize = new System.Drawing.Size(500, 500);
            this.HighScoreLabel1.Name = "HighScoreLabel1";
            this.HighScoreLabel1.Size = new System.Drawing.Size(500, 500);
            this.HighScoreLabel1.TabIndex = 8;
            this.HighScoreLabel1.Visible = false;
            // 
            // HighScoreLabel2
            // 
            this.HighScoreLabel2.AutoSize = true;
            this.HighScoreLabel2.Image = ((System.Drawing.Image)(resources.GetObject("HighScoreLabel2.Image")));
            this.HighScoreLabel2.Location = new System.Drawing.Point(0, 0);
            this.HighScoreLabel2.MinimumSize = new System.Drawing.Size(500, 500);
            this.HighScoreLabel2.Name = "HighScoreLabel2";
            this.HighScoreLabel2.Size = new System.Drawing.Size(500, 500);
            this.HighScoreLabel2.TabIndex = 9;
            this.HighScoreLabel2.Visible = false;
            // 
            // NewNicknameLabel
            // 
            this.NewNicknameLabel.AutoSize = true;
            this.NewNicknameLabel.BackColor = System.Drawing.Color.White;
            this.NewNicknameLabel.Image = ((System.Drawing.Image)(resources.GetObject("NewNicknameLabel.Image")));
            this.NewNicknameLabel.Location = new System.Drawing.Point(153, 250);
            this.NewNicknameLabel.MinimumSize = new System.Drawing.Size(200, 100);
            this.NewNicknameLabel.Name = "NewNicknameLabel";
            this.NewNicknameLabel.Size = new System.Drawing.Size(200, 100);
            this.NewNicknameLabel.TabIndex = 10;
            this.NewNicknameLabel.Visible = false;
            // 
            // NicknameLabel
            // 
            this.NicknameLabel.AutoSize = true;
            this.NicknameLabel.Location = new System.Drawing.Point(153, 366);
            this.NicknameLabel.MinimumSize = new System.Drawing.Size(200, 50);
            this.NicknameLabel.Name = "NicknameLabel";
            this.NicknameLabel.Size = new System.Drawing.Size(200, 50);
            this.NicknameLabel.TabIndex = 11;
            this.NicknameLabel.Visible = false;
            // 
            // PigeonAmountLabel
            // 
            this.PigeonAmountLabel.AutoSize = true;
            this.PigeonAmountLabel.Location = new System.Drawing.Point(310, 134);
            this.PigeonAmountLabel.Name = "PigeonAmountLabel";
            this.PigeonAmountLabel.Size = new System.Drawing.Size(43, 13);
            this.PigeonAmountLabel.TabIndex = 12;
            this.PigeonAmountLabel.Text = "999999";
            this.PigeonAmountLabel.Visible = false;
            // 
            // CleanerAmountLabel
            // 
            this.CleanerAmountLabel.AutoSize = true;
            this.CleanerAmountLabel.Location = new System.Drawing.Point(310, 176);
            this.CleanerAmountLabel.Name = "CleanerAmountLabel";
            this.CleanerAmountLabel.Size = new System.Drawing.Size(43, 13);
            this.CleanerAmountLabel.TabIndex = 0;
            this.CleanerAmountLabel.Text = "999999";
            this.CleanerAmountLabel.Visible = false;
            // 
            // SmokerAmountLabel
            // 
            this.SmokerAmountLabel.AutoSize = true;
            this.SmokerAmountLabel.Location = new System.Drawing.Point(310, 219);
            this.SmokerAmountLabel.Name = "SmokerAmountLabel";
            this.SmokerAmountLabel.Size = new System.Drawing.Size(43, 13);
            this.SmokerAmountLabel.TabIndex = 13;
            this.SmokerAmountLabel.Text = "999999";
            this.SmokerAmountLabel.Visible = false;
            // 
            // TimeAmountLabel
            // 
            this.TimeAmountLabel.AutoSize = true;
            this.TimeAmountLabel.Location = new System.Drawing.Point(310, 261);
            this.TimeAmountLabel.Name = "TimeAmountLabel";
            this.TimeAmountLabel.Size = new System.Drawing.Size(43, 13);
            this.TimeAmountLabel.TabIndex = 14;
            this.TimeAmountLabel.Text = "999999";
            this.TimeAmountLabel.Visible = false;
            // 
            // OKAAAYLabel
            // 
            this.OKAAAYLabel.AutoSize = true;
            this.OKAAAYLabel.Image = ((System.Drawing.Image)(resources.GetObject("OKAAAYLabel.Image")));
            this.OKAAAYLabel.Location = new System.Drawing.Point(175, 373);
            this.OKAAAYLabel.MinimumSize = new System.Drawing.Size(149, 15);
            this.OKAAAYLabel.Name = "OKAAAYLabel";
            this.OKAAAYLabel.Size = new System.Drawing.Size(149, 15);
            this.OKAAAYLabel.TabIndex = 15;
            this.OKAAAYLabel.Visible = false;
            this.OKAAAYLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OKAAAYLabel_MouseDown);
            this.OKAAAYLabel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OKAAAYLabel_MouseUp);
            // 
            // HighscorePointsLabel
            // 
            this.HighscorePointsLabel.AutoSize = true;
            this.HighscorePointsLabel.Location = new System.Drawing.Point(310, 304);
            this.HighscorePointsLabel.Name = "HighscorePointsLabel";
            this.HighscorePointsLabel.Size = new System.Drawing.Size(43, 13);
            this.HighscorePointsLabel.TabIndex = 16;
            this.HighscorePointsLabel.Text = "999999";
            this.HighscorePointsLabel.Visible = false;
            // 
            // Menu_StartLabel
            // 
            this.Menu_StartLabel.AutoSize = true;
            this.Menu_StartLabel.Image = ((System.Drawing.Image)(resources.GetObject("Menu_StartLabel.Image")));
            this.Menu_StartLabel.Location = new System.Drawing.Point(191, 264);
            this.Menu_StartLabel.MinimumSize = new System.Drawing.Size(103, 22);
            this.Menu_StartLabel.Name = "Menu_StartLabel";
            this.Menu_StartLabel.Size = new System.Drawing.Size(103, 22);
            this.Menu_StartLabel.TabIndex = 17;
            this.Menu_StartLabel.Visible = false;
            this.Menu_StartLabel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Menu_StartLabel_MouseClick);
            this.Menu_StartLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Menu_StartLabel_MouseDown);
            this.Menu_StartLabel.MouseEnter += new System.EventHandler(this.Menu_StartLabel_MouseEnter);
            this.Menu_StartLabel.MouseLeave += new System.EventHandler(this.Menu_StartLabel_MouseLeave);
            // 
            // Menu_ShopLabel
            // 
            this.Menu_ShopLabel.AutoSize = true;
            this.Menu_ShopLabel.Image = ((System.Drawing.Image)(resources.GetObject("Menu_ShopLabel.Image")));
            this.Menu_ShopLabel.Location = new System.Drawing.Point(200, 304);
            this.Menu_ShopLabel.MinimumSize = new System.Drawing.Size(82, 22);
            this.Menu_ShopLabel.Name = "Menu_ShopLabel";
            this.Menu_ShopLabel.Size = new System.Drawing.Size(82, 22);
            this.Menu_ShopLabel.TabIndex = 18;
            this.Menu_ShopLabel.Visible = false;
            this.Menu_ShopLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Menu_ShopLabel_MouseDown);
            this.Menu_ShopLabel.MouseEnter += new System.EventHandler(this.Menu_ShopLabel_MouseEnter);
            this.Menu_ShopLabel.MouseLeave += new System.EventHandler(this.Menu_ShopLabel_MouseLeave);
            // 
            // Menu_HighscoreLabel
            // 
            this.Menu_HighscoreLabel.AutoSize = true;
            this.Menu_HighscoreLabel.Image = ((System.Drawing.Image)(resources.GetObject("Menu_HighscoreLabel.Image")));
            this.Menu_HighscoreLabel.Location = new System.Drawing.Point(154, 333);
            this.Menu_HighscoreLabel.MinimumSize = new System.Drawing.Size(175, 22);
            this.Menu_HighscoreLabel.Name = "Menu_HighscoreLabel";
            this.Menu_HighscoreLabel.Size = new System.Drawing.Size(175, 22);
            this.Menu_HighscoreLabel.TabIndex = 19;
            this.Menu_HighscoreLabel.Visible = false;
            this.Menu_HighscoreLabel.Click += new System.EventHandler(this.Menu_HighscoreLabel_Click);
            this.Menu_HighscoreLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Menu_HighscoreLabel_MouseDown);
            this.Menu_HighscoreLabel.MouseEnter += new System.EventHandler(this.Menu_HighscoreLabel_MouseEnter);
            this.Menu_HighscoreLabel.MouseLeave += new System.EventHandler(this.Menu_HighscoreLabel_MouseLeave);
            // 
            // Menu_TutorialLabel
            // 
            this.Menu_TutorialLabel.AutoSize = true;
            this.Menu_TutorialLabel.Image = ((System.Drawing.Image)(resources.GetObject("Menu_TutorialLabel.Image")));
            this.Menu_TutorialLabel.Location = new System.Drawing.Point(165, 362);
            this.Menu_TutorialLabel.MinimumSize = new System.Drawing.Size(153, 22);
            this.Menu_TutorialLabel.Name = "Menu_TutorialLabel";
            this.Menu_TutorialLabel.Size = new System.Drawing.Size(153, 22);
            this.Menu_TutorialLabel.TabIndex = 20;
            this.Menu_TutorialLabel.Visible = false;
            this.Menu_TutorialLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Menu_TutorialLabel_MouseDown);
            this.Menu_TutorialLabel.MouseEnter += new System.EventHandler(this.Menu_TutorialLabel_MouseEnter);
            this.Menu_TutorialLabel.MouseLeave += new System.EventHandler(this.Menu_TutorialLabel_MouseLeave);
            // 
            // Menu_ExitLabel
            // 
            this.Menu_ExitLabel.AutoSize = true;
            this.Menu_ExitLabel.Image = ((System.Drawing.Image)(resources.GetObject("Menu_ExitLabel.Image")));
            this.Menu_ExitLabel.Location = new System.Drawing.Point(208, 404);
            this.Menu_ExitLabel.MinimumSize = new System.Drawing.Size(68, 22);
            this.Menu_ExitLabel.Name = "Menu_ExitLabel";
            this.Menu_ExitLabel.Size = new System.Drawing.Size(68, 22);
            this.Menu_ExitLabel.TabIndex = 21;
            this.Menu_ExitLabel.Visible = false;
            this.Menu_ExitLabel.Click += new System.EventHandler(this.Menu_ExitLabel_Click);
            this.Menu_ExitLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Menu_ExitLabel_MouseDown);
            this.Menu_ExitLabel.MouseEnter += new System.EventHandler(this.Menu_ExitLabel_MouseEnter);
            this.Menu_ExitLabel.MouseLeave += new System.EventHandler(this.Menu_ExitLabel_MouseLeave);
            // 
            // MOOORELabel
            // 
            this.MOOORELabel.AutoSize = true;
            this.MOOORELabel.Image = ((System.Drawing.Image)(resources.GetObject("MOOORELabel.Image")));
            this.MOOORELabel.Location = new System.Drawing.Point(168, 300);
            this.MOOORELabel.MinimumSize = new System.Drawing.Size(149, 15);
            this.MOOORELabel.Name = "MOOORELabel";
            this.MOOORELabel.Size = new System.Drawing.Size(149, 15);
            this.MOOORELabel.TabIndex = 22;
            this.MOOORELabel.Visible = false;
            this.MOOORELabel.Click += new System.EventHandler(this.MOOORELabel_Click);
            this.MOOORELabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MOOORELabel_MouseDown);
            // 
            // fstNicknameLabel
            // 
            this.fstNicknameLabel.AutoSize = true;
            this.fstNicknameLabel.Location = new System.Drawing.Point(178, 163);
            this.fstNicknameLabel.Name = "fstNicknameLabel";
            this.fstNicknameLabel.Size = new System.Drawing.Size(0, 13);
            this.fstNicknameLabel.TabIndex = 23;
            this.fstNicknameLabel.Visible = false;
            // 
            // secNicknameLabel
            // 
            this.secNicknameLabel.AutoSize = true;
            this.secNicknameLabel.Location = new System.Drawing.Point(178, 204);
            this.secNicknameLabel.Name = "secNicknameLabel";
            this.secNicknameLabel.Size = new System.Drawing.Size(0, 13);
            this.secNicknameLabel.TabIndex = 24;
            this.secNicknameLabel.Visible = false;
            // 
            // thrdNicknameLabel
            // 
            this.thrdNicknameLabel.AutoSize = true;
            this.thrdNicknameLabel.Location = new System.Drawing.Point(178, 245);
            this.thrdNicknameLabel.Name = "thrdNicknameLabel";
            this.thrdNicknameLabel.Size = new System.Drawing.Size(0, 13);
            this.thrdNicknameLabel.TabIndex = 25;
            this.thrdNicknameLabel.Visible = false;
            // 
            // fstRecordLabel
            // 
            this.fstRecordLabel.AutoSize = true;
            this.fstRecordLabel.Location = new System.Drawing.Point(292, 163);
            this.fstRecordLabel.Name = "fstRecordLabel";
            this.fstRecordLabel.Size = new System.Drawing.Size(48, 13);
            this.fstRecordLabel.TabIndex = 26;
            this.fstRecordLabel.Text = "Record1";
            this.fstRecordLabel.Visible = false;
            // 
            // secRecordLabel
            // 
            this.secRecordLabel.AutoSize = true;
            this.secRecordLabel.Location = new System.Drawing.Point(292, 204);
            this.secRecordLabel.Name = "secRecordLabel";
            this.secRecordLabel.Size = new System.Drawing.Size(48, 13);
            this.secRecordLabel.TabIndex = 27;
            this.secRecordLabel.Text = "Record2";
            this.secRecordLabel.Visible = false;
            // 
            // thrdRecordLabel
            // 
            this.thrdRecordLabel.AutoSize = true;
            this.thrdRecordLabel.Location = new System.Drawing.Point(292, 245);
            this.thrdRecordLabel.Name = "thrdRecordLabel";
            this.thrdRecordLabel.Size = new System.Drawing.Size(48, 13);
            this.thrdRecordLabel.TabIndex = 28;
            this.thrdRecordLabel.Text = "Record3";
            this.thrdRecordLabel.Visible = false;
            // 
            // WOOHOOLabel
            // 
            this.WOOHOOLabel.AutoSize = true;
            this.WOOHOOLabel.Image = ((System.Drawing.Image)(resources.GetObject("WOOHOOLabel.Image")));
            this.WOOHOOLabel.Location = new System.Drawing.Point(123, 296);
            this.WOOHOOLabel.MinimumSize = new System.Drawing.Size(92, 14);
            this.WOOHOOLabel.Name = "WOOHOOLabel";
            this.WOOHOOLabel.Size = new System.Drawing.Size(92, 14);
            this.WOOHOOLabel.TabIndex = 29;
            this.WOOHOOLabel.Visible = false;
            this.WOOHOOLabel.Click += new System.EventHandler(this.WOOHOOLabel_Click);
            this.WOOHOOLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.WOOHOOLabel_MouseDown);
            this.WOOHOOLabel.MouseEnter += new System.EventHandler(this.WOOHOOLabel_MouseEnter);
            this.WOOHOOLabel.MouseLeave += new System.EventHandler(this.WOOHOOLabel_MouseLeave);
            // 
            // EHLabel
            // 
            this.EHLabel.AutoSize = true;
            this.EHLabel.Image = ((System.Drawing.Image)(resources.GetObject("EHLabel.Image")));
            this.EHLabel.Location = new System.Drawing.Point(268, 296);
            this.EHLabel.MinimumSize = new System.Drawing.Size(96, 14);
            this.EHLabel.Name = "EHLabel";
            this.EHLabel.Size = new System.Drawing.Size(96, 14);
            this.EHLabel.TabIndex = 30;
            this.EHLabel.Visible = false;
            this.EHLabel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.EHLabel_MouseClick);
            this.EHLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.EHLabel_MouseDown);
            this.EHLabel.MouseEnter += new System.EventHandler(this.EHLabel_MouseEnter);
            this.EHLabel.MouseLeave += new System.EventHandler(this.EHLabel_MouseLeave);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 462);
            this.Controls.Add(this.EHLabel);
            this.Controls.Add(this.WOOHOOLabel);
            this.Controls.Add(this.thrdRecordLabel);
            this.Controls.Add(this.secRecordLabel);
            this.Controls.Add(this.fstRecordLabel);
            this.Controls.Add(this.thrdNicknameLabel);
            this.Controls.Add(this.secNicknameLabel);
            this.Controls.Add(this.fstNicknameLabel);
            this.Controls.Add(this.MOOORELabel);
            this.Controls.Add(this.Menu_ExitLabel);
            this.Controls.Add(this.Menu_TutorialLabel);
            this.Controls.Add(this.Menu_HighscoreLabel);
            this.Controls.Add(this.Menu_ShopLabel);
            this.Controls.Add(this.Menu_StartLabel);
            this.Controls.Add(this.HighscorePointsLabel);
            this.Controls.Add(this.OKAAAYLabel);
            this.Controls.Add(this.TimeAmountLabel);
            this.Controls.Add(this.SmokerAmountLabel);
            this.Controls.Add(this.CleanerAmountLabel);
            this.Controls.Add(this.PigeonAmountLabel);
            this.Controls.Add(this.NicknameLabel);
            this.Controls.Add(this.NewNicknameLabel);
            this.Controls.Add(this.HighScoreLabel2);
            this.Controls.Add(this.HighScoreLabel1);
            this.Controls.Add(this.OKLabel);
            this.Controls.Add(this.TotalScoreLabel);
            this.Controls.Add(this.PauseMenu_ExitLabel);
            this.Controls.Add(this.PauseMenu_LeaderboardLabel);
            this.Controls.Add(this.PauseMenu_FAQLabel);
            this.Controls.Add(this.PauseMenu_ContinueLabel);
            this.Controls.Add(this.PointsLabel);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(500, 500);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 500);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "officeman";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label PointsLabel;
        private System.Windows.Forms.Label PauseMenu_ContinueLabel;
        private System.Windows.Forms.Label PauseMenu_FAQLabel;
        private System.Windows.Forms.Label PauseMenu_LeaderboardLabel;
        private System.Windows.Forms.Label PauseMenu_ExitLabel;
        private System.Windows.Forms.Label TotalScoreLabel;
        private System.Windows.Forms.Label OKLabel;
        private System.Windows.Forms.Label HighScoreLabel1;
        private System.Windows.Forms.Label HighScoreLabel2;
        private System.Windows.Forms.Label NewNicknameLabel;
        private System.Windows.Forms.Label NicknameLabel;
        private System.Windows.Forms.Label PigeonAmountLabel;
        private System.Windows.Forms.Label CleanerAmountLabel;
        private System.Windows.Forms.Label SmokerAmountLabel;
        private System.Windows.Forms.Label TimeAmountLabel;
        private System.Windows.Forms.Label OKAAAYLabel;
        private System.Windows.Forms.Label HighscorePointsLabel;
        private System.Windows.Forms.Label Menu_StartLabel;
        private System.Windows.Forms.Label Menu_ShopLabel;
        private System.Windows.Forms.Label Menu_HighscoreLabel;
        private System.Windows.Forms.Label Menu_TutorialLabel;
        private System.Windows.Forms.Label Menu_ExitLabel;
        private System.Windows.Forms.Label MOOORELabel;
        private System.Windows.Forms.Label fstNicknameLabel;
        private System.Windows.Forms.Label secNicknameLabel;
        private System.Windows.Forms.Label thrdNicknameLabel;
        private System.Windows.Forms.Label fstRecordLabel;
        private System.Windows.Forms.Label secRecordLabel;
        private System.Windows.Forms.Label thrdRecordLabel;
        private System.Windows.Forms.Label WOOHOOLabel;
        private System.Windows.Forms.Label EHLabel;
    }
}

