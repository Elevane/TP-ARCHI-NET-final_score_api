
using Microsoft.EntityFrameworkCore;
using tp_final_score_api.Extensions;
using tp_final_score_api.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddAppServices();
builder.Services.AddApplication(builder.Configuration);
builder.Services.AddDbContext<ScoreContext>(options => options.UseSqlServer(builder.Configuration["db"]));

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
