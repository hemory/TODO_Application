using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TODO_Application
{
    class Program
    {
        static void Main(string[] args)
        {
            Task task = null;

            List<Task> taskList = new List<Task>();


            Console.WriteLine("Welcome to the TODO APP! Add Task or enter (Q) to exit application.");

            int incrementer = 1;

            while (true)
            {
                task = new Task {TaskNumber = incrementer};

                Console.Write($"{task.TaskNumber}:  ");
                task.TaskItem = Console.ReadLine();

                if (task.TaskItem != null && task.TaskItem.ToLower() == "q")
                {
                    break;
                }

                taskList.Add(task);

                incrementer++;




            }

            Console.Clear();

            Console.WriteLine("Your complete list: ");
            foreach (var item in taskList)
            {
                Console.WriteLine($"{item.TaskNumber}: {item.TaskItem}");
            }


            Console.ReadLine();
        }
    }
}
