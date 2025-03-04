using System;
using MagicstoreAPI.Infrastructures.DTO;
using MagicstoreAPI.Infrastructures.Entities;
using MagicstoreAPI.Interfaces;
using MagicstoreAPI.Repositories;
using MagicstoreAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace MagicstoreAPI.Controllers
{
	public class PaginatorController
	{
        private readonly ILogger<PaginatorController> _logger;
		private IPaginatorService _paginatorService;

        public PaginatorController(IPaginatorService paginadorService, ILogger<PaginatorController> logger)
		{
			_logger = logger;
			_paginatorService = paginadorService;
		}


        [Route("/api/Paginador")]
        [HttpPost]
        public  PaginadorData GetPaginador([FromBody] paginadorInput input)
        {

            var result = _paginatorService.GetItemsService(input.startRow, input.endRow);
            return (result);
        }

    }
}

