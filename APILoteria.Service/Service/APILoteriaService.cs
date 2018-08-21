using APILoteria.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSena.Domain.Entities;
using WebSena.Util.Http;

namespace APILoteria.Service.Service
{
    public class APILoteriaService : IAPILoteriaService
    {

        private string _wsloteria_url;
        private string _userId;
        private string _password;

        private string _tokenAuth;

        public string TokenAuth {
            get {
                return _tokenAuth;
            }
        }

        public APILoteriaService()
        {
            _wsloteria_url = System.Configuration.ConfigurationManager.AppSettings["megasena_url"];
            _userId = System.Configuration.ConfigurationManager.AppSettings["megasena_user"];
            _password = System.Configuration.ConfigurationManager.AppSettings["megasena_password"];
            if (string.IsNullOrWhiteSpace(_tokenAuth))
            {
                _tokenAuth = Authenticar();
            }
        }
        private string Authenticar()
        {
            try
            {
                User user = new User()
                {
                    Codigo = _userId,
                    Senha = _password
                };
                string userJson = new HttpUtility().ObjectToJsonSerializer<User>(user);
                string authResponseJson = new HttpUtility().SendHttpWebRequest(userJson,
                     HttpUtility.HttpVerbEnum.Post,
                     HttpUtility.HttpContentTypeEnum.Json,
                     _wsloteria_url + "account/authenticate",
                     new NameValueCollection());
                AuthResponse response = new HttpUtility().JsonToObjectDeserialize<AuthResponse>(authResponseJson);
                return response.Token;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Falha ao se autenticar no serviço da megasena", ex);
            }
        }

        public List<ConcursoDTO> ObterTodosOsConcursos()
        {
            try
            {
                List<Concurso> concursos = new List<Concurso>();
                string token = Authenticar();
                NameValueCollection header = new NameValueCollection();
                header.Add("A-Token", token);

                string concursosJson = new HttpUtility().SendHttpWebRequest("",
                     HttpUtility.HttpVerbEnum.Get,
                     HttpUtility.HttpContentTypeEnum.Json,
                     _wsloteria_url + $"megasena",
                     header);

                List<ConcursoDTO> dtos = new HttpUtility()
                    .JsonToObjectDeserialize<List<ConcursoDTO>>(concursosJson);

                return dtos;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Falha ao carregar o concurso do serviços da megasena", ex);
            }
        }


        public ConcursoDTO ObterUltimoConcurso()
        {
            try
            {
                List<Concurso> concursos = new List<Concurso>();
                string token = Authenticar();
                NameValueCollection header = new NameValueCollection();
                header.Add("A-Token", token);

                string concursosJson = new HttpUtility().SendHttpWebRequest("",
                     HttpUtility.HttpVerbEnum.Get,
                     HttpUtility.HttpContentTypeEnum.Json,
                     _wsloteria_url + $"megasena/last/1",
                     header);

                List<ConcursoDTO> dtos = new HttpUtility()
                    .JsonToObjectDeserialize<List<ConcursoDTO>>(concursosJson);
                return dtos.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Falha ao carregar o concurso do serviços da megasena", ex);
            }
        }

        public List<ConcursoDTO> ObterConcursosPorData(DateTime dataInicio, DateTime dataFim)
        {
            try
            {
                List<ConcursoDTO> concursos = new List<ConcursoDTO>();
                string token = Authenticar();
                NameValueCollection header = new NameValueCollection();
                header.Add("A-Token", token);

                string concursosJson = new HttpUtility().SendHttpWebRequest("",
                     HttpUtility.HttpVerbEnum.Get,
                     HttpUtility.HttpContentTypeEnum.Json,
                     _wsloteria_url + $"megasena/range/{dataInicio.ToShortDateString()}/{dataFim.ToShortDateString()}",
                     header);
                List<ConcursoDTO> dtos = new HttpUtility()
                    .JsonToObjectDeserialize<List<ConcursoDTO>>(concursosJson);
                return dtos;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Falha ao carregar o concurso do serviços da megasena", ex);
            }
        }
    }
}
