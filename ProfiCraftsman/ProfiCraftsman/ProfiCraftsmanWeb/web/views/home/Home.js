define([
	'base/base-view',
    'calendar',
    'mixins/kendo-widget-form',
	'mixins/kendo-validator-form',
	'mixins/bound-form',
    'models/ShowProduct'
], function (BaseView, Calendar, KendoWidgetFormMixin, KendoValidatorFormMixin, BoundForm, Model) {
	'use strict';
    
    var bindCalendar = function (self, needLoadData) {

	    var model = self.model;

	    require(['calendarLanguages'], function () {

	        self.$el.find('#calendar').fullCalendar({
	            header: {
	                left: 'prev,next today',
	                center: 'title',
	                right: ''
	            },
	            editable: false,
	            lang: "de",
	            eventLimit: true, // allow "more" link when too many events,
                	            
	            events: function (start, end, timezone, callback) {
    
	                if (needLoadData) {
	                    $.ajax({
	                        url: Application.apiUrl + 'showProduct',
	                        type: 'POST',
	                        data: {
	                            productTypeId: model.get('productTypeId'),
	                            name: model.get('name'),
	                            equipments: model.get('equipments'),
	                            startDateStr: start.date() + '.' + (start.month() + 1) + '.' + start.year(),
	                            endDateStr: end.date() + '.' + (end.month() + 1) + '.' + end.year(),
	                            searchFreeProduct: model.get('searchFreeProduct')
	                        },
	                        success: function (doc) {

	                            var events = [];
	                            $(doc).each(function () {

	                                events.push({
	                                    title: this.title,
	                                    start: this.start,
	                                    end: this.end,
	                                    url: this.url,
	                                    color: model.get('searchFreeProduct') == true ? '#009D59' : ''
	                                });
	                            });
	                            callback(events);
	                        },
	                        error: function (e) {
	                            //alert('there was an error while fetching events!');
	                        }
	                    });
	                }
	            }
	        });
	    });
	},

	view = BaseView.extend({
        
	    bindings: function () {

	        var self = this;
	        var result = {
	            '#name': 'name',
	            '#productTypeId': {
	                observe: 'productTypeId',
	                selectOptions: {
	                    labelPath: 'name', valuePath: 'id',
	                    collection: self.options.productTypesForDisposition,
	                    defaultOption: { label: self.resources.pleaseSelect, value: null }
	                },
	            },
	            '#equipments': {
	                observe: 'equipments',
	                selectOptions: {
	                    labelPath: 'name', valuePath: 'id',
	                    collection: self.options.equipments
	                },
	            }	            
	        };

	        return result;
	    },

	    initialize: function () {

	        view.__super__.initialize.apply(this, arguments);
	        
	        var self = this;
	        self.model = new Model();
	        self.model.set('searchFreeProduct', self.options.searchFreeProduct);
	    },

		render: function () {
		    view.__super__.render.apply(this, arguments);

		    var self = this,
                needLoadData = true;

		    if (self.options.searchFreeProduct) {
		        needLoadData = false;
		    }

		    setTimeout(function () { bindCalendar(self, needLoadData); }, 0);

			return this;
		},

		events: {
		    'click .apply': function (e) {

		        var self = this;
		        self.$el.find('#calendar').fullCalendar('destroy');
		        bindCalendar(self, true);		        
		    },
		    'click .cancel': function (e) {

		        var self = this,
                    searchFreeProduct = self.options.searchFreeProduct;

		        self.model.clear().set(self.model.defaults);

		        self.model.set('searchFreeProduct', searchFreeProduct);

		        self.$el.find('#calendar').fullCalendar('destroy');
		        bindCalendar(self, true);		        
		    },
		}
	});
    
	view.mixin(BoundForm);
	view.mixin(KendoValidatorFormMixin);
	view.mixin(KendoWidgetFormMixin);
    
	return view;
});