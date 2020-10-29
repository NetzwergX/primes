# Primes

![.NET Core Unit Tests](https://github.com/NetzwergX/Primes/workflows/.NET%20Core%20Unit%20Tests/badge.svg)

is a tech demo for .Net Core 3.1, showcasing a full CI/CD pipeline
for a REST API which is consumed by an SPA app (using Aurelia) with

* unit tests
* integration tests
* benchmarks (report generation)
* [WIP] E2E tests
* [WIP] Load tests
* [WIP] stress tests

# License

(The MIT License)

Copyright &copy; 2020 Sebastian Teumert &lt;https://sebastian.teumert.net&gt;

[See LICENSE](/LICENSE)

# Benchmarks

In order to use `dotnet benchmark`,
you need to run `dotnet tool install -g BenchmarkDotNet.Tool`.

    $ dotnet build -C Release
    $ dotnet benchmark ./Prime.Service.Benchmarks/bin/Release/netstandard2.0/Prime.Service.Benchmarks.dll --filter * --runtimes net472 netcoreapp3.1 Mono

To change the artifact folder:

    $ dotnet benchmark ./Prime.Service.Benchmarks/bin/Release/netstandard2.0/Prime.Service.Benchmarks.dll --filter * --runtimes net472 netcoreapp3.1 Mono --artifacts="./path-to-artifact-folder/"

You can also run `dotnet tool restore`
and then use `dotnet dotnet-benchmark ...`