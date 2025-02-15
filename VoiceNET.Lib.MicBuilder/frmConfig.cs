﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VoiceNET.Lib.MicBuilder
{
    public partial class frmConfig : Form
    {
        public frmConfig()
        {
            InitializeComponent();

            txtPathFolder.Text = VBuilder.getPathDataset();

            hsMicCont.Value = VBuilder.getMicTime();

            hsMinValue.Value = VBuilder.getMinVolume();

            lbMinVolume.Text = hsMinValue.Value.ToString() + "%";

            lbTimeCont.Text = hsMicCont.Value.ToString() + "ms";

        }

        private void hsMinValue_Scroll(object sender, ScrollEventArgs e)
        {

            lbMinVolume.Text = hsMinValue.Value.ToString() + "%";

            VBuilder.setMinVolume(hsMinValue.Value);

        }

        private void hsMicCont_Scroll(object sender, ScrollEventArgs e)
        {

            lbTimeCont.Text = hsMicCont.Value.ToString() + "ms";

            VBuilder.setMicTime(hsMicCont.Value);

        }


        private void frmConfig_Load(object sender, EventArgs e) { }

        private void btnChooseFolder_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())

            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {

                    txtPathFolder.Text =(fbd.SelectedPath);

                    VBuilder.setPathDataset(txtPathFolder.Text);

                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e) => closeFrm();

        private void closeFrm()
        {
            if (String.IsNullOrEmpty(txtPathFolder.Text))
            {

                MessageBox.Show("Please choose a folder for the dataset!", "MessageBox");

                return;

            }

            VBuilder.setPathDataset(txtPathFolder.Text);

            VBuilder.setMinVolume(hsMinValue.Value);

            VBuilder.setMicTime(hsMicCont.Value);

            Hide();
        }
     /*   private void frmConfig_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                closeFrm();
            }
            e.Cancel = true;
        } */
    }
}
