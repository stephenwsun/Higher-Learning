﻿namespace HigherLearningApp.Controllers {

    export class EmbeddedSystemsController {

        public projects;

        constructor(private projectServices: HigherLearningApp.Services.ProjectServices) {
            this.getProjects();
        }

        getProjects() {
            this.projects = this.projectServices.getActiveProjects().then((data) => {
                console.log(data);
                this.projects = data;
            });
        }

    }




}