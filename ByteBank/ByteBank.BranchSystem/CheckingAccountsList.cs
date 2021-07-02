using ByteBank.Accounts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ByteBank.BranchSystem {
    public class CheckingAccountsList {

        private CheckingAccount[] _items;
        private int _nextPosition;

        public int Size {
            get {
                return _nextPosition;
            }
        }

        public CheckingAccountsList(int initialCapacity = 5) {
            _items = new CheckingAccount[initialCapacity];
            _nextPosition = 0;
        }

        public void AddAccount(CheckingAccount item) {

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

            CheckingAccount[] newArray = new CheckingAccount[newSize];

            for (int i = 0; i < _items.Length; i++) {
                newArray[i] = _items[i];
            }

            _items = newArray;

        }

        public void RemoveAccount(CheckingAccount item) {

            int itemIndex = -1;

            for (int i = 0; i < _nextPosition; i++) {
                CheckingAccount currentItem = _items[i];

                if (currentItem.Equals(item)) {
                    itemIndex = i;
                    break;
                }
            }

            for (int i = itemIndex; i < _nextPosition - 1; i++) {
                _items[i] = _items[i + 1];
            }

            _nextPosition--;
            _items[_nextPosition] = null;
        }

        
        public CheckingAccount GetItemInIndex(int index) {
            if (index < 0 || index >= _nextPosition) {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            return _items[index];
        }

        public CheckingAccount this[int index] {
            get {
                return GetItemInIndex(index);
            }
        }

        public void AddSeveral(params CheckingAccount[] items) {
            foreach (CheckingAccount account in items) {
                AddAccount(account);
            }
        }

    }
}
