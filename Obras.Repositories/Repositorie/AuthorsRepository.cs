using Obras.Commom.Models.AuthorsModels;
using Obras.Commom.Repositorie;
using Obras.Repositories.Connection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Obras.Repositories.Repositorie
{
    public class AuthorsRepository : Repository<FluentAuthors>, IAuthorsRepository
    {
        public AuthorsRepository(Context context) : base(context)
        {

        }
    }
}
