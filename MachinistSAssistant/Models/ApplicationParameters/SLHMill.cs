namespace MachinistSAssistant.Models.ApplicationParameters;
public class SLHMill
{
    public string ToolType { get; } = "SLHMill";
    public string ToolNumber { get; set; } = default!;
    public string? WorkpieceMaterial { get; set; }
    public string? CuttingGeometry { get; set; }
    public string SLHType { get; set; } = default!;
    public string MmOrInches { get; set; } = default!;
    public double WorkpieceReferenceDiameter { get; set; } = default!;
    public double WorkpieceReferenceOffset { get; set; } = default!;
    public double ToolReferenceDiameter { get; set; } = default!;
    public double ToolReferenceOffset { get; set; } = default!;
    public double ToolMaxFrontDiameter { get; set; } = default!;
    public int Z { get; set; } = default!;
}