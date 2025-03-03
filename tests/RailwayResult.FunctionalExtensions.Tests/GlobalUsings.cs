global using Shouldly;

global using Xunit;

global using O = RailwayResult.FunctionalExtensions.Tests.Data.Obj;
global using RC = RailwayResult.Result<string?>;
global using R1 = RailwayResult.Result<RailwayResult.FunctionalExtensions.Tests.Data.Obj>;
global using R1N = RailwayResult.Result<RailwayResult.FunctionalExtensions.Tests.Data.Obj?>;
global using R2 = RailwayResult.Result<(RailwayResult.FunctionalExtensions.Tests.Data.Obj, RailwayResult.FunctionalExtensions.Tests.Data.Obj)>;
global using R2N = RailwayResult.Result<(RailwayResult.FunctionalExtensions.Tests.Data.Obj?, RailwayResult.FunctionalExtensions.Tests.Data.Obj?)>;
global using R3 = RailwayResult.Result<(RailwayResult.FunctionalExtensions.Tests.Data.Obj, RailwayResult.FunctionalExtensions.Tests.Data.Obj, RailwayResult.FunctionalExtensions.Tests.Data.Obj)>;
