using System.Reflection;
using Foundation;

// This attribute allows you to mark your assemblies as “safe to link”.
// When the attribute is present, the linker—if enabled—will process the assembly
// even if you’re using the “Link SDK assemblies only” option, which is the default for device builds.

[assembly: LinkerSafe]

// Information about this assembly is defined by the following attributes.
// Change them to the values specific to your project.

[assembly: AssemblyTitle ("Adobe Mobile SDK for Xamarin iOS")]
[assembly: AssemblyDescription ("Adobe Mobile SDK for Xamarin iOS")]
[assembly: AssemblyConfiguration ("")]
[assembly: AssemblyCompany ("Adobe")]
[assembly: AssemblyProduct ("Adobe Mobile SDK")]
[assembly: AssemblyCopyright ("Copyright 2014 Adobe Systems Incorporated\n *  All Rights Reserved.\n *\n * NOTICE:  All information contained herein is, and remains\n * the property of Adobe Systems Incorporated and its suppliers,\n * if any.  The intellectual and technical concepts contained\n * herein are proprietary to Adobe Systems Incorporated and its\n * suppliers and are protected by trade secret or copyright law.\n * Dissemination of this information or reproduction of this material\n * is strictly forbidden unless prior written permission is obtained\n * from Adobe Systems Incorporated.")]
[assembly: AssemblyTrademark ("")]
[assembly: AssemblyCulture ("")]

// The assembly version has the format "{Major}.{Minor}.{Build}.{Revision}".
// The form "{Major}.{Minor}.*" will automatically update the build and revision,
// and "{Major}.{Minor}.{Build}.*" will update just the revision.

[assembly: AssemblyVersion ("4.11.0")]

// The following attributes are used to specify the signing key for the assembly,
// if desired. See the Mono documentation for more information about signing.

//[assembly: AssemblyDelaySign(false)]
//[assembly: AssemblyKeyFile("")]
