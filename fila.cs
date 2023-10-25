using System;
using System.Collections.Generic;
using System.Threading;

class Cliente
{
    public string Nome { get; set; }
    public int TempoDeEspera { get; set; }
}

class Funcionario
{
    public string Nome { get; set; }

    public void AtenderCliente(Cliente cliente)
    {
        Console.WriteLine($"{Nome} está atendendo o cliente {cliente.Nome} por {cliente.TempoDeEspera} segundos.");
        Thread.Sleep(cliente.TempoDeEspera * 1000);
        Console.WriteLine($"{Nome} atendeu o cliente {cliente.Nome} em {cliente.TempoDeEspera} segundos.");
    }
}

class Program
{
    static void Main()
    {
        Queue<Cliente> fila = new Queue<Cliente>();
        List<Funcionario> funcionarios = new List<Funcionario>
        {
            new Funcionario { Nome = "Funcionário 1" },
            new Funcionario { Nome = "Funcionário 2" }
        };

        Random random = new Random();

        // Simulando a chegada de clientes à fila
        for (int i = 1; i <= 5; i++)
        {
            Cliente cliente = new Cliente
            {
                Nome = $"Cliente {i}",
                TempoDeEspera = random.Next(1, 6) // Tempo de espera aleatório de 1 a 5 segundos
            };
            fila.Enqueue(cliente);
            Console.WriteLine($"Novo cliente na fila: {cliente.Nome} (Tempo de espera: {cliente.TempoDeEspera} segundos)");
        }

        // Atendimento dos clientes pelos funcionários
        while (fila.Count > 0)
        {
            foreach (Funcionario funcionario in funcionarios)
            {
                if (fila.Count == 0)
                    break;

                Cliente cliente = fila.Dequeue();
                funcionario.AtenderCliente(cliente);
            }
        }

        Console.WriteLine("Todos os clientes foram atendidos.");
    }
}
