namespace WebApi.Services;

using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Models;

public interface IUserService
{
    AuthenticateResponse Authenticate(AuthenticateRequest model);
    IEnumerable<User> GetAll();
    User GetById(int id);
}

public class UserService : IUserService
{
    // users hardcoded for simplicity, store in a db with hashed passwords in production applications
    private List<User> _users = new List<User>
    {
        new User { 
            Id = 1, 
            FirstName = "Thales", 
            LastName = "Liscano", 
            Username = "thales", 
            Password = "thalesthales",
            Signo = "Leão"
        },
        new User { 
            Id = 2, 
            FirstName = "Pedro", 
            LastName = "Paulo", 
            Username = "pedro", 
            Password = "pedropedro" 
        },
        new User { 
            Id = 3, 
            FirstName = "Carlos", 
            LastName = "Antonio", 
            Username = "carlos", 
            Password = "carloscarlos" 
        },
        new User { 
            Id = 4, 
            FirstName = "Joana", 
            LastName = "Tereza", 
            Username = "joana", 
            Password = "joana" 
        }

    };

    private readonly AppSettings _appSettings;

    public UserService(IOptions<AppSettings> appSettings)
    {
        _appSettings = appSettings.Value;
    }

    public AuthenticateResponse Authenticate(AuthenticateRequest model)
    {
        // => é um função que faz um comparação de cada item da lista {foreach()}
        // var user = _users.SingleOrDefault(
        //     x => 
        //     x.Username == model.Username 
        //     && 
        //     x.Password == model.Password
        // );
        
        User? user = null;
        foreach(var each in _users){
            Console.WriteLine(each);
            if (each.Username == model.Username && each.Password == model.Password)
            {
                user = each;
            }
        }

        // return null if user not found
        if (user == null) return null;

        // authentication successful so generate jwt token
        var token = generateJwtToken(user);

        return new AuthenticateResponse(user, token);
    }

    public IEnumerable<User> GetAll()
    {
        return _users;
    }

    public User GetById(int id)
    {
        return _users.FirstOrDefault(x => x.Id == id);
    }

    // helper methods
    private string generateJwtToken(User user)
    {
        // generate token that is valid for 7 days
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}