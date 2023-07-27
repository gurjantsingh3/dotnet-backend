// using Tempo_Backend.Models.User;
// using System.Collections.Concurrent;
// using Tempo_Backend.Models.User;

// namespace Tempo_Backend.Services
// {
//     public class UserRepository : IUserRepository
//     {
//         private static ConcurrentDictionary<string, User> _user =
//               new ConcurrentDictionary<string, User>();

//         public UserRepository()
//         {
//             Add(new User { Email = "Item1" });
//         }

//         public IEnumerable<User> GetAll()
//         {
//             return _user.Values;
//         }

//         public void Add(User item)
//         {
//             item.Email = Guid.NewGuid().ToString();
//             _user[item.FirstName] = item;
//         }

//         public User Find(string key)
//         {
//             User item;
//             _user.TryGetValue(key, out item);
//             return item;
//         }

//         public User Remove(string key)
//         {
//             User item;
//             _user.TryGetValue(key, out item);
//             _user.TryRemove(key, out item);
//             return item;
//         }

//         public void Update(User item)
//         {
//             _user[item.Email] = item;
//         }

//         public Task<IEnumerable<User>> GetUsers()
//         {
//             throw new NotImplementedException();
//         }

//         public Task<User> Find(int userId)
//         {
//             throw new NotImplementedException();
//         }

//         Task<User> IUserRepository.Add(User user)
//         {
//             throw new NotImplementedException();
//         }

//         Task<User> IUserRepository.Update(User user)
//         {
//             throw new NotImplementedException();
//         }

//         public void DeleteEmployee(int employeeId)
//         {
//             throw new NotImplementedException();
//         }
//     }
// }