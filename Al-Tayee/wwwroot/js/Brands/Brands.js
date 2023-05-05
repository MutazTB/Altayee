//$(document).ready(function () {
//});
$(function () {
    alert();
    GetAllData();
});
function GetAllData() {
    alert();
    $.ajax({
        url: "/Brands/GetAllBrands",
        type: "GET",
                success: function (data) {
            swal("Success", data.Message, "success");
            $("#Add_Edit_Brand").slideup();
        },
        error: function (err) {
            swal('Oops...', 'Something went wrong!', 'error');
        }
    })
}