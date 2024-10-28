namespace Interface.Services
{
    interface IOnlinePaymentService 
        //Interface cria uma espécie de contrato com a classe, nesse caso qualquer classe que possua vínculo com esta interface
        //deve implementar os dois métodos
    {
        public double Interest(double amount, int months);
        public double PaymentFee(double amount);
    }
}
