using Models_core;

namespace Intranet.ServicesInterfaces
{
    public interface IEmpresaService
    {
        Task<List<Empresa>> GetAll();
        Task<Empresa> GetByID(int id);
        bool Insertar(Empresa item);
        bool Update(Empresa item);
        bool Delete(int id);
    }
}
