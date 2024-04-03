using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Running;

using RailwayResult.FunctionalExtensions.Benchmarks.Benchmarks;

var config = new ManualConfig();
config.AddColumnProvider([
	DefaultColumnProviders.Descriptor,
	DefaultColumnProviders.Statistics,
	DefaultColumnProviders.Metrics
]);
config.AddDiagnoser(new MemoryDiagnoser(new MemoryDiagnoserConfig(false)));
config.AddExporter(MarkdownExporter.GitHub);

BenchmarkRunner.Run<StatementBenchmark>(config);
