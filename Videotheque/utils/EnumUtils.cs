using System;

namespace Videotheque.utils
{
    class EnumUtils
    {

        public static object GetEnumValueWithString(string value)
        {
            int index = Array.IndexOf(Enum.GetValues(value.GetType()), value);
            return Enum.GetValues(value.GetType()).GetValue(index);
        }
    }
}
