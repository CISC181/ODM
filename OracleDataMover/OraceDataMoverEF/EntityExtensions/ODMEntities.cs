using Eca.Common;
using OracleDataMoverEF.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Validation;

namespace OracleDataMoverEF.EF
{
    public partial class ODMEntities : IODMEntities
    {
        public string LoggedInUserId { get; set; }

        public virtual bool ObjectChanges()
        {
            return this.ChangeTracker.Entries<Entity>().Count(p => p.State == EntityState.Added
               || p.State == EntityState.Modified || p.State == EntityState.Deleted) > 0;
        }
        public virtual bool ObjectIsNew<TEntity>(TEntity anObject) where TEntity : class
        {
            return !this.ChangeTracker.Entries<TEntity>().Any(x => x.Entity == anObject);
        }


        public override int SaveChanges()
        {
            var addedAuditedEntities = ChangeTracker.Entries<Entity>()
              .Where(p => p.State == EntityState.Added)
              .Select(p => p.Entity);
            var modifiedAuditedEntities = ChangeTracker.Entries<Entity>()
              .Where(p => p.State == EntityState.Modified)
              .Select(p => p.Entity);
            var allEntities = new List<Entity>();
            var now = DateTime.UtcNow;
            foreach (var added in addedAuditedEntities)
            {
                if (string.IsNullOrEmpty(added.Id))
                    added.Id = new Guid().ToString();
                added.UpdatedDate = now;
                added.UpdatedById = this.LoggedInUserId;
                added.CreatedDate = now;
                added.CreatedById = this.LoggedInUserId;
                allEntities.Add(added);
            }
            foreach (var modified in modifiedAuditedEntities)
            {
                modified.UpdatedById = this.LoggedInUserId;
                modified.UpdatedDate = now;
                allEntities.Add(modified);
            }
            int count = 0;
            try
            {
                count = base.SaveChanges();
            }

            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        string errorText = eve.Entry.Entity.GetType().Name.ToString() + " " + eve.Entry.State.ToString()
                            + " " + ve.PropertyName + " " + ve.ErrorMessage;
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
            return count;
        }
    }
}
