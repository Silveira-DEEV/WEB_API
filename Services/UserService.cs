using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using WebApi.Models;

namespace WebApi.Services
{
    public static class UserService
    {
        private static readonly string _filePath = "./Data/users.json";
        private static List<Usuario> _users = LoadUsersFromFile();

        public static List<Usuario> LoadUsers()
        {
            return _users;
        }
        private static int GetNextId(List<Usuario> users)
        {
            return users.Count == 0 ? 1 : users.Max(u => u.Id) + 1;
        }

        public static void AddUser(Usuario user)
        {
            var users = LoadUsersFromFile();
            user.Id = GetNextId(users);
            users.Add(user);
            SaveUsersToFile(users);
        }
        public static bool DeleteUserById(int id)
        {
            var users = LoadUsersFromFile();
            var userToRemove = users.FirstOrDefault(u => u.Id == id);

            if (userToRemove != null)
            {
                users.Remove(userToRemove);
                SaveUsersToFile(users);
                Console.WriteLine($"Usuário com ID {id} removido.");
                return true;
            }
            else
            {
                Console.WriteLine($"Usuário com ID {id} não encontrado.");
                return false;
            }
        }

        private static List<Usuario> LoadUsersFromFile()
        {
            if (!File.Exists(_filePath))
                return new List<Usuario>();

            var json = File.ReadAllText(_filePath);
            if (string.IsNullOrWhiteSpace(json))
                return new List<Usuario>();

            return JsonSerializer.Deserialize<List<Usuario>>(json) ?? new List<Usuario>();
        }

        private static void SaveUsersToFile(List<Usuario> users)
        {
            var json = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, json);
            _users = users;
        }

    }
}
