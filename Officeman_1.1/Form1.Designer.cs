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
            this.SuspendLayout();
            // 
            // PointsLabel
            // 
            PrivateFontCollection newFont = new PrivateFontCollection();
            newFont.AddFontFile("..\\..\\font\\Chava-Regular.ttf");
            FontFamily chava = new FontFamily("Chava", newFont);
            this.PointsLabel.Font = new System.Drawing.Font(chava, 10, System.Drawing.FontStyle.Regular);

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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 462);
            this.Controls.Add(this.PauseMenu_ExitLabel);
            this.Controls.Add(this.PauseMenu_LeaderboardLabel);
            this.Controls.Add(this.PauseMenu_FAQLabel);
            this.Controls.Add(this.PauseMenu_ContinueLabel);
            this.Controls.Add(this.PointsLabel);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(500, 500);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 500);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
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
    }
}

