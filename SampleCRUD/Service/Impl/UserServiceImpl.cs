using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using SampleCRUD.Model;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SampleCRUD.Service.Impl
{
    public class UserServiceImpl : UserService
    {
        private ApplicationDbContext _context;
        private IConfiguration _configuration;

        public UserServiceImpl(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public Responce addUser(User user)
        {
            try
            {
                if (user == null)
                {

                    return new Responce(01, "user object empty", null);

                }

                _context.Users.Add(user);
                _context.SaveChanges();
                return new Responce(00, "User save success..", user);


            }
            catch (Exception ex)
            {

                return new Responce(02, "Error", ex.Message);
            }
        }

        public Responce getAllUser()
        {
            try
            {
                List<User> users = _context.Users.ToList();
                if (users.IsNullOrEmpty())
                {
                    return new Responce(01, "not exixting data", null);
                }
                return new Responce(00, "get all data", users);
            }
            catch (Exception ex) { 
            
                return new Responce(02,"Error",ex.Message);
            }
        }

        public Responce login(LoginDto loginDto)
        {
            try
            {
                if (loginDto == null)
                {

                    return new Responce(01, "login object empty", null);
                }
                User user = _context.Users.Where(z => z.Email == loginDto.Email && z.Password == loginDto.Password).FirstOrDefault()!;
                if (user == null)
                {

                    return new Responce(01, "Invaild login credential", null);

                }
                string token = generateJwtToken(user);
                return new Responce(00, "Login Success...", token);

            }
            catch (Exception ex)
            {

                return new Responce(02, "Error", ex.Message);

            }

        }


        private string generateJwtToken(User user)
        {

            var jwtSettings = _configuration.GetSection("Jwt");

            Console.WriteLine(jwtSettings);
            var claims = new[]
            {
               new Claim("user_id",user.Id.ToString()),
               new Claim("user_name",user.Name),
               new Claim("user_email",user.Email)
            };


            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);


            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(double.Parse(jwtSettings["ExpiresInMinutes"]!)),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);

            //return null;

        }

    }
}
