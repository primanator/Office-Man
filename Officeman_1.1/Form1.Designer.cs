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
            this.PointsLabel = new System.Windows.Forms.Label();
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
            this.PointsLabel.MinimumSize = new System.Drawing.Size(120, 20);
            this.PointsLabel.Name = "PointsLabel";
            this.PointsLabel.Size = new System.Drawing.Size(120, 20);
            this.PointsLabel.TabIndex = 0;
            this.PointsLabel.Text = "0";
            this.PointsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.PointsLabel.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 462);
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
    }
}

