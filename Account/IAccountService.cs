using System.Threading.Tasks;

namespace ASP_pl.Account
{
    public interface IAccountService
    {
        UserRoles GetUserRoles(string userName);
    }
}