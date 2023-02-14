using Models_core;

namespace Intranet.ServicesInterfaces.Planes
{
    public interface ISistemaService
    {
        Task<List<Sistema>> GetAll();
        Task<Sistema> GetByID(int id);

        List<Sistema> GetAllPaquete(int idPaquete);
        bool Insertar(Sistema sala);
        bool Update(Sistema sala);
        bool Delete(int id);
    }
}
