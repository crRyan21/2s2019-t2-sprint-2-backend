using Microsoft.EntityFrameworkCore;
using Senai.ManualPecas.WebApi.Domains;
using Senai.ManualPecas.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.ManualPecas.WebApi.Repositories
{
    public class FornecedorRepository : IFornecedorRepository
    {
        public List<Fornecedores> Listar()
        {
            using (ManualPecasContext ctx = new ManualPecasContext())
            {
                return ctx.Fornecedores.ToList();
            }
        }
        public void Cadastrar(Fornecedores fornecedor)
        {
            using (ManualPecasContext ctx = new ManualPecasContext())
            {
                ctx.Fornecedores.Add(fornecedor);
                ctx.SaveChanges();
            }
        }
        public void Atualizar(Fornecedores fornecedor)
        {
            using (ManualPecasContext ctx = new ManualPecasContext())
            {
                Fornecedores fornecedorBuscado = ctx.Fornecedores.Find(fornecedor.FornecedorId);
                fornecedorBuscado.NomeFantasia = fornecedor.NomeFantasia;
                fornecedorBuscado.RazaoSocial = fornecedor.RazaoSocial;
                fornecedorBuscado.Cnpj = fornecedor.Cnpj;
                fornecedorBuscado.Endereco = fornecedor.Endereco;
                fornecedorBuscado.Pecas = fornecedor.Pecas;
                fornecedorBuscado.UsuarioId = fornecedor.UsuarioId;
                ctx.Fornecedores.Update(fornecedorBuscado);
                ctx.SaveChanges();
            }
        }
        public Fornecedores BuscarPorId(int id)
        {
            using (ManualPecasContext ctx = new ManualPecasContext())
            {
                return ctx.Fornecedores.Find(id);

            }

        }
        public void Deletar(int id)
        {
            using (ManualPecasContext ctx = new ManualPecasContext())
            {
                ctx.Usuarios.Remove(ctx.Usuarios.FirstOrDefault(x => x.Fornecedores.FornecedorId == id));
                ctx.Fornecedores.Remove(ctx.Fornecedores.Find(id));
                ctx.SaveChanges();
            }
        }
    }
}
