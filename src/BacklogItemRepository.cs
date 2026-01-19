using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApp
{
    public class BacklogItemRepository
    {
        private readonly Dictionary<int, BacklogItem> _items;
        private int _nextId = 1;

        public BacklogItemRepository()
        {
            _items = new Dictionary<int, BacklogItem>();
        }

        public int Count => _items.Count;

        public BacklogItem GetById(int id)
        {
            if (_items.TryGetValue(id, out BacklogItem item))
            {
                return item;
            }
            return null;
        }

        public IEnumerable<BacklogItem> GetAll()
        {
            return _items.Values.ToList();
        }

        public BacklogItem Add(BacklogItem item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            if (string.IsNullOrWhiteSpace(item.Title))
                throw new ArgumentException("Title cannot be null or empty.", nameof(item.Title));

            item.Id = _nextId++;
            _items[item.Id] = item;
            return item;
        }

        public bool Update(BacklogItem item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            if (!_items.ContainsKey(item.Id))
                return false;

            if (string.IsNullOrWhiteSpace(item.Title))
                throw new ArgumentException("Title cannot be null or empty.", nameof(item.Title));

            _items[item.Id] = item;
            return true;
        }

        public bool Delete(int id)
        {
            return _items.Remove(id);
        }
    }
}