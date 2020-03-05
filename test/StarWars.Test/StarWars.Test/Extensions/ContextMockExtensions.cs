using Entities;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace StarWars.Test.Extensions
{
    public static class ContextMockExtensions
    {
        public static Mock<DbSet<TEntity>> MockDbSet<TContext, TEntity>(this Mock<TContext> contextMock, Expression<Func<TContext, DbSet<TEntity>>> dbSet, IQueryable<TEntity> mockedEntities)
            where TEntity : class
            where TContext : class
        {
            Mock<DbSet<TEntity>> dbSetMock = new Mock<DbSet<TEntity>>();

            dbSetMock.As<IQueryable<TEntity>>().Setup(p => p.Expression)
                .Returns(mockedEntities.Expression);

            dbSetMock.As<IQueryable<TEntity>>().Setup(m => m.GetEnumerator())
                .Returns(mockedEntities.GetEnumerator());

            contextMock.Setup(dbSet)
                .Returns(dbSetMock.Object);


            return dbSetMock;
        }
    }
}
