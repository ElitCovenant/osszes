using KonyvtarBackEnd.Dto;
using KonyvtarBackEnd.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KonyvtarBackEnd.Controllers
{
    [ApiController]
    [Route("/User")]
    public class UserController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<FelhasznaloDto>> Post(CreateFelhasznaloDto createFelhasznaloDto)
        {
            try
            {
                var UjFelhasznalo = new User
                {
                    MembershipStart = createFelhasznaloDto.MembershipStart,
                    MembershipEnd = createFelhasznaloDto.MembershipEnd,
                    Usarname = createFelhasznaloDto.UserName,
                    Hash = BCrypt.Net.BCrypt.HashPassword(createFelhasznaloDto.Hash),
                    IdRule = createFelhasznaloDto.Id_Rule,
                    IdAccountImg = createFelhasznaloDto.Id_Account_Image
                };
                using (var context = new KonyvtarDbContext())
                {
                    if (context != null)
                    {
                        context.Users.Add(UjFelhasznalo);
                        context.SaveChanges();

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

        [HttpGet]
        public async Task<ActionResult<FelhasznaloDto>> GetAll()
        {
            try
            {
                using (var context = new KonyvtarDbContext())
                {
                    if (context != null)
                    {
                        return Ok(context.Users.Select(x => new { x.Id, x.MembershipStart, x.MembershipEnd, x.Usarname, x.IdRule, x.IdAccountImg }).ToList());
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

        [HttpGet("{id}")]
        public async Task<ActionResult<FelhasznaloDto>> Get(int id)
        {
            try
            {
                using (var context = new KonyvtarDbContext())
                {
                    var kerdezett = context.Users.FirstOrDefault(x => x.Id == id);

                    if (context != null)
                    {
                        if (kerdezett != null)
                        {
                            return Ok(kerdezett);
                        }
                        else
                        {
                            return StatusCode(404, "A keresett felhasználó nem létezik, vagy nincs eltárolva");
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

        [HttpPut("{id}"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<FelhasznaloDto>> Put(int id, ModifyFelhasznaloDto modifyFelhasznaloDto)
        {
            try
            {
                using (var context = new KonyvtarDbContext())
                {
                    if (context != null)
                    {
                        var valtoztatando = context.Users.FirstOrDefault(x => x.Id == id);
                        if (valtoztatando != null)
                        {
                            valtoztatando.MembershipStart = modifyFelhasznaloDto.MembershipStart;
                            valtoztatando.MembershipEnd = modifyFelhasznaloDto.MembershipEnd;
                            valtoztatando.Usarname = modifyFelhasznaloDto.UserName;
                            valtoztatando.IdRule = modifyFelhasznaloDto.Id_Rule;
                            valtoztatando.IdAccountImg = modifyFelhasznaloDto.Id_Account_Image;

                            try
                            {
                                context.Users.Update(valtoztatando);
                                context.SaveChanges();
                            }
                            catch (Exception e)
                            {
                                return BadRequest("Hiba lépett fel! : " + e.Message);
                            }

                            return Ok("Sikeres adatváltoztatás!");
                        }
                        else
                        {
                            return StatusCode(404, "A keresett felhasználó nem létezik, vagy nincs eltárolva");
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

        [HttpPut("/jelszovaltas/{id}")]
        public async Task<ActionResult<ModifyJelszo>> Jelszovaltas(int id, ModifyJelszo modifyJelszo)
        {
            try
            {
                using (var context = new KonyvtarDbContext())
                {
                    if (context != null)
                    {
                        var valtoztatando = context.Users.FirstOrDefault(x => x.Id == id);
                        if (valtoztatando != null)
                        {
                            valtoztatando.Hash = BCrypt.Net.BCrypt.HashPassword(modifyJelszo.Hash);
                            context.Users.Update(valtoztatando);
                            context.SaveChanges();
                            return Ok("Sikeres adatváltoztatás!");
                        }
                        else
                        {
                            return StatusCode(404, "A keresett felhasználó nem létezik, vagy nincs eltárolva");
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

        [HttpPut("/profilkepvaltas/{id}")]
        public async Task<ActionResult<FelhasznaloDto>> Profilkepvaltas(int id, int profId)
        {
            try
            {
                using (var context = new KonyvtarDbContext())
                {
                    if (context != null)
                    {
                        var valtoztatando = context.Users.FirstOrDefault(x => x.Id == id);
                        if (valtoztatando != null)
                        {
                            valtoztatando.IdAccountImg = profId;
                            context.Users.Update(valtoztatando);
                            context.SaveChanges();
                            return Ok("Sikeres adatváltoztatás!");
                        }
                        else
                        {
                            return StatusCode(404, "A keresett felhasználó nem létezik, vagy nincs eltárolva");
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

        [HttpDelete("{id}")]
        public async Task<ActionResult<FelhasznaloDto>> Delete(int id)
        {
            try
            {
                using (var context = new KonyvtarDbContext())
                {
                    var kerdezett = context.Users.FirstOrDefault(x => x.Id == id);

                    if (context != null)
                    {
                        if (kerdezett != null)
                        {
                            context.Users.Remove(kerdezett);
                            context.SaveChanges();
                            return Ok("A felhasználó eltávolítása sikeresen megtörtént");
                        }
                        else
                        {
                            return StatusCode(404, "A keresett kiadó eddig sem létezett, vagy nem volt eltárolva");
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
    }
}
