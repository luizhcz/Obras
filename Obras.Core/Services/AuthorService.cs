using Obras.Commom.MappingRequest.AuthorsName;
using Obras.Commom.Models.AuthorsModels;
using Obras.Commom.Repositorie;
using Obras.Commom.Services;
using Obras.Commom.ViewModels.AuthorsName;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obras.Core.Services
{
    public class AuthorService : IAuthorService
    {
        #region prop

        private readonly IAuthorsRepository _authorsRepository;

        #endregion

        #region constructor
        public AuthorService(IAuthorsRepository authorsRepository)
        {
            _authorsRepository = authorsRepository;
        }

        #endregion

        #region public

        public async Task<bool> Add(AuthorsNameRequest authors)
        {
            var List = AuthorName(authors);

            foreach (var author in List)
            {
                await _authorsRepository.Add(new FluentAuthors
                {
                    Name = author.name
                });
            }

            return true;
        }

        public async Task<bool> AddAll(IEnumerable<AuthorsNameRequest> authors)
        {
            foreach (var author in authors)
            {
                var List = AuthorName(author);

                foreach (var item in List)
                {
                    await _authorsRepository.Add(new FluentAuthors
                    {
                        Name = item.name
                    });
                }
            }

            return true;
        }

        public IEnumerable<AuthorsNameViewModel> AuthorName(AuthorsNameRequest author)
        {
            List<AuthorsNameViewModel> ListNames = new List<AuthorsNameViewModel>();
            string[] ListAux = { "da", "de", "do", "das", "dos" };
            string[] Relatives = { "FILHO", "FILHA", "NETO", "NETA", "SOBRINHO", "SOBRINHA", "JUNIOR" };

            string[] parts = author.name.Split(' ');
            int tamanho = parts.Length;

            if (tamanho > 1)
            {

                StringBuilder builder = new StringBuilder();
                string lastName = parts.Last().ToUpper();

                builder.Append($"{lastName}, ");

                if (Relatives.Contains(lastName) && parts.Length > 2)
                {
                    builder.Replace($"{lastName}, ", $"{parts[parts.Length - 2].ToUpper()} {lastName}, ");
                    tamanho -= 1;
                }


                builder.Append($"{FormatAuthorName(parts.First())} ");

                for (int i = 1; i < tamanho - 1; i++)
                {

                    if (ListAux.Contains(parts[i].ToLower()) && (parts[i].Length == 2 || parts[i].Length == 3))
                    {
                        builder.Append($"{parts[i]} ");
                    }
                    else
                        builder.Append($"{FormatAuthorName(parts[i])} ");
                }

                ListNames.Add(new AuthorsNameViewModel { name = builder.ToString().TrimEnd() });
            }
            else
            {
                ListNames.Add(new AuthorsNameViewModel { name = parts.First().ToUpper().TrimEnd() });
            }


            return ListNames;
        }

        public async Task<List<AuthorsNameViewModel>> GetAll()
        {
            List<AuthorsNameViewModel> AuthorsName = new List<AuthorsNameViewModel>();

            foreach (var author in await _authorsRepository.GetAll())
            {
                AuthorsName.Add(new AuthorsNameViewModel { name = author.Name });
            }

            return AuthorsName;
        }

        #endregion

        #region private

        private string FormatAuthorName(string name)
        {
            StringBuilder formatName = new StringBuilder(name.Substring(0, 1).ToUpper());
            formatName.Append(name.Substring(1, name.Length - 1).ToLower());
            return formatName.ToString();
        }

        #endregion
    }
}
