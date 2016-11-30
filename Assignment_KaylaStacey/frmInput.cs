/*
 * Name: Kayla Wiest and Stacey Stewart
 * Date: Nov 30, 2015
 * Purpose: Allows user to input a Employee Name, Number, and Hours worked.
 *          Once all input fields are entered, save the new entry to a document.
 */ 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment_KaylaStacey
{
    public partial class frmInput : Form
    {

        private StreamWriter employeeStreamWriter;

        public frmInput()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //Close application
            if(employeeStreamWriter != null)
            {
                employeeStreamWriter.Close();
            }
            Application.Exit();
        }

        private void frmInput_Load(object sender, EventArgs e)
        {
            //run save file dialog box
            saveFileDialog();
        
           
        }

        private bool IsValidData()
        {
            //checks if inputs are valid
            return Validator.IsPresent(txtName) &&
                   Validator.IsPresent(txtNumber) &&
                   Validator.IsPresent(txtHours) &&
                   Validator.IsDecimal(txtHours) &&
                   Validator.IsInRange(txtHours, 0, 40); 
        }

        private void saveFileDialog()
        {
            //save file dialog and prompts to user to select file
            DialogResult result;

            //set saveFileDialog settings
            saveFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();
            saveFileDialog1.DefaultExt = "txt";
            saveFileDialog1.Title = "Save File";
            saveFileDialog1.Filter = "Text File(*.txt|*.txt|All Files(*.*)|*.*";

            //save user selection
            result = saveFileDialog1.ShowDialog();

            if(result != DialogResult.Cancel)
            {
                try
                {
                    //Creates file or appends to existing file
                    employeeStreamWriter = new StreamWriter(saveFileDialog1.FileName, true);


                }
                catch (Exception ex1)
                {
                    MessageBox.Show(ex1.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
            else
            {
                //Close Application            
                Application.Exit();
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //Clear all input fields
            txtName.Clear();
            txtNumber.Clear();
            txtHours.Clear();
            txtName.Focus();
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            //Hid Input form and Shows Output form
            frmOutput outputForm = new frmOutput();
            this.Hide();
            outputForm.Show();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //Checks all inputs are valid, if so save to file
            if (IsValidData())
            {
                //If ok, write inputs into StreamWriter, clear textboxes, and displays message to user on success
                try
                {
                    employeeStreamWriter.WriteLine(txtName.Text + " " + txtNumber.Text + " " + txtHours.Text);
                    MessageBox.Show("Employee has been saved", "Save Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtName.Clear();
                    txtNumber.Clear();
                    txtHours.Clear();
                }
                catch (Exception ex2)
                {
                    MessageBox.Show(ex2.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void frmInput_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Close application
            if (employeeStreamWriter != null)
            {
                employeeStreamWriter.Close();
            }
            Application.Exit();
        }
    }
}
