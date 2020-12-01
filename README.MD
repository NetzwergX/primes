# Primes

![.NET Core Unit Tests](https://github.com/NetzwergX/Primes/workflows/.NET%20Core%20Unit%20Tests/badge.svg)
![Webpack Build](https://github.com/NetzwergX/Primes/workflows/Webpack%20Build/badge.svg)

is a tech demo for .Net Core 3.1, showcasing a full CI/CD pipeline
for a Web API which is consumed by an SPA app (using Aurelia) with

* Unit tests
* Integration tests
* Benchmarks (report generation, comment on PR [WIP])
* Vulnerability scanning via CodeQL
* [WIP] E2E tests
* [WIP] Load tests
* [WIP] Stress tests


# Usage

    $ git clone git@github.com:NetzwergX/Primes.git
    $ cd Primes/
    
    $ dotnet build
    $ cd Prime.WebApi/
    $ dotnet watch run
    
    $ cd .\Prime.UI\
    $ npm install
    $ npm start

# License

(The MIT License)

Copyright &copy; 2020 Sebastian Teumert &lt;https://sebastian.teumert.net&gt;

[See LICENSE](/LICENSE)

# Benchmarks (for Prime.Service)

In order to use `dotnet benchmark`,
you need to run `dotnet tool install -g BenchmarkDotNet.Tool`.

    $ dotnet build -C Release
    $ dotnet benchmark ./Prime.Service.Benchmarks/bin/Release/netstandard2.0/Prime.Service.Benchmarks.dll --filter * --runtimes net472 netcoreapp3.1 Mono

To change the artifact folder:

    $ dotnet benchmark ./Prime.Service.Benchmarks/bin/Release/netstandard2.0/Prime.Service.Benchmarks.dll --filter * --runtimes net472 netcoreapp3.1 Mono --artifacts="./path-to-artifact-folder/"

You can also run `dotnet tool restore`
and then use `dotnet dotnet-benchmark ...`

# Linting

## Prime.UI

Run `npx eslint ./src --ext .ts,.tsx --report-unused-disable-directives`
in `Prime.UI/`

### VS Code

If you are using the project in VS Code and open the root folder, ESLint will
search the config files in the root folder. To properly run from `Prime.UI/`,
add `"eslint.workingDirectories" : ["Prime.UI/"]` to your `settings.json`
(for [Microsofts ESLint plugin](https://github.com/microsoft/vscode-eslint)).
