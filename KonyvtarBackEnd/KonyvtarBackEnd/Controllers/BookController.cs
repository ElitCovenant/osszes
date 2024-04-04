using KonyvtarBackEnd.Dto;
using KonyvtarBackEnd.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KonyvtarBackEnd.Controllers
{
    [ApiController]
    [Route("/Book")]
    public class BookController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<BookDto>> Post(CreateOrModifyKonyvDto createOrModifyKonyvDto)
        {
            try
            {
                var UjKonyv = new Book
                {
                    Id = createOrModifyKonyvDto.Id,
                    WarehouseNum = createOrModifyKonyvDto.Warehouse_Num,
                    PurchaseDate = createOrModifyKonyvDto.Purchase_Date,
                    AuthorId = createOrModifyKonyvDto.Author_Id,
                    Title = createOrModifyKonyvDto.Title,
                    SeriesId = createOrModifyKonyvDto.Series_Id,
                    IsbnNum = createOrModifyKonyvDto.Isbn_Num,
                    Szakkjelzet = createOrModifyKonyvDto.Szakjelzet,
                    CutterJelzet = createOrModifyKonyvDto.Cutter_Jelzet,
                    PublisherId = createOrModifyKonyvDto.Publisher_Id,
                    ReleaseDate = createOrModifyKonyvDto.Release_Date,
                    Price = createOrModifyKonyvDto.Price,
                    Comment = createOrModifyKonyvDto.Comment,
                    BookImg = createOrModifyKonyvDto.BookImg,
                    UserId = createOrModifyKonyvDto.User_Id

                };
                using (var context = new KonyvtarDbContext())
                {
                    if (context != null)
                    {
                        try
                        {
                            context.Books.Add(UjKonyv);
                            context.SaveChanges();
                        }
                        catch (Exception e) { return BadRequest("Hiba lépett fel! : " + e.Message); }


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

        [HttpGet, Authorize(Roles = "Admin")]
        public async Task<ActionResult<BookDto>> GetAll()
        {
            try
            {
                using (var context = new KonyvtarDbContext())
                {
                    if (context != null)
                    {
                        return Ok(context.Books.ToList());
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

        [HttpGet("/GuestInformations")]
        public async Task<ActionResult<BookDto>> GetSutentsAll()
        {
            try
            {
                using (var context = new KonyvtarDbContext())
                {
                    if (context != null)
                    {
                        return Ok(context.Books.Select(x => new { x.Id, x.Author, x.Title, x.ReleaseDate, x.BookImg }).ToList());
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

        [HttpGet("/Search/{nae}")]
        public async Task<ActionResult<BookDto>> Search(string nae)
        {
            try
            {
                using (var context = new KonyvtarDbContext())
                {
                    if (context != null)
                    {
                        return Ok(context.Books.Select(x => new { x.Id, x.Author, x.Title, x.ReleaseDate, x.BookImg }).Where(x => x.Title.Contains(nae)).ToList());
                    }
                    else
                    {
                        return StatusCode(404, "Nincs ilyen könyv!");
                    }
                }
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }

        }

        [HttpGet("/Konyvvalaszto")]
        public async Task<ActionResult<BookDto>> GetSpecial(int elsoev, int masodikev, int iroId)
        {
            try
            {
                using (var context = new KonyvtarDbContext())
                {
                    if (context != null)
                    {
                        var response = context.Books.Where(x => x.ReleaseDate < masodikev && x.ReleaseDate > elsoev && x.AuthorId == iroId).Select(x => new { x.Author, x.Title, x.ReleaseDate, x.BookImg }).ToList();
                        if (response != null)
                        {
                            return Ok(response);
                        }
                        else
                        {
                            return NotFound();
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

        [HttpGet("{id}")]
        public async Task<ActionResult<BookDto>> Get(int id)
        {
            try
            {
                using (var context = new KonyvtarDbContext())
                {
                    var kerdezett = context.Books.FirstOrDefault(x => x.Id == id);

                    if (context != null)
                    {
                        if (kerdezett != null)
                        {
                            return Ok(kerdezett);
                        }
                        else
                        {
                            return StatusCode(404, "A keresett könyv nem létezik, vagy nincs eltárolva");
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

        [HttpPut("{id}")]
        public async Task<ActionResult<BookDto>> Put(int id, CreateOrModifyKonyvDto createOrModifyKonyvDto)
        {
            try
            {
                using (var context = new KonyvtarDbContext())
                {
                    if (context != null)
                    {
                        var valtoztatando = context.Books.FirstOrDefault(x => x.Id == id);
                        if (valtoztatando != null)
                        {
                            valtoztatando.WarehouseNum = createOrModifyKonyvDto.Warehouse_Num;
                            valtoztatando.PurchaseDate = createOrModifyKonyvDto.Purchase_Date;
                            valtoztatando.AuthorId = createOrModifyKonyvDto.Author_Id;
                            valtoztatando.Title = createOrModifyKonyvDto.Title;
                            valtoztatando.SeriesId = createOrModifyKonyvDto.Series_Id;
                            valtoztatando.IsbnNum = createOrModifyKonyvDto.Isbn_Num;
                            valtoztatando.Szakkjelzet = createOrModifyKonyvDto.Szakjelzet;
                            valtoztatando.CutterJelzet = createOrModifyKonyvDto.Cutter_Jelzet;
                            valtoztatando.PublisherId = createOrModifyKonyvDto.Publisher_Id;
                            valtoztatando.ReleaseDate = createOrModifyKonyvDto.Release_Date;
                            valtoztatando.Price = createOrModifyKonyvDto.Price;
                            valtoztatando.Comment = createOrModifyKonyvDto.Comment;
                            valtoztatando.BookImg = createOrModifyKonyvDto.BookImg;
                            valtoztatando.UserId = createOrModifyKonyvDto.User_Id;

                            try
                            {
                                context.Books.Update(valtoztatando);
                                context.SaveChanges();
                            }
                            catch (Exception e)
                            {
                                return BadRequest("Hiba lépett fel : " + e.Message);
                            }

                            return Ok("Sikeres adatváltoztatás!");
                        }
                        else
                        {
                            return StatusCode(404, "A keresett könyv nem létezik, vagy nincs eltárolva");
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
        public async Task<ActionResult<BookDto>> Delete(int id)
        {
            try
            {
                using (var context = new KonyvtarDbContext())
                {
                    var kerdezett = context.Books.FirstOrDefault(x => x.Id == id);

                    if (context != null)
                    {
                        if (kerdezett != null)
                        {
                            context.Books.Remove(kerdezett);
                            context.SaveChanges();
                            return Ok("A sorozat eltávolítása sikeresen megtörtént");
                        }
                        else
                        {
                            return StatusCode(404, "A keresett könyv eddig sem létezett, vagy nem volt eltárolva");
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
