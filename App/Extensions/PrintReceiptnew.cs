using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PrinterUtility;
using App.Model;
using App.Repository;

namespace App.Extensions
{
    public enum PrintOption
    {
        ReprintInvoice = 1,
        PrintInvoice,
        PrintTableInvoice,
        PrintKOT
    }
    class PrintReceiptnew
    {
        public void printreport()
        {

            PrinterUtility.EscPosEpsonCommands.EscPosEpson obj = new PrinterUtility.EscPosEpsonCommands.EscPosEpson();
            var BytesValue = Encoding.ASCII.GetBytes(string.Empty);
            BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Separator());
            BytesValue = PrintExtensions.AddBytes(BytesValue, obj.CharSize.DoubleWidth6());
            BytesValue = PrintExtensions.AddBytes(BytesValue, obj.FontSelect.FontA());
            BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Alignment.Center());
            BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.ASCII.GetBytes(" ax Title\n"));
            BytesValue = PrintExtensions.AddBytes(BytesValue, obj.CharSize.DoubleWidth4());
            BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.ASCII.GetBytes("Sub Title\n"));
            BytesValue = PrintExtensions.AddBytes(BytesValue, obj.CharSize.Nomarl());
            BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Separator());
            BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.ASCII.GetBytes("Invoice\n"));
            BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Alignment.Left());
            BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.ASCII.GetBytes("Invoice No. : 12345\n"));
            BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.ASCII.GetBytes("Date        : 12/12/2015\n"));
            BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.ASCII.GetBytes("Itm                      Qty      Net   Total\n"));
            BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Separator());
            BytesValue = PrintExtensions.AddBytes(BytesValue, string.Format("{0,-40}{1,6}{2,9}{3,9:N2}\n", "item 1", 12, 11, 144.00));
            BytesValue = PrintExtensions.AddBytes(BytesValue, string.Format("{0,-40}{1,6}{2,9}{3,9:N2}\n", "item 2", 12, 11, 144.00));
            BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Alignment.Right());
            BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Separator());
            BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.ASCII.GetBytes("Total\n"));
            BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.ASCII.GetBytes("288.00\n"));
            BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Separator());
            BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());
            BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Alignment.Center());
            BytesValue = PrintExtensions.AddBytes(BytesValue, obj.CharSize.DoubleHeight6());
            BytesValue = PrintExtensions.AddBytes(BytesValue, obj.BarCode.Code128("12345"));
            BytesValue = PrintExtensions.AddBytes(BytesValue, obj.QrCode.Print("12345", PrinterUtility.Enums.QrCodeSize.Grande));
            BytesValue = PrintExtensions.AddBytes(BytesValue, "-------------------Thank you for coming------------------------\n");
            BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Alignment.Left());
            BytesValue = PrintExtensions.AddBytes(BytesValue, CutPage());
            // PrinterUtility.PrintExtensions.Print(BytesValue, POSPrintExample.Properties.Settings.Default.PrinterPath);
            if (File.Exists(".\\tmpPrint.print"))
                File.Delete(".\\tmpPrint.print");
            File.WriteAllBytes(".\\tmpPrint.print", BytesValue);
            RawPrinterHelper.SendFileToPrinter(Program.MySettingViewModal.MyPrinterDetails.PosPrinter, ".\\tmpPrint.print");
            try
            {
                File.Delete(".\\tmpPrint.print");
            }
            catch
            {

            }

        }

        public byte[] CutPage()
        {
            List<byte> oby = new List<byte>();
            oby.Add(Convert.ToByte(Convert.ToChar(0x1D)));
            oby.Add(Convert.ToByte('V'));
            oby.Add((byte)66);
            oby.Add((byte)3);
            return oby.ToArray();
        }
        public byte[] GetLogo(string LogoPath)
        {
            List<byte> byteList = new List<byte>();
            if (!File.Exists(LogoPath))
                return null;
            BitmapData data = GetBitmapData(LogoPath);
            BitArray dots = data.Dots;
            byte[] width = BitConverter.GetBytes(data.Width);

            int offset = 0;
            MemoryStream stream = new MemoryStream();
            // BinaryWriter bw = new BinaryWriter(stream);
            byteList.Add(Convert.ToByte(Convert.ToChar(0x1B)));
            //bw.Write((char));
            byteList.Add(Convert.ToByte('@'));
            //bw.Write('@');
            byteList.Add(Convert.ToByte(Convert.ToChar(0x1B)));
            // bw.Write((char)0x1B);
            byteList.Add(Convert.ToByte('3'));
            //bw.Write('3');
            //bw.Write((byte)24);
            byteList.Add((byte)24);
            while (offset < data.Height)
            {
                byteList.Add(Convert.ToByte(Convert.ToChar(0x1B)));
                byteList.Add(Convert.ToByte('*'));
                //bw.Write((char)0x1B);
                //bw.Write('*');         // bit-image mode
                byteList.Add((byte)33);
                //bw.Write((byte)33);    // 24-dot double-density
                byteList.Add(width[0]);
                byteList.Add(width[1]);
                //bw.Write(width[0]);  // width low byte
                //bw.Write(width[1]);  // width high byte

                for (int x = 0; x < data.Width; ++x)
                {
                    for (int k = 0; k < 3; ++k)
                    {
                        byte slice = 0;
                        for (int b = 0; b < 8; ++b)
                        {
                            int y = (((offset / 8) + k) * 8) + b;
                            // Calculate the location of the pixel we want in the bit array.
                            // It'll be at (y * width) + x.
                            int i = (y * data.Width) + x;

                            // If the image is shorter than 24 dots, pad with zero.
                            bool v = false;
                            if (i < dots.Length)
                            {
                                v = dots[i];
                            }
                            slice |= (byte)((v ? 1 : 0) << (7 - b));
                        }
                        byteList.Add(slice);
                        //bw.Write(slice);
                    }
                }
                offset += 24;
                byteList.Add(Convert.ToByte(0x0A));
                //bw.Write((char));
            }
            // Restore the line spacing to the default of 30 dots.
            byteList.Add(Convert.ToByte(0x1B));
            byteList.Add(Convert.ToByte('3'));
            //bw.Write('3');
            byteList.Add((byte)30);
            return byteList.ToArray();
            //bw.Flush();
            //byte[] bytes = stream.ToArray();
            //return logo + Encoding.Default.GetString(bytes);
        }

        public BitmapData GetBitmapData(string bmpFileName)
        {
            using (var bitmap = (Bitmap)Bitmap.FromFile(bmpFileName))
            {
                var threshold = 127;
                var index = 0;
                double multiplier = 570; // this depends on your printer model. for Beiyang you should use 1000
                double scale = (double)(multiplier / (double)bitmap.Width);
                int xheight = (int)(bitmap.Height * scale);
                int xwidth = (int)(bitmap.Width * scale);
                var dimensions = xwidth * xheight;
                var dots = new BitArray(dimensions);

                for (var y = 0; y < xheight; y++)
                {
                    for (var x = 0; x < xwidth; x++)
                    {
                        var _x = (int)(x / scale);
                        var _y = (int)(y / scale);
                        var color = bitmap.GetPixel(_x, _y);
                        var luminance = (int)(color.R * 0.3 + color.G * 0.59 + color.B * 0.11);
                        dots[index] = (luminance < threshold);
                        index++;
                    }
                }

                return new BitmapData()
                {
                    Dots = dots,
                    Height = (int)(bitmap.Height * scale),
                    Width = (int)(bitmap.Width * scale)
                };
            }
        }

        public class BitmapData
        {
            public BitArray Dots
            {
                get;
                set;
            }

            public int Height
            {
                get;
                set;
            }

            public int Width
            {
                get;
                set;
            }
        }

        public void printInvoice(Invoicemaster invoicemaster, PrintOption printOption, string printerIP = "")
        {
            string eClear = ('' + "@");
            string eDrawer = (eClear + ('' + ("p" + ('\0' + ".}"))));

            PrinterUtility.EscPosEpsonCommands.EscPosEpson obj = new PrinterUtility.EscPosEpsonCommands.EscPosEpson(54);
            string format = "";
            int productLength = 0;
            if (printOption != PrintOption.PrintKOT)
            {
                format = "{0,-24}{1,4}{2,7}{3,7:N2}\n";
                productLength = 23;
            }
            else if (printOption == PrintOption.PrintKOT)
            {
                format = "{0,-30}{1,7}\n";
                productLength = 29;
            }
            byte[] bytes = new byte[] { };

            string border = "";
            int maxCharacterInLine = 42;
            for (int i = 0; i < maxCharacterInLine; i++)
            {
                border = border + "-";
            }

            bytes = PrintExtensions.AddBytes(bytes, obj.CharSize.DoubleWidth2());
            bytes = PrintExtensions.AddBytes(bytes, obj.FontSelect.FontA());
            bytes = PrintExtensions.AddBytes(bytes, obj.Alignment.Center());
            bytes = PrintExtensions.AddBytes(bytes, Encoding.ASCII.GetBytes(invoicemaster.StoreName + "\n"));

            bytes = PrintExtensions.AddBytes(bytes, obj.CharSize.Nomarl());
            if (!string.IsNullOrEmpty(invoicemaster.StoreAddress))
            {
                bytes = PrintExtensions.AddBytes(bytes, Encoding.ASCII.GetBytes(invoicemaster.StoreAddress + "\n"));
            }
            if (!string.IsNullOrEmpty(invoicemaster.StoreStreet))
            {
                bytes = PrintExtensions.AddBytes(bytes, Encoding.ASCII.GetBytes(invoicemaster.StoreStreet + "\n"));
            }

            if (!string.IsNullOrEmpty(invoicemaster.StorePhone))
            {
                bytes = PrintExtensions.AddBytes(bytes, Encoding.ASCII.GetBytes(invoicemaster.StorePhone + "\n"));
            }

            bytes = PrintExtensions.AddBytes(bytes, Encoding.ASCII.GetBytes(border + "\n"));

            bytes = PrintExtensions.AddBytes(bytes, obj.CharSize.DoubleWidth2());

            switch (printOption)
            {
                case PrintOption.PrintInvoice:
                    bytes = PrintExtensions.AddBytes(bytes, Encoding.ASCII.GetBytes("Tax Invoice\n"));


                    var encoding = Encoding.GetEncoding(936);
                    //  bytes = Encoding.Unicode.GetBytes("فاتورة ضريبية");

                    // bytes = PrintExtensions.AddBytes(bytes, encoding.GetBytes("فاتورة ضريبية"));
                    ////bytes = PrintExtensions.AddBytes(bytes, System.Text.Encoding.Unicode.GetBytes("فاتورة ضريبية"));
                    ////bytes = PrintExtensions.AddBytes(bytes, System.Text.Encoding.UTF32.GetBytes("فاتورة ضريبية"));

                    break;
                case PrintOption.ReprintInvoice:
                    bytes = PrintExtensions.AddBytes(bytes, Encoding.ASCII.GetBytes("Tax Invoice\n"));
                    bytes = PrintExtensions.AddBytes(bytes, obj.CharSize.Nomarl());
                    bytes = PrintExtensions.AddBytes(bytes, Encoding.ASCII.GetBytes("[Duplicate Bill]\n"));
                    break;
                case PrintOption.PrintTableInvoice:
                    bytes = PrintExtensions.AddBytes(bytes, Encoding.ASCII.GetBytes("Table Bill\n"));
                    break;
                case PrintOption.PrintKOT:
                    bytes = PrintExtensions.AddBytes(bytes, Encoding.ASCII.GetBytes("KOT\n"));
                    break;
            }

            bytes = PrintExtensions.AddBytes(bytes, Encoding.ASCII.GetBytes("\n"));

            bytes = PrintExtensions.AddBytes(bytes, obj.CharSize.Nomarl());
            bytes = PrintExtensions.AddBytes(bytes, obj.Alignment.Left());

            bytes = PrintExtensions.AddBytes(bytes, Encoding.ASCII.GetBytes(string.Format("Invoice # : {0}", invoicemaster.InvoiceNum) + "\n"));
            bytes = PrintExtensions.AddBytes(bytes, Encoding.ASCII.GetBytes(string.Format("Date      : {0}", invoicemaster.InvoiceDate.ToString("dd-MMM-yyyy hh:mm tt")) + "\n"));
            bytes = PrintExtensions.AddBytes(bytes, Encoding.ASCII.GetBytes(string.Format("Cashier   : {0}", invoicemaster.Cashier.Trim()) + "\n"));
            if (!string.IsNullOrEmpty(invoicemaster.BuzzerName) && !string.Equals(invoicemaster.BuzzerName.ToString().ToLower(), "buzzer"))
            {
                bytes = PrintExtensions.AddBytes(bytes, Encoding.ASCII.GetBytes(string.Format("Buzzer    : {0}", invoicemaster.BuzzerName.ToString()) + "\n"));
            }
            bytes = PrintExtensions.AddBytes(bytes, Encoding.ASCII.GetBytes(string.Format("Table     : {0}", invoicemaster.TableName.Trim()) + "\n"));

            bytes = PrintExtensions.AddBytes(bytes, obj.Alignment.Center());
            bytes = PrintExtensions.AddBytes(bytes, Encoding.ASCII.GetBytes(border + "\n"));

            bytes = PrintExtensions.AddBytes(bytes, obj.Alignment.Left());
            if (printOption != PrintOption.PrintKOT)
            {
                bytes = PrintExtensions.AddBytes(bytes, string.Format(format, "Item", "Qty", "Rate", "Amount"));
            }
            else if (printOption == PrintOption.PrintKOT)
            {
                bytes = PrintExtensions.AddBytes(bytes, string.Format(format, "Item", "Qty"));
            }

            bytes = PrintExtensions.AddBytes(bytes, Encoding.ASCII.GetBytes(border + "\n"));
            foreach (InvoiceDetail invoicedet in invoicemaster.InvoiceDetails)
            {
                List<string> orderlineWords = new List<string>();
                if (!string.IsNullOrEmpty(invoicedet.ProductName))
                {
                    orderlineWords = invoicedet.ProductName.Trim().Split(new[] { ' ' }).ToList();
                }
                else if (invoicedet.Product != null)
                {
                    orderlineWords = invoicedet.Product.ProductName.Trim().Split(new[] { ' ' }).ToList();
                }
                string normalName = "";
                string extraName = "";
                foreach (string w in orderlineWords)
                {
                    if (normalName.Length + w.Length <= productLength)
                    {
                        normalName = normalName + w + " ";
                    }
                    else if (extraName.Length + w.Length <= productLength - 3)
                    {
                        extraName = extraName + w + " ";
                    }
                }

                string orderline = "";
                if (printOption != PrintOption.PrintKOT)
                {
                    orderline = string.Format(format,
                    normalName.Trim(),
                    invoicedet.Qty,
                    string.Format("{0:0.00}", invoicedet.UnitPrice),
                    string.Format("{0:0.00}", invoicedet.Qty * invoicedet.UnitPrice));
                }
                else if (printOption == PrintOption.PrintKOT)
                {
                    orderline = string.Format(format,
                    normalName.Trim(),
                    invoicedet.Qty);
                }

                bytes = PrintExtensions.AddBytes(bytes, Encoding.ASCII.GetBytes(orderline));
                if (!string.IsNullOrEmpty(extraName))
                {
                    bytes = PrintExtensions.AddBytes(bytes, Encoding.ASCII.GetBytes(string.Format("   {0}", extraName) + "\n"));
                }
                if (!string.IsNullOrEmpty(invoicedet.Notes))
                {
                    bytes = PrintExtensions.AddBytes(bytes, Encoding.ASCII.GetBytes(string.Format("   [{0}]\n", invoicedet.Notes.Substring(0, Math.Min(30, invoicedet.Notes.Length)))));
                }
            }

            if (printOption == PrintOption.PrintKOT)
            {
                bytes = PrintExtensions.AddBytes(bytes, obj.Alignment.Right());
                bytes = PrintExtensions.AddBytes(bytes, obj.CharSize.DoubleWidth2());
                bytes = PrintExtensions.AddBytes(bytes, Encoding.ASCII.GetBytes("\n"));
                bytes = PrintExtensions.AddBytes(bytes, Encoding.ASCII.GetBytes(string.Format("{0,37}\n", string.Format("Total {0} Items", invoicemaster.InvoiceDetails.Count()))));
            }

            if (printOption != PrintOption.PrintKOT)
            {
                bytes = PrintExtensions.AddBytes(bytes, obj.CharSize.Nomarl());
                bytes = PrintExtensions.AddBytes(bytes, Encoding.ASCII.GetBytes(border + "\n"));

                bytes = PrintExtensions.AddBytes(bytes, obj.Alignment.Right());
                bytes = PrintExtensions.AddBytes(bytes, Encoding.ASCII.GetBytes(String.Format("{0,15}{1,7}", "Gross Amount : ", string.Format("{0:0.00}", invoicemaster.InvoiceDetails.Sum(u => u.Qty * u.UnitPrice).ToString("F").Trim())) + "\n"));
                if (invoicemaster.TotalDiscount != 0)
                {
                    bytes = PrintExtensions.AddBytes(bytes, Encoding.ASCII.GetBytes(String.Format("{0,15}{1,7}", "(-) Discount : ", string.Format("{0:0.00}", invoicemaster.TotalDiscount.ToString().Trim())) + "\n"));
                }
                bytes = PrintExtensions.AddBytes(bytes, Encoding.ASCII.GetBytes(String.Format("{0,15}{1,7}", "(+) Tax      : ", string.Format("{0:0.00}", invoicemaster.Taxamount.ToString().Trim())) + "\n"));

                bytes = PrintExtensions.AddBytes(bytes, obj.CharSize.DoubleWidth2());
                bytes = PrintExtensions.AddBytes(bytes, Encoding.ASCII.GetBytes(String.Format("Total : AED {0:0.00}", invoicemaster.TotalBill.ToString("0.00").Trim()) + "\n"));
            }

            if (!string.IsNullOrEmpty(invoicemaster.CustomerName) && !string.Equals(invoicemaster.CustomerName.Trim().ToLower(), "new"))
            {
                bytes = PrintExtensions.AddBytes(bytes, obj.CharSize.Nomarl());
                bytes = PrintExtensions.AddBytes(bytes, obj.Alignment.Left());
                bytes = PrintExtensions.AddBytes(bytes, Encoding.ASCII.GetBytes(border + "\n"));

                bytes = PrintExtensions.AddBytes(bytes, Encoding.ASCII.GetBytes(string.Format("Customer : {0}", invoicemaster.CustomerName.Trim()) + "\n"));
                if (!string.IsNullOrEmpty(invoicemaster.CustomerPhone))
                {
                    bytes = PrintExtensions.AddBytes(bytes, Encoding.ASCII.GetBytes(string.Format("Phone    : {0}", invoicemaster.CustomerPhone.ToString().Trim()) + "\n"));
                }
                if (!string.IsNullOrEmpty(invoicemaster.CustomerAdress))
                {
                    bytes = PrintExtensions.AddBytes(bytes, Encoding.ASCII.GetBytes(string.Format("Address  : {0}", invoicemaster.CustomerAdress.ToString().Trim()) + "\n"));
                }
            }

            if (printOption != PrintOption.PrintKOT)
            {
                bytes = PrintExtensions.AddBytes(bytes, obj.CharSize.Nomarl());
                bytes = PrintExtensions.AddBytes(bytes, obj.Alignment.Center());
                bytes = PrintExtensions.AddBytes(bytes, Encoding.ASCII.GetBytes(border + "\n"));
                bytes = PrintExtensions.AddBytes(bytes, "Thank you for coming\n");
            }


            bytes = PrintExtensions.AddBytes(bytes, CutPage());
            bytes = PrintExtensions.AddBytes(bytes, eDrawer);



            if (File.Exists(".\\tmpPrint.print"))
                File.Delete(".\\tmpPrint.print");
            File.WriteAllBytes(".\\tmpPrint.print", bytes);
            if (printOption != PrintOption.PrintKOT)
            {
                RawPrinterHelper.SendFileToPrinter(Program.MySettingViewModal.MyPrinterDetails.PosPrinter, ".\\tmpPrint.print");
            }
            else if (printOption == PrintOption.PrintKOT)
            {
                try
                {
                    IpPrint print = new IpPrint();
                    print.PrinttoIP(printerIP, ".\\tmpPrint.print");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error on KOT Printer So Printing on receipt Printer ");
                    ErrorLogger.WriteToErrorLog("Error on KOT Printer ", ex.StackTrace, ex.Message);
                    RawPrinterHelper.SendFileToPrinter(Program.MySettingViewModal.MyPrinterDetails.PosPrinter, ".\\tmpPrint.print");
                }
            }
            try
            {
                File.Delete(".\\tmpPrint.print");
            }
            catch
            {

            }
        }







        public void printInvoiceLogo(Invoicemaster invoicemaster, PrintOption printOption, string printerIP = "")
        {
            string eClear = ('' + "@");
            string eDrawer = (eClear + ('' + ("p" + ('\0' + ".}"))));

            PrinterUtility.EscPosEpsonCommands.EscPosEpson obj = new PrinterUtility.EscPosEpsonCommands.EscPosEpson(54);
            string format = "";
            int productLength = 0;
            if (printOption != PrintOption.PrintKOT)
            {
                format = "{0,-24}{1,4}{2,7}{3,7:N2}\n";
                productLength = 23;
            }
            else if (printOption == PrintOption.PrintKOT)
            {
                format = "{0,-30}{1,7}\n";
                productLength = 29;
            }
            byte[] bytes = GetLogo("logo.bmp");

            string border = "";
            int maxCharacterInLine = 42;
            for (int i = 0; i < maxCharacterInLine; i++)
            {
                border = border + "-";
            }

            bytes = PrintExtensions.AddBytes(bytes, obj.CharSize.DoubleWidth2());
            bytes = PrintExtensions.AddBytes(bytes, obj.FontSelect.FontA());
            bytes = PrintExtensions.AddBytes(bytes, obj.Alignment.Center());
            //bytes = PrintExtensions.AddBytes(bytes, Encoding.ASCII.GetBytes(invoicemaster.StoreName + "\n"));

            bytes = PrintExtensions.AddBytes(bytes, obj.CharSize.Nomarl());
            //if (!string.IsNullOrEmpty(invoicemaster.StoreAddress))
            //{
            //    bytes = PrintExtensions.AddBytes(bytes, Encoding.ASCII.GetBytes(invoicemaster.StoreAddress + "\n"));
            //}
            //if (!string.IsNullOrEmpty(invoicemaster.StoreStreet))
            //{
            //    bytes = PrintExtensions.AddBytes(bytes, Encoding.ASCII.GetBytes(invoicemaster.StoreStreet + "\n"));
            //}

            //if (!string.IsNullOrEmpty(invoicemaster.StorePhone))
            //{
            //    bytes = PrintExtensions.AddBytes(bytes, Encoding.ASCII.GetBytes(invoicemaster.StorePhone + "\n"));
            //}

            bytes = PrintExtensions.AddBytes(bytes, Encoding.ASCII.GetBytes(border + "\n"));

            bytes = PrintExtensions.AddBytes(bytes, obj.CharSize.DoubleWidth2());

            switch (printOption)
            {
                case PrintOption.PrintInvoice:
                    bytes = PrintExtensions.AddBytes(bytes, Encoding.ASCII.GetBytes("Tax Invoice\n"));


                    var encoding = Encoding.GetEncoding(936);
                    //  bytes = Encoding.Unicode.GetBytes("فاتورة ضريبية");

                    // bytes = PrintExtensions.AddBytes(bytes, encoding.GetBytes("فاتورة ضريبية"));
                    ////bytes = PrintExtensions.AddBytes(bytes, System.Text.Encoding.Unicode.GetBytes("فاتورة ضريبية"));
                    ////bytes = PrintExtensions.AddBytes(bytes, System.Text.Encoding.UTF32.GetBytes("فاتورة ضريبية"));

                    break;
                case PrintOption.ReprintInvoice:
                    bytes = PrintExtensions.AddBytes(bytes, Encoding.ASCII.GetBytes("Tax Invoice\n"));
                    bytes = PrintExtensions.AddBytes(bytes, obj.CharSize.Nomarl());
                    bytes = PrintExtensions.AddBytes(bytes, Encoding.ASCII.GetBytes("[Duplicate Bill]\n"));
                    break;
                case PrintOption.PrintTableInvoice:
                    bytes = PrintExtensions.AddBytes(bytes, Encoding.ASCII.GetBytes("Table Bill\n"));
                    break;
                case PrintOption.PrintKOT:
                    bytes = PrintExtensions.AddBytes(bytes, Encoding.ASCII.GetBytes("KOT\n"));
                    break;
            }

            bytes = PrintExtensions.AddBytes(bytes, Encoding.ASCII.GetBytes("\n"));

            bytes = PrintExtensions.AddBytes(bytes, obj.CharSize.Nomarl());
            bytes = PrintExtensions.AddBytes(bytes, obj.Alignment.Left());

            bytes = PrintExtensions.AddBytes(bytes, Encoding.ASCII.GetBytes(string.Format("Invoice # : {0}", invoicemaster.InvoiceNum) + "\n"));
            bytes = PrintExtensions.AddBytes(bytes, Encoding.ASCII.GetBytes(string.Format("Date      : {0}", invoicemaster.InvoiceDate.ToString("dd-MMM-yyyy hh:mm tt")) + "\n"));
            bytes = PrintExtensions.AddBytes(bytes, Encoding.ASCII.GetBytes(string.Format("Cashier   : {0}", invoicemaster.Cashier.Trim()) + "\n"));
            if (!string.IsNullOrEmpty(invoicemaster.BuzzerName) && !string.Equals(invoicemaster.BuzzerName.ToString().ToLower(), "buzzer"))
            {
                bytes = PrintExtensions.AddBytes(bytes, Encoding.ASCII.GetBytes(string.Format("Buzzer    : {0}", invoicemaster.BuzzerName.ToString()) + "\n"));
            }
            bytes = PrintExtensions.AddBytes(bytes, Encoding.ASCII.GetBytes(string.Format("Table     : {0}", invoicemaster.TableName.Trim()) + "\n"));

            bytes = PrintExtensions.AddBytes(bytes, obj.Alignment.Center());
            bytes = PrintExtensions.AddBytes(bytes, Encoding.ASCII.GetBytes(border + "\n"));

            bytes = PrintExtensions.AddBytes(bytes, obj.Alignment.Left());
            if (printOption != PrintOption.PrintKOT)
            {
                bytes = PrintExtensions.AddBytes(bytes, string.Format(format, "Item", "Qty", "Rate", "Amount"));
            }
            else if (printOption == PrintOption.PrintKOT)
            {
                bytes = PrintExtensions.AddBytes(bytes, string.Format(format, "Item", "Qty"));
            }

            bytes = PrintExtensions.AddBytes(bytes, Encoding.ASCII.GetBytes(border + "\n"));
            foreach (InvoiceDetail invoicedet in invoicemaster.InvoiceDetails)
            {
                List<string> orderlineWords = new List<string>();
                if (!string.IsNullOrEmpty(invoicedet.ProductName))
                {
                    orderlineWords = invoicedet.ProductName.Trim().Split(new[] { ' ' }).ToList();
                }
                else if (invoicedet.Product != null)
                {
                    orderlineWords = invoicedet.Product.ProductName.Trim().Split(new[] { ' ' }).ToList();
                }
                string normalName = "";
                string extraName = "";
                foreach (string w in orderlineWords)
                {
                    if (normalName.Length + w.Length <= productLength)
                    {
                        normalName = normalName + w + " ";
                    }
                    else if (extraName.Length + w.Length <= productLength - 3)
                    {
                        extraName = extraName + w + " ";
                    }
                }

                string orderline = "";
                if (printOption != PrintOption.PrintKOT)
                {
                    orderline = string.Format(format,
                    normalName.Trim(),
                    invoicedet.Qty,
                    string.Format("{0:0.00}", invoicedet.UnitPrice),
                    string.Format("{0:0.00}", invoicedet.Qty * invoicedet.UnitPrice));
                }
                else if (printOption == PrintOption.PrintKOT)
                {
                    orderline = string.Format(format,
                    normalName.Trim(),
                    invoicedet.Qty);
                }

                bytes = PrintExtensions.AddBytes(bytes, Encoding.ASCII.GetBytes(orderline));
                if (!string.IsNullOrEmpty(extraName))
                {
                    bytes = PrintExtensions.AddBytes(bytes, Encoding.ASCII.GetBytes(string.Format("   {0}", extraName) + "\n"));
                }
                if (!string.IsNullOrEmpty(invoicedet.Notes))
                {
                    bytes = PrintExtensions.AddBytes(bytes, Encoding.ASCII.GetBytes(string.Format("   [{0}]\n", invoicedet.Notes.Substring(0, Math.Min(30, invoicedet.Notes.Length)))));
                }
            }

            if (printOption == PrintOption.PrintKOT)
            {
                bytes = PrintExtensions.AddBytes(bytes, obj.Alignment.Right());
                bytes = PrintExtensions.AddBytes(bytes, obj.CharSize.DoubleWidth2());
                bytes = PrintExtensions.AddBytes(bytes, Encoding.ASCII.GetBytes("\n"));
                bytes = PrintExtensions.AddBytes(bytes, Encoding.ASCII.GetBytes(string.Format("{0,37}\n", string.Format("Total {0} Items", invoicemaster.InvoiceDetails.Count()))));
            }

            if (printOption != PrintOption.PrintKOT)
            {
                bytes = PrintExtensions.AddBytes(bytes, obj.CharSize.Nomarl());
                bytes = PrintExtensions.AddBytes(bytes, Encoding.ASCII.GetBytes(border + "\n"));

                bytes = PrintExtensions.AddBytes(bytes, obj.Alignment.Right());
                bytes = PrintExtensions.AddBytes(bytes, Encoding.ASCII.GetBytes(String.Format("{0,15}{1,7}", "Gross Amount : ", string.Format("{0:0.00}", invoicemaster.InvoiceDetails.Sum(u => u.Qty * u.UnitPrice).ToString("F").Trim())) + "\n"));
                if (invoicemaster.TotalDiscount != 0)
                {
                    bytes = PrintExtensions.AddBytes(bytes, Encoding.ASCII.GetBytes(String.Format("{0,15}{1,7}", "(-) Discount : ", string.Format("{0:0.00}", invoicemaster.TotalDiscount.ToString().Trim())) + "\n"));
                }
                bytes = PrintExtensions.AddBytes(bytes, Encoding.ASCII.GetBytes(String.Format("{0,15}{1,7}", "(+) Tax      : ", string.Format("{0:0.00}", invoicemaster.Taxamount.ToString().Trim())) + "\n"));

                bytes = PrintExtensions.AddBytes(bytes, obj.CharSize.DoubleWidth2());
                bytes = PrintExtensions.AddBytes(bytes, Encoding.ASCII.GetBytes(String.Format("Total : AED {0:0.00}", invoicemaster.TotalBill.ToString("0.00").Trim()) + "\n"));
            }

            if (!string.IsNullOrEmpty(invoicemaster.CustomerName) && !string.Equals(invoicemaster.CustomerName.Trim().ToLower(), "new"))
            {
                bytes = PrintExtensions.AddBytes(bytes, obj.CharSize.Nomarl());
                bytes = PrintExtensions.AddBytes(bytes, obj.Alignment.Left());
                bytes = PrintExtensions.AddBytes(bytes, Encoding.ASCII.GetBytes(border + "\n"));

                bytes = PrintExtensions.AddBytes(bytes, Encoding.ASCII.GetBytes(string.Format("Customer : {0}", invoicemaster.CustomerName.Trim()) + "\n"));
                if (!string.IsNullOrEmpty(invoicemaster.CustomerPhone))
                {
                    bytes = PrintExtensions.AddBytes(bytes, Encoding.ASCII.GetBytes(string.Format("Phone    : {0}", invoicemaster.CustomerPhone.ToString().Trim()) + "\n"));
                }
                if (!string.IsNullOrEmpty(invoicemaster.CustomerAdress))
                {
                    bytes = PrintExtensions.AddBytes(bytes, Encoding.ASCII.GetBytes(string.Format("Address  : {0}", invoicemaster.CustomerAdress.ToString().Trim()) + "\n"));
                }
            }

            if (printOption != PrintOption.PrintKOT)
            {
                bytes = PrintExtensions.AddBytes(bytes, obj.CharSize.Nomarl());
                bytes = PrintExtensions.AddBytes(bytes, obj.Alignment.Center());
                bytes = PrintExtensions.AddBytes(bytes, Encoding.ASCII.GetBytes(border + "\n"));
                bytes = PrintExtensions.AddBytes(bytes, "Thank you for coming\n");
            }


            bytes = PrintExtensions.AddBytes(bytes, CutPage());
            bytes = PrintExtensions.AddBytes(bytes, eDrawer);



            if (File.Exists(".\\tmpPrint.print"))
                File.Delete(".\\tmpPrint.print");
            File.WriteAllBytes(".\\tmpPrint.print", bytes);
            if (printOption != PrintOption.PrintKOT)
            {
                RawPrinterHelper.SendFileToPrinter(Program.MySettingViewModal.MyPrinterDetails.PosPrinter, ".\\tmpPrint.print");
            }
            else if (printOption == PrintOption.PrintKOT)
            {
                try
                {
                    IpPrint print = new IpPrint();
                    print.PrinttoIP(printerIP, ".\\tmpPrint.print");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error on KOT Printer So Printing on receipt Printer ");
                    ErrorLogger.WriteToErrorLog("Error on KOT Printer ", ex.StackTrace, ex.Message);
                    RawPrinterHelper.SendFileToPrinter(Program.MySettingViewModal.MyPrinterDetails.PosPrinter, ".\\tmpPrint.print");
                }
            }
            try
            {
                File.Delete(".\\tmpPrint.print");
            }
            catch
            {

            }
        }










        public void ReprintprintInvoicereport(Invoicemaster invoicemaster)
        {
            printInvoice(invoicemaster, PrintOption.ReprintInvoice);
        }

       
        public void printInvoicereport(Invoicemaster invoicemaster)
        {
           
            if (Program.MySettingViewModal.AppUserSettings.LogoReport == true)
            {
                printInvoiceLogo(invoicemaster, PrintOption.PrintInvoice);
            }
            else
            {
                printInvoice(invoicemaster, PrintOption.PrintInvoice);

            }
        }

        public void printTableInvoicereport(Invoicemaster invoicemaster)
        {
            printInvoice(invoicemaster, PrintOption.PrintTableInvoice);
        }

        public void printKOTreport(Invoicemaster kotMaster)
        {
            InvoiceRepository invrepo = new InvoiceRepository();
            Invoicemaster invoicemaster = invrepo.GetInvoice(kotMaster.InvoicemasterID);
            var Printer = invoicemaster.InvoiceDetails.Select(m => m.Product.Category.PrinterName).Distinct();
            foreach (var printer in Printer)
            {
                String PrinterIP = printer.ToString();
                //List<InvoiceDetail> kotdetails = invoicemaster.InvoiceDetails.Where(m => m.Product.Category.PrinterName == PrinterIP).ToList();
                // List<InvoiceDetail> kotdetails = invoicemaster.InvoiceDetails.ToList();
                List<InvoiceDetail> kotdetails = invoicemaster.InvoiceDetails.Where(m => m.Product.Category.PrinterName == PrinterIP && m.Kotnum == 1).ToList();

                Invoicemaster newInvoicemaster = new Invoicemaster();
                newInvoicemaster = kotMaster;
                newInvoicemaster.InvoiceDetails = new List<InvoiceDetail>();
                newInvoicemaster.InvoiceDetails.AddRange(kotdetails);

                printInvoice(newInvoicemaster, PrintOption.PrintKOT, !string.IsNullOrEmpty(printer) ? printer.ToString() : "");
            }
        }

  
        public void printClosingreport(ShiftViewModel shiftViewModel)
        {
            PrinterUtility.EscPosEpsonCommands.EscPosEpson obj = new PrinterUtility.EscPosEpsonCommands.EscPosEpson(54);
            byte[] bytes = new byte[] { };

            string border = "";
            int maxCharacterInLine = 42;
            for (int i = 0; i < maxCharacterInLine; i++)
            {
                border = border + "-";
            }

            bytes = PrintExtensions.AddBytes(bytes, obj.CharSize.DoubleWidth2());
            bytes = PrintExtensions.AddBytes(bytes, obj.FontSelect.FontA());
            bytes = PrintExtensions.AddBytes(bytes, obj.Alignment.Center());
            bytes = PrintExtensions.AddBytes(bytes, Encoding.ASCII.GetBytes(shiftViewModel.StoreName + "\n"));

            bytes = PrintExtensions.AddBytes(bytes, obj.CharSize.Nomarl());
            if (!string.IsNullOrEmpty(Program.StoreAddress))
            {
                bytes = PrintExtensions.AddBytes(bytes, Encoding.ASCII.GetBytes(Program.StoreAddress + "\n"));
            }
            if (!string.IsNullOrEmpty(Program.StoreStreet))
            {
                bytes = PrintExtensions.AddBytes(bytes, Encoding.ASCII.GetBytes(Program.StoreStreet + "\n"));
            }

            if (!string.IsNullOrEmpty(Program.StrorePhone))
            {
                bytes = PrintExtensions.AddBytes(bytes, Encoding.ASCII.GetBytes(Program.StrorePhone + "\n"));
            }

            bytes = PrintExtensions.AddBytes(bytes, obj.CharSize.Nomarl());
            bytes = PrintExtensions.AddBytes(bytes, Encoding.ASCII.GetBytes(border + "\n"));

            bytes = PrintExtensions.AddBytes(bytes, obj.CharSize.Nomarl());
            bytes = PrintExtensions.AddBytes(bytes, obj.Alignment.Left());

            string headerDetailFormat = "{0,-12}{1,-25}\n";
            bytes = PrintExtensions.AddBytes(bytes, Encoding.ASCII.GetBytes(string.Format(headerDetailFormat,
                "Print On  : ", DateTime.Now.ToString("dd-MMM-yyyy hh:mm tt"))));
            bytes = PrintExtensions.AddBytes(bytes, Encoding.ASCII.GetBytes(string.Format(headerDetailFormat,
                "User      : ", Program.Username)));
            bytes = PrintExtensions.AddBytes(bytes, Encoding.ASCII.GetBytes(string.Format("{0,-12}",
                "Shift     : ")));
            if (shiftViewModel.ShiftName.Length > 24)
            {
                bytes = PrintExtensions.AddBytes(bytes, obj.FontSelect.SpecialFontA());
            }
            bytes = PrintExtensions.AddBytes(bytes, Encoding.ASCII.GetBytes(string.Format("{0,-25}\n",
                    shiftViewModel.ShiftName)));
            bytes = PrintExtensions.AddBytes(bytes, obj.FontSelect.FontA());
            DateTime start = Convert.ToDateTime(shiftViewModel.Shiftfrom);
            DateTime end = Convert.ToDateTime(shiftViewModel.ShiftTo);
            bytes = PrintExtensions.AddBytes(bytes, Encoding.ASCII.GetBytes(string.Format(headerDetailFormat,
                "Start     : ", start.ToString("dd-MMM-yyyy hh:mm tt"))));
            bytes = PrintExtensions.AddBytes(bytes, Encoding.ASCII.GetBytes(string.Format(headerDetailFormat,
                "End       : ", end.ToString("dd-MMM-yyyy hh:mm tt"))));

            bytes = PrintExtensions.AddBytes(bytes, obj.CharSize.Nomarl());
            bytes = PrintExtensions.AddBytes(bytes, Encoding.ASCII.GetBytes(border + "\n"));

            string bodyFormat = "{0,-22}{1,8}\n";
            bytes = PrintExtensions.AddBytes(bytes, Encoding.ASCII.GetBytes(string.Format(bodyFormat,
                "Description", "Amount")));
            bytes = PrintExtensions.AddBytes(bytes, Encoding.ASCII.GetBytes(border + "\n"));
            bytes = PrintExtensions.AddBytes(bytes, Encoding.ASCII.GetBytes(string.Format(bodyFormat,
                "Gross Sales       : ", string.Format("{0:0.00}", shiftViewModel.TotalSales - shiftViewModel.TotalTax + shiftViewModel.TotalDiscount))));
            bytes = PrintExtensions.AddBytes(bytes, Encoding.ASCII.GetBytes(string.Format(bodyFormat,
                "Total Tax         : ", string.Format("{0:0.00}", shiftViewModel.TotalTax))));
            bytes = PrintExtensions.AddBytes(bytes, Encoding.ASCII.GetBytes(string.Format(bodyFormat,
                "Total Discount    : ", string.Format("{0:0.00}", shiftViewModel.TotalDiscount))));
            bytes = PrintExtensions.AddBytes(bytes, Encoding.ASCII.GetBytes(string.Format(bodyFormat,
                "Net Sales         : ", string.Format("{0:0.00}", shiftViewModel.Netsales))));
            bytes = PrintExtensions.AddBytes(bytes, Encoding.ASCII.GetBytes("\n"));

            bytes = PrintExtensions.AddBytes(bytes, Encoding.ASCII.GetBytes(string.Format(bodyFormat,
                "Pending Bill      : ", string.Format("{0:0.00}", shiftViewModel.TableBill))));
            bytes = PrintExtensions.AddBytes(bytes, Encoding.ASCII.GetBytes("\n"));

            bytes = PrintExtensions.AddBytes(bytes, Encoding.ASCII.GetBytes(string.Format(bodyFormat,
                "Total By Cash     : ", string.Format("{0:0.00}", shiftViewModel.TotalByCash))));
            bytes = PrintExtensions.AddBytes(bytes, Encoding.ASCII.GetBytes(string.Format(bodyFormat,
                "Total By CC       : ", string.Format("{0:0.00}", shiftViewModel.TotalCC))));
            bytes = PrintExtensions.AddBytes(bytes, Encoding.ASCII.GetBytes(string.Format(bodyFormat,
                "Total By Zomato   : ", string.Format("{0:0.00}", shiftViewModel.TotalByZomato))));
            bytes = PrintExtensions.AddBytes(bytes, Encoding.ASCII.GetBytes(string.Format(bodyFormat,
                "Total By Credit   : ", string.Format("{0:0.00}", shiftViewModel.TotalByCredit))));
            //bytes = PrintExtensions.AddBytes(bytes, Encoding.ASCII.GetBytes(string.Format(bodyFormat,
            //    "Total BY Gift         : ", string.Format("{0:0.00}", shiftViewModel.TotalByGift))));
            bytes = PrintExtensions.AddBytes(bytes, Encoding.ASCII.GetBytes("\n"));

            bytes = PrintExtensions.AddBytes(bytes, Encoding.ASCII.GetBytes(string.Format(bodyFormat,
                "Credit Settlement : ", string.Format("{0:0.00}", shiftViewModel.SettlementAmount))));
            bytes = PrintExtensions.AddBytes(bytes, Encoding.ASCII.GetBytes("\n"));

            bytes = PrintExtensions.AddBytes(bytes, Encoding.ASCII.GetBytes(string.Format(bodyFormat,
                "Total Refund      : ", string.Format("{0:0.00}", shiftViewModel.TotalRefund))));
            bytes = PrintExtensions.AddBytes(bytes, Encoding.ASCII.GetBytes(string.Format(bodyFormat,
                "Total Cashout     : ", string.Format("{0:0.00}", shiftViewModel.TotalCashout))));
            bytes = PrintExtensions.AddBytes(bytes, Encoding.ASCII.GetBytes(string.Format(bodyFormat,
                "Total CashIn    : ", string.Format("{0:0.00}", shiftViewModel.TotalCashIn))));
            bytes = PrintExtensions.AddBytes(bytes, Encoding.ASCII.GetBytes(string.Format(bodyFormat,
                "Total Credit      : ", string.Format("{0:0.00}", shiftViewModel.TotalCredit))));
            bytes = PrintExtensions.AddBytes(bytes, Encoding.ASCII.GetBytes("\n"));

            bytes = PrintExtensions.AddBytes(bytes, Encoding.ASCII.GetBytes(string.Format(bodyFormat,
                "Net Amount        : ", string.Format("{0:0.00}", shiftViewModel.NetAmount))));

            bytes = PrintExtensions.AddBytes(bytes, CutPage());
            if (File.Exists(".\\tmpPrint.print"))
                File.Delete(".\\tmpPrint.print");
            File.WriteAllBytes(".\\tmpPrint.print", bytes);
            KeepCopy(shiftViewModel.ShiftName, bytes);


            RawPrinterHelper.SendFileToPrinter(Program.MySettingViewModal.MyPrinterDetails.PosPrinter, ".\\tmpPrint.print");
            try
            {
                File.Delete(".\\tmpPrint.print");
            }
            catch
            {

            }
        }
             public void OpenDrawer()
        {
            string eClear = ('' + "@");
            string eDrawer = (eClear + ('' + ("p" + ('\0' + ".}"))));


            //const string format = "{0,-24}{1,6}{2,9}{3,9:N2}\n";
            // const string format = "{0,-24}{1,-8}{2,-5},{3,4:N2}{4,4:N2}\n";
            const string format = "{0,-24}{1,-8}{2,-5},{3,-6:N2}{4,6:N2}\n";
            PrinterUtility.EscPosEpsonCommands.EscPosEpson obj = new PrinterUtility.EscPosEpsonCommands.EscPosEpson(54);
            var BytesValue = Encoding.ASCII.GetBytes(string.Empty);
            //Adds a Seperator

            BytesValue = PrintExtensions.AddBytes(BytesValue, CutPage());
            BytesValue = PrintExtensions.AddBytes(BytesValue, eDrawer);
            // PrinterUtility.PrintExtensions.Print(BytesValue, POSPrintExample.Properties.Settings.Default.PrinterPath);
            if (File.Exists(".\\tmpPrint.print"))
                File.Delete(".\\tmpPrint.print");
            File.WriteAllBytes(".\\tmpPrint.print", BytesValue);

            // MessageBox.Show(Program.MySettingViewModal.MyPrinterDetails.PosPrinter);

            RawPrinterHelper.SendFileToPrinter(Program.MySettingViewModal.MyPrinterDetails.PosPrinter, ".\\tmpPrint.print");
            try
            {
                File.Delete(".\\tmpPrint.print");
            }
            catch
            {

            }

        }

        public void KeepCopy(string Filename, byte[] bytes)
        {

            if (!(System.IO.Directory.Exists(Application.StartupPath + "\\CloseReports\\")))
            {
                System.IO.Directory.CreateDirectory(Application.StartupPath + "\\CloseReports\\");
            }
            String newfilename = Application.StartupPath + "\\CloseReports\\" + Filename + ".print";
            if (File.Exists(newfilename))
                File.Delete(newfilename);
            File.WriteAllBytes(newfilename, bytes);

        }



        public void PrintCopy(string Filename)
        {
            String newfilename = Application.StartupPath + "\\CloseReports\\" + Filename + ".print";

            RawPrinterHelper.SendFileToPrinter(Program.MySettingViewModal.MyPrinterDetails.PosPrinter, newfilename);

        }
    }
}
