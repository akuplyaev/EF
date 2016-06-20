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
            var projecttasks = await (from task in db.Tasks

                                      select new { Name = task.Project.NameProject, Tasks = task.Title }).ToListAsync();

            return Ok(projecttasks);
        }


        [Route("api/projects/simple")]
        public IQueryable GetSimple()
        {
            var res = db.Tasks.Select(p => new
            {
                Name = p.Title,

                Company = p.Project.NameProject
            });



            var res1 = from projects in db.Projects
                       group projects by projects.Tasks into g
                       select new { Name = g.Key, countTask = g.Count() };
            return res;
        }

    }
}


