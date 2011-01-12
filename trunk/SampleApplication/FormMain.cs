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
using System.Text;
using System.Windows.Forms;

using SampleApplication.Properties;

using Sharp2City;

#endregion

namespace SampleApplication
{
    public partial class FormMain : Form, ITeamCityAccessConfiguration
    {
        #region private fields

        private readonly TeamCityClient teamCityClient;

        #endregion

        #region constructors

        public FormMain()
        {
            this.InitializeComponent();

            this.teamCityClient = new TeamCityClient(this);
        }

        #endregion

        #region protected override methods

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            Settings.Default.Save();

            base.OnFormClosed(e);
        }

        #endregion

        #region private methods

        private void OnButtonShowServerInfoClick(object sender, EventArgs e)
        {
            this.SafeExecute(this.ShowServerInfo);
        }

        private void SafeExecute(Action action)
        {
            try
            {
                action();
            }
            catch (Exception exception)
            {
                MessageBox.Show(this,
                                exception.Message,
                                "SampelApplication",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void ShowServerInfo()
        {
            ServerInfo serverInfo = this.teamCityClient.ServerInfo;

            StringBuilder message = new StringBuilder();

            message.AppendFormat("Version: {0}", serverInfo.Version).AppendLine();
            message.AppendFormat("StartTime: {0}", serverInfo.StartTime).AppendLine();
            message.AppendFormat("CurrentTime: {0}", serverInfo.CurrentTime).AppendLine();

            this.textBoxOutput.AppendText(message.ToString());
        }

        #endregion

        #region ITeamCityAccessConfiguration Members

        string ITeamCityAccessConfiguration.HostName
        {
            [DebuggerStepThrough]
            get
            {
                return (this.textBoxHostName.Text);
            }
        }

        string ITeamCityAccessConfiguration.Password
        {
            [DebuggerStepThrough]
            get
            {
                return (this.textBoxPassword.Text);
            }
        }

        string ITeamCityAccessConfiguration.UserName
        {
            [DebuggerStepThrough]
            get
            {
                return (this.textBoxUsername.Text);
            }
        }

        bool ITeamCityAccessConfiguration.UseSSL
        {
            get
            {
                return this.checkBoxUseSsl.Checked;
            }
        }

        #endregion

        #region Nested type: Action

        private delegate void Action();

        #endregion

        private void OnButtonShowAllBuildsClick(object sender, EventArgs e)
        {
            foreach (var build in this.teamCityClient.GetAllBuilds())
            {
                var sb = new StringBuilder();

                sb.AppendFormat("BuildId: {0}", build.BuildId).AppendLine();
                sb.AppendFormat("FinishDate: {0}", build.FinishDate).AppendLine();
                sb.AppendFormat("StatusText: {0}", build.StatusText).AppendLine();

                this.textBoxOutput.AppendText(sb.ToString());
            }
        }
    }
}