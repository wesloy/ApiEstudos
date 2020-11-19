using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Services.User
{
    public interface IUserService
    {
        Task<UserEntity> Get(Guid id); //Registro específico
        Task<IEnumerable<UserEntity>> GetAll(); //Lista de registros
        Task<UserEntity> Post(UserEntity user); //escrever no BD um registro
        Task<UserEntity> Put(UserEntity user); //atualizar no BD um registro
        Task<bool> Delete(Guid id); //Deleção de um registro
    }
}
