﻿$(function () {


    var ajaxFormSubmit = function () {
        var $form = $(this);

        var options = {
            url: $form.attr("action"),
            type: $form.attr("method"),
            data: $form.serialize()
            };

        console.log("HELLO FROM THE AJAX METHOD");

        $.ajax(options).done(function (data) {
            var $target = $($form.attr("data-gp-target"));
            $target.replaceWith(data);
        });

        return false; 
    };


    $("form[data-gp-ajax='true']").submit(ajaxFormSubmit);


});