; (function (global, factory) {
    if (typeof exports === 'object' && typeof module !== 'undefined')
        module.exports = factory(global);
    else if (typeof define === 'function' && define.amd)
        define(factory());
    else
        factory(global);

}(window, (function () {
    'use strict';

    $$SCRIPT_MODELS$$

})));
