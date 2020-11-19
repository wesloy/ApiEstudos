using System;
using System.ComponentModel.DataAnnotations;

//Todas as tabelas que receberem esta classe terá os campos dessa tabela como seus campos

namespace Api.Domain.Entities
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }

        private DateTime? _createAt;
        public DateTime? CreateAt
        {
            get { return _createAt; }
            set { _createAt = (value == null ? DateTime.UtcNow : value); }
        }

        public DateTime? UpadateAt { get; set; }


    }
}
