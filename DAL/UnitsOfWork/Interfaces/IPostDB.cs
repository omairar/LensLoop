using BOL;

namespace DAL.UnitsOfWork.Interfaces
{
    public interface IPostDB
    {
        IQueryable<Post> GetAll();
        IQueryable<Post> GetStoriesByStatus(bool IsApproved);
        IQueryable<Post> GetById(int SSid);
        IQueryable<Post> GetByUserId(string Id);
        Task<bool> Create(Post story);
        Task<bool> Update(Post story);
        Task<bool> Delete(int SSid);
        Task<bool> Approve(Post stry);
    }
}
