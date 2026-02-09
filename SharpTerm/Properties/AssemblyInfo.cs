using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Internals visible to unit tests
[assembly: InternalsVisibleTo("SharpTerm.Tests")]

// General info
[assembly: AssemblyTitle("SharpTerm")]
[assembly: AssemblyDescription("A C# library for rich text and windowing in the terminal")]
[assembly: AssemblyConfiguration("Debug")]
[assembly: AssemblyCompany("ed522")]
[assembly: AssemblyProduct("SharpTerm")]
[assembly: AssemblyCopyright("Copyright © 2026 ed522")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")] // localisation

// Not visible to COM
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
// Should not be necessary
[assembly: Guid("57ef8dac-80ef-4e83-9367-46476f94593d")]

// Specified in semantic versioning [Maj].[Min].[Build].[Patch]
// where [Maj] = major/breaking;
//       [Min] = nonbreaking additions that change the public API;
//       [Build] = build number
//       [Revision] = bug fixes and other changes that do not change the public API.
// .NET requires all four in the top two, but [Build] is dropped in the informational version.
[assembly: AssemblyVersion("0.1.0.0")]
[assembly: AssemblyFileVersion("0.1.0.0")]
// remove [Build]
[assembly: AssemblyInformationalVersion("0.1.0")]
