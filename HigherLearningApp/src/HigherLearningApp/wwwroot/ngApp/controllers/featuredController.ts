namespace HigherLearningApp.Controllers {


    export class FeaturedController {

        public projects;

        constructor(private projectServices: HigherLearningApp.Services.ProjectServices) {
            this.getProjects();
        }

        getProjects() {
            this.projects = this.projectServices.getUserProjects();
        }
    }




}