namespace Codefirst.Models
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    public class ProjectContext : DbContext
    {

        public ProjectContext()
            : base("name=ProjectContext")
        {
        }
        public  DbSet<Project> Projects { get; set; }
        public  DbSet<Task> Tasks { get; set; }
        public  DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Task>()
                .HasMany(task=>task.Tags).
                 WithMany(tag=>tag.Tasks).
                 Map( m=>
                 {                   
                    m.MapLeftKey("TaskId");
                    m.MapRightKey("TagId");
                    m.ToTable("TaskTag");
                 });
            
        }
    }
    public class DbInitializer : DropCreateDatabaseIfModelChanges<ProjectContext>
    {
        protected override void Seed(ProjectContext db)
        {
            Project pr1 = new Project() { NameProject = "test1" };
            Project pr2 = new Project() { NameProject = "test2" };
            Project pr3 = new Project() { NameProject = "test3" };
            Task t1 = new Task() { Title = "task1", Deadline = DateTime.Now, Mark = true, Project = pr1 };
            Task t2 = new Task() { Title = "task2", Deadline = DateTime.Now, Mark = true, Project = pr2 };
            Task t3 = new Task() { Title = "task3", Deadline = DateTime.Now, Mark = true, Project = pr2 };
            Task t4 = new Task() { Title = "task4", Deadline = DateTime.Now, Mark = true, Project = pr3 };
            Task t5 = new Task() { Title = "task5", Deadline = DateTime.Now, Mark = true, Project = pr3 };
            Task t6 = new Task() { Title = "task6", Deadline = DateTime.Now, Mark = true, Project = pr3 };
            Tag tag1 = new Tag { NameTag = "tag1", Tasks = new HashSet<Task> { t2, t3, t6 } };
            Tag tag2 = new Tag { NameTag = "tag2", Tasks = new HashSet<Task> { t3 } };
            Tag tag3 = new Tag { NameTag = "tag3", Tasks = new HashSet<Task> { t1, t2, t3, t5, t6 } };
            db.Projects.AddRange(new HashSet<Project> { pr1, pr2, pr3 });
            db.Tasks.AddRange(new HashSet<Task> { t1, t2, t3, t4, t5, t6 });
            db.Tags.AddRange(new HashSet<Tag> { tag1, tag2, tag3 });
            db.SaveChanges();
            base.Seed(db);
        }
    }

}