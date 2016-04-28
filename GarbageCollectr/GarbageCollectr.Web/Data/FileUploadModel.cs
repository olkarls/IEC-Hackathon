namespace GarbageCollectr.Web.Data
{
    using System;

    using Microsoft.WindowsAzure.Storage.Blob;

    public class FileUploadModel
    {
        public int BlockCount { get; set; }

        public string FileName { get; set; }

        public long FileSize { get; set; }

        public CloudBlockBlob BlockBlob { get; set; }

        public DateTime StartTime { get; set; }

        public bool IsUploadCompleted { get; set; }

        public string UploadStatusMessage { get; set; }
    }
}