namespace MachinistSAssistant.Services.ProgramParameters
{
    public class SLHMill: ISLHMill
    {
        public Models.ProgramParameters.SLHMill GetProgramParameters(Models.ApplicationParameters.SLHMill appParam, Models.MachiningParameters.SLHMill machParam)
        {
            // Diameter depends on where the cutting speed is referenced (in this case ToolReferenceDiameter)
            double circularRampSpindlSpeed = machParam.CircularRampCuttingSpeed * 1000 / (Math.PI * appParam.ToolReferenceDiameter);
            double circularRampPeripheralFeedrate = circularRampSpindlSpeed * machParam.CircularRampChipThickness * appParam.Z;
            double circularRampToolEffectiveDiameter = Math.Max(appParam.ToolReferenceDiameter, appParam.ToolMaxFrontDiameter);
            double circularRampMachinedDiameter = appParam.WorkpieceReferenceDiameter - 2 * machParam.RadialStockRemoval;
            double circularRampHelixAngle = Math.Atan(Math.PI * circularRampMachinedDiameter / machParam.CircularRampLead);

            Models.ProgramParameters.SLHMill progParam = new();
            progParam.CircularRampSpindleSpeed = circularRampSpindlSpeed;
            progParam.CircularRampMachinedDiameter = circularRampMachinedDiameter;
            progParam.CircularRampToolCentrePathDiameter = circularRampMachinedDiameter - circularRampToolEffectiveDiameter;
            progParam.CircularRampToolCentreFeedrate = circularRampPeripheralFeedrate * (circularRampMachinedDiameter - circularRampToolEffectiveDiameter) / circularRampMachinedDiameter;
            progParam.CircularRampHelixAngle = circularRampHelixAngle;
            return progParam;
        }
    }
}
