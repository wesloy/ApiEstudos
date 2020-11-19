namespace Api.Domain.Entities
{
    //Nome da tabela com o sufixo Entity
    public class UserEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
