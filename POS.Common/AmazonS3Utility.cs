using Amazon.S3;
using Amazon.S3.IO;
using Amazon.S3.Model;
using Amazon;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace POS.Common
{
    public static class AmazonS3Utility
    {

        /// <summary>
        /// Upload images on Amazon S3 server.
        /// </summary>
        /// <param name="bucketName">bucket Name</param>
        /// <param name="awsAccessKeyId">Access Key Id</param>
        /// <param name="awsSecretAccessKey">Secret Access Key</param>
        /// <param name="fileName">file Name</param>
        /// <param name="folderKey">folder Key</param>
        /// <param name="base64String">base64String</param>
        /// <returns></returns>
        public static async Task<string> UploadFiles(string bucketName, string awsAccessKeyId, string awsSecretAccessKey, string folderKey, byte[] bytes)
        {            
            string httpStatus = string.Empty;

            AmazonS3Config cfg = new AmazonS3Config();

            //Sets end point based on the region
            cfg.RegionEndpoint = RegionEndpoint.USEast1; // USEast1 & USEast2 both are working but we will use USEast1 as per bucket region (Virginia)
            AmazonS3Client s3Client = new AmazonS3Client(awsAccessKeyId, awsSecretAccessKey, cfg);

            //Put request object to upload file bytes on amazon
            PutObjectRequest putRequest = new PutObjectRequest
            {
                BucketName = bucketName,
                Key = folderKey,
                CannedACL = S3CannedACL.PublicRead
            };

            using (var ms = new MemoryStream(bytes))
            {
                putRequest.InputStream = ms;
                PutObjectResponse response = await s3Client.PutObjectAsync(putRequest);

                //Check response status to decide whether file uploaded successfully or not
                if (response.HttpStatusCode == HttpStatusCode.OK)
                {
                    httpStatus = "success";
                }
                else
                {
                    httpStatus = response.HttpStatusCode.ToString();
                }
            }

            return httpStatus;
        }

        /// <summary>
        /// Download all single images
        /// </summary>
        /// <param name="bucketName">bucket Name</param>
        /// <param name="awsAccessKeyId">Access Key Id</param>
        /// <param name="awsSecretAccessKey">Secret Access Key</param>
        /// <param name="fileName">file Name</param>
        /// <param name="folderKey">folder Key</param>
        /// <returns></returns>
        public static List<Tuple<string, string>> DownloadAllImages(string bucketName, string awsAccessKeyId, string awsSecretAccessKey, string folderKey)
        {
            AmazonS3Config cfg = new AmazonS3Config();
            cfg.RegionEndpoint = RegionEndpoint.EUWest1;
            AmazonS3Client s3Client = new AmazonS3Client(awsAccessKeyId, awsSecretAccessKey, cfg);
            S3DirectoryInfo dir = new S3DirectoryInfo(s3Client, bucketName, folderKey);
            List<Tuple<string, string>> images = new List<Tuple<string, string>>();
            foreach (IS3FileSystemInfo file in dir.GetFileSystemInfos())
            {
                if (file.Extension.ToLower() == "jpeg" || file.Extension.ToLower() == "jpg" || file.Extension.ToLower() == "png")
                {
                    string responseBody = string.Empty;

                    GetObjectRequest request = new GetObjectRequest
                    {
                        BucketName = bucketName,
                        Key = folderKey.Replace("\\", "/") + file.Name
                    };
                    GetObjectResponse response = s3Client.GetObject(request);
                    using (Stream responseStream = response.ResponseStream)
                    {
                        var bytes = ReadStream(responseStream);
                        responseBody = Convert.ToBase64String(bytes);
                    }
                    images.Add(new Tuple<string, string>(responseBody, file.Extension));
                }
            }
            return images;
        }

        public static bool checkFileExist(string bucketName, string awsAccessKeyId, string awsSecretAccessKey, string folderKey, string fileName)
        {
            bool isExist = false;
            AmazonS3Config cfg = new AmazonS3Config();
            cfg.RegionEndpoint = RegionEndpoint.EUWest1;
            AmazonS3Client s3Client = new AmazonS3Client(awsAccessKeyId, awsSecretAccessKey, cfg);
            S3DirectoryInfo dir = new S3DirectoryInfo(s3Client, bucketName, folderKey);
            foreach (IS3FileSystemInfo file in dir.GetFileSystemInfos())
            {
                if (file.Name.ToLower() == fileName.ToLower())
                {
                    isExist = true;
                }
            }
            return isExist;
        }

        /// <summary>
        /// return bytes
        /// </summary>
        /// <param name="responseStream">response Stream</param>
        /// <returns></returns>
        public static byte[] ReadStream(Stream responseStream)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = responseStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }

        /// <summary>
        /// Delete file from Aws S3
        /// </summary>
        /// <param name="bucketName">Bucket Name</param>
        /// <param name="awsAccessKeyId">AWS Access Key</param>
        /// <param name="awsSecretAccessKey">AWS Secret Key</param>
        /// <param name="fileObjectKey">file key name - full path of file in aws bucket</param>
        /// <returns></returns>
        /// <CreatedBy>Pratik</CreatedBy>
        /// <CreatedOn>15th FEB 19</CreatedOn>
        public static async Task DeleteObjectNonVersionedBucket(string bucketName, string awsAccessKeyId, string awsSecretAccessKey, string fileObjectKey)
        {
            try
            {
                AmazonS3Config cfg = new AmazonS3Config
                {
                    //Sets end point based on the region
                    RegionEndpoint = RegionEndpoint.USEast1 // USEast1 & USEast2 both are working but we will use USEast1 as per bucket region (Virginia)
                };
                AmazonS3Client s3Client = new AmazonS3Client(awsAccessKeyId, awsSecretAccessKey, cfg);

                var deleteObjectRequest = new DeleteObjectRequest
                {
                    BucketName = bucketName,
                    Key = fileObjectKey
                };
                
                await s3Client.DeleteObjectAsync(deleteObjectRequest);
            }
            catch (AmazonS3Exception ex)
            {
                throw ex;   
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
