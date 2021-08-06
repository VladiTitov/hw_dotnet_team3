using System;
using System.Linq;
using System.Reflection;

namespace HW_15_3
{
    class Program
    {
        static void Main(string[] args)
        {
            // Засетать приватное Поле и Свойство используя Рефлексию
            Type purchase1 = typeof(PurchaseMotorcycle);
            ConstructorInfo ctor = purchase1.GetTypeInfo().DeclaredConstructors.Single();

            Object[] parameters = new Object[0];
            object obj = ctor.Invoke(parameters);
            Console.WriteLine($"Created Object is {obj.GetType().Name}");

            FieldInfo fieldInfo = obj.GetType().GetTypeInfo().GetDeclaredField("_id");
            fieldInfo.SetValue(obj, Guid.NewGuid());
            Console.WriteLine(obj.ToString());

            PropertyInfo propertyInfo = obj.GetType().GetTypeInfo().GetDeclaredProperty("CardType");
            propertyInfo.SetValue(obj, "Visa");
            Console.WriteLine(obj.ToString());

            // Константа через Рефлексию - судя по всему нельзя, на то она и константа - System.FieldAccessException: 'Cannot set a constant field.'
            FieldInfo fieldInfoConst = obj.GetType().GetTypeInfo().GetDeclaredField("PaymentType");
            fieldInfoConst.SetValue(obj, "cash");
            Console.WriteLine(obj.ToString());

            // изменить текст  атрибута Obsolete на "Soon this method will NOT be removed!" 
            // (через Property нельзя, т.к. у свойства "Message" нет метода set: System.ArgumentException: 'Property set method not found.'
            PurchaseMotorcycle purchase2 = new PurchaseMotorcycle();
            purchase2.MethodForTask3();

            PropertyInfo propertyInfoAttr = purchase2.GetType().GetTypeInfo().GetDeclaredMethod("MethodForTask3").GetCustomAttributes().Single().GetType().GetTypeInfo().GetDeclaredProperty("Message");
            propertyInfoAttr.SetValue(purchase2, "Soon this method will NOT be removed!");
            Console.WriteLine(propertyInfoAttr);
        }
    }
}
