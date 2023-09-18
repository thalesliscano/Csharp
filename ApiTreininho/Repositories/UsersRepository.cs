using System;
using System.Collections.Generic;
using System.Linq;

namespace ApiTreininho.Repositories
{
    public class UsersRepository
    {
        public static Models.User? Get(string name, string password)
        {
            var users = new List<Models.User>
            {
                new Models.User {Id = 1, Name = "Thales", Password = "12345", Role = "Funcionario"},
                new Models.User {Id = 2, Name = "Beatriz", Password = "banana", Role = "Gerente"},
            };

            // Verificar se os parâmetros name e password não são nulos
            if (name == null || password == null)
            {
                throw new ArgumentNullException("name e password não podem ser nulos");
            }

            return users.FirstOrDefault(x => x.Name?.ToLower() == name.ToLower() && x.Password == password);
        }
    }
}
