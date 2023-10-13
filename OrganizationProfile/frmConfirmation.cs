using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace OrganizationProfile
{
    public partial class frmConfirmation : Form
    {
        StudentInformationClass studentInformationClass = new StudentInformationClass();
        public frmConfirmation()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {

        }

        private void frmConfirmation_Load(object sender, EventArgs e)
        {
            lblStudentNo.Text = studentInformationClass.SetStudentNo.ToString();
            lblName.Text = studentInformationClass.SetFullName;
            lblProgram.Text = studentInformationClass.SetProgram;
            lblBirthday.Text = studentInformationClass.SetBirthday.ToString();
            lblGender.Text = studentInformationClass.SetGender;
            lblContactNo.Text = studentInformationClass.SetContactNo.ToString();
            lblAge.Text = studentInformationClass.SetAge.ToString(); 

        }
    }
}
