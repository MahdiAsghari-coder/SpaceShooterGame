using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SpaceShooterGame
{
    public partial class OptionsForm : Form
    {
        public OptionsForm()
        {
            InitializeComponent();
        }

        private void OptionsForm_Load(object sender, EventArgs e)
        {
            chkMusic.Checked = GameSettings.IsMusicMuted;
            chkSFX.Checked = GameSettings.IsSFXMuted;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            GameSettings.IsMusicMuted = chkMusic.Checked;
            GameSettings.IsSFXMuted = chkSFX.Checked;

            this.Close();
        }
    }
}
