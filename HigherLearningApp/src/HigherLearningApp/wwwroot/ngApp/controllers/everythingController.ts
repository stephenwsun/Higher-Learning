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
            this.projectServices.getActiveProjects().then((data) => {
                console.log(data);
                this.projects = data;
            });
        }
    }

    export class ProjectDetailsController {

        public projectId;
        public project;
        public comment;
        public file;
        
        constructor(private projectServices: HigherLearningApp.Services.ProjectServices, private $state: angular.ui.IStateService, $stateParams: angular.ui.IStateParamsService, private filepickerService: any, private $scope: ng.IScope) {
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

        saveImage() {
            this.projectServices.saveImage(this.projectId, this.file).then(() => {
                let element: any = document.getElementById("image");
                element.reset();
            });
        }

        voteProjectUp() {
            this.projectServices.voteProject(this.projectId, 1);
            this.getProject();
            let element: any = document.getElementById("vote");
            element.reset();
        }

        voteProjectDown() {
            this.projectServices.voteProject(this.projectId, 0);
            this.getProject();
            let element: any = document.getElementById("vote");
            element.reset();
        }

        // Filepicker code
        public pickFile() {
            this.filepickerService.pick({
                mimetype: 'image/*'
            }, this.fileUploaded.bind(this));
        }

        public fileUploaded(file) {
            this.file = file;
            console.log(this.file);
            console.log(this.projectId);
            console.log(this.file.url);        

            if (this.file.url != null) {
                // generally you want to put your code here that will send the url info to the database
                this.projectServices.saveImage(this.projectId, this.file).then(() => {
                    this.getProject();
                });
                console.log("url sent");
            }
            else {
                console.log("nothing to send");
            }

            this.$scope.$apply();   //all this does is re-calls the controller (refresh)
        }

        cancel() {
            this.$state.go('everything');
        }
    }

    export class ProjectCreateController {

        public projectId;
        public project;
        public file;

        constructor(private projectServices: HigherLearningApp.Services.ProjectServices, private $state: angular.ui.IStateService, $stateParams: angular.ui.IStateParamsService, private filepickerService: any, private $scope: ng.IScope) {
            if ($stateParams) {
                this.projectId = $stateParams['id'];
            }
        }

        saveProject() {
            this.projectServices.saveProject(this.project).then((data) => {
                console.log(data);
                console.log(data.id);
                this.projectId = data.id;
                this.$state.go('projectImages', { id: this.projectId });
            });
        }

        // Filepicker code
        public pickFile() {
            this.filepickerService.pick({
                mimetype: 'image/*'
            }, this.fileUploaded.bind(this));
        }

        public fileUploaded(file) {
            this.file = file;
            console.log(this.file);
            console.log(this.projectId);
            this.projectServices.saveImage(this.projectId, this.file);

            this.$scope.$apply();
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