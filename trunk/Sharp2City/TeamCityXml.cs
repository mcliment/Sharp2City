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

using System.Collections.Generic;
using System.Diagnostics;
using System.Xml.Serialization;

#endregion

namespace Sharp2City
{
    [XmlRoot("server")]
    public sealed class XmlServer
    {
        #region private fields

        private int buildNumber;

        private string currentTime;

        private string startTime;

        private string version;

        private int versionMajor;

        private int versionMinor;

        #endregion

        #region public properties

        [XmlAttribute("buildNumber")]
        public int BuildNumber
        {
            get
            {
                return this.buildNumber;
            }
            set
            {
                this.buildNumber = value;
            }
        }

        [XmlAttribute("currentTime")]
        public string CurrentTime
        {
            get
            {
                return this.currentTime;
            }
            set
            {
                this.currentTime = value;
            }
        }

        [XmlAttribute("startTime")]
        public string StartTime
        {
            get
            {
                return this.startTime;
            }
            set
            {
                this.startTime = value;
            }
        }

        [XmlAttribute("version")]
        public string Version
        {
            get
            {
                return this.version;
            }
            set
            {
                this.version = value;
            }
        }

        [XmlAttribute("versionMajor")]
        public int VersionMajor
        {
            get
            {
                return this.versionMajor;
            }
            set
            {
                this.versionMajor = value;
            }
        }

        [XmlAttribute("versionMinor")]
        public int VersionMinor
        {
            get
            {
                return this.versionMinor;
            }
            set
            {
                this.versionMinor = value;
            }
        }

        #endregion
    }

    [XmlRoot("builds")]
    [DebuggerDisplay("Count: {count} - Next Href: {nextHref}")]
    public sealed class XmlBuildsCollection
    {
        #region private fields

        private readonly List<XmlBuild> build = new List<XmlBuild>();

        private int count;

        private string nextHref;

        #endregion

        #region public properties

        [XmlElement("build")]
        public List<XmlBuild> Build
        {
            [DebuggerStepThrough]
            get
            {
                return (this.build);
            }
        }

        [XmlAttribute("count")]
        public int Count
        {
            [DebuggerStepThrough]
            get
            {
                return this.count;
            }
            [DebuggerStepThrough]
            set
            {
                this.count = value;
            }
        }

        [XmlAttribute("nextHref")]
        public string NextHref
        {
            [DebuggerStepThrough]
            get
            {
                return this.nextHref;
            }
            [DebuggerStepThrough]
            set
            {
                this.nextHref = value;
            }
        }

        #endregion
    }

    [XmlRoot("build")]
    public sealed class XmlBuild
    {
        #region private fields

        private string buildTypeId;

        private string finishDate;

        private string href;

        private int id;

        private int number;

        private string startDate;

        private string status;

        private string webUrl;

        private string statusText;

        #endregion

        #region public properties

        [XmlAttribute("buildTypeId")]
        public string BuildTypeId
        {
            [DebuggerStepThrough]
            get
            {
                return this.buildTypeId;
            }
            [DebuggerStepThrough]
            set
            {
                this.buildTypeId = value;
            }
        }

        [XmlElement("finishDate")]
        public string FinishDate
        {
            [DebuggerStepThrough]
            get
            {
                return this.finishDate;
            }
            [DebuggerStepThrough]
            set
            {
                this.finishDate = value;
            }
        }

        [XmlAttribute("href")]
        public string Href
        {
            [DebuggerStepThrough]
            get
            {
                return this.href;
            }
            [DebuggerStepThrough]
            set
            {
                this.href = value;
            }
        }

        [XmlAttribute("id")]
        public int Id
        {
            [DebuggerStepThrough]
            get
            {
                return this.id;
            }
            [DebuggerStepThrough]
            set
            {
                this.id = value;
            }
        }

        [XmlAttribute("number")]
        public int Number
        {
            [DebuggerStepThrough]
            get
            {
                return this.number;
            }
            [DebuggerStepThrough]
            set
            {
                this.number = value;
            }
        }

        [XmlElement("statusText")]
        public string StatusText
        {
            get
            {
                return this.statusText;
            }
            set
            {
                this.statusText = value;
            }
        }

        [XmlElement("startDate")]
        public string StartDate
        {
            [DebuggerStepThrough]
            get
            {
                return this.startDate;
            }
            [DebuggerStepThrough]
            set
            {
                this.startDate = value;
            }
        }

        [XmlAttribute("status")]
        public string Status
        {
            [DebuggerStepThrough]
            get
            {
                return this.status;
            }
            [DebuggerStepThrough]
            set
            {
                this.status = value;
            }
        }

        [XmlAttribute("webUrl")]
        public string WebUrl
        {
            [DebuggerStepThrough]
            get
            {
                return this.webUrl;
            }
            [DebuggerStepThrough]
            set
            {
                this.webUrl = value;
            }
        }

        #endregion
    }

    [XmlRoot("projects")]
    [DebuggerDisplay("Count: {projects.Count}")]
    public sealed class XmlProjects
    {
        #region private fields

        private readonly List<XmlProject> projects = new List<XmlProject>();

        #endregion

        #region public properties

        [XmlElement("project")]
        public List<XmlProject> Projects
        {
            get
            {
                return (this.projects);
            }
        }

        #endregion
    }

    public sealed class XmlBuilds
    {
        #region private fields

        private string href;

        #endregion

        #region public properties

        [XmlAttribute("href")]
        public string Href
        {
            [DebuggerStepThrough]
            get
            {
                return this.href;
            }
            [DebuggerStepThrough]
            set
            {
                this.href = value;
            }
        }

        #endregion
    }

    [XmlRoot("buildType")]
    public sealed class XmlDetailedBuildType
    {
        #region private fields

        private XmlBuilds builds;

        private string description;

        private string href;

        private string id;

        private string name;

        private string webUrl;

        #endregion

        #region public properties

        [XmlElement("builds")]
        public XmlBuilds Builds
        {
            [DebuggerStepThrough]
            get
            {
                return this.builds;
            }
            [DebuggerStepThrough]
            set
            {
                this.builds = value;
            }
        }

        [XmlAttribute("description")]
        public string Description
        {
            [DebuggerStepThrough]
            get
            {
                return this.description;
            }
            [DebuggerStepThrough]
            set
            {
                this.description = value;
            }
        }

        [XmlAttribute("href")]
        public string Href
        {
            [DebuggerStepThrough]
            get
            {
                return this.href;
            }
            [DebuggerStepThrough]
            set
            {
                this.href = value;
            }
        }

        [XmlAttribute("id")]
        public string Id
        {
            [DebuggerStepThrough]
            get
            {
                return this.id;
            }
            [DebuggerStepThrough]
            set
            {
                this.id = value;
            }
        }

        [XmlAttribute("name")]
        public string Name
        {
            [DebuggerStepThrough]
            get
            {
                return this.name;
            }
            [DebuggerStepThrough]
            set
            {
                this.name = value;
            }
        }

        [XmlAttribute("webUrl")]
        public string WebUrl
        {
            [DebuggerStepThrough]
            get
            {
                return this.webUrl;
            }
            [DebuggerStepThrough]
            set
            {
                this.webUrl = value;
            }
        }

        #endregion
    }

    public sealed class XmlBuildType
    {
        #region private fields

        private string href;

        private string id;

        private string name;

        private string projectId;

        private string projectName;

        private string webUrl;

        #endregion

        #region public properties

        [XmlAttribute("href")]
        public string Href
        {
            [DebuggerStepThrough]
            get
            {
                return this.href;
            }
            [DebuggerStepThrough]
            set
            {
                this.href = value;
            }
        }

        [XmlAttribute("id")]
        public string Id
        {
            [DebuggerStepThrough]
            get
            {
                return this.id;
            }
            [DebuggerStepThrough]
            set
            {
                this.id = value;
            }
        }

        [XmlAttribute("name")]
        public string Name
        {
            [DebuggerStepThrough]
            get
            {
                return this.name;
            }
            [DebuggerStepThrough]
            set
            {
                this.name = value;
            }
        }

        [XmlAttribute("projectId")]
        public string ProjectId
        {
            [DebuggerStepThrough]
            get
            {
                return this.projectId;
            }
            [DebuggerStepThrough]
            set
            {
                this.projectId = value;
            }
        }

        [XmlAttribute("projectName")]
        public string ProjectName
        {
            [DebuggerStepThrough]
            get
            {
                return this.projectName;
            }
            [DebuggerStepThrough]
            set
            {
                this.projectName = value;
            }
        }

        [XmlAttribute("webUrl")]
        public string WebUrl
        {
            [DebuggerStepThrough]
            get
            {
                return this.webUrl;
            }
            [DebuggerStepThrough]
            set
            {
                this.webUrl = value;
            }
        }

        #endregion
    }

    public sealed class XmlBuildTypes
    {
        #region private fields

        private readonly List<XmlBuildType> buildType = new List<XmlBuildType>();

        #endregion

        #region public properties

        [XmlElement("buildType")]
        public List<XmlBuildType> BuildType
        {
            get
            {
                return (this.buildType);
            }
        }

        #endregion
    }

    [DebuggerDisplay("Name: {name} Id: {id} Href: {href}")]
    [XmlRoot("project")]
    public sealed class XmlProject
    {
        #region private fields

        private bool archived;

        private XmlBuildTypes buildType;

        private string description;

        private string href;

        private string id;

        private string name;

        private string webUrl;

        #endregion

        #region public properties

        [XmlAttribute("archived")]
        public bool Archived
        {
            [DebuggerStepThrough]
            get
            {
                return this.archived;
            }
            [DebuggerStepThrough]
            set
            {
                this.archived = value;
            }
        }

        [XmlElement("buildTypes")]
        public XmlBuildTypes BuildType
        {
            [DebuggerStepThrough]
            get
            {
                return this.buildType;
            }
            [DebuggerStepThrough]
            set
            {
                this.buildType = value;
            }
        }

        [XmlAttribute("description")]
        public string Description
        {
            [DebuggerStepThrough]
            get
            {
                return this.description;
            }
            [DebuggerStepThrough]
            set
            {
                this.description = value;
            }
        }

        [XmlAttribute("href")]
        public string Href
        {
            [DebuggerStepThrough]
            get
            {
                return this.href;
            }
            [DebuggerStepThrough]
            set
            {
                this.href = value;
            }
        }

        [XmlAttribute("id")]
        public string Id
        {
            [DebuggerStepThrough]
            get
            {
                return this.id;
            }
            [DebuggerStepThrough]
            set
            {
                this.id = value;
            }
        }

        [XmlAttribute("name")]
        public string Name
        {
            [DebuggerStepThrough]
            get
            {
                return this.name;
            }
            [DebuggerStepThrough]
            set
            {
                this.name = value;
            }
        }

        [XmlAttribute("webUrl")]
        public string WebUrl
        {
            [DebuggerStepThrough]
            get
            {
                return this.webUrl;
            }
            [DebuggerStepThrough]
            set
            {
                this.webUrl = value;
            }
        }

        #endregion
    }
}