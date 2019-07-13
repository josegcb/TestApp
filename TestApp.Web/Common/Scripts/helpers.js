var App = App || {};
(function () {

    var appLocalizationSource = abp.localization.getSource('TestApp');
    App.localize = function () {
        return appLocalizationSource.apply(this, arguments);
    };

})(App);