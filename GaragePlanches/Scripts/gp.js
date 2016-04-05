$(function () {

    //Méthode qui va lancer récupérer les données d'un formulaire en AJAX
    var ajaxFormSubmit = function () {
        var $form = $(this);

        var options = {
            url: $form.attr("action"),
            type: $form.attr("method"),
            data: $form.serialize()
            };

        $.ajax(options).done(function (data) {
            var $target = $($form.attr("data-gp-target"));
            $target.replaceWith(data);
        });

        return false; 
    };

    //Méthode qui va créer l'autocomplétation 
    var createAutocomplete = function () {
        var $input = $(this);

        var options = {
            source: $input.attr("data-gp-autocomplete"),
            select: submitAutocompleteForm
        };

        console.log(options);
        console.log(options.source);

        $input.autocomplete(options);
    };

    //Méthode qui va déclencher la sélection lors d'un clic sur la liste de l'autocomplétation
    var submitAutocompleteForm = function (event,ui) {

        var $input = $(this);
        $input.val(ui.item.label);

        var $form = $input.parents("form:first");
        $form.submit(); 
    };


    $("form[data-gp-ajax='true']").submit(ajaxFormSubmit);
    $("input[data-gp-autocomplete]").each(createAutocomplete);

});