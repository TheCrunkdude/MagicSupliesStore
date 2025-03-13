using System;
using MagicstoreAPI.Infrastructures.Entities;

namespace MagicstoreAPI.Interfaces
{
    public interface IPaginatorRepo
    {
        PaginadorData<T> GetItemsRepo<T>(IQueryable<T> query, int startRow, int endRow);
        
    }
}

