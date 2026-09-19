using static System.Net.Mime.MediaTypeNames;

namespace OrganizationProfile
{
    public partial class frmRegistration : Form
    {
        frmConfirmation frm;
        public frmRegistration()
        {
            InitializeComponent();
            frm = new frmConfirmation();

        }

        private void frmRegistration_Load(object sender, EventArgs e)
        {
            string[] ListOfProgram = new string[] { "BS Information Technology", "BS Computer Science", "BS Information Systems", "BS in Accountancy", "BS in Hospitality Management", "BS in Tourism Management" };

            for (int i = 0; i < 6; i++)
            {
                cbProgram.Items.Add(ListOfProgram[i]);
            }
            cbGender.Items.Add("Male");
            cbGender.Items.Add("Female");
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                StudentInformationClass.SetFullName = frm.FullName(txtLastName.Text, txtFirstName.Text, txtMiddleInitial.Text);
                StudentInformationClass.SetStudentNo = frm.StudentNumber(txtStudentNo.Text);
                StudentInformationClass.SetProgram = cbProgram.Text;
                StudentInformationClass.SetGender = cbGender.Text;
                StudentInformationClass.SetContactNo = frm.ContactNo(txtContactNo.Text);
                StudentInformationClass.SetAge = frm.Age(txtAge.Text);
                StudentInformationClass.SetBirthday = datePickerBirthday.Value.ToString("yyyy-MM-dd");
                frm.ShowDialog();
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Invalid format!", "Error has occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show("Invalid input!", "Error has occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IndexOutOfRangeException ex)
            {
                MessageBox.Show("Index is out of range!", "Error has occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (OverflowException ex)
            {
                MessageBox.Show("Overflow error!", "Error has occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                MessageBox.Show("The finally statement works btw.");
            }

            if (frm.reset == true)
            {
                txtFirstName.Clear();
                txtLastName.Clear();
                txtMiddleInitial.Clear();
                txtAge.Clear();
                txtContactNo.Clear();
                txtStudentNo.Clear();
                cbGender.SelectedIndex = -1;
                cbProgram.SelectedIndex = -1;
            }

        }
    }
}
