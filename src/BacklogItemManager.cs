using System;
using System.Collections.Generic;
using System.Linq;

namespace BacklogApp.Models
{
    public class BacklogItemManager
    {
        private readonly List<BacklogItem> _items;
        private readonly BacklogItemRepository _repository;

        public BacklogItemManager()
        {
            _items = new List<BacklogItem>();
            _repository = new BacklogItemRepository();
        }

        public void AddItem(string title)
        {
            if (string.IsNullOrEmpty(title))
            {
                Console.WriteLine("Title cannot be empty.");
                return;
            }

            var newItem = new BacklogItem(title);
            _repository.Add(newItem);
            Console.WriteLine($"Added item: {title}");
        }

        public void ViewAllItems()
        {
            if (_repository.Count == 0)
            {
                Console.WriteLine("No backlog items found.");
                return;
            }

            Console.WriteLine("\nBacklog Items:");
            Console.WriteLine("----------------");
            foreach (var item in _repository.GetAll())
            {
                string status = item.Status == Status.Done ? "[Completed]" : "[Pending]";
                Console.WriteLine($"{item.Id}. {status} {item.Title}");
            }
        }

        public void MarkAsCompleted(int index)
        {
            if (index >= 0 && index < _repository.Count)
            {
                var item = _repository.GetById(index + 1); // Adjust for 1-based indexing
                if (item != null)
                {
                    item.Status = Status.Done;
                    _repository.Update(item);
                    Console.WriteLine($"Marked item '{item.Title}' as completed.");
                }
            }
            else
            {
                Console.WriteLine("Invalid item number.");
            }
        }

        public void DeleteItem(int index)
        {
            if (index >= 0 && index < _repository.Count)
            {
                var item = _repository.GetById(index + 1); // Adjust for 1-based indexing
                if (item != null)
                {
                    string title = item.Title;
                    _repository.Delete(index + 1); // Adjust for 1-based indexing
                    Console.WriteLine($"Deleted item: {title}");
                }
            }
            else
            {
                Console.WriteLine("Invalid item number.");
            }
        }
    }
}