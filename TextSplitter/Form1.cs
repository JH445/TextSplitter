using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace TextSplitter
{
    public partial class Form1 : Form
    {
        //Global Variables
        string sFileName;
        string outPath;
        int MAX_LINES_USER;

        //Global Constant
        const int MAX_LINES_DEFAULT = 500000;
    
    public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //var reader = File.OpenText("C:\\Users\\Jeremy\\Desktop\\es\\es-stdout.2019-01-15.log");
            //if (outPath = "")

            var reader = File.OpenText(sFileName);
            //string outFileName = "file{0}.txt";
            string outFileName = outPath + "\\file{0}.txt";
            int outFileNumber = 1;
            //const int MAX_LINES = 1500000;
            if (textBox3.Text == "")
            {
                MessageBox.Show(textBox3.Text + "No Value provided, using default line count (500,000).");
                MAX_LINES_USER = MAX_LINES_DEFAULT;
                MessageBox.Show(Convert.ToString("Line break = " + MAX_LINES_USER));
            }
            else
            {
                MAX_LINES_USER = Convert.ToInt32(textBox3.Text);
                MessageBox.Show(Convert.ToString(MAX_LINES_USER));
            }
            
            while (!reader.EndOfStream)
            {
                //var writer = File.CreateText(string.Format(outFileName, outFileNumber++));
                
                var writer = File.CreateText(string.Format(outFileName, outFileNumber++));
                for (int idx = 0; idx < MAX_LINES_USER; idx++)
                {
                    writer.WriteLine(reader.ReadLine());
                    if (reader.EndOfStream) break;
                }
                writer.Close();
            }
            reader.Close();

            MessageBox.Show("Split completed.");
        }

        private void button3_Click(object sender, EventArgs e)
        {
              OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "All Files (*.*) |*.*";
                ofd.FilterIndex = 1;
                ofd.Multiselect = false;
            //string sFileName = null;
            sFileName = null;
            MessageBox.Show(sFileName);

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    sFileName = ofd.FileName;
                    string[] arrAllFiles = ofd.FileNames; // used when Multiselect = true
                    MessageBox.Show(sFileName);
                //populate the text box field with the path and full path to file
                textBox1.Text = sFileName;


            }
                else
                {
                    sFileName = string.Empty;
                }
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            var fbd1 = new FolderBrowserDialog();

            //Show the FolderBrowserDialog
            DialogResult result = fbd1.ShowDialog();

            if (result == DialogResult.OK )
            {
                outPath = fbd1.SelectedPath;
                MessageBox.Show(outPath);
                textBox2.Text = outPath;
            }
        }
    }
}
