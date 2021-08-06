using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Motoshop.Models;

namespace Motoshop.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class MinYearAttribute : Attribute //DataTypeAttribute
    {
        public int ValidYear;

        public MinYearAttribute(int validYear)
        {
            Moto moto = new Moto();
            ValidYear = validYear;
        }

        public void Validate(Moto moto)
        {
            if (moto.MadeIN.Year < ValidYear || moto.MadeIN.Year > DateTime.Now.Year)
            {
                throw new Exception("This is not valid year");
            }
        }
    }
}
