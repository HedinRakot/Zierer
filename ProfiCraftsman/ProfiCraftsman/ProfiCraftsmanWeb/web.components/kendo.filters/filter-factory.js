﻿define(["kendo.filters/multiselect","kendo.filters/select-box"],function(t,e){"use strict";var n=function(t){this.column=t};return _.extend(n.prototype,{multiSelect:function(e,n){t.call(this,e,n)},selectBox:function(t,n){e.call(this,t,n)}}),n});