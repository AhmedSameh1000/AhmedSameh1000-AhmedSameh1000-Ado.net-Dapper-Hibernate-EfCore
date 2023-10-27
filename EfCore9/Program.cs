using EfCore8.Data;
using EfCore8.Entities;
using Microsoft.EntityFrameworkCore;

namespace EfCore9
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            using var Context = new AppDbContext();
            await Context.Database.EnsureCreatedAsync();

            if(!await Context.Offices.AnyAsync()) 
                Context.Offices.AddRange(SeedingData.LoadOffices());

            if (!await Context.Students.AnyAsync())
                Context.Students.AddRange(SeedingData.LoadStudent());

            if (!await Context.Set<Course>().AnyAsync())
                Context.Set<Course>().AddRange(SeedingData.LoadCourses());

            if (!await Context.Set<Schedule>().AnyAsync())
                Context.Set<Schedule>().AddRange(SeedingData.LoadSchaduels());


            if (!await Context.Set<Instructor>().AnyAsync())
                Context.Set<Instructor>().AddRange(SeedingData.LoadInstractor());


            if (!await Context.Set<Section>().AnyAsync())
                Context.Set<Section>().AddRange(SeedingData.LoadSection());

            await Context.SaveChangesAsync();

        }
    }
}