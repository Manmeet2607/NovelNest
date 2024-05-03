using System.Linq.Expressions;

namespace NovelNest.Repository.IRepository
{
    public interface IRepository<T> where T:class
    {
        //T-will be category or any generic model on which we will perform CRUD operation.
        //all operations that we can perform on category

        // add to category
        void Add(T entity);

        //1. Get all category
        //filter when we what some particular records
        IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null);

        //2. Get one category
        //tracked is set to false so that ef does not automatically track and change a object accessed using it and blunders are prevented.
        T Get(Expression<Func<T, bool>> filter, string? includeProperties = null, bool tracked = false);

        //3. update
        //  void Update(T entity);

        //4. delete
        void Remove(T entity);

        //delete range(to remove multiple)
        void RemoveRange(IEnumerable<T> entity);
    }
}
