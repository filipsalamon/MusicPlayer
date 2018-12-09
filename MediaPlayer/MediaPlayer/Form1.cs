using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MediaPlayer
{
    public partial class Form1 : Form
    {
        string[] doc, path;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Multiselect = true;
            open.Filter = "MP3 Files|*.mp3|Avi Files|*.avi|Wav Files|*.wav";
            if (open.ShowDialog() == DialogResult.OK)
            {
                doc = open.SafeFileNames;
                path = open.FileNames;
                for (int i = 0; i < doc.Length; i++)
                {
                    listBox1.Items.Add(doc[i]);
                }
            }

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                axWindowsMediaPlayer1.URL = path[listBox1.SelectedIndex];
            }
            catch(IndexOutOfRangeException r)
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ListBox.ObjectCollection list = listBox1.Items;
            Random random = new Random();
            int w = list.Count;
            listBox1.BeginUpdate();
            while (w > 1)
            {
                w--;
                int u = random.Next(w + 1);
                object value = list[u];
                list[u] = list[w];
                list[w] = value;
            }
            listBox1.EndUpdate();
            listBox1.Invalidate();


        }
    }
}
