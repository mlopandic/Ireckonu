using IreckonuDataImporter.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IreckonuDataImporter.Repositories.Interfaces
{
    public interface IArtikelRepository
    {
        Task SaveArtikels(IList<Artikel> artikels);
    }
}
