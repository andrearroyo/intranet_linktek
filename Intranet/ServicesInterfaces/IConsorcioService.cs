using Models_core;

namespace Intranet.ServicesInterfaces
{
    public interface IConsorcioService
    {
        Task<List<Consorcio>> GetAll();
        Task<Consorcio> GetByID(int id);
        bool Insertar(Consorcio consorcio);
        bool Update(Consorcio consorcio);
        bool Delete(int id);
    }
}
