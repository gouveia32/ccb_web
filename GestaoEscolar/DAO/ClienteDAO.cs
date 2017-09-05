using GestaoEscolar.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GestaoEscolar.DAO
{
    public class ClienteDAO
    {
        private Contexto contexto;

        public ClienteDAO(Contexto contexto)
        {
            this.contexto = contexto;
        }

        public void salva(Cliente novoClientea)
        {
            contexto.Clientes.Add(novoClientea);
            contexto.SaveChanges();
        }

        public void SalvarMudanca(Cliente cliente)
        {
            contexto.Entry(cliente).State = EntityState.Modified;
            contexto.SaveChanges();
        }

        public IList<Cliente> ListaClientes()
        {
            return contexto.Clientes.ToList();
        }

        public Cliente BuscaPorId(long Id)
        {
            return contexto.Clientes.Find(Id);
        }

        public void Excluir(long Id)
        {
            var cliente = contexto.Clientes.First(x => x.Id == Id);
            contexto.Clientes.Remove(cliente);
            contexto.SaveChanges();
        }
    }
}