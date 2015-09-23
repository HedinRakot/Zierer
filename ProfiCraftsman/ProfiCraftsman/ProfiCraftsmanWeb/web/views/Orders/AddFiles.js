define([
	'base/base-window-view',
	'mixins/kendo-widget-form'
], function (BaseView, KendoWidgetForm) {

    var view = BaseView.extend({
        width: '960px',
        title: 'Dateien hinzufügen',
        getUploadOptions: function ($el) {

            var self = this,
                result = {
                    async: {
                        saveUrl: Application.apiUrl + 'addOrderFiles/?orderId=' + self.options.orderId,
                        autoUpload: true
                    },
                    showFileList: false,
                    upload: function (e) {

                    },
                    success: function (e) {
                        if (e.operation === 'upload') {
                            self.options.grid.dataSource.read();
                            self.options.grid.refresh();
                        }
                    },
                    error: function (e) {
                        debugger;

                    }
                };

            return result;
        }
    });

    view.mixin(KendoWidgetForm);

    return view;
});