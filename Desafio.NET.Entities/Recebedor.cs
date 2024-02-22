using System.ComponentModel.DataAnnotations;

namespace Desafio.NET.Entities
{
    public class Recebedor
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Saldo { get; set; }
        public Chave Chave { get; set; }
    }
}
