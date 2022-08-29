using System.Text;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace LandwalkerServer
{
    public class Webhost
    {
        int Port = 80;
        string webRoot = "http";
        private HttpListener _listener;

        public void Start(bool Verbose)
        {
            string prefix = $"http://localhost:{Port}/";
            _listener = new HttpListener();
            _listener.Prefixes.Add(prefix);
            _listener.Start();

            try
            {
                Task listenTask = Listen();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public void Stop()
        {
            _listener.Stop();
        }

        private async Task Listen()
        {
            while (true)
            {
                var context = await _listener.GetContextAsync();
                var request = context.Request;
                var response = context.Response;

                string path = $"{webRoot}{request.Url.LocalPath}";

                if (!File.Exists(path))
                {
                    Console.WriteLine($"{path} Does not exist");
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    response.StatusDescription = "404";
                    response.OutputStream.Close();
                }
                else
                {
                    Console.WriteLine($"Transferring {path}");
                    using (FileStream fs = File.OpenRead(path))
                    {

                        using (var fileStream = File.OpenRead(path))
                        {
                            response.ContentType = "application/octet-stream";
                            response.ContentLength64 = (new FileInfo(path)).Length;
                            response.AddHeader(
                                "Content-Disposition",
                                "Attachment; filename=\"" + Path.GetFileName(path) + "\"");
                            fileStream.CopyTo(response.OutputStream);
                        }

                        response.StatusCode = (int)HttpStatusCode.OK;
                        response.StatusDescription = "OK";
                        response.OutputStream.Close();
                    }
                }
            }
        }
    }
}

