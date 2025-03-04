using System;
using System.Xml;
using MagicstoreAPI.Infrastructures.Entities;
using MagicstoreAPI.Interfaces;
using MagicstoreAPI.Services;
using Microsoft.Extensions.Logging;
using static System.Net.Mime.MediaTypeNames;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace MagicstoreAPI.Repositories
{
	public class PaginatorRepo : IPaginadorRepo
    {
        private ApplicationDBContext _applicationDb;
        private ILogger<PaginatorService> _logger;

        public PaginatorRepo(ApplicationDBContext applicationDB, ILogger<PaginatorService> logger)
        {
            _applicationDb = applicationDB;
            _logger = logger;
        }

        public  PaginadorData GetItemsRepo(int startRow, int endRow)
        {
            _logger.LogInformation("Paginator Get Items is ok ");

            // Get paginated data
            var items = _applicationDb.cervezas.Skip(startRow).Take(endRow - startRow).ToList();

            // Get total count for pagination information
            var totalCount = _applicationDb.cervezas.Count();

            return new PaginadorData
            {
                Rows = items,
                TotalItems = totalCount
            };
        }



    }
}

