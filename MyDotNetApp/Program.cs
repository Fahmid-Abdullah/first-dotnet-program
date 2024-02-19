using System;
using System.Collections.Generic;

class TaskManager
{
    private List<string> tasks = new List<string>();

    public void AddTask(string task)
    {
        tasks.Add(task);
        Console.WriteLine($"Task '{task}' added successfully.");
    }

    public void CompleteTask(int taskIndex)
    {
        if (taskIndex >= 0 && taskIndex < tasks.Count)
        {
            string completedTask = tasks[taskIndex];
            tasks.RemoveAt(taskIndex);
            Console.WriteLine($"Task '{completedTask}' marked as completed.");
        }
        else
        {
            Console.WriteLine("Invalid task index.");
        }
    }

    public void ViewTasks()
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("No tasks available.");
        }
        else
        {
            Console.WriteLine("Tasks:");
            for (int i = 0; i < tasks.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {tasks[i]}");
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        TaskManager taskManager = new TaskManager();

        while (true)
        {
            Console.WriteLine("\nTask Manager Menu:");
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. Complete Task");
            Console.WriteLine("3. View Tasks");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        Console.Write("Enter task description: ");
                        string newTask = Console.ReadLine();
                        taskManager.AddTask(newTask);
                        break;
                    case 2:
                        Console.Write("Enter task index to mark as completed: ");
                        if (int.TryParse(Console.ReadLine(), out int taskIndexComplete))
                        {
                            taskManager.CompleteTask(taskIndexComplete - 1);
                        }
                        else
                        {
                            Console.WriteLine("Invalid input.");
                        }
                        break;
                    case 3:
                        taskManager.ViewTasks();
                        break;
                    case 4:
                        Console.WriteLine("Exiting Task Manager. Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid choice. Please enter a number.");
            }
        }
    }
}
