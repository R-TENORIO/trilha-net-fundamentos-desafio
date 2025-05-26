namespace DesafioFundamentos.Models
{
    public class NewBaseType
    {
        protected List<string> veiculos = new List<string>();

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(placa))
            {
                veiculos.Add(placa.ToUpper()); // Armazena em maiúsculas para padronização
                Console.WriteLine($"Veículo com placa {placa.ToUpper()} estacionado com sucesso.");
            }
            else
            {
                Console.WriteLine("Placa inválida. Nenhum veículo foi adicionado.");
            }
        }
    }

    public class Estacionamento : NewBaseType
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void RemoverVeiculo()
        {
            // Verifica se há veículos estacionados
            if (!veiculos.Any())
            {
                Console.WriteLine("Não há veículos estacionados para remover.");
                return; // Sai do método se não houver veículos
            }

            // Exibe a lista de veículos com numeração
            Console.WriteLine("Selecione o número correspondente ao veículo que deseja remover:");
            for (int i = 0; i < veiculos.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {veiculos[i]}"); // Exibe o índice + 1 e a placa // metodo obtido com ajuda em pesquisa google
            }

            // Solicita ao usuário que digite o número correspondente à placa
            Console.Write("Digite o número da placa: ");
            bool indiceValido = int.TryParse(Console.ReadLine(), out int indiceSelecionado);

            // Verifica se a entrada é válida e se está dentro da faixa da lista
            if (!indiceValido || indiceSelecionado < 1 || indiceSelecionado > veiculos.Count)
            {
                Console.WriteLine("Opção inválida.");
                return; // Sai do método se a seleção for inválida
            }

            // Recupera a placa selecionada com base no índice
            string placaSelecionada = veiculos[indiceSelecionado - 1];

            // Confirma com o usuário se deseja realmente remover essa placa
            Console.WriteLine($"Você selecionou a placa: {placaSelecionada}. Deseja continuar? (s/n)");
            string confirmacao = Console.ReadLine()?.Trim().ToLower(); // Lê e trata a resposta

            // Se o usuário não confirmar com "s", cancela a remoção
            if (confirmacao != "s")
            {
                Console.WriteLine("Remoção cancelada.");
                return;
            }

            // Solicita ao usuário a quantidade de horas que o veículo ficou estacionado
            Console.Write("Digite quantas horas o veículo permaneceu estacionado: ");
            bool entradaHorasValida = int.TryParse(Console.ReadLine(), out int horas);

            // Verificar se a quantidade de horas é válida (inteiro positivo)
            if (!entradaHorasValida || horas < 0)
            {
                Console.WriteLine("Quantidade de horas inválida.");
                return;
            }

            // Calcular o valor total a pagar:  Entrada +  horas
            decimal valorTotal = precoInicial + (precoPorHora * horas);

            // Remover a placa da lista 
            veiculos.RemoveAt(indiceSelecionado - 1);

            // Exibi ao operador sobre a remoção e o valor a ser cobrado
            Console.WriteLine($"O veículo {placaSelecionada} foi removido e o preço total foi de: R$ {valorTotal}");
        }



        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");

                foreach (var placa in veiculos)
                {
                    Console.WriteLine(placa);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}




