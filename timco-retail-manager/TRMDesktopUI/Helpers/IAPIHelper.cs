using System.Threading.Tasks;
using TRMDesktopUI.Models;

namespace TRMDesktopUI.Helpers
{
    public interface IAPIHelper
    {
        Task<AuthenticatedUser> Authenticate(string usename, string password);
    }
}