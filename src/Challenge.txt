// DESAFIO: Sistema de Templates de Documentos
// PROBLEMA: Um sistema de gerenciamento documental precisa criar novos documentos
// baseados em templates pré-configurados complexos (contratos, propostas, relatórios)
// O código atual recria objetos do zero, perdendo muito tempo em inicializações

using System;
using System.Collections.Generic;

namespace DesignPatternChallenge
{
    // Contexto: Sistema que gerencia documentos corporativos com muitas configurações
    // Templates são complexos e custosos para criar, mas precisamos gerar muitos documentos similares
    
    public class DocumentTemplate
    {
        public string Title { get; set; }
        public string Category { get; set; }
        public List<Section> Sections { get; set; }
        public DocumentStyle Style { get; set; }
        public List<string> RequiredFields { get; set; }
        public Dictionary<string, string> Metadata { get; set; }
        public ApprovalWorkflow Workflow { get; set; }
        public List<string> Tags { get; set; }

        public DocumentTemplate()
        {
            Sections = new List<Section>();
            RequiredFields = new List<string>();
            Metadata = new Dictionary<string, string>();
            Tags = new List<string>();
        }
    }

    public class Section
    {
        public string Name { get; set; }
        public string Content { get; set; }
        public bool IsEditable { get; set; }
        public List<string> Placeholders { get; set; }

        public Section()
        {
            Placeholders = new List<string>();
        }
    }

    public class DocumentStyle
    {
        public string FontFamily { get; set; }
        public int FontSize { get; set; }
        public string HeaderColor { get; set; }
        public string LogoUrl { get; set; }
        public Margins PageMargins { get; set; }
    }

    public class Margins
    {
        public int Top { get; set; }
        public int Bottom { get; set; }
        public int Left { get; set; }
        public int Right { get; set; }
    }

    public class ApprovalWorkflow
    {
        public List<string> Approvers { get; set; }
        public int RequiredApprovals { get; set; }
        public int TimeoutDays { get; set; }

        public ApprovalWorkflow()
        {
            Approvers = new List<string>();
        }
    }

    public class DocumentService
    {
        // Problema: Criação manual de templates complexos repetidamente
        public DocumentTemplate CreateServiceContract()
        {
            Console.WriteLine("Criando template de Contrato de Serviço do zero...");
            
            // Simulando processo custoso de inicialização
            System.Threading.Thread.Sleep(100);
            
            var template = new DocumentTemplate
            {
                Title = "Contrato de Prestação de Serviços",
                Category = "Contratos",
                Style = new DocumentStyle
                {
                    FontFamily = "Arial",
                    FontSize = 12,
                    HeaderColor = "#003366",
                    LogoUrl = "https://company.com/logo.png",
                    PageMargins = new Margins { Top = 2, Bottom = 2, Left = 3, Right = 3 }
                },
                Workflow = new ApprovalWorkflow
                {
                    RequiredApprovals = 2,
                    TimeoutDays = 5
                }
            };

            template.Workflow.Approvers.Add("gerente@empresa.com");
            template.Workflow.Approvers.Add("juridico@empresa.com");

            template.Sections.Add(new Section
            {
                Name = "Cláusula 1 - Objeto",
                Content = "O presente contrato tem por objeto...",
                IsEditable = true
            });
            template.Sections.Add(new Section
            {
                Name = "Cláusula 2 - Prazo",
                Content = "O prazo de vigência será de...",
                IsEditable = true
            });
            template.Sections.Add(new Section
            {
                Name = "Cláusula 3 - Valor",
                Content = "O valor total do contrato é de...",
                IsEditable = true
            });

            template.RequiredFields.Add("NomeCliente");
            template.RequiredFields.Add("CPF");
            template.RequiredFields.Add("Endereco");

            template.Tags.Add("contrato");
            template.Tags.Add("servicos");

            template.Metadata["Versao"] = "1.0";
            template.Metadata["Departamento"] = "Comercial";
            template.Metadata["UltimaRevisao"] = DateTime.Now.ToString();

            return template;
        }

        // Problema: Mesmo código repetido para criar documentos similares
        public DocumentTemplate CreateConsultingContract()
        {
            Console.WriteLine("Criando template de Contrato de Consultoria do zero...");
            
            System.Threading.Thread.Sleep(100);
            
            // Código quase idêntico ao CreateServiceContract
            var template = new DocumentTemplate
            {
                Title = "Contrato de Consultoria",
                Category = "Contratos",
                Style = new DocumentStyle
                {
                    FontFamily = "Arial",
                    FontSize = 12,
                    HeaderColor = "#003366",
                    LogoUrl = "https://company.com/logo.png",
                    PageMargins = new Margins { Top = 2, Bottom = 2, Left = 3, Right = 3 }
                },
                Workflow = new ApprovalWorkflow
                {
                    RequiredApprovals = 2,
                    TimeoutDays = 5
                }
            };

            template.Workflow.Approvers.Add("gerente@empresa.com");
            template.Workflow.Approvers.Add("juridico@empresa.com");

            // Mesmas seções com pequenas variações
            template.Sections.Add(new Section
            {
                Name = "Cláusula 1 - Objeto",
                Content = "O presente contrato de consultoria tem por objeto...",
                IsEditable = true
            });
            template.Sections.Add(new Section
            {
                Name = "Cláusula 2 - Prazo",
                Content = "O prazo de vigência será de...",
                IsEditable = true
            });

            template.RequiredFields.Add("NomeCliente");
            template.RequiredFields.Add("CPF");
            template.RequiredFields.Add("Endereco");

            template.Tags.Add("contrato");
            template.Tags.Add("consultoria");

            template.Metadata["Versao"] = "1.0";
            template.Metadata["Departamento"] = "Comercial";

            return template;
        }

        public void DisplayTemplate(DocumentTemplate template)
        {
            Console.WriteLine($"\n=== {template.Title} ===");
            Console.WriteLine($"Categoria: {template.Category}");
            Console.WriteLine($"Seções: {template.Sections.Count}");
            Console.WriteLine($"Campos obrigatórios: {string.Join(", ", template.RequiredFields)}");
            Console.WriteLine($"Aprovadores: {string.Join(", ", template.Workflow.Approvers)}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Sistema de Templates de Documentos ===\n");

            var service = new DocumentService();

            // Problema: Precisamos criar 10 contratos de serviço
            // Cada um é criado do zero, mesmo sendo idênticos no início
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

            // Problema: Código duplicado para templates similares
            var consultingContract = service.CreateConsultingContract();
            service.DisplayTemplate(consultingContract);

            // Perguntas para reflexão:
            // - Como evitar recriar objetos complexos do zero?
            // - Como clonar um objeto mantendo toda sua estrutura e configurações?
            // - Como criar cópias profundas (deep copy) de objetos com referências?
            // - Como permitir personalização após clonagem?
        }
    }
}
