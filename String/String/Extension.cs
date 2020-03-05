using System;
using System.Collections.Generic;
using System.Text;

namespace Exstension
{
   public static class Extension
    {
       public static string UpDown(this string str)
        {
            StringBuilder new_st = new StringBuilder();
            for (int i = 0; i < str.Length; i++)
            {
                if (i % 2 == 0)
                {
                    if (char.IsLower(str[i]))
                    {
                        new_st.Append(char.ToUpper(str[i]));
                    }
                    else
                    {
                        new_st.Append(str[i]);
                    }
                }
                else
                {
                    if (char.IsUpper(str[i]))
                    {
                        new_st.Append(char.ToLower(str[i]));
                    }
                    else
                    {
                        new_st.Append(str[i]);
                    }
                }
            }
            return new_st.ToString();
        }
    }
}
