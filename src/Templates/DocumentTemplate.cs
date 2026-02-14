    namespace DesignPatternChallenge.Templates;
    public class DocumentTemplate : IPrototype
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

        public IPrototype Clone()
        {
            return DeepCopy();
        }

        public IPrototype DeepCopy()
        {
            var copy = (DocumentTemplate)MemberwiseClone();
            
            // Deep copy collections
            copy.Sections = Sections.Select(s => (Section)s.Clone()).ToList();
            copy.RequiredFields = new List<string>(RequiredFields);
            copy.Metadata = new Dictionary<string, string>(Metadata);
            copy.Tags = new List<string>(Tags);

            // Deep copy objects
            if (Style != null)
            {
                copy.Style = new DocumentStyle
                {
                    FontFamily = Style.FontFamily,
                    FontSize = Style.FontSize,
                    HeaderColor = Style.HeaderColor,
                    LogoUrl = Style.LogoUrl,
                    PageMargins = Style.PageMargins != null ? new Margins
                    {
                        Top = Style.PageMargins.Top,
                        Bottom = Style.PageMargins.Bottom,
                        Left = Style.PageMargins.Left,
                        Right = Style.PageMargins.Right
                    } : null
                };
            }

            if (Workflow != null)
            {
                copy.Workflow = new ApprovalWorkflow
                {
                    Approvers = new List<string>(Workflow.Approvers),
                    RequiredApprovals = Workflow.RequiredApprovals,
                    TimeoutDays = Workflow.TimeoutDays
                };
            }

            return copy;
        }
    }

    public class Section : IPrototype
    {
        public string Name { get; set; }
        public string Content { get; set; }
        public bool IsEditable { get; set; }
        public List<string> Placeholders { get; set; }

        public Section()
        {
            Placeholders = new List<string>();
        }

        public IPrototype Clone()
        {
            return (IPrototype)MemberwiseClone();
        }

        public IPrototype DeepCopy()
        {
            var copy = (Section)MemberwiseClone();
            copy.Placeholders = new List<string>(Placeholders);
            return copy;
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