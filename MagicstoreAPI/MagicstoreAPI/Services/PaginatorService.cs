using System;
using MagicstoreAPI.Infrastructures.Entities;
using MagicstoreAPI.Interfaces;
using MagicstoreAPI.Repositories;

namespace MagicstoreAPI.Services
{
	public class PaginatorService : IPaginatorService
    {
        private IPaginatorRepo _paginadorRepo;
        private readonly ILogger<PaginatorService> _logger;

        public PaginatorService(ILogger<PaginatorService> logger, IPaginatorRepo paginadorRepo)
		{
            _logger = logger;
            _paginadorRepo = paginadorRepo;

        }

        public PaginadorData<T> GetItemsService<T>(IQueryable<T> query, int startRow, int endRow)
        {
            _logger.LogInformation("Paginator GetItemsService is ok");

            return _paginadorRepo.GetItemsRepo(query, startRow, endRow);
        }




    }
}

