namespace SpaceShooterGame
{
    partial class MainMenuForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnplay = new Button();
            SuspendLayout();
            // 
            // btnplay
            // 
            btnplay.Location = new Point(199, 81);
            btnplay.Name = "btnplay";
            btnplay.Size = new Size(252, 98);
            btnplay.TabIndex = 1;
            btnplay.Text = "شروع بازی ";
            btnplay.UseVisualStyleBackColor = true;
            btnplay.Click += btnPlay_Click;
            // 
            // MainMenuForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(659, 450);
            Controls.Add(btnplay);
            Name = "MainMenuForm";
            Text = "Space Shooter - Main Menu";
            ResumeLayout(false);
        }

        #endregion

        private Button btnplay;
    }
}
