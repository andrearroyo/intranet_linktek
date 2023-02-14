using Models_core;

namespace Intranet.ServicesInterfaces.Planes
{
    public interface IPaqueteService
    {
        Task<List<Paquete>> GetAll();
        Task<Paquete> GetByID(int id);
        bool Insertar(Paquete item);
        bool Update(Paquete item);
        bool Delete(int id);
    }
}
