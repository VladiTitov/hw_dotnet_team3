using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Motoshop.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class MinYearAttribute : Attribute //DataTypeAttribute
    {
        int ValidYear;
        //public MinYearAttribute(int valid)
       // {
            //ValidYear = valid;
       // }
    }
}
