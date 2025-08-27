using System.Text;
using DesafioProjetoHospedagem.Models;

Console.WriteLine($"========== Bem vindo ao sistema de reservas do MyHostel! ==========");
Console.Write($"Por favor informe o número de dias que deseja ficar conosco: ");
int diasReserva = int.Parse(Console.ReadLine());

Console.Write($"Por favor informe o número de hospedes: ");
int numHospedes = int.Parse(Console.ReadLine());

Console.OutputEncoding = Encoding.UTF8;

// Cria os modelos de hóspedes e cadastra na lista de hóspedes
List<Pessoa> hospedes = new List<Pessoa>(capacity: numHospedes);

for (int i = 1; i <= numHospedes; i++)
{
    Console.Write($"Por favor informe o nome do hóspede {i}: ");
    string nome = Console.ReadLine();

    Console.Write($"Por favor informe o sobrenome do hóspede {i}: ");
    string sobrenome = Console.ReadLine();

    Pessoa p = new Pessoa(nome: nome, sobrenome: sobrenome);
    hospedes.Add(p);
}

// Cria a suíte
Suite suite = new Suite(tipoSuite: "Premium", capacidade: 2, valorDiaria: 30);

// Cria uma nova reserva, passando a suíte e os hóspedes
Reserva reserva = new Reserva(diasReservados: diasReserva);
reserva.CadastrarSuite(suite);
reserva.CadastrarHospedes(hospedes);

// TODO: listar os detalhes da reserva, incluindo os hóspedes e a suíte e valores
reserva.Detalhes();