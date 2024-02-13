using KonyvtarBackEnd.Dto;
using KonyvtarBackEnd.Models;
using Microsoft.AspNetCore.Mvc;

namespace KonyvtarBackEnd.Controllers
{
    [ApiController]
    [Route("/User")]
    public class UserController : ControllerBase
    {
        [HttpPost]
        public ActionResult<FelhasznaloDto> Post(CreateFelhasznaloDto createFelhasznaloDto)
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

        [HttpGet]
        public ActionResult<FelhasznaloDto> GetAll()
        {
            using (var context = new KonyvtarDbContext())
            {
                if (context != null)
                {
                    return Ok(context.Users.ToList());
                }
                else
                {
                    return StatusCode(503, "A szerver jelenleg nem elérhető");
                }
            }
        }

        [HttpGet("{id}")]
        public ActionResult<FelhasznaloDto> Get(int id)
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

        [HttpPut("{id}")]
        public ActionResult<FelhasznaloDto> Put(int id, ModifyFelhasznaloDto modifyFelhasznaloDto)
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

        [HttpPut("/jelszovaltas/{id}")]
        public ActionResult<FelhasznaloDto> Jelszovaltas(int id, ModifyJelszo modifyJelszo)
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


        [HttpDelete("{id}")]
        public ActionResult<FelhasznaloDto> Delete(int id)
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
    }
}
