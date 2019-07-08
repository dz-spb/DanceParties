using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DanceParties.Interfaces.Services
{
    public interface IService<TModel>
    {
        Task<TModel> Get(int id);

        Task<List<TModel>> GetAll();

        Task<TModel> Add(TModel dance);

        Task Edit(int id, TModel dance);

        Task Delete(int id);
    }
}
