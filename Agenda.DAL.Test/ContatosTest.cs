using Agenda.Domain;
using NUnit.Framework;
using System;
using System.Linq;

namespace Agenda.DAL.Test
{
    [TestFixture]
    public class ContatosTest
    {
        private Contatos _contatos;

        [SetUp]
        public void SetUp()
        {
            _contatos = new Contatos();
        }

        [Test]
        public void IncluirContatoTest()
        {
            var contato = new Contato();
            contato.Id = Guid.NewGuid();
            contato.Nome = "Marcos";

            _contatos.Adicionar(contato);

            Assert.True(true);
        }

        [Test]
        public void ObterContatoTest()
        {
            var contato = new Contato();
            contato.Id = Guid.NewGuid();
            contato.Nome = "Maria";

            _contatos.Adicionar(contato);
            var resultado = _contatos.Obter(contato.Id);

            Assert.AreEqual(contato.Id, resultado.Id);
            Assert.AreEqual(contato.Nome, resultado.Nome);
        }

        [Test]
        public void ObterTodos()
        {
            var contato = new Contato();
            contato.Id = Guid.NewGuid();
            contato.Nome = "Maria";

            _contatos.Adicionar(contato);

            var list = _contatos.ObterTodos();
            var resultado = list.Where(l => l.Id == contato.Id).FirstOrDefault();

            Assert.IsTrue(list.Any());
            Assert.AreEqual(resultado.Id, contato.Id);
            Assert.AreEqual(resultado.Nome, contato.Nome);
        }

        [TearDown]
        public void TearDown()
        {
            _contatos = null;
        }
    }
}
