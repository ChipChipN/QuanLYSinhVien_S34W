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
    public partial class Han : Form
    {
        public Han()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.freepik.com/icon/teacher_8803809#fromView=keyword&page=1&position=20&uuid=b6217088-d0e2-44d5-979c-5fd3dc875550");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://zalo.me/0985446004");
        }
    }
}