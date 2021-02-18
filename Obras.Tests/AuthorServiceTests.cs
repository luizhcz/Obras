using Microsoft.EntityFrameworkCore;
using Moq;
using Obras.Commom.MappingRequest.AuthorsName;
using Obras.Commom.Repositorie;
using Obras.Commom.Services;
using Obras.Core.Services;
using Obras.Repositories.Connection;
using Obras.Repositories.Repositorie;
using System.Collections.Generic;
using Xunit;

namespace Obras.Tests
{    
    public class AuthorServiceTests
    {
        #region Sucess

        [Theory]
        [InlineData("GuImaraes", "GUIMARAES")]
        [InlineData("Luiz Henrique Cerqueira Ruiz", "RUIZ, Luiz Henrique Cerqueira")]
        [InlineData("Joao Neto", "NETO, Joao")]
        [InlineData("Joao Silva Neto", "SILVA NETO, Joao")]
        [InlineData("Lucas dos santos", "SANTOS, Lucas dos")]
        [InlineData("Lucas pereira dos santos silva", "SILVA, Lucas Pereira dos Santos")]
        public void nome_formatado_certo(string nome, string nomeFormatado)
        {

            //Arrange 
            var List = new List<AuthorsNameRequest>() {
                new AuthorsNameRequest { name = nome }
            };
            var authorService = new AuthorService(new Mock<Commom.Repositorie.IAuthorsRepository>().Object);

            //Act
            var result = authorService.AuthorName(List);

            //Assert
            foreach (var item in result)
            {
                Assert.Equal(nomeFormatado, item.names);
            }
        }

        #endregion

        #region Fail

        [Theory]
        [InlineData("GuImaraes", "Guimaraes")]
        [InlineData("Joao Silva Neto", "NETO SILVA, Joao")]
        [InlineData("Lucas dos santos", "Santos, Lucas Dos")]
        [InlineData("Lucas dos santos", "Santos, Dos Lucas")]
        [InlineData("Lucas dos santos", "Santos, dos Lucas")]
        public void nome_formatado_errado(string nome, string nomeFormatado)
        {

            //Arrange 
            var List = new List<AuthorsNameRequest>() {
                new AuthorsNameRequest { name = nome }
            };
            var authorService = new AuthorService(new Mock<Commom.Repositorie.IAuthorsRepository>().Object);

            //Act
            var result = authorService.AuthorName(List);

            //Assert
            foreach (var item in result)
            {
                Assert.NotEqual(nomeFormatado, item.names);
            }
        }

        #endregion
    }
}
