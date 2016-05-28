namespace HigherLearningApp.Controllers {

    export class HomeController {
        public message = 'Hello from the Home page!';
    }


    export class SecretController {
        public secrets;

        constructor($http: ng.IHttpService) {
            $http.get('/api/secrets').then((results) => {
                this.secrets = results.data;
            });
        }
    }


    export class AboutController {
        public message = 'Hello from the About page!';
    }

}
