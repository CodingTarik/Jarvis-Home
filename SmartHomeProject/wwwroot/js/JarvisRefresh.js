
function refreshDevice() {


    $.ajax({ type: "GET", dataType: "json", url: location.origin + "/api/devicestatus/", success: success });


}

function success(data) {

    console.log(data);
    
    for (i = 0; i < data.length; i++) {

        if (data[i].deviceFunctions == null) {

        }
        else {
            for (k = 0; k < data[i].deviceFunctions.length; k++) {

               

                if (data[i].deviceFunctions[k].status == true) {
                    var id = "(" + data[i].name + data[i].deviceFunctions[k].functionID + ")" + "card";
                    document.getElementById(id).className = "card text-white bg-success mb-3";
                    var id = "(" + data[i].name + data[i].deviceFunctions[k].functionID + ")" + "button";
                    document.getElementById(id).className = "btn btn-danger";
                }
                else {
                    var id = "(" + data[i].name + data[i].deviceFunctions[k].functionID + ")" + "card";
                    document.getElementById(id).className = "card text-white bg-danger mb-3";
                    console.log(id);
                    var id = "(" + data[i].name + data[i].deviceFunctions[k].functionID + ")" + "button";
                    document.getElementById(id).className = "btn btn-success";
                }



            }
        }

    }

}

refreshDevice();