using System;
using System.Collections.Generic;
using System.Text;

namespace ByteBank.BranchSystem {
    public class Lists<T> {

        private T[] _items;
        private int _nextPosition;

        public int Size {
            get {
                return _nextPosition;
            }
        }

        public Lists(int initialCapacity = 5) {
            _items = new T[initialCapacity];
            _nextPosition = 0;
        }

        public void Add(T item) {

            CheckCapacity(_nextPosition + 1);

            _items[_nextPosition] = item;
            _nextPosition++;
        }

        private void CheckCapacity(int requiredSize) {

            if (_items.Length >= requiredSize) {
                return;
            }

            int newSize = _items.Length * 2;

            if (newSize < requiredSize) {
                newSize = requiredSize;
            }

            T[] newArray = new T[newSize];

            for (int i = 0; i < _items.Length; i++) {
                newArray[i] = _items[i];
            }

            _items = newArray;

        }

        public void Remove(T item) {

            int itemIndex = -1;

            for (int i = 0; i < _nextPosition; i++) {
                T currentItem = _items[i];

                if (currentItem.Equals(item)) {
                    itemIndex = i;
                    break;
                }
            }

            for (int i = itemIndex; i < _nextPosition - 1; i++) {
                _items[i] = _items[i + 1];
            }

            _nextPosition--;
            
        }


        public T GetItemInIndex(int index) {
            if (index < 0 || index >= _nextPosition) {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            return _items[index];
        }

        public T this[int index] {
            get {
                return GetItemInIndex(index);
            }
        }

        public void AddSeveral(params T[] items) {
            foreach (T item in items) {
                Add(item);
            }
        }
    }
}
