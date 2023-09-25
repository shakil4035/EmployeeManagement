$(document).ready(function () {
    //Get Department
    $.get("/api/Universitys", function (data) {
        var $el = $("#UniversityId");
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
                $("#GenarelInformationId").val(data.id);
                $("#searchName").val(data.NameEnglish);
                $("#searchPhone").val(data.PhoneNumber);

                //loadHistoryTable(data.id);

            });

    }
});

$(document.body).on("click",
    "#btnSubmit",
    function () {
        var vm = {};
        var id = $("#Id").val();
        vm.examName = $("#ExamName").val();
        vm.genarelInformationId = $("#GenarelInformationId").val();
        vm.universityId = $("#UniversityId").val();
        vm.passingYear = $("#PassingYear").val();
        vm.subjectName = $("#SubjectName").val();
        vm.result = $("#Result").val();
        vm.schoolOrCollage = $("#SchoolOrCollage").val();
       
        if (id == "" || id == 0 || id == null) {
            $.ajax({
                url: "/api/Educations",
                data: vm,
                type: "POST",
                success: function (e) {
                    if (e > 0) {
                        toastr.success("Save Success", "Success!!!");
                        //loadHistoryTable(e);
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
                url: "/api/Educations/" + id,
                data: vm,
                type: "PUT",
                success: function (e) {
                    if (e > 0) {
                        toastr.success("Update Success", "Success!!!");
                        //loadHistoryTable(e);
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
    $("#ExamName").val('');
    $("#GenarelInformationId").val('');
    $("#UniversityId").val('');
    $("#PassingYear").val('');
    $("#SubjectName").val('');
    $("#Result").val('');
    $("#SchoolOrCollage").val('');
    
}
$(document.body).on("click",
    "#btnRefresh",
    function () {
        refressForm();
    })
