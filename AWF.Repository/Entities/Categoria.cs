
namespace AWF.Repository.Entities
{
    public class Categoria
    {
        public int IdCategoria { get; set; }
        public string Nombre { get; set; }
        public Medida RefMedida { get; set; }
        public int Activo { get; set; }
    }
}