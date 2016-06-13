using Codefirst.Models;
using System.Collections;
using System.Linq;
using System.Web.Http;

namespace Codefirst.Controllers {
    public class ProjectsController:ApiController {
        ProjectContext db = new ProjectContext();


        public Project Get() {
            var project = new Project() { Id=123,NameProject = "tets1321" };

            return project;
        }

        [Route("all")]
        [Route("~/api/application/")]
        public int GetSimple() {
            int t = db.Projects.Count();
            
            return t;  
        }

    }
}