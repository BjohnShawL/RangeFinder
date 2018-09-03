using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RangeFinder.Classes;

namespace RangeFinder
{

    public partial class Form1 : Form
    {
        //public List<int> RangeOutList { get; set; }

        public Form1()
        {
            InitializeComponent();
            

        }
        
        private void ImportUserCsv_click(object sender, System.EventArgs e)
        {
            if (UserListPath.Text != "" && RangeListPath.Text != "")
            {
                CsvReader reader = new CsvReader(UserListPath.Text, RangeListPath.Text);

                foreach (var rNum in reader.IntCsvList)
                {
                   var _range = new Range(rNum);
                    foreach (var _rNum in _range.RangeList)
                    {
                        RangeOutList.Add(_rNum);
                    }
                }

            }
            else
            {
                MessageBox.Show(@"Please enter the path of the Csv");
            }
        }

        public List<int> RangeOutList { get; set; }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void UserListBrowser_Click(object sender, EventArgs e)
        {
            DialogResult result = this.openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.UserListPath.Text = this.openFileDialog1.FileName;
            }
        }

        private void RangeListBrowser_Click(object sender, EventArgs e)
        {
            DialogResult result = this.openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.RangeListPath.Text = this.openFileDialog1.FileName;
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
    }
}
