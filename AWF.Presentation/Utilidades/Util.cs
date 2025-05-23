﻿using System.Security.Cryptography;
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
            // Convertir una cadena a un array de bytes y calcular el hash
            byte[] bytes = SHA256.HashData(Encoding.UTF8.GetBytes(text));

            // Construir el string en hash
            var builder = new StringBuilder();
            foreach (byte b in bytes)
            {
                builder.Append(b.ToString("x2"));
            }

            return builder.ToString();
        }

        [Obsolete]
        public static byte[] GeneratePDFVenta(Negocio oNegocio, Venta oVenta, Stream imageLogo)
        {
            QuestPDF.Settings.License = LicenseType.Community;

            var arrayPDF = Document.Create(document => 
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

                            foreach(DetalleVenta item in oVenta.RefDetalleVenta!)
                            {
                                decimal cantidad = Convert.ToDecimal(item.Cantidad) / Convert.ToDecimal(item.RefProducto?.RefCategoria?.RefMedida?.Valor);
                                string abreviatura = item.RefProducto?.RefCategoria?.RefMedida?.Abreviatura!;

                                table.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9").Padding(2).Text(item.RefProducto!.Descripcion).FontSize(10);
                                table.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9").Padding(2).Text($"{oNegocio.SimboloMoneda} {item.PrecioVenta.ToString("0.00")}").FontSize(10);
                                table.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9").Padding(2).Text($"{cantidad.ToString()} {abreviatura}").FontSize(10);
                                table.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9").Padding(2).Text($"{oNegocio.SimboloMoneda} {item.PrecioTotal}").FontSize(10);
                            }
                        });

                        col.Item().AlignRight().Text($"{oNegocio.SimboloMoneda} {oVenta.PrecioTotal.ToString("0.00")}").FontSize(10);

                    });

                    page.Footer().AlignRight().Text(txt => {
                        txt.Span("Pagina").FontSize(10);
                        txt.CurrentPageNumber().FontSize(10);
                        txt.Span(" de ").FontSize(10);
                        txt.TotalPages().FontSize(10);
                    });
                });
            })
            .GeneratePdf();

            return arrayPDF;
        }

    }
}
