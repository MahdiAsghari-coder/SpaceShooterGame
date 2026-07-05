namespace SpaceShooterGame
{
    partial class OptionsForm
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
            chkMusic = new CheckBox();
            chkSFX = new CheckBox();
            guide = new Label();
            label1 = new Label();
            label2 = new Label();
            btnSave = new Button();
            SuspendLayout();
            // 
            // chkMusic
            // 
            chkMusic.AutoSize = true;
            chkMusic.BackColor = Color.Green;
            chkMusic.Font = new Font("Segoe Print", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            chkMusic.Location = new Point(111, 300);
            chkMusic.Name = "chkMusic";
            chkMusic.Size = new Size(172, 44);
            chkMusic.TabIndex = 0;
            chkMusic.Text = "Mute Music";
            chkMusic.UseVisualStyleBackColor = false;
            // 
            // chkSFX
            // 
            chkSFX.AutoSize = true;
            chkSFX.BackColor = Color.Green;
            chkSFX.Font = new Font("Segoe Print", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            chkSFX.Location = new Point(420, 300);
            chkSFX.Name = "chkSFX";
            chkSFX.Size = new Size(153, 44);
            chkSFX.TabIndex = 1;
            chkSFX.Text = "Mute SFX";
            chkSFX.UseVisualStyleBackColor = false;
            // 
            // guide
            // 
            guide.AutoSize = true;
            guide.BackColor = Color.Green;
            guide.Font = new Font("Segoe Print", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            guide.Location = new Point(143, 97);
            guide.Name = "guide";
            guide.Size = new Size(370, 40);
            guide.TabIndex = 2;
            guide.Text = "راهنمای کنترل: حرکت با جهت ها";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Green;
            label1.Font = new Font("Segoe Print", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(209, 157);
            label1.Name = "label1";
            label1.Size = new Size(244, 40);
            label1.TabIndex = 3;
            label1.Text = "شلیک : به کمک اسپیس";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Green;
            label2.Font = new Font("Segoe Print", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.Location = new Point(257, 218);
            label2.Name = "label2";
            label2.Size = new Size(159, 40);
            label2.TabIndex = 4;
            label2.Text = "توقف با : Esc";
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.Green;
            btnSave.Font = new Font("Segoe Print", 10.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            btnSave.Location = new Point(30, 30);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(168, 45);
            btnSave.TabIndex = 5;
            btnSave.Text = "ذخیره و بازگشت";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // OptionsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(701, 450);
            Controls.Add(btnSave);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(guide);
            Controls.Add(chkSFX);
            Controls.Add(chkMusic);
            Name = "OptionsForm";
            Text = "OptionsForm";
            Load += OptionsForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox chkMusic;
        private CheckBox chkSFX;
        private Label guide;
        private Label label1;
        private Label label2;
        private Button btnSave;
    }
}