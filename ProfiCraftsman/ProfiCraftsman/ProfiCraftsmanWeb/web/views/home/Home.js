define([
	'base/base-view',
    'calendar',
    'mixins/kendo-widget-form',
	'mixins/kendo-validator-form',
	'mixins/bound-form',
    'models/ShowProduct'
], function (BaseView, Calendar, KendoWidgetFormMixin, KendoValidatorFormMixin, BoundForm, Model) {
    'use strict';

    var employees = [];

    var bindCalendar = function (self, needLoadData) {

        var model = self.model,
            schedulerCreated = false,
            terms = [];

        require(['calendarLanguages'], function () {

            self.$el.find('#calendar').fullCalendar({

                customButtons: {
                    weeklyViewButton: {
                        text: 'Wochenansicht',
                        click: function () {
                            self.$el.find('#calendar').hide();

                            var scheduler = self.$el.find('#scheduler');
                            scheduler.show();

                            if (!schedulerCreated) {
                                schedulerCreated = true;

                                bindWeeklyScheduler(self, scheduler, true);
                            }
                            else {
                                scheduler.data('kendoScheduler').refresh();
                            }
                        }
                    },
                    mapsButton: {
                        text: 'Karte',
                        click: function () {
                            self.$el.find('#calendar').hide();

                            var mapContainer = self.$el.find('#mapContainer');
                            mapContainer.show();

                            var map = new google.maps.Map(self.$el.find('#map')[0], {
                                zoom: 12
                            });

                            var geocoder = new google.maps.Geocoder();
                            $(terms).each(function () {

                                var address = this.address,
                                    title = this.title,
                                    url = this.url;

                                if (address && address != '') {
                                    geocoder.geocode({ 'address': address }, function (results, status) {
                                        if (status === google.maps.GeocoderStatus.OK) {
                                            map.setCenter(results[0].geometry.location);
                                            var marker = new google.maps.Marker({
                                                map: map,
                                                position: results[0].geometry.location,
                                                title: title,
                                                url: url
                                            });

                                            google.maps.event.addListener(marker, 'click', function () {
                                                location.href = marker.url;
                                            });
                                        } else {
                                            alert('Geocode was not successful for the following reason: ' + status);
                                        }
                                    });
                                }
                            });
                        }
                    }
                },
                header: {
                    left: 'prev,next today',
                    center: 'title',
                    right: 'weeklyViewButton, mapsButton'
                },
                minTime: "07:00:00",
                maxTime: "18:00:00",
                height: 690,
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
                                startDateStr: start.date() + '.' + (start.month() + 1) + '.' + start.year(),
                                endDateStr: end.date() + '.' + (end.month() + 1) + '.' + end.year(),
                            },
                            success: function (results) {

                                var events = [];
                                terms = results;
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

                            }
                        });
                    }
                }
            });
        });
    },

    bindWeeklyScheduler = function (self, scheduler, needLoadData) {

        var model = self.model;

        require(['kendo/kendo.scheduler', 'kendo/kendo.timezones', 'kendo/cultures/kendo.culture.de-DE'], function () {

            scheduler.kendoScheduler({

                workDayStart: new Date("2015/1/1 07:00"),
                workDayEnd: new Date("2015/1/1 18:00"),
                startTime: new Date("2015/1/1 00:00"),
                endTime: new Date("2015/1/1 23:59"),

                eventTemplate: $("#event-template").html(),

                eventHeight: 50,
                majorTick: 60,

                views: [
                    "timelineWeek",
                ],

                timezone: "Europe/Berlin",

                navigate: function (e) {

                    if (e.action == "changeView") {
                        scheduler.hide();
                        self.$el.find('#calendar').show();
                    }
                    else {
                        loadWeeklySchedulerData(scheduler, new Date(e.date));
                    }
                },

                messages: {
                    showWorkDay: "Arbeitszeit anzeigen",
                    showFullDay: "Ganzen Tag anzeigen",
                    today: "Heute",
                    views: {
                        timelineWeek: "Tagesansicht"
                    }
                },


                showWorkHours: true,
                editable: false,

                group: {
                    resources: ["Employees"],
                    orientation: "vertical"
                },
                resources: [
                    {
                        field: "employees",
                        name: "Employees",
                        dataSource : employees,
                        multiple: true,
                        title: "Employees"
                    }
                ]
            });


            loadWeeklySchedulerData(scheduler, new Date());

        });

    },

    loadWeeklySchedulerData = function (scheduler, currentDate) {
        var firstday = new Date(currentDate.setDate(currentDate.getDate() - currentDate.getDay() + 1));
        var lastday = new Date(currentDate.setDate(currentDate.getDate() - currentDate.getDay() + 8));

        $.ajax({
            url: Application.apiUrl + 'showTerms',
            type: 'POST',
            data: {
                startDateStr: firstday.toDateString(),
                endDateStr: lastday.toDateString()
            },
            success: function (terms) {

                scheduler.data('kendoScheduler').setDataSource(new kendo.data.SchedulerDataSource({
                    data: terms,

                    schema: {
                        model: {
                            id: "id",
                            fields: {
                                id: { from: "id", type: "number" },
                                title: { from: "title" },
                                start: { type: "date", from: "start" },
                                end: { type: "date", from: "end" },
                                url: { from: "url" },
                                employees: { from: "employees" },
                            }
                        }
                    }
                }));

                scheduler.data('kendoScheduler').dataSource.read();
            },
            error: function (e) {

            }
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
            
	        employees = [];

	        $.ajax({
	            url: Application.apiUrl + 'employees',
	            success: function (result) {

	                $(result.data).each(function () {

	                    employees.push({
	                        text: this.name + ' ' + (this.firstName != null ? this.firstName : ''),
	                        value: this.id,
	                        color: this.color,
	                    });
	                });
	            },
	            error: function (e) {

	            }
	        });

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
	        'click .calendarViewButton': function (e) {

	            var self = this;

	            var mapContainer = self.$el.find('#mapContainer');
	            mapContainer.hide();

	            self.$el.find('#calendar').show();
	        },
	    }
	});

    view.mixin(BoundForm);
    view.mixin(KendoValidatorFormMixin);
    view.mixin(KendoWidgetFormMixin);

    return view;
});