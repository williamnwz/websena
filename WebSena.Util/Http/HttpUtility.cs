using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft;
using Newtonsoft.Json;

namespace WebSena.Util.Http
{

    public class HttpUtility
    {

        public enum HttpVerbEnum
        {

            Get,
            Post,
            Put,
            Delete
        }

        public enum HttpContentTypeEnum
        {

            Xml,
            Json
        }

        /// <summary>
        /// Envio de HttpWebRequest
        /// </summary>
        /// <param name="dataToSend"></param>
        /// <param name="httpVerbEnum"></param>
        /// <param name="httpContentTypeEnum"></param>
        /// <param name="serviceEndpoint"></param>
        /// <param name="headerData"></param>
        /// <param name="allowInvalidCertificate"></param>
        /// <param name="ignoreResponse"></param>
        /// <returns></returns>
        public string SendHttpWebRequest(string dataToSend, HttpVerbEnum httpVerbEnum, HttpContentTypeEnum httpContentTypeEnum, string serviceEndpoint, NameValueCollection headerData, bool allowInvalidCertificate = false, bool ignoreResponse = false)
        {

            if (string.IsNullOrWhiteSpace(serviceEndpoint)) { throw new ArgumentException("serviceEndpoint"); }

            // Cria um objeto webRequest para referenciando a Url do serviço informado
            Uri serviceUri = new Uri(serviceEndpoint);

            HttpWebRequest httpWebRequest = WebRequest.Create(serviceUri) as HttpWebRequest;
            httpWebRequest.Method = httpVerbEnum.ToString().ToUpper();
            httpWebRequest.ContentType = httpContentTypeEnum == HttpContentTypeEnum.Json ? "application/json" : "text/xml";
            httpWebRequest.Accept = httpContentTypeEnum == HttpContentTypeEnum.Json ? "application/json" : "text/xml";
            httpWebRequest.ContentLength = 0;

            // Verifica se certificados inválidos devem ser aceitos.
            ServicePointManager.ServerCertificateValidationCallback = ((sender, certificate, chain, sslPolicyErrors) => allowInvalidCertificate);

            // Verifica se deverão ser enviados dados/chaves de cabeçalho
            if (headerData.Count > 0)
            {

                // Insere cada chave enviado no cabeçalho da requisição
                foreach (string key in headerData.Keys) { httpWebRequest.Headers.Add(key, headerData[key].ToString()); }
            }

            if (string.IsNullOrWhiteSpace(dataToSend) == false)
            {

                // Cria um array de bytes dos dados que serão postados
                byte[] byteData = UTF8Encoding.UTF8.GetBytes(dataToSend);

                // Configura o tamanho dos dados que serão enviados
                httpWebRequest.ContentLength = byteData.Length;

                // Escreve os dados na stream do WebRequest
                using (Stream stream = httpWebRequest.GetRequestStream())
                {
                    stream.Write(byteData, 0, byteData.Length);
                }
            }

            string returnString = string.Empty;

            try
            {
                // Dispara a requisição e recebe o resultado da mesma
                using (HttpWebResponse response = httpWebRequest.GetResponse() as HttpWebResponse)
                {
                    if (ignoreResponse == false)
                    {

                        // Recupera a stream com a resposta da solicitação
                        StreamReader streamReader = new StreamReader(response.GetResponseStream());
                        returnString = streamReader.ReadToEnd();
                    }
                }
            }
            catch (WebException ex)
            {
                throw ex;
            }

            return returnString;
        }

        /// <summary>
        /// Chamada Async do HttoWebRequest
        /// </summary>
        /// <param name="dataToSend"></param>
        /// <param name="httpVerbEnum"></param>
        /// <param name="httpContentTypeEnum"></param>
        /// <param name="serviceEndpoint"></param>
        /// <param name="headerData"></param>
        /// <param name="allowInvalidCertificate"></param>
        public void SendHttpWebRequestAsync(string dataToSend, HttpVerbEnum httpVerbEnum, HttpContentTypeEnum httpContentTypeEnum, string serviceEndpoint, NameValueCollection headerData, bool allowInvalidCertificate = false)
        {

            Task.Factory.StartNew(() =>
            {
                bool ignoreResponse = true;
                SendHttpWebRequest(dataToSend, httpVerbEnum, httpContentTypeEnum, serviceEndpoint, headerData, allowInvalidCertificate, ignoreResponse);
            });

        }
        /// <summary>
        /// Realiza serialização de um objeto para o formato Json correspondente
        /// </summary>
        public string ObjectToJsonSerializer<T>(T t)
        {

            // Classe de serialização Json
            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(T));

            // Serializa o objeto para o memoryStream
            MemoryStream memoryStream = new MemoryStream();
            jsonSerializer.WriteObject(memoryStream, t);

            // Recupera o Json correspondente ao objeto serializado
            string jsonString = Encoding.UTF8.GetString(memoryStream.ToArray());

            memoryStream.Close();

            return jsonString;
        }

        /// <summary>
        /// Realiza a deserialização de uma string Json para um objeto
        /// </summary>
        public T JsonToObjectDeserialize<T>(string jsonString)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.DateFormatHandling = DateFormatHandling.MicrosoftDateFormat;
            settings.DateParseHandling = DateParseHandling.DateTime;
            return JsonConvert.DeserializeObject<T>(jsonString, settings);
        }
    }

}

