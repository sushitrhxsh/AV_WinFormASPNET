using System.Security.Cryptography;
using System.Text;
using AWF.Repository.Entities;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

namespace AWF.Presentation.Utilidades
{
    public static class Util
    {

        public static string GenerateCode()
        {
            string guid = Guid.NewGuid().ToString("N").Substring(0,6);
            return guid;
        }

        public static string ConvertToSha256(string text)
        {
            // Crear la instancia sha256
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Convertit una cadena a un array de bytes
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(text));

                // Contruir el string en hash
                StringBuilder builder = new StringBuilder();
                for(int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }

        /*public static byte[] GeneratePDFVenta(Negocio oNegocio, Venta oVenta, Stream imageLogo)
        {
            QuestPDF.Settings.License = LicenseType.Community;

            Document.Create(document => 
            {
                document.Page(page => {
                    page.Margin(30);

                    page.Header().ShowOnce().Row(row => {
                        row.AutoItem().Height(60).Image(imageLogo, ImageScaling.FitArea);

                        row.RelativeItem().Column(col => 
                        {
                            col.Item().AlignCenter().Text(oNegocio.RazonSocial).Bold().FontSize(14);
                            col.Item().AlignCenter().Text(oNegocio.Direccion).FontSize(9);
                            col.Item().AlignCenter().Text(oNegocio.NumCelular).FontSize(9);
                            col.Item().AlignCenter().Text(oNegocio.Correo).FontSize(9);
                        });

                        row.ConstantItem(140).Column(col => 
                        {
                            col.Item().Border(1).BorderColor("#634883").AlignCenter().Text($"RFC {oNegocio.RFC}");
                            col.Item().Background("#634883").Border(1).BorderColor("#634883").AlignCenter().Text("Boleta de venta").FontColor("#fff");
                            col.Item().Border(1).BorderColor("#634883").AlignCenter().Text(oVenta.NumeroVenta);
                        });
                    });

                    page.Content().PaddingVertical(15).Column(col => {
                        col.Spacing(10);
                        col.Item().LineHorizontal(0.5f);
                        
                        col.Item().Row(row => 
                        {
                            row.RelativeItem().Text(txt => {
                                txt.Span("Cliente:").SemiBold().FontSize(10);
                                txt.Span(oVenta.NombreCliente).FontSize(10);
                            });

                            row.RelativeItem().Text(txt => {
                                txt.Span("Fecha Emision:").SemiBold().FontSize(10);
                                txt.Span(oVenta.FechaRegistro).FontSize(10);
                            });
                        });

                        col.Item().LineHorizontal(0.5f);
                        col.Item().Table(table => 
                        {
                            table.ColumnsDefinition(columns => {
                                columns.RelativeColumn(3);
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                            });

                            table.Header(header => {
                                header.Cell().Background("#634883").Padding(2).Text("Producto").FontColor("#fff");
                                header.Cell().Background("#634883").Padding(2).Text("Precio").FontColor("#fff");
                                header.Cell().Background("#634883").Padding(2).Text("Cantidad").FontColor("#fff");
                                header.Cell().Background("#634883").Padding(2).Text("Total").FontColor("#fff");
                            });

                        });

                    });

                });
            });

        }*/

    }
}
