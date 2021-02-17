using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ExcelDataReader;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;

namespace WebAPISampleApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsureProductsController : ControllerBase
    {
        [HttpGet]
        [Route("GetInsureClaims")]
        public List<InsureMembersModel> GetInsureClaims(DateTime claimDate)
        {
           // DataTable claimdt = GetExcelDataData(@"C:\Samples\WebAPISampleApp\SampleData\Claim.xlsx");
          //  DataTable memberdt = GetExcelDataData(@"C:\Samples\WebAPISampleApp\SampleData\Member.xlsx");
            List<InsureMembersModel> mdlList = new List<InsureMembersModel>();
            mdlList.Add(new InsureMembersModel()
            {
                MemberId = "1",
                MemberName = "Test1",
                InsureAmount =1000
            });
            mdlList.Add(new InsureMembersModel()
            {
                MemberId = "2",
                MemberName = "Test3",
                InsureAmount =3000
            });
            mdlList.Add(new InsureMembersModel()
            {
                MemberId = "3",
                MemberName = "Test2",
                InsureAmount =4000
            });
            return mdlList;
        }

        private DataTable GetExcelDataData(string filePath)
        {
            DataTable dt = new DataTable();
            ExcelPackage package = new ExcelPackage(new FileInfo(filePath));
            ExcelWorksheet workSheet = package.Workbook.Worksheets[0];
            for (int i = workSheet.Dimension.Start.Column; i <= workSheet.Dimension.End.Column; i++)
            {
                dt.Columns.Add(new DataColumn());
                for (int j = workSheet.Dimension.Start.Row; j <= workSheet.Dimension.End.Row; j++)
                {
                    DataRow dr = dt.NewRow();
                    object cellValue = workSheet.Cells[i, j].Value;
                    dr[i] = cellValue.ToString();
                    dt.Rows.Add(dr);
                }
            }
            return dt;
        }
    }
}
