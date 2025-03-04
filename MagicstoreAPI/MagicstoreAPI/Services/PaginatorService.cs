using System;
using MagicstoreAPI.Infrastructures.Entities;
using MagicstoreAPI.Interfaces;
using MagicstoreAPI.Repositories;

namespace MagicstoreAPI.Services
{
	public class PaginatorService : IPaginatorService
    {
        private IPaginadorRepo _paginadorRepo;
        private readonly ILogger<PaginatorService> _logger;

        public PaginatorService(ILogger<PaginatorService> logger, IPaginadorRepo paginadorRepo)
		{
            _logger = logger;
            _paginadorRepo = paginadorRepo;

        }

        public  PaginadorData GetItemsService(int startRow, int endRow)
        {

            PaginadorData result =  _paginadorRepo.GetItemsRepo(startRow, endRow);
            return result;
        }


    }
}

