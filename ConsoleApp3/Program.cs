// See https://aka.ms/new-console-template for more information

using System;
class Account
{
    private string name;
    private int accountNumber;
    private decimal balance;
    private List<decimal> Transactions;

    public Account(string name, int accountNumber, decimal initbalance)
    {
        this.name = name;
        this.accountNumber = accountNumber;
        this.balance = initbalance;
        this.Transactions = new List<decimal>();
    }
   public void Deposit(decimal amount)
    {
        balance += amount;
        Console.WriteLine($"Deposited {amount:N2}. New balance {balance:N2}");
        Transactions.Add(+amount);

    }
    public void Withdraw(decimal amount)
    {
        if (amount <= balance)
        {
            balance -= amount;
            Console.WriteLine($"Withdraaw {amount:N2}. New balance {balance:N2}");
            Transactions.Add(-amount);
        }
        else
        {
            Console.WriteLine("insufficient.");
        }
    }
    public decimal GetBalance() 
    {
        return balance; 
    }
    public void ListTransaction()
    {
        Console.WriteLine("List transaction: ");
        foreach (var transaction in Transactions)
        {
            Console.WriteLine(transaction >= 0 ? $"deposit {transaction:N2} KWD": $"Withdraw {(-transaction):N2}KWD");
        }
    }
}
class Bank
{
    static void Main(string[] args)
    {
        Console.WriteLine("WELCOME TO BANKING APP!");
        Console.WriteLine("------------------------------");
        Console.WriteLine("enter your name:");
        string name = Console.ReadLine();
        Console.WriteLine("enter your account number");
        int accountNumber = int.Parse(Console.ReadLine());
        Console.WriteLine("enter your balance:");
        decimal balance = decimal.Parse(Console.ReadLine());
        Account account = new Account(name, accountNumber, balance);
        Console.WriteLine("Account setup successful!");



        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("Main Menu:");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. View Balance");
            Console.WriteLine("4. List Transaction");
            Console.WriteLine("5. Exit");
            Console.WriteLine("Please select an option: ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.WriteLine(" Deposit selected. ");
                    Console.Write(" enter deposit amount: ");
                    decimal depositAmount = decimal.Parse(Console.ReadLine());
                    account.Deposit(depositAmount);
                    break;
                

                case "2":
                    Console.WriteLine(" withdraw selected. ");
                    Console.Write("enter withdrow amount: ");
                    decimal withdrawAmount = decimal.Parse(Console.ReadLine());
                    account.Withdraw(withdrawAmount);
                    break;
                
                case "3":

                    Console.WriteLine($" Your Balance: {balance:N2} KWD");
                    break;
                case "4":
                    account.ListTransaction();
                    break;
                case "5":
                    Console.WriteLine("exit the service number. ");
                    exit = true;
                    break;
                default:

                    Console.WriteLine("invalid choice. ");
                    break;
            }
        }
    }
}

