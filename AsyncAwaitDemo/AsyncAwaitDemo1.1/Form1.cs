using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncAwaitDemo1._1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private async void btnReadFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Before async call");
                await GetDataAsync(openFileDialog.FileName);
                MessageBox.Show("After async call");
            }
        }

        private async Task GetDataAsync(string fileName)
        {
            byte[] data = null;

            using (FileStream fileStream = File.Open(fileName, FileMode.Open))
            {
                data = new byte[fileStream.Length];
                await fileStream.ReadAsync(data, 0, (int)fileStream.Length);
            }
            textBox1.Text = Encoding.Default.GetString(data);
        }
    }
}
