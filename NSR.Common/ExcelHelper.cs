using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using ClosedXML.Excel;
using Elmah;

namespace NSR.Common
{
    public static class ExcelHelper
    {
        /// <summary>
        /// Export Excel with multiple sheet
        /// </summary>
        /// <param name="ds">Add datatable in dataset</param>
        /// <param name="workbookName">Name of work book in List</param>
        /// <param name="fileName">Name of File</param>
        public static void multipleSheetExcel(DataSet ds, List<string> workbookName, string fileName, List<Tuple<int, string, string>> headers = null)
        {
            try
            {
                //Set Name of DataTables.
                for (int i = 0; i < ds.Tables.Count; i++)
                {
                    foreach (var item in workbookName)
                    {
                        ds.Tables[i].TableName = item;
                        i++;
                    }
                }
                using (XLWorkbook wb = new XLWorkbook())
                {
                    foreach (DataTable dt in ds.Tables)
                    {
                        var ws = wb.Worksheets.Add(dt);
                        int row = 1;

                        if (headers?.Count > 0)
                        {
                            int index = ds.Tables.IndexOf(dt);
                            var wsHeader = headers.Where(x => x.Item1 == index).ToList();

                            foreach (var item in wsHeader)
                            {
                                ws.Row(row).InsertRowsAbove(1);
                                ws.Cell(row, 1).Value = "'" + item.Item2.ToString();
                                ws.Cell(row, 1).Style.Font.Bold = true;
                                ws.Cell(row, 2).Value = "'" + item.Item3.ToString();
                                row++;
                            }
                        }

                        ws.Tables.FirstOrDefault().ShowAutoFilter = false; // not showing fiter by deafult
                    }

                    HttpContext.Current.Response.Clear();
                    HttpContext.Current.Response.Buffer = true;
                    HttpContext.Current.Response.Charset = "";
                    HttpContext.Current.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=" + fileName + ".xlsx");
                    using (MemoryStream MyMemoryStream = new MemoryStream())
                    {

                        wb.SaveAs(MyMemoryStream);
                        MyMemoryStream.WriteTo(HttpContext.Current.Response.OutputStream);
                        HttpContext.Current.Response.Flush();
                        HttpContext.Current.Response.End();
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorSignal.FromCurrentContext().Raise(ex);
            }

        }

        /// <summary>
        /// Export Excel with multiple sheet
        /// </summary>
        /// <param name="ds">Add datatable in dataset</param>
        /// <param name="workbookName">Name of work book in List</param>
        /// <param name="fileName">Name of File</param>
        public static void multipleSheetExcelMultiHeader(DataSet ds, List<string> workbookName, string fileName, List<Tuple<int, string, string>> headers = null)
        {
            try
            {
                //Set Name of DataTables.
                for (int i = 0; i < ds.Tables.Count; i++)
                {
                    foreach (var item in workbookName)
                    {
                        ds.Tables[i].TableName = item;
                        i++;
                    }
                }
                using (XLWorkbook wb = new XLWorkbook())
                {
                    foreach (DataTable dt in ds.Tables)
                    {
                        var ws = wb.Worksheets.Add(dt);
                        int row = 1;

                        if (headers?.Count > 0)
                        {
                            int index = ds.Tables.IndexOf(dt);
                            var wsHeader = headers.Where(x => x.Item1 == index).ToList();

                            foreach (var item in headers)
                            {
                                ws.Row(row).InsertRowsAbove(1);
                                ws.Cell(row, 1).Value = "'" + item.Item2.ToString();
                                ws.Cell(row, 1).Style.Font.Bold = true;
                                ws.Cell(row, 2).Value = "'" + item.Item3.ToString();
                                row++;
                            }
                        }

                        ws.Tables.FirstOrDefault().ShowAutoFilter = false; // not showing fiter by deafult
                    }

                    HttpContext.Current.Response.Clear();
                    HttpContext.Current.Response.Buffer = true;
                    HttpContext.Current.Response.Charset = "";
                    HttpContext.Current.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=" + fileName + ".xlsx");
                    using (MemoryStream MyMemoryStream = new MemoryStream())
                    {

                        wb.SaveAs(MyMemoryStream);
                        MyMemoryStream.WriteTo(HttpContext.Current.Response.OutputStream);
                        HttpContext.Current.Response.Flush();
                        HttpContext.Current.Response.End();
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorSignal.FromCurrentContext().Raise(ex);
            }
        }
    }
}
