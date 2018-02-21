using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sha2
{
   public class getInitialPadding
    {
       public static byte[] padding;

       public void paddingcopy(byte[] b)
        {
            padding = b.ToArray();
            //Console.WriteLine(BitConverter.ToString(padding));
        }
    }
}
