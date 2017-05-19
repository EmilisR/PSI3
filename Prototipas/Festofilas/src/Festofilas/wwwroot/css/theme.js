// *** TO BE CUSTOMISED ***

var style_cookie_name = "style" ;
var style_cookie_duration = 30 ;
var style_domain = "localhost" ;

// *** END OF CUSTOMISABLE SECTION ***
// You do not need to customise anything below this line

function switch_style(css_title) {
    var element = document.getElementById('navbar');
    if (document.body.style.backgroundColor === 'white') {
        document.body.style.backgroundColor = 'cyan';
        element.style.backgroundColor = 'purple';
    }
    else {
        document.body.style.backgroundColor = 'white';
        element.style.backgroundColor = "#2a2a2a";
    }
}

