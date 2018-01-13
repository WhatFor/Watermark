using System;
using System.Reflection;

namespace Watermark
{
    [AttributeUsage(AttributeTargets.Field)]
    public class CountryAttribute : Attribute
    {
        private string country;

        public CountryAttribute(string country)
        {
            this.country = country;
        }

        public static string Get(Type tp, string name)
        {
            MemberInfo[] mi = tp.GetMember(name);

            if (mi != null && mi.Length > 0)
            {
                CountryAttribute attr = GetCustomAttribute(mi[0],
                    typeof(CountryAttribute)) as CountryAttribute;
                if (attr != null)
                {
                    return attr.country;
                }
            }
            return null;
        }
        public static string Get(object enm)
        {
            if (enm != null)
            {
                MemberInfo[] mi = enm.GetType().GetMember(enm.ToString());

                if (mi != null && mi.Length > 0)
                {
                    CountryAttribute attr = GetCustomAttribute(mi[0],
                        typeof(CountryAttribute)) as CountryAttribute;
                    if (attr != null)
                    {
                        return attr.country;
                    }
                }
            }
            return null;
        }
    }
}