using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebEnviarVariosArquivosImagens.Models;

namespace WebEnviarVariosArquivosImagens.Controllers
{
    public class HomeController : Controller
    {

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        //maxRequestLength - o limite do tamanho do request em Kilobytes(o valor padrão é 4096 KB)
        //requestLengthDiskThreshold - o limite dos dados armazenados no buffer na memória do servidor em kilobyte(o padrão é 80 KB)
        //executionTimeout - o tempo de execução permitida para a requisição antes do seu encerramento(o padrão é 110 segundos)
        //Todos esses atributos devem ser definidos na seção <httpRunttime>.


        [HttpPost]
        public ActionResult Index(RemessaImagens arq)
        {
            try
            {       

                Guid prefixo = Guid.NewGuid();
                string nomeArquivo = "";
                string arquivoEnviados = "";
                string[] extensaoPermitida = { ".png", ".jpeg"};

                foreach (var arquivo in arq.Arquivos)
                {
                    string extensao = Path.GetExtension(arquivo.FileName);
                    if (arquivo.ContentLength > 0 && extensaoPermitida.Contains(extensao))
                    {
                        nomeArquivo = Path.GetFileName(prefixo + arquivo.FileName);
                        var caminho = Path.Combine(Server.MapPath("~/Imagens"),  nomeArquivo);
                        arquivo.SaveAs(caminho);
                    }

                    arq.Id = Guid.NewGuid();
                    arq.NomeArquivo = nomeArquivo;
                    arquivoEnviados = arquivoEnviados + " , " + nomeArquivo;
                }

                ViewBag.Mensagem = "Arquivos enviados  : " + arquivoEnviados + " , com sucesso.";
            }
            catch (Exception ex)
            {
                ViewBag.Mensagem = "Erro : " + ex.Message;
            }
            return View();
        }
    }


}