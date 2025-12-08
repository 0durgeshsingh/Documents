## Step 1. Model
  - Create the Model Folder and add class

```C#
namespace _0durgeshsingh.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
    }
}
```
## Step 2. Create Application Context Class
  - Create a Folder Data and Add a Context Class 

```C#
using _0durgeshsingh.Models;
using Microsoft.EntityFrameworkCore;

namespace _0durgeshsingh.Data
{
    // Define the ApplicationDbContext class, which inherits from DbContext

    public class ApplicationDbContext : DbContext     
    {
        // Constructor that accepts DbContextOptions and passes it to the base DbContext class
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {

            // The constructor is used to configure the context with specific options (e.g., database settings)
        }

        // DbSet property for accessing and querying the 'Persons' table in the database
        // DbSet represents a collection of entities of type Person that can be queried or saved to the database
        public DbSet<Person> Persons { get; set; }
    }
}
```
## Step 3. Create Controller Class
  - Create controller class in Controller folder

```C#
using _0durgeshsingh.Data;
using _0durgeshsingh.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _0durgeshsingh.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PersonController(ApplicationDbContext context)
        {
            _context  = context;
        }

        // POST: api/People
        [HttpPost]
        public async Task<IActionResult> CreatePerson([FromBody] Person person)
        {
            if (person == null)
            {
                return BadRequest();
            }
            _context.Persons.Add(person);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPerson), new { id = person.Id }, person);
        }

        // GET: api/People
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetPeople()
        {
            return await _context.Persons.ToListAsync();
        }
        // GET: api/People/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPerson(int id)
        {
            var person = await _context.Persons.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }
            return person;
        }

        // PUT: api/People/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePerson(int id, [FromBody] Person person)
        {
            if (id != person.Id)
            {
                return BadRequest();
            }
            _context.Entry(person).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/People/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(int id)
        {
            var person = await _context.Persons.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }
            _context.Persons.Remove(person);
            await _context.SaveChangesAsync();
            return NoContent();
        }



    }
}
```

## Step 4. Configure Connection 
```C#
{
    "Logging": {
        "LogLevel": {
            "Default": "Information",
            "Microsoft.AspNetCore": "Warning"
        }
    },
    "ConnectionStrings": {
        "DefaultConnection": "Server=.\\;Database=0durgeshsingh;User Id=sa;Password=default;TrustServerCertificate=true;"
    },
    "AllowedHosts": "*"
}
```
## Step 5. Update Program.cs Class 

```C#
using Microsoft.Data.SqlClient;  // Using the modern SQL Client library
using _0durgeshsingh.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Register SqlHelper with dependency injection
builder.Services.AddSingleton<SqlHelper>();  // Or AddScoped or AddTransient based on your use case

// Register DbContext for SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
```







