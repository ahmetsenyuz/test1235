using System;
using System.Collections.Generic;
using System.Text.Json;
using BacklogApp.Models;

namespace TodoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var backlogManager = new BacklogManager();
            bool running = true;

            Console.WriteLine("Welcome to the C# Backlog Manager!");
            Console.WriteLine("==================================");

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
                        backlogManager.ViewAllItems();
                        break;
                    case "2":
                        Console.Write("Enter backlog item title: ");
                        string title = Console.ReadLine();
                        backlogManager.AddItem(title);
                        break;
                    case "3":
                        backlogManager.ViewAllItems();
                        Console.Write("Enter item number to mark as completed: ");
                        if (int.TryParse(Console.ReadLine(), out int completeIndex))
                        {
                            backlogManager.MarkAsCompleted(completeIndex - 1);
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter a valid number.");
                        }
                        break;
                    case "4":
                        backlogManager.ViewAllItems();
                        Console.Write("Enter item number to delete: ");
                        if (int.TryParse(Console.ReadLine(), out int deleteIndex))
                        {
                            backlogManager.DeleteItem(deleteIndex - 1);
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter a valid number.");
                        }
                        break;
                    case "5":
                        running = false;
                        Console.WriteLine("Thank you for using the C# Backlog Manager!");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        public class BacklogItem
        {
            public string Id { get; set; } = Guid.NewGuid().ToString();
            public string Title { get; set; } = string.Empty;
            public Status Status { get; set; } = Status.ToDo;
            public Priority Priority { get; set; } = Priority.Medium;
            public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
            public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

            public BacklogItem(string title)
            {
                Title = title;
            }
        }

        public class BacklogManager
        {
            private List<BacklogItem> _items;
            private int _nextId;

            public BacklogManager()
            {
                _items = new List<BacklogItem>();
                _nextId = 1;
            }

            public void AddItem(string title)
            {
                if (string.IsNullOrWhiteSpace(title))
                {
                    Console.WriteLine("Title cannot be empty.");
                    return;
                }

                var newItem = new BacklogItem(title);
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
                Console.WriteLine("----------------");
                foreach (var item in _items)
                {
                    string status = item.Status == Status.Done ? "[Completed]" : "[Pending]";
                    Console.WriteLine($"{item.Id}. {status} {item.Title}");
                }
            }

            public void MarkAsCompleted(int index)
            {
                if (index >= 0 && index < _items.Count)
                {
                    _items[index].Status = Status.Done;
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
}