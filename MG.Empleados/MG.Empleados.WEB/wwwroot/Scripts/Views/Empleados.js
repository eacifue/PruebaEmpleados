function Empleados() {



    this.ConsultarEmpleados = function () {

        var pParametros = new Object();
        pParametros.id = $("#txtEmpleado").val();
        var Id = $("#txtEmpleado").val();

        $.ajax({
            url: '/Empleados/ConsultarEmpleados',
            type: "GET",
            dataType: "JSON",
            data: {
                Request: Id
            },
            success: function (data) {

                    Empleados.CargarTabla(data);

            }
        });
    };


    this.CargarTabla = function (data) {

        $('#tblEmpleados tbody').empty()

        $.each(data, function (key, item) {

            var html = '<tr><th>' + item.id + '</th><td>' + item.name + '</td><td>' + item.contractTypeName + '</td><td>' + item.roleId + '</td><td>' + item.roleName + '</td><td>' + item.roleDescription + '</td><td>' + new Intl.NumberFormat().format(item.hourlySalary) + '</td><td>' + new Intl.NumberFormat().format(item.monthlySalary) + '</td><td>' + new Intl.NumberFormat().format(item.yearSalary) + '</td></tr>';

            $("#tblEmpleados tbody").append(html);


        });

        $('#MyModalDetalle').modal('show');

    };
}
var Empleados = new Empleados();

$(document).ready(function () {

    $("#btnBuscar").click(function () {

        Empleados.ConsultarEmpleados();

    });


});