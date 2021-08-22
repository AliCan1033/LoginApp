using System;
using System.Threading.Tasks;
using Api.DTO;
using Api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{

    public class UserController : BaseController
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        public UserController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;

        }

        [HttpPost]
        [Route("Register")]
        //Post: /api/User/Register
        public async Task<Object> PostApplicationUser(UserDTO model){
            
            var applicationUser = new ApplicationUser(){
                UserName = model.UserName,
                Email = model.Email,
                FullName = model.FullName
            };
            try
            {
                var result = await _userManager.CreateAsync(applicationUser,model.Password);
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                
                throw ex;
            }
        }
        
    }
}