using ApiLogin.DDD.Infraestructure.Configuration.Connection;
using ApiLogin.DDD.Transversal.AutoMapper.AutoMapper;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region [Services]

#region [AddRegistration]
builder.Services.AddSingleton<IConnectionFactory, ConnectionFactory>();
builder.Services.AddSingleton<IConnectionFactory, ConnectionFactory>();
#endregion

#region [Log]
builder.Services.AddLogging(l =>
{
    //l.SetMinimumLevel(LogLevel.Information);
    //l.AddNLog("Log/NLog.config");

});
#endregion

#region [Cors]

string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(MyAllowSpecificOrigins,
                      builder =>
                      {
                          builder.AllowAnyOrigin()
                                 .AllowAnyHeader()
                                 .AllowAnyMethod();
                      });
});
#endregion

#region [Swagger]
builder.Services.AddSwaggerGen(options =>
{
    var groupName = "v1";

    options.SwaggerDoc(groupName, new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = $"API Seguridad {groupName}",
        Version = groupName,
        Description = "API Seguridad",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact
        {
            Name = "API Seguridad",
            Email = string.Empty,
            Url = new System.Uri("https://foo.com/"),
        }
    });
});
#endregion

#region [Jwt]
builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = builder.Configuration["Jwt:IssuerToken"],
                    ValidAudience = builder.Configuration["Jwt:audienceToken"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
                    ClockSkew = TimeSpan.Zero
                };
            });
#endregion

#region [AutoMapper]
//Mapper
var mapperConfig = new MapperConfiguration(m =>
{
    m.AddProfile(new MapperProfile());
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);
#endregion

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
