using System;
using MagicstoreAPI.Infrastructures.Entities;

namespace MagicstoreAPI.Interfaces
{
	public interface IPaginatorService
	{
        PaginadorData<T> GetItemsService<T>(IQueryable<T> query, int startRow, int endRow);

    }
}

