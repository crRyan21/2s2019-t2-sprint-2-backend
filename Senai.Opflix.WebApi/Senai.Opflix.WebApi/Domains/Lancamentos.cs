using System;
using System.Collections.Generic;

namespace Senai.Opflix.WebApi.Domains
{
    public partial class Lancamentos
    {
        public int IdLancamento { get; set; }
        public string Nome { get; set; }
        public int? IdTipoTitulo { get; set; }
        public string Sinopse { get; set; }
        public int? IdCategoria { get; set; }
        public string Duracao { get; set; }
        public DateTime DataLancamento { get; set; }
        public int? IdPlataform { get; set; }
        public List<ListaFavoritos> ListaFavoritos { get; set; }

        public Categorias IdCategoriaNavigation { get; set; }
        public Plataformas IdPlataformNavigation { get; set; }
        public TipoTitulo IdTipoTituloNavigation { get; set; }
    }
}
