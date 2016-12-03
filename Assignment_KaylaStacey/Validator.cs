/*
 * Name: Kayla Wiest and Stacey Stewart
 * Date: Nov 30, 2015
 * Purpose: A Validator class that validates the textbox inputs
 */
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
            //Checks if a text box is empty,
            //if so, display a message to user that it is required
            if (textBox.Text == String.Empty)
            {
                MessageBox.Show(textBox.Tag + " is a required field", "Missing Input", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox.Focus();
                return false;
            }
            return true;
        }

        public static Boolean IsDecimal(TextBox textBox)
        {
            //Checks if a text box is a decimal,
            //if not display a message to the user that it must be a decimal value
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
        }

        public static Boolean IsInRange(TextBox textBox, decimal min, decimal max)
        {
            //Checks if a text box decimal number is between min and max values
            //If not display a message to the user that it must be between the min and max values
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
