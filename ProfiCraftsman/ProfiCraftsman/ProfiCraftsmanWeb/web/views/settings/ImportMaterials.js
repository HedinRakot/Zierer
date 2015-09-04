define([
	'base/base-window-view',
	'mixins/kendo-widget-form'
], function (BaseView, KendoWidgetForm) {

    var view = BaseView.extend({
        width: '960px',
        title: 'Materialien Import',
        getUploadOptions: function ($el) {
            
            var self = this,
			result = {
			    async: {
			        saveUrl: Application.apiUrl + 'importMaterials',
			        autoUpload: true
			    },
			    showFileList: false,
			    upload: function (e) {
			        if (self.importResultsView) {
			            self.importResultsView.close();
			            delete self.importResultsView;
			        }
			    },
			    success: function (e) {
			        if (e.operation === 'upload') {
			            require(['t!Settings/ImportMaterialResults'], function (View) {
			                var view = self.importResultsView = new View({
			                    collection: new Backbone.Collection(e.response.errors),
			                    model: new Backbone.Model({
			                        createdMaterials: e.response.createdMaterials,
			                        updatedMaterials: e.response.updatedMaterials
			                    })
			                });

			                self.showView(view, '.import-results');
			                self.kendoWindow.center();
			            });
			        }
			    },
			    error: function(e){
			        debugger;

                }
			};

            return result;
        }
    });

    view.mixin(KendoWidgetForm);

    return view;
});