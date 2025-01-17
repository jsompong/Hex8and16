using System;
using CsvHelper;
using System.Globalization;
using static System.Console;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Collections;

namespace WFAnet
   
{
    
    public partial class Form1 : Form
    {
        public Form1()
        {
         //    public static string ReadAllText(string path);
        InitializeComponent();
            
       
        }
        static byte[] HexStringToByteArray(string hex)
        {
            int length = hex.Length;
            byte[] bytes = new byte[length / 2];
            for (int i = 0; i < length; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            }
            return bytes;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Define a 16-bit hexadecimal array                //  waveformsTable   // Sin wave
            ushort[] hexArray = new ushort[]
            {
            0x7ff, 0x86a, 0x8d5, 0x93f, 0x9a9, 0xa11, 0xa78, 0xadd, 0xb40, 0xba1,
            0xbff, 0xc5a, 0xcb2, 0xd08, 0xd59, 0xda7, 0xdf1, 0xe36, 0xe77, 0xeb4,
        0xeec, 0xf1f, 0xf4d, 0xf77, 0xf9a, 0xfb9, 0xfd2, 0xfe5, 0xff3, 0xffc,
        0xfff, 0xffc, 0xff3, 0xfe5, 0xfd2, 0xfb9, 0xf9a, 0xf77, 0xf4d, 0xf1f,
        0xeec, 0xeb4, 0xe77, 0xe36, 0xdf1, 0xda7, 0xd59, 0xd08, 0xcb2, 0xc5a,
        0xbff, 0xba1, 0xb40, 0xadd, 0xa78, 0xa11, 0x9a9, 0x93f, 0x8d5, 0x86a,
        0x7ff, 0x794, 0x729, 0x6bf, 0x655, 0x5ed, 0x586, 0x521, 0x4be, 0x45d,
        0x3ff, 0x3a4, 0x34c, 0x2f6, 0x2a5, 0x257, 0x20d, 0x1c8, 0x187, 0x14a,
        0x112, 0xdf, 0xb1, 0x87, 0x64, 0x45, 0x2c, 0x19, 0xb, 0x2,
        0x0, 0x2, 0xb, 0x19, 0x2c, 0x45, 0x64, 0x87, 0xb1, 0xdf,
        0x112, 0x14a, 0x187, 0x1c8, 0x20d, 0x257, 0x2a5, 0x2f6, 0x34c, 0x3a4,
        0x3ff, 0x45d, 0x4be, 0x521, 0x586, 0x5ed, 0x655, 0x6bf, 0x729, 0x794
            };

            // Print the array elements
            foreach (ushort hexValue in hexArray)
            {
              //  MessageBox.Show($"0x{hexValue:X4}");
                S16blistBox.Items.Add($"0x{hexValue:X4}");
            }
          
            int itemCount = S16blistBox.Items.Count;                  // Count the items
          //  Console.WriteLine($"Total items: {itemCount}");
            for (int i = 0; i < itemCount; i++)
            { 
                string HjexValue = S16blistBox.Items[i].ToString();
                int decimaValue = Convert.ToInt32(HjexValue, 16);
                S16bDEClistBox.Items.Add(decimaValue);
            }
          
            /* string hexString = "4A6F686E"; // Example hex string
            byte[] byteArray = HexStringToByteArray(hexString);
            MessageBox.Show("Byte Array:");
            foreach (byte b in byteArray)
            {
                MessageBox.Show(b + " ");
            }               */

                string HexValue = S16blistBox.Items[0].ToString();
                int decimalValue = Convert.ToInt32(HexValue, 16);
            // Console.WriteLine($"The decimal value of 0x{hexValue} is {decimalValue}");
            MessageBox.Show($"The decimal value of  {HexValue} is {decimalValue}");

            // var fs = new FileStream(@"D:\WFAnet\bin\Debug\sinewaveHEX.csv", FileMode.Open);
            var fs = new FileStream(@"D:\WFAnet\bin\Debug\sinewaveHEX1.csv", FileMode.Open);
            var xreader = new StreamReader(fs);
            while (!xreader.EndOfStream)
            {
                var line = xreader.ReadLine();
              //  WriteLine(line?.ToUpperInvariant());
                string hexdecim = line?.ToUpperInvariant();
             //   MessageBox.Show(hexdecim);                  // แสดง เป็น กลุ่ม
            }
            xreader.Close();

            //  จาก data :  อ่าน ฐาน 16 เป็น ฐาน 10            // Install-Package CsvHelper
           //  var reader = new StreamReader("sinewaveHEX.csv");
            var reader = new StreamReader("sinewaveHEX1.csv");

            var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            var records = csv.GetRecords<dynamic>();                         // read CSV file
                                                                             // output
            foreach (var r in records)
            {
                //WriteLine($"{r.FirstName,-15}{r.LastName,-10}{r.JoinedDate,15}{r.Salary,15}{r.Active,5}");
                //WriteLine($"{r.HexValue,-15}");
                //string hexdecim = $"{r.HexValue,-15}";
                //   string hexdecim = $"{r.HexCol1}{r.HexCol2}{r.HexCol3}{r.HexCol4}";
                string hexdecim = $"{r.HexColumn}";
                //MessageBox.Show(hexdecim);
                HEXlistBox.Items.Add(hexdecim);
                int decValue = int.Parse(hexdecim, System.Globalization.NumberStyles.HexNumber);
                string decim = Convert.ToString(decValue);
                //  MessageBox.Show(decim);
                DEClistBox.Items.Add(decim);
            }
            reader.Close();
            //try
            //{
            //  Block of code to try
            //}
            //catch (Exception e)
            //{
            //  Block of code to handle errors
            //}


            try
            {
                //string contents = File.ReadAllText(@"C:\temp\readme1.txt");
                string contents = File.ReadAllText(@"D:\WFAnet\bin\Debug\sinewaveHEX.csv");
               // Console.WriteLine(contents);
               //  MessageBox.Show(contents);              // แสดง เป็นกลุ่ม
            }
         //   catch (FileNotFoundException e)
            catch (Exception)
            {
                //Console.WriteLine(e.Message);
            }

        }

        private void HEXlistBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void DEClistBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void S16blistBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void S16bDEClistBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
