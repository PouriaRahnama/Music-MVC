function DeleteSinger(singerId) {
    $.get("/Admin/Singer/Delete/" + singerId).done(function (res) {
        if (res.status === "Done") {
            location.reload();
        } else {
            alert(res.status);
        }
    });

};

function ReturnSinger(singerId) {
    $.get("/Admin/Singer/Return/" + singerId).done(function (res) {
        if (res.status === "Done") {
            location.reload();
        } else {
            alert(res.status);
        }
    });
};



//function DeleteSong(songId) {
//    $.get("/Admin/Song/Delete/" + songId).done(function (res) {
//        if (res.status === "Done") {
//            location.reload();
//        } else {
//            alert(res.status);
//        }
//    });

//};

//function ReturnSong(songId) {
//    $.get("/Admin/Song/Return/" + songId).done(function (res) {
//        if (res.status === "Done") {
//            location.reload();
//        } else {
//            alert(res.status);
//        }
//    });
//};