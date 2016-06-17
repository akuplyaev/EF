using Codefirst.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Codefirst.Controllers
{
    public class TasksController : ApiController
    {
        ProjectContext db = new ProjectContext();
        // GET: api/Tasks
        public IEnumerable GetGrouped()
        {
            //имя срок общее количество задач для срока
            //string query = "Select Projects.NameProject,Tasks.Deadline,temp.counttasks from (Select Deadline,Count(GuidId) as counttasks   from Tasks group by Deadline) temp INNER JOIN Tasks on temp.Deadline=Tasks.Deadline INNER JOIN Projects on Projects.Id=Tasks.ProjectId order by NameProject";
            var res1 = from tasks in db.Tasks
                       group tasks by tasks.Deadline into temp
                       join task in db.Tasks on temp.Key equals task.Deadline into jo
                       from rr in jo.DefaultIfEmpty()
                       select new { name = rr.Project.NameProject, deadline = rr.Deadline, counttasks = jo.Count() };
            // имя проекта срок количество задач для проекта с таким сроком
            var res2 = from tasks in db.Tasks
                       join projects in db.Projects on tasks.ProjectId equals projects.Id into jo
                       from re in jo.DefaultIfEmpty()
                       group new { tasks, jo } by new { tasks.Deadline, re.NameProject } into temp
                       select new { name = temp.Key.NameProject, dealine = temp.Key.Deadline, counttask = temp.Count() };

            return res2;
        }
        // POST: api/Tasks
        public int Post([FromBody]Task task)
        {
            db.Tasks.Add(task);
            db.SaveChanges();
            return task.Id;
        }
        // PUT: api/Tasks
        public int Put(int id, [FromBody]Task task)
        {
            var entity = db.Tasks.Find(id);
            db.SaveChanges();
            if (entity != null)
            {
                entity.Title = task.Title;
                entity.Deadline = task.Deadline;
                entity.Mark = task.Mark;
                entity.Description = task.Description;
                entity.ProjectId = task.ProjectId;
                db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
