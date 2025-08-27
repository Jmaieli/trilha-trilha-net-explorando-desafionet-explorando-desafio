namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        private bool _descontoAplicado = false;

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            if (hospedes.Count > Suite.Capacidade)
                throw new Exception("Número de hóspedes excede a capacidade da suíte.");

            Hospedes = hospedes;
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            // TODO: Retorna a quantidade de hóspedes (propriedade Hospedes)
            // *IMPLEMENTE AQUI*
            return Hospedes.Count;
        }

        private decimal CalcularValorDiaria()
        {
            // TODO: Retorna o valor da diária
            // Cálculo: DiasReservados X Suite.ValorDiaria
            // *IMPLEMENTE AQUI*
            decimal valor = DiasReservados * Suite.ValorDiaria;

            // Regra: Caso os dias reservados forem maior ou igual a 10, conceder um desconto de 10%
            // *IMPLEMENTE AQUI*
            if (DiasReservados >= 10)
            {
                valor -= valor * 0.1M;
                _descontoAplicado = true;
            }

            return valor;
        }

        public void Detalhes()
        {
            decimal v = CalcularValorDiaria();

            Console.WriteLine("===== Detalhes da Reserva =====");
            if (_descontoAplicado)
                Console.WriteLine("Eeeebaaa! você conseguiu um desconto de 10%!");

            Console.WriteLine($"Dias Reservados: {DiasReservados}");
            Console.WriteLine($"Valor da Diária: {v:C}");

            Console.WriteLine("\n--- Suíte ---");
            Console.WriteLine($"Tipo: {Suite.TipoSuite}");
            Console.WriteLine($"Capacidade: {Suite.Capacidade} hóspedes");
            Console.WriteLine($"Valor por Diária: {Suite.ValorDiaria:C}");

            Console.WriteLine("\n--- Hóspedes ---");
            foreach (var hospede in Hospedes)
            {
                Console.WriteLine($"- {hospede.Nome} {hospede.Sobrenome}");
            }
        }
    }
}