$(window).scroll(function () {
    var Height1 = document.getElementById("content_div").clientHeight;
    var Height2 = document.getElementById("nav_sec").clientHeight;
    if ($(window).scrollTop() > Height1) {
        $('#nav_sec').addClass('navbarsec-fixed');
        //$('#conDiv2').addClass('transCon2');
        $('#conDiv2').css("transform", "translateY(" + Height2 + "px)");
        $('#conDiv3').css("transform", "translateY(" + Height2 + "px)");
        //$('#myFooter').addClass('transCon');
        $('#myFooter').css("transform", "translateY(" + Height2 + "px)");
    }
    if ($(window).scrollTop() < Height1 + 1) {
        $('#nav_sec').removeClass('navbarsec-fixed');
        //$('#conDiv2').removeClass('transCon');
        $('#conDiv2').css("transform", "translateY(0px)");
        $('#conDiv3').css("transform", "translateY(0px)");
        //$('#myFooter').removeClass('transCon');
        $('#myFooter').css("transform", "translateY(0px)");
    }
});
