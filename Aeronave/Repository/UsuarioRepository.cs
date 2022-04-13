//using System.Collections.Generic;
//using System.Linq;
//using Model;

//namespace Aeronave.Repositories
//{
//    public class UsuarioRepository
//    {
//        public static Usuario Get(string username, string password)
//        {
//            var users = new List<Usuario>();
//            users.Add(new Usuario { Id = "1", Username = "admin", Password = "admin", Role = "manager" });
//            users.Add(new Usuario { Id = "2", Username = "user", Password = "user", Role = "employee" });
//            return users.Where(x => x.Username.ToLower() == username.ToLower() && x.Password == password).FirstOrDefault();
//        }
//    }
//}
