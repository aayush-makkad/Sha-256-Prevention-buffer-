using System;



    class datacopy
    {

      static byte[] padding;

    void dataCopy(byte[] b)
    {
        padding = b.ToArray();
        Console.WriteLine(BitConverter.ToString(padding));

    }


    }
