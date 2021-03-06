﻿using Codefirst.Models;
using System.Collections;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace Codefirst.Controllers
{
    public class ProjectsController : ApiController
    {
        ProjectContext db = new ProjectContext();


        public async Task<IHttpActionResult> Get()
        {            
            var projecttasks = await (from task in db.Tasks
                                      select new { Name = task.Project.NameProject, Tasks = task.Title }).ToListAsync();
            return Ok(projecttasks);
        }


        [Route("api/projects/simple")]
        public IQueryable GetSimple()
        {         
            var res = from projects in db.Projects                       
                       select new { ProjectName =projects.NameProject , TaskCount = projects.Tasks.Count };            
            return res;
        }

    }
}


