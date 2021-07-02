using ByteBank.Accounts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace ByteBank.BranchSystem.Comparators {
    public class CheckingAccountComparatorByBranch : IComparer<CheckingAccount> {

        public int Compare([AllowNull] CheckingAccount x, [AllowNull] CheckingAccount y) {
            
            if(x == y) {
                return 0;
            }

            if(x == null) {
                return 1;
            }

            if (y == null) {
                return -1;
            }

            return x.Branch.CompareTo(y.Branch);

        }
    }
}
