var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.SagaPattern_OrderService>("sagapattern-orderservice");

builder.AddProject<Projects.SagaPattern_Payment>("sagapattern-payment");

builder.Build().Run();
