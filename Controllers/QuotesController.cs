using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace Solution
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuotesController : ControllerBase
    {
        QuotesContext dbContext;
        public QuotesContext(QuotesContext context)
        {
            dbContext = context;
            if (!dbContext.Quotes.Any())
            {
                dbContext.Quotes.Add(new Quote { Text = "Сильный человек — это тот, кто может управлять своим гневом.", Author = "Мухаммед (С.В.С)", new System.DateTime.Now() });
                dbContext.Quotes.Add(new Quote { Text = "Почитает женщину только благородный, а унижает её — только подлец!", Author = "Мухаммед (С.В.С)", new System.DateTime.Now() });
                dbContext.Quotes.Add(new Quote { Text = "Не войдет в рай тот, кто оставит родителей в старости.", Author = "Мухаммед (С.В.С)", new System.DateTime.Now() });
                dbContext.Quotes.Add(new Quote { Text = "Каждый человек ошибается, но достоин похвалы тот из вас, кто, осознав свою ошибку, пытается её исправить.", Author = "Мухаммед (С.В.С)", new System.DateTime.Now() });
                dbContext.Quotes.Add(new Quote { Text = "Самая совершенная вера у того, кто самый благонравный и самый добрый к свой семье.", Author = "Мухаммед (С.В.С)", new System.DateTime.Now() });
                dbContext.Quotes.Add(new Quote { Text = "Истинно верующий подобен пчеле: он не потребляет ничего, кроме благого, и не отдаёт ничего, кроме благого.", Author = "Мухаммед (С.В.С)", new System.DateTime.Now() });
                dbContext.Quotes.Add(new Quote { Text = "Чернила ученого более святы, чем кровь мученика. Так учитесь же грамоте, а научившись, учите других.", Author = "Мухаммед (С.В.С)", new System.DateTime.Now() });
                dbContext.Quotes.Add(new Quote { Text = "Аллах помогает Своему рабу до тех пор, пока этот раб будет помогать своему брату.", Author = "Мухаммед (С.В.С)", new System.DateTime.Now() });
                dbContext.Quotes.Add(new Quote { Text = "Не будет помилован тот, кто сам не проявляет милосердия (к другим)!", Author = "Мухаммед (С.В.С)", new System.DateTime.Now() });
                dbContext.Quotes.Add(new Quote { Text = "Будьте целомудренны в отношении чужих женщин и целомудренными будут ваши женщины!", Author = "Мухаммед (С.В.С)", new System.DateTime.Now() });
                dbContext.Quotes.Add(new Quote { Text = "Воистину, Аллах, Его ангелы, обитатели небес и земель, даже муравей в своей норке и даже рыбы благословляют того, кто обучает людей добру.", Author = "Мухаммед (С.В.С)", new System.DateTime.Now() });

                dbContext.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            return await db.Users.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(int id)
        {
            User user = await db.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
                return NotFound();
            return new ObjectResult(user);
        }

        [HttpPost]
        public async Task<ActionResult<User>> Post(User user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            db.Users.Add(user);
            await db.SaveChangesAsync();
            return Ok(user);
        }

        [HttpPut]
        public async Task<ActionResult<User>> Put(User user)
        {
            if (user.Age == 99)
                ModelState.AddModelError("Age", "Возраст не должен быть равен 99");
            if (user.Name == "admin")
            {
                ModelState.AddModelError("Name", "Недопустимое имя пользователя - admin");
            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            db.Users.Add(user);
            await db.SaveChangesAsync();
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> Delete(int id)
        {
            User user = db.Users.FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            db.Users.Remove(user);
            await db.SaveChangesAsync();
            return Ok(user);
        }
    }
}