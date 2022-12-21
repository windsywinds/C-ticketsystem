using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem;

namespace TicketSystem
{
    internal class TicketStats 
    {

        public static int ticket_base = 2000;
        public int ticket_no;
        private string name;        //
        private string email;       //Private strings for personal details: Name, Email, Staff ID  
        private string staff_id;    //
        public string issue;
        public string status;
        public string response;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Email
        {
            get { return email; }    //3 {get and set} methods for private strings applied to details most likely to contain sensitive data
            set { email = value; }
        }

        public string Staff_id 
        {
            get { return staff_id; }    
            set { staff_id = value; }   
        }       
                

        public TicketStats(string f_name, string f_email, string f_staff_id, string f_issue) //When the user provides all details the following constructor will be used
        {
            Name = f_name;
            Email = f_email;
            Staff_id = f_staff_id;
            issue = f_issue;
            status = "Open";
            ticket_base++;
            ticket_no = ticket_base;
            response = "No response";
        }

        public TicketStats(string f_staff_id, string f_issue) //If only Staff Id and Issue this constructor is used
        {
            Name = "Not Specified";
            Email = "Not specified";
            Staff_id = f_staff_id;
            issue = f_issue;
            status = "Open";
            ticket_base++;
            ticket_no = ticket_base;
            response = "No response";
        }
        
        public void show_tickets() //displays all recorded details of each ticket including the newly generated password if relevant
        {
            Console.WriteLine("Ticket Number: " + ticket_no);
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Staff ID: " + Staff_id);
            Console.WriteLine("User email: " + Email);
            Console.WriteLine("Description: " + issue);
            Console.WriteLine("Response: " + response);

            if (issue.Contains("Password change") || issue.Contains("assword change")) // if statement calls the below static method if the condition is met. || to allow for lack of capitalisation
            {

                string new_pass = PasswordGenerator.Change_pass(Staff_id, ticket_no);        // Staff_id and ticket_no are passed through to the method    
                Console.WriteLine("Your new password is:" + new_pass);                
               
            }
            Console.WriteLine("Ticket status: " + status);
            Console.WriteLine("*********************************************");  // breaker to help make reading easier for user
        }
    }
}
