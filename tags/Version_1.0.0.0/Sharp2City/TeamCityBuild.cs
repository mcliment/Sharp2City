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

using System.Diagnostics;

#endregion

namespace Sharp2City
{
    /// <summary>
    ///   Information about a Team City Build
    /// </summary>
    public sealed class TeamCityBuild
    {
        #region private fields

        /// <summary>
        ///   The Build Id
        /// </summary>
        private readonly int buildId;

        /// <summary>
        ///   The Build Status
        /// </summary>
        private readonly string status;

        #endregion

        #region constructors

        /// <summary>
        ///   Initializes a new instance of the <see cref = "TeamCityBuild" /> class.
        /// </summary>
        /// <param name = "xmlBuild">The deserialized Response from TeamCity</param>
        internal TeamCityBuild(XmlBuild xmlBuild)
        {
            this.status = xmlBuild.Status;
            this.buildId = xmlBuild.Id;
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
            return (this.status);
        }

        #endregion

        #region public properties

        /// <summary>
        ///   Gets the BuildId of the Build
        /// </summary>
        public int BuildId
        {
            [DebuggerStepThrough]
            get
            {
                return this.buildId;
            }
        }

        /// <summary>
        ///   Gets the Status of the Build
        /// </summary>
        public BuildStatus BuildStatus
        {
            [DebuggerStepThrough]
            get
            {
                switch (this.status)
                {
                    case "SUCCESS":
                    {
                        return (BuildStatus.Success);
                    }
                    default:
                    {
                        return (BuildStatus.Failed);
                    }
                }
            }
        }

        #endregion
    }
}