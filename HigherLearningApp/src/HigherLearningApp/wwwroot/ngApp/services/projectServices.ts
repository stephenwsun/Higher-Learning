namespace HigherLearningApp.Services {

    export class ProjectServices {

        private projectResource;
        private commentResource;
        private imageResource;

        constructor($resource: angular.resource.IResourceService) {
            this.projectResource = $resource('/api/project/:id', null, {
                vote: {
                    method: 'PUT'
                },
                getAllProjects: {
                    method: 'GET',
                    url: '/api/project/getallprojects',
                    isArray: true
                },
                getUserProjects: {
                    method: 'GET',
                    url: '/api/project/getuserprojects',
                    isArray: true
                },
                getActiveProjects: {
                    method: 'GET',
                    url: '/api/project/getactiveprojects',
                    isArray: true
                }
            });
            this.commentResource = $resource("/api/comment/:id");
            this.imageResource = $resource("/api/image/:id");
        }

        // Vote Functionality

        voteProject(projectId, voteValue) {
            return this.projectResource.vote({ id: projectId }, voteValue);
        }

        // CRUD - Read

        getAllProjects() {
            return this.projectResource.getAllProjects();
        }

        getUserProjects() {
            return this.projectResource.getUserProjects();
        }

        getActiveProjects() {
            return this.projectResource.getActiveProjects();
        }

        getProject(projectId) {
            return this.projectResource.get({ id: projectId });
        }

        // CRUD - Create/Update

        saveProject(project) {
            return this.projectResource.save(project).$promise;
        }

        saveComment(projectId, comment) {
            return this.commentResource.save({ id: projectId }, comment).$promise;
        }

        saveImage(projectId, image) {
            return this.imageResource.save({ id: projectId }, image).$promise;
        }

        createImage(image) {
            return this.imageResource.save(image).$promise;
        }

        // CRUD - Delete

        deleteProject(projectId) {
            return this.projectResource.delete({ id: projectId }).$promise;
        }
    }


    angular.module('HigherLearningApp').service('projectServices', ProjectServices);

}