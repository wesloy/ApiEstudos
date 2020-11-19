using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;


//Interface é uma assinatura que preve que o método que receba ela
//tenha todas as implantações dos métodos abaixo

namespace Api.Domain.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        //Trabalhando com todos os retornos sincronos ou assicronos
        Task<T> InsertAsync(T item);
        Task<T> UpdatetAsync(T item);
        Task<bool> DeletetAsync(Guid id);
        Task<T> SelectAsync(Guid id);
        Task<IEnumerable<T>> SelectAsync();
        Task<bool> ExistAsync(Guid id);
    }

}
