#region Disclaimer / License
// Copyright (C) 2011, Kenneth Skovhede
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

namespace Duplicati.Library.Interface
{
    /// <summary>
    /// The interface all backends must implement.
    /// The classes that implements this interface MUST also 
    /// implement a default constructor and a construtor that
    /// has the signature new(string url, Dictionary&lt;string, string&gt; options).
    /// The default constructor is used to construct an instance
    /// so the DisplayName and other values can be read.
    /// The other constructor is used to do the actual work.
    /// An instance is never reused.
    /// </summary>
    public interface IBackend : IDisposable
    {
        /// <summary>
        /// The localized name to display for this backend
        /// </summary>
        string DisplayName { get;}

        /// <summary>
        /// The protocol key, eg. ftp, http or ssh
        /// </summary>
        string ProtocolKey { get; }

        /// <summary>
        /// Returns a list of files found on the remote location
        /// </summary>
        /// <param name="url">The url passed</param>
        /// <returns>The list of files</returns>
        List<IFileEntry> List();

        /// <summary>
        /// Puts the content of the file to the url passed
        /// </summary>
        /// <param name="remotename">The remote filename, relative to the URL</param>
        /// <param name="filename">The local filename</param>
        void Put(string remotename, string filename);

        /// <summary>
        /// Downloads a file with the remote data
        /// </summary>
        /// <param name="remotename">The remote filename, relative to the URL</param>
        /// <param name="filename">The local filename</param>
        void Get(string remotename, string filename);

        /// <summary>
        /// Deletes the specified file
        /// </summary>
        /// <param name="remotename">The remote filename, relative to the URL</param>
        void Delete(string remotename);

        /// <summary>
        /// Gets a list of supported commandline arguments
        /// </summary>
        IList<ICommandLineArgument> SupportedCommands { get; }

        /// <summary>
        /// A localized description of the backend, for display in the usage information
        /// </summary>
        string Description { get; }
    }
}
