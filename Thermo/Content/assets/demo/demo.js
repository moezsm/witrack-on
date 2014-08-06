// -------------------------------
// Demos
// -------------------------------
$(document).ready(
  function() {
    $('.popovers').popover({container: 'body', trigger: 'hover', placement: 'top'}); //bootstrap's popover
    $('.tooltips').tooltip(); //bootstrap's tooltip

    $(".chathistory").niceScroll({horizrailenabled:false});  //chathistory scroll

    prettyPrint(); //Apply Code Prettifier

    $('.toggle').toggles({on:true});

    //EasyPieChart in rightbar

    try {
    $('.easypiechart#serverload').easyPieChart({
        barColor: "#e73c3c",
        trackColor: '#edeef0',
        scaleColor: '#d2d3d6',
        scaleLength: 5,
        lineCap: 'round',
        lineWidth: 2,
        size: 90,
        onStep: function(from, to, percent) {
            $(this.el).find('.percent').text(Math.round(percent));
        }
    });

    $('.easypiechart#ramusage').easyPieChart({
        barColor: "#f39c12",
        trackColor: '#edeef0',
        scaleColor: '#d2d3d6',
        scaleLength: 5,
        lineCap: 'round',
        lineWidth: 2,
        size: 90,
        onStep: function(from, to, percent) {
            $(this.el).find('.percent').text(Math.round(percent));
        }
    });
    }
    catch(error) {}



    $("#currentbalance").sparkline([12700,8573,10145,21077,15380,14399,19158,23911,15401,16793,13115,23315], {
    type: 'bar',
    barColor: '#62bc1f',
    height: '45',
    barWidth: 7});

});


// -------------------------------
// Demo: Chatbar.
// -------------------------------

$('.chatinput textarea').keypress(function (e) {
  if (e.which == 13) {

    var chatmsg = $(".chatinput textarea").val();
    var oo=$(".chathistory").html();

    var d=new Date();
    var n=d.toLocaleTimeString();


    if (!!$(".chatinput textarea").val())
        $(".chathistory").html(oo+ "<div class='chatmsg'><p>"+chatmsg+"</p><span class='timestamp'>"+n+"</span></div>");


    $(".chathistory").getNiceScroll().resize();
    $(".chathistory").animate({ scrollTop: $(document).height() }, 0);

    $(this).val(''); // empty textarea

    return false;
  }
});


// Toggle buttons

$("a#hidechatbtn").click(function () {
    $("#widgetarea").toggle();
    $("#chatarea").toggle();
});

$("#chatbar li a").click(function () {
    $("#widgetarea").toggle();
    $("#chatarea").toggle();
});




// -------------------------------
// Show Theme Settings
// -------------------------------
$('#slideitout').click(function() {
    $('#demo-theme-settings').toggleClass('shown');
    return false;
});


// -------------------------------
// Demo: Theme Settings
// -------------------------------

// Demo Fixed Header
