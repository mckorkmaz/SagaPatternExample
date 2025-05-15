var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.SagaPattern_OrderService>("sagapattern-orderservice");

builder.Build().Run();
