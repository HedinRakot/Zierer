define([
	'base/base-object-tab-view',
    'kendo/kendo.tabstrip'
], function (BaseView) {
    'use strict';

    var view = BaseView.extend({

        tabs: function () {
            
            var result = [
				{ view: 'l!t!Invoices/InvoicePositions', selector: '.invoicePositions' },
				{ view: 'l!t!Invoices/InvoicePayments', selector: '.invoicePayments' },
                
            ];
            
            return result;
        }
    });

    return view;
});
