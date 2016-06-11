namespace HigherLearningApp.Services {

    export class ProjectServices {

        private projectResource;
        private commentResource;

        constructor($resource: angular.resource.IResourceService) {
            this.projectResource = $resource("/api/project/:id", null,
                {
                    vote: { method: "PUT" }
                });
            this.commentResource = $resource("/api/comment/:id");
        }

        // Vote Functionality

        voteProject(projectId, voteValue) {
            return this.projectResource.vote({ id: projectId }, voteValue);
        }

        // CRUD - Create

        //createProject() {

        //}

        // CRUD - Read

        getProjects() {
            return this.projectResource.query();
        }

        getProject(projectId) {
            return this.projectResource.get({ id: projectId });
        }

        // CRUD - Update

        saveProject(project) {
            return this.projectResource.save(project).$promise;
        }

        saveComment(projectId, comment) {
            return this.commentResource.save({ id: projectId }, comment).$promise;
        }

        // CRUD - Delete

        deleteProject(projectId) {
            return this.projectResource.delete({ id: projectId }).$promise;
        }
    }


    angular.module('HigherLearningApp').service('projectServices', ProjectServices);

}