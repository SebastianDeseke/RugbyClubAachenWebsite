// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    $('.dropdown-item').click(function () {
        var language = $(this).attr('id');

        $.ajax({
            url: '/Language/SetLanguage',
            type: 'POST',
            data: { Language: language },
            success: function (response) {
                console.log(response.message);
            }
        });
    });
});
