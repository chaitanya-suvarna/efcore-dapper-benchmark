# efcore-dapper-benchmark
A project that I have created to benchmark the read/write performance of EFCore vs Dapper

Find more details at my bolg : https://chaitanyasuvarna.wordpress.com/2021/06/28/using-dapper-over-entityframework/

To run this benchmark on your local machine first **clone this repo locally**

Install EF Core (skip if already installed)
-------------------------------------------------------
Ensure you have efcore installed in your machine. If not, run the below command using **package manager console**

```bash
dotnet tool install --global dotnet-ef
```

Run EF migrations
------------------
Run migrations on you localdb by running the below command in you **package manager console**

```bash
dotnet ef database update --project BenchmarkEFCoreDapper.Data
```

Run benchmark
------------------
Navigate to the folder where you have cloned this repo locally. Nabigate to `\efcore-dapper-benchmark\BenchmarkEFCoreDapper\BenchmarkEFCoreDapper` and run the below command to start the benchmark and wait for it to complete to see the benchmark summary.

```bash
dotnet run -p BenchmarkEFCoreDapper.csproj -c Release
```
