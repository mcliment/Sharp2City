#region File Header

// Copyright (c) 2010, Stefan Stolz
// All rights reserved.
// 
// Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:
// 
// * Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.
// 
// * Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in the documentation and/or other materials provided with the distribution.
// 
// * Neither the name of Sharp2City nor the names of its contributors may be used to endorse or promote products derived from this software without specific prior written permission.
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

#endregion

#region using directives

using System;
using System.Globalization;
using System.IO;
using System.Net;
using System.Xml.Serialization;

#endregion

namespace Sharp2City
{
    /// <summary>
    ///   Creates Connections to access TeamCity
    /// </summary>
    public sealed class TeamCityConnection
    {
        #region private fields

        /// <summary>
        ///   The access Configuration
        /// </summary>
        private readonly ITeamCityAccessConfiguration configuration;

        #endregion

        #region constructors

        /// <summary>
        ///   Initializes a new instance of the <see cref = "TeamCityConnection" /> class.
        /// </summary>
        /// <param name = "configuration">The access configuration.</param>
        /// <exception cref = "ArgumentNullException"><c>configuration</c> is <c>null</c></exception>
        public TeamCityConnection(ITeamCityAccessConfiguration configuration)
        {
            if (configuration == null) throw new ArgumentNullException("configuration");
            this.configuration = configuration;
        }

        #endregion

        #region public methods

        /// <summary>
        ///   Creates an absolute <see cref = "Uri" /> for a Resource of the TeamCity Server
        /// </summary>
        /// <param name = "relativeUrl">The relative URL of the TeamCity server</param>
        /// <returns>An <see cref = "Uri" /> with the absolute Location of the Resources</returns>
        public Uri CreateUri(string relativeUrl)
        {
            Uri uri = new Uri(new Uri(string.Format(CultureInfo.InvariantCulture,
                                                    "http://{0}",
                                                    this.configuration.HostName)),
                              relativeUrl);

            return (uri);
        }

        /// <summary>
        ///   Creates a <see cref = "WebRequest" /> for the specified <paramref name = "uri" /> with
        ///   the credentials of the TeamCity Account
        /// </summary>
        /// <param name = "uri">The Uri for the <see cref = "WebRequest" /></param>
        /// <returns>A <see cref = "WebRequest" /> that can access the TeamCity Server</returns>
        public HttpWebRequest CreateWebRequest(Uri uri)
        {
            HttpWebRequest webRequest = (HttpWebRequest) WebRequest.Create(uri);
            webRequest.Credentials = new NetworkCredential(this.configuration.UserName,
                                                           this.configuration.Password);
            webRequest.Proxy = null;
            return (webRequest);
        }

        /// <summary>
        ///   Downloads a Resource from the TeamCity Server and saves it to <paramref name = "destinationFile" />
        /// </summary>
        /// <param name = "uri">The Uri of the Resource</param>
        /// <param name = "destinationFile">The destination File</param>
        public void Download(Uri uri, string destinationFile)
        {
            HttpWebRequest webRequest = this.CreateWebRequest(uri);

            using (WebResponse webResponse = webRequest.GetResponse())
            {
                using (Stream sourceStream = webResponse.GetResponseStream())
                {
                    using (FileStream fs = new FileStream(destinationFile,
                                                          FileMode.OpenOrCreate,
                                                          FileAccess.ReadWrite,
                                                          FileShare.None))
                    {
                        byte[] buffer = new byte[4096 * 4];
                        int count;

                        do
                        {
                            count = sourceStream.Read(buffer,
                                                      0,
                                                      buffer.Length);
                            fs.Write(buffer,
                                     0,
                                     count);
                        } while (count > 0);
                    }
                }
            }
        }

        /// <summary>
        ///   Requests a Resource of the TeamCity Server and deserializes the Response
        /// </summary>
        /// <typeparam name = "T">The Type of the Response</typeparam>
        /// <param name = "uri">The Uri of the Resource to request</param>
        /// <returns>The deserialized resource</returns>
        public T Request<T>(Uri uri)
        {
            HttpWebRequest webRequest = this.CreateWebRequest(uri);
            webRequest.Accept = "application/xml";

            using (WebResponse webResponse = webRequest.GetResponse())
            {
                XmlSerializer serializer = new XmlSerializer(typeof (T));

                using (Stream stream = webResponse.GetResponseStream())
                {
                    return ((T) serializer.Deserialize(stream));
                }
            }
        }

        /// <summary>
        ///   Requests a Text Resource of the TeamCity Server
        /// </summary>
        /// <param name = "uri">The Uri of the Resource to request</param>
        /// <returns>The Response</returns>
        public string RequestText(Uri uri)
        {
            HttpWebRequest webRequest = this.CreateWebRequest(uri);

            using (WebResponse webResponse = webRequest.GetResponse())
            {
                using (StreamReader sr = new StreamReader(webResponse.GetResponseStream()))
                {
                    return (sr.ReadToEnd());
                }
            }
        }

        #endregion
    }
}