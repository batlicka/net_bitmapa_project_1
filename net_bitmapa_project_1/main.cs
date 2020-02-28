using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace net_bitmapa_project_1
{
    class main
    {
        static void Main(string[] args)
        {
            String fileName = "d:\\dokumenty\\dotnet\\obr\\jednoduchy1.bmp";
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            long numBytes = new FileInfo(fileName).Length;
            byte[] buff;
            buff = new byte[(int)numBytes];
            buff = br.ReadBytes((int)numBytes);

            BitMap ArrayPic = new BitMap(buff);
            //vypíše první byte souboru na pozici [0]
            Console.Write(ArrayPic.GiveFirst());

            //FileToByteArray("d:\\dokumenty\\dotnet\\obr\\jednoduchy1.bmp");

            //uvolnění zdrojů
            fs.Close();

        }
    }

}
