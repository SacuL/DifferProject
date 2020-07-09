using Differ.Domain.Interfaces;
using Differ.Domain.Models;
using Differ.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Differ.Infra.Data.Repository
{
    public class DiffRepository : IDiffRepository
    {
        protected readonly DifferContext Db;
        protected readonly DbSet<Diff> DbSet;

        public DiffRepository(DifferContext context)
        {
            Db = context;
            DbSet = Db.Set<Diff>();
        }

        public async Task<Diff> GetById(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<Diff> Add(Diff diff)
        {
            DbSet.Add(diff);
            await Db.SaveChangesAsync();
            return diff;
        }

        public async Task<Diff> Update(Diff diff)
        {
            Db.Update(diff);
            await Db.SaveChangesAsync();
            return diff;
        }
    }
}