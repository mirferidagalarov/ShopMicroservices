using Shop.Basket.LoginServices.Abstract;

namespace Shop.Basket.LoginServices.Concrete
{
    public class LoginService : ILoginService
    {
        private readonly IHttpContextAccessor _contextAccessor;
        public LoginService(IHttpContextAccessor httpContextAccessor)
        {
            _contextAccessor = httpContextAccessor; 
        }
        public string GetUserId => _contextAccessor.HttpContext.User.FindFirst("sub").Value;
    }
}
