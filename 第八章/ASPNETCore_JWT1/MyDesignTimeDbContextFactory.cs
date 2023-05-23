using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

class MyDesignTimeDbContextFactory : IDesignTimeDbContextFactory<IdDbContext>
{
    public IdDbContext CreateDbContext(string[] args)
    {
        DbContextOptionsBuilder<IdDbContext> builder = new();
        string connStrMySql = "server=localhost;port=3306;database=jwtdemo;uid=root;pwd=alpha.netcore;charset=utf8;allow zero datetime=True;pooling=true;max pool size=512;sslmode=none;allow user variables=True;treattinyasboolean=false";
        builder.UseMySql(connStrMySql, MySqlServerVersion.Parse("5.6.20-mysql"));
        return new IdDbContext(builder.Options);
    }
}