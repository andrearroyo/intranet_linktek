using Models_core;

namespace Intranet.ServicesInterfaces.Planes
{
    public interface ILicenciaService
    {
        Task<List<Licencia>> GetAll();
        Task<Licencia> GetByIDs(int idPaquete, int idSala);
        Task<Licencia> GetLicenciaRemota(int idPaquete, int idSala, DateTime date);
        bool Insert(Licencia item);
    }
}
