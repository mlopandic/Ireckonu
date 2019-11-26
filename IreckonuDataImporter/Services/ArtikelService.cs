using IreckonuDataImporter.Models;
using IreckonuDataImporter.Repositories.Interfaces;
using IreckonuDataImporter.Services.Interfaces;
using System;
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

        public async Task SaveArtikelsToDB(IList<Artikel> artikels)
        {
            await artikelRepository.SaveArtikels(artikels);
        }

        public Task SaveArtikelsToJson(IList<Artikel> artikels)
        {
            throw new NotImplementedException();
        }
    }
}