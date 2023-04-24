using System;
using System.IO;
using iText.Kernel.Pdf;
using iText.Forms;
using iText.Forms.Fields;
using Microsoft.AspNetCore.Mvc;
using iText.Layout;
using System.Net;
using System.Net.Http.Headers;
using System.Web.Http.Results;
using Microsoft.AspNetCore.Http;

namespace MachinistSAssistant.Services.Documentation;
public class SLHMill: ISLHMill
{
    private readonly string _templateFilePath;
    public SLHMill(IConfiguration configuration)
    {
        _templateFilePath = configuration.GetValue<string>("Template:SLHMillFilePath");
    }

    public IResult GetDocumentation(Models.ProgramParameters.SLHMill progParam)
    {
        byte[] pdfBytes;
        var stream = new MemoryStream();

        using (var reader = new PdfReader(_templateFilePath))
        using (var writer = new PdfWriter(stream))
        using (var pdfDocument = new PdfDocument(reader, writer))
        using (var document = new Document(pdfDocument))
        {
            writer.SetCloseStream(false);
            PdfAcroForm form = PdfAcroForm.GetAcroForm(pdfDocument, true);
            PdfFormField field = form.GetField("CircularRampMachinedDiameter");
            field.SetValue(progParam.CircularRampMachinedDiameter.ToString());
            document.Close();
            pdfBytes = stream.ToArray();
        }
        return Results.File(pdfBytes, "application/pdf", "test.pdf");
    }
}