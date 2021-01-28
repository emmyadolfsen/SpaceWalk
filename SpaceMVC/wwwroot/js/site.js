$(window).ready(function () {
    /**********************************
    * Walking through space - animation
    ***********************************/
   
    // Första katten
    setTimeout(function () {
        $("#first-cat").removeClass("animate__fadeInLeft").addClass("animate__fadeOutUp");
    }, 800);

    //Andra katten 
    setTimeout(function () {
        $("#second-cat").removeClass("animate__fadeInDown").addClass("animate__fadeOutUp");
    }, 2500);

    // Tredje katten - tar bort hidden - lägger till fadein animation
    setTimeout(function () {
        $("#third-cat").removeClass("hidden").addClass("animate__fadeInRight");
    }, 5000);

    // Tredje katten - lägger till fade out
    setTimeout(function () {
        $("#third-cat").addClass("animate__fadeOutRight");
    }, 6000);

    // Visar walk-btn
    setTimeout(function () {
        $("#walk-btn").removeClass("hidden").addClass("visible");
    }, 6500);
});
