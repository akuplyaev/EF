using Codefirst.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Codefirst.Controllers {
    public class TasksController : ApiController {
        ProjectContext db = new ProjectContext();
        // GET: api/Tasks
        public IEnumerable GetGrouped() {

            //string query = "Select Projects.NameProject,Tasks.Deadline,temp.counttasks from (Select Deadline,Count(GuidId) as counttasks   from Tasks group by Deadline) temp INNER JOIN Tasks on temp.Deadline=Tasks.Deadline INNER JOIN Projects on Projects.Id=Tasks.ProjectId order by NameProject";
            var res1 = from tasks in db.Tasks
                       group tasks by tasks.Deadline into temp
                       join task in db.Tasks on temp.Key equals task.Deadline into jo
                       from rr in jo.DefaultIfEmpty()
                       select new { name = rr.Project.NameProject, deadline = rr.Deadline, counttasks = jo.Count() };

            return res1;
        }


    }
}
