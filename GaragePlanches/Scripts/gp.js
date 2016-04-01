$(function () {


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


    var createAutocomplete = function () {
        var $input = $(this);

        var options = {
            source: $input.attr("data-gp-autocomplete")
        };

        console.log(options);
        console.log(options.source);

        //$input.autocomplete(options);
    };


    $("form[data-gp-ajax='true']").submit(ajaxFormSubmit);
    $("input[data-gp-autocomplete]").each(createAutocomplete);
});