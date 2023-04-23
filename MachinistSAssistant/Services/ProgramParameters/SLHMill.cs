namespace MachinistSAssistant.Services.ProgramParameters
{
    public class SLHMill : Internal.ISLHMill
    {
        public Models.ProgramParameters.SLHMill CreateProgramParameters(Models.ApplicationParameters.SLHMill appParam, Models.MachiningParameters.SLHMill machParam)
        {
            var toolWorkDiameter = Math.Max(appParam.ToolReferenceDiameter, appParam.ToolMaxFrontDiameter);
            var circularRampDiameter = appParam.WorkpieceReferenceDiameter - 2*machParam.RadialStockRemoval;
            var circularRampHelixAngle = Math.Atan(Math.PI * circularRampDiameter / machParam.CircularRampLead);
            Models.ProgramParameters.SLHMill progParam = new();

            progParam.CircularRampMachinedDiameter = circularRampDiameter;
            progParam.CircularRampToolCentrePathDiameter = circularRampDiameter - toolWorkDiameter;
            progParam.CircularRampHelixAngle = circularRampHelixAngle;
            return progParam;
        }
    }
}
