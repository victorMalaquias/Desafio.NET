using Desafio.NET.Infrastructurie;
using System.ComponentModel.DataAnnotations;

namespace Desafio.NET.Entities
{
    public class Chave
    {
        [Key]
        public int Id { get; set; }
        public TipoChave TipoChave { get; set; }
        public string Descricao { get; set; }
    }
}
