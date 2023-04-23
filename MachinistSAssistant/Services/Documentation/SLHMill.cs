using iText.Kernel.Pdf;
using iText.Forms;
using iText.Forms.Fields;

namespace MachinistSAssistant.Services.Documentation;
public class SLHMill
{
    private readonly string _templateFilePath;
    public SLHMill(string templateFilePath, Models.ProgramParameters.SLHMill progParam)
    {
        _templateFilePath = templateFilePath;
    }

    public MemoryStream GetDocumentation(Models.ProgramParameters.SLHMill progParam)
    {
        MemoryStream memStream = new MemoryStream();
        PdfDocument pdfDoc = new PdfDocument(new PdfReader(_templateFilePath), new PdfWriter(memStream));
        PdfAcroForm form = PdfAcroForm.GetAcroForm(pdfDoc, true);
        PdfFormField field = form.GetField("CircularRampMachinedDiameter");
        field.SetValue(progParam.CircularRampMachinedDiameter.ToString());
        pdfDoc.Close();
        return memStream;
    }
}