using KonyvtarBackEnd.Dto;
using KonyvtarBackEnd.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KonyvtarBackEnd.Controllers
{
    [ApiController]
    [Route("/Profilképek")]
    public class AccounImgController : Controller
    {
        [HttpPost]
        public async Task<ActionResult<AccountImgDto>> Post(CreateOrModifyAccountImgDto createOrModifyAccountImgDto)
        {
            try
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
                        try
                        {
                            context.AccountImgs.Add(UjAccountImg);
                            context.SaveChanges();
                        }
                        catch (Exception e)
                        {
                            return BadRequest("Hiba lépett fel ! : " + e.Message);
                        }

                        return StatusCode(201, "Az adatok sikeresen eltárolva!");
                    }
                    else
                    {
                        return StatusCode(406, "Nem megfeleő az adat formátuma!");
                    }
                }
            }
            catch (Exception e) { return StatusCode(500, e.Message); }
        }

        [HttpGet, Authorize(Roles = "Admin")]
        public async Task<ActionResult<AccountImgDto>> GetPath()
        {
            try
            {
                using (var context = new KonyvtarDbContext())
                {
                    if (context != null)
                    {
                        return Ok(context.AccountImgs.Select(x => new { x.ImgPath }).ToList());
                    }
                    else
                    {
                        return StatusCode(503, "A szerver jelenleg nem elérhető");
                    }
                }
            }
            catch (Exception e) { return StatusCode(500, e.Message); }

        }

        [HttpGet("/GetData"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<AccountImgDto>> GetData()
        {
            try
            {
                using (var context = new KonyvtarDbContext())
                {
                    if (context != null)
                    {
                        return Ok(context.AccountImgs.Select(x => new { x.Id, x.ImgName }).ToList());
                    }
                    else
                    {
                        return StatusCode(503, "A szerver jelenleg nem elérhető");
                    }
                }
            }
            catch (Exception e) { return StatusCode(500, e.Message); }

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AccountImgDto>> Get(int id)
        {
            try
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
            catch (Exception e) { return StatusCode(500, e.Message); }

        }

        [HttpGet("/önkép/{id}")]
        public async Task<ActionResult<AccountImgDto>> GetMyPic(int id)
        {
            try
            {
                using (var context = new KonyvtarDbContext())
                {
                    if (context != null)
                    {
                        try
                        {
                            var kerdezett = context.Users.FirstOrDefault(x => x.Id == id);
                            if (kerdezett != null)
                            {
                                return Ok(kerdezett.IdAccountImg);
                            }
                            else
                            {
                                return NotFound("Nincs ilyen felhasználó");
                            }
                        }
                        catch (Exception e)
                        {

                            return StatusCode(404, "Hiba lépett fel a lekérdezés során : " + e.Message);
                        }
                    }
                    else
                    {
                        return StatusCode(503, "A szerver jelenleg nem elérhető");
                    }

                }
            }
            catch (Exception e) { return StatusCode(500, e.Message); }

        }

        [HttpGet("/Tanulók")]
        public async Task<ActionResult<AccountImgDto>> GetStudentPics()
        {
            try
            {
                using (var context = new KonyvtarDbContext())
                {
                    if (context != null)
                    {
                        return Ok(context.AccountImgs.Where(x => x.ImgName.Contains("Guest") || x.ImgName.Contains("Default")).Select(x => new { x.ImgPath }).ToList());
                    }
                    else
                    {
                        return StatusCode(503, "A szerver jelenleg nem elérhető");
                    }
                }
            }
            catch (Exception e)
            {

                return StatusCode(500,e.Message);
            }

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<AccountImgDto>> Put(int id, CreateOrModifyAccountImgDto createOrModifyAccountImgDto)
        {
            try
            {
                using (var context = new KonyvtarDbContext())
                {
                    if (context != null)
                    {
                        var valtoztatando = context.AccountImgs.FirstOrDefault(x => x.Id == id);
                        if (valtoztatando != null)
                        {
                            try
                            {
                                valtoztatando.Id = createOrModifyAccountImgDto.Id;
                                valtoztatando.ImgName = createOrModifyAccountImgDto.Name;
                                valtoztatando.ImgPath = createOrModifyAccountImgDto.Path;

                                context.AccountImgs.Update(valtoztatando);
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
                            return StatusCode(404, "A keresett kép nem létezik, vagy nincs eltárolva");
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

                return StatusCode(500,e.Message);
            }

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<AccountImgDto>> Delete(int id)
        {
            try
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
            catch (Exception e)
            {

                return StatusCode(500,e.Message);
            }
        }

    }
}

