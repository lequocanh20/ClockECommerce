using clockECommerce.ViewModels.Common;

namespace clockECommerce.ViewModels.System.Users
{
    public class GetUserPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
    }
}
