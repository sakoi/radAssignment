/*
 * Name: Kayla Wiest and Stacey Stewart
 * Date: Nov 30, 2015
 * Purpose: A Employee class with a constructor and property fieldss
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_KaylaStacey
{
    class Employee
    {

        //module level variables
        private String name, number;
        private decimal hours;
        //module level constaints
        private const decimal wage = 10.50m;
        
        public Employee(String name, String number, decimal hours)
        {
            //Employee Constructor
            Name = name;
            Number = number;
            Hours = hours;

        }

        //Property fields for Name
        public String Name{
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        //Property fields for Number
        public String Number
        {
            get
            {
                return number;
            }
            set
            {
                number = value;
            }
        }

        //Property fields for Hours
        public decimal Hours
        {
            get
            {
                return hours;
            }
            set
            {
                hours = value;
            }
        }

        //Method to calculate the wage of a employee by 
        //multiplying hours and wage rate
        public decimal getPay()
        {
            decimal pay = 0;
            pay = Hours * wage;

            return pay;
        }

    }
}
