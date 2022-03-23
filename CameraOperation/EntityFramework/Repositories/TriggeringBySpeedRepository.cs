﻿using CameraOperation.Models;
using Microsoft.EntityFrameworkCore;
namespace CameraOperation.EntityFramework.Repositories
{
    public class TriggeringBySpeedRepository : IRepository<TriggeringBySpeed>
    {

        private readonly ICameraOperationContextFactory _factory;
        public TriggeringBySpeedRepository(ICameraOperationContextFactory factory)
        {
            _factory = factory;
        }
        public bool Create(TriggeringBySpeed data)
        {
            throw new NotImplementedException();
        }

        public bool Delete(TriggeringBySpeed data)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TriggeringBySpeed> Read()
        {
            using var context = _factory.Create();
            var triggers = context.TriggeringBySpeeds.Include(r => r.RuleOfSearchBySpeed).ToList();
            return triggers;
        }

        public bool Update(TriggeringBySpeed data)
        {
            throw new NotImplementedException();
        }
    }
}
