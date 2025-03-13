using System;
using System.Xml;
using MagicstoreAPI.Infrastructures.Entities;
using MagicstoreAPI.Interfaces;
using Microsoft.Extensions.Logging;
using static System.Net.Mime.MediaTypeNames;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace MagicstoreAPI.Repositories
{
	public class PaginatorRepo :IPaginatorRepo
    {
        private ApplicationDBContext _applicationDb;
        private ILogger<PaginatorRepo> _logger;


        public PaginatorRepo(ApplicationDBContext applicationDB, ILogger<PaginatorRepo> logger)
        {
            _applicationDb = applicationDB;
            _logger = logger;
        }

        public PaginadorData<T> GetItemsRepo<T>(IQueryable<T> query, int startRow, int endRow)
        {
            _logger.LogInformation("Paginator Get Items is ok ");
            // Get paginated data
            var items = query.Skip(startRow).Take(endRow - startRow).ToList();

            // Get total count for pagination information
            var totalCount = query.Count();

            return new PaginadorData<T>
            {
                Rows = items,
                TotalItems = totalCount
            };
        }

        public interface IGenericPaginatorRepo<T>
        {
            IQueryable<T> GetAll();
        }

    }
}

