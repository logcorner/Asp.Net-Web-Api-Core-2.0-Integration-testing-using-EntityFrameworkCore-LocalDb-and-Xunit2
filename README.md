# Asp.Net-Web-Api-Core-2.0-Integration-testing-using-EntityFrameworkCore-LocalDb-and-Xunit2
# To migrate JW from asp.net core 1.x to asp.net core 2.0 proceed as follows
# 1. Go to project properties and choose .NET Core 2.0 as TargetFramework
# 2. open ConfigureServices of startup.cs file and paste this line of code :
  
            services.AddIdentity<MyUser, MyRole>().AddEntityFrameworkStores<SecurityContext>();
            services.AddAuthentication((cfg =>
            {
                cfg.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                cfg.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = Configuration["JwtSecurityToken:Issuer"],
                    ValidAudience = Configuration["JwtSecurityToken:Audience"],
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtSecurityToken:Key"])),
                    ValidateLifetime = true
                };
            });
  # 3. open Configure of Startup.cs class and remove this lines of code :
    app.UseJwtBearerAuthentication(.................)
    and app.UseIdentity()
  # 4 . paste this line of code 
       app.UseAuthentication();
