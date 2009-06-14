﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3082
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Duplicati.Library.Backend.Strings {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class S3Backend {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal S3Backend() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Duplicati.Library.Backend.Strings.S3Backend", typeof(S3Backend).Assembly);
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
        ///   Looks up a localized string similar to The AWS &quot;Secret Access Key&quot; can be obtained after logging into your AWS account, this can also be supplied through the &quot;ftp-password&quot; property.
        /// </summary>
        internal static string AMZKeyDescriptionLong {
            get {
                return ResourceManager.GetString("AMZKeyDescriptionLong", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The AWS &quot;Secret Access Key&quot;.
        /// </summary>
        internal static string AMZKeyDescriptionShort {
            get {
                return ResourceManager.GetString("AMZKeyDescriptionShort", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The AWS &quot;Access Key ID&quot; can be obtained after logging into your AWS account..
        /// </summary>
        internal static string AMZUserIDDescriptionLong {
            get {
                return ResourceManager.GetString("AMZUserIDDescriptionLong", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The AWS &quot;Access Key ID&quot;.
        /// </summary>
        internal static string AMZUserIDDescriptionShort {
            get {
                return ResourceManager.GetString("AMZUserIDDescriptionShort", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This backend can read and write data to an Amazon S3 based backend. Allowed formats are &quot;s3://bucketname/prefix&quot; or &quot;s3://aws_id:aws_key@bucketname/prefix&quot;. Note that if you AWS ID or Key contains either &quot;:&quot;, &quot;/&quot; or &quot;@&quot; you cannot use the second form, but must supply them through arguments..
        /// </summary>
        internal static string Description {
            get {
                return ResourceManager.GetString("Description", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Amazon S3 based.
        /// </summary>
        internal static string DisplayName {
            get {
                return ResourceManager.GetString("DisplayName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The password used to connect to the server. This may also be supplied as the environment variable &quot;FTP_PASSWORD&quot;..
        /// </summary>
        internal static string FTPPasswordDescriptionLong {
            get {
                return ResourceManager.GetString("FTPPasswordDescriptionLong", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Supplies the password used to connect to the server.
        /// </summary>
        internal static string FTPPasswordDescriptionShort {
            get {
                return ResourceManager.GetString("FTPPasswordDescriptionShort", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No Amazon S3 secret key given.
        /// </summary>
        internal static string NoAMZKeyError {
            get {
                return ResourceManager.GetString("NoAMZKeyError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No Amazon S3 userID given.
        /// </summary>
        internal static string NoAMZUserIDError {
            get {
                return ResourceManager.GetString("NoAMZUserIDError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This flag is only used when creating new buckets. If the flag is set, the bucket is created on a european server. This flag forces the &quot;s3-use-new-style&quot; flag. Amazon charges slightly more for european buckets..
        /// </summary>
        internal static string S3EurobucketDescriptionLong {
            get {
                return ResourceManager.GetString("S3EurobucketDescriptionLong", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Use a European server.
        /// </summary>
        internal static string S3EurobucketDescriptionShort {
            get {
                return ResourceManager.GetString("S3EurobucketDescriptionShort", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Specify this argument to make the S3 backend use subdomains rather than the previous url prefix method. See the Amazon S3 documentation for more details..
        /// </summary>
        internal static string S3NewStyleDescriptionLong {
            get {
                return ResourceManager.GetString("S3NewStyleDescriptionLong", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Use subdomain calling style.
        /// </summary>
        internal static string S3NewStyleDescriptionShort {
            get {
                return ResourceManager.GetString("S3NewStyleDescriptionShort", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unable to determine the bucket name for host: {0}.
        /// </summary>
        internal static string UnableToDecodeBucketnameError {
            get {
                return ResourceManager.GetString("UnableToDecodeBucketnameError", resourceCulture);
            }
        }
    }
}
