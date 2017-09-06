using ccb_web.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ccb_web.DAO
{
    public class ClienteDAO
    {
        private Contexto contexto;

        public ClienteDAO(Contexto contexto)
        {
            this.contexto = contexto;
        }

        public void Salvar(Cliente novoCliente)
        {
            contexto.Clientes.Add(novoCliente);
            contexto.SaveChanges();
        }

        public IList<Cliente> Lista()
        {
            return contexto.Clientes.OrderBy(a => a.Nome).ToList();
        }

        public Cliente BuscarClienteId(int Id)
        {
            Cliente cliente = contexto.Clientes.FirstOrDefault(a => a.Id == Id);
            return cliente;
        }

        public IList<Cliente> BuscaClienteTermo(string termo)
        {
            return contexto.Clientes
                .Where(a => a.Nome.ToUpper()
                .Contains(termo.ToUpper())).ToList();
        }

        public void Alterar(Cliente cliente)
        {
            contexto.Entry(cliente).State = EntityState.Modified;
            contexto.SaveChanges();
        }

        public void Excluir(Cliente cliente)
        {
            contexto.Clientes.Remove(cliente);
            contexto.SaveChanges();
        }

    }
}