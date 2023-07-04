function DeleteUser(SliderId) {
    $.get("/Admin/User/Delete/" + SliderId).done(function (res) {
        if (res.status === "Done") {
            location.reload();
        } else {
            alert(res.status);
        }
    });

};

function ReturnUser(SliderId) {
    $.get("/Admin/User/Return/" + SliderId).done(function (res) {
        if (res.status === "Done") {
            location.reload();
        } else {
            alert(res.status);
        }
    });
};