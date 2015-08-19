define([
    'l!t!Orders/Positions'
], function (BaseView) {
    'use strict';
    
    var view = BaseView.extend({

        isMaterialPosition: true,

        render: function () {

            var self = this;
            
            debugger;

            view.__super__.render.apply(self, arguments);           

            return self;
        },
        
    });

    return view;
});
