using System;
using System.Collections;
using System.IO;

namespace net_bitmapa_project_1
{
    class BitMap
    {

        //puvodni inicializace a nacteni souboru
        public static String fileName = "d:\\dokumenty\\dotnet\\obr\\jednoduchy1.bmp";
        FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
        //stream.Close(); ukonceni
        //tmp
        public BitMap(Stream stream)
        {
            streamBits = new BinaryReader(stream);
            long numBytes = new FileInfo(fileName).Length;            
            buff = new byte[(int)numBytes];
            buff = streamBits.ReadBytes((int)numBytes);
            //streamBits.Close; ukoncení
        }

        public BinaryReader streamBits;
        public byte[] buff;

        public short BM_Type { get; private set; } //2B-bfType
        public int BM_Size { get; private set; } //4B-bfSize
        //2B nic
        //2B nic
        public int BM_Offset { get; private set; } //4B-bfOffBits

        public int BM_NumberOfBit { get; private set; } //4B-biSize
        public int BM_Height { get; private set; } //4B-biWidth
        public int BM_Width { get; private set; }  //4B-biHeight
        public int BM_Planes { get; private set; } //2B-biPlanes
        public int BM_BitsPerPixel { get; private set; }   //2B-biBitCount
        public int BM_Compression { get; private set; }    //4B-biCompression (neřešíme)
        public int BM_ByteSizeToCom { get; private set; }    //4B-biSizeImage (asi nepotřebujeme)
        public int BM_XOutPerMeter { get; private set; }    //4B-biXPelsPerMeter
        public int BM_YOutPerMeter { get; private set; }    //4B-biYPelsPerMeter
        public int BM_ByteColorUsed { get; private set; }    //4B-biClrUsed
        public int BM_NeededByteToColor { get; private set; }    //4B-biClrImportant

    }



}



/*
 * 
 * https://www.root.cz/clanky/graficky-format-bmp-pouzivany-a-pritom-neoblibeny/
 * 
 * Hlavička souboru BMP
 * 2B (bfType) Identifikátor formátu BMP.
 * 4B (bfSize) Celková velikost souboru s obrazovými údaji.
 * 2B (bfReserved1) nic
 * 2B (bfReserved2) nic
 * 4B (bfOffBits) Posun dat od začátku souboru k datům.
 * 
 * Metainformace o uloženém rastrovém obrazu
 * 4B (biSize) Velikost datové struktury.
 * 4B (biWidth) šířka v pixelech
 * 4B (biHeight) výška n pixelech
 * 2B (biPlanes) Bitové hladiny téměř vždy 1
 * 2B (biBitCount) Počet bitů na pixel (podle barev).
 * 4B (biCompression) neřešíme
 * 4B (biSizeImage) Velikost obrazu v B, položka je nulová, pokud není použitá žádná komprese
 * 4B (biXPelsPerMeter) Udává horizontální rozlišení výstupního zařízení v pixelech na metr, většinou 0
 * 4B (biYPelsPerMeter) Udává vertikální rozlišení výstupního zařízení v pixelech na metr většinou 0
 * 4B (biClrUsed) Celkový počet barev použitých v bitmapě, pokud je 0 jsou použité všechny, protože počet barev lze zjistit z biSize
 * 4B (biClrImportant) Počet barev potřebný pro vykreslení obrázku, většinou bývá 0, protože všechny barvy jsou potřebné, využíváno u zařízení s barevným omezení
 * 
 * Barvová paleta
 * 4B na jeden bit obrazku na jednu barvu RGB model, ve struktuře je poskládaný jako BGR -> B-Blue 1B, G-Green 1B, R-Red 1B, poslední B je vždy nulový, možná byl vyhrazen pro alfa kanál
 * 1bit bmp má barevnou paletu 4B, 2bit má 8B, 4bit má 16B, 8bit má 32B a 24bit má 96B velikost barevné palety
 * 
 * 
 */


//naprogramovat načtení bytů pomocí streamu a provést jednotkový test na otestování funkčnosti na pole, použit na malou bitmapu třeba 4x4

