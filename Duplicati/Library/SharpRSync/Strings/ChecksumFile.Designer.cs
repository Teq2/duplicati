﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.237
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Duplicati.Library.SharpRSync.Strings {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class ChecksumFile {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ChecksumFile() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Duplicati.Library.SharpRSync.Strings.ChecksumFile", typeof(ChecksumFile).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to End of stream occured while reading initial 4 bytes of signature file.
        /// </summary>
        internal static string EndofstreamBeforeSignatureError {
            get {
                return ResourceManager.GetString("EndofstreamBeforeSignatureError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to End of stream occured while reading blocksize in signature file.
        /// </summary>
        internal static string EndofstreamInBlocksizeError {
            get {
                return ResourceManager.GetString("EndofstreamInBlocksizeError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to End of stream occured while reading stronglen in signature file.
        /// </summary>
        internal static string EndofstreamInStronglenError {
            get {
                return ResourceManager.GetString("EndofstreamInStronglenError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to End of stream occured while reading strong signature from signature file.
        /// </summary>
        internal static string EndofstreamInStrongSignatureError {
            get {
                return ResourceManager.GetString("EndofstreamInStrongSignatureError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Blocklen in signature file was: {0}, which does not seem correct.
        /// </summary>
        internal static string InvalidBlocksizeError {
            get {
                return ResourceManager.GetString("InvalidBlocksizeError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The size of the signature file is invalid.
        /// </summary>
        internal static string InvalidFilesizeError {
            get {
                return ResourceManager.GetString("InvalidFilesizeError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Signature stream did not have the correct start marker.
        /// </summary>
        internal static string InvalidSignatureHeaderError {
            get {
                return ResourceManager.GetString("InvalidSignatureHeaderError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Stronglen in signature file was: {0}, which does not seem correct.
        /// </summary>
        internal static string InvalidStrongsizeError {
            get {
                return ResourceManager.GetString("InvalidStrongsizeError", resourceCulture);
            }
        }
    }
}
