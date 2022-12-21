using TicketSystem;
using System.Collections.Generic;

//Sam Windsor
//Student ID 20220552

List<TicketStats> Open = new List<TicketStats>();
List<TicketStats> Closed = new List<TicketStats>();
List<TicketStats> Reopened = new List<TicketStats>();


codestart: //This is a goto jump point from end of code to help with ease of testing. i.e. retains user inputs instead of having to re-enter tickets each time the code is executed incase tester unintentionally reaches end of program

Console.WriteLine("Welcome to the IT ticketing system!");
Console.WriteLine("Do you want to submit a ticket? yes/no");
string option1 = Console.ReadLine(); 
    if (option1 == "yes")                           //This if statement allows the user to submit a ticket or go to the next menu for ticket management
{        
        string running = "yes";
        while (running == "yes")                    //This loop lets the user continue to submit multiple tickets before moving on
        {
            TicketStats objopen;                    //Defines the temporary object to hold users information
            Console.WriteLine("Please enter your ticket details: ");
            Console.WriteLine("Please enter name: "); 
            string n_name = Console.ReadLine();
            Console.WriteLine("Enter email address: ");
            string n_email = Console.ReadLine();
            Console.WriteLine("Enter Staff ID: ");
            string n_staff_id = Console.ReadLine();                 //These strings and inputs define the values for the overloaded constructor for objopen
            Console.WriteLine("Enter Issue: ");
            string n_issue = Console.ReadLine();
            if (n_name == "" || n_email == "")
            {
                objopen = new TicketStats(n_staff_id, n_issue);                     //If no name or no email is provided, only these details are passed         
            }
            else
            {
                objopen = new TicketStats(n_name, n_email, n_staff_id, n_issue);    //If Name, Email, Staff ID, Issue are provided all inputs will be used               
            }
            Open.Add(objopen);                    //Adds the user inputs to the Open list with the provided details
            Console.WriteLine("Ticket submitted");
            if (n_issue.Contains("Password change") || n_issue.Contains("assword change"))          //after the above constructor has been selected, it will then check the issue. || is added to allow for lack of capitalisation
            {                
                Open.Remove(objopen);                           //Removes from Open list
                Closed.Add(objopen);                            //Adds to closed list
                objopen.response = "New password generated";    // Changes the tickets response as a solution has been provided
                objopen.status = "Closed";                      // Changes the ticket status to closed
                Console.WriteLine("Ticket closed and new password generated");
                objopen.show_tickets();                         //This will display the ticket info for tickets that require new passwords so that the user is given their new password.
                
            }  
            Console.WriteLine("Submit another ticket? yes/no");
            running = Console.ReadLine();                   //User can enter more tickets or program will open ticket management options

        }
    }
Console.WriteLine("Do you want to enter the ticket management menu? yes/no");
string option2 = Console.ReadLine();
while (option2 == "yes")
    {
        Console.WriteLine("Ticket stats:");
        Console.WriteLine("Select 1 to display Open tickets:");
        Console.WriteLine("Select 2 to display Closed tickets:");
        Console.WriteLine("Select 3 to display Reopened tickets:");
        Console.WriteLine("Select 4 to reopen closed tickets");
        Console.WriteLine("Select 5 to provide a response to tickets");
        Console.WriteLine("Select 6 to display ticket stats and print all tickets");
        int display = Convert.ToInt32(Console.ReadLine());
        if (display == 1)
        {
            int Open_count = Open.Count;
            for (int i = 0; i < Open_count; i++)
            {
                Open[i].show_tickets();
            }
        }
        if (display == 2)
        {
            int Closed_count = Closed.Count;
            for (int i = 0; i < Closed_count; i++)          //The first 3 if options allow the user to display the count and details of all relevant tickets with statuses: Open, closed, reopened
            {
                Closed[i].show_tickets();
            }

        }
        if (display == 3)
        {
            int Reopened_count = Reopened.Count;
            for (int i = 0; i < Reopened_count; i++)
            { 
                Reopened[i].show_tickets();
            }
        }
        if (display == 4)
        {
            Console.WriteLine("Please enter Ticket number to reopen: ");
            int to_reopen = Convert.ToInt32(Console.ReadLine());
            int Closed_count = Closed.Count;
            for (int i = 0; i < Closed_count; i++)
            {
                TicketStats tempobj = Closed[i];
                if (tempobj.ticket_no == to_reopen)        //This if statement for option 4 lets the user set the ticket status to reopened
                {
                    tempobj.status = "Reopened";
                    Reopened.Add(tempobj);
                    Closed.Remove(tempobj);
                    Closed_count--;
                    i--;
                }
            }
        }
        if (display == 5)               //This if is to allow the user to enter a response to a ticket, after which it will close the ticket
        {
            Console.WriteLine("Please enter an open Ticket number to respond to: ");
            int to_respond = Convert.ToInt32(Console.ReadLine());                       //requests a ticket number the user wishes to respond to
            Console.WriteLine("Please provide your response below, ticket will closed once submitted:");  
            string new_response = Console.ReadLine();                                   //requests the users response to add to the ticket
            int Open_count = Open.Count;
            for (int i = 0; i < Open_count; i++)
            {
                TicketStats tempobj = Open[i];
                if (tempobj.ticket_no == to_respond)                //takes the users ticket number to indentify where to place the repsonse
                {
                    tempobj.response = new_response;                //updates the response with the new input
                    tempobj.status = "Closed";
                    Closed.Add(tempobj);                            //now that the user has added a resposne, the ticket is closed and then below, removed from the open list
                    Open.Remove(tempobj); 
                    Open_count--;
                    i--;
                }
            }
        }
        if (display == 6)
        {
            Console.WriteLine("Printing all tickets:");
            Console.WriteLine("Open tickets: " + Open.Count);
            Console.WriteLine("Closed tickets: " + Closed.Count);  //these 3 lines show the counts for all lists and prints all objects in each list
            Console.WriteLine("Reopened tickets: " + Reopened.Count);
            int Open_count = Open.Count;
            for (int i = 0; i < Open_count; i++)
            {
                Open[i].show_tickets();
            }
            int Closed_count = Closed.Count;
            for (int i = 0; i < Closed_count; i++)
            {
                Closed[i].show_tickets();
            }
            int Reopened_count = Reopened.Count;
            for (int i = 0; i < Reopened_count; i++)
            {
                Reopened[i].show_tickets();
            }
            Console.WriteLine("*********************************************");  //  breaker to help make reading easier for user

    }
    }
Console.WriteLine("Do you want to retain ticket info and return to the start? yes/no");
string option3 = Console.ReadLine();
if (option3 == "yes")               //option allows user to end program or return to start to continue entering or managing tickets
{
    goto codestart; // Returns user to start of program and retains current inputs for ease of testing
}
Console.WriteLine("bye!");

  