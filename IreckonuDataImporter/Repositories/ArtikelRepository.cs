using IreckonuDataImporter.DAL;
using IreckonuDataImporter.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IreckonuDataImporter.Repositories
{
    public class ArtikelRepository : IArtikelRepository
    {
        private readonly ArtikelStoreContext artikelStoreDB;

        public ArtikelRepository()
        {
            artikelStoreDB = new ArtikelStoreContext();
        }

        public async Task SaveArtikels(IList<Models.Artikel> artikels)
        {
            List<DAL.Artikel> artikelsForDB = new List<DAL.Artikel>();

            foreach (var artikel in artikels)
            {
                var artikelDAL = new DAL.Artikel
                {
                    ArtikelCode = artikel.ArtikelCode,
                    Color = artikel.Color,
                    ColorCode = artikel.ColorCode,
                    DeliveredIn = artikel.DeliveredIn,
                    Description = artikel.Description,
                    DiscountPrice = artikel.DiscountPrice,
                    Key = artikel.Key,
                    Price = artikel.Price,
                    Q1 = artikel.Q1,
                    Size = artikel.Size
                };

                artikelsForDB.Add(artikelDAL);
            }

            await artikelStoreDB.Artikels.AddRangeAsync(artikelsForDB);
            await artikelStoreDB.SaveChangesAsync();
        }
    }
}