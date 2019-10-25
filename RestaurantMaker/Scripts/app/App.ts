module myApp {
    /**
     * 啟動設定
     */
    export class Config {
        static $inject = ["$locationProvider", "$provide", "$compileProvider", "$httpProvider", "blockUIConfig"];

        constructor($locationProvider: ng.ILocationProvider, $provide, $compileProvider, $httpProvider, blockUIConfig) {
            // 設定 Ajax 請求攜帶 XMLHttpRequest Header
            $httpProvider.defaults.headers.common["X-Requested-With"] = "XMLHttpRequest";
            // 設定 BlockUI
            blockUIConfig.message = "Loading...";
            blockUIConfig.autoBlock = false;
        }
    }

    /**
     * 註冊 Angular 各項服務
     */
    export class RegisterAngular {
        public static RegisterDirective(name: string, service: Array<any>): void {
            angular.module("myApp.Directives").directive(name, service);
        }

        public static RegisterDirectives(object: Object): void {
            var classNames = Object.getOwnPropertyNames(object);
            classNames.forEach((className: string) => {
                this.RegisterDirective(object[className].$name, object[className].$inject);
            });
        }

        public static RegisterService(name: string, service: Function): void {
            angular.module("myApp.Services").service(name, service);
        }

        public static RegisterController(name: string, service: ng.Injectable<ng.IControllerConstructor>): void {
            angular.module("myApp.Controllers").controller(name, service);
        }
    }

    /**
    * 初始化 Angular Module
    */
    var appModules =
        [
            "myApp.Directives", "myApp.Controllers", "myApp.Services"
        ];
    var trirdpartyModules =
        [
            "blockUI"
        ];
    appModules.forEach((module: string) => angular.module(module, []));
    appModules = appModules.concat(trirdpartyModules);
    angular.module("myApp", appModules).config(Config);
}