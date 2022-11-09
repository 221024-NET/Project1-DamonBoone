using System;

namespace Project1
{
    class App
    {
        public static void Main(string[] args)
        {
            //testing connection string
            string connectionString = File.ReadAllText("F:/Revature/Project1/connectionString.txt");
            Console.WriteLine(connectionString);
        }
    }
}

