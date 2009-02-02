#region Disclaimer / License
// Copyright (C) 2008, Kenneth Skovhede
// http://www.hexad.dk, opensource@hexad.dk
// 
// This library is free software; you can redistribute it and/or
// modify it under the terms of the GNU Lesser General Public
// License as published by the Free Software Foundation; either
// version 2.1 of the License, or (at your option) any later version.
// 
// This library is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
// Lesser General Public License for more details.
// 
// You should have received a copy of the GNU Lesser General Public
// License along with this library; if not, write to the Free Software
// Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301  USA
// 
#endregion
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.LightDatamodel;

namespace Duplicati.Datamodel
{
    public class ApplicationSettings
    {
        private SettingsHelper<ApplicationSetting, string, string> m_appset;

        private const string RECENT_DURATION = "Recent duration";
        private const string PGP_PATH = "PGP path";
        private const string PYTHON_PATH = "Python path";
        private const string DUPLICITY_PATH = "Duplicity path";
        private const string NCFTP_PATH = "NcFTP Path";
        private const string PUTTY_PATH = "Putty Path";

        public const string APP_PATH_ENV = "%APP_PATH%";

        public ApplicationSettings(IDataFetcher dataparent)
        {
            m_appset = new SettingsHelper<ApplicationSetting, string, string>(dataparent, new List<ApplicationSetting>(dataparent.GetObjects<ApplicationSetting>()), "Name", "Value");
        }

        /// <summary>
        /// Gets or sets the amount of time a log entry will be visible in the list of recent backups
        /// </summary>
        public string RecentBackupDuration
        {
            get { return string.IsNullOrEmpty(m_appset[RECENT_DURATION]) ? "2W" : m_appset[RECENT_DURATION]; }
            set { m_appset[RECENT_DURATION] = value; }
        }

        /// <summary>
        /// Gets or sets the path to PGP. May contain environment variables
        /// </summary>
        public string PGPPath
        {
            get { return string.IsNullOrEmpty(m_appset[PGP_PATH]) ? APP_PATH_ENV + "gpg" : m_appset[PGP_PATH]; }
            set { m_appset[PGP_PATH] = value; }
        }

        /// <summary>
        /// Gets or sets the path to NcFTP. May contain environment variables
        /// </summary>
        public string NcFTPPath
        {
            get { return string.IsNullOrEmpty(m_appset[NCFTP_PATH]) ? APP_PATH_ENV + "ncftp" : m_appset[NCFTP_PATH]; }
            set { m_appset[NCFTP_PATH] = value; }
        }

        /// <summary>
        /// Gets or sets the path to Putty. May contain environment variables
        /// </summary>
        public string PuttyPath
        {
            get { return string.IsNullOrEmpty(m_appset[PUTTY_PATH]) ? APP_PATH_ENV + "putty" : m_appset[PUTTY_PATH]; }
            set { m_appset[PUTTY_PATH] = value; }
        }

        /// <summary>
        /// Gets or sets the path to the pyhon executeable. May contain environment variables
        /// </summary>
        public string PythonPath
        {
            get { return string.IsNullOrEmpty(m_appset[PYTHON_PATH]) ? APP_PATH_ENV + "python25\\python.exe" : m_appset[PYTHON_PATH]; }
            set { m_appset[PYTHON_PATH] = value; }
        }

        /// <summary>
        /// Gets or sets the path to the duplicity main script. May contain environment variables
        /// </summary>
        public string DuplicityPath
        {
            get { return string.IsNullOrEmpty(m_appset[DUPLICITY_PATH]) ? APP_PATH_ENV + "duplicity\\duplicity.py" : m_appset[DUPLICITY_PATH]; }
            set { m_appset[DUPLICITY_PATH] = value; }
        }

    }
}