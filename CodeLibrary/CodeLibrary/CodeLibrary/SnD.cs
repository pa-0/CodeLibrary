﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeLibrary
{
    public partial class SnD : Form
    {
        public SnD()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            search();
        }

        private void SnD_Load(object sender, EventArgs e)
        {
            loadCategories();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13) 
            {
                search();
            }
        }

        private void search()
        {
            string title= "";
            string cat;
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                title = textBox1.Text;
            }
            else
            {

            }

            if (!string.IsNullOrEmpty(comboBox1.Text))
            {
                 cat = comboBox1.Text;
            }
            else
            {
                cat = null;
            }
            StringBuilder strbuilder = new StringBuilder();

            foreach (Snippet x in Main.Snippets)
            {
                if (cat != null && title!="")
                {
                    if (x.title.Contains(title) && cat == x.category)
                    {
                        strbuilder.AppendFormat("Title: {0}{1}", x.title, Environment.NewLine);
                        strbuilder.AppendFormat("Category: {0}{1}", x.category, Environment.NewLine);
                        strbuilder.AppendFormat("Snippet:{0}{1}{2}{3}", Environment.NewLine, x.code, Environment.NewLine, Environment.NewLine);
                        strbuilder.AppendFormat("========================================================================={0}", Environment.NewLine);
                    }
                }
                else if(cat ==null && title!="")
                {
                    if (x.title.Contains(title))
                    {
                        strbuilder.AppendFormat("Title: {0}{1}", x.title, Environment.NewLine);
                        strbuilder.AppendFormat("Category: {0}{1}", x.category, Environment.NewLine);
                        strbuilder.AppendFormat("Snippet:{0}{1}{2}{3}", Environment.NewLine, x.code, Environment.NewLine, Environment.NewLine);
                        strbuilder.AppendFormat("========================================================================={0}", Environment.NewLine);
                    }
                }
                else if (cat != null && string.IsNullOrEmpty(title))
                {
                    if(cat == x.category)
                    {
                        strbuilder.AppendFormat("Title: {0}{1}", x.title, Environment.NewLine);
                        strbuilder.AppendFormat("Category: {0}{1}", x.category, Environment.NewLine);
                        strbuilder.AppendFormat("Snippet:{0}{1}{2}{3}", Environment.NewLine, x.code, Environment.NewLine, Environment.NewLine);
                        strbuilder.AppendFormat("========================================================================={0}", Environment.NewLine);
                    }
                }
                    textBox2.Text = strbuilder.ToString();

            }
            textBox1.Clear();
        }
        private void loadCategories()
        {
            comboBox1.Items.Clear();
            foreach (string x in Main.Categories)
            {
                comboBox1.Items.Add(x);
            }
        }

        private void clear_btn_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
        }
    }
}
