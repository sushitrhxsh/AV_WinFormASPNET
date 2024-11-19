
namespace AWF.Services.Interfaces
{
    public interface ICorreoService
    {
        Task Enviar(string para, string asunto, string msjHtml);
    }
}