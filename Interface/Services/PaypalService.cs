namespace Interface.Services
{
    internal class PaypalService : IOnlinePaymentService 
    {
        private const double MonthlyInterest = 0.01;
        private const double FeePercentage = 0.02;
        //os dois métodos da interface implementados
        public double Interest(double amount, int months)
        {
            return amount * MonthlyInterest * months;
        }
        public double PaymentFee(double amount)
        {
            return amount * FeePercentage;
        }
    }
}
