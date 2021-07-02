using System;
using System.Collections.Generic;
using System.Text;

namespace ByteBank.BranchSystem.Extensions {
    public static class ExtensionsList {
        public static void AddSeveral<T>(this List<T> list, params T[] items) {
            foreach (T item in items) {
                list.Add(item);
            }
        }
    }
}
