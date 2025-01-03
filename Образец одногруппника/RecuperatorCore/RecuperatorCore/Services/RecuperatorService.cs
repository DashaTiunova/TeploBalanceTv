using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using RecuperatorCore.Models;
using RecuperatorLibrary.Models;
using SQLitePCL;
using System.Net.Http;

namespace RecuperatorCore.Services
{
    public class RecuperatorService
    {
        private readonly RecuperatorContext _context;
        public RecuperatorService(RecuperatorContext context)
        {
            _context = context;
        }
        public List<Variant> GetVariants(int UserId)
        {
            var query = _context.Variants.AsQueryable();
            if (UserId != 0) query = query.Where(x => x.UserId == UserId);
            return query.ToList();
        }
        public int GetUserId(string User)
        {
            int UserId = _context.Users.FirstOrDefault(x => x.Login == User).Id;
            return UserId;
        }
        public int GetVariantId(VariantAddDto variant)
        {
            int variantId = _context.Variants.FirstOrDefault(x => x.Name == variant.Name).Id;
            return variantId;
        }
        public VariantUser GetVariantUser(VariantLoadDto model)
        {
            var variant = _context.VariantUsers.FirstOrDefault(x => x.UserId == model.UserId && x.VariantId == model.VariantId);
            return variant;
        }
        public VariantUser GetDefaultVariantUser(int UserId)
        {
            var variant = _context.VariantUsers.FirstOrDefault(x => x.Id == UserId);
            return variant;
        }
        public bool DeleteVariant(VariantDeleteDto model)
        {
            var variantUser = _context.VariantUsers.FirstOrDefault(x => x.UserId == model.UserId && x.VariantId == model.VariantId);
            _context.VariantUsers.Remove(variantUser);
            var variant = _context.Variants.FirstOrDefault(x => x.Id == model.VariantId);
            _context.Variants.Remove(variant);
            _context.SaveChanges();
            return true;
        }
    }
}
