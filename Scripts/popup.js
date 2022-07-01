function openPopup() {
    $("body").addClass("showPopup");
}
function closePopup() {
    $("body").removeClass("showPopup removePopup");
}
function closePopupScreen() {
    $("body").addClass("removePopup");
    setTimeout(closePopup, 200);
}

$(".popup .close").on("click", function () {
    closePopupScreen();
});

// auto open popup
openPopup();
// setTimeout(openPopup, 1000);

// close popup
$(document).keyup(function (e) {
    if (e.key === "Escape") {
        closePopup();
    }
});
