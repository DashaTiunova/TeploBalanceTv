using TeploBalanceKotelCore.Data;
using TeploBalanceKotelCore.Models;
namespace TeploBalanceKotelCore.Services
{
    public class TverdToplivoService
    {
        private readonly DataContext_TverdToplivo _context;
        public TverdToplivoService(DataContext_TverdToplivo context)
        {
            _context = context;
        }
        public List<VarTverdToplivo> GetVariants(int OwnerID_User)
        {
            var query = _context.VarTverdToplivos.AsQueryable();
            if (OwnerID_User != 0) query = query.Where(x => x.OwnerID_User == OwnerID_User);
            return query.ToList();
        }
        public int GetUserId(string User)
        {
            int UserId = _context.Users.FirstOrDefault(x => x.UserName == User).ID_User;
            return UserId;
        }

        public int GetVariantId(VariantAddDto variant)
        {
            int variantId = _context.VarTverdToplivos.FirstOrDefault(x => x.NameVariant_TverdToplivo == variant.Name).VarTverd_Toplivo_ID;
            return variantId;
        }
    }
}
