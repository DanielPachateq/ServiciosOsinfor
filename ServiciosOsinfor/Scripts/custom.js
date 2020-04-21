/* 
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */


var dtIni = {
    order: [],
    dom: 'Bfrtip',
    destroy: true,
    scrollX: true,
    buttons: [
        {
            extend: 'copyHtml5',
            text: '<span class="btn btn-default"><li class="fa fa-files-o"></li></span>&nbsp;',
            titleAttr: 'Copiar'
        },
        {
            extend: 'excelHtml5',
            text: '<span class="btn btn-default"><li class="fa fa-file-excel-o"></li></span>&nbsp;',
            titleAttr: 'Excel'
        },
        {
            extend: 'csvHtml5',
            text: '<span class="btn btn-default"><li class="fa fa-file-text-o"></li></span>&nbsp;',
            titleAttr: 'CSV'
        },
        {
            extend: 'pdfHtml5',
            text: '<span class="btn btn-default"><li class="fa fa-file-pdf-o"></li></span>&nbsp;',
            titleAttr: 'PDF'
        }
    ]
};

var dtMant = {
    order: [],
    dom: 'Bfrtip',
    destroy: true,
    scrollX: true,
    "language": {
        "url": "/assets/js/datatables.es.json"
    }
};

var estadoSolicitud = [
	{color: '#000000', desc: 'Ninguno'},
    {color: '#fef59e', desc: 'Pendiente'},
    {color: '#99cda0', desc: 'Aprobado'},
    {color: '#ef9da2', desc: 'Rechazado'},
    {color: '#93b1dc', desc: 'Procesado'},
	{color: '#c896bd', desc: 'En Proceso Cancelación'},
    {color: '#facd91', desc: 'Cancelado'}
	];

var estadoConcepto = [
	{color:'#33cc33', desc:'Recepción Terminados'},
	{color:'#f30000', desc:'Despacho'}
	];

var spinner = '<div class="row"><div class="col-xs-12" style="text-align: center;"><span class="fa fa-spinner fa-spin" style="font-size:86px;"></span></div></div>';


$(document).ready(function () {

    //Marcar sección activa en la barra lateral para subelementos

    $('.treeview-menu li').children('a').each(function () {

        if (window.location.pathname === this.pathname) {
            $(this).parent().addClass("active");
            $(this).parent().parent().parent().addClass("active");
        }
    });

    //Marcar sección activa en la barra lateral para elementos
    $('#main-menu li').children('a').each(function () {

        if ((window.location.pathname === this.pathname) && !($(this).parent().hasClass("treeview"))) {
            $(this).parent().addClass("active");
        }

    });

    $.sum = function (arr) {
        var r = 0;

        $.each(arr, function (i, v) {
            r += parseFloat(v);
        });
        return r;
    };

    $.sumPesos = function (arr) {
        var r = 0;
        var u = 0;

        $.each(arr, function (i, v) {
            r += parseFloat((v.cantidad * v.KILOS));
            u += parseFloat(v.cantidad);
        });
        r = r.toFixed(2);
        return {peso: r, cantidad: u};
    };

    $.sumUnidPesos = function (arr) {
        var r = 0;
        var q = 0;
        var u = 0;

        $.each(arr, function (i, v) {
            if (v.F_UNIDAD === true) {
                u += parseFloat((v.cantidad * v.UNIDADES_CONV));
            } else {
                r += parseFloat((v.cantidad * v.KILOS));
            }

            q += parseFloat(v.cantidad);
        });
        r = r.toFixed(2);
        return {peso: r, cantidad: q, unidades: u};
    };
});



function findInArray(arr, attr, value) {
    for (i = 0; i < arr.length; i++) {
        if (arr[i][attr] == value) {
            return i;
        }
    }

    return -1;


}

