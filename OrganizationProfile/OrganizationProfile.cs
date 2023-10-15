using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrganizationProfile
{
    public partial class frmRegistration : Form
    {
        public frmRegistration()
        {
            InitializeComponent();
        }

        private void frmRegistration_Load(object sender, EventArgs e)
        {

            string[] ListOfPrograms = new string[] {
                "BS in Information Technology",
                "BS in Computer Science",
                "BS in Information Systems",
                "BS in Accountancy",
                "BS in Hospitality Management",
                "BS in Tourism Management"
            };

            for (int i = 0; i < ListOfPrograms.Length; i++)
            {
                cbPrograms.Items.Add(ListOfPrograms[i].ToString());
            }

            string[] listOfGender = new string[] {
                "Male",
                "Female"
            };

            for (int i = 0; i < 2; i++)
            {
                cbGender.Items.Add(listOfGender[i].ToString());
            }

        }

        private string _FullName;
        private int _Age;
        private long _ContactNo;
        private long _StudentNo;

        public long StudentNumber(string studNum)
        {
            try
            {
                if (Regex.IsMatch(studNum, @"^[0-9]{10,11}$"))
                {
                    _StudentNo = long.Parse(studNum);
                }
                else
                {
                    throw new FormatException("Please enter digits only!");
                }
            }
            catch (Exception fme)
            {
                MessageBox.Show("Message : " + fme);
            }

            return _StudentNo;

        }

        public long ContactNo(string Contact)
        {
            try
            {
                if (Regex.IsMatch(Contact, @"^[0-9]{10,11}$"))
                {
                    _ContactNo = long.Parse(Contact);
                }
                else
                {
                    throw new IndexOutOfRangeException("Please enter 11 digits only!");
                }
            }
            catch (Exception ixr)
            {
                MessageBox.Show("Message : " + ixr);
            }

            return _ContactNo;
        }

        public string FullName(string LastName, string FirstName, string MiddleInitial)
        {
            try
            {
                if (Regex.IsMatch(LastName, @"^[a-zA-Z]+$") || Regex.IsMatch(FirstName, @"^[a-zA-Z]+$") || Regex.IsMatch(MiddleInitial, @"^[a-zA-Z]+$"))
                {
                    _FullName = LastName + ", " + FirstName + ", " + MiddleInitial;
                }
                else
                {
                    throw new ArgumentNullException("LastName, FirstName, and MiddleInitial Textbox is empty!!");
                }
            }
            catch (Exception ane)
            {
                MessageBox.Show("Message: " + ane);
            }

            return _FullName;
        }

        public int Age(string age)
        {
            try
            {
                if (Regex.IsMatch(age, @"^[0-9]{1,3}$"))
                {
                    _Age = Int32.Parse(age);
                }
                else
                {
                    throw new OverflowException("Plese enter your real age!");
                }
            }
            catch (Exception oex)
            {
                MessageBox.Show("Message : " + oex);
            }
            finally
            {
                MessageBox.Show("Please fill up correctly.");
            }
            return _Age;
        }


        private void btnRegistration_Click(object sender, EventArgs e)
        {

            StudentInformationClass.SetFullName = FullName(txtLastName.Text, txtFirstName.Text, txtMiddleInitial.Text);
            StudentInformationClass.SetStudentNo = StudentNumber(txtStudentNo.Text);
            StudentInformationClass.SetProgram = cbPrograms.Text;
            StudentInformationClass.SetGender = cbGender.Text;
            StudentInformationClass.SetContactNo = ContactNo(txtContactNo.Text);
            StudentInformationClass.SetAge = Age(txtAge.Text);
            StudentInformationClass.SetBirthday = datePickerBirtday.Value.ToString("yyyy-MM-dd");
            frmConfirmation frm = new frmConfirmation();
            frm.ShowDialog();

        }
    }
}
