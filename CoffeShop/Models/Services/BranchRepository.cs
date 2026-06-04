using CoffeShop.Data;
using CoffeShop.Models.Interfaces;

namespace CoffeShop.Models.Services
{
    public class BranchRepository : IBranchRepository
    {
        private readonly CoffeeshopDbContext context;
        public BranchRepository(CoffeeshopDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<Branch> GetAllBranches() => context.Branches.ToList();
        public void AddBranch(Branch branch)
        {
            context.Branches.Add(branch);
            context.SaveChanges();
        }
        public void DeleteBranch(int id)
        {
            var b = context.Branches.Find(id);
            if (b != null) { context.Branches.Remove(b); context.SaveChanges(); }
        }
    }
}