namespace SpaceShooterGame
{
    partial class AboutForm
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
            name = new Label();
            studentnum = new Label();
            label1 = new Label();
            btnBackToMenu = new Button();
            SuspendLayout();
            // 
            // name
            // 
            name.AutoSize = true;
            name.BackColor = Color.Green;
            name.Font = new Font("Segoe Print", 16.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            name.Location = new Point(281, 78);
            name.Name = "name";
            name.Size = new Size(212, 50);
            name.TabIndex = 0;
            name.Text = "MahdiAsghari";
            // 
            // studentnum
            // 
            studentnum.AutoSize = true;
            studentnum.BackColor = Color.Green;
            studentnum.Font = new Font("Segoe Print", 16.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            studentnum.Location = new Point(157, 171);
            studentnum.Name = "studentnum";
            studentnum.Size = new Size(470, 50);
            studentnum.TabIndex = 1;
            studentnum.Text = "student number : 403411123 ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Green;
            label1.Font = new Font("Segoe Print", 16.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(172, 279);
            label1.Name = "label1";
            label1.Size = new Size(441, 50);
            label1.TabIndex = 2;
            label1.Text = "I hope you engoyed this game";
            // 
            // btnBackToMenu
            // 
            btnBackToMenu.BackColor = Color.Green;
            btnBackToMenu.Location = new Point(32, 12);
            btnBackToMenu.Name = "btnBackToMenu";
            btnBackToMenu.Size = new Size(148, 83);
            btnBackToMenu.TabIndex = 3;
            btnBackToMenu.Text = "back to menu";
            btnBackToMenu.UseVisualStyleBackColor = false;
            btnBackToMenu.Click += btnBackToMenu_Click;
            // 
            // AboutForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(766, 450);
            Controls.Add(btnBackToMenu);
            Controls.Add(label1);
            Controls.Add(studentnum);
            Controls.Add(name);
            Name = "AboutForm";
            Text = "AboutForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label name;
        private Label studentnum;
        private Label label1;
        private Button btnBackToMenu;
    }
}