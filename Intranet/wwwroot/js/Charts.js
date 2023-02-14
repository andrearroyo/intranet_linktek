function generateLineChart(value, label) {
    var options = {
        series: [
            {
                name: "Atenciones",
                data: value
            }
        ],
        chart: {
            height: '100%',
            width: '100%',
            type: 'bar',
            toolbar: {
                show: false
            }
        },
        plotOptions: {
            bar: {
                borderRadius: 4,
                horizontal: false,
            }
        },
        dataLabels: {
            enabled: true,
        },
        stroke: {
            curve: 'smooth'
        },
        grid: {
            borderColor: '#e7e7e7',
            row: {
                colors: ['#f3f3f3', 'transparent'],
                opacity: 0.5
            },
        },
        markers: {
            size: 1
        },
        yaxis: {
            title: {
                text: 'Atenciones'
            }
        }
    };

    //follow the same tag id for your visualization
    var chart = new ApexCharts(document.querySelector("#chart"), options);
    chart.render();
}

function generateBarChart(value, label) {
    var options = {
        series: [{
            name: "Atenciones",
            data: value
        }],
        chart: {
            type: 'bar',
            height: 350
        },
        plotOptions: {
            bar: {
                borderRadius: 4,
                horizontal: false,
            }
        },
        dataLabels: {
            enabled: false
        },
        xaxis: {
            categories: label,
        }
    };
    var chart = new ApexCharts(document.querySelector("#chart"), options);
    chart.render();
}