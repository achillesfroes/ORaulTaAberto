using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using WebApplication4.Models;
using Newtonsoft.Json;

namespace WebApplication4.Hubs
{
    public class PessoasIO : Hub
    {
        private static List<Pessoa> pessoasNoRaul;

        public PessoasIO()
        {
            if (pessoasNoRaul == null)
            {
                pessoasNoRaul = new List<Pessoa>();

                pessoasNoRaul.Add(new Pessoa { Nome = "Zé", QuandoChegou = DateTime.Now.ToString("dd/MM/yyyy hh:mm")});
            }
        }

        public void CheckIn(string nick, string dataHora)
        {
            if (!pessoasNoRaul.Any(p => p.Nome.Equals(nick)))
            {
                AdicionarPessoa(nick, dataHora);

                ObterPessoasNoRaul();
            }
        }

        public void CheckOut(string nick)
        {
            if (!String.IsNullOrWhiteSpace(nick))
            {
                Pessoa pessoa = pessoasNoRaul.FirstOrDefault(p => p.Nome.Equals(nick));
                pessoasNoRaul.Remove(pessoa);

                ObterPessoasNoRaul();
            }
        }

        public void ObterPessoasNoRaul()
        {
            Clients.All.listarPessoas(JsonConvert.SerializeObject(pessoasNoRaul));
        }

        private void AdicionarPessoa(string nick, string dataHora)
        {
            pessoasNoRaul.Add(new Pessoa { Nome = nick, QuandoChegou = dataHora });
        }
    }
}