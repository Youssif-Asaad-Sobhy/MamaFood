﻿using Azure.Identity;
using MamaFood.API.Domain.Entities;
using MamaFood.API.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MamaFood.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _config;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public AccountController(UserManager<ApplicationUser> userManager, IConfiguration config,
           SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _config = config;
            _signInManager = signInManager;
        }
        private async Task<JwtSecurityToken> CreateToken(ApplicationUser user)
        {
            #region claims
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, user.UserName));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            #endregion

            #region get roles
            var roles = await _userManager.GetRolesAsync(user);
            foreach (var role in roles)
                claims.Add(new Claim(ClaimTypes.Role, role));
            #endregion

            #region sign-in credintials
            SecurityKey securityKey =
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Secret"]));
            SigningCredentials signingCred = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            #endregion

            #region create token
            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _config["JWT:Issuer"],
                audience: _config["JWT:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: signingCred
            );
            #endregion

            return token;
        }
        [HttpPost("Register")]
        public async Task<IActionResult>Register([FromBody] ResgisterUseDTO Model)
        {
            if (await _userManager.FindByNameAsync(Model.UserName) != null)
                return StatusCode(StatusCodes.Status400BadRequest, new { status = "Error", Message = "User Name Already Exist" });
            ApplicationUser newUser = new ApplicationUser()
            {
                UserName = Model.UserName,
                NID = Model.NID,
                Name = Model.Name,
                Description = Model.Description,
                SecurityStamp = Guid.NewGuid().ToString(),
            };
            var result = await _userManager.CreateAsync(newUser, Model.Password);
            if(!result.Succeeded)
                return BadRequest(result.Errors);
            await _userManager.AddToRoleAsync(newUser, Model.Role);
            var token = await CreateToken(newUser);

            return StatusCode(StatusCodes.Status200OK,
              new{status = "Success", Message = $"Account Created Successfully \nWelcome{Model.UserName}\n",
              Token = new JwtSecurityTokenHandler().WriteToken(token),
                  expiration = DateTime.Now.AddMinutes(20)});
        }

        [HttpPost("LogIn")]
        public async Task<IActionResult> LogIn([FromBody] LogInUserDTO Model)
        {
            ApplicationUser result = await _userManager.FindByNameAsync(Model.UserName);
            if (result == null || !await _userManager.CheckPasswordAsync(result, Model.Password))
                return StatusCode(StatusCodes.Status400BadRequest, new { status = "Error", Message = "InCorrect UserName Or Password" });
            var token = await CreateToken(result);
            return StatusCode(StatusCodes.Status200OK, new { status = "Success", Message = $"Welcome Back, {result.UserName}", Token = new JwtSecurityTokenHandler().WriteToken(token), expiration = DateTime.Now.AddMinutes(30), });
        }

        [HttpPut("Change Password")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDTO Model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var CurrentUser = await _userManager.FindByNameAsync(User.Identity.Name);
            var result = await _userManager.ChangePasswordAsync(CurrentUser, Model.OldPassword, Model.NewPassword);
            if(!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }
            await _signInManager.RefreshSignInAsync(CurrentUser);
            return Ok("Password Changed Successfully");
        }

    }
}