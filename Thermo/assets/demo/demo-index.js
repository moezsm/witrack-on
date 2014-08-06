jQuery(document).ready(function() {

    $(".demodrop").pulsate({
        color: "#2bbce0",
        repeat: 10
    });

    try {
    //Easy Pie Chart
    $('.easypiechart#returningvisits').easyPieChart({
        barColor: "#85c744",
        trackColor: '#edeef0',
        scaleColor: '#d2d3d6',
        scaleLength: 5,
        lineCap: 'square',
        lineWidth: 2,
        size: 90,
        onStep: function(from, to, percent) {
            $(this.el).find('.percent').text(Math.round(percent));
        }
    });

    $('.easypiechart#average').easyPieChart({
        barColor: "#85c744",
        trackColor: '#edeef0',
        scaleColor: '#d2d3d6',
        scaleLength: 5,
        lineCap: 'square',
        lineWidth: 2,
        size: 90,
        onStep: function (from, to, percent) {
            $(this.el).find('.percent').text(Math.round(percent));
        }
    });

    $('.easypiechart#hight').easyPieChart({
        barColor: "#e73c3c",
        trackColor: '#edeef0',
        scaleColor: '#d2d3d6',
        scaleLength: 5,
        lineCap: 'square',
        lineWidth: 2,
        size: 90,
        onStep: function (from, to, percent) {
            $(this.el).find('.percent').text(Math.round(percent));
        }
    });
    $('.easypiechart#Low').easyPieChart({
        barColor: "#4f8edc",
        trackColor: '#edeef0',
        scaleColor: '#d2d3d6',
        scaleLength: 5,
        lineCap: 'square',
        lineWidth: 2,
        size: 90,
        onStep: function (from, to, percent) {
            $(this.el).find('.percent').text(Math.round(percent));
        }
    });

    $('.easypiechart#newvisitor').easyPieChart({
        barColor: "#4f8edc",
        trackColor: '#edeef0',
        scaleColor: '#d2d3d6',
        scaleLength: 5,
        lineCap: 'square',
        lineWidth: 2,
        size: 90,
        onStep: function(from, to, percent) {
            $(this.el).find('.percent').text(Math.round(percent));
        }
    });

    $('.easypiechart#clickrate').easyPieChart({
        barColor: "#e73c3c",
        trackColor: '#edeef0',
        scaleColor: '#d2d3d6',
        scaleLength: 5,
        lineCap: 'square',
        lineWidth: 2,
        size: 90,
        onStep: function(from, to, percent) {
            $(this.el).find('.percent').text(Math.round(percent));
        }
    });


    $('#updatePieCharts').on('click', function() {
        $('.easypiechart#returningvisits').data('easyPieChart').update(Math.random()*100);
        $('.easypiechart#newvisitor').data('easyPieChart').update(Math.random()*100);
        $('.easypiechart#clickrate').data('easyPieChart').update(Math.random()*100);
        return false;
    });
    }
    catch(e) {}


    //Date Range Picker



    $("#threads,#comments,#users").niceScroll({horizrailenabled:false, railoffset: {left:0}});


    //Sparklines

    $("#indexinfocomments").sparkline([12 + randValue(),8 + randValue(),10 + randValue(), 21 + randValue(), 16 + randValue(), 9 + randValue(), 15 + randValue(), 8 + randValue() ,10 + randValue(),19 + randValue()], {
    type: 'bar',
    barColor: '#f1948a',
    height: '45',
    barWidth: 7});

    $("#indexinfolikes").sparkline([120 + randValue(),87 + randValue(),108 + randValue(), 121 + randValue(), 85 + randValue(), 95 + randValue(), 185 + randValue(), 125 + randValue() ,154 + randValue(),109 + randValue()], {
    type: 'bar',
    barColor: '#f5c783',
    height: '45',
    barWidth: 7});



    $("#indexvisits").sparkline([7914 + randValue(),2795 + randValue(),3256 + randValue(), 3018 + randValue(), 2832 + randValue() ,5261 + randValue(),6573 + randValue()], {
    lineWidth: 1.5,
    type: 'line',
    width: '90px',
    height: '45px',
    lineColor: '#556b8d',
    fillColor: 'rgba(85,107,141,0.1)',
    spotColor: false,
    minSpotColor: false,
    highlightLineColor: '#d2d3d6',
    highlightSpotColor: '#556b8d',
    spotRadius: 3,
    maxSpotColor: false});

    $("#indexpageviews").sparkline([8263 + randValue(),6314 + randValue(),10467 + randValue(), 12123 + randValue(), 11125 + randValue() ,13414 + randValue(),15519 + randValue()], {
    lineWidth: 1.5,
    type: 'line',
    width: '90px',
    height: '45px',
    lineColor: '#4f8edc',
    fillColor: 'rgba(79,142,220,0.1)',
    spotColor: false,
    minSpotColor: false,
    highlightLineColor: '#d2d3d6',
    highlightSpotColor: '#4f8edc',
    spotRadius: 3,
    maxSpotColor: false});

    $("#indexpagesvisit").sparkline([7.41 + randValue(),6.12 + randValue(),6.8 + randValue(), 5.21 + randValue(), 6.15 + randValue() ,7.14 + randValue(),6.19 + randValue()], {
    lineWidth: 1.5,
    type: 'line',
    width: '90px',
    height: '45px',
    lineColor: '#2bbce0',
    fillColor: 'rgba(43,188,224,0.1)',
    spotColor: false,
    minSpotColor: false,
    highlightLineColor: '#d2d3d6',
    highlightSpotColor: '#2bbce0',
    spotRadius: 3,
    maxSpotColor: false});

    $("#indexavgvisit").sparkline([5.31 + randValue(),2.18 + randValue(),1.06 + randValue(), 3.42 + randValue(), 2.51 + randValue() ,1.45 + randValue(),4.01 + randValue()], {
    lineWidth: 1.5,
    type: 'line',
    width: '90px',
    height: '45px',
    lineColor: '#85c744',
    fillColor: 'rgba(133,199,68,0.1)',
    spotColor: false,
    minSpotColor: false,
    highlightLineColor: '#d2d3d6',
    highlightSpotColor: '#85c744',
    spotRadius: 3,
    maxSpotColor: false});

    $("#indexnewvisits").sparkline([70.14 + randValue(),72.95 + randValue(),77.56 + randValue(), 78.18 + randValue(), 76.32 + randValue() ,73.61 + randValue(),74.73 + randValue()], {
    lineWidth: 1.5,
    type: 'line',
    width: '90px',
    height: '45px',
    lineColor: '#efa131',
    fillColor: 'rgba(239,161,49,0.1)',
    spotColor: false,
    minSpotColor: false,
    highlightLineColor: '#d2d3d6',
    highlightSpotColor: '#efa131',
    spotRadius: 3,
    maxSpotColor: false});

    $("#indexbouncerate").sparkline([29.14 + randValue(),27.95 + randValue(),32.56 + randValue(), 30.18 + randValue(), 28.32 + randValue() ,32.61 + randValue(),35.73 + randValue()], {
    lineWidth: 1.5,
    type: 'line',
    width: '90px',
    height: '45px',
    lineColor: '#e74c3c',
    fillColor: 'rgba(231,76,60,0.1)',
    spotColor: false,
    minSpotColor: false,
    highlightLineColor: '#d2d3d6',
    highlightSpotColor: '#e74c3c',
    spotRadius: 3,
    maxSpotColor: false});



    //Flot

    function randValue() {
        return (Math.floor(Math.random() * (2)));
    }

    var viewcount = [
        [1, 787 + randValue()],
        [2, 740 + randValue()],
        [3, 560 + randValue()],
        [4, 860 + randValue()],
        [5, 750 + randValue()],
        [6, 910 + randValue()],
        [7, 730 + randValue()]
    ];

    var uniqueviews = [
        [1, 179 + randValue()],
        [2, 320 + randValue()],
        [3, 120 + randValue()],
        [4, 400 + randValue()],
        [5, 573 + randValue()],
        [6, 255 + randValue()],
        [7, 366 + randValue()]
    ];

    
    var usercount = [
        [1, 70 + randValue()],
        [2, 260 + randValue()],
        [3, 30 + randValue()],
        [4, 147 + randValue()],
        [5, 333 + randValue()],
        [6, 155 + randValue()],
        [7, 166 + randValue()]
    ];



    var d1 = [
        [1, 29 + randValue()],
        [2, 62 + randValue()],
        [3, 52 + randValue()],
        [4, 41 + randValue()]
    ];
    var d2 = [
        [1, 36 + randValue()],
        [2, 79 + randValue()],
        [3, 66 + randValue()],
        [4, 24 + randValue()]
    ];

    for (var i = 1; i < 5; i++) {
        d1.push([i, parseInt(Math.random() * 1)]);
        d2.push([i, parseInt(Math.random() * 1)]);
    }
 
    var ds = new Array();

    ds.push({
    data:d1,
    label: "Budget",
    bars: {
        show: true,
        barWidth: 0.2,
        order: 1
    }
    });
    ds.push({
        data:d2,
        label: "Actual",
        bars: {
            show: true,
            barWidth: 0.2,
            order: 2,
        }
    });

   



    var previousPoint = null;
        $("#site-statistics").bind("plothover", function (event, pos, item) {
        $("#x").text(pos.x.toFixed(2));
        $("#y").text(pos.y.toFixed(2));
        if (item) {
            if (previousPoint != item.dataIndex) {
                previousPoint = item.dataIndex;

                $("#tooltip").remove();
                var x = item.datapoint[0].toFixed(2),
                    y = item.datapoint[1].toFixed(2);

                showTooltip(item.pageX, item.pageY-7, item.series.label + ": " + Math.round(y));

            }
        } else {
            $("#tooltip").remove();
            previousPoint = null;
        }
    });

    var previousPointBar = null;
        $("#budget-variance").bind("plothover", function (event, pos, item) {
        $("#x").text(pos.x.toFixed(2));
        $("#y").text(pos.y.toFixed(2));
        if (item) {
            if (previousPointBar != item.dataIndex) {
                previousPointBar = item.dataIndex;

                $("#tooltip").remove();
                var x = item.datapoint[0].toFixed(2),
                    y = item.datapoint[1].toFixed(2);

                showTooltip(item.pageX+20, item.pageY, item.series.label + ": $" + Math.round(y)+"K");

            }
        } else {
            $("#tooltip").remove();
            previousPointBar = null;
        }
    });



    function showTooltip(x, y, contents) {
        $('<div id="tooltip" class="tooltip top in"><div class="tooltip-inner">' + contents + '<\/div><\/div>').css({
            display: 'none',
            top: y - 40,
            left: x - 55,
        }).appendTo("body").fadeIn(200);
    }



    var container = $("#server-load");

    // Determine how many data points to keep based on the placeholder's initial size;
    // this gives us a nice high-res plot while avoiding more than one point per pixel.

    var maximum = container.outerWidth() / 2 || 300;
    var data = [];

    function getRandomData() {

        if (data.length) {
            data = data.slice(1);
        }

        while (data.length < maximum) {
            var previous = data.length ? data[data.length - 1] : 50;
            var y = previous + Math.random() * 10 - 5;
            data.push(y < 0 ? 0 : y > 100 ? 100 : y);
        }

        // zip the generated y values with the x values
        var res = [];
        for (var i = 0; i < data.length; ++i) {
            res.push([i, data[i]])
        }
        return res;
    }

    //

    series = [{
        data: getRandomData()
    }];

    



   


});


// Calendar
// If screensize > 1200, render with m/w/d view, if not by default render with just title






