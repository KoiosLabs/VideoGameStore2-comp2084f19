// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(function () {
    $('#AjaxTriggerButton').click(function () {
        $('.PutOurAjaxContentHere').load("/ajax/getPartial");
    });

    $('#query').autocomplete({
        source: "search/autocomplete",
        minLength: 2
    });

    $('.AddToCartBtn').click(function () {
        var id = $(this).attr('id');
        $('#AddToCart-' + id).load('/Cart/AddToCart/' + id);
    }
    )
});

