using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem;

namespace TicketSystem
{
    internal class PasswordGenerator
    {     

       public static string Change_pass(string staff_id, int ticket) //overloaded method with the staff iD and ticket number sent from TicketStats class
        {
            
            string timeStamp = DateTime.Now.ToString("hmm"); 
            string value0 = Convert.ToInt32(timeStamp[0]).ToString("X");
            string value1 = Convert.ToInt32(timeStamp[1]).ToString("X");        //converts the 3 characters from DateTime to hexadecimal.
            string value2 = Convert.ToInt32(timeStamp[2]).ToString("X");
            string new_password = staff_id.Substring(0, 2) + ticket.ToString("X") + value0 + value1 + value2;   // combines the staff id, ticket, and time stamp to create a new password
            return new_password;           
        }

       
    }
}
    