using LYRA.Models;
using LYRA.Models.Examens;
using LYRA.Pages.Parametre;
using Microsoft.AspNetCore.Mvc;

namespace LYRA.Controllers.ControllerDentiste
{
    [Route("api_dentiste/[controller]/[action]")]
    [ApiController]
    public class DentisteExportController : ControllerBase, IRapportInterface
    {
        private const string XlsxContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

        private readonly FICHISTEContext? _context;
        private readonly ADHESIONContext? _adContext;
        private readonly EXAMENSContext? _examContext;
        public DentisteExportController(FICHISTEContext context, ADHESIONContext adContext, EXAMENSContext examContext)
        {
            _context = context;
            _adContext = adContext;
            _examContext = examContext;
        }
        public Task ExportAllJour()
        {
            throw new NotImplementedException();
        }

        public Task ExportFamJour()
        {
            throw new NotImplementedException();
        }

        public Task ExportTravJour()
        {
            throw new NotImplementedException();
        }

        public Task ExportInDate()
        {
            throw new NotImplementedException();
        }

        public Task ExportEntreDeuxDate()
        {
            throw new NotImplementedException();
        }

        public Task ExportDateSpecifique()
        {
            throw new NotImplementedException();
        }

        public Task ExportTravDeuxDate()
        {
            throw new NotImplementedException();
        }

        public Task ExportFamDeuxDate()
        {
            throw new NotImplementedException();
        }

        public Task ExportTravInDate()
        {
            throw new NotImplementedException();
        }

        public Task ExportFamInDate()
        {
            throw new NotImplementedException();
        }

        public Task ExportFamInDateParEtab()
        {
            throw new NotImplementedException();
        }

        public Task ExportTravInDateParEtab()
        {
            throw new NotImplementedException();
        }

        public Task ExportFamDeuxDateParEtab()
        {
            throw new NotImplementedException();
        }

        public Task ExportTravDeuxDateParEtab()
        {
            throw new NotImplementedException();
        }

        public Task ExportEtabInDate()
        {
            throw new NotImplementedException();
        }

        public Task ExportEtabDeuxDate()
        {
            throw new NotImplementedException();
        }

        public class DateClass
        {
            public string? d0 { get; set; }
            public string? d1 { get; set; }
            public string? d2 { get; set; }
        }
    }
}
