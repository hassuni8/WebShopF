using System.Linq;
using Core.DomainServices;
using Core.Entity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Infrastructure.SQL;
using Infrastructure.SQL.Repositories;
using Microsoft.AspNetCore.Mvc;



namespace WebShopFruit.Controllers
{

    [Route("/token")]
    public class TokenController : Controller
    {
        private IUser<User> _repo;
        private IAuthenticationHelper _authenticationHelper;

        public TokenController(IUser<User> repo, IAuthenticationHelper authService)
        {
            _repo = repo;
            _authenticationHelper = authService;
        }


        [HttpPost]
        public IActionResult Login([FromBody] LoginInputModel model)
        {
            var user = _repo.getAll().FirstOrDefault(u => u.UserName == model.Username);
            if (user == null)
            {
                return Unauthorized();
            }

            if (!_authenticationHelper.VerifyPasswordHash(model.Password, user.PassWordHash, user.PaswordSalt))
            {
                return Unauthorized();
            }
            
            return Ok( 
                new
                {
                    username = user.UserName,
                    token = _authenticationHelper.GenerateToken(user)
                }
                );

        }


    }
}
        
        

