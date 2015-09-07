
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using MVCDemo.Domain;


namespace MVCDemo.DAL
{
    public class DemoDBInitializer<T> : CreateDatabaseIfNotExists<DemoContext>
    {
        
        protected override void Seed(DemoContext demoContext)
        {            
            demoContext.States.AddRange(SeedData.GetStateList());           
            demoContext.Members.AddRange(SeedData.GetMemberList());

            var changeSet = demoContext.ChangeTracker.Entries<BaseDomain>();

            foreach (var entry in changeSet)
            {
                entry.Entity.UpdateDateTime = DateTime.Now;
                entry.Entity.UpdatedBy = demoContext.User.UserID;
                entry.Entity.CreateDateTime = DateTime.Now;
                entry.Entity.CreatedBy = demoContext.User.UserID;
            }


            base.Seed(demoContext);
        }
        
    }
}
