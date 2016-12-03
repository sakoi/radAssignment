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
        //module level variables
        private StreamWriter employeeStreamWriter;
        private String path;

        public frmInput()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //Close StreamWriter
            if(employeeStreamWriter != null)
            {
                employeeStreamWriter.Close();
            }
            //Close application
            Application.Exit();
        }

        private void frmInput_Load(object sender, EventArgs e)
        {
            //Open saveFileDialog 
            saveFileDialog();
            
        }

        private bool IsValidData()
        {
            //Checks that all user inputs are valid
            return Validator.IsPresent(txtName) &&
                   Validator.IsPresent(txtNumber) &&
                   Validator.IsPresent(txtHours) &&
                   Validator.IsDecimal(txtHours) &&
                   Validator.IsInRange(txtHours, 0, 40); 
        }

        private void saveFileDialog()
        {
            //Prompts the user to select or save a file 

            DialogResult result;

            //Set saveFileDialog settings
            saveFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();
            saveFileDialog1.DefaultExt = "txt";
            saveFileDialog1.Title = "Save File";
            saveFileDialog1.Filter = "Text File(*.txt|*.txt|All Files(*.*)|*.*";

            //Ask user for selection or creation
            result = saveFileDialog1.ShowDialog();

            if(result != DialogResult.Cancel)
            {
                try
                {
                    //Creates file or appends to existing file
                    employeeStreamWriter = new StreamWriter(saveFileDialog1.FileName, true);
                    
                    //Save the file path
                    path = Path.GetFullPath(saveFileDialog1.FileName);
                }
                catch (Exception ex1)
                {
                    MessageBox.Show(ex1.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

               //set windowstate to normal
               //fixes the minimized bug where once a user save a file the frmInput would say minimized
               this.WindowState = FormWindowState.Normal;
            }
            else
            {
                //If user did not select a file, close Application            
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
            //Close StreamWriter
            employeeStreamWriter.Close();

            //Hide frmInput and create new frmOutput and set the filepath to saved path
            frmOutput outputForm = new frmOutput();
            outputForm.filePath = path;
            this.Hide();
            outputForm.Show();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //Checks all inputs are valid, if so save to file
            if (IsValidData())
            {
                //Write valid inputs into StreamWriter, clear textboxes,
                //and displays message to user on successful save
                try
                {
                    employeeStreamWriter.WriteLine(txtName.Text);
                    employeeStreamWriter.WriteLine(txtNumber.Text);
                    employeeStreamWriter.WriteLine(txtHours.Text);
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
            //Close StreamWriter
            if (employeeStreamWriter != null)
            {
                employeeStreamWriter.Close();
            }
            //Close Application
            Application.Exit();
        }

    }
}
