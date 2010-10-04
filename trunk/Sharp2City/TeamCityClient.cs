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
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;

#endregion

namespace Sharp2City
{
    /// <summary>
    ///   The Client for the Team City REST API
    /// </summary>
    public sealed class TeamCityClient
    {
        #region private fields

        /// <summary>
        ///   The Configuration for the Team City Access
        /// </summary>
        private readonly ITeamCityAccessConfiguration accessConfiguration;

        /// <summary>
        ///   The <see cref = "TeamCityConnection" /> to use
        /// </summary>
        private readonly TeamCityConnection connection;

        #endregion

        #region constructors

        /// <summary>
        ///   Initializes a new instance of the <see cref = "TeamCityClient" /> class.
        /// </summary>
        /// <param name = "accessConfiguration">The access configuration.</param>
        public TeamCityClient(ITeamCityAccessConfiguration accessConfiguration)
        {
            if (accessConfiguration == null) throw new ArgumentNullException("accessConfiguration");
            this.accessConfiguration = accessConfiguration;

            this.connection = new TeamCityConnection(this.accessConfiguration);
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref = "TeamCityClient" /> class.
        /// </summary>
        /// <param name = "hostName">Name of the host.</param>
        /// <param name = "userName">Name of the user.</param>
        /// <param name = "password">The password.</param>
        public TeamCityClient(string hostName, string userName, string password)
            : this(new DefaultAccessConfiguration(hostName,
                                                  userName,
                                                  password))
        {}

        #endregion

        #region public methods

        /// <summary>
        ///   Downloads the Build Log for the specified <paramref name = "buildId" />
        /// </summary>
        /// <param name = "buildId">The buildId of the Build to load the Build Log</param>
        /// <returns>A <see cref = "string" /> with the Build Log</returns>
        public string DownloadBuildLog(int buildId)
        {
            Uri uri = this.connection.CreateUri(string.Format(CultureInfo.InvariantCulture,
                                                              "/httpAuth/downloadBuildLog.html?buildId={0}",
                                                              buildId));

            return (this.connection.RequestText(uri));
        }

        /// <summary>
        ///   Searches for the <see cref = "TeamCityBuildConfiguration" /> of the project <paramref name = "projectName" />
        ///   with the name <paramref name = "configurationName" />.
        /// </summary>
        /// <param name = "projectName">The name of the project</param>
        /// <param name = "configurationName">The name of the build configuration</param>
        /// <returns>An instance of <see cref = "TeamCityBuildConfiguration" /> if a Buildconfiguraiton for the specified names was found; otherwise <c>null</c></returns>
        public TeamCityBuildConfiguration FindBuildConfiguration(string projectName, string configurationName)
        {
            TeamCityProject teamCityProject = this.FindProject(projectName);

            if (teamCityProject != null)
            {
                return (this.FindBuildConfiguration(teamCityProject,
                                                    configurationName));
            }

            return (null);
        }

        /// <summary>
        ///   Searches for the <see cref = "TeamCityBuildConfiguration" /> with in name <paramref name = "configurationName" /> in the project specified by <paramref name = " teamCityProject" />
        /// </summary>
        /// <param name = "teamCityProject">The project to look at</param>
        /// <param name = "configurationName">The name of the build configuration</param>
        /// <returns>An instance of <see cref = "TeamCityBuildConfiguration" /> if a Buildconfiguraiton for the specified names was found; otherwise <c>null</c></returns>
        public TeamCityBuildConfiguration FindBuildConfiguration(TeamCityProject teamCityProject,
                                                                 string configurationName)
        {
            foreach (
                TeamCityBuildConfiguration teamCityBuildConfiguration in
                    this.GetBuildConfigurations(teamCityProject))
            {
                if (teamCityBuildConfiguration.Name.Equals(configurationName,
                                                           StringComparison.Ordinal))
                {
                    return (teamCityBuildConfiguration);
                }
            }

            return (null);
        }

        /// <summary>
        ///   Searches for the last successful Build in the <paramref name = "buildConfiguration" />
        /// </summary>
        /// <param name = "buildConfiguration">The Build configuration where to look</param>
        /// <returns>An instance of <see cref = "TeamCityBuild" /> if a sucessful Build was found; otherwise <c>null</c></returns>
        public TeamCityBuild FindLastSuccessfulBuild(TeamCityBuildConfiguration buildConfiguration)
        {
            foreach (TeamCityBuild teamCityBuild in this.GetBuilds(buildConfiguration))
            {
                if (teamCityBuild.BuildStatus == BuildStatus.Success)
                {
                    return (teamCityBuild);
                }
            }

            return (null);
        }

        /// <summary>
        ///   Searches for the project with specified name
        /// </summary>
        /// <param name = "projectName">The name of the Project to search for</param>
        /// <returns>An instance of <see cref = "TeamCityProject" /> if a Project was found; otherwise <c>null</c></returns>
        public TeamCityProject FindProject(string projectName)
        {
            foreach (TeamCityProject teamCityProject in this.GetAllProjects())
            {
                if (teamCityProject.Name.Equals(projectName,
                                                StringComparison.Ordinal))
                {
                    return (teamCityProject);
                }
            }

            return (null);
        }

        /// <summary>
        ///   Returns a Collection of all Builds of the TeamCity Server
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TeamCityBuild> GetAllBuilds()
        {
            return (this.GetBuilds("/httpAuth/app/rest/builds"));
        }

        /// <summary>
        ///   Returns a Collection of all TeamCity Projects
        /// </summary>
        /// <returns>Collection of <see cref = "TeamCityProject" /></returns>
        public IEnumerable<TeamCityProject> GetAllProjects()
        {
            Uri uri = this.connection.CreateUri("/httpAuth/app/rest/projects");

            XmlProjects projectsElement = this.connection.Request<XmlProjects>(uri);

            foreach (XmlProject projectInfo in projectsElement.Projects)
            {
                Uri projectInfoUri = this.connection.CreateUri(projectInfo.Href);

                XmlProject project = this.connection.Request<XmlProject>(projectInfoUri);

                yield return new TeamCityProject(project);
            }
        }

        public void DownloadArtifacts(int buildId, DownloadArtifactsCallback downloadArtifactsCallback)
        {
            Uri uri = this.connection.CreateUri(string.Format(CultureInfo.InvariantCulture,
                                                              "/httpAuth/downloadArtifacts.html?buildId={0}",
                                                              buildId));

            string tempFileName = Path.GetTempFileName();
            try
            {
                this.connection.Download(uri,
                                         tempFileName);
                downloadArtifactsCallback(tempFileName);
            }
            finally
            {
                if (File.Exists(tempFileName)) File.Delete(tempFileName);
            }
        }

        /// <summary>
        ///   Returns a Collection of all TeamCity Build Configuartions of the specified <paramref name = "project" />
        /// </summary>
        /// <param name = "project">The Project</param>
        /// <returns>A Collection of <see cref = "TeamCityBuildConfiguration" /></returns>
        public IEnumerable<TeamCityBuildConfiguration> GetBuildConfigurations(TeamCityProject project)
        {
            Uri uri = this.connection.CreateUri(project.Href);

            XmlProject xmlProject = this.connection.Request<XmlProject>(uri);

            foreach (XmlBuildType xmlBuildType in xmlProject.BuildType.BuildType)
            {
                Uri buildTypeUri = this.connection.CreateUri(xmlBuildType.Href);

                XmlDetailedBuildType detailedBuildType = this.connection.Request<XmlDetailedBuildType>(buildTypeUri);

                yield return new TeamCityBuildConfiguration(detailedBuildType);
            }
        }

        public IEnumerable<TeamCityBuild> GetBuilds(TeamCityBuildConfiguration configuration)
        {
            string relativeUrl = configuration.BuildsUrl;

            return (this.GetBuilds(relativeUrl));
        }

        #endregion

        #region public properties

        public ServerInfo ServerInfo
        {
            [DebuggerStepThrough]
            get
            {
                Uri serverInfoUri = this.connection.CreateUri("/httpAuth/app/rest/server");

                XmlServer xmlServer = this.connection.Request<XmlServer>(serverInfoUri);

                return (new ServerInfo(xmlServer));
            }
        }

        #endregion

        #region private methods

        private IEnumerable<TeamCityBuild> GetBuilds(string relativeUrl)
        {
            XmlBuildsCollection builds;
            do
            {
                Uri uri = this.connection.CreateUri(relativeUrl);
                builds = this.connection.Request<XmlBuildsCollection>(uri);

                foreach (XmlBuild xmlBuild in builds.Build)
                {
                    Uri detailedUri = this.connection.CreateUri(xmlBuild.Href);

                    XmlBuild detailed = this.connection.Request<XmlBuild>(detailedUri);

                    yield return new TeamCityBuild(detailed);
                }

                relativeUrl = builds.NextHref;
            } while (!string.IsNullOrEmpty(builds.NextHref));
        }

        #endregion

        #region Nested type: DefaultAccessConfiguration

        private sealed class DefaultAccessConfiguration : ITeamCityAccessConfiguration
        {
            #region private fields

            private readonly string hostName;

            private readonly string password;

            private readonly string userName;

            #endregion

            #region constructors

            public DefaultAccessConfiguration(string hostName, string userName, string password)
            {
                this.hostName = hostName;
                this.password = password;
                this.userName = userName;
            }

            #endregion

            #region ITeamCityAccessConfiguration Members

            /// <summary>
            ///   Gets the Hostname
            /// </summary>
            public string HostName
            {
                get
                {
                    return this.hostName;
                }
            }

            /// <summary>
            ///   Gets the Password
            /// </summary>
            public string Password
            {
                get
                {
                    return this.password;
                }
            }

            /// <summary>
            ///   Gets the Username
            /// </summary>
            public string UserName
            {
                get
                {
                    return this.userName;
                }
            }

            #endregion
        }

        #endregion
    }
}