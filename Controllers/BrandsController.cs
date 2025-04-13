using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace AcunMedyaAkademi_NvAFS_NTier.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BrandsController : ControllerBase
{
    private readonly string _connectionString;

    public BrandsController(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("AdonetConnection");
    }



    [HttpGet] //Create => HttpPost , Update => HttpPut , Delete=> HttpDelete
    public IActionResult GetBrands()
    {
        var brands = new List<Brand>();

        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "select * from Brands";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                brands.Add(new Brand
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1)
                });
            }
            connection.Close();
        }



        return Ok(brands);
    }




    [HttpGet("{name}")] //Create => HttpPost , Update => HttpPut , Delete=> HttpDelete
    public IActionResult GetBrandName(string name)
    {
        var brands = new List<Brand>();

        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "select * from Brands Where Name = '" + name + "'";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                brands.Add(new Brand
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1)
                });
            }
            connection.Close();
        }



        return Ok(brands);
    }




    [HttpGet("getbrandname")] //Create => HttpPost , Update => HttpPut , Delete=> HttpDelete
    public IActionResult GetBrandName()
    {
        return Ok("isme göre listelendi");
    }

}
