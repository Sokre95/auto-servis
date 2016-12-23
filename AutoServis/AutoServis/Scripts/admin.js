$(document).ready(function () {
    $("#korisnici").DataTable();
    $(".del").click(Delete);
});

function Delete() {
    var serviserId = $(this).data("serviser-id");
    var url = "/Admin/Izbrisi/" + serviserId;
    $.ajax({
        method: "POST",
        url: url,
        success: function () {
            Refresh();
            alert("Serviser uspješno izbrisan.")
        },
        error: function () {
            alert("Nije moguce izbrisati servisera.")
        }
    });
}

function Refresh() {
    $("#modul-korisnici").load('/Admin/Osvjezi', function () {
        $('#korisnici').DataTable();
        $(".del").click(Delete);
    });
}