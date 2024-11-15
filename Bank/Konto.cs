using System;

namespace Bank
{
    public class Konto
    {
        private decimal _balance;
        public KontoOwner Owner { get; }
        public KontoAdmin Admin { get; }

        public Konto(KontoOwner owner, KontoAdmin admin, decimal initialDeposit)
        {
            if (initialDeposit < 100)
                throw new ArgumentException("Indsæt minimum 100kr");

            Owner = owner ?? throw new ArgumentNullException(nameof(owner), "Fejl owner");
            Admin = admin ?? throw new ArgumentNullException(nameof(admin), "Fejl admin");
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
            return $"Account Owner: {Owner.FullName}, Admin: {Admin.FullName}, Balance: {_balance:C}";
        }
    }
}
