using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.OleDb;
using System.IO;
using Import_From_Excel.Models.DataContext;
using Import_From_Excel.Models;

namespace Import_From_Excel.Controllers
{
    public class HomeController : Controller
    {

        SqlConnection sqlConnection = 
            new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        OleDbConnection oleconnection;

        public ActionResult Index()
        {            
            return View(dataContext.Addresses.ToList());
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase excelfile)
        {
            string filename = Guid.NewGuid() + Path.GetExtension(excelfile.FileName);
            string filepath = "/FileImport/" + filename;
            excelfile.SaveAs(Path.Combine(Server.MapPath("/FileImport"), filename));
            InsertExcel(filepath, filename);

            return View(dataContext.Addresses.ToList());
        }

        private ImportDataContext dataContext = new ImportDataContext();


        private void ExcelConnection(string filepath)
        {
            string constring = "";
            if (filepath.EndsWith(".xlsx"))
            {
                constring = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=""Excel 12.0 Xml;HDR=YES;""", filepath);
            }
            else if (filepath.EndsWith(".xls"))
            {
                constring = string.Format(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=""Excel 8.0;HDR=YES;IMEX=2\""" , filepath);
            }
                        
            oleconnection = new OleDbConnection(constring);
        }

        private void InsertExcel (string path, string filename)
        {
            try
            {
                if (filename.EndsWith(".xls") || filename.EndsWith(".xlsx"))
                {
                    string fullpath = Server.MapPath("/FileImport/") + filename;
                    ExcelConnection(fullpath);
                    string query = string.Format("Select [ID], [MAIN_STREET_NAME], [MAIN_STREET_NUMBER], [MAIN_STREET_FLAT_NUMBER], [MAIN_POST_CODE], [MAIN_POST_OFFICE_CITY], [CORRESPONDENCE_STREET_NAME], [CORRESPONDENCE_STREET_NUMBER], [CORRESPONDENCE_STREET_FLAT_NUMBER], [CORRESPONDENCE_POST_CODE], [CORRESPONDENCE_POST_OFFICE_CITY] FROM [{0}]", "Arkusz1$");
                    OleDbCommand oleDbCommand = new OleDbCommand(query, oleconnection);
                    oleconnection.Open();

                    DataSet dataSet = new DataSet();
                    OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, oleconnection);
                    oleconnection.Close();
                    dataAdapter.Fill(dataSet);

                    DataTable dataTable = dataSet.Tables[0];

                    SqlBulkCopy sqlBulk = new SqlBulkCopy(sqlConnection);
                    sqlBulk.DestinationTableName = "Addresses";
                    sqlBulk.ColumnMappings.Add("ID", "AddressId");
                    sqlBulk.ColumnMappings.Add("MAIN_STREET_NAME", "StreetName");
                    sqlBulk.ColumnMappings.Add("MAIN_STREET_NUMBER", "StreetNumber");
                    sqlBulk.ColumnMappings.Add("MAIN_STREET_FLAT_NUMBER", "FlatNumber");
                    sqlBulk.ColumnMappings.Add("MAIN_POST_CODE", "PostCode");
                    sqlBulk.ColumnMappings.Add("MAIN_POST_OFFICE_CITY", "PostOfficeCity");
                    sqlBulk.ColumnMappings.Add("CORRESPONDENCE_STREET_NAME", "CorrespondenceStreetName");
                    sqlBulk.ColumnMappings.Add("CORRESPONDENCE_STREET_NUMBER", "CorrespondenceStreetnumber");
                    sqlBulk.ColumnMappings.Add("CORRESPONDENCE_STREET_FLAT_NUMBER", "CorrespondenceFlatNumber");
                    sqlBulk.ColumnMappings.Add("CORRESPONDENCE_POST_CODE", "CorrespondencePostCode");
                    sqlBulk.ColumnMappings.Add("CORRESPONDENCE_POST_OFFICE_CITY", "CorrespondencePostOfficeCity");


                    sqlConnection.Open();
                    sqlBulk.WriteToServer(dataTable);
                    sqlConnection.Close();                
                    
                }
                else
                {
                    ViewBag.Error = "Proszę wybrać plik Excel (.xls lub .xlsx)<br>";
                }
            }
            catch (Exception ex)
            {               
                throw ex;
            }                   
        }
    }
}