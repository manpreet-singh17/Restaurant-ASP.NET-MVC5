$(function () {
    //alert("Hello");
    var ajaxFormSubmit = function () {
        var form = $(this);

        var options = {
            url: form.attr("action"),
            type: form.attr("method"),
            data: form.serialize()
        };

        //here is the async request to server via jQuery.
        $.ajax(options).done(function (data) {
            var target = $(form.attr("data-otf-target"));
            target.html(data);
        });

        //to PREVENT browser for its default behaviour of submitting the form by itself to server.
        return false;
    };

    var submitAutocompleteForm = function (event, ui) {

        var input = $(this);
        input.val(ui.item.label);
        
        var $form = input.parents("form:first");
        $form.submit();
    }

    var createAutoComplete = function () {

        var $input = $(this);

        var options = {
            source: $input.attr("data-otf-autocomplete"),
            select: submitAutocompleteForm
        };

        $input.autocomplete(options);
    };

    var getPage = function () {
        var $a = $(this);

        var options = {
            url: $a.attr("href"),
            data: $("form").serialize(),
            type: "get"
        };

        $.ajax(options).done(function (data) {
            var target = $a.parents("div.pagedList").attr("data-otf-target");
            $(target).replaceWith(data);
        });
        return false;
    }

    $("form[data-otf-ajax='true']").submit(ajaxFormSubmit);

    $("input[data-otf-autocomplete]").each(createAutoComplete);

    $(".body-content").on("click", ".pagedList a", getPage);
});