using LYRA.Models;
using LYRA.Models.RapportModele;
using OfficeOpenXml;
using OfficeOpenXml.Table;

namespace LYRA
{
    public class UtilsSoin
    {
        public static ExcelPackage DownloadTravInDate(List<RapportParamList> fModels, DateTime date)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var package = new ExcelPackage();

            //Add a new worksheet to the empty workbook
            var worksheet = package.Workbook.Worksheets.Add("Rapport journalier du : " + date.ToLongDateString());
            //Defining the tables parameters
            int firstRow = 3;
            int lastRow = 3 + fModels.Count;
            int firstColumn = 1;
            int lastColumn = 12;
            ExcelRange rg = worksheet.Cells[firstRow, firstColumn, lastRow, lastColumn];
            string tableName = "SOIM";
            //Ading a table to a Range
            ExcelTable tab = worksheet.Tables.Add(rg, tableName);
            //Formating the table style
            tab.TableStyle = TableStyles.Light8;

            //TITRE
            worksheet.Cells[1, 1].Value = "RAPPORT SOIN";
            //Add the headers
            worksheet.Cells[3, 1].Value = "DATE";
            worksheet.Column(1).Width = 17;
            worksheet.Cells[3, 2].Value = "N° DU JOUR";
            worksheet.Column(2).Width = 13;
            worksheet.Cells[3, 3].Value = "NOM ET PRENOM";
            worksheet.Column(3).Width = 35;
            worksheet.Cells[3, 4].Value = "ETABLISSEMENT";
            worksheet.Column(4).Width = 25;
            worksheet.Cells[3, 5].Value = "CAT";
            worksheet.Column(5).Width = 10;
            worksheet.Cells[3, 6].Value = "N° OSIET";
            worksheet.Column(6).Width = 13;
            worksheet.Cells[3, 7].Value = "T° G";
            worksheet.Column(7).Width = 10;
            worksheet.Cells[3, 8].Value = "T° D";
            worksheet.Column(8).Width = 10;
            worksheet.Cells[3, 9].Value = "TEMP";
            worksheet.Column(9).Width = 10;
            worksheet.Cells[3, 10].Value = "POIDS";
            worksheet.Column(10).Width = 10;
            worksheet.Cells[3, 11].Value = "MEDECIN";
            worksheet.Column(11).Width = 24;
            worksheet.Cells[3, 12].Value = "OBSERVATION";
            worksheet.Column(12).Width = 20;

            //DATE DU RAPPORT
            worksheet.Cells[2, 8].Value = "Date";
            if (fModels.Count() > 0)
                worksheet.Cells[2, 9].Value = date.ToShortDateString();
            int i = 3;
            foreach (var fModel in fModels)
            {
                worksheet.Cells[i + 1, 1].Value = fModel.Date.Value.ToString("dd MMMM yyyy");
                worksheet.Cells[i + 1, 2].Value = fModel.NumJour;
                worksheet.Cells[i + 1, 3].Value = fModel.NomComplet;
                worksheet.Cells[i + 1, 4].Value = fModel.Etablissement;
                worksheet.Cells[i + 1, 5].Value = fModel.Categorie;
                worksheet.Cells[i + 1, 6].Value = fModel.NumOSIET;
                worksheet.Cells[i + 1, 7].Value = fModel.TG;
                worksheet.Cells[i + 1, 8].Value = fModel.TD;
                worksheet.Cells[i + 1, 9].Value = fModel.Temperature;
                worksheet.Cells[i + 1, 10].Value = fModel.Poids;
                worksheet.Cells[i + 1, 11].Value = fModel.Medecin;
                worksheet.Cells[i + 1, 12].Value = fModel.Observation;
                i++;
            }

            return package;
        }

        public static ExcelPackage DownloadTravInTwoDate(List<RapportParamList> fModels, DateTime date1, DateTime date2)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var package = new ExcelPackage();

            //Add a new worksheet to the empty workbook
            var worksheet = package.Workbook.Worksheets.Add("Rapport journalier du : " + date1.ToLongDateString() + " au " + date2.ToLongDateString());

            //Defining the tables parameters
            int firstRow = 3;
            int lastRow = 3 + fModels.Count;
            int firstColumn = 1;
            int lastColumn = 12;
            ExcelRange rg = worksheet.Cells[firstRow, firstColumn, lastRow, lastColumn];
            string tableName = "PARAMÈTRE";
            //Ading a table to a Range
            ExcelTable tab = worksheet.Tables.Add(rg, tableName);
            //Formating the table style
            tab.TableStyle = TableStyles.Light8;

            //TITRE
            worksheet.Cells[1, 1].Value = "RAPPORT PARAMÈTRE";
            //Add the headers
            worksheet.Cells[3, 1].Value = "DATE";
            worksheet.Column(1).Width = 17;
            worksheet.Cells[3, 2].Value = "N° DU JOUR";
            worksheet.Column(2).Width = 13;
            worksheet.Cells[3, 3].Value = "NOM ET PRENOM";
            worksheet.Column(3).Width = 35;
            worksheet.Cells[3, 4].Value = "ETABLISSEMENT";
            worksheet.Column(4).Width = 25;
            worksheet.Cells[3, 5].Value = "CAT";
            worksheet.Column(5).Width = 10;
            worksheet.Cells[3, 6].Value = "N° OSIET";
            worksheet.Column(6).Width = 13;
            worksheet.Cells[3, 7].Value = "T° G";
            worksheet.Column(7).Width = 10;
            worksheet.Cells[3, 8].Value = "T° D";
            worksheet.Column(8).Width = 10;
            worksheet.Cells[3, 9].Value = "TEMP";
            worksheet.Column(9).Width = 10;
            worksheet.Cells[3, 10].Value = "POIDS";
            worksheet.Column(10).Width = 10;
            worksheet.Cells[3, 11].Value = "MEDECIN";
            worksheet.Column(11).Width = 24;
            worksheet.Cells[3, 12].Value = "OBSERVATION";
            worksheet.Column(12).Width = 20;

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
                worksheet.Cells[i + 1, 1].Value = fModel.Date.Value.ToString("dd MMMM yyyy");
                worksheet.Cells[i + 1, 2].Value = fModel.NumJour;
                worksheet.Cells[i + 1, 3].Value = fModel.NomComplet;
                worksheet.Cells[i + 1, 4].Value = fModel.Etablissement;
                worksheet.Cells[i + 1, 5].Value = fModel.Categorie;
                worksheet.Cells[i + 1, 6].Value = fModel.NumOSIET;
                worksheet.Cells[i + 1, 7].Value = fModel.TG;
                worksheet.Cells[i + 1, 8].Value = fModel.TD;
                worksheet.Cells[i + 1, 9].Value = fModel.Temperature;
                worksheet.Cells[i + 1, 10].Value = fModel.Poids;
                worksheet.Cells[i + 1, 11].Value = fModel.Medecin;
                worksheet.Cells[i + 1, 12].Value = fModel.Observation;
                i++;
            }

            return package;
        }
    }
}
