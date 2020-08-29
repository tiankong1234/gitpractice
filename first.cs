using System;
using System.Collections.Generic;
namespace classes
{
public class BankAccount
{
private static int accountNumberSeed = 1234567890;
public string Number { get; }
public string Owner { get; set; }
public decimal Balance
{
get
{
decimal balance = 0;
foreach (var item in allTransactions)
{
balance += item.Amount;
}
return balance;
}
}
private List<Transaction> allTransactions = new List<Transaction>();
public BankAccount(string name, decimal initialBalance)
{
this.Owner = name;

this.Number = accountNumberSeed.ToString();
accountNumberSeed++;
MakeDeposit(initialBalance, DateTime.Now, "Initial balance");
}
public string GetAccountHistory()
{
var report = new System.Text.StringBuilder();
decimal balance = 0;
report.AppendLine("Date\t\tAmount\tBalance\tNote");
foreach (var item in allTransactions)
{
balance += item.Amount;
report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{balance}\t{item.Notes}");
}
return report.ToString();
}
public void MakeDeposit(decimal amount, DateTime date, string note)
{
if (amount <= 0)
{
throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
}
var deposit = new Transaction(amount, date, note);
allTransactions.Add(deposit);
}
public void MakeWithdrawal(decimal amount, DateTime date, string note)
{
if (amount <= 0)
{
throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
}
if (Balance - amount < 0)
{
throw new InvalidOperationException("Not sufficient funds for this withdrawal");
}
var withdrawal = new Transaction(-amount, date, note);
allTransactions.Add(withdrawal);
}
}
public class Transaction
{
public decimal Amount { get; }
public DateTime Date { get; }
public string Notes { get; }
public Transaction(decimal amount, DateTime date, string note)
{
this.Amount = amount;
this.Date = date;
this.Notes = note;
}
}
}
