using Interface.Entities;

namespace Interface.Services
{
    internal class ContractService
    {
        private IOnlinePaymentService _onlinePaymentService;

        public ContractService(IOnlinePaymentService onlinePaymentService)
        {
            _onlinePaymentService = onlinePaymentService;
        }

        public void ProcessContrat(Contract contract, int months)
        {
            double baseValue = contract.TotalValue / months;
            for (int i = 1; i <= months; i++)
            {
                double updateValue = baseValue + _onlinePaymentService.Interest(baseValue, i);
                updateValue = updateValue + _onlinePaymentService.PaymentFee(updateValue);
      
                contract.AddInstallment(new Installment(contract.Date.AddMonths(i), updateValue));
            }
        }
    }
}
