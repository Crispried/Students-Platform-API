using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace Students.API.Helpers
{
    public static class BlobHelper
    {
        public static bool Upload(Image src, string containerName, string fileName)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                ConfigurationManager.ConnectionStrings["StorageConnectionString"].ConnectionString);
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            CloudBlobContainer container = blobClient.GetContainerReference(containerName);

            if (!container.Exists())
            {
                container.Create();
                container.SetPermissions(new BlobContainerPermissions
                {
                    PublicAccess = BlobContainerPublicAccessType.Blob
                });
            }
            
            CloudBlockBlob blob = container.GetBlockBlobReference(fileName);
            using (MemoryStream memoryStream = new MemoryStream())
            {
                src.Save(memoryStream, ImageFormat.Png);
                memoryStream.Position = 0;
                blob.UploadFromStream(memoryStream);
                memoryStream.Close();
            }

            return true;
        }

        public static bool Move(string containerName, string oldName, string newName)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                ConfigurationManager.ConnectionStrings["StorageConnectionString"].ConnectionString);
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            CloudBlobContainer container = blobClient.GetContainerReference(containerName);

            if (!container.Exists())
            {
                container.Create();
                container.SetPermissions(new BlobContainerPermissions
                {
                    PublicAccess = BlobContainerPublicAccessType.Blob
                });
            }

            CloudBlockBlob oldBlob = container.GetBlockBlobReference(oldName);
            CloudBlockBlob newBlob = container.GetBlockBlobReference(newName);

            newBlob.StartCopy(oldBlob);
            oldBlob.Delete();

            return true;
        }

        public static bool Remove(string containerName, string fileName)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                ConfigurationManager.ConnectionStrings["StorageConnectionString"].ConnectionString);
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            CloudBlobContainer container = blobClient.GetContainerReference(containerName);

            if (!container.Exists())
            {
                return false;
            }

            CloudBlockBlob blob = container.GetBlockBlobReference(fileName);
            blob.Delete();

            return true;
        }
    }
}