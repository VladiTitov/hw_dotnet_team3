using HM15.Task1.Actions;
using HM15.Task1.Validations;
using System;
using System.Reflection;

namespace HM15.Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            PurchaseMotorcycle purchase = new PurchaseMotorcycle("4154 2699-62992373");
            Type purchaseInfo = purchase.GetType();
            foreach (PropertyInfo property in purchaseInfo.GetProperties())
            {
                foreach (Attribute attribute in property.GetCustomAttributes())
                {
                    if (attribute is not CustomCreditCardAttribute creditCardAttribute)
                        continue;
                    if (creditCardAttribute.IsValid(property.GetValue(purchase) as string))
                        Console.WriteLine("Validation succsessful");
                    else
                        Console.WriteLine("Invalid credit card number");
                }
            }
        }
    }
}
