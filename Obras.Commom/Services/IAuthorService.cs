using Obras.Commom.MappingRequest.AuthorsName;
using Obras.Commom.ViewModels.AuthorsName;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Obras.Commom.Services
{
    public interface IAuthorService
    {
        IEnumerable<AuthorsNameViewModel> AuthorName(AuthorsNameRequest authorsName);

        Task<bool> Add(AuthorsNameRequest authors);
        Task<bool> AddAll(IEnumerable<AuthorsNameRequest> authors);

        Task<List<AuthorsNameViewModel>> GetAll();
    }
}
