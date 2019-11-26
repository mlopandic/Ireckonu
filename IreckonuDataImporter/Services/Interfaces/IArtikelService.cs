using IreckonuDataImporter.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IreckonuDataImporter.Services.Interfaces
{
    public interface IArtikelService
    {
        Task SaveArtikelsToDB(IList<Artikel> artikels);

        Task SaveArtikelsToJson(IList<Artikel> artikels);
    }
}
