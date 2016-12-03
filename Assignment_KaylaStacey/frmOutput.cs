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
    public partial class frmOutput : Form
    {

        private StreamReader employeeStreamReader;

        private List<Employee> employees = new List<Employee>();
        private int index = 0;

        public frmOutput()
        {
            InitializeComponent();
        }

        public String filePath { get; set; }

        private void frmOutput_Load(object sender, EventArgs e)
        {
           
            //open file
            openFileDialog();
   
            //see if list is empty
            if(employees.Any())
            {
                txtName.Text = employees.First().Name;
                 txtNumber.Text = employees.First().Number;
                txtHours.Text = employees.First().Hours.ToString();
                txtWage.Text = employees.First().getPay().ToString("c");
            }
            else
            {
                DialogResult result;

                result = MessageBox.Show("Input file is empty", "File Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                if (result == DialogResult.OK)
                {
                   Application.Exit();
                }
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //Close application
            Application.Exit();
        }

        private void openFileDialog()
        {
            String name, number;
            decimal hours;
            //set saveFileDialog settings
            openFileDialog1.InitialDirectory = Path.GetDirectoryName(filePath);
            openFileDialog1.FileName = Path.GetFileName(filePath);

            try
            {
                employeeStreamReader = new StreamReader(openFileDialog1.FileName);
                //take stuff from txt file and poplate list
                while (employeeStreamReader.Peek() != -1)
                {
                    name = employeeStreamReader.ReadLine();
                    number = employeeStreamReader.ReadLine();
                    hours = Decimal.Parse(employeeStreamReader.ReadLine());

                    Employee e = new Employee(name, number, hours);
                    //Add to employee lis
                    employees.Add(e);


                    //add to text blocks
                   // txtName.Text = e.Name;
                   // txtNumber.Text = e.Number;
                    //txtHours.Text = e.Hours.ToString();
                    //txtWage.Text = e.getPay().ToString("c");

          

                }
               



            }
            catch (Exception ex1)
            {
                MessageBox.Show(ex1.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void btnNext_Click(object sender, EventArgs e)
        {

            txtName.Text = employees[index +1].Name;
            txtNumber.Text = employees[index +1].Number;
            txtHours.Text = employees[index +1].Hours.ToString();
            txtWage.Text = employees[index +1].getPay().ToString("c");
            //increase
            index++;

            if (index == employees.Count() - 1) {
                btnNext.Enabled = false;
            }

        }
    }
}
