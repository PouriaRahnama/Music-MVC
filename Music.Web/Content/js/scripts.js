(function () {
    "use strict";

    // custom scrollbar

    $("html").niceScroll({
        styler: "fb",
        cursorcolor: "#45B39D",
        cursorwidth: '5',
        cursorborderradius: '10px',
        background: '#444',
        spacebarenabled: false,
        cursorborder: '0',
        zindex: '1000'
    });

    $(".left-side").niceScroll({
        styler: "fb",
        cursorcolor: "#45B39D",
        cursorwidth: '3',
        cursorborderradius: '10px',
        background: '#444',
        spacebarenabled: false,
        cursorborder: '0'
    });

    $('.popup-with-zoom-anim').magnificPopup({
        type: 'inline',
        fixedContentPos: false,
        fixedBgPos: true,
        overflowY: 'auto',
        closeBtnInside: true,
        preloader: false,
        midClick: true,
        removalDelay: 300,
        mainClass: 'my-mfp-zoom-in'
    });
    $(".left-side").getNiceScroll();
    if ($('body').hasClass('left-side-collapsed')) {
        $(".left-side").getNiceScroll().hide();
    }

    // Slideshow 4
    $("#slider4").responsiveSlides({
        auto: true,
        pager: true,
        nav: true,
        speed: 500,
        namespace: "callbacks",
        before: function () {
            $('.events').append("<li>before event fired.</li>");
        },
        after: function () {
            $('.events').append("<li>after event fired.</li>");
        }
    });

    $("#flexiselDemo1").flexisel({
        visibleItems: 5,
        animationSpeed: 1000,
        autoPlay: true,
        autoPlaySpeed: 3000,
        pauseOnHover: false,
        enableResponsiveBreakpoints: true,
        responsiveBreakpoints: {
            portrait: {
                changePoint: 480,
                visibleItems: 2
            },
            landscape: {
                changePoint: 640,
                visibleItems: 3
            },
            tablet: {
                changePoint: 800,
                visibleItems: 4
            }
        }
    });

    // Toggle Left Menu
    jQuery('.menu-list > a').click(function () {

        var parent = jQuery(this).parent();
        var sub = parent.find('> ul');

        if (!jQuery('body').hasClass('left-side-collapsed')) {
            if (sub.is(':visible')) {
                sub.slideUp(200, function () {
                    parent.removeClass('nav-active');
                    jQuery('.main-content').css({
                        height: ''
                    });
                    mainContentHeightAdjust();
                });
            } else {
                visibleSubMenuClose();
                parent.addClass('nav-active');
                sub.slideDown(200, function () {
                    mainContentHeightAdjust();
                });
            }
        }
        return false;
    });

    function visibleSubMenuClose() {
        jQuery('.menu-list').each(function () {
            var t = jQuery(this);
            if (t.hasClass('nav-active')) {
                t.find('> ul').slideUp(200, function () {
                    t.removeClass('nav-active');
                });
            }
        });
    }

    function mainContentHeightAdjust() {
        // Adjust main content height
        var docHeight = jQuery(document).height();
        if (docHeight > jQuery('.main-content').height())
            jQuery('.main-content').height(docHeight);
    }

    //  class add mouse hover
    jQuery('.custom-nav > li').hover(function () {
        jQuery(this).addClass('nav-hover');
    }, function () {
        jQuery(this).removeClass('nav-hover');
    });


    // Menu Toggle
    jQuery('.toggle-btn').click(function () {
        $(".left-side").getNiceScroll().hide();

        if ($('body').hasClass('left-side-collapsed')) {
            $(".left-side").getNiceScroll().hide();
        }
        var body = jQuery('body');
        var bodyposition = body.css('position');

        if (bodyposition != 'relative') {

            if (!body.hasClass('left-side-collapsed')) {
                body.addClass('left-side-collapsed');
                jQuery('.custom-nav ul').attr('style', '');

                jQuery(this).addClass('menu-collapsed');

            } else {
                body.removeClass('left-side-collapsed chat-view');
                jQuery('.custom-nav li.active ul').css({
                    display: 'block'
                });

                jQuery(this).removeClass('menu-collapsed');

            }
        } else {

            if (body.hasClass('left-side-show'))
                body.removeClass('left-side-show');
            else
                body.addClass('left-side-show');

            mainContentHeightAdjust();
        }

    });


    searchform_reposition();

    jQuery(window).resize(function () {

        if (jQuery('body').css('position') == 'relative') {

            jQuery('body').removeClass('left-side-collapsed');

        } else {

            jQuery('body').css({
                left: '',
                marginRight: ''
            });
        }

        searchform_reposition();

    });

    function searchform_reposition() {
        if (jQuery('.searchform').css('position') == 'relative') {
            jQuery('.searchform').insertBefore('.left-side-inner .logged-user');
        } else {
            jQuery('.searchform').insertBefore('.menu-right');
        }
    }
})(jQuery);

// Dropdowns Script
$(document).ready(function () {
    $(document).on('click', function (ev) {
        ev.stopImmediatePropagation();
        $(".dropdown-toggle").dropdown("active");
    });
});



/************** Search ****************/
$(function () {
    var button = $('#loginButton');
    var box = $('#loginBox');
    var form = $('#loginForm');
    button.removeAttr('href');
    button.mouseup(function (login) {
        box.toggle();
        button.toggleClass('active');
    });
    form.mouseup(function () {
        return false;
    });
    $(this).mouseup(function (login) {
        if (!($(login.target).parent('#loginButton').length > 0)) {
            button.removeClass('active');
            box.hide();
        }
    });
});


  