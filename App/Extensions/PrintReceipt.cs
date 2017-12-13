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
    public class PrintReceipt
    {


        public void printreport()
        {

            PrinterUtility.EscPosEpsonCommands.EscPosEpson obj = new PrinterUtility.EscPosEpsonCommands.EscPosEpson();
            var BytesValue = Encoding.ASCII.GetBytes(string.Empty);
            BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Separator());
            BytesValue = PrintExtensions.AddBytes(BytesValue, obj.CharSize.DoubleWidth6());
            BytesValue = PrintExtensions.AddBytes(BytesValue, obj.FontSelect.FontA());
            BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Alignment.Center());
            BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.ASCII.GetBytes("Title\n"));
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

        public void printInvoicereport(Invoicemaster invoicemaster)
        {

            PrinterUtility.EscPosEpsonCommands.EscPosEpson obj = new PrinterUtility.EscPosEpsonCommands.EscPosEpson();
            var BytesValue = Encoding.ASCII.GetBytes(string.Empty);
            //Adds a Seperator
            BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Separator());
            //Increases the Width of Byte
            BytesValue = PrintExtensions.AddBytes(BytesValue, obj.CharSize.DoubleWidth2());

           // Select Font A
            BytesValue = PrintExtensions.AddBytes(BytesValue, obj.FontSelect.SpecialFontA());

            BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Alignment.Center()); //allign Center
            BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.ASCII.GetBytes(invoicemaster.StoreName + "\n")); //added Store name
            BytesValue = PrintExtensions.AddBytes(BytesValue, obj.CharSize.Nomarl()); 
            BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.ASCII.GetBytes(invoicemaster.StoreAddress + "\n"));
            BytesValue = PrintExtensions.AddBytes(BytesValue, obj.CharSize.Nomarl());
            BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Separator());
            BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.ASCII.GetBytes("Invoice\n"));
            BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Alignment.Left());
            
            BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.ASCII.GetBytes(invoicemaster.InvoiceNum + "\n"));
            BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.ASCII.GetBytes(invoicemaster.InvoiceDate.ToString()));
            BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Alignment.Right());
            BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.ASCII.GetBytes("Cashier:" + invoicemaster.Cashier.Trim() + "\n"));
            BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Alignment.Left());
            BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.ASCII.GetBytes("Itm                 Qty   Net   Dis  Total\n"));
            BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Separator());
            foreach (InvoiceDetail invoicedet in invoicemaster.InvoiceDetails)
            {
                BytesValue = PrintExtensions.AddBytes(BytesValue, string.Format("{0,-25}{1,6}{2,8}{3,8}{4,6:N2}\n", invoicedet.ProductName, invoicedet.Qty, invoicedet.UnitPrice, invoicedet.DiscountPerUOM, invoicedet.Total));
            }



            BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Alignment.Right());
            BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Separator());
            BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.ASCII.GetBytes("Total\n"));
            BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.ASCII.GetBytes(invoicemaster.TotalBill + "\n"));
            BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Separator());
            BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());
            //BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Alignment.Center());
            //BytesValue = PrintExtensions.AddBytes(BytesValue, obj.CharSize.DoubleHeight6());
            //BytesValue = PrintExtensions.AddBytes(BytesValue, obj.BarCode.Code128("12345"));
            //BytesValue = PrintExtensions.AddBytes(BytesValue, obj.QrCode.Print("12345", PrinterUtility.Enums.QrCodeSize.Grande));
            BytesValue = PrintExtensions.AddBytes(BytesValue, "----------------Thank you for coming---------------------\n");
            BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Alignment.Left());
            BytesValue = PrintExtensions.AddBytes(BytesValue, CutPage());
            // PrinterUtility.PrintExtensions.Print(BytesValue, POSPrintExample.Properties.Settings.Default.PrinterPath);
            if (File.Exists(".\\tmpPrint.print"))
                File.Delete(".\\tmpPrint.print");
            File.WriteAllBytes(".\\tmpPrint.print", BytesValue);

            MessageBox.Show(Program.MySettingViewModal.MyPrinterDetails.PosPrinter);

            RawPrinterHelper.SendFileToPrinter(Program.MySettingViewModal.MyPrinterDetails.PosPrinter, ".\\tmpPrint.print");
            try
            {
                File.Delete(".\\tmpPrint.print");
            }
            catch
            {

            }

        }


        public void printKOTreport(Invoicemaster kotMaster)
        {
            InvoiceRepository invrepo = new InvoiceRepository();
            Invoicemaster invoicemaster = invrepo.GetInvoice(kotMaster.InvoicemasterID);

            var Printer = invoicemaster.InvoiceDetails.Select(m => m.Product.Category.PrinterName).Distinct();


            foreach (var printer in Printer)
            {

                String PrinterIP = printer.ToString();
                List<InvoiceDetail> kotdetails = invoicemaster.InvoiceDetails.Where(m => m.Product.Category.PrinterName == PrinterIP).ToList();

                PrinterUtility.EscPosEpsonCommands.EscPosEpson obj = new PrinterUtility.EscPosEpsonCommands.EscPosEpson();
                var BytesValue = Encoding.ASCII.GetBytes(string.Empty);
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Separator());
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.CharSize.DoubleHeight2());
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.FontSelect.FontA());
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Alignment.Center());
                BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.ASCII.GetBytes(kotMaster.StoreName + "\n"));
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.CharSize.Nomarl());
                BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.ASCII.GetBytes(kotMaster.StoreAddress + "\n"));
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.CharSize.Nomarl());
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Separator());
                BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.ASCII.GetBytes("KOT\n"));
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Alignment.Left());
                BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.ASCII.GetBytes("" + kotMaster.InvoiceNum + "\n"));
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Alignment.Left());
                BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.ASCII.GetBytes(" " + kotMaster.CustomerName + "\n"));

                BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.ASCII.GetBytes("" + kotMaster.InvoiceDate+ "     Cashier  :" + kotMaster.Cashier.Trim() + "\n"));
                BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.ASCII.GetBytes("Itm                             Qty \n"));
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Separator());
                foreach (InvoiceDetail kotdetail in kotdetails)
                {

                    BytesValue = PrintExtensions.AddBytes(BytesValue, string.Format("{0,-35}{1,6}\n", kotdetail.Product.ProductName, kotdetail.Qty));


                }



                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Alignment.Right());
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Separator());
                BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.ASCII.GetBytes("Total\n"));
                BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.ASCII.GetBytes(kotMaster.InvoiceDetails.Count() + " Items \n"));
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Separator());
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Alignment.Left());
                BytesValue = PrintExtensions.AddBytes(BytesValue, CutPage());
                if (File.Exists(".\\tmpPrint.print"))
                    File.Delete(".\\tmpPrint.print");
                File.WriteAllBytes(".\\tmpPrint.print", BytesValue);

                try
                {
                    IpPrint print = new IpPrint();
                    print.PrinttoIP(PrinterIP, ".\\tmpPrint.print");
                }
                catch (Exception)
                {
                    MessageBox.Show("Error on KOT Printer So Printing on receipt Printer ");
                    RawPrinterHelper.SendFileToPrinter(Program.MySettingViewModal.MyPrinterDetails.PosPrinter, ".\\tmpPrint.print");
                }
                // 
                try
                {
                    File.Delete(".\\tmpPrint.print");
                }
                catch
                {

                }
            }



        }

    }
}
