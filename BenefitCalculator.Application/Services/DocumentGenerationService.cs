using Aspose.Words;
using Aspose.Pdf;
using Aspose.Pdf.Text;
using RateCalculator.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.Html;
using Aspose.Html.Saving;

namespace RateCalculator.Application.Services
{
    public class DocumentGenerationService : IDocumentGenerationService
    {
        private readonly IRepository _repository;

        public DocumentGenerationService(IRepository repository)
        {
            _repository = repository;
        }


        //Aspose.word doc gen
        public void CreateDocument(string filepath)
        {
            Aspose.Words.Document doc = new Aspose.Words.Document();
            DocumentBuilder builder = new DocumentBuilder(doc);

            var result = _repository.GetPlanEffectiveDate();

            builder.Write("Hello from Aspose.Words" + "Sample out from db - Plan Effective date: " + result.Value);

            doc.Save(filepath);
        }

        //aspose.pdf doc gen
        public void CreatePDF(string filepath)
        {
            Aspose.Pdf.Document document = new Aspose.Pdf.Document();
            Page page = document.Pages.Add();

            //creating text fragment
            TextFragment textfragment = new TextFragment("Hello, this is test pdf from Aspose.PDF");
            textfragment.Position = new Position(100, 800);

            //set text props
            textfragment.TextState.FontSize = 14;
            textfragment.TextState.FontStyle = FontStyles.Bold | FontStyles.Italic;
            textfragment.TextState.ForegroundColor = Color.Beige;

            TextBuilder textBuilder = new TextBuilder(page);
            textBuilder.AppendText(textfragment);

            document.Save(filepath);
        }

        //aspose.html dic gen
        public void CreateHTML(string filepath)
        {
            using(var document = new HTMLDocument())
            {
                document.Body.InnerHTML = "<p>HTML File by Aspose</p>";

                document.Save(filepath);
            }
        }
    }
}
