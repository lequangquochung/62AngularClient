using System.Security.AccessControl;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using OfficeOpenXml;
using OfficeOpenXml.Table;


using OfficeOpenXml.Style;
using System.Drawing;
using UserManager.BAL.Interface;
using OfficeOpenXml.FormulaParsing.Excel.Functions.DateTime;

namespace UserManager.API.Controllers
{
    [Produces("application/json")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        [Obsolete]
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly ICustomerService customer;
        private readonly IJobService job;

        [Obsolete]
        public ReportController(IHostingEnvironment hostingEnvironment, ICustomerService customer, IJobService job)
        {
            this.hostingEnvironment = hostingEnvironment;
            this.customer = customer;
            this.job = job;
        }


        [HttpGet]
        [Route("api/export/listCustomer")]
        public async Task<string> ExportReport()
        {
            string rootFolder = hostingEnvironment.WebRootPath;
            string fileName = "ExportReport.xlsx";
            string downloadUrl = string.Format("{0}://{1}/{2}", Request.Scheme, Request.Host, fileName);
            FileInfo file = new FileInfo(Path.Combine(rootFolder, fileName));
            if (file.Exists)
            {
                file.Delete();
                file = new FileInfo(Path.Combine(rootFolder, fileName));
            }
            await Task.Yield();

            using (ExcelPackage package = new ExcelPackage(file))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Customer");

                //FillBackGround(worksheet, 1, 1, 1, true);
                //FillBackGround(worksheet, 2, 2, 5, true);
                var CustomerList = customer.AllCustomer();
                worksheet.Cells[3, 2].LoadFromCollection(CustomerList, true, TableStyles.Light19);
                worksheet.DeleteColumn(2);
                worksheet.DeleteColumn(11);
                worksheet.DefaultColWidth = 25;
                worksheet.Cells.Style.WrapText = true;
                worksheet.Cells[1, 5].Value = $"List All  Customer :({CustomerList.Count})";
                using (ExcelRange Rng = worksheet.Cells[1, 5, 1, 7])
                {
                    Rng.Merge = true;
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Size = 18;
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                }

                //ExcelWorksheet worksheet2 = package.Workbook.Worksheets.Add("joblist");               
                //var JobList = job.JobList();
                //worksheet2.Cells[3, 5].LoadFromCollection(JobList, true, TableStyles.Light19);
                //worksheet2.DeleteColumn(2);
                //worksheet2.DeleteColumn(11);
                //worksheet2.DefaultColWidth = 25;
                //worksheet2.Cells.Style.WrapText = true;
                //worksheet2.Cells[1, 5].Value = $"Job List :({JobList.Count})";
                //using (ExcelRange Rng = worksheet2.Cells[1, 5, 1, 7])
                //{
                //    Rng.Merge = true;
                //    Rng.Style.Font.Bold = true;
                //    Rng.Style.Font.Size = 18;
                //    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                //}
                //return downloadUrl;
            }
        }
        [HttpGet]
        [Route("api/export/JobList")]
        public async Task<string> ExportReport()
        {
            string rootFolder = hostingEnvironment.WebRootPath;
            string fileName = "ExportReport.xlsx";
            string downloadUrl = string.Format("{0}://{1}/{2}", Request.Scheme, Request.Host, fileName);
            FileInfo file = new FileInfo(Path.Combine(rootFolder, fileName));
            if (file.Exists)
            {
                file.Delete();
                file = new FileInfo(Path.Combine(rootFolder, fileName));
            }
            await Task.Yield();

            using (ExcelPackage package = new ExcelPackage(file))
            {
                ExcelWorksheet worksheet2 = package.Workbook.Worksheets.Add("joblist");
                var JobList = job.JobList();
                worksheet2.Cells[3, 5].LoadFromCollection(JobList, true, TableStyles.Light19);
                worksheet2.DeleteColumn(2);
                worksheet2.DeleteColumn(11);
                worksheet2.DefaultColWidth = 25;
                worksheet2.Cells.Style.WrapText = true;
                worksheet2.Cells[1, 5].Value = $"Job List :({JobList.Count})";
                using (ExcelRange Rng = worksheet2.Cells[1, 5, 1, 7])
                {
                    Rng.Merge = true;
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Size = 18;
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                }
                return downloadUrl;
            }
        }

        [HttpGet]
        [Route("api/export/{id}")]
        public async Task<string> ExportReportWithJobId(int id)
        {
            string rootFolder = hostingEnvironment.WebRootPath;
            string fileName = "ExportReport.xlsx";
            string downloadUrl = string.Format("{0}://{1}/{2}", Request.Scheme, Request.Host, fileName);
            FileInfo file = new FileInfo(Path.Combine(rootFolder, fileName));
            if (file.Exists)
            {
                file.Delete();
                file = new FileInfo(Path.Combine(rootFolder, fileName));
            }
            await Task.Yield();

            using (ExcelPackage package = new ExcelPackage(file))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Customer");

                //FillBackGround(worksheet, 1, 1, 1, true);
                //FillBackGround(worksheet, 2, 2, 5, true);
                var CustomerList = customer.AllCustomer();
                worksheet.Cells[3, 2].LoadFromCollection(CustomerList, true, TableStyles.Light19);
                worksheet.DeleteColumn(2);
                worksheet.DeleteColumn(11);
                worksheet.DefaultColWidth = 25;
                worksheet.Cells.Style.WrapText = true;
                worksheet.Cells[1, 5].Value = $"List All  Customer :({CustomerList.Count})";
                using (ExcelRange Rng = worksheet.Cells[1, 5, 1, 7])
                {
                    Rng.Merge = true;
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Size = 18;
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                }

                ExcelWorksheet worksheet2 = package.Workbook.Worksheets.Add("joblist");

                //FillBackGround(worksheet, 1, 1, 1, true);
                //FillBackGround(worksheet, 2, 2, 5, true);
                var JobList = job.JobList();
                worksheet2.Cells[3, 5].LoadFromCollection(JobList, true, TableStyles.Light19);
                worksheet2.DeleteColumn(2);
                worksheet2.DeleteColumn(11);
                worksheet2.DefaultColWidth = 25;
                worksheet2.Cells.Style.WrapText = true;
                worksheet2.Cells[1, 5].Value = $"Job List :({JobList.Count})";
                using (ExcelRange Rng = worksheet2.Cells[1, 5, 1, 7])
                {
                    Rng.Merge = true;
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Size = 18;
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                }


                //FillBackGround(worksheet, 1, 1, 1, true);
                //FillBackGround(worksheet, 2, 2, 5, true);
                ExcelWorksheet worksheet3 = package.Workbook.Worksheets.Add($"CustomerOfJob");
                var CustomerByJob = customer.CustomerList(id);
                worksheet3.Cells[3, 2].LoadFromCollection(CustomerByJob, true, TableStyles.Light19);
                worksheet3.DeleteColumn(2);
                worksheet3.DeleteColumn(11);
                worksheet3.DeleteColumn(10);
                worksheet3.DefaultColWidth = 25;
                worksheet3.Cells.Style.WrapText = true;
                worksheet3.Cells[1, 5].Value = $"Customer of Job:({CustomerList.Count})";
                using (ExcelRange Rng = worksheet3.Cells[1, 5, 1, 7])
                {
                    Rng.Merge = true;
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Size = 18;
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                }
                package.Save();
            }
            return downloadUrl;
            }


        }
    }




