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

	            customButtons: {
	                weeklyViewButton: {
	                    text: 'Wochenansicht',
	                    click: function () {
	                        self.$el.find('#calendar').hide();
	                        
	                        self.$el.find('#scheduler').show();
	                        bindWeeklyScheduler(self, true);
	                    }
	                }
	            },
	            header: {
	                left: 'prev,next today',
	                center: 'title',
	                right: 'weeklyViewButton'
	            },
	            minTime: "08:00:00",
	            maxTime: "20:00:00",
	            height: 735,
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
	                        success: function (terms) {

	                            var events = [];
	                            $(terms).each(function () {

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

    bindWeeklyScheduler = function (self, needLoadData) {

        var model = self.model;

        require(['kendo/kendo.scheduler', 'kendo/kendo.timezones'], function () {
            
            $.ajax({
                url: Application.apiUrl + 'showTerms',
                type: 'POST',
                data: {
                    //TODO name: model.get('name'),
                    //startDateStr: start.date() + '.' + (start.month() + 1) + '.' + start.year(),
                    //endDateStr: end.date() + '.' + (end.month() + 1) + '.' + end.year(),
                    startDateStr: '02.09.2015',//new Date(),
                    endDateStr: '03.09.2015',//new Date(new Date().setDate(new Date().getDate()+1)).toDateString(),
                },
                success: function (terms) {
                    debugger;

            self.$el.find('#scheduler').kendoScheduler({
                date: new Date(),
                startTime: new Date(),
                eventHeight: 50,
                majorTick: 60,
                views: [
                    //"timeline",
                    "timelineWeek",
                    //"timelineWorkWeek",
                    //{
                    //    type: "timelineMonth",
                    //    startTime: new Date("2013/6/13 00:00 AM"),
                    //    majorTick: 1440
                    //}
                ],
                timezone: "Europe/Berlin",

                navigate: function (e) {
                    alert(e.date);
                },

                showWorkHours: true,
                editable: false,

                dataSource: {
                    batch: true,

                    data: terms,// [{ "id": 2, "employees": [2], "title": "LoL", "Description": "", "start": "2015-09-02T10:00", "end": "2015-09-02T14:00" }],
                    //transport: {
                    //    read: {
                    //        url: "//demos.telerik.com/kendo-ui/service/meetings",
                    //        dataType: "jsonp"
                    //    },
                    //    //update: {
                    //    //    url: "//demos.telerik.com/kendo-ui/service/meetings/update",
                    //    //    dataType: "jsonp"
                    //    //},
                    //    //create: {
                    //    //    url: "//demos.telerik.com/kendo-ui/service/meetings/create",
                    //    //    dataType: "jsonp"
                    //    //},
                    //    //destroy: {
                    //    //    url: "//demos.telerik.com/kendo-ui/service/meetings/destroy",
                    //    //    dataType: "jsonp"
                    //    //},
                    //    parameterMap: function (options, operation) {
                    //        if (operation !== "read" && options.models) {
                    //            return { models: kendo.stringify(options.models) };
                    //        }
                    //    }
                    //},
                    schema: {
                        model: {
                            id: "id",
                            fields: {
                                id: { from: "id", type: "number" },
                                title: { from: "title", defaultValue: "No title", validation: { required: true } },
                                start: { type: "date", from: "startDate" },
                                end: { type: "date", from: "endDate" },
                                //startTimezone: { from: "StartTimezone" },
                                //endTimezone: { from: "EndTimezone" },
                                //description: { from: "Description" },
                                //recurrenceId: { from: "RecurrenceID" },
                                //recurrenceRule: { from: "RecurrenceRule" },
                                //recurrenceException: { from: "RecurrenceException" },
                                //roomId: { from: "RoomID", nullable: true },
                                employees: { from: "employees", nullable: true },
                                //isAllDay: { type: "boolean", from: "IsAllDay" }
                            }
                        }
                    }
                },
                group: {
                    resources: ["Employees"],
                    orientation: "vertical"
                },
                resources: [
                    //{
                    //    field: "roomId",
                    //    name: "Rooms",
                    //    dataSource: [
                    //        { text: "Meeting Room 101", value: 1, color: "#6eb3fa" },
                    //        { text: "Meeting Room 201", value: 2, color: "#f58a8a" }
                    //    ],
                    //    title: "Room"
                    //},
                    {
                        field: "employees",
                        name: "Employees",
                        dataSource: [
                            { text: "Yury", value: 1, color: "#f8a398" },
                            { text: "Thomas", value: 2, color: "#51a0ed" },
                            { text: "Fechner Sasha", value: 3, color: "#56ca85" },
                            { text: "Matthias", value: 4, color: "#56ca85" },
                            { text: "Heinrich", value: 5, color: "#56ca85" },
                            { text: "Peter", value: 6, color: "#56ca85" },
                        ],
                        multiple: true,
                        title: "Employees"
                    }
                ]
            });



                },
                error: function (e) {
                    //alert('there was an error while fetching events!');
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