$(document)
    .ready(function() {
        $("#korisnici").DataTable();
        $(".del").click(Delete);
    });

function Delete(uloga) {
    var serviserId = $(this).data("serviser-id");
    var url = "/Admin/Izbrisi/" + serviserId;
    $.ajax({
        method: "POST",
        url: url,
        success: function() {
            Refresh();
            alert("Brisanje " + uloga + " uspješno.");
        },
        error: function() {
            alert("Neuspješno brisanje " + uloga);
        }
    });
}