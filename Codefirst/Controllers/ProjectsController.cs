using Codefirst.Models;
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
            //var project = await (from b in db.Projects                            
            //                 select b.NameProject).ToListAsync();
            //var task = await (from b in db.Tasks
            //                     select b.Title).ToListAsync();
            var projecttasks = await (from task in db.Tasks
                                      select new { Name = task.Project.NameProject, Tasks = task.Title }).ToListAsync();
            return Ok(projecttasks);
        }


        [Route("api/projects/simple")]
        public IQueryable GetSimple()
        {         
            var res = from task in db.Tasks
                       group task by task.Project.NameProject into g 
                       select new { Name =g.Key , countTask = g.Count() };
            return res;
        }

    }
}


