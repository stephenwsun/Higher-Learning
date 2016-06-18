namespace HigherLearningApp.Controllers {

    export class WebDevelopmentController {

        public projects;

        constructor(private projectServices: HigherLearningApp.Services.ProjectServices) {
            this.getProjects();
        }

        getProjects() {
            this.projects = this.projectServices.getActiveProjects();
        }

    }




}