/*
 * Copyright (c) 2010 Yuri K. Schlesner
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */

using System.Collections.ObjectModel;
using System.IO;
using Sha2;
using System;
using System.Threading;

namespace Sha2Test
{
    class Program
    {
       static  byte[] send;
        static void Main(string[] args)
        {
            string s;
           
            FileStream fs =  new FileStream(@"C:\Users\aayum\Source\Repos\SHA2-Csharp\creation.txt",FileMode.Open,FileAccess.Read);
            ReadOnlyCollection<byte> hash = Sha256.HashFile(fs);
            long len = fs.Length;
            System.Console.WriteLine("length : {0}",fs.Length);
            fs.Close();
            byte[] buff = new byte[len];
            using (BinaryReader reader = new BinaryReader(new FileStream(@"C:\Users\aayum\Source\Repos\SHA2-Csharp\creation.txt", FileMode.Open)))
            {
                reader.BaseStream.Seek(0, SeekOrigin.Begin);
                reader.Read(buff, 0, (int)len);
            }
            foreach(byte t in buff)
            {
                System.Console.WriteLine(t);
            }


            System.Console.Out.WriteLine("{0}", Util.ArrayToString(hash));
            byte[] initialDump = File.ReadAllBytes(@"C:\Users\aayum\Source\Repos\SHA2-Csharp\creation.txt");
            foreach(byte m in initialDump)
            {
                System.Console.WriteLine(m);
            }

            System.Console.WriteLine("Initial dump ends here!!!");

            //   System.Console.WriteLine(BitConverter.ToString(send));
            //byte buffer = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };
            var buffer = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20,0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20,
                                      0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20,
                                      0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20,0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20

                                    };


            //   AppendAllBytes(@"C:\Users\aayum\Source\Repos\SHA2-Csharp\test.txt",buffer);
            //   using(StreamWriter sw = File.AppendText(@"C:\Users\aayum\Source\Repos\SHA2-Csharp\test.txt"))
            //    {
            //  sw.WriteLine("extra boyyyy!!!");

            //}
            //getInitialPadding n = new Sha2.getInitialPadding();
            int[] l = new int[2];
            l[0] = (int)len / 100;
            l[1] = (int)len % 100;
            buffer[63] = (byte)l[1];
            buffer[62] = (byte)l[0];

            byte[] x = new byte[512];
           x = getInitialPadding.padding;
            Array.Resize(ref x, getInitialPadding.padding.Length);
            byte[] final = new byte[1024];
            x.CopyTo(final, 0);
            buffer.CopyTo(final, x.Length);
            int i = x.Length + buffer.Length;
            Array.Resize(ref final, x.Length + buffer.Length);
            System.Console.WriteLine(BitConverter.ToString(x));
            System.Console.WriteLine(BitConverter.ToString(final));

            byte[] y = new byte[] { 0x1 };
            AppendAllBytes(@"C:\Users\aayum\Source\Repos\SHA2-Csharp\creation.txt", y);
            AppendAllBytes(@"C:\Users\aayum\Source\Repos\SHA2-Csharp\creation.txt", final);
            System.Console.WriteLine("Appending done");
           
            byte[] dump = File.ReadAllBytes(@"C:\Users\aayum\Source\Repos\SHA2-Csharp\creation.txt");
            foreach(byte c in dump)
            {
                System.Console.WriteLine(c);
            }
            //System.Console.WriteLine(BitConverter.ToString(x));
            //FileStream fs2 = new FileStream(@"C:\Users\aayum\Source\Repos\SHA2-Csharp\test.txt", FileMode.Open, FileAccess.Read);
            //ReadOnlyCollection<byte> hash2 = Sha256.HashFile(fs);
            //fs.Close();



            //System.Console.Out.WriteLine("{0}", Util.ArrayToString(hash2));
            //byte[] x2 = new byte[512];
            //x2 = getInitialPadding.padding;
            //Array.Resize(ref x, getInitialPadding.padding.Length);

            //System.Console.WriteLine(BitConverter.ToString(x2));
            System.Console.Read();
        }
        public static void AppendAllBytes(string path, byte[] bytes)
{
    //argument-checking here.

    using (var stream = new FileStream(path, FileMode.Append))
    {
        stream.Write(bytes, 0, bytes.Length);
    }
}

     


    }
}
