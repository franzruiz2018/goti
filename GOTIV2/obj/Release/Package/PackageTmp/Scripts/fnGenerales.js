TipoMensaje = { Exito: 1, Error: 2, Alert: 3, Info: 4 };

function mostrarMensaje(elemento, mensaje, tipo)
{
    var html = "";
    var mTipo = "";
    var mIcon = "";
    switch (tipo) {
        case 1: mTipo = "alert-success"; mIcon = "fa-check"; break;
        case 2: mTipo = "alert-error"; mIcon = "fa-ban"; break;       
        case 3: mTipo = "alert-warning"; mIcon = "fa-warning"; break;
        case 4: mTipo = "alert-info"; mIcon = "fa-info"; break;
    }
    html="<div class='alert "+mTipo+" alert-dismissable' style='height:auto;'>" +
    "<button type='button' class='close' data-dismiss='alert' aria-hidden='true'>×</button>"+
    "<i class='icon fa "+mIcon+"'></i>"+mensaje+"</div>";
    document.getElementById(elemento).innerHTML = html;
}

function obtenerData(dataSource, propertyName) {
    var data = [];
    for (var i = 0; i < dataSource.length; i++) {
        data.push(eval('dataSource[i].' + propertyName));
    }
    return data;
}