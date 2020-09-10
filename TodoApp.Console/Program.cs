using System;
using System.Collections.Generic;
using System.Linq;

namespace TodoApp
{
    internal class Program
    {
        static List<Todo> s_todos = new List<Todo>();

        static void PrintMenu()
        {
            Console.WriteLine("Welcome to your todo app!");
            Console.WriteLine();

            Console.WriteLine("1) Create Todo");
            Console.WriteLine("2) List Todo's");
            Console.WriteLine("3) Delete Todo");
            Console.WriteLine();
            Console.WriteLine("0) Exit Application");
            Console.WriteLine();
            Console.Write("> ");
        }

        private static int DetermineRecordId()
        {
            if (!s_todos.Any())
            {
                return 1;
            }

            return s_todos.Max(x => x.Id) + 1;
        }

        static void Main()
        {
            while (true)
            {
                Console.Clear();
                PrintMenu();
                var input = Console.ReadLine();

                if (!int.TryParse(input, out int menuEntry))
                {
                    continue;
                }

                switch (menuEntry)
                {
                    case 0:
                        Environment.Exit(0);
                        break;
                    case 1:
                        string description;
                        while (true)
                        {
                            Console.Write("Please enter a description: ");
                            description = Console.ReadLine();
                            if(string.IsNullOrWhiteSpace(description))
                            {
                                Console.WriteLine("Description may not be empty.");
                                continue;
                            }

                            break;
                        }
                        var id = DetermineRecordId();
                        var todo = new Todo(id, description);
                        s_todos.Add(todo);
                        Console.Write($"Todo with Id \"{id}\" was added. Press a key to continue.");
                        Console.ReadKey();
                        continue;
                    case 2:
                        if (!s_todos.Any())
                        {
                            Console.WriteLine("No todo entries found. Press a key to continue.");
                            Console.ReadKey();
                            continue;
                        }

                        ListTodos();
                        Console.WriteLine("Press a key to continue.");
                        Console.ReadKey();
                        continue;
                    case 3:
                        if (!s_todos.Any())
                        {
                            Console.WriteLine("No todo entries found. Press a key to continue.");
                            Console.ReadKey();
                            continue;
                        }

                        while (true)
                        {
                            ListTodos();
                            Console.Write("Please enter the Id of the entry to delete (0 to abort): ");
                            var idInput = Console.ReadLine();
                            if (!int.TryParse(idInput, out int entryId))
                            {
                                continue;
                            }

                            if (entryId == 0)
                            {
                                break;
                            }

                            var existingTodo = s_todos.SingleOrDefault(x => x.Id == entryId);

                            if (existingTodo == null)
                            {
                                Console.WriteLine($"Entry with Id \"{entryId}\" was not found.");
                                continue;
                            }

                            s_todos.Remove(existingTodo);
                            Console.Write($"Todo with id \"{entryId}\" deleted. Press a key to continue.");
                            Console.ReadKey();
                            break;
                        }

                        break;
                    default:
                        Console.WriteLine("Invalid menu option. Press a key to continue.");
                        Console.ReadKey();
                        continue;
                }
            }
        }

        private static void ListTodos()
        {
            foreach (var todoEntry in s_todos)
            {
                Console.WriteLine($"Id: {todoEntry.Id} - {todoEntry.Description}");
            }
            Console.WriteLine();
        }
    }
}
