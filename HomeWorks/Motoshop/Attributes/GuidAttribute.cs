using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Motoshop.Models;

namespace Motoshop.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class GuidAttribute : Attribute // DataTypeAttribute
    {
        public Guid DefGuid = Guid.Parse("00000000-0000-0000-0000-000000000000");
        public void Validate(Moto moto)
        {
            if (moto.Id == DefGuid)
            {
                throw new Exception("This is not GUID");
            } 
        }
    }
}
