﻿# NuStore
Download nuget packages which declared in the *.deps.json, and save it to store folder, for minify .net core publish size

## Install
	dotnet tool install -g NuStore

## Update
	dotnet tool update -g Nustore

## Uninstall
	dotnet tool uninstall -g NuStore

## Usage
	nustore verb [options]
By default `nustore restore` will load the deps file from current folder, 
and save the packages to /usr/local/share/dotnet/store 
on macOS/Linux and C:/Program Files/dotnet/store on Windows


by default `nustore minify` will parse ./*.deps.json and merge all  project dlls into [project name].dll, then copy the [project name].dll appsettings.json and runtimeconfig.\* to ./nustored/  


get help info via `nustore --help` `nustore restore --help` or `nustore minify --help`

> dotnet core installed path may be different on linux, for example it may be /usr/share/dotnet on centos7


## verbs
1. restore
2. minify

## restore options

 opt           | desc
-------------- | -----
`-p` `--deps` | deps file. default is *.deps.json in current directory
`-d` `--dir` | directory packages stored (typically at /usr/local/share/dotnet/store on macOS/Linux and C:/Program Files/dotnet/store on Windows)
`-f` `--force` | override existing packages, default is false
`-y` `--yes` | yes to all confirm, default is false
`-k` `--keep` | keep the raw full path in package, default is false
`--nuget` | set nuget resource api url. default: https://api.nuget.org/v3/index.json
`-e` `--exclude` | skip packages, support regex. separated by semicolon for mutiple
`-s` `--special` | restore special packages, support regex. separated by semicolon for mutiple
`--runtime` | .net core runtime version, the defaut value set by deps file, for example netcoreapp2.0/netcoreapp2.1
`--arch` | x64/x86, by default this value is resolved from platform attribute which declared in deps file
`--flatten` | restore files directly onto path/package.dll instead of restoring in nested folders (eg. path/x64/netcoreapp2.0/package/1.2.0/lib/netcoreapp2.0/package.dll)
`-v` `--verbosity` | show detailed log
`--help` | get help info

## minify options

 opt           | desc
-------------- | -----
`-d` `--dir` | output directory. default is ./nustored
`-c` `--copy` | copy files to output dir, default is appsettings.json. support wildcard: *.exe;appsettings.json, separated by semicolon
`-a` `--all` | merge all dlls in current dir
`--exclude` | exclude dlls, support regex. separated by semicolon for mutiple
`-k` `--kind` | specify target assembly kind (dll, exe, winexe supported, default is same as first assembly)
`--search` | adds the path to the search directories for referenced assemblies (can be specified multiple times), separated by semicolon
`--delaysign` | sets the key, but don't sign the assembly
`--debug` | enable symbol file generation
`-v` `--verbosity` | show detailed log
`--help` | get help info


### example

Use e:/nustore/test.deps.json file to restore packages to e:/nustore. exclude all packages which start with microsoft

``` bash
nustore restore --dir="e:/nustore" --deps="e:/nustore/test.deps.json" --exclude="^microsoft.*;^System.*" -s "Microsoft\.Extensions.Logging"
```

Merge dlls into ./out/ and copy *.json and *.exe files to output dir.
``` bash
nustore minify --dir out -c *.json;*.exe
```
