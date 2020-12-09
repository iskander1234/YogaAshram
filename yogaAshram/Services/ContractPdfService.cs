using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PdfSharpCore.Drawing;
using PdfSharpCore.Drawing.Layout;
using PdfSharpCore.Fonts;
using PdfSharpCore.Pdf;
using yogaAshram.Models;

namespace yogaAshram.Services
{
    public class ContractPdfService
    {
        private readonly YogaAshramContext _db;

        public ContractPdfService(YogaAshramContext db)
        {
            _db = db;
        }

        public IActionResult RenderPdfDocument(long clientId)
        {
            Client client = _db.Clients.FirstOrDefault(c => c.Id == clientId && c.Id == clientId);
            MyFontResolver.Apply();
            PdfDocument document = new PdfDocument();

            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);
            double x = 50, y = 100;
            XFont fontH1 = new XFont("Arial", 18, XFontStyle.Bold);
            XFont font = new XFont("Arial", 11, XFontStyle.Bold);
            XFont fontRegular = new XFont("Arial", 11);
            double ls = 10;

            gfx.DrawString("",
                fontH1, XBrushes.Black, x, x);

            if (client != null)
            {
                gfx.DrawString($"Я, {client.NameSurname},",
                    fontRegular, XBrushes.Black, x, y);
               
                y += 20 + 2 * ls;
                gfx.DrawString("настоящим подтверждаю, что с Правилами посещения и условиями абонемента йога-центра",
                    font, XBrushes.Black, x, y);
                y += ls;
                gfx.DrawString("Classical Yoga Ashram ознакомлен и согласен. В дальнейшем иметь претензий не буду.",
                    font, XBrushes.Black, x, y);
                y += 20 + 2 * ls;
                gfx.DrawString("Информация о практикующем:", fontH1, XBrushes.Black, x += 115, y);
                y += 20 + 2 * ls;
                if(client.WorkPlace != null)
                 gfx.DrawString($"Место работы и должность: {client.WorkPlace}", fontRegular, XBrushes.Black,
                    x -= 110, y);
                else
                    gfx.DrawString($"", fontRegular, XBrushes.Black,
                        x -= 110, y);
                
                y += 5 + 2 * ls;
                gfx.DrawString($"Моб. тел.: {client.PhoneNumber}", fontRegular, XBrushes.Black, x, y);
                y += 5 + 2 * ls;
                gfx.DrawString($"Дата рождения: {client.DateOfBirth.ToString("dd MMMM yyyy")} г.", fontRegular,
                    XBrushes.Black, x, y);
                y += 5 + 2 * ls;
                gfx.DrawString($"E-mail: {client.Email}", fontRegular, XBrushes.Black, x, y);
                y += 5 + 2 * ls;
                gfx.DrawString($"Наличие заболеваний: {client.Sickness.Name}", fontRegular, XBrushes.Black, x, y);
                y += 20 + 2 * ls;
                gfx.DrawString($"Дата: {DateTime.Now:dd.MM.yyyy} г.", font, XBrushes.Black, x, y);
                gfx.DrawString("Подпись: ______________", font, XBrushes.Black, x += 300, y);
            }
            else
            {
                y += 20 + 2 * ls;
                gfx.DrawString($"Нет никакого клиента", fontRegular, XBrushes.Black, x, y);
            }


            MemoryStream stream = new MemoryStream();
            document.Save(stream);
            stream.Position = 0;
            FileStreamResult fileStreamResult = new FileStreamResult(stream, "application/pdf");
            fileStreamResult.FileDownloadName = $"{client.NameSurname}.pdf";
            return fileStreamResult;



            // string filename = $"Files/contract.pdf";
            // document.Save(filename);
            //
            // var fileStream = new FileStream(filename, 
            //     FileMode.Open,
            //     FileAccess.Read
            // );
            // var fsResult = new FileStreamResult(fileStream, "application/pdf");
            // return fsResult;

        }

        class MyFontResolver : IFontResolver
        {
            public FontResolverInfo ResolveTypeface(string familyName, bool isBold, bool isItalic)
            {
                // Ignore case of font names.
                var name = familyName.ToLower().TrimEnd('#');

                // Deal with the fonts we know.
                switch (name)
                {
                    case "arial":
                        if (isBold)
                        {
                            if (isItalic)
                                return new FontResolverInfo("Arial#bi");
                            return new FontResolverInfo("Arial#b");
                        }

                        if (isItalic)
                            return new FontResolverInfo("Arial#i");
                        return new FontResolverInfo("Arial#");
                }

                // We pass all other font requests to the default handler.
                // When running on a web server without sufficient permission, you can return a default font at this stage.
                return PlatformFontResolver.ResolveTypeface(familyName, isBold, isItalic);
            }

            /// <summary>
            /// Return the font data for the fonts.
            /// </summary>
            public byte[] GetFont(string faceName)
            {
                switch (faceName)
                {
                    case "Arial#":
                        return FontHelper.Arial;

                    case "Arial#b":
                        return FontHelper.ArialBold;

                    case "Arial#i":
                        return FontHelper.ArialItalic;

                    case "Arial#bi":
                        return FontHelper.ArialBoldItalic;
                }

                return null;
            }

            public string DefaultFontName { get; }


            internal static MyFontResolver OurGlobalFontResolver = null;

            /// <summary>
            /// Ensure the font resolver is only applied once (or an exception is thrown)
            /// </summary>
            internal static void Apply()
            {
                if (OurGlobalFontResolver == null || GlobalFontSettings.FontResolver == null)
                {
                    if (OurGlobalFontResolver == null)
                        OurGlobalFontResolver = new MyFontResolver();

                    GlobalFontSettings.FontResolver = OurGlobalFontResolver;
                }
            }
        }


        /// <summary>
        /// Helper class that reads font data from embedded resources.
        /// </summary>
        public static class FontHelper
        {
            public static byte[] Arial
            {
                get { return LoadFontData("yogaAshram.fonts.arial.arial.ttf"); }
            }

            public static byte[] ArialBold
            {
                get { return LoadFontData("yogaAshram.fonts.arial.arialbd.ttf"); }
            }

            public static byte[] ArialItalic
            {
                get { return LoadFontData("yogaAshram.fonts.arial.ariali.ttf"); }
            }

            public static byte[] ArialBoldItalic
            {
                get { return LoadFontData("yogaAshram.fonts.arial.arialbi.ttf"); }
            }

            /// <summary>
            /// Returns the specified font from an embedded resource.
            /// </summary>
            static byte[] LoadFontData(string name)
            {
                var assembly = Assembly.GetExecutingAssembly();

                // Test code to find the names of embedded fonts
                //var ourResources = assembly.GetManifestResourceNames();

                using (Stream stream = assembly.GetManifestResourceStream(name))
                {
                    if (stream == null)
                        throw new ArgumentException("No resource with name " + name);

                    int count = (int) stream.Length;
                    byte[] data = new byte[count];
                    stream.Read(data, 0, count);
                    return data;
                }
            }
        }
    }
}