using ApiTest.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ApiTest.EF;
using ApiTest.ModelView;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace ApiTest.Controllers
{
    public class HomeController : Controller
    {
        private TestingContext db;
        public HomeController(TestingContext context)
        {
            db = context;
        }

        [HttpGet("GetEmployee/{id}")]
        public IActionResult GetEmployee(int id)
        {
            Employees? employees = db.Employees.FirstOrDefault(x => x.Id == id);
            if (employees is null)
            {
                return NotFound();
            }
/*            employees.Positions = db.Positions.FirstOrDefault(x => x.Id == employees.PositionsId);
            employees.Projects = db.Projects.FirstOrDefault(x => x.Id == employees.ProjectsId);*/
            return Ok(employees);
        }

        [HttpPost("PostEmployee")]
        public IActionResult PostEmployee([FromBody] EmployeeView employ)
        {
            if(db.Positions.FirstOrDefault(x => x.Name == employ.Position) is null)
            {
                Positions positions = new Positions
                {
                    Name = employ.Name
                };
                db.Positions.Add(positions);
                db.SaveChanges();
            }
            if(db.Projects.FirstOrDefault(x => x.NameProject == employ.Project) is null)
            {
                Projects projects = new Projects
                {
                    NameProject = employ.Project
                };
                db.Projects.Add(projects);
                db.SaveChanges();
            }
            Employees employees = new Employees
            {
                Name = employ.Name,
                Surname = employ.Surname,
                Patronymic = employ.Patronymic,
                Positions = db.Positions.FirstOrDefault(x => x.Name == employ.Position),
                Projects = db.Projects.FirstOrDefault(x => x.NameProject == employ.Project)
            };
            db.Employees.Add(employees);
            db.SaveChanges();
            return Ok();
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            Employees? employees = db.Employees.FirstOrDefault(x => x.Id == id);
            if (employees is null)
            {
                return NotFound();
            }
            db.Employees.Remove(employees);
            db.SaveChanges();
            return Ok();
        }

        [HttpPost("Update")]
        public IActionResult UpdateEmployee([FromBody] EmployeeView employ)
        {
            Employees employees = db.Employees.First(x => x.Id == employ.Id);
            if (db.Positions.FirstOrDefault(x => x.Name == employ.Position) is null)
            {
                Positions positions = new Positions
                {
                    Name = employ.Name
                };
                db.Positions.Add(positions);
                db.SaveChanges();
            }
            if (db.Projects.FirstOrDefault(x => x.NameProject == employ.Project) is null)
            {
                Projects projects = new Projects
                {
                    NameProject = employ.Project
                };
                db.Projects.Add(projects);
                db.SaveChanges();
            }
            employees.Name = employ.Name;
            employees.Surname = employ.Surname;
            employees.Patronymic = employ.Patronymic;
            employees.Positions = db.Positions.FirstOrDefault(x => x.Name == employ.Position);
            employees.Projects = db.Projects.FirstOrDefault(x => x.NameProject == employ.Project);
            db.SaveChanges();
            return Ok();
        }

        [HttpPost("Auth")]
        public IActionResult AuthUser([FromBody]LoginData loginData)
        {
            List<Users> user = new List<Users>();
            user.Add(new Users
            {
                Id = 1,
                Email = "kapralov_00@mail.ru",
                Password = "12345",
            }) ;
            
            // находим пользователя 
            //Users? users = db.Users.FirstOrDefault(p => p.Email == loginData.Email && p.Password == loginData.Password);
            Users? users = user.FirstOrDefault(p => p.Email == loginData.Email && p.Password == loginData.Password);
            // если пользователь не найден, отправляем статусный код 400
            if (users is null) 
                return BadRequest();

            var claims = new List<Claim> { new Claim(ClaimTypes.Name, users.Email), new Claim("Id", users.Id.ToString()) };
            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    claims: claims,
                    expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            // формируем ответ
            var response = new
            {
                access_token = encodedJwt,
                username = users.Email
            };

            return Ok(response);
        }
        /* private readonly ILogger<HomeController> _logger;

         public HomeController(ILogger<HomeController> logger)
         {
             _logger = logger;
         }

         public IActionResult Index()
         {
             return View();
         }

         public IActionResult Privacy()
         {
             return View();
         }

         [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
         public IActionResult Error()
         {
             return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
         }*/
    }
}