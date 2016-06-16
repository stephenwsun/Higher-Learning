namespace HigherLearningApp.Controllers {

    export class ComputersController {

        public projects;

        constructor(private projectServices: HigherLearningApp.Services.ProjectServices) {
            this.getProjects();
        }

        getProjects() {
            this.projects = this.projectServices.getUserProjects();
        }

    }




}