using KonyvtarBackEnd.Dto;
using KonyvtarBackEnd.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Win32;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        [HttpPost("/Register"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<RegisterDto>> Register(RegisterDto registerDto)
        {
            try
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
                            await context.SaveChangesAsync();
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
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }

        }

        [HttpPost("/AOERegister"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<string>> AOERegister(Transfer transfer)
        {
            try
            {
                using (var context = new KonyvtarDbContext())
                {
                    if (context != null)
                    {
                        try
                        {
                            List<RegisterDto> registers = new List<RegisterDto>();
                            string[] data = transfer.transfer.Split(',');
                            foreach (string line in data)
                            {
                                registers.Add(new RegisterDto(line.Split(';')[0].Trim(),line.Split(';')[1].Trim()));
                            }
                            foreach (var user in registers)
                            {
                                var UjFelhasznalo = new User
                                {
                                    MembershipStart = DateTime.Now,
                                    MembershipEnd = DateTime.Now.AddYears(4),
                                    Usarname = user.UserName,
                                    Hash = BCrypt.Net.BCrypt.HashPassword(user.Hash)
                                };
                                await context.Users.AddAsync(UjFelhasznalo);
                                await context.SaveChangesAsync();
                            }
                            
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
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }

        }

        [HttpPost("/Login")]
        public async Task<ActionResult<LoginDto>> Login(LoginDto loginDto)
        {
            try
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
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
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
                new Claim(ClaimTypes.Dns,user.Id.ToString()),

            };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value!));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

                var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    audience: _configuration.GetValue<string>("Authentication:Schemes:Bearer:ValidAudiences:0"),
                    issuer: _configuration.GetSection("Authentication:Schemes:Bearer:ValidIssuer").Value,
                    signingCredentials: creds);
                var jwt = new JwtSecurityTokenHandler().WriteToken(token);

                return jwt;
            }
        }
    }

}
