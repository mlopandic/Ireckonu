using IreckonuDataImporter.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IreckonuDataImporter.Services.Interfaces
{
    public interface IArtikelService
    {
        Task SaveArtikels(IList<Artikel> artikels);
    }
}
