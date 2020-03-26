using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace PortariaInteligente.Models
{
    public class ConvidadosEventoViewModel
    {
        public List<Convidado> Convidados { get; set; }
        public SelectList Eventos { get; set; }//Uma SelectList que contém a lista de eventos. Isso permite que o usuário selecione um evento na lista.
        public string Evento { get; set; }//Evento, que contém o evento selecionado.
        public string SearchString { get; set; } //SearchString, que contém o texto que os usuários inserem na caixa de texto de pesquisa.
    }
}
