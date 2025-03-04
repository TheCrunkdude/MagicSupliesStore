using System;
using MagicstoreAPI.Infrastructures.Entities;

namespace MagicstoreAPI.Interfaces
{
	public interface IPaginadorRepo
	{
        PaginadorData GetItemsRepo(int startRow, int endRow);

    }
}

