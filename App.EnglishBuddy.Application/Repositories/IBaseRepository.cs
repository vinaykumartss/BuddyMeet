﻿

using App.EnglishBuddy.Application.Features.UserFeatures.AllContactUs;
using App.EnglishBuddy.Domain.Common;
using System.Linq.Expressions;
namespace App.EnglishBuddy.Application.Repositories;
public interface IBaseRepository<T> where T : BaseEntity
{
    void Create(T entity);
    void Update(T entity);
    void Delete(T entity);
    Task<T> GetById(Guid id, CancellationToken cancellationToken);
    Task<List<T>> GetAll(int pageNumber , int pageSize, CancellationToken cancellationToken);
    Task<List<T>> FindByCondition(Expression<Func<T, bool>> expression, CancellationToken cancellationToken);
    Task<T> FindByUserId(Expression<Func<T, bool>> expression, CancellationToken cancellationToken);
    List<T> FindByListSync(Expression<Func<T, bool>> expression);
    T FindByUserIdSync(Expression<Func<T, bool>> expression);
    
    Task<List<Domain.Entities.ContactUs>> GetAllContact(AllContactUsRequest request, CancellationToken cancellationToken);

}