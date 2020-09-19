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

            DisplayCompleteTaskList(taskList);

            Console.WriteLine("How would you like to proceed?");
            Console.WriteLine("(1)Add More Items (2)Remove Items");
            string userMenuChoice = Console.ReadLine().Trim();

            Console.Clear();

            switch (userMenuChoice)
            {
                case "1":
                    //add logic
                    taskList = AddATask(taskList);
                    DisplayCompleteTaskList(taskList);

                    break;
                case "2":
                    //remove logic
                    Console.Write("Enter item number to remove: ");
                    int itemToRemove = int.Parse(Console.ReadLine().Trim());

                    foreach (var taskItem in taskList)
                    {
                        if (taskItem.TaskNumber == itemToRemove)
                        {
                            taskList.Remove(taskItem);
                        }
                    }
                    break;
            }


            Console.ReadLine();
        }

        private static void DisplayCompleteTaskList(List<Task> taskList)
        {
            Console.Clear();

            Console.WriteLine("Your complete list: ");
            foreach (var item in taskList)
            {
                Console.WriteLine($"{item.TaskNumber}: {item.TaskItem}");
            }

            Console.WriteLine();
        }

        private static List<Task> AddATask(List<Task> taskList)
        {
            int currentItemNumber = taskList.Count + 1;

            while (true)
            {
                var task = new Task { TaskNumber = currentItemNumber };

                Console.Write($"{task.TaskNumber}:  ");
                task.TaskItem = Console.ReadLine();

                if (task.TaskItem != null && task.TaskItem.ToLower() == "q")
                {
                    break;
                }

                taskList.Add(task);

                currentItemNumber++;
            }

            return taskList;
        }
    }
}
