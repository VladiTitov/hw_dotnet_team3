using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_15_3
{
    public class PurchaseMotorcycle
    {
        Guid _id;
        const string PaymentType = "Card";
        public Guid Id { get { return _id; } }
        [CreditCard()]
        public string CardNumber { get; set; }
        public string CardType { get; set; }

        [Obsolete("Soon this method will be removed!", false)]
        public void MethodForTask3()
        {
        }
        public PurchaseMotorcycle()
        {
            _id = Guid.NewGuid();
        }
        public override string ToString()
        {
            return $"Payment Type = {PaymentType}; CardId = {Id}; Card Type = {CardType}";
        }
    }
}
