using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDB
{
    public static class AccountDB
    {
        //School Entity Framework
        private static SchoolDataEntities schoolData = new SchoolDataEntities();

        public static Boolean IsAccessLevel(int? access, int correctAccess)
        {
            bool correct = access == correctAccess ? true : false;
            return correct;
        }

        public static EFAccount GetAccountByName(string userName)
        {
            var accounts = (from account in schoolData.EFAccounts
                           where account.Username == userName
                           select account).Single();

            return accounts;
        }
    }
}
