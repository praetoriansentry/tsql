﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TSQLFormatter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void formatSqlButton_Click(object sender, EventArgs e)
        {
            Formatter f = new Formatter();
            outputSql.Text = f.Format(inputSql.Text);
        }

    }
}
