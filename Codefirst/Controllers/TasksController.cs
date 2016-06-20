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
            //var res1 = from tasks in db.Tasks
            //           group tasks by tasks.Deadline into grouped
            //           join task in db.Tasks on grouped.Key equals task.Deadline
            //           select new {nameproject= task.Project.NameProject, Deadline = grouped.Key,cout = grouped.Count() };
            var res = from tasks in db.Tasks
                      group tasks by new { tasks.Deadline, tasks.Project } into grouped
                      select new { NameProject = grouped.Key.Project.NameProject, Deadline = grouped.Key.Deadline, TaskCount = grouped.Count() };                                 
            return res;
        }
        // POST: api/Tasks
        public int Post([FromBody]Task task)
        {
            db.Tasks.Add(task);
            db.SaveChanges();
            return task.TaskId;
        }
        // PUT: api/Tasks
        public bool Put(int id, [FromBody]Task task)
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
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
