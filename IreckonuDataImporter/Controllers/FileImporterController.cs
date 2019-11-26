using IreckonuDataImporter.Models;
using IreckonuDataImporter.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using System.Web.Http;

namespace IreckonuDataImporter.Controllers
{
    [System.Web.Http.Route("api")]
    [ApiController]
    public class FileImporterController : ApiController
    {
        private readonly IArtikelService artikelService;

        public FileImporterController (IArtikelService artikelService)
        {
            this.artikelService = artikelService;
        }

        [System.Web.Http.HttpPost]
        public async Task<IHttpActionResult> Import()
        {
            HttpRequestMessage request = this.Request;
            if (!request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            List<Artikel> artikels = new List<Artikel>();
            var provider = new MultipartMemoryStreamProvider();
            await request.Content.ReadAsMultipartAsync(provider);
            foreach (var file in provider.Contents)
            {
                var buffer = await file.ReadAsByteArrayAsync();

                var artikel = GetArtikels(buffer);
                if (artikel != null)
                {
                    artikels.Add(artikel);
                }
            }

            await artikelService.SaveArtikelsToDB(artikels);

            return Ok();
        }

        private static Artikel GetArtikels(byte[] buffer)
        {
            if (buffer == null)
            {
                return null;
            }

            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                using (MemoryStream ms = new MemoryStream(buffer))
                {
                    return (Artikel)bf.Deserialize(ms);
                }
            }
            catch
            {
                return null;
            }
        }
    }
}