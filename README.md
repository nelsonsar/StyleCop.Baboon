# StyleCop.Baboon

A command line runner for StyleCop that works for all.

[![Build status](https://ci.appveyor.com/api/projects/status/qs2k50hblbc4b603/branch/master?svg=true)](https://ci.appveyor.com/project/nelsonsar/stylecop-baboon/branch/master) [![Build Status](https://travis-ci.org/nelsonsar/StyleCop.Baboon.svg?branch=master)](https://travis-ci.org/nelsonsar/StyleCop.Baboon)

## Building

On Windows you can use ```msbuild``` as you would for a normal project:

```
nuget restore
msbuild "StyleCop.Baboon.sln"
```

On Linux and OSX you'll need [Mono](http://www.mono-project.com/download/):

```
nuget restore
xbuild "StyleCop.Baboon.sln"
```

## License

MIT
