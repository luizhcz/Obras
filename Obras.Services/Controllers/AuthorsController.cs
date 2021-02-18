using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Obras.Commom.MappingRequest.AuthorsName;
using Obras.Commom.Services;
using Obras.Commom.ViewModels.AuthorsName;

namespace Obras.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _authorServices;


        public AuthorsController(IAuthorService authorServices)
        {
            _authorServices = authorServices;
        }


        [HttpPost("insertAll")]
        public async Task<bool> InsertAll([FromBody] IEnumerable<AuthorsNameRequest> request)
            => await _authorServices.AddAll(request);

        [HttpGet]
        public async Task<IEnumerable<AuthorsNameViewModel>> GetAuthors()
            => await _authorServices.GetAll();

        [HttpPost("insert")]
        public async Task<bool> Insert([FromBody] AuthorsNameRequest request)
            => await _authorServices.Add(request);

    }
}