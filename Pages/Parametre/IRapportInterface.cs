namespace LYRA.Pages.Parametre
{
    public interface IRapportInterface
    {
        public Task ExportAllJour();
        public Task ExportFamJour();
        public Task ExportTravJour();
        public Task ExportInDate();
        public Task ExportEntreDeuxDate();
        public Task ExportDateSpecifique();
        public Task ExportTravDeuxDate();
        public Task ExportFamDeuxDate();
        public Task ExportTravInDate();
        public Task ExportFamInDate();
        public Task ExportFamInDateParEtab();
        public Task ExportTravInDateParEtab();
        public Task ExportFamDeuxDateParEtab();
        public Task ExportTravDeuxDateParEtab();
        public Task ExportEtabInDate();
        public Task ExportEtabDeuxDate();
        
    }
}
