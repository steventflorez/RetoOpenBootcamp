using FacturasApi.DTOs;
using FacturasApi.Models;

namespace FacturasApi.Services
{
    public interface ILoginService
    {
        IEnumerable<Usuario> GetUserNameAndPassword(Usuario usuario, LoginUserCreacionDTO loginUserCreacionDTO);
    }
}
