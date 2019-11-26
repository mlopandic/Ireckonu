using IreckonuDataImporter.Models;
using IreckonuDataImporter.Repositories.Interfaces;
using IreckonuDataImporter.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IreckonuDataImporter.Services
{
    public class ArtikelService : IArtikelService
    {
        private readonly IArtikelRepository artikelRepository;

        public ArtikelService (IArtikelRepository artikelRepository)
        {
            this.artikelRepository = artikelRepository;
        }

        public async Task SaveArtikels(IList<Artikel> artikels)
        {
            await SaveToDB(artikels);
            await SaveToJson(artikels);
        }

        private async Task SaveToDB(IList<Artikel> artikels)
        {
            await artikelRepository.SaveArtikels(artikels);
        }

        private async Task SaveToJson(IList<Artikel> artikels)
        {
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(@"C:\temp\IreckonuData.json", true))
            {
                foreach (var artikel in artikels)
                {
                    await file.WriteLineAsync(Newtonsoft.Json.JsonConvert.SerializeObject(artikel));
                }
            }
        }
    }
}