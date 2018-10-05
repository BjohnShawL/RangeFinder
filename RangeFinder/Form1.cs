using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
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
        
        private void ImportUserCsv_click(object sender, EventArgs e)
        {//Instantiate three lists on button click
            List<long> rangeOutList = new List<long>();
            List<User>userOutList = new List<User>();
            List<User> finalOut;

            //check for data in the two boxes - if either is null, prompt for a filepath

            if (UserListPath.Text != "" && RangeListPath.Text != "")
            {
                CsvReader reader = new CsvReader(UserListPath.Text, RangeListPath.Text);

                foreach (var rNum in reader.IntCsvList)
                {
                   var range = new Range(rNum);
                    foreach (var _rNum in range.RangeList)
                    {
                        rangeOutList.Add(_rNum);
                    }
                }

                foreach (var rUse in reader.StrCsvList)
                {
                    var user = new User(rUse.Key,rUse.Value,false);
                    userOutList.Add(user);
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

                finalOut = ListModulo(userOutList, rangeOutList);

                string outfile = string.Join
                (
                    Environment.NewLine, finalOut.Select(d => d.UserName + "," + d.PhoneNumber)
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

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        // Create browse dialog for CSVs

        private void UserListBrowser_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                UserListPath.Text = openFileDialog1.FileName;
            }
        }

        private void RangeListBrowser_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                RangeListPath.Text = openFileDialog1.FileName;
            }
        }

        private void OpenFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        public List<User> ListModulo(List<User> ulist, List<long> rList)
        {
            List<User> fullOutList = new List<User>();

            foreach (var x in rList)
            {
                var unUser = new User("Unassigned", x, false);

                foreach (var user in ulist)
                {
                    if (user.PhoneNumber == unUser.PhoneNumber && unUser.Listed == false && user.Listed == false)
                    {
                        fullOutList.Add(user);
                        user.Listed = true;
                        /*fullOutList.Add(unUser)*/
                    }
                    else if (user.PhoneNumber != unUser.PhoneNumber && unUser.Listed == false && user.Listed == false)
                    {
                        fullOutList.Add(unUser);
                        unUser.Listed = true;

                    }
                    else { break; }
                }
            }

            return fullOutList;
        }

    }
}
