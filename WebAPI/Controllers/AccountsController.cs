﻿using BOL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.Intrinsics.X86;
using System.Security.Claims;
using System.Text;
using WebAPI.ViewModels;

namespace WebAPI.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        IConfiguration configuration;
        SignInManager<LLUser> signInManager;
        UserManager<LLUser> userManager;

        public AccountsController(SignInManager<LLUser> _signInManager, UserManager<LLUser> _userManager, IConfiguration _configuration)
        {
            signInManager = _signInManager;
            userManager = _userManager;
            configuration = _configuration;
        }


        [HttpPost("logout")]

        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            return NoContent();
        }


        [HttpPost("login")]

        public async Task<IActionResult> Login(LoginViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = await userManager.FindByNameAsync(model.UserName);
                    var userResult = await signInManager.CheckPasswordSignInAsync(user, model.Password, false);
                    if (userResult.Succeeded)
                    {
                        var roles = await userManager.GetRolesAsync(user);

                        //step 1: Creating Claims
                        IdentityOptions identityOptions = new IdentityOptions();
                        var claims = new Claim[]
                        {
                            new Claim(identityOptions.ClaimsIdentity.UserIdClaimType, user.Id),
                            new Claim(identityOptions.ClaimsIdentity.UserNameClaimType, user.UserName),
                            new Claim(identityOptions.ClaimsIdentity.RoleClaimType, roles[0]),
                        };

                        //Step - 2: Create signingKey from Secretkey
                        var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("SS:JWTKey").Value));

                        //Step -3: Create signingCredentials from signingKey with HMAC algorithm
                        var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

                        //Step - 4: Create JWT with signingCredentials, IdentityClaims & expire duration.
                        var jwt = new JwtSecurityToken(signingCredentials: signingCredentials,
                                                        expires: DateTime.Now.AddMinutes(30), claims: claims);

                        //Step - 5: Finally write the token as response with OK().
                        return Ok(new { tokenJwt = new JwtSecurityTokenHandler().WriteToken(jwt), id = user.Id, userName = user.UserName, role = roles[0] });



                    }
                    else
                    {
                        return BadRequest("Invalid Username or Password");
                    }
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception e)
            {
                var msg = (e.InnerException != null) ? (e.InnerException.Message) : (e.Message);

                return StatusCode(500, "Internal Server Error" + msg);
            }
        }

        [HttpPost("register"), DisableRequestSizeLimit]

        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            try
            {

               // RegisterViewModel model = JsonConvert.DeserializeObject<RegisterViewModel>(Request.Form["myModel"].ToString());

                if (ModelState.IsValid)
                {
                    var user = new LLUser()
                    {
                        UserName = model.UserName,
                        Email = model.Email

                    };

                    var userResult = await userManager.CreateAsync(user, model.Password);
                    if (userResult.Succeeded)
                    {
                        var roleResult = await userManager.AddToRoleAsync(user, "User");

                        if (roleResult.Succeeded)
                        {
                            //if (Request.Form.Files.Count > 0)
                            //{
                            //    var filePath = Path.GetFullPath("~/ProfilePics/" + user.Id + ".jpeg").Replace("~\\", "");

                            //    using (var stream = new FileStream(filePath, FileMode.Create))
                            //    {
                            //        Request.Form.Files[0].CopyTo(stream);

                            //    }
                            //}
                            return Ok(user);

                        }
                        else
                        {
                            return BadRequest(roleResult.Errors);
                        }
                    }
                    else
                    {
                        return BadRequest(userResult.Errors);
                    }
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception e)
            {
                var msg = (e.InnerException != null) ? (e.InnerException.Message) : (e.Message);

                return StatusCode(500, "Admin is working on it " + msg);
            }
        }

    }
}
