using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.Test
{
    public class InMemoryDbContextFactory
    {
        public RepositoryContext GetRepositoryContext()
        {
            var options = new DbContextOptionsBuilder<RepositoryContext>()
                            .UseInMemoryDatabase(databaseName: "InMemoryDatabase")
                            .Options;
            var dbContext = new RepositoryContext(options);

            return dbContext;
        }
    }
}
