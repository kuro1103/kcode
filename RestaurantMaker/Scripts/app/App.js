var myApp;
(function (myApp) {
    /**
     * 啟動設定
     */
    var Config = /** @class */ (function () {
        function Config($locationProvider, $provide, $compileProvider, $httpProvider, blockUIConfig) {
            // 設定 Ajax 請求攜帶 XMLHttpRequest Header
            $httpProvider.defaults.headers.common["X-Requested-With"] = "XMLHttpRequest";
            // 設定 BlockUI
            blockUIConfig.message = "Loading...";
            blockUIConfig.autoBlock = false;
        }
        Config.$inject = ["$locationProvider", "$provide", "$compileProvider", "$httpProvider", "blockUIConfig"];
        return Config;
    }());
    myApp.Config = Config;
    /**
     * 註冊 Angular 各項服務
     */
    var RegisterAngular = /** @class */ (function () {
        function RegisterAngular() {
        }
        RegisterAngular.RegisterDirective = function (name, service) {
            angular.module("myApp.Directives").directive(name, service);
        };
        RegisterAngular.RegisterDirectives = function (object) {
            var _this = this;
            var classNames = Object.getOwnPropertyNames(object);
            classNames.forEach(function (className) {
                _this.RegisterDirective(object[className].$name, object[className].$inject);
            });
        };
        RegisterAngular.RegisterService = function (name, service) {
            angular.module("myApp.Services").service(name, service);
        };
        RegisterAngular.RegisterController = function (name, service) {
            angular.module("myApp.Controllers").controller(name, service);
        };
        return RegisterAngular;
    }());
    myApp.RegisterAngular = RegisterAngular;
    /**
    * 初始化 Angular Module
    */
    var appModules = [
        "myApp.Directives", "myApp.Controllers", "myApp.Services"
    ];
    var trirdpartyModules = [
        "blockUI"
    ];
    appModules.forEach(function (module) { return angular.module(module, []); });
    appModules = appModules.concat(trirdpartyModules);
    angular.module("myApp", appModules).config(Config);
})(myApp || (myApp = {}));
//# sourceMappingURL=App.js.map