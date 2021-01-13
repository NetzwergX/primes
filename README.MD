# Primes
[![Pipeline Status](https://gitlab.com/s.teumert/primes/badges/master/pipeline.svg)](https://gitlab.com/s.teumert/primes/-/pipelines/latest)
[![Coverage Report](https://gitlab.com/s.teumert/primes/badges/master/coverage.svg)](https://gitlab.com/s.teumert/primes/-/commits/master)
[![MIT License](https://user-content.gitlab-static.net/4ec3c3f7ab4f51eb26b9091872f65d29ed6d581f/68747470733a2f2f62616467656e2e6e65742f6769746c61622f6c6963656e73652f732e7465756d6572742f5072696d65733f636f6c6f723d707572706c65)](https://gitlab.com/s.teumert/primes/-/blob/master/LICENSE)

A Continuos Practices / DevOps tech demo for a modern, cloud based web application.

Featuring a single-page application (SPA) written in Aurelia and served via lighttpd
and a web API, written in DotNet Core 3.1 and Quarkus, deployed via docker containers.

The setup also demonstrates:

* Unit tests (with report generation and coverage tracking)
* [WIP] Integration tests
* Benchmarks
* [WIP] E2E tests
* [WIP] Load tests
* [WIP] Stress tests
* Docker Image Build
* [WIP] Docker image upload to registry

The Web API is provided either as .Net Core 3.1 project
or as native build with Quarkus + GraalVM.

# Usage

    $ git clone git@gitlab.com:s.teumert/primes.git && cd primes/
    $ pwsh build.ps1
    $ docker-compose up

# License

(The MIT License)

Copyright &copy; 2020 Sebastian Teumert &lt;https://sebastian.teumert.net&gt;

[See LICENSE](/LICENSE)

# .Net Core Web API

## Benchmarks (for Prime.Service)

In order to use `dotnet benchmark`,
you need to run `dotnet tool install -g BenchmarkDotNet.Tool`.

    $ git clone git@gitlab.com:s.teumert/primes.git && cd primes/
    $ cd web-api/
    $ dotnet build -C Release
    $ dotnet benchmark ./Prime.Service.Benchmarks/bin/Release/netstandard2.0/Prime.Service.Benchmarks.dll --filter * --runtimes net472 netcoreapp3.1 Mono

To change the artifact folder:

    $ git clone git@github.com:NetzwergX/Primes.git
    $ cd Primes/rest-api/
    $ dotnet benchmark ./Prime.Service.Benchmarks/bin/Release/netstandard2.0/Prime.Service.Benchmarks.dll --filter * --runtimes net472 netcoreapp3.1 Mono --artifacts="./path-to-artifact-folder/"

You can also run `dotnet tool restore`
and then use `dotnet dotnet-benchmark ...`

## Linting

### Prime.UI

Run `npx eslint ./src --ext .ts,.tsx --report-unused-disable-directives`
in `Prime.UI/`

#### VS Code

~~If you are using the project in VS Code and open the root folder, ESLint will
search the config files in the root folder. To properly run from `Prime.UI/`,
add `"eslint.workingDirectories" : ["Prime.UI/"]` to your `settings.json`
(for [Microsofts ESLint plugin](https://github.com/microsoft/vscode-eslint)).~~

This repo contains a workspace `settings.json` with the proper ESLint configuration.
