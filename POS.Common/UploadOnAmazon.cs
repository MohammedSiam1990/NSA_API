using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using Amazon.S3;
using Amazon.S3.Model;
using ClosedXML.Excel;

namespace POS.Common
{
    public static class UploadOnAmazon
    {
        public static string UploadExcelOnAmazon(DataSet ds, List<string> workbookName, string amazonAccessKey, string amazonSecretKey, string amazonBucketName, string amazonBucketParentFolder)
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
                    ws.Tables.FirstOrDefault().ShowAutoFilter = false; // not showing fiter by deafult 
                }
                
                AmazonS3Config cfg = new AmazonS3Config();
                //Sets end point based on the region
                cfg.RegionEndpoint = Amazon.RegionEndpoint.USEast1; // USEast1 & USEast2 both are working but we will use USEast1 as per bucket region (Virginia)
                AmazonS3Client s3Client = new AmazonS3Client(amazonAccessKey, amazonSecretKey, cfg);

                //Put request object to upload file bytes on amazon
                PutObjectRequest putRequest = new PutObjectRequest
                {
                    BucketName = amazonBucketName,
                    Key = amazonBucketParentFolder,
                    CannedACL = S3CannedACL.PublicRead
                };
                
                using (var ms = new MemoryStream())
                {
                    wb.SaveAs(ms);
                    putRequest.InputStream = ms;
                    PutObjectResponse response = s3Client.PutObject(putRequest);
                    return response.HttpStatusCode.ToString();
                }
            }
        }

    }
}
