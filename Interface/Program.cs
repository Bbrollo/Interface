using System.Globalization;
using System.Net.WebSockets;
using Interface.Entities;
using Interface.Services;

namespace Interface
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter contract data: ");
                Console.Write("Contract number: ");
                int number = int.Parse(Console.ReadLine());
                Console.Write("Date: (dd/mm/yyyy): ");
                //ParseExact requer que o formato seja exatamente como especificado dd/MM/yyyy
                DateTime date = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                Console.Write("Contract value: ");
                double totalValue = double.Parse(Console.ReadLine());

                Contract contract = new Contract(number, date, totalValue);

                Console.Write("Number of installments: ");
                int months = int.Parse(Console.ReadLine());

                ContractService contractService = new ContractService(new PaypalService());
                contractService.ProcessContrat(contract, months);

                foreach (Installment installment in contract.Installments)
                {
                    Console.WriteLine(installment);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
