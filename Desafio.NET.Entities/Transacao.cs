using System.ComponentModel.DataAnnotations;

namespace Desafio.NET.Entities
{
    public class Transacao
    {
        [Key]
        public int Id { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataTransacao { get; set; }
        public Pagador Pagador { get; set; }
        public Recebedor Recebedor { get; set; }
    }
}
