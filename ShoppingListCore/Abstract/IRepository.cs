using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingListCore.Abstract
{
    public interface IRepository<T>
    {
        void Insert(T t);
        void Delete(T t);
        void Update(T t);
        List<T> GetList();
        List<T> GetListByFilter(Expression<Func<T,bool>>filter);

        T GetByFilter(Expression<Func<T, bool>> filter);
        List<T> GetAll(Expression<Func<T, bool>>? filter =null, params Expression<Func<T, object>>[] expressionList);
        T GetByID(int id);

    }
}
