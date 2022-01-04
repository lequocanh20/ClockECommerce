using clockECommerce.ViewModels.Common;
using clockECommerce.ViewModels.System.Roles;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace clockECommerce.ApiIntegration
{
    public interface IRoleApiClient
    {
        Task<ApiResult<List<RoleViewModel>>> GetAll();
    }
}
