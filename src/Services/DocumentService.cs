namespace DesignPatternChallenge.Services;

using DesignPatternChallenge.Templates;
using System;

public class DocumentService
{
    private readonly DocumentTemplate _baseTemplate;

    public DocumentService()
    {
        _baseTemplate = InitializeBaseTemplate();
    }

    private DocumentTemplate InitializeBaseTemplate()
    {
        var template = new DocumentTemplate
        {
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

        template.RequiredFields.Add("NomeCliente");
        template.RequiredFields.Add("CPF");
        template.RequiredFields.Add("Endereco");

        template.Metadata["Versao"] = "1.0";
        template.Metadata["Departamento"] = "Comercial";

        return template;
    }

    // Problema resolvido: Uso de clone para evitar recriação do zero
    public DocumentTemplate CreateServiceContract()
    {
        Console.WriteLine("Criando template de Contrato de Serviço via protótipo...");
            
        // Simulando processo custoso que agora é evitado pelo clone
        System.Threading.Thread.Sleep(50); 
            
        var template = (DocumentTemplate)_baseTemplate.Clone();
        
        template.Title = "Contrato de Prestação de Serviços";
        template.Metadata["UltimaRevisao"] = DateTime.Now.ToString();
        template.Tags.Add("contrato");
        template.Tags.Add("servicos");

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

        return template;
    }

    // Problema resolvido: Código não é mais repetido
    public DocumentTemplate CreateConsultingContract()
    {
        Console.WriteLine("Criando template de Contrato de Consultoria via protótipo...");
            
        System.Threading.Thread.Sleep(50);
            
        var template = (DocumentTemplate)_baseTemplate.Clone();
        
        template.Title = "Contrato de Consultoria";
        template.Tags.Add("contrato");
        template.Tags.Add("consultoria");

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