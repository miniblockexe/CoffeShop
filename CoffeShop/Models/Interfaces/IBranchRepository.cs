namespace CoffeShop.Models.Interfaces
{
    public interface IBranchRepository
    {
        IEnumerable<Branch> GetAllBranches();
        void AddBranch(Branch branch);
        void DeleteBranch(int id);
    }
}
