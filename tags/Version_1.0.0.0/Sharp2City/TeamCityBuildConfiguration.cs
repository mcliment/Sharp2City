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
using System.Diagnostics;

#endregion

namespace Sharp2City
{
    /// <summary>
    ///   Information about a TeamCity Build Configuration
    /// </summary>
    public sealed class TeamCityBuildConfiguration
    {
        #region private fields

        /// <summary>
        ///   The URLs of the Builds of this Configuration
        /// </summary>
        private readonly string buildsUrl;

        /// <summary>
        ///   The relative Url of the detailed Information
        /// </summary>
        private readonly string href;

        /// <summary>
        ///   The Configuration Id
        /// </summary>
        private readonly string id;

        /// <summary>
        ///   The Name of the configuration
        /// </summary>
        private readonly string name;

        /// <summary>
        ///   The URL of the TeamCity Web Page of this Configuration
        /// </summary>
        private readonly string webUrl;

        #endregion

        #region constructors

        /// <summary>
        ///   Initializes a new instance of the <see cref = "TeamCityBuildConfiguration" /> class.
        /// </summary>
        /// <param name = "buildType">The Deserialized Team City Response</param>
        /// <exception cref = "ArgumentNullException"><paramref name = "buildType" /> is <c>null</c>.</exception>
        internal TeamCityBuildConfiguration(XmlDetailedBuildType buildType)
        {
            if (buildType == null) throw new ArgumentNullException("buildType");
            this.id = buildType.Id;
            this.name = buildType.Name;
            this.href = buildType.Href;
            this.webUrl = buildType.WebUrl;
            this.buildsUrl = buildType.Builds.Href;
        }

        #endregion

        #region public override methods

        /// <summary>
        ///   Returns a <see cref = "System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        ///   A <see cref = "System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return (this.name);
        }

        #endregion

        #region public properties

        /// <summary>
        ///   Gets the URL of the Builds
        /// </summary>
        public string BuildsUrl
        {
            [DebuggerStepThrough]
            get
            {
                return this.buildsUrl;
            }
        }

        /// <summary>
        ///   Gets the URL of the detailed information
        /// </summary>
        public string Href
        {
            [DebuggerStepThrough]
            get
            {
                return this.href;
            }
        }

        /// <summary>
        ///   Gets the Id of the Build Configuration
        /// </summary>
        public string Id
        {
            [DebuggerStepThrough]
            get
            {
                return this.id;
            }
        }

        /// <summary>
        ///   Gets the Name of the Build Configuration
        /// </summary>
        public string Name
        {
            [DebuggerStepThrough]
            get
            {
                return this.name;
            }
        }

        /// <summary>
        ///   Gets the URL of the TeamCity Webpage
        /// </summary>
        public string WebUrl
        {
            [DebuggerStepThrough]
            get
            {
                return this.webUrl;
            }
        }

        #endregion
    }
}