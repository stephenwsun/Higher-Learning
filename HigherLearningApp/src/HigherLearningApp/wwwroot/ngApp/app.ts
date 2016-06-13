namespace HigherLearningApp {

    angular.module('HigherLearningApp', ['ui.router', 'ngResource', 'ui.bootstrap', 'angular-filepicker', 'textAngular']).config((
        $stateProvider: ng.ui.IStateProvider,
        $urlRouterProvider: ng.ui.IUrlRouterProvider,
        $locationProvider: ng.ILocationProvider,
        filepickerProvider
    ) => {

        // Filestack API key
        filepickerProvider.setKey('	A6kptWpyQQ9KdU6rI9TkBz');

        // Define routes
        $stateProvider
            .state('home', {
                url: '/',
                templateUrl: '/ngApp/views/home.html',
                controller: HigherLearningApp.Controllers.HomeController,
                controllerAs: 'controller'
            })
            .state('secret', {
                url: '/secret',
                templateUrl: '/ngApp/views/secret.html',
                controller: HigherLearningApp.Controllers.SecretController,
                controllerAs: 'controller'
            })
            .state('login', {
                url: '/login',
                templateUrl: '/ngApp/views/login.html',
                controller: HigherLearningApp.Controllers.LoginController,
                controllerAs: 'controller'
            })
            .state('register', {
                url: '/register',
                templateUrl: '/ngApp/views/register.html',
                controller: HigherLearningApp.Controllers.RegisterController,
                controllerAs: 'controller'
            })
            .state('externalRegister', {
                url: '/externalRegister',
                templateUrl: '/ngApp/views/externalRegister.html',
                controller: HigherLearningApp.Controllers.ExternalRegisterController,
                controllerAs: 'controller'
            }) 
            .state('projects', {
                url: '/projects',
                templateUrl: '/ngApp/views/projects.html',
                controller: HigherLearningApp.Controllers.ProjectsController,
                controllerAs: 'controller'
            })

            //-----------------------Project Creation for Users-----------------------//
            .state('projectDetails', {
                url: '/projects/details/:id',
                templateUrl: '/ngApp/views/projectDetails.html',
                controller: HigherLearningApp.Controllers.ProjectDetailsController,
                controllerAs: 'controller'
            })
            .state('projectCreate', {
                url: '/projects/create',
                templateUrl: '/ngApp/views/projectCreate.html',
                controller: HigherLearningApp.Controllers.ProjectCreateController,
                controllerAs: 'controller'
            })
            .state('projectDelete', {
                url: '/projects/delete/:id',
                templateUrl: '/ngApp/views/projectDelete.html',
                controller: HigherLearningApp.Controllers.ProjectDeleteController,
                controllerAs: 'controller'
            })
            .state('projectEdit', {
                url: '/projects/edit/:id',
                templateUrl: '/ngApp/views/projectEdit.html',
                controller: HigherLearningApp.Controllers.ProjectEditController,
                controllerAs: 'controller'
            })
            //-----------------------------------------------------------------------//

            //-----------------------A Page for All Projects-------------------------//
            .state('everything', {
                url: '/everything',
                templateUrl: '/ngApp/views/everything.html',
                controller: HigherLearningApp.Controllers.EverythingController,
                controllerAs: 'controller'
            })
            //-----------------------------------------------------------------------//

            .state('3dprinting', {
                url: '/3DPrinting',
                templateUrl: '/ngApp/views/3DPrinting.html',
                controller: HigherLearningApp.Controllers.PrintingController,
                controllerAs: 'controller'
            })
            .state('computers', {
                url: '/computers',
                templateUrl: '/ngApp/views/computers.html',
                controller: HigherLearningApp.Controllers.ComputersController,
                controllerAs: 'controller'
            })
            .state('embeddedSystems', {
                url: '/embeddedSystems',
                templateUrl: '/ngApp/views/embeddedSystems.html',
                controller: HigherLearningApp.Controllers.EmbeddedSystemsController,
                controllerAs: 'controller'
            })
            .state('webDevelopment', {
                url: '/webDevelopment',
                templateUrl: '/ngApp/views/webDevelopment.html',
                controller: HigherLearningApp.Controllers.WebDevelopmentController,
                controllerAs: 'controller'
            })
            .state('learn', {
                url: '/learn',
                templateUrl: '/ngApp/views/learn.html',
                controller: HigherLearningApp.Controllers.LearnController,
                controllerAs: 'controller'
            })
            .state('about', {
                url: '/about',
                templateUrl: '/ngApp/views/about.html',
                controller: HigherLearningApp.Controllers.AboutController,
                controllerAs: 'controller'
            })
            .state('contact', {
                url: '/contact',
                templateUrl: '/ngApp/views/contact.html',
                controller: HigherLearningApp.Controllers.ContactController,
                controllerAs: 'controller'
            })
            .state('notFound', {
                url: '/notFound',
                templateUrl: '/ngApp/views/notFound.html'
            });

        // Handle request for non-existent route
        $urlRouterProvider.otherwise('/notFound');

        // Enable HTML5 navigation
        $locationProvider.html5Mode(true);
    });

    
    angular.module('HigherLearningApp').factory('authInterceptor', (
        $q: ng.IQService,
        $window: ng.IWindowService,
        $location: ng.ILocationService
    ) =>
        ({
            request: function (config) {
                config.headers = config.headers || {};
                config.headers['X-Requested-With'] = 'XMLHttpRequest';
                return config;
            },
            responseError: function (rejection) {
                if (rejection.status === 401 || rejection.status === 403) {
                    $location.path('/login');
                }
                return $q.reject(rejection);
            }
        })
    );

    angular.module('HigherLearningApp').config(function ($httpProvider) {
        $httpProvider.interceptors.push('authInterceptor');
    });

    

}
