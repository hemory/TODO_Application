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
            List<Task> taskList = new List<Task>();


            Console.WriteLine("Welcome to the TODO APP! Add Task or enter (Q) to stop adding items.");

            taskList = AddATask(taskList);



            bool endApplication = false;
            while (endApplication == false)
            {
                DisplayCompleteTaskList(taskList);

                Console.WriteLine();

                Console.WriteLine("How would you like to proceed?");
                Console.WriteLine("(1)Add More Items (2)Remove Items (3)Exit");
                string userMenuChoice = Console.ReadLine().Trim();

                Console.Clear();

                switch (userMenuChoice)
                {
                    case "1":
                        //add logic
                        DisplayCompleteTaskList(taskList);
                        taskList = AddATask(taskList);


                        break;
                    case "2":
                        //remove logic
                        Console.Write("Enter item number to remove: ");
                        DisplayCompleteTaskList(taskList);
                        Console.WriteLine();
                        Console.Write("Remove Item: ");
                        int itemToRemove = int.Parse(Console.ReadLine().Trim());

                        taskList = RemoveAnItem(taskList, itemToRemove);

                        break;
                    case "3":
                        endApplication = true;
                        break;

                    default:
                        Console.WriteLine("Please choose a valid option.");
                        break;

                }
            }


            Console.WriteLine("Press ENTER to close application");

            Console.ReadLine();
        }

        private static List<Task> RemoveAnItem(List<Task> taskList, int itemToRemove)
        {
            Task removedItem = null;

            foreach (var taskItem in taskList)
            {
                if (taskItem.Id == itemToRemove)
                {
                    removedItem = taskItem;
                }
            }

            taskList.Remove(removedItem);

            return taskList;
        }

        private static void DisplayCompleteTaskList(List<Task> taskList)
        {
            Console.Clear();

            Console.WriteLine("Your complete list: ");
            foreach (var item in taskList)
            {
                Console.WriteLine($"{item.Id}: {item.TaskItem}");
            }

        }

        private static List<Task> AddATask(List<Task> taskList)
        {
            //int currentItemNumber = taskList.Count + 1;

            while (true)
            {
                var task = new Task();

                Console.Write($"{task.Id}:  ");
                task.TaskItem = Console.ReadLine();

                if (task.TaskItem != null && task.TaskItem.ToLower() == "q")
                {
                    break;
                }

                taskList.Add(task);

            }

            return taskList;
        }

    }
}
