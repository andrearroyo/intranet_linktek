using Models_core;

namespace Intranet.ServicesInterfaces
{
    public interface ISalaService
    {
        Task<List<Sala>> GetAll();
        Task<Sala> GetByID(int id);
        bool Insertar(Sala sala);
        bool Update(Sala sala);
        bool Delete(int id);
    }
}
