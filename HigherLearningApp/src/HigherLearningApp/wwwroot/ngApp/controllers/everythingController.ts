namespace HigherLearningApp.Controllers {

    export class AdminEverythingController {

        public projects;

        constructor(private projectServices: HigherLearningApp.Services.ProjectServices) {
            this.getProjects();
        }

        getProjects() {
            this.projects = this.projectServices.getAllProjects();
        }
    }

    export class UserEverythingController {

        public projects;

        constructor(private projectServices: HigherLearningApp.Services.ProjectServices) {
            this.getProjects();
        }

        getProjects() {
            this.projects = this.projectServices.getUserProjects();
        }
    }

    export class EverythingController {

        public projects;

        constructor(private projectServices: HigherLearningApp.Services.ProjectServices) {
            this.getProjects();
        }

        getProjects() {
            this.projects = this.projectServices.getActiveProjects();
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
                let element: any = document.getElementById("commentForm");
                element.reset();
            });
        }

        cancel() {
            this.$state.go('everything');
        }
    }

    export class ProjectCreateController {

        public project;
        public file;

        constructor(private projectServices: HigherLearningApp.Services.ProjectServices, private $state: angular.ui.IStateService, private filepickerService: any, private $scope: ng.IScope) {

        }

        saveProject() {
            this.projectServices.saveProject(this.project).then(() => {
                this.$state.go('everything');
            });
        }

        cancel() {
            this.$state.go('everything');
        }

        // Filestack code
        public pickFile() {
            this.filepickerService.pick({
                mimetype: 'image/*'
            }, this.fileUploaded.bind(this));
        }

        public fileUploaded(file) {
            this.file = file;
            console.log(this.file);

            // generally you want to put your code here that will send the url info to the database


            this.$scope.$apply();   //all this does is re-calls the controller (refresh)
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

        cancel() {
            this.$state.go('everything');
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