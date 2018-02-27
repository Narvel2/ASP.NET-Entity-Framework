function Count() {
    var dzisiaj = new Date();

    var dzien = dzisiaj.getDate();
    var miesiac = dzisiaj.getMonth() + 1;
    var rok = dzisiaj.getFullYear();

    var godzina = dzisiaj.getHours();
    if (godzina < 10) godzina = "0" + godzina;

    var minuta = dzisiaj.getMinutes();
    if (minuta < 10) minuta = "0" + minuta;

    var sekunda = dzisiaj.getSeconds();
    if (sekunda < 10) sekunda = "0" + sekunda;

    document.getElementById("Clock").innerHTML =
     dzien + "/" + miesiac + "/" + rok+ " "+ godzina + ":" + minuta + ":" + sekunda;

    setTimeout("Count()", 1000);
}

var number = Math.floor(Math.random() * 5) + 1;

var timer1 = 0;
var timer2 = 0;


function Hide()
{
    $("#slider").fadeOut(500);
}

function ChangeSlide()
{
    number++;
    if (number > 5)
        number = 1;

    var file = "<img src=\"doodles/slajd" + number + ".jpg\" width=\"700\" height=\"525\"\" />";

    document.getElementById("LeftUniversity").innerHTML = file;
    $("#LeftUniversity").fadeIn(500);

    timer1 = setTimeout("ChangeSlide()", 5000);
    timer2 = setTimeout("Hide()", 4500);

}