using WebApi.Models;
using WebApi.Services;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();
app.MapControllers();

var apiTask = Task.Run(() => app.Run());

while (true)
{
    Console.WriteLine("=== Menu ===");
    Console.WriteLine("1. Registrar usuário");
    Console.WriteLine("2. Deletar usuário por ID");
    Console.WriteLine("3. Sair");
    Console.Write("Escolha: ");
    var option = Console.ReadLine();

    if (option == "1")
    {
        Console.Write("Nome: ");
        var name = Console.ReadLine();

        Console.Write("Idade: ");
        if (!int.TryParse(Console.ReadLine(), out int age))
        {
            Console.WriteLine("Idade inválida!");
            continue;
        }

        var newUser = new Usuario
        {
            Nome = name,
            Idade = age
        };

        UserService.AddUser(newUser);

        Console.WriteLine($"Usuário {name} registrado com sucesso!");
    }
    else if (option == "2")
    {
        Console.Write("Digite o ID do usuário a ser deletado: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("ID inválido.");
            continue;
        }

        UserService.DeleteUserById(id);
    }
    else if (option == "3")
    {
        break;
    }
}

