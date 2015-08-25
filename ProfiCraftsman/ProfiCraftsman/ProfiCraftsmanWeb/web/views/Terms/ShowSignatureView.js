define([
	'base/base-window-view',
	'text!templates/Terms/ShowSignatureView.html',
    'lr!resources/Terms/ShowSignatureView'
], function (BaseView, Template, Resources) {
	'use strict';

	var view = BaseView.extend({

	    width: '1300px',

		template: Template,

		events: {
			'click .continue': function (e) {
				e.preventDefault();

				this.close();
			},
		},

		initialize: function () {
			view.__super__.initialize.apply(this, arguments);

			this.title = this.options.title;
			this.model = new Backbone.Model({
				signatureData: this.options.signatureData
			});
		},

        render: function () {
			view.__super__.render.apply(this, arguments);

		    this.$('[data-localized=continue]').html(Resources.continue);

			return this;
		}
	});

	return view;
});