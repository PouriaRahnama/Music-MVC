function DeleteSlider(sliderId) {
    $.get("/Admin/Slider/Delete/" + sliderId).done(function (res) {
        if (res.status === "Done") {
            location.reload();
        } else {
            alert(res.status);
        }
    });

};

function ReturnSlider(sliderId) {
    $.get("/Admin/Slider/Return/" + sliderId).done(function (res) {
        if (res.status === "Done") {
            location.reload();
        } else {
            alert(res.status);
        }
    });
};