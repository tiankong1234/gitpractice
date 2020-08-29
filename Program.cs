using System;
using System.Net;
using System.Collections.Generic;
using   classes;
namespace cscs
{
    class Program
    {
 
static void Main(string[] args)
{

var account = new BankAccount("<name>", 1000);
Console.WriteLine($"Account {account.Number} was created for {account.Owner} with {account.Balance} initialbalance.");
Console.WriteLine(account.Balance);
account.MakeWithdrawal(500, DateTime.Now, "Rent payment");
Console.WriteLine(account.Balance);
account.MakeDeposit(100, DateTime.Now, "Friend paid me back");
Console.WriteLine(account.Balance);
Console.WriteLine(account.GetAccountHistory());



}
    }
}
