using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace yogaAshram.Services
{
    public class GetEnumDescription
    {
        public static string GetDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes = fi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

            if (attributes != null && attributes.Any())
            {
                return attributes.First().Description;
            }
            
            
            return value.ToString();
        }
        
    }
}