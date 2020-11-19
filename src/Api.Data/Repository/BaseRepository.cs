using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {


        //Variável protegida e interna ao método, facilita a reutilização dentro da classe
        protected readonly MyContext _context;
        private DbSet<T> _dataset;


        public BaseRepository(MyContext context)
        {
            //Construtor 
            _context = context;
            _dataset = _context.Set<T>();
        }
        public async Task<bool> DeletetAsync(Guid id)
        {
            try
            {
                var result = await _dataset.SingleOrDefaultAsync(
                                        p => p.Id.Equals(id)
                );

                if (result != null)
                {
                    _dataset.Remove(result);
                    await _context.SaveChangesAsync();

                }
                else
                {
                    return false;
                }

                return true;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<bool> ExistAsync(Guid id)
        {
            return await _dataset.AnyAsync(
                p => p.Id.Equals(id)
            );
        }

        public async Task<T> InsertAsync(T item)
        {
            try
            {
                //Se o guid (id) é vazio o Entity fornece um novo
                if (item.Id == Guid.Empty)
                {
                    item.Id = Guid.NewGuid();
                }

                item.CreateAt = DateTime.UtcNow;
                _dataset.Add(item);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return item; //devolvendo o item criado
        }
        public async Task<T> SelectAsync(Guid id)
        {
            try
            {
                return await _dataset.SingleOrDefaultAsync(
                         p => p.Id.Equals(id));

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<IEnumerable<T>> SelectAsync()
        {
            try
            {
                return await _dataset.ToListAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task<T> UpdatetAsync(T item)
        {
            try
            {

                //procurando um item específico ou trazendo nulo
                var result = await _dataset.SingleOrDefaultAsync(
                                            p => p.Id.Equals(item.Id));


                if (result != null)
                {
                    item.UpadateAt = DateTime.UtcNow;
                    item.CreateAt = result.CreateAt; //garantindo que não seja alterada externamente

                    _context.Entry(result).CurrentValues.SetValues(item); //comparando os dados e atualizando
                    await _context.SaveChangesAsync(); //salvando no BD

                }
                else
                {
                    return null;
                }



            }
            catch (Exception ex)
            {
                throw ex;
            }

            return item; //devolvendo o item já atualizado

        }
    }
}
