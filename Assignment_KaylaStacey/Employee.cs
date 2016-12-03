using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_KaylaStacey
{
    class Employee
    {

        private String name, number;
        private decimal hours;
        private const decimal wage = 10.50m;
        
        public Employee(String name, String number, decimal hours)
        {
            //Employee Constructor
            Name = name;
            Number = number;
            Hours = hours;

        }

        public String Name{
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }//end name

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
        }//end number

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
        }//end hours

        public decimal getPay()
        {
            decimal pay= 0;

            pay = Hours * wage;

            return pay;
        }

    }
}
