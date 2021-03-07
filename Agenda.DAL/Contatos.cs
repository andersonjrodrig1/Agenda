using Agenda.Domain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Dapper;
using System.Linq;

namespace Agenda.DAL
{
    public class Contatos
    {
        private string _strConexao;

        public Contatos()
        {
            _strConexao = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        }

        public void Adicionar(Contato contato)
        {
            var insertContato = "insert into Contato (id, nome) values (@id, @nome)";

            using (SqlConnection conn = new SqlConnection(_strConexao))
            {
                conn.Execute(insertContato, contato);
            }
        }

        public Contato Obter(Guid id)
        {
            Contato contato = null;

            var selectContato = @"select id, nome from Contato where id = @id";

            using (SqlConnection conn = new SqlConnection(_strConexao))
            {
                contato = conn.Query<Contato>(selectContato, new { id = id }).First();
            }

            return contato;
        }

        public IEnumerable<Contato> ObterTodos()
        {
            var contatos = new List<Contato>();

            var selectContatos = string.Format("select id, nome from Contato");

            using (SqlConnection conn = new SqlConnection(_strConexao))
            {
                contatos = conn.Query<Contato>(selectContatos, null).ToList();
            }

            return contatos;
        }
    }
}
