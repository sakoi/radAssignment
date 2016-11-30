using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment_KaylaStacey
{
    class Validator
    {

        public static Boolean IsPresent(TextBox textBox)
        {
            //checks that text input is not empty
            if (textBox.Text == String.Empty)
            {
                MessageBox.Show(textBox.Tag + " is a required field", "Missing Input", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox.Focus();
                return false;
            }
            return true;
        }//end IsPresent

        public static Boolean IsDecimal(TextBox textBox)
        {
            //Checks if input is a numeric value
            decimal number = 0m;
            if (Decimal.TryParse(textBox.Text, out number))
            {
                return true;
            }
            else
            {
                MessageBox.Show(textBox.Tag + " must be a decimal value", "Invaild Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox.SelectAll();
                textBox.Focus();
                return false;
            }
        }//IsDecimal

        public static Boolean IsInRange(TextBox textBox, decimal min, decimal max)
        {
            decimal number = Convert.ToDecimal(textBox.Text);
            if (number < min || number > max)
            {
                MessageBox.Show(textBox.Tag + " must be between " + min + " and " + max, "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox.SelectAll();
                textBox.Focus();

                return false;

            }
            return true;
        }

    }
}
