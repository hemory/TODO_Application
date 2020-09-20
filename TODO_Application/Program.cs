using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TODO_Application
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Task> taskList = new List<Task>();

            string welcomeString = "Welcome to the TODO APP!";

            PrintOutMessageLetterByLetter(welcomeString);
            Console.Clear();

            Console.WriteLine("Add Task or enter (Q) to stop adding items...");

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
                        DisplayTaskListForRemoval(taskList);
                        Console.WriteLine();
                        Console.Write("Remove Task #: ");
                        int itemToRemove = int.Parse(Console.ReadLine().Trim());

                        taskList = CompleteATask(taskList, itemToRemove);

                        break;
                    case "3":
                        endApplication = true;
                        break;

                    case "4":
                        //todo edit logic
                        break;

                    default:
                        Console.WriteLine("Please choose a valid option.");
                        break;

                }
            }

            string textPath = @"C:\Users\hphif\source\repos\TODO_Application\TODO_Application\TasksData.txt";
            WriteToFile(textPath,taskList);
            

            Console.WriteLine("Press ENTER to close application");
            
            Console.ReadLine();
        }

        private static void WriteToFile(string textPath, List<Task> collection)
        {
            using (StreamWriter sw = new StreamWriter(textPath))
            {
                foreach (var item in collection)
                {
                    sw.WriteLine($"{item.Id},{item.TaskItem}");
                }
            }
        }

        private static void PrintOutMessageLetterByLetter(string message)
        {
            
            foreach (var letter in message)
            {
                Thread.Sleep(100);
                Console.Write(letter);
            }

            Console.WriteLine();
        }

        private static List<Task> CompleteATask(List<Task> taskList, int taskToRemove)
        {
            Task completedTask = null;

            foreach (var taskItem in taskList)
            {
                if (taskItem.Id == taskToRemove)
                {
                    completedTask = taskItem;
                }
            }

            taskList.Remove(completedTask);

            return taskList;
        }

        private static void DisplayCompleteTaskList(List<Task> taskList)
        {
            Console.Clear();

            Console.WriteLine("Your complete list: ");
            foreach (var item in taskList)
            {
                Console.WriteLine($"[] {item.TaskItem}");
            }

        }

        private static void DisplayTaskListForRemoval(List<Task> taskList)
        {
            Console.Clear();
            foreach (var item in taskList)
            {
                Console.WriteLine($"{item.Id}: {item.TaskItem}");
            }

        }

        private static List<Task> AddATask(List<Task> taskList)
        {
            while (true)
            {
                var task = new Task();

                Console.Write("[] ");
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
