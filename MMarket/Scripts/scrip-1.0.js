﻿$(window).scroll(function () {
    var Height1 = document.getElementById("content_div").clientHeight;
    //var Height2 = document.getElementById("top_nav").clientHeight;
    if ($(window).scrollTop() > Height1) {
        $('#nav_sec').addClass('navbarsec-fixed');
        $('#conDiv2').addClass('transCon');
        $('#myFooter').addClass('transCon');
    }
    if ($(window).scrollTop() < Height1 + 1) {
        $('#nav_sec').removeClass('navbarsec-fixed');
        $('#conDiv2').removeClass('transCon');
        $('#myFooter').removeClass('transCon');
    }
});
