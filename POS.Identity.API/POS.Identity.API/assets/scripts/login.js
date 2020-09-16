$(document).ready(function () {
    'use strict';
    var emailError = true,
        passwordError = true,
        passConfirm = true;

    if (navigator.userAgent.toLowerCase().indexOf('firefox') > -1) {
        $('.form form label').addClass('fontSwitch');
    }
    // Label effect
    $('input').focus(function () {

        $(this).siblings('label').addClass('active');
    });
    // Form validation
    $('input').blur(function () {

        // Email
        if ($(this).hasClass('email')) {
            if ($(this).val().length == '') {
                $(this).siblings('span.error').text('Please type your email address').fadeIn().parent('.form-group').addClass('hasError');
                emailError = true;
            } else {
                $(this).siblings('.error').text('').fadeOut().parent('.form-group').removeClass('hasError');
                emailError = false;
            }
        }

        // PassWord
        if ($(this).hasClass('pass')) {
            if ($(this).val().length < 8) {
                $(this).siblings('span.error').text('Please type at least 8 charcters').fadeIn().parent('.form-group').addClass('hasError');
                passwordError = true;
            } else {
                $(this).siblings('.error').text('').fadeOut().parent('.form-group').removeClass('hasError');
                passwordError = false;
            }
        }

        // PassWord confirmation
        if ($('.pass').val() !== $('.passConfirm').val()) {
            $('.passConfirm').siblings('.error').text('Passwords don\'t match').fadeIn().parent('.form-group').addClass('hasError');
            passConfirm = false;
        } else {
            $('.passConfirm').siblings('.error').text('').fadeOut().parent('.form-group').removeClass('hasError');
            passConfirm = false;
        }

        // label effect
        if ($(this).val().length > 0) {
            $(this).siblings('label').addClass('active');
        } else {
            $(this).siblings('label').removeClass('active');
        }


    });
    // form switch
    $('a.switch').click(function (e) {
        $(this).toggleClass('active');
        e.preventDefault();

        if ($('a.switch').hasClass('active')) {
            $(this).parents('.form-peice').addClass('switched').siblings('.form-peice').removeClass('switched');
        } else {
            $(this).parents('.form-peice').removeClass('switched').siblings('.form-peice').addClass('switched');
        }
    });

    var formata = $('#ajax-contact');
    // Form submit
    $(formata).submit(function (event) {
        event.preventDefault();

        // var AccountName = 'salem';
        // var language = 'en';
        // var URL = "http://mmfapi.smarturdon.com/api/Data/GetBlance?Username=" + AccountName + "&lang=" + language;
        // $.ajax({
        //     url: URL,
        //     dataType: "jsonp",
        //     headers: {
        //         Accept: "application/json",
        //         'Access-Control-Allow-Origin': "*"

        //     },
        //     success: function (data) {
        //         if (data != null) {
        //             alert(data.SMSBalance);

        //         }
        //     },
        //     complete: function () {
        //         alert('complete');
        //     },
        //     error: function (e) {
        //         alert(e);
        //     }

        // });


        var formData = {
            email: $('#email').val(),
            password: $('#password').val(),
            ConfirmPassword: $('#passwordCon').val()
        };
        alert(formData);
        $.ajax({
            method: 'POST',
            url: 'http://localhost:10047/api/Account/Register',
            headers: {
						'Accept': 'application/json'
            },
            dataType: "json",
			crossDomain: true,
            contentType: 'application/json  charset=utf-8',
            data:  JSON.stringify(formData),
            success: function () {
                $('.email, .pass, .passConfirm').blur();
                $('#email').val(),
                    $('#password').val(),
                    $('#passwordCon').val()


                $('.signup, .login').addClass('switched');

                setTimeout(function () { $('.signup, .login').hide(); }, 700);
                setTimeout(function () { $('.brand').addClass('active'); }, 300);
                setTimeout(function () { $('.heading').addClass('active'); }, 600);
                setTimeout(function () { $('.success-msg p').addClass('active'); }, 900);
                setTimeout(function () { $('.success-msg a').addClass('active'); }, 1050);
                setTimeout(function () { $('.form').hide(); }, 700);
                alert(success)
            }, error: function () {

                $('.signup, .login').addClass('switched');

                setTimeout(function () { $('.signup, .login').hide(); }, 700);
                setTimeout(function () { $('.brand').addClass('active'); }, 300);
                setTimeout(function () { $('.heading').addClass('active'); }, 600);
                setTimeout(function () { $('.ERROR-msg p').addClass('active'); }, 900);
                setTimeout(function () { $('.ERROR-msg a').addClass('active'); }, 1050);
                setTimeout(function () { $('.form').hide(); }, 700);
                $('#email').val(),
                    $('#password').val(),
                    $('#passwordCon').val()

            }

        })

    });

    // Reload page
    $('a.profile').on('click', function () {
        location.reload(true);
    });


});


