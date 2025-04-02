using EcommerceApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IConfiguration _configuration;

    public AuthController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] UserLogin user)
    {
        string connectionString = _configuration.GetConnectionString("DefaultConnection");

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username AND Password = @Password";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Username", user.Username);
                cmd.Parameters.AddWithValue("@Password", user.Password);

                int count = (int)cmd.ExecuteScalar();

                if (count > 0)
                {
                    return Ok("Login successful");
                }
                else
                {
                    return Unauthorized("Invalid username or password");
                }
            }
        }
    }
}using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IConfiguration _configuration;

    public AuthController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] UserLogin user)
    {
        string connectionString = _configuration.GetConnectionString("DefaultConnection");

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username AND Password = @Password";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Username", user.Username);
                cmd.Parameters.AddWithValue("@Password", user.Password);

                int count = (int)cmd.ExecuteScalar();

                if (count > 0)
                {
                    return Ok("Login successful");
                }
                else
                {
                    return Unauthorized("Invalid username or password");
                }
            }
        }
    }
}
