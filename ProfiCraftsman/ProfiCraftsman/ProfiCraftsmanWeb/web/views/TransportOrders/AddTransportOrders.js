define([
	'base/base-object-add-view',
    'l!t!TransportOrders/TransportOrdersRelationships',
    'l!t!Orders/SelectCustomer'
], function (BaseView, TabView, SelectCustomerView) {
    'use strict';

    var save = function () {

        var self = this,
            deferred = new $.Deferred(),
            isNew = self.model.isNew(),
			attributesToSave = _.pick(
				self.model.toJSON(),
                'id',
                'changeDate',
                'deliveryPlace',        
                'zip',
                'city',
                'street',
                'comment',
                'orderDate',
                'orderedFrom',
                'customerOrderNumber',
                'orderNumber',
                'discount',
                'billTillDate',
                'customerNumber',
                'newCustomerName',
                'customerStreet',
                'customerCity',
                'customerZip',
                'customerPhone',
                'customerFax',
                'customerEmail',
                'customerSelectType',
                'customerId',
                'communicationPartnerId',
                'customerSelectType',
                'isOffer',
                'customerNumber');
        

        attributesToSave["newCustomerName"] = $('#newCustomerName').val();
        attributesToSave["customerStreet"] = $('#customerStreet').val();
        attributesToSave["customerCity"] = $('#customerCity').val();
        attributesToSave["customerZip"] = $('#customerZip').val();


        if (self.validate()) {
            self.model.save({}, {
                data: kendo.stringify(attributesToSave),
                method: isNew ? 'post' : 'put',
                contentType: 'application/json',
                success: function (response) {
                    
                    if(response.get('isOffer'))
                        location.href = "#TransportOffers/" + response.id;
                    else
                        location.href = "#TransportOrders/" + response.id;

                    return deferred.resolve();
                },
                error: function (model, response) {
                    self.validateResponse(response);
                }
            });
        }

        return deferred.promise();
    },

    validate = function(attributes)
    {

    },

    view = BaseView.extend({

        tabView: TabView,
        tableName: 'TransportOrders',
        actionUrl: '#TransportOrders',

        bindings: function () {

            var self = this;
            var result = {
                '#customerSelectType': 'customerSelectType',
                '#customerId': 'customerId',
                '#communicationPartnerId': {
                    observe: 'communicationPartnerId',
                    selectOptions: {
                        labelPath: 'name',
                        valuePath: 'id',
                        collection: function () {

                            return this.options.communicationPartners.where({ customerId: this.model.get('customerId') }).
                                    map(function (item) {
                                        return item.toJSON();
                                    });
                        },
                        defaultOption: {
                            label: self.resources.pleaseSelect,
                            value: null
                        }
                    },
                },
                '#customerId_Name': 'customerName',
                '#deliveryPlace': 'deliveryPlace',
                '#street': 'street',
                '#zip': 'zip',
                '#city': 'city',
                '#comment': 'comment',
                '#orderDate': 'orderDate',
                '#orderedFrom': 'orderedFrom',
                '#orderNumber': 'orderNumber',
                '#customerOrderNumber': 'customerOrderNumber',
                '#discount': 'discount',
                '#billTillDate': 'billTillDate',
                '#customerPhone': 'customerPhone',
                '#customerFax': 'customerFax',
                '#customerEmail': 'customerEmail',
                '#createDate': 'createDate',
                '.radioButtons': {
                    observe: 'id',
                    visible: function (val) {
                        return val == undefined || val == "";
                    }
                },
                '#isOffer': 'isOffer',
                '.rowWithOrderNumbers': {
                    observe: 'id',
                    visible: function (val) {
                        return val != undefined && val != "" && !self.model.get('isOffer');
                    }
                },
            };
            
            return result;
        },

        render: function () {

            view.__super__.render.apply(this, arguments);

            this.stickit();

            var self = this;

            $('#isOffer').val(self.options.isOffer);

            self.listenTo(self.model, 'change:customerId', function () {

                self.model.unset('communicationPartnerId', { silent: true });
                self.model.set('communicationPartnerId', 0);
            });

            self.listenTo(self.model, 'change:customerSelectType', function (temp) {
                var customerSelectType = self.model.get('customerSelectType');
                if(customerSelectType === "1")
                {
                    $('#selectCustomerRow').show();
                    $('#customerNumberRow').hide();
                    $('#customerAddressRow').hide();
                    $('#customerPhonesRow').hide();
                    $('#newCustomerName').val('0');
                    $('#customerStreet').val('0');
                    $('#customerCity').val('0');
                    $('#customerZip').val('0');
                    $('#customerId').val('');
                    $('#customerId_Name').val('');
                }
                else if(customerSelectType === "2")
                {
                    $('#selectCustomerRow').hide();
                    $('#customerNumberRow').show();
                    $('#customerAddressRow').show();
                    $('#customerPhonesRow').show();
                    $('#newCustomerName').val('');
                    $('#customerStreet').val('');
                    $('#customerCity').val('');
                    $('#customerZip').val('');
                    $('#customerId').val('0');
                }
            });
            
            return this;
        },

        save: function () {
            
        },

        events: {
            'click .SelectCustomer': function (e) {
                e.preventDefault();

                var self = this,
                    view = new SelectCustomerView();

                self.listenTo(view, 'select', function (item) {

                    self.model.set('customerId', item.id);
                    self.$el.find('#customerId').val(item.id);
                    self.$el.find('#customerId_Name').val(item.get('name'));

                    self.$el.find('#discount').data("kendoNumericTextBox").value(item.get('discount'));
                    self.model.set('discount', item.get('discount'));

                    var autoBill = item.get('autoBill');
                    self.$el.find('#autoBill').val(autoBill);
                    self.model.set('autoBill', autoBill);
                });

                self.addView(view);
                self.$el.append(view.render().$el);
            },
            'click .save': function (e) {
                e.preventDefault();

                var self = this;
                save.call(self).done(function () {

                });
            },
        }
    });

    return view;
});
