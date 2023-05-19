using LYRA.Models;
using OfficeOpenXml;
using OfficeOpenXml.Table;

namespace LYRA
{
    public class Utils
    {
        public static ExcelPackage DownloadAllJournalier(List<FichisteModel> fModels)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var package = new ExcelPackage();

            //Add a new worksheet to the empty workbook
            var worksheet = package.Workbook.Worksheets.Add("Rapport journalier");

            //Defining the tables parameters
            int firstRow = 3;
            int lastRow = 3 + fModels.Count;
            int firstColumn = 1;
            int lastColumn = 11;
            ExcelRange rg = worksheet.Cells[firstRow, firstColumn, lastRow, lastColumn];
            string tableName = "fichiste";
            //Ading a table to a Range
            ExcelTable tab = worksheet.Tables.Add(rg, tableName);
            //Formating the table style
            tab.TableStyle = TableStyles.Light8;

            //TITRE
            worksheet.Cells[1, 1].Value = "RAPPORT JOURNALIER FICHISTE";
            //Add the headers
            worksheet.Cells[3, 1].Value = "N° DU JOUR";
            worksheet.Cells[3, 2].Value = "N° OSIET";
            worksheet.Cells[3, 3].Value = "DATE";
            worksheet.Cells[3, 4].Value = "HEURE D'ENREG";
            worksheet.Cells[3, 5].Value = "NOM ET PRENOM";
            worksheet.Cells[3, 6].Value = "ETABLISSEMENT";
            worksheet.Cells[3, 7].Value = "CATEGORIE";
            worksheet.Cells[3, 8].Value = "FREQUENCE DU MOIS";
            worksheet.Cells[3, 9].Value = "FREQUENCE DE L'ANNEE";
            worksheet.Cells[3, 10].Value = "PARAMETRE";
            worksheet.Cells[3, 11].Value = "FICHISTE";
            worksheet.Column(1).Width = 12;
            worksheet.Column(2).Width = 13;
            worksheet.Column(3).Width = 18;
            worksheet.Column(4).Width = 18;
            worksheet.Column(5).Width = 28;
            worksheet.Column(6).Width = 15;
            worksheet.Column(7).Width = 18;
            worksheet.Column(8).Width = 24.14;
            worksheet.Column(9).Width = 15;
            worksheet.Column(10).Width = 18;
            worksheet.Column(11).Width = 28;

            //DATE DU RAPPORT
            worksheet.Cells[2, 8].Value = "Date";
            if (fModels.Count() > 0)
                worksheet.Cells[2, 9].Value = fModels.ElementAt(0).FDateCreate.Value.ToLongDateString();
            int i = 3;
            foreach (var fModel in fModels)
            {
                worksheet.Cells[i + 1, 1].Value = fModel.FNumero;
                worksheet.Cells[i + 1, 2].Value = fModel.FNumeroosiet;
                worksheet.Cells[i + 1, 3].Value = fModel.FDateCreate.Value.ToString("dd MMMM yyyy");
                worksheet.Cells[i + 1, 4].Value = fModel.FDateCreate.Value.ToShortTimeString();
                worksheet.Cells[i + 1, 5].Value = fModel.FName;
                worksheet.Cells[i + 1, 6].Value = fModel.FEtablissement;
                worksheet.Cells[i + 1, 7].Value = fModel.FCategorie;
                worksheet.Cells[i + 1, 8].Value = fModel.FFrequenceM;
                worksheet.Cells[i + 1, 9].Value = fModel.FFrequenceY;
                worksheet.Cells[i + 1, 10].Value = fModel.FParametre;
                worksheet.Cells[i + 1, 11].Value = fModel.FNomfichiste;
                
                i++;
            }

            return package;
        }

        public static ExcelPackage DownloadFamJournalier(List<FichisteModel> fModels)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var package = new ExcelPackage();

            //Add a new worksheet to the empty workbook
            var worksheet = package.Workbook.Worksheets.Add("Rapport journalier pour les familles");

            //Defining the tables parameters
            int firstRow = 3;
            int lastRow = 3 + fModels.Count;
            int firstColumn = 1;
            int lastColumn = 11;
            ExcelRange rg = worksheet.Cells[firstRow, firstColumn, lastRow, lastColumn];
            string tableName = "fichiste";
            //Ading a table to a Range
            ExcelTable tab = worksheet.Tables.Add(rg, tableName);
            //Formating the table style
            tab.TableStyle = TableStyles.Light8;

            //TITRE
            worksheet.Cells[1, 1].Value = "RAPPORT JOURNALIER FICHISTE";
            //Add the headers
            worksheet.Cells[3, 1].Value = "N° DU JOUR";
            worksheet.Cells[3, 2].Value = "N° OSIET";
            worksheet.Cells[3, 3].Value = "DATE";
            worksheet.Cells[3, 4].Value = "HEURE D'ENREG";
            worksheet.Cells[3, 5].Value = "NOM ET PRENOM";
            worksheet.Cells[3, 6].Value = "ETABLISSEMENT";
            worksheet.Cells[3, 7].Value = "CATEGORIE";
            worksheet.Cells[3, 8].Value = "FREQUENCE DU MOIS";
            worksheet.Cells[3, 9].Value = "FREQUENCE DE L'ANNEE";
            worksheet.Cells[3, 10].Value = "PARAMETRE";
            worksheet.Cells[3, 11].Value = "FICHISTE";
            worksheet.Column(1).Width = 12;
            worksheet.Column(2).Width = 13;
            worksheet.Column(3).Width = 18;
            worksheet.Column(4).Width = 18;
            worksheet.Column(5).Width = 28;
            worksheet.Column(6).Width = 15;
            worksheet.Column(7).Width = 18;
            worksheet.Column(8).Width = 24.14;
            worksheet.Column(9).Width = 15;
            worksheet.Column(10).Width = 18;
            worksheet.Column(11).Width = 28;

            //DATE DU RAPPORT
            worksheet.Cells[2, 8].Value = "Date";
            if (fModels.Count() > 0)
                worksheet.Cells[2, 9].Value = fModels.ElementAt(0).FDateCreate.Value.ToLongDateString();
            int i = 3;
            foreach (var fModel in fModels)
            {
                worksheet.Cells[i + 1, 1].Value = fModel.FNumero;
                worksheet.Cells[i + 1, 2].Value = fModel.FNumeroosiet;
                worksheet.Cells[i + 1, 3].Value = fModel.FDateCreate.Value.ToString("dd MMMM yyyy");
                worksheet.Cells[i + 1, 4].Value = fModel.FDateCreate.Value.ToShortTimeString();
                worksheet.Cells[i + 1, 5].Value = fModel.FName;
                worksheet.Cells[i + 1, 6].Value = fModel.FEtablissement;
                worksheet.Cells[i + 1, 7].Value = fModel.FCategorie;
                worksheet.Cells[i + 1, 8].Value = fModel.FFrequenceM;
                worksheet.Cells[i + 1, 9].Value = fModel.FFrequenceY;
                worksheet.Cells[i + 1, 10].Value = fModel.FParametre;
                worksheet.Cells[i + 1, 11].Value = fModel.FNomfichiste;
                i++;
            }

            return package;
        }

        public static ExcelPackage DownloadTravJournalier(List<FichisteModel> fModels)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var package = new ExcelPackage();

            //Add a new worksheet to the empty workbook
            var worksheet = package.Workbook.Worksheets.Add("Rapport journalier pour les travailleurs");

            //Defining the tables parameters
            int firstRow = 3;
            int lastRow = 3 + fModels.Count;
            int firstColumn = 1;
            int lastColumn = 11;
            ExcelRange rg = worksheet.Cells[firstRow, firstColumn, lastRow, lastColumn];
            string tableName = "fichiste";
            //Ading a table to a Range
            ExcelTable tab = worksheet.Tables.Add(rg, tableName);
            //Formating the table style
            tab.TableStyle = TableStyles.Light8;

            //TITRE
            worksheet.Cells[1, 1].Value = "RAPPORT JOURNALIER FICHISTE";
            //Add the headers
            worksheet.Cells[3, 1].Value = "N° DU JOUR";
            worksheet.Cells[3, 2].Value = "N° OSIET";
            worksheet.Cells[3, 3].Value = "DATE";
            worksheet.Cells[3, 4].Value = "HEURE D'ENREG";
            worksheet.Cells[3, 5].Value = "NOM ET PRENOM";
            worksheet.Cells[3, 6].Value = "ETABLISSEMENT";
            worksheet.Cells[3, 7].Value = "CATEGORIE";
            worksheet.Cells[3, 8].Value = "FREQUENCE DU MOIS";
            worksheet.Cells[3, 9].Value = "FREQUENCE DE L'ANNEE";
            worksheet.Cells[3, 10].Value = "PARAMETRE";
            worksheet.Cells[3, 11].Value = "FICHISTE";
            worksheet.Column(1).Width = 12;
            worksheet.Column(2).Width = 13;
            worksheet.Column(3).Width = 18;
            worksheet.Column(4).Width = 18;
            worksheet.Column(5).Width = 28;
            worksheet.Column(6).Width = 15;
            worksheet.Column(7).Width = 18;
            worksheet.Column(8).Width = 24.14;
            worksheet.Column(9).Width = 15;
            worksheet.Column(10).Width = 18;
            worksheet.Column(11).Width = 28;

            //DATE DU RAPPORT
            worksheet.Cells[2, 8].Value = "Date";
            if (fModels.Count() > 0)
                worksheet.Cells[2, 9].Value = fModels.ElementAt(0).FDateCreate.Value.ToLongDateString();
            int i = 3;
            foreach (var fModel in fModels)
            {
                worksheet.Cells[i + 1, 1].Value = fModel.FNumero;
                worksheet.Cells[i + 1, 2].Value = fModel.FNumeroosiet;
                worksheet.Cells[i + 1, 3].Value = fModel.FDateCreate.Value.ToString("dd MMMM yyyy");
                worksheet.Cells[i + 1, 4].Value = fModel.FDateCreate.Value.ToShortTimeString();
                worksheet.Cells[i + 1, 5].Value = fModel.FName;
                worksheet.Cells[i + 1, 6].Value = fModel.FEtablissement;
                worksheet.Cells[i + 1, 7].Value = fModel.FCategorie;
                worksheet.Cells[i + 1, 8].Value = fModel.FFrequenceM;
                worksheet.Cells[i + 1, 9].Value = fModel.FFrequenceY;
                worksheet.Cells[i + 1, 10].Value = fModel.FParametre;
                worksheet.Cells[i + 1, 11].Value = fModel.FNomfichiste;
                i++;
            }

            return package;
        }
        
        public static ExcelPackage DownloadTravInDate(List<FichisteModel> fModels, DateTime date)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var package = new ExcelPackage();

            //Add a new worksheet to the empty workbook
            var worksheet = package.Workbook.Worksheets.Add("Rapport journalier du : " + date.ToLongDateString());
            //Defining the tables parameters
            int firstRow = 3;
            int lastRow = 3 + fModels.Count;
            int firstColumn = 1;
            int lastColumn = 11;
            ExcelRange rg = worksheet.Cells[firstRow, firstColumn, lastRow, lastColumn];
            string tableName = "fichiste";
            //Ading a table to a Range
            ExcelTable tab = worksheet.Tables.Add(rg, tableName);
            //Formating the table style
            tab.TableStyle = TableStyles.Light8;

            //TITRE
            worksheet.Cells[1, 1].Value = "RAPPORT JOURNALIER FICHISTE";
            //Add the headers
            worksheet.Cells[3, 1].Value = "N° DU JOUR";
            worksheet.Cells[3, 2].Value = "N° OSIET";
            worksheet.Cells[3, 3].Value = "DATE";
            worksheet.Cells[3, 4].Value = "HEURE D'ENREG";
            worksheet.Cells[3, 5].Value = "NOM ET PRENOM";
            worksheet.Cells[3, 6].Value = "ETABLISSEMENT";
            worksheet.Cells[3, 7].Value = "CATEGORIE";
            worksheet.Cells[3, 8].Value = "FREQUENCE DU MOIS";
            worksheet.Cells[3, 9].Value = "FREQUENCE DE L'ANNEE";
            worksheet.Cells[3, 10].Value = "PARAMETRE";
            worksheet.Cells[3, 11].Value = "FICHISTE";
            worksheet.Column(1).Width = 12;
            worksheet.Column(2).Width = 13;
            worksheet.Column(3).Width = 18;
            worksheet.Column(4).Width = 18;
            worksheet.Column(5).Width = 28;
            worksheet.Column(6).Width = 15;
            worksheet.Column(7).Width = 18;
            worksheet.Column(8).Width = 24.14;
            worksheet.Column(9).Width = 15;
            worksheet.Column(10).Width = 18;
            worksheet.Column(11).Width = 28;

            //DATE DU RAPPORT
            worksheet.Cells[2, 8].Value = "Date";
            if (fModels.Count() > 0)
                worksheet.Cells[2, 9].Value = date.ToShortDateString();
            int i = 3;
            foreach (var fModel in fModels)
            {
                worksheet.Cells[i + 1, 1].Value = fModel.FNumero;
                worksheet.Cells[i + 1, 2].Value = fModel.FNumeroosiet;
                worksheet.Cells[i + 1, 3].Value = fModel.FDateCreate.Value.ToString("dd MMMM yyyy");
                worksheet.Cells[i + 1, 4].Value = fModel.FDateCreate.Value.ToShortTimeString();
                worksheet.Cells[i + 1, 5].Value = fModel.FName;
                worksheet.Cells[i + 1, 6].Value = fModel.FEtablissement;
                worksheet.Cells[i + 1, 7].Value = fModel.FCategorie;
                worksheet.Cells[i + 1, 8].Value = fModel.FFrequenceM;
                worksheet.Cells[i + 1, 9].Value = fModel.FFrequenceY;
                worksheet.Cells[i + 1, 10].Value = fModel.FParametre;
                worksheet.Cells[i + 1, 11].Value = fModel.FNomfichiste;
                i++;
            }

            return package;
        }
        
        public static ExcelPackage DownloadTravInTwoDate(List<FichisteModel> fModels, DateTime date1,DateTime date2)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var package = new ExcelPackage();

            //Add a new worksheet to the empty workbook
            var worksheet = package.Workbook.Worksheets.Add("Rapport journalier du : " + date1.ToLongDateString() + " au " + date2.ToLongDateString());

            //Defining the tables parameters
            int firstRow = 3;
            int lastRow = 3 + fModels.Count;
            int firstColumn = 1;
            int lastColumn = 11;
            ExcelRange rg = worksheet.Cells[firstRow, firstColumn, lastRow, lastColumn];
            string tableName = "fichiste";
            //Ading a table to a Range
            ExcelTable tab = worksheet.Tables.Add(rg, tableName);
            //Formating the table style
            tab.TableStyle = TableStyles.Light8;

            //TITRE
            worksheet.Cells[1, 1].Value = "RAPPORT JOURNALIER FICHISTE";
            //Add the headers
            worksheet.Cells[3, 1].Value = "N° DU JOUR";
            worksheet.Cells[3, 2].Value = "N° OSIET";
            worksheet.Cells[3, 3].Value = "DATE";
            worksheet.Cells[3, 4].Value = "HEURE D'ENREG";
            worksheet.Cells[3, 5].Value = "NOM ET PRENOM";
            worksheet.Cells[3, 6].Value = "ETABLISSEMENT";
            worksheet.Cells[3, 7].Value = "CATEGORIE";
            worksheet.Cells[3, 8].Value = "FREQUENCE DU MOIS";
            worksheet.Cells[3, 9].Value = "FREQUENCE DE L'ANNEE";
            worksheet.Cells[3, 10].Value = "PARAMETRE";
            worksheet.Cells[3, 11].Value = "FICHISTE";
            worksheet.Column(1).Width = 12;
            worksheet.Column(2).Width = 13;
            worksheet.Column(3).Width = 18;
            worksheet.Column(4).Width = 18;
            worksheet.Column(5).Width = 28;
            worksheet.Column(6).Width = 15;
            worksheet.Column(7).Width = 18;
            worksheet.Column(8).Width = 24.14;
            worksheet.Column(9).Width = 15;
            worksheet.Column(10).Width = 18;
            worksheet.Column(11).Width = 28;

            //DATE DU RAPPORT
            worksheet.Cells[2, 7].Value = "Date debut du rapport :";
            if (fModels.Count() > 0)
            {
                worksheet.Cells[2, 8].Value = date1.ToShortDateString();
            }
            worksheet.Cells[2, 9].Value = "Date fin du rapport : ";
            if (fModels.Count() > 0)
            {
                worksheet.Cells[2, 10].Value = date2.ToShortDateString();
            }
            int i = 3;
            foreach (var fModel in fModels)
            {
                worksheet.Cells[i + 1, 1].Value = fModel.FNumero;
                worksheet.Cells[i + 1, 2].Value = fModel.FNumeroosiet;
                worksheet.Cells[i + 1, 3].Value = fModel.FDateCreate.Value.ToString("dd MMMM yyyy");
                worksheet.Cells[i + 1, 4].Value = fModel.FDateCreate.Value.ToShortTimeString();
                worksheet.Cells[i + 1, 5].Value = fModel.FName;
                worksheet.Cells[i + 1, 6].Value = fModel.FEtablissement;
                worksheet.Cells[i + 1, 7].Value = fModel.FCategorie;
                worksheet.Cells[i + 1, 8].Value = fModel.FFrequenceM;
                worksheet.Cells[i + 1, 9].Value = fModel.FFrequenceY;
                worksheet.Cells[i + 1, 10].Value = fModel.FParametre;
                worksheet.Cells[i + 1, 11].Value = fModel.FNomfichiste;
                i++;
            }

            return package;
        }

    }
}
