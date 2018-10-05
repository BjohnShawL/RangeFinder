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
        
        public Form1()
        {
            InitializeComponent();
            

        }
        
        private void ImportUserCsv_click(object sender, System.EventArgs e)
        {//Instantiate two lists on button click
            List<long> RangeOutList = new List<long>();
            List<User>UserOutList = new List<User>();
            List<User>fullOutList = new List<User>();

            List<KeyValuePair<string,string>> finalOut = new List<KeyValuePair<string, string>>();

            //check for data in the two boxes - if either is null, prompt for a filepath

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

                foreach (var rUse in reader.StrCsvList)
                {
                    var _user = new User(rUse.Key,rUse.Value,false);
                    UserOutList.Add(_user);
                }

                //foreach (var user in reader.StrCsvList)
                //{
                //    string[] splitter = user.Split(',');
                //    if (splitter[1].Length == 17)
                //    {
                //        splitter[1] = splitter[1].Substring(7);
                //        var _user = new User(splitter[0], Convert.ToInt32(splitter[1]), true);
                //        UserOutList.Add(_user);
                //    }
                //    else
                //    {


                //        var _user = new User(splitter[0], Convert.ToInt32(splitter[1]), true);
                //        UserOutList.Add(_user);
                //    }
                //}

                foreach (var x in RangeOutList)
                {
                    var unUser = new User("Unassigned",x,false);
                    
                    foreach (var user in UserOutList)
                    {
                        if (user.PhoneNumber == unUser.PhoneNumber && unUser.Listed == false && user.Listed == false)
                        {
                            fullOutList.Add(user);
                            user.Listed = true;
                            /*fullOutList.Add(unUser)*/;
                          
                        }
                        else if (user.PhoneNumber != unUser.PhoneNumber && unUser.Listed == false && user.Listed == false)
                        {
                          fullOutList.Add(unUser);
                            unUser.Listed = true;
                            
                        }
                        else { break;}
                    }
                }

                string outfile = string.Join
                (
                    Environment.NewLine, fullOutList.Select(d => d.UserName + "," + d.PhoneNumber)
                );
                System.IO.File.WriteAllText("C: \\Users\\Ben.Liddle\\Desktop\\Scripting\\rangetest.csv", outfile);
            }
            else
            {
                MessageBox.Show(@"Please enter the path of the Csv");
            }
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        // Create browse dialog for CSVs

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
