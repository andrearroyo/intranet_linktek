using Models_core;

namespace Intranet.ServicesInterfaces.Planes
{
    public interface IPaqueteSistemaService
    {
        Task<List<PaqueteSistema>> GetAllPaqueteSistema();
        bool Insertar(PaqueteSistema item);
        bool Update(PaqueteSistema item);
        bool Delete(int id);
    }
}
