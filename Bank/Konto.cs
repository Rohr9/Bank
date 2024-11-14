using System;

namespace Bank
{
    public class Konto
    {
        private decimal _balance;
        public Person Owner { get; }

        public Konto(Person owner, decimal initialDeposit)
        {
            if (initialDeposit < 100)
                throw new ArgumentException("Indsæt minimum 100kr.");

            Owner = owner ?? throw new ArgumentNullException(nameof(owner), "Fejl owner");
            _balance = initialDeposit;
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Beløbet skal være større end 0");

            _balance += amount;
            Console.WriteLine(GenerateUpdateMessage());
        }

        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Beløbet skal være større end 0");

            if (amount > _balance)
                throw new InvalidOperationException("Ikke nok på konto");

            _balance -= amount;
            Console.WriteLine(GenerateUpdateMessage());
        }

        public decimal GetBalance()
        {
            return _balance;
        }

        private string GenerateUpdateMessage()
        {
            return $"Din konto er blevet opdateret. Der står nu {_balance:C}";
        }

        public override string ToString()
        {
            return $"Konto Ejer: {Owner.FullName}, Konto: {_balance:C}";
        }
    }
}
