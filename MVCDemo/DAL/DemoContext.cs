using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using MVCDemo.Domain;
using System.Data.Entity.Validation;
using MVCDemo.Common;

namespace MVCDemo.DAL
{
    public class DemoContext : DbContext
    {
        public DemoContext()
            : base("name=DBConnectionString")
        {
            Database.SetInitializer<DemoContext>(new DemoDBInitializer<DemoContext>());
        }
        public DbSet<Member> Members { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<State> States { get; set; }

        public User User { get; set; }

        internal void Save()
        {
            try
            {
                var changeSet = ChangeTracker.Entries<BaseDomain>();
                if (changeSet != null)
                {
                    foreach (var entry in changeSet.Where(c => c.State != EntityState.Unchanged))
                    {
                        entry.Entity.UpdateDateTime = DateTime.Now;
                        entry.Entity.UpdatedBy = User.UserID;
                        if (entry.State == EntityState.Added)
                        {
                            entry.Entity.CreateDateTime = DateTime.Now;
                            entry.Entity.CreatedBy = User.UserID;
                        }
                    }
                }
                this.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {

                var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);
                var fullErrorMessage = string.Join("; ", errorMessages);

                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }

        }
    }
}