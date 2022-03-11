
using FD.ShortUrl.Domain;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddOptions<PositionOption>()
            .Bind(builder.Configuration.GetSection(PositionOption.PositionOptions))
            .ValidateDataAnnotations()
            .Validate(config =>
            {
                if (config.Value != 0)
                {
                    return config.Value > config.Value2;
                }

                return true;
            }, "Key3 must be > than Key2.");   // Failure message.;

builder.Services.AddSingleton<IValidateOptions<PositionOption>, MyConfigValidation>();

var app = builder.Build();
app.MapControllers();
await app.RunAsync();
