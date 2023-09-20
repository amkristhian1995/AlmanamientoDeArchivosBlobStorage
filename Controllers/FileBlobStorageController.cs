using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlmanamientoDeArchivosBlobStorage.Controllers
{
    public class FileBlobStorageController : Controller
    {
        public readonly BlobServiceClient _blob;

        public FileBlobStorageController(BlobServiceClient blob)
        {
            this._blob = blob;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<string> CargarArchivo(IFormFile file) {
            string mensaje = "";
            try
            {
                BlobContainerClient contenedor = _blob.GetBlobContainerClient("contenedorprueba2");
                await contenedor.UploadBlobAsync(file.FileName, file.OpenReadStream());
                mensaje = "Se cargó.";
            } catch(Exception ex)
            {
                mensaje = ex.Message;
            }
            return mensaje;
        }
    }
}
