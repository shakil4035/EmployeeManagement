$(document).ready(function () {
    GenaratePersonalNumber();
    //Get Department
    $.get("/api/Departments", function (data) {
        var $el = $("#DepartmentId");
        $el.empty(); // remove old options
        $el.append($("<option></option>")
            .attr("value", '').text(''));
        $.each(data, function (value, key) {
            $el.append($('<option>',
                {
                    value: key.id,
                    text: key.name
                }));
        });
    });


    //Get Designation
    $.get("/api/Designations", function (data) {
        var $el = $("#DesignationId");
        $el.empty(); // remove old options
        $el.append($("<option></option>")
            .attr("value", '').text(''));
        $.each(data, function (value, key) {
            $el.append($('<option>',
                {
                    value: key.id,
                    text: key.name
                }));
        });
    });
    //loadHistoryTable(e)
});

$("#txtFindTrainee").autocomplete({
    source: function (request, response) {
        $.ajax({
            url: "/api/GeneralInformations/Search",
            data: { query: request.term },
            type: "GET"
        }).done(function (data) {
            response($.map(data, function (item) {
                return { label: item.employeeId + " " + item.nameEnglish, value: item.employeeId }
            }));
        });
    },
    minLength: 2,
    select: function (e, ui) {

        $.get("/api/GeneralInformations/SearchAutoComplete", { pNumber: ui.item.value })
            .done(function (data) {
                //console.log(pData);
                // window.pId = data.id;
                $("#Id").val(data.id);
                $("#searchName").val(data.nameEnglish);
                $("#searchPhone").val(data.phoneNumber);

                loadHistoryTable(data.id);

            });

    }
});


$(document.body).on("click",
    "#btnSubmit",
    function () {
        var vm = {};
        var id = $("#Id").val();
        vm.employeeId = $("#EmployeeId").val();
        vm.nameBangla = $("#NameBangla").val();
        vm.nameEnglish = $("#NameEnglish").val();
        vm.fatherName = $("#FatherName").val();
        vm.motherName = $("#MotherName").val();
        vm.birthDate = $("#BirthDate").val();
        vm.birthPlace = $("#BirthPlace").val();
        vm.nationalId = $("#NationalId").val();
        vm.nationality = $("#Nationality").val();
        vm.presentAddress = $("#PresentAddress").val();
        vm.permanentAddress = $("#PermanentAddress").val();
        vm.bloodGroup = $("#BloodGroup").val();
        vm.religion = $("#Religion").val();
        vm.basicSalary = $("#BasicSalary").val();
        vm.gender = $("#Gender").val();
        vm.meritialStatus = $("#MeritialStatus").val();
        vm.phoneNumber = $("#PhoneNumber").val();
        vm.email = $("#Email").val();
        vm.departmentId = $("#DepartmentId").val();
        vm.position = $("#Position").val();
        vm.designationId = $("#DesignationId").val();
        vm.JobJoiningDate = $("#JobJoiningDate").val();
  
        if (id == "" || id == 0 || id == null) {
            $.ajax({
                url: "/api/GeneralInformations",
                data: vm,
                type: "POST",
                success: function (e) {
                    if (e > 0) {
                        toastr.success("Save Success", "Success!!!");
                        loadHistoryTable(e);
                        GenaratePersonalNumber();
                        refressForm();
                    } else {
                        toastr.warning("Save Fail", "Warning!!!");
                    }
                },
                error: function (request, status, error) {
                    var response = jQuery.parseJSON(request.responseText);
                    toastr.error(response.message, "Error");
                }
            });
        } else {
            vm.id = id;

            $.ajax({
                url: "/api/GeneralInformations/" + id,
                data: vm,
                type: "PUT",
                success: function (e) {
                    if (e > 0) {
                        toastr.success("Update Success", "Success!!!");
                        loadHistoryTable(e);
                        refressForm();
                        
                    } else {
                        toastr.warning("Update Fail.", "Warning!!!");
                    }
                },
                error: function (request, status, error) {
                    var response = jQuery.parseJSON(request.responseText);
                    toastr.error(response.message, "Error");
                }
            });

        }
    });


function refressForm() {
    $("#Id").val('');
    $("#EmployeeId").val('');
    $("#NameEnglish").val('');
    $("#NameBangla").val('');
    $("#FatherName").val('');
    $("#MotherName").val('');
    $("#BirthDate").val('');
    $("#BirthPlace").val('');
    $("#NationalId").val('');
    $("#Nationality").val('');
    $("#PresentAddress").val('');
    $("#PermanentAddress").val('');
    $("#BloodGroup").val('');
    $("#Religion").val('');
    $("#BasicSalary").val('');
    $("#Gender").val('');
    $("#MeritialStatus").val('');
    $("#PhoneNumber").val('');
    $("#Email").val('');
    $("#DepartmentId").val('');
    $("#Position").val('');
    $("#DesignationId").val('');
    $("#JobJoiningDate").val('');
}

function loadHistoryTable(id) {

    $("#employeeList").DataTable().destroy();

    $("#employeeList").DataTable({
        retrieve: true,
        paging: true,
        ajax: {
            url: "/api/GeneralInformations/GetInfoById?id=" +id,
            dataSrc: ""
        },
        columns: [
            {
                data: "employeeId"
            },
            {
                data: "nameEnglish"
            },
            {
                data: "email"
            },
            {
                data: "department.name"
            },
            {
                data: "designation.name"
            },
            {
                data: "basicSalary"
            },
            
            {
                data: "id",
                render: function (data) {
                    return "<a class='btn btn-info btn-sm js-edit' data-id=" + data + " ><i class='fa fa-pencil-square fa-2x ' aria-hidden='false'></i></a>";
                }
            },
            {
                data: "id",
                render: function (data) {
                    return "<a class='btn-link js-delete'  data-id=" + data + "><i class='fa fa-trash fa-2x' aria-hidden='true' style='color: #d9534f;'></i></a>";
                }
            }
        ]
    });
}
$(document.body).on("click",
    "#btnRefresh",
    function () {
        refressForm();
    });


function GenaratePersonalNumber() {

    $.get("/api/GeneralInformations/GenerateEmployeId",
        function (data) {
            if (data !== null) {
                $("#EmployeeId").val(data);
            }

        });
}

function getData(id) {
    $.get("/api/GeneralInformations/" + id)
        .done(function (data) {
            $("#Id").val(data.id);
            $("#EmployeeId").val(data.employeeId);
            $("#NameBangla").val(data.nameBangla);
            $("#NameEnglish").val(data.nameEnglish);
            $("#FatherName").val(data.fatherName);
            $("#MotherName").val(data.motherName);
            $("#BirthDate").val(data.birthDate);
            $("#BirthPlace").val(data.birthPlace);
            $("#NationalId").val(data.nationalId);
            $("#Nationality").val(data.nationality);
            $("#PresentAddress").val(data.presentAddress);
            $("#PermanentAddress").val(data.permanentAddress);
            $("#BloodGroup").val(data.bloodGroup);
            $("#Religion").val(data.religion);
            $("#BasicSalary").val(data.basicSalary);
            $("#Gender").val(data.gender);
            $("#MeritialStatus").val(data.meritialStatus);
            $("#PhoneNumber").val(data.phoneNumber);
            $("#Email").val(data.email);
            $("#DepartmentId").val(data.departmentId);
            $("#Position").val(data.position);
            $("#DesignationId").val(data.designationId);
            $("#JobJoiningDate").val(data.jobJoiningDate);
        });
}

$(document.body).on("click",
    ".js-edit",
    function () {
        refressForm();
        var button = $(this);
        var id = button.attr("data-id");
        getData(id);
    });


$(document.body).on("click", ".js-delete", function () {
    var button = $(this);
    var id = button.attr("data-id");
    bootbox.confirm("Are You Delete This Data?",
        function (result) {
            if (result) {
                $.ajax({
                    url: "/api/GeneralInformations/" + id,
                    method: "DELETE",
                    success: function () {
                        button.parents("tr").remove();
                        toastr.success("Delete Success");
                    },
                    error: function (request, status, error) {
                        var response = jQuery.parseJSON(request.responseText);
                        toastr.error(response.message, "Error");
                    }
                });
            }
        });
});

