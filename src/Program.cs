using System;
using System.Collections.Generic;

namespace TodoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var todoManager = new TodoManager();
            bool running = true;

            Console.WriteLine("Welcome to the C# To-Do App!");
            Console.WriteLine("==============================");

            while (running)
            {
                Console.WriteLine("\nOptions:");
                Console.WriteLine("1. View all backlog items");
                Console.WriteLine("2. Add a new backlog item");
                Console.WriteLine("3. Mark item as completed");
                Console.WriteLine("4. Delete a backlog item");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option (1-5): ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        todoManager.ViewAllItems();
                        break;
                    case "2":
                        Console.Write("Enter backlog item title: ");
                        string title = Console.ReadLine();
                        todoManager.AddItem(title);
                        break;
                    case "3":
                        todoManager.ViewAllItems();
                        Console.Write("Enter item number to mark as completed: ");
                        if (int.TryParse(Console.ReadLine(), out int completeIndex))
                        {
                            todoManager.MarkAsCompleted(completeIndex - 1);
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter a valid number.");
                        }
                        break;
                    case "4":
                        todoManager.ViewAllItems();
                        Console.Write("Enter item number to delete: ");
                        if (int.TryParse(Console.ReadLine(), out int deleteIndex))
                        {
                            todoManager.DeleteItem(deleteIndex - 1);
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter a valid number.");
                        }
                        break;
                    case "5":
                        running = false;
                        Console.WriteLine("Thank you for using the C# To-Do App!");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
    }

    public class TodoItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsCompleted { get; set; }

        public TodoItem(int id, string title)
        {
            Id = id;
            Title = title;
            IsCompleted = false;
        }
    }

    public class TodoManager
    {
        private List<TodoItem> _items;
        private int _nextId;

        public TodoManager()
        {
            _items = new List<TodoItem>();
            _nextId = 1;
        }

        public void AddItem(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                Console.WriteLine("Title cannot be empty.");
                return;
            }

            var newItem = new TodoItem(_nextId++, title);
            _items.Add(newItem);
            Console.WriteLine($"Added item: {title}");
        }

        public void ViewAllItems()
        {
            if (_items.Count == 0)
            {
                Console.WriteLine("No backlog items found.");
                return;
            }

            Console.WriteLine("\nBacklog Items:");
            Console.WriteLine("--------------");
            foreach (var item in _items)
            {
                string status = item.IsCompleted ? "[Completed]" : "[Pending]";
                Console.WriteLine($"{item.Id}. {status} {item.Title}");
            }
        }

        public void MarkAsCompleted(int index)
        {
            if (index >= 0 && index < _items.Count)
            {
                _items[index].IsCompleted = true;
                Console.WriteLine($"Marked item '{_items[index].Title}' as completed.");
            }
            else
            {
                Console.WriteLine("Invalid item number.");
            }
        }

        public void DeleteItem(int index)
        {
            if (index >= 0 && index < _items.Count)
            {
                string title = _items[index].Title;
                _items.RemoveAt(index);
                Console.WriteLine($"Deleted item: {title}");
            }
            else
            {
                Console.WriteLine("Invalid item number.");
            }
        }
    }
}