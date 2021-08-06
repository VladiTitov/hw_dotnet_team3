using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Motoshop.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class GuidAttribute : Attribute // DataTypeAttribute
    {
        public bool isGuid;
        Guid ID;
    }
}
