using KonyvtarBackEnd.Dto;
using KonyvtarBackEnd.Models;
using Microsoft.AspNetCore.Mvc;

namespace KonyvtarBackEnd.Controllers
{
    [ApiController]
    [Route("/Profilképek")]
    public class AccounImgController : Controller
    {
        [HttpPost]
        public ActionResult<AccountImgDto> Post(CreateOrModifyAccountImgDto createOrModifyAccountImgDto)
        {
            var UjAccountImg = new AccountImg
            {
                Id = createOrModifyAccountImgDto.Id,
                ImgName = createOrModifyAccountImgDto.Name,
                ImgPath = createOrModifyAccountImgDto.Path
            };
            using (var context = new KonyvtarDbContext())
            {
                if (context != null)
                {
                    context.AccountImgs.Add(UjAccountImg);
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
        public ActionResult<AccountImgDto> GetAll()
        {
            using (var context = new KonyvtarDbContext())
            {
                if (context != null)
                {
                    return Ok(context.AccountImgs.ToList());
                }
                else
                {
                    return StatusCode(503, "A szerver jelenleg nem elérhető");
                }
            }
        }

        [HttpGet("{id}")]
        public ActionResult<AccountImgDto> Get(int id)
        {
            using (var context = new KonyvtarDbContext())
            {
                var kerdezett = context.AccountImgs.FirstOrDefault(x => x.Id == id);

                if (context != null)
                {
                    if (kerdezett != null)
                    {
                        return Ok(kerdezett);
                    }
                    else
                    {
                        return StatusCode(404, "A keresett kép nem létezik, vagy nincs eltárolva");
                    }
                }
                else
                {
                    return StatusCode(503, "A szerver jelenleg nem elérhető");
                }


            }
        }

        [HttpPut("{id}")]
        public ActionResult<AccountImgDto> Put(int id, CreateOrModifyAccountImgDto createOrModifyAccountImgDto)
        {
            using (var context = new KonyvtarDbContext())
            {
                if (context != null)
                {
                    var valtoztatando = context.AccountImgs.FirstOrDefault(x => x.Id == id);
                    if (valtoztatando != null)
                    {
                        valtoztatando.Id = createOrModifyAccountImgDto.Id;
                        valtoztatando.ImgName = createOrModifyAccountImgDto.Name;
                        valtoztatando.ImgPath = createOrModifyAccountImgDto.Path;

                        context.AccountImgs.Update(valtoztatando);
                        context.SaveChanges();
                        return Ok("Sikeres adatváltoztatás!");
                    }
                    else
                    {
                        return StatusCode(404, "A keresett kép nem létezik, vagy nincs eltárolva");
                    }
                }
                else
                {
                    return StatusCode(503, "A szerver jelenleg nem elérhető");
                }
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<AccountImgDto> Delete(int id)
        {
            using (var context = new KonyvtarDbContext())
            {
                var kerdezett = context.AccountImgs.FirstOrDefault(x => x.Id == id);

                if (context != null)
                {
                    if (kerdezett != null)
                    {
                        context.AccountImgs.Remove(kerdezett);
                        context.SaveChanges();
                        return Ok("A kép eltávolítása sikeresen megtörtént");
                    }
                    else
                    {
                        return StatusCode(404, "A keresett kép eddig sem létezett, vagy nem volt eltárolva");
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

