using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateCalculator.Application.Interfaces
{
    public interface IDocumentGenerationService
    {
        void CreateDocument(string filepath);
        void CreatePDF(string filepath);
        void CreateHTML(string filepath);
    }
}
