﻿define([	
    'base/related-object-grid-view',
    'collections/Terms/Terms',
    'l!t!Terms/TermsRelationships'
], function (BaseView, Collection, DetailView) {
	'use strict';

    var view = BaseView.extend({

		collectionType: Collection,
		gridSelector: '.grid',
		tableName: 'Terms',
        
		detailView: DetailView,

		selectable: true,

		defaultSorting: {
		    field: 'date',
		    dir: 'desc'
		},

		initialize: function() {
			view.__super__.initialize.apply(this, arguments);

			this.defaultFiltering = { field: 'orderId', operator: 'eq', value: this.model.id };

			this.options.durations = new Backbone.Collection([
				{ name: this.resources.pleaseSelect, id: '' },
				//{ name: '0:10', id: 10 },
				//{ name: '0:20', id: 20 },
				{ name: '0:30', id: 30 },
				//{ name: '0:40', id: 40 },
				//{ name: '0:50', id: 50 },
                { name: '1:00', id: 60 },
				{ name: '1:30', id: 90 },
				{ name: '2:00', id: 120 },
                { name: '2:30', id: 150 },
				{ name: '3:00', id: 180 },
                { name: '3:30', id: 210 },
				{ name: '4:00', id: 240 },
                { name: '4:30', id: 270 },
				{ name: '5:00', id: 300 },
                { name: '5:30', id: 330 },
				{ name: '6:00', id: 360 },
                { name: '6:30', id: 390 },
				{ name: '7:00', id: 420 },
                { name: '7:30', id: 450 },
				{ name: '8:00', id: 480 }
			]);

			this.collection = new Collection();
		},

		columns: function () {

		   return [
				{ field: 'date', headerAttributes: { width: '220px' }, title: this.resources.date, format: "{0:g}", dateTime: true, attributes: { "class": "detail-view-grid-cell" } },
                {
                    field: 'duration',
                    title: this.resources.duration,
                    collection: this.options.durations,
                    sortable: false,
                    headerAttributes: {
                        title: this.resources.duration
                    },
                    attributes: { "class": "detail-view-grid-cell", width: '55px' }
                },
				{ field: 'employees', title: this.resources.employee, sortable: false, filterable: false, attributes: { "class": "detail-view-grid-cell" } },
				{ field: 'autoId', title: this.resources.auto, collection: this.options.autos, defaultText: this.resources.pleaseSelect, attributes: { "class": "detail-view-grid-cell" } },
				{ field: 'status', title: this.resources.status, attributes: { "class": "detail-view-grid-cell" } },
                { field: 'comment', title: this.resources.comment, attributes: { "class": "detail-view-grid-cell" } },
                { field: 'errorStatus', title: this.resources.errorStatus, sortable: false, filterable: false, attributes: { "class": "detail-view-grid-cell" } },
			];
		},
		
		render: function () {
		    var self = this;

		    view.__super__.render.apply(self, arguments);

		    self.grid.bind('edit', function (e) {

		        e.model.orderId = self.model.id;		        
		    });

		    return self;
		},

		events: {
		    'click .printDeliveryNote': function (e) {

		        e.preventDefault();
		        var self = this,
                    grid = self.grid,
					dataItem = grid.dataItem(grid.select());

		        if (dataItem != undefined) {

		            location.href = Application.apiUrl + 'print/?printTypeId=5&id=' + dataItem.id;
		        }
		        else {
		            require(['base/information-view'], function (View) {
		                var view = new View({
		                    title: 'Termin auswählen',
		                    message: 'Wählen Sie bitte ein Termin aus!'
		                });
		                self.addView(view);
		                self.$el.append(view.render().$el);
		            });
		        }
		    },
		    'click .showDeliveryNote': function (e) {

		        e.preventDefault();
		        var self = this,
                    grid = self.grid,
					dataItem = grid.dataItem(grid.select());

		        if (dataItem != undefined) {

		            var model = new Backbone.Model();
		            model.url = Application.apiUrl + 'getTermSignature';
		            model.set('id', dataItem.id);

		            model.save({}, {
		                success: function (model, response) {
		                                             
		                    require(['Terms/ShowSignatureView'], function (View) {
		                        var view = new View({
		                            title: 'Unterschrift anzeigen',
		                            signatureData: response.signatureData
		                        });
		                        self.addView(view);
		                        self.$el.append(view.render().$el);
		                    });
		                },
		                error: function (model, response) {

		                }
		            });
		        }
		        else {
		            require(['base/information-view'], function (View) {
		                var view = new View({
		                    title: 'Unterschrift anzeigen',
		                    message: 'Wählen Sie bitte ein Termin aus!'
		                });
		                self.addView(view);
		                self.$el.append(view.render().$el);
		            });
		        }
		    },
		},

		toolbar: function () {
		    var self = this,
		        result =
		    [{
		        template: function () {
		            return '<a class="k-button k-button-icontext k-grid-create-inline" href="#" data-localized="add" style="min-width: 160px;"></a>' +
                    '<a class="k-button k-button-icontext printDeliveryNote" href="#" data-localized="printDeliveryNote"></a>' +
		            '<a class="k-button k-button-icontext showDeliveryNote" href="#" data-localized="showDeliveryNote" style="min-width: 180px;"></a>';
		        }
		    }];

		    return result;
		}
	});

	return view;
});
