﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLLOPHOC_QLDIEM
{
    public partial class Man : Form
    {
        public Man()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.freepik.com/icon/chick_2632839#fromView=keyword&page=1&position=4&uuid=b6217088-d0e2-44d5-979c-5fd3dc875550");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://zalo.me/0866694140");
        }
    }
}