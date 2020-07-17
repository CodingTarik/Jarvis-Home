
function refreshDevice() {


    $.ajax({ type: "GET", dataType: "json", url: location.origin + "/api/devicestatus/", success: success });

}

function success(data) {

    console.log(data[1].onlineStatus);
    
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
                    document.getElementById(id).value = "Ausschalten";
                }
                else {
                    var id = "(" + data[i].name + data[i].deviceFunctions[k].functionID + ")" + "card";
                    document.getElementById(id).className = "card text-white bg-danger mb-3";
                    var id = "(" + data[i].name + data[i].deviceFunctions[k].functionID + ")" + "button";
                    document.getElementById(id).className = "btn btn-success";
                    document.getElementById(id).value = "Einschalten";
                }



            }
        }

    }

}

refreshDevice();