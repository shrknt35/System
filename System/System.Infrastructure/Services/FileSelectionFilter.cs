using System.Collections;
using System.Collections.Generic;

namespace System.Infrastructure.Services
{
    public class FileSelectionFilter : ICollection<string>
    {
        private readonly List<string> _extensions;

        public string Title { get; private set; }

        public IEnumerable<string> Extensions { get { return _extensions; } }

        public int Count
        {
            get { return _extensions.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public FileSelectionFilter(string title)
        {
            _extensions = new List<string>();

            Title = title;
        }

        public IEnumerator<string> GetEnumerator()
        {
            return _extensions.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(string item)
        {
            _extensions.Add(item);
        }

        public void Clear()
        {
            _extensions.Clear();
        }

        public bool Contains(string item)
        {
            return _extensions.Contains(item);
        }

        public void CopyTo(string[] array, int arrayIndex)
        {
            _extensions.CopyTo(array, arrayIndex);
        }

        public bool Remove(string item)
        {
            return _extensions.Remove(item);
        }
    }
}