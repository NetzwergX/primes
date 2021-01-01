# Primes
[![Unit Tests (.NET Core)](https://github.com/NetzwergX/Primes/workflows/Unit%20Tests%20(.NET%20Core)/badge.svg)](https://github.com/NetzwergX/Primes/actions?query=workflow%3A%22Unit+Tests+%28.NET+Core%29%22) 
[![Build (Webpack)](https://github.com/NetzwergX/Primes/workflows/Build%20(Webpack)/badge.svg)](https://github.com/NetzwergX/Primes/actions?query=workflow%3A%22Build+%28Webpack%29%22) 
[![Pipeline status](https://gitlab.com/s.teumert/primes/badges/master/pipeline.svg)](https://gitlab.com/s.teumert/primes/-/pipelines/latest)

A tech demo for .Net Core 3.1, showcasing a full CI/CD pipeline
for a REST API (.Net Core) which is consumed by an SPA (using Aurelia),
featuring:

* Unit tests
* [WIP] Integration tests
* Benchmarks (report generation, comment on PR [WIP])
* Vulnerability scanning via CodeQL
* [WIP] E2E tests
* [WIP] Load tests
* [WIP] Stress tests
* Docker Image Build
* [WIP] Docker image Upload to registry
# Usage

    $ git clone git@github.com:NetzwergX/Primes.git
    $ cd Primes/

    % pushd rest-api
    $ dotnet build
    $ dotnet run -p Prime.WebApi/
    $ popd

    $ pushd web-app/
    $ npm install
    $ npm start
    $ popd

# Docker build

    $ git clone git@github.com:NetzwergX/Primes.git
    $ cd Primes/

    % pushd rest-api
    $ docker build -t rest-api
    $ docker run -dp 5000:5000 rest-api
    $ popd

    % pushd web-app
    $ docker build -t web-app
    $ docker run -dp 8080:8080 web-app
    $ popd

# License

(The MIT License)

Copyright &copy; 2020 Sebastian Teumert &lt;https://sebastian.teumert.net&gt;

[See LICENSE](/LICENSE)

# Benchmarks (for Prime.Service)

In order to use `dotnet benchmark`,
you need to run `dotnet tool install -g BenchmarkDotNet.Tool`.

    $ git clone git@github.com:NetzwergX/Primes.git
    $ cd Primes/rest-api/
    $ dotnet build -C Release
    $ dotnet benchmark ./Prime.Service.Benchmarks/bin/Release/netstandard2.0/Prime.Service.Benchmarks.dll --filter * --runtimes net472 netcoreapp3.1 Mono

To change the artifact folder:

    $ git clone git@github.com:NetzwergX/Primes.git
    $ cd Primes/rest-api/
    $ dotnet benchmark ./Prime.Service.Benchmarks/bin/Release/netstandard2.0/Prime.Service.Benchmarks.dll --filter * --runtimes net472 netcoreapp3.1 Mono --artifacts="./path-to-artifact-folder/"

You can also run `dotnet tool restore`
and then use `dotnet dotnet-benchmark ...`

# Linting

## Prime.UI

Run `npx eslint ./src --ext .ts,.tsx --report-unused-disable-directives`
in `Prime.UI/`

### VS Code

~~If you are using the project in VS Code and open the root folder, ESLint will
search the config files in the root folder. To properly run from `Prime.UI/`,
add `"eslint.workingDirectories" : ["Prime.UI/"]` to your `settings.json`
(for [Microsofts ESLint plugin](https://github.com/microsoft/vscode-eslint)).~~

This repo contains a workspace `settings.json` with the proper ESLint configuration.
