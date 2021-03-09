using Agenda.Domain;
using NUnit.Framework;
using System;
using System.Linq;
using Ploeh.AutoFixture;
using Moq;

namespace Agenda.DAL.Test
{
    [TestFixture]
    public class ContatosTest
    {
        private Contatos _contatos;
        private Fixture _fixture;
        private Contato _contato;

        [SetUp]
        public void SetUp()
        {
            _contatos = new Mock<Contatos>().Object;
            _fixture = new Fixture();
            _contato = new Contato();
        }

        [Test]
        public void IncluirContatoTest()
        {
            _contato = _fixture.CreateAnonymous<Contato>();

            _contatos.Adicionar(_contato);

            Assert.True(true);
        }

        [Test]
        public void ObterContatoTest()
        {
            _contato = _fixture.CreateAnonymous<Contato>();

            _contatos.Adicionar(_contato);
            var resultado = _contatos.Obter(_contato.Id);

            Assert.AreEqual(resultado.Id, _contato.Id);
            Assert.AreEqual(resultado.Nome, _contato.Nome);
        }

        [Test]
        public void ObterTodos()
        {
            _contato = _fixture.CreateAnonymous<Contato>();

            _contatos.Adicionar(_contato);

            var list = _contatos.ObterTodos();
            var resultado = list.Where(l => l.Id == _contato.Id).FirstOrDefault();

            Assert.IsTrue(list.Any());
            Assert.AreEqual(resultado.Id, _contato.Id);
            Assert.AreEqual(resultado.Nome, _contato.Nome);
        }

        [TearDown]
        public void TearDown()
        {
            _contatos = null;
            _fixture = null;
            _contato = null;
        }
    }
}
