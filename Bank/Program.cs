using System.Security.Principal;

namespace Bank
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Velkommen til banken!");

            Console.Write("Indtast kunde-ID (6 cifre): ");
            int customerID = int.Parse(Console.ReadLine());

            Console.Write("Indtast fornavn: ");
            string ownerFirstName = Console.ReadLine();

            Console.Write("Indtast efternavn: ");
            string ownerLastName = Console.ReadLine();

            KontoOwner owner = new KontoOwner(customerID, ownerFirstName, ownerLastName);

            Console.Write("Indtast administratorens medarbejder-ID (6 cifre): ");
            int adminID = int.Parse(Console.ReadLine());

            Console.Write("Indtast administratorens fornavn: ");
            string adminFirstName = Console.ReadLine();

            Console.Write("Indtast administratorens efternavn: ");
            string adminLastName = Console.ReadLine();

            KontoAdmin admin = new KontoAdmin(adminID, adminFirstName, adminLastName);

            Console.Write("Indtast beløb for at oprette en konto (minimum 100 kr): ");
            decimal initialDeposit = decimal.Parse(Console.ReadLine());

            if (initialDeposit < 100)
            {
                Console.WriteLine("Beløbet er for lavt. Konto kan ikke oprettes.");
                return;
            }

            Konto account = new Konto(owner, admin, initialDeposit);

            Console.WriteLine($"Hej {owner.FullName}. Din konto er oprettet med {admin.FullName} som admin!");

            while (true)
            {
                Console.WriteLine("\nVælg en handling:");
                Console.WriteLine("1. Indsæt penge");
                Console.WriteLine("2. Træk penge");
                Console.WriteLine("3. Vis saldo");
                Console.WriteLine("4. Afslut");

                Console.Write("Indtast dit valg: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Indtast beløb til indsætning: ");
                        decimal depositAmount = decimal.Parse(Console.ReadLine());
                        account.Deposit(depositAmount);
                        break;

                    case "2":
                        Console.Write("Indtast beløb til udtrækning: ");
                        decimal withdrawAmount = decimal.Parse(Console.ReadLine());
                        try
                        {
                            account.Withdraw(withdrawAmount);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Fejl: {ex.Message}");
                        }
                        break;

                    case "3":
                        Console.WriteLine($"Din saldo er: {account.GetBalance():C}");
                        break;

                    case "4":
                        Console.WriteLine("Afslutter");
                        return;

                    default:
                        Console.WriteLine("Ugyldigt valg. Prøv igen.");
                        break;
                }
            }
        }
    }
}

