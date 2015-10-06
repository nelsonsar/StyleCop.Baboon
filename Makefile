build:
	nuget restore
	xbuild StyleCop.Baboon.sln

test: build
	nunit-console StyleCop.Baboon.Tests/bin/Debug/StyleCop.Baboon.Tests.dll
