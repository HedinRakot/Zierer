﻿define([
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
               
	            defaultView: 'agendaDay',

	            events: function (start, end, timezone, callback) {
    
	                if (needLoadData) {
	                    $.ajax({
	                        url: Application.apiUrl + 'showTerms',
	                        type: 'POST',
	                        data: {
	                            //TODO name: model.get('name'),
	                            startDateStr: start.date() + '.' + (start.month() + 1) + '.' + start.year(),
	                            endDateStr: end.date() + '.' + (end.month() + 1) + '.' + end.year(),
	                        },
	                        success: function (doc) {

	                            var events = [];
	                            $(doc).each(function () {

	                                events.push({
	                                    title: this.title,
	                                    start: this.start,
	                                    end: this.end,
	                                    url: this.url,
	                                    color: this.color,
	                                    allDay: this.agendaEvent,
	                                    columnIndex: this.columnIndex,
	                                    overlap: false,
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
	            //TODO'#name': 'name',      
	        };

	        return result;
	    },

	    initialize: function () {

	        view.__super__.initialize.apply(this, arguments);
	        
	        var self = this;
	        self.model = new Model();
	    },

		render: function () {
		    view.__super__.render.apply(this, arguments);

		    var self = this,
                needLoadData = true;

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

		        var self = this;

		        self.model.clear().set(self.model.defaults);

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