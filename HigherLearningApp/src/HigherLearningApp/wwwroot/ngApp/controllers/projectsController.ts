namespace HigherLearningApp.Controllers {

    export class ProjectsController {
        //public message = 'Hello from the Projects page!';

        public projects;

        constructor(private projectServices: HigherLearningApp.Services.ProjectServices) {
            this.getProjects();
        }

        getProjects() {
            this.projects = this.projectServices.getProjects();
        }
    }

    export class ProjectDetailsController {

        public projectId;
        public project;
        public comment;

        constructor(private projectServices: HigherLearningApp.Services.ProjectServices, private $state: angular.ui.IStateService, $stateParams: angular.ui.IStateParamsService) {
            this.projectId = $stateParams['id'];
            this.getProject();
        }

        getProject() {
            this.project = this.projectServices.getProject(this.projectId);
        }

        saveComment() {
            this.projectServices.saveComment(this.projectId, this.comment).then(() => {
                this.getProject();
                let element: any = document.getElementById('commentForm');
                element.reset();
            });
        }

        cancel() {
            this.$state.go('everything');
        }
    }

    export class ProjectCreateController {

        public project;

        constructor(private projectServices: HigherLearningApp.Services.ProjectServices, private $state: angular.ui.IStateService) {

        }

        saveProject() {
            this.projectServices.saveProject(this.project).then(() => {
                this.$state.go('everything');
            });
        }

        cancel() {
            this.$state.go('everything');
        }
    }

    export class ProjectEditController {

        public project;
        private projectId;

        constructor(private projectServices: HigherLearningApp.Services.ProjectServices, private $state: angular.ui.IStateService, $stateParams: angular.ui.IStateParamsService) {
            this.projectId = $stateParams['id'];
            this.getProject();
        }

        getProject() {
            this.project = this.projectServices.getProject(this.projectId);
        }

        saveProject() {
            this.projectServices.saveProject(this.project).then(() => {
                this.$state.go('everything').catch((data) => {
                    console.log(data);
                });
            });
        }
    }

    export class ProjectDeleteController {

        public project;
        private projectId;

        constructor(private projectServices: HigherLearningApp.Services.ProjectServices, private $state: angular.ui.IStateService, $stateParams: angular.ui.IStateParamsService) {
            this.projectId = $stateParams['id'];
            this.getProject();
        }

        getProject() {
            this.project = this.projectServices.getProject(this.projectId);
        }

        deleteProject() {
            this.projectServices.deleteProject(this.projectId).then(() => {
                this.$state.go('everything');
            });
        }

        cancel() {
            this.$state.go('everything');
        }
    }
}