using KonyvtarBackEnd.Dto;
using KonyvtarBackEnd.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace KonyvtarBackEnd.Controllers
{
    [ApiController]
    [Route("/interactions")]
    //the interactions name can be renamed if you don't like it
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public LoginController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPut("/Register"),Authorize(Roles = "Admin")]
        public ActionResult<RegisterDto> Register(RegisterDto registerDto)
        {
            var UjFelhasznalo = new User
            {
                MembershipStart = DateTime.Now,
                MembershipEnd = DateTime.Now.AddYears(4),
                Usarname = registerDto.UserName,
                Hash = BCrypt.Net.BCrypt.HashPassword(registerDto.Hash)
            };
            using (var context = new KonyvtarDbContext())
            {
                if (context != null)
                {
                    try
                    {
                        context.Users.Add(UjFelhasznalo);
                        context.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        return BadRequest("Hiba lépett fel : " + e.Message);
                    }
                    
                    return StatusCode(201, "Az adatok sikeresen eltárolva!");
                }
                else
                {
                    return StatusCode(406, "Nem megfeleő az adat formátuma!");
                }
            }
        }

        [HttpPost("/Login")]
        public ActionResult<LoginDto> Login(LoginDto loginDto)
        {
            using (var context = new KonyvtarDbContext())
            {
                if (context != null)
                {
                    var kerdezett = context.Users.FirstOrDefault(x => x.Usarname == loginDto.UserName);
                    if (kerdezett != null)
                    {
                        if (!BCrypt.Net.BCrypt.Verify(loginDto.Hash, kerdezett.Hash))
                        {
                            return StatusCode(406, "Hibás adatok!");
                        }
                        else
                        {
                            string token = CreateToken(kerdezett);
                            kerdezett.Token = token;
                            context.Users.Update(kerdezett);
                            context.SaveChanges();
                            Token Troken = new Token();
                            Troken.Troken = token;
                            return Ok(Troken);
                        }

                    }
                    else
                    {
                        return StatusCode(404, "Nem létezik ilyen felhasználó!");
                    }
                }
                else
                {
                    return StatusCode(503, "A szerver jelenleg nem elérhető");
                }
            }
        }

        private string CreateToken(User user)
        {
            using (var context = new KonyvtarDbContext())
            {
                List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Role,context.Rules.FirstOrDefault(x=>x.Id==user.IdRule).Name),
                new Claim(ClaimTypes.Email,user.Usarname),
                new Claim(ClaimTypes.Actor,user.IdAccountImg.ToString()),
                new Claim(ClaimTypes.Dns,user.Id.ToString()),

            };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value!));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

                var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    audience: _configuration.GetValue<string>("Authentication:Schemes:Bearer:ValidAudiences:0"),
                    issuer : _configuration.GetSection("Authentication:Schemes:Bearer:ValidIssuer").Value,
                    signingCredentials: creds);
                var jwt = new JwtSecurityTokenHandler().WriteToken(token);
                
                return jwt;
            }
        }
    }
    
}
