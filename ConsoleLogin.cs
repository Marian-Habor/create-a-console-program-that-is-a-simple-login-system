using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{

    static void Main(string[] args)
    {
        var UsersArray = new Users[] // pre exsting registred users
        {
           new Users("myuser","mypass"),
            new Users("myusertwo","mypasstwo"),
            new Users("myuserthree","mypassthree")
        };

    Start:
        Console.WriteLine("to login select 1 to register select 2"); // begining of app user can select to login or register
        var input = Console.ReadLine();



        bool successfull = false; // assgning the falue false
        while (!successfull)
        {

            if (input == "1") // if user sellected to login
            {
                Console.WriteLine("Your username:"); // we ask for his credentials
                var username = Console.ReadLine();
                Console.WriteLine("Your password:");
                var password = Console.ReadLine();


                foreach (Users user in UsersArray) // for each register user we will try to authenticate them
                {
                    if (username == user.username && password == user.password) // if username ans passworld exist
                    {

                        Console.WriteLine("\nHi {0} You have successfully logged in !!!", username);
                    Logedin:
                        Console.WriteLine("Welcome to users dashboard\n");


                        Console.WriteLine("To logout select 1 to prin your user credentials select 2"); // we ask user if he wants to logout or see his account credentials
                        var logout = Console.ReadLine();

                        if (logout == "1") // if he selcts 1 we logging him out
                        {
                            Console.WriteLine("You have successfully logged out");
                            goto Start;

                        }
                        if (logout == "2") // if he wants to see his credentials
                        {
                            Console.WriteLine("Your user credentials are \n");
                            Console.WriteLine(" Username {0} \n Passworld {1}\n", username, password);
                            goto Logedin; // we redirect back to users dashboard
                        }

                        successfull = true;
                        break;
                    }
                }

                if (!successfull) // if credentials dont match
                {
                    Console.WriteLine("Your username or password is incorect, try again !!!");
                }

            }

            if (input == "2") // if he wants to register 
            {

                Console.WriteLine("Enter your username:"); // we ask to provide username and passworld
                var username = Console.ReadLine();

                Console.WriteLine("\nEnter your password:");
                var password = Console.ReadLine();

                foreach (Users user in UsersArray) // if username all ready exist, and we redirect him back to login and register
                {
                    if (username == user.username)
                    {
                        Console.WriteLine("This user all ready exist \n please try again");
                        goto Start;
                    }
                }

                Array.Resize(ref UsersArray, UsersArray.Length + 1); // we save his credentials
                UsersArray[UsersArray.Length - 1] = new Users(username, password);
                successfull = true;

                Console.WriteLine("\nYou have successfully registered\n"); // and then redirect back to login and register
                goto Start;

            }
            

        }


    }
}

public class Users // the method to store usernames and passwords in cache memory
{
    public string username;
    public string password;


    public Users(string username, string password)
    {
        this.username = username;
        this.password = password;

    }
}