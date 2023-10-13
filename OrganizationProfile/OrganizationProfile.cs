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

        StudentInformationClass studentInformationClass = new StudentInformationClass();

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

        }

        private string _FullName;
        private int _Age;
        private long _ContactNo;
        private long _StudentNo;

        public long StudentNumber(string studNum)
        {

            _StudentNo = long.Parse(studNum);

            return _StudentNo;
        }

        public long ContactNo(string Contact)
        {
            if (Regex.IsMatch(Contact, @"^[0-9]{10,11}$"))
            {
                _ContactNo = long.Parse(Contact);
            }

            return _ContactNo;
        }

        public string FullName(string LastName, string FirstName, string MiddleInitial)
        {
            if (Regex.IsMatch(LastName, @"^[a-zA-Z]+$") || Regex.IsMatch(FirstName, @"^[a-zA-Z]+$") || Regex.IsMatch(MiddleInitial, @"^[a-zA-Z]+$"))
            {
                _FullName = LastName + ", " + FirstName + ", " + MiddleInitial;
            }

            return _FullName;
        }

        public int Age(string age)
        {
            if (Regex.IsMatch(age, @"^[0-9]{1,3}$"))
            {
                _Age = Int32.Parse(age);
            }

            return _Age;
        }

        private void btnRegistration_Click(object sender, EventArgs e)
        {
            studentInformationClass.SetFullName = FullName(txtLastName.Text,txtFirstName.Text, txtMiddleInitial.Text);
            studentInformationClass.SetStudentNo = (int)StudentNumber(txtStudentNo.Text);
            studentInformationClass.SetProgram = cbPrograms.Text;
            studentInformationClass.SetGender = cbGender.Text;
            studentInformationClass.SetContactNo = (int)ContactNo(txtContactNo.Text);
            studentInformationClass.SetAge = (int)Age(txtAge.Text); 
            studentInformationClass.SetBirthday = datePickerBirthday.Value.ToString("yyyyMM-dd");
            frmConfirmation frm = new frmConfirmation();
            frm.ShowDialog();


        }
    }
}
