using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Server.repository
{
    internal sealed class AccountRepository
    {
        private static readonly string PATH = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName +
                                              "/repository/Accounts.txt";

        internal readonly Dictionary<string, Account> AllAccounts = new Dictionary<string, Account>();

        internal void GetAccounts()
        {
            //Считывание строк файла
            IEnumerable<string> lines = File.ReadLines(PATH);
            foreach (var line in lines)
            {
                Console.WriteLine("Fetch account: " + line);
                Account account = FromLine(line);
                string name = account.Name;
                AllAccounts.Add(name, account);
            }
        }

        internal static Account FromLine(string line)
        {
            string[] parts = line.Split(' ');
            string name = parts[0];
            uint wins = uint.Parse(parts[1]);
            return new Account(name, wins);
        }

        //Если аккаунт существует, то берем его, если нет, то создаем
        internal Account Fetch(string name)
        {
            if (name.Length == 0)
            {
                return null;
            }

            if (!AllAccounts.ContainsKey(name))
            {
                //Console.WriteLine("CREATE NEW ACCOUNT: " + name);
                Account account = new Account(name, 0);
                AllAccounts.Add(name, account);
                File.AppendAllText(PATH, "/n" + account);
                return account;
            }
            return AllAccounts[name];
        }
        
        internal void AddWin(Account account)
        {
            account.Wins += 1;

            //Обновление файла
            var accounts = AllAccounts.Values;
            IEnumerable<string> lines = accounts.Select(it => it.ToString());
            File.WriteAllLines(PATH, lines);
        }
    }
}