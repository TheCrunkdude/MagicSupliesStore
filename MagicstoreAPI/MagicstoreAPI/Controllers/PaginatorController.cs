using System;
using MagicstoreAPI.Infrastructures.DTO;
using MagicstoreAPI.Infrastructures.Entities;
using MagicstoreAPI.Interfaces;
using MagicstoreAPI.Repositories;
using MagicstoreAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MagicstoreAPI.Controllers
{
	public class PaginatorController
	{
        private readonly ILogger<PaginatorController> _logger;
		private IPaginatorService _paginatorService;
        private ApplicationDBContext _context;
        public PaginatorController(IPaginatorService paginadorService, ILogger<PaginatorController> logger, ApplicationDBContext context)
		{
			_logger = logger;
			_paginatorService = paginadorService;
            _context = context;
		}


        [Route("/api/Paginador")]
        [HttpPost]
        public PaginadorData<object> GetPaginador([FromBody] paginadorInput input)
        {
            IQueryable<object> query = input.Entity.ToLower() switch
            {
                "cervezas" => _context.cervezas,
                "usuarios" => _context.MSDB_Users,
                _ => null
            };

            var result = _paginatorService.GetItemsService( query, input.StartRow, input.EndRow);
            return result;
        }

    }
}

