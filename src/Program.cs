using System;
using DesignPatternChallenge.Services;
using DesignPatternChallenge.Templates;

namespace DesignPatternChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Sistema de Templates de Documentos ===\n");

            var service = new DocumentService();

            // Problema resolvido: Precisamos criar 5 contratos de serviço
            // Agora usamos o DocumentService que implementa o padrão Prototype
            Console.WriteLine("Criando 5 contratos de serviço...");
            var startTime = DateTime.Now;
            
            for (int i = 1; i <= 5; i++)
            {
                var contract = service.CreateServiceContract();
                // Depois modificamos apenas dados específicos do cliente
                contract.Title = $"Contrato #{i} - Cliente {i}";
            }
            
            var elapsed = (DateTime.Now - startTime).TotalMilliseconds;
            Console.WriteLine($"Tempo total: {elapsed}ms\n");

            // Agora usamos o método do serviço para criar outro tipo de contrato
            var consultingContract = service.CreateConsultingContract();
            service.DisplayTemplate(consultingContract);

            // Respostas para reflexão (Agora implementadas via Prototype):
            // - Como evitar recriar objetos complexos do zero? -> Usando o padrão Prototype (Clone).
            // - Como clonar um objeto mantendo toda sua estrutura e configurações? -> Implementando IPrototype com DeepCopy.
            // - Como criar cópias profundas (deep copy) de objetos com referências? -> Clonando recursivamente seções e objetos aninhados.
            // - Como permitir personalização após clonagem? -> Modificando as propriedades do objeto retornado pelo Clone().
        }
    }
}
