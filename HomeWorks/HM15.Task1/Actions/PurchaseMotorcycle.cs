using HM15.Task1.Validations;
using System.ComponentModel.DataAnnotations;


namespace HM15.Task1.Actions
{
    class PurchaseMotorcycle
    {
        [Phone]
        public string CreditCardNumber1 { get; set; }
        [CustomCreditCard]
        public string CreditCardNumber { get; set; }
        public string CreditCardNumber2 { get; set; }
        public PurchaseMotorcycle(string number)
        {
            CreditCardNumber1 = "3213213";
            CreditCardNumber = number;
            CreditCardNumber2 = "654985";
        }
    }
}
