using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppDZ9
{
    public class Contact
    {
       public string Name;
        public long PhoneNumber;
        public Contact(string name, long phoneNumber)
        {
            Name = name;
            PhoneNumber = phoneNumber;
        }
    }
}
