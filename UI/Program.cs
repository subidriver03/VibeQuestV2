using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using VibeQuest.Core.Interfaces;
using VibeQuest.Infrastructure.Data;
using VibeQuest.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=vibequest.db"));

builder.Services.AddScoped<IProfileService, ProfileService>();
builder.Services.AddScoped<IQuestService, QuestService>();
builder.Services.AddScoped<IJournalService, JournalService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();
app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/Host");

app.Run();
