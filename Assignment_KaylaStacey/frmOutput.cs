/*
 * Name: Kayla Wiest and Stacey Stewart
 * Date: Nov 30, 2015
 * Purpose: Asks the user to select or create a new file to save to.
 *          Allows user to input a Employee Name, Number, and Hours worked.
 *          Saves to the document selected if all input fields are valid.
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
    public partial class frmOutput : Form
    {
        //module level variables
        private StreamReader employeeStreamReader;
        private List<Employee> employees = new List<Employee>();
        private int index = 0;

        public frmOutput()
        {
            InitializeComponent();
        }

        //Property fields for file Path (Get and Set)
        public String filePath { get; set; }

        private void frmOutput_Load(object sender, EventArgs e)
        {
           
            //Open file used in frmInput to read the data 
            openFileDialog();
   
            //If any data in file, read the first employee entry in the Employees list
            if(employees.Any())
            {
                txtName.Text = employees.First().Name;
                 txtNumber.Text = employees.First().Number;
                txtHours.Text = employees.First().Hours.ToString();
                txtWage.Text = employees.First().getPay().ToString("c");

                //If index equals the amount of Employees in the Employees List,
                //Disable the Next button
                if (index == employees.Count() - 1)
                {
                    btnNext.Enabled = false;
                }
            }
            else
            {
                //If no data found in file, notify the user and exit the program after they acknowledge
                DialogResult result;

                result = MessageBox.Show("Input file is empty", "File Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                if (result == DialogResult.OK)
                {
                   employeeStreamReader.Close();
                   Application.Exit();
                }
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //Close StreamReader
            if (employeeStreamReader != null)
            {
                employeeStreamReader.Close();
            }
            //Close application
            Application.Exit();
        }

        private void openFileDialog()
        {
            //local variables
            String name, number;
            decimal hours;

            //set saveFileDialog settings to filePath form frmInput
            openFileDialog1.InitialDirectory = Path.GetDirectoryName(filePath);
            openFileDialog1.FileName = Path.GetFileName(filePath);

            try
            {
                employeeStreamReader = new StreamReader(openFileDialog1.FileName);

                //While there is data in the file, 
                //read each line and add the data into the Employee constructor
                while (employeeStreamReader.Peek() != -1)
                {
                    name = employeeStreamReader.ReadLine();
                    number = employeeStreamReader.ReadLine();
                    hours = Decimal.Parse(employeeStreamReader.ReadLine());

                    //Create the Employee instance
                    Employee e = new Employee(name, number, hours);
                    
                    //Add new Employee to the Employees List
                    employees.Add(e);
                }
            }
            catch (Exception ex1)
            {
                MessageBox.Show(ex1.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
  
            //When user clickes Next,
            //populate the next Employee in the Employees List by 
            //using the current index and adding 1.
            txtName.Text = employees[index +1].Name;
            txtNumber.Text = employees[index +1].Number;
            txtHours.Text = employees[index +1].Hours.ToString();
            txtWage.Text = employees[index +1].getPay().ToString("c");

            //Increase the index by 1
            index++;
            
            //If index equals the amount of Employees in the Employees List,
            //Disable the Next button and display message to user
            if (index == employees.Count() - 1)
            {
                btnNext.Enabled = false;
                MessageBox.Show("No more employee records to display", "Employee Recors", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void frmOutput_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Close StreamReader
            if (employeeStreamReader != null)
            {
                employeeStreamReader.Close();
            }
            //Close application
            Application.Exit();
        }
    }
}
