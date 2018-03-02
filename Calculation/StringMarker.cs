using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculation
{
    class StringMarker
    {
        public static string marker = "STRING";
        public static void Marking(string rawText, Dictionary<int,string> markToken)
        {
            
            bool inStr = false;
            for (int i = 0; i < rawText.Length; i++)
            {
                if (rawText[i] == '"')
                {

                    if (i > 0 && rawText[i - 1] == '\\')
                    {
                        markToken[i] = marker;
                        continue;
                    }

                    inStr = !inStr;
                }
                markToken[i] = inStr ? marker : "";
            }
        }
       
    }
}
