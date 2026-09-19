using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.AxHost;

namespace OrganizationProfile
{
    public partial class frmConfirmation : Form
    {
        private string _FullName;
        private int _Age;
        private long _ContactNo;
        private long _StudentNo;

        public frmConfirmation()
        {
            InitializeComponent();
            
        }

        private void frmConfirmation_Load(object sender, EventArgs e)
        {
            lblStudentNo.Text = StudentInformationClass.SetStudentNo.ToString(); 
            lblName.Text = StudentInformationClass.SetFullName;
            lblProgram.Text = StudentInformationClass.SetProgram;
            lblBirthday.Text = StudentInformationClass.SetBirthday; 
            lblGender.Text = StudentInformationClass.SetGender;
            lblContactNo.Text = StudentInformationClass.SetContactNo.ToString(); 
            lblAge.Text = StudentInformationClass.SetAge.ToString();
        }
        public long StudentNumber(string studNum)
        {
            try
            {
                _StudentNo = long.Parse(studNum);
            }
            catch (FormatException e)
            {
                MessageBox.Show("Invalid format", "An error has occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IndexOutOfRangeException ex)
            {
                MessageBox.Show("Input out of range.", "An error has occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show("Invalid input.", "An error has occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    throw new FormatException("Nah");
                }
            }catch (FormatException e)
            {
                MessageBox.Show("Invalid format", "An error has occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show("Invalid input.", "An error has occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    throw new FormatException("Nah");
                }
            }catch (FormatException e)
            {
                MessageBox.Show("Invalid format.", "An error has occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show("Invalid input.", "An error has occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
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
                    throw new IndexOutOfRangeException("Nah man");
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Invalid format.", "An error has occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IndexOutOfRangeException ex)
            {
                MessageBox.Show("Input out of range.", "An error has occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show("Invalid input.", "An error has occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return _Age;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
