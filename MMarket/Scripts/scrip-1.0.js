$(window).scroll(function () {
    var Height1 = document.getElementById("content_div").clientHeight;
    var Height2 = document.getElementById("top_nav").clientHeight;
    if ($(window).scrollTop() > Height1) {
        $('#nav_sec').addClass('navbarsec-fixed');
        $('#nav_sec').css("top", Height2);
    }
    if ($(window).scrollTop() < Height1 + 1) {
        $('#nav_sec').removeClass('navbarsec-fixed');
    }
});
