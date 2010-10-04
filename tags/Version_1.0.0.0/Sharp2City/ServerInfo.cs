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
    public sealed class ServerInfo
    {
        #region private fields

        private readonly XmlServer xmlServerInfo;

        #endregion

        #region constructors

        internal ServerInfo(XmlServer xmlServerInfo)
        {
            if (xmlServerInfo == null) throw new ArgumentNullException("xmlServerInfo");
            this.xmlServerInfo = xmlServerInfo;
        }

        #endregion

        #region public properties

        public int BuildNumber
        {
            [DebuggerStepThrough]
            get
            {
                return (this.xmlServerInfo.BuildNumber);
            }
        }

        public DateTime CurrentTime
        {
            [DebuggerStepThrough]
            get
            {
                return (Helpers.ParseTeamCityTimeStamp(this.xmlServerInfo.CurrentTime));
            }
        }

        public int MajorVersion
        {
            [DebuggerStepThrough]
            get
            {
                return (this.xmlServerInfo.VersionMajor);
            }
        }

        public int MinorVersion
        {
            [DebuggerStepThrough]
            get
            {
                return (this.xmlServerInfo.VersionMinor);
            }
        }

        public DateTime StartTime
        {
            [DebuggerStepThrough]
            get
            {
                return (Helpers.ParseTeamCityTimeStamp(this.xmlServerInfo.StartTime));
            }
        }

        public string Version
        {
            [DebuggerStepThrough]
            get
            {
                return (this.xmlServerInfo.Version);
            }
        }

        #endregion
    }
}