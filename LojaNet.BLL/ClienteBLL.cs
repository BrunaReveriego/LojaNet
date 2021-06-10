using System;
using System.Collections.Generic;
using System.Text;
using LojaNet.Models;
using LojaNet.DAL;

namespace LojaNet.BLL
{
    public class ClienteBLL : IClienteDados
    {


        private ClienteDAL dal;

        public ClienteBLL()
        {
            this.dal = new ClienteDAL();
        }


        //Business Logic Layer




        public void Alterar(Cliente cliente)
        {
            Validar(cliente);

            if (string.IsNullOrEmpty(cliente.Id))
            {
                throw new Exception("O id deve ser informado");
            }


            dal.Alterar(cliente);
        }

        public void Excluir(string Id)
        {

            if (string.IsNullOrEmpty(Id))
            {
                throw new Exception("O id deve ser informado");
            }


            dal.Excluir(Id);
        }

        public void Incluir(Cliente cliente)
        {
            Validar(cliente);

            if (string.IsNullOrEmpty(cliente.Id))
            {
                // criação de GUID
                cliente.Id = Guid.NewGuid().ToString();
            }


            dal.Incluir(cliente);
        }

        private static void Validar(Cliente cliente)
        {
            if (string.IsNullOrEmpty(cliente.Nome))
            {
                throw new ApplicationException("Campo nome deve ser informado");
            }
        }

        public Cliente ObterPorEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Cliente ObterPorId(string id)
        {
            return dal.ObterPorId(id);
        }

        public List<Cliente> ObterTodos()
        {
            var dal = new ClienteDAL();
            var lista = dal.ObterTodos();

            return lista;
        }
    }
}
