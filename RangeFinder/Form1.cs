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
            List<User> userOutList = new List<User>();
            List<User> finalOut;
            List<User> fullOutList = new List<User>();

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
                    var user = new User(rUse.Key, rUse.Value, false);
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

                finalOut = ListModulo(rangeOutList, userOutList, fullOutList);

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

        private void label1_Click(object sender, EventArgs e)
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

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        public List<User> ListModulo(List<long> rList, List<User> uList, List<User> outList)
        {
            if (uList == null)
            {
                throw new ArgumentNullException(nameof(uList));
            }



            //foreach (var x in rList)
            //{
            //    var unUser = new User("Unassigned", x, false);

            //    foreach (var user in uList)
            //    {
            //        if (user.PhoneNumber == unUser.PhoneNumber && unUser.Listed == false && user.Listed == false)
            //        {
            //           outList.Add(user);
            //            user.Listed = true;
            //            /*fullOutList.Add(unUser)*/
            //        }
            //        else if (user.PhoneNumber != unUser.PhoneNumber && unUser.Listed == false && user.Listed == false)
            //        {
            //            outList.Add(unUser);
            //            unUser.Listed = true;

            //        }
            //        else { break; }
            //    }
            //}

            foreach (var user in uList)
            {
                outList.Add(user);
                user.Listed = true;

                foreach (var x in rList)
                {
                    bool AlreadyListed = false;
                    var unUser = new User("Unassigned", x, false);
                    if (user.PhoneNumber != unUser.PhoneNumber && !Listed(outList,AlreadyListed,unUser))
                    {
                        var y = existenceCheck(unUser,uList);
                        if (y) continue;
                        unUser.Listed = true;
                        outList.Add(unUser);

                    }

                }
            }

            return outList;
        }

        private bool existenceCheck(User user, List<User> list)
        {
            bool existing = false;
            foreach (var u in list)
            {
                if (u.PhoneNumber == user.PhoneNumber)
                {
                    existing = true;
                }
            }

            return existing;
        }

        bool Listed(List<User> list, bool alreadyListed, User user)
        {
            
            
                foreach (var entry in list)
                {
                    if (entry.PhoneNumber == user.PhoneNumber) { alreadyListed = true;}
                }
           
            return alreadyListed;
        }

    }
}
