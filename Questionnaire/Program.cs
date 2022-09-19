using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using Questionnaire.DB;
using Questionnaire.Repositories;
using Questionnaire.Models;
using Questionnaire.Services;
using Questionnaire.Models.Dto;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddControllers().AddNewtonsoftJson(
    opt =>
    {
        opt.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.Objects;
        opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
    });


var cS = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING") ??
    "host=localhost;port=5432;database=test;username=postgres;password=abrakadabra77";

builder.Services
    .AddEntityFrameworkNpgsql()
    .AddDbContext<TestContext>(opt => opt.UseNpgsql(cS));

builder.Services.AddScoped<TestContext>();
builder.Services.AddScoped<BaseRepository<Test>, TestRepository>();
builder.Services.AddScoped<BaseRepository<TestResult>, TestResultRepository>();
builder.Services.AddScoped<BaseRepository<Answer>, AnswerRepository>();
builder.Services.AddScoped<BaseRepository<Question>, QuestionRepository>();
builder.Services.AddScoped<TestService>();
builder.Services.AddScoped<TestResultService>();
// Configure the HTTP request pipeline.

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

Prepare(app);

app.Run();


static void Prepare(IApplicationBuilder app)
{
    AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    using (var context = app.ApplicationServices.CreateScope())
    {
        var supportContext = context.ServiceProvider.GetService<TestContext>();
        supportContext.Database.Migrate();
    }

    CreateBaseTest(app);
}

static void CreateBaseTest(IApplicationBuilder app)
{
    var test = new TestDto()
    {
        Title = "��� � c#",
        Questions = new List<QuestionDto>
                {
                    new QuestionDto
                    {
                        Text = "����� ���������� ��������� ����������������?",
                        Answers = new List<AnswerDto>
                        {
                            new AnswerDto
                            {
                                Text = "��������������",
                                IsTrue = true,
                            },
                            new AnswerDto
                            {
                                Text = "��������������",
                                IsTrue=false
                            },
                            new AnswerDto
                            {
                                Text="��������-���������������",
                                IsTrue=true
                            },
                            new AnswerDto
                            {
                                Text = "����������",
                                IsTrue=false
                            }
                        }
                    },
                    new QuestionDto
                    {
                        Text = "�� ����� ��������� ������������ ���?",
                        Answers = new List<AnswerDto>
                        {
                            new AnswerDto
                            {
                                Text = "������������",
                                IsTrue = true,
                            },
                            new AnswerDto
                            {
                                Text = "������������",
                                IsTrue=true
                            },
                            new AnswerDto
                            {
                                Text="�����������",
                                IsTrue=true
                            },
                            new AnswerDto
                            {
                                Text = "��������",
                                IsTrue=false
                            }
                        }
                    },
                    new QuestionDto
                    {
                        Text = "����� ���������� ��������� ������� � c#?",
                        Answers = new List<AnswerDto>
                        {
                            new AnswerDto
                            {
                                Text = "public",
                                IsTrue = true,
                            },
                            new AnswerDto
                            {
                                Text = "private",
                                IsTrue=true
                            },
                            new AnswerDto
                            {
                                Text="protected",
                                IsTrue=true
                            },
                            new AnswerDto
                            {
                                Text = "intermediate",
                                IsTrue=false
                            }
                        }
                    },
                    new QuestionDto
                    {
                        Text = "����� ���� ������ ���������� � c#?",
                        Answers = new List<AnswerDto>
                        {
                            new AnswerDto
                            {
                                Text = "���� ��������",
                                IsTrue = true,
                            },
                            new AnswerDto
                            {
                                Text = "����������� ����",
                                IsTrue=true
                            },
                            new AnswerDto
                            {
                                Text="��������� ����",
                                IsTrue=true
                            }
                        }
                    },

                }
    };


    using (var context = app.ApplicationServices.CreateScope())
    {
        var testService = context.ServiceProvider.GetService<TestService>();
        if(!testService.GetTestsAsync().Result.Any())
            testService.InsertTestAsync(test).Wait();
    }
}