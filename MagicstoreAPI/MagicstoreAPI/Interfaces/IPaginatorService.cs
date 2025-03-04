using System;
using MagicstoreAPI.Infrastructures.Entities;

namespace MagicstoreAPI.Interfaces
{
	public interface IPaginatorService
	{
        PaginadorData GetItemsService(int startRow, int endRow);

    }
}

