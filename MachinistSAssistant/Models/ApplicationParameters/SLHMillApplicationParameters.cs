namespace MachinistSAssistant.Models.ApplicationParameters
{
    public class SLHMillApplicationParameters
    {
        public string ToolNumber { get; set; } = default!;

        public string WorkpieceMaterial { get; set; } = default!;
        public string SLHType { get; set; } = default!;
        public string MmOrInches { get; set; } = default!;
        public double WorkpieceReferenceDiameter { get; set; } = default!;
        public double WorkpieceReferenceOffset { get; set; } = default!;
        public double ToolReferenceDiameter { get; set; } = default!;
        public double ToolReferenceOffset { get; set; } = default!;
    }
}
