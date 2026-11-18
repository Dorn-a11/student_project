
$(document).ready(function () {
    getAllDegree();
});
const tblDegree = $("#tblDegree");
const degreeModal = $("#modalDegree");
const frmDegree = $("#frmDegree");
function getAllDegree() {
  $("#tblDegree").DataTable({
        processing: true,
        serverSide: true,

        ajax: {
            url: "/api/Degree/paging",
            type: "POST",
            dataSrc: function (json) {
                console.log("Full Data : ", json);
                return json.data
            }
        },
        columns: [
            { data: 'id' },
            { data: 'nameEnglish' },
            { data: 'nameKhmer' },
            {
                data: null,
                orderable: false,
                searchable: false,
                render: function (data, type, row) {
                    console.log("Data:", data);
                    console.log("Type:", type);
                    console.log("Row:", row);
                    return `<a type="button" id="btnEdit" class="btn btn-warning btn-sm"><i class="fas fa-edit"></i> Edit</a>
                            <a type="button" id="btnDelete" class="btn btn-danger btn-sm"><i class="fas fa-trash"></i> Delete</a>
                    `;
                }
            }
        ],
        pageLength:10
    });


};


$("#btnNew").on("click", function (e) {
    e.preventDefault();
    $("#frmDegree").trigger("reset");
    $("#id").val(0);
    degreeModal.find(".modal-title").text("Create New Degree");
    $("#btnSubmit").text("Create");
    degreeModal.modal("show");
});

tblDegree.on("click", "#btnEdit", function (e) {
    e.preventDefault();
    const row = $(this).closest("tr");
    const selectRow = tblDegree.DataTable().row(row).data();
    $("#Id").val(selectRow.id);
    $("#NameEnglish").val(selectRow.nameEnglish);
    $("#NameKhmer").val(selectRow.nameKhmer);
    degreeModal.find(".modal-title").text("Update Degree");
    $("#btnSubmit").text("Update");
    degreeModal.modal("show");
});


frmDegree.on("submit", function (e) {
    e.preventDefault();
    const frm = $(this);
    const formData = frm.serialize();
    console.log("Request to server : ", formData);

    $.ajax({
        url: "/api/Degree/save-change",
        type: "POST",
        data: formData,
        success: function (response) {
            console.log("Response From Server:", response);

            degreeModal.modal("hide");
            alert("Save successfully!");

            tblDegree.DataTable().ajax.reload();
        },

        error: function (xhr, status, error) {
            console.log("HTTP Status:", xhr.status);
            console.log("Status:", status);
            console.log("Error:", error);
            console.log("Response:", xhr.responseText);
        }

    });
});