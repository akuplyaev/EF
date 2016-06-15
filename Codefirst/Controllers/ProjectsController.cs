using Codefirst.Models;
using System.Collections;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace Codefirst.Controllers {
    public class ProjectsController:ApiController {
        ProjectContext db = new ProjectContext();

        
        public async Task<IHttpActionResult> Get() {
            //var project = await (from b in db.Projects                            
            //                 select b.NameProject).ToListAsync();
            //var task = await (from b in db.Tasks
            //                     select b.Title).ToListAsync();
            var projecttasks = await (from projeect in db.Projects
                            join
                            tasks in db.Tasks on projeect.Id equals tasks.ProjectId
                            select new { Name = projeect.NameProject, tasks.Title }).ToListAsync();
            
            return Ok(projecttasks);
        }

        
        [Route("api/projects/simple")]
        public IQueryable GetSimple() {
            var res = from projects in db.Projects
                      join tasks in db.Tasks on projects equals tasks.Project
                      into projectTask
                      select new { ProjectsName = projects.NameProject, TasksCount = projectTask.Count()                      
                      };
            return res;  
        }

    }
}


