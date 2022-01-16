using System;
using System.Collections.Generic;

namespace Assignment1
{
    internal class Program
    {
        public class Task
        {
            public string name;
            public string description;
            public string deadline;
            public bool isComplete;
            public Task(string taskName, string taskDescription, string taskDeadline)
            {
                name = taskName;
                description = taskDescription;
                deadline = taskDeadline;
                isComplete = false; 
            }

            public void PrintTask()
            {
                string status;
                if (isComplete)
                    status = "complete";
                else
                    status = "incomplete";

                string formattedTask = String.Join(
                Environment.NewLine,
                "\nTask name: " + name,
                "Task description: " + description,
                "Task deadline: " + deadline,
                "Task status: " + status
                );
                Console.WriteLine(formattedTask);
            }
        }
        //Create a new task 
        static void AddTask(Dictionary<String, Task> list)
        {
            string taskName;
            string taskDescription;
            string taskDeadline;
            Console.Write("Enter a task: ");
            taskName = Console.ReadLine();
            Console.Write("Enter task description: ");
            taskDescription = Console.ReadLine();
            Console.Write("Enter task deadline: ");
            taskDeadline = Console.ReadLine();
            list.Add(taskName, new Task(taskName, taskDescription, taskDeadline));
            Console.WriteLine(taskName + " was added");

        }
        //Delete an existing task 
        static void DeleteTask(Dictionary<String, Task> list)
        {
            PrintAll(list);
            string taskName;
            Console.Write("Enter the entire task you want to delete: ");
            taskName = Console.ReadLine();
            if (!list.ContainsKey(taskName))
            {
                Console.WriteLine(taskName + " wasn't found as a task on the list");
                return;
            }
            list.Remove(taskName);
            Console.WriteLine(taskName + " was deleted"); 
        }
        //Edit an existing task 
        static void EditTask(Dictionary<String, Task> list)
        {
            PrintAll(list);
            string taskName;
            string newName;
            string newDescription;
            string newDeadline;
            Console.Write("Enter the entire task you want to edit: ");
            taskName = Console.ReadLine();
            if (!list.ContainsKey(taskName))
            {
                Console.WriteLine(taskName + " wasn't found as a task on the list");
                return;
            }
            Console.Write("Enter what you'd like to change it to (leave blank to keep the same): ");
            newName = Console.ReadLine();
            Console.Write("Enter new task description (leave blank to keep the same): ");
            newDescription = Console.ReadLine();
            Console.Write("Enter task deadline (leave blank to keep the same): ");
            newDeadline = Console.ReadLine();
            if (string.IsNullOrEmpty(newName))
                newName = taskName;
            if (string.IsNullOrEmpty(newDescription))
                newDescription = list[taskName].description;
            if (string.IsNullOrEmpty(newDeadline))
                newDeadline = list[taskName].description;
            list.Remove(taskName);
            list.Add(newName, new Task(newName, newDescription, newDeadline));
            Console.WriteLine(taskName + " was edited"); 
        }
        //Complete a task 
        static void CompleteTask(Dictionary<String, Task> list)
        {
            PrintAll(list);
            string taskName;
            Console.Write("Enter the entire task you want to mark as complete: ");
            taskName = Console.ReadLine();
            if (!list.ContainsKey(taskName))
            {
                Console.WriteLine(taskName + " wasn't found as a task on the list");
                return;
            }
            list[taskName].isComplete = true;
            Console.WriteLine(taskName + " was marked as complete"); 
        }

        //List all outstanding(not complete) tasks 
        static void PrintTodo(Dictionary<String, Task> list)
        {
            Console.WriteLine("\nAll outstanding tasks");
            foreach(KeyValuePair<String, Task> task in list)
            {
                if (!task.Value.isComplete)
                    task.Value.PrintTask();
            }
        }
        //List all tasks
        static void PrintAll(Dictionary<String, Task> list)
        {
            Console.WriteLine("\nAll tasks");
            foreach(KeyValuePair<String, Task> task in list)
            {
                    task.Value.PrintTask();
            }
        }

        static void Main(string[] args)
        { 
            Dictionary<String, Task> todo = new Dictionary<String, Task>();
            char menuChoice;
            // String.join idea from https://stackoverflow.com/a/25177497
            string menuPrompt = String.Join(
                Environment.NewLine,
                "\nTodo List Task Menu",
                "(A)dd task",
                "(D)elete task",
                "(E)dit task",
                "(C)omplete task",
                "(L)ist tasks to do",
                "(S)ee all tasks",
                "(Q)uit");
            do
            {
                Console.WriteLine(menuPrompt);
                menuChoice = Console.ReadLine()[0];
                switch (menuChoice)
                {
                    case 'a':
                    case 'A':
                        AddTask(todo);
                        break;
                    case 'd':
                    case 'D':
                        DeleteTask(todo);
                        break;
                    case 'e':
                    case 'E':
                        EditTask(todo);
                        break;
                    case 'c':
                    case 'C':
                        CompleteTask(todo);
                        break;
                    case 'l':
                    case 'L':
                        PrintTodo(todo);
                        break;
                    case 's':
                    case 'S':
                        PrintAll(todo);
                        break;
                    case 'q':
                    case 'Q':
                        break;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }

            }while(menuChoice != 'q' && menuChoice != 'Q');

        }
    }
}
