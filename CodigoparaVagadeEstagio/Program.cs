using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static List<Usuario> usuarios = new List<Usuario>();
    
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\nEscolha uma opção:");
            Console.WriteLine("1 - Cadastrar usuário");
            Console.WriteLine("2 - Listar usuários");
            Console.WriteLine("3 - Buscar usuário pelo nome");
            Console.WriteLine("4 - Sair");
            Console.Write("Opção: ");
            
            string opcao = Console.ReadLine();
            Console.WriteLine();

            switch (opcao)
            {
                case "1":
                    CadastrarUsuario(); // Cadastra um novo usuário
                    break;
                case "2":
                    ListarUsuarios(); // Lista todos os usuários cadastrados
                    break;
                case "3":
                    BuscarUsuario(); // Busca um usuário pelo nome
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Opção inválida! Tente novamente.");
                    break;
            }
        }
    }

    static void CadastrarUsuario()
    {
        // Solicita e cadastra um novo usuário
        Console.Write("Nome: ");
        string nome = Console.ReadLine();
        
        Console.Write("E-mail: ");
        string email = Console.ReadLine();
        
        Console.Write("Idade: ");
        if (!int.TryParse(Console.ReadLine(), out int idade))
        {
            Console.WriteLine("Idade inválida!");
            return;
        }
        
        usuarios.Add(new Usuario(nome, email, idade));
        Console.WriteLine("Usuário cadastrado com sucesso!");
    }

    static void ListarUsuarios()
    {
        // Exibe a lista de usuários cadastrados
        if (usuarios.Count == 0)
        {
            Console.WriteLine("Nenhum usuário cadastrado.");
            return;
        }
        
        Console.WriteLine("Lista de usuários:");
        foreach (var usuario in usuarios)
        {
            Console.WriteLine(usuario);
        }
    }

    static void BuscarUsuario()
    {
        // Busca um usuário pelo nome e exibe suas informações
        Console.Write("Digite o nome do usuário: ");
        string nomeBusca = Console.ReadLine();
        
        var usuario = usuarios.FirstOrDefault(u => u.Nome.Equals(nomeBusca, StringComparison.OrdinalIgnoreCase));
        
        if (usuario == null)
        {
            Console.WriteLine("Usuário não encontrado.");
        }
        else
        {
            Console.WriteLine("Usuário encontrado:");
            Console.WriteLine(usuario);
        }
    }
}

class Usuario
{
    // Classe que representa um usuário
    public string Nome { get; }
    public string Email { get; }
    public int Idade { get; }

    public Usuario(string nome, string email, int idade)
    {
        Nome = nome;
        Email = email;
        Idade = idade;
    }

    public override string ToString()
    {
        return $"Nome: {Nome}, Email: {Email}, Idade: {Idade}";
    }
}
