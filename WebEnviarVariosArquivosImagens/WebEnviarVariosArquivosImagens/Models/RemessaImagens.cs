using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebEnviarVariosArquivosImagens.Models
{
    public class RemessaImagens
    {
        public Guid Id { get; set; }
        public string NomeArquivo { get; set; }
        public int IdTabelaOs { get; set; }
        public IEnumerable<HttpPostedFileBase> Arquivos { get; set; }
    }
}