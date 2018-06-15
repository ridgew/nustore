﻿using System;
using System.Collections.Generic;
using System.Text;
using CommandLine;

namespace NuStore.Common
{
    internal class RestoreOptions
    {
        [Option('s', "deps", HelpText ="deps file. default is *.deps.json in current directory")]
        public string DepsFile { get; set; }

        [Option('d', "dir", HelpText = "diretory packages stored(typically at /usr/local/share/dotnet/store on macOS/Linux and C:/Program Files/dotnet/store on Windows).")]
        public string Directory { get; set; }

        [Option('f', "force", HelpText = "override exists packages")]
        public bool ForceOverride { get; set; }

        [Option("nuget", HelpText = "set nuget resouce api url. default: https://api.nuget.org/v3/index.json")]
        public string NugetServiceIndex { get; set; }

        [Option('s', "skip", HelpText = "skip packages, support regex")]
        public string Skip { get; set; }

        //[]
        //public bool Minify { get; set; }
    }

    //[Verb("restore", HelpText ="")]
    //public class Restore
    //{

    //}
}
