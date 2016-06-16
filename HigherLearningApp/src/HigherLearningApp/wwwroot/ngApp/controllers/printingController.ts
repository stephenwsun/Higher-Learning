namespace HigherLearningApp.Controllers {


    export class PrintingController {

        public projects;

        constructor(private projectServices: HigherLearningApp.Services.ProjectServices) {
            this.getProjects();
        }

        getProjects() {
            this.projects = this.projectServices.getUserProjects();
        }
    }




}