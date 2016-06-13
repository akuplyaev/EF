namespace Codefirst.Models {
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    public class ProjectContext : DbContext {
        
        public ProjectContext()
            : base("name=ProjectContext") {
        }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }
    public class DbInitializer : DropCreateDatabaseAlways<ProjectContext> {
        protected override void Seed(ProjectContext db) {
            Project pr1 = new Project() { NameProject = "test1" };
            Project pr2 = new Project() { NameProject = "test2" };
            Task t1 = new Task() { Title = "task1", Deadline = DateTime.Now, Mark = true, Project = pr1 };
            Task t2 = new Task() { Title = "task2", Deadline = DateTime.Now, Mark = true, Project = pr2 };
            Task t3 = new Task() { Title = "task3", Deadline = DateTime.Now, Mark = true, Project = pr2 };
            Tag tag1 = new Tag { NameTag = "tag1", Tasks = new List<Task> { t2, t3 } };
            Tag tag2 = new Tag { NameTag = "tag2", Tasks = new List<Task> { t3 } };
            Tag tag3 = new Tag { NameTag = "tag3", Tasks = new List<Task> { t1, t2, t3 } };
            db.Projects.AddRange(new List<Project> { pr1, pr2 });
            db.Tasks.AddRange(new List<Task> { t1, t2, t3 });
            db.Tags.AddRange(new List<Tag> { tag1, tag2, tag3 });
            db.SaveChanges();
            base.Seed(db);
        }
    }

}   