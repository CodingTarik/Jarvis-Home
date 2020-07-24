
function refreshDevice() {


    $.ajax({ type: "GET", dataType: "json", url: location.origin + "/api/devicestatus/", success: success });

}


function success(data) {

    for (i = 0; i < data.length; i++) {
        if (data[i].deviceFunctions != null) {
            for (k = 0; k < data[i].deviceFunctions.length; k++) {
                if (data[i].onlineStatus == true) {
                    var id = "(" + data[i].name + data[i].deviceFunctions[k].functionID + ")" + "card";
                    if (data[i].deviceFunctions[k].status == true) {
                        document.getElementById(id).className = "card text-white bg-success mb-3";
                        var id = "(" + data[i].name + data[i].deviceFunctions[k].functionID + ")" + "button";
                        document.getElementById(id).className = "btn btn-danger";
                        document.getElementById(id).value = "Ausschalten";
                    } else {
                        document.getElementById(id).className = "card text-white bg-danger mb-3";
                        var id = "(" + data[i].name + data[i].deviceFunctions[k].functionID + ")" + "button";
                        document.getElementById(id).className = "btn btn-success";
                        document.getElementById(id).value = "Einschalten";
                    }
                } else {
                    var id = "(" + data[i].name + data[i].deviceFunctions[k].functionID + ")" + "button";
                    document.getElementById(id).className = "btn btn-info";
                    document.getElementById(id).value = "OFFLINE";
                    document.getElementById(id).disabled = true;
                    var id = "(" + data[i].name + data[i].deviceFunctions[k].functionID + ")" + "card";
                    document.getElementById(id).className = "card text-white bg-danger mb-3";
                }
            }
        }
        if (data[i].onlineStatus == false) {
            var id = "(" + data[i].name + ")" + "head";
            document.getElementById(id).innerHTML = data[i].name + " (OFFLINE)";
        }
        if (data[i].sensors != null) {
            for (g = 0; g < data[i].sensors.length; g++) {
                var badge = document.getElementById("(" + data[i].sensors[g].sensorID + ")sensorcard");
                var sensorstatus = document.getElementById("(" + data[i].sensors[g].sensorID + ")sensorstatus");
                if (data[i].sensors[g].status == "ERROR") {
                    badge.className = "card text-white bg-danger mb-3";
                    sensorstatus.innerHTML = data[i].sensors[g].status + " (see console for more information)";
                    console.warn("Python-Error of sensor " + data[i].sensors[g].sensorname + " with id " + data[i].sensors[g].sensorID + ": " + data[i].sensors[g].pythonError);
                } else {
                    badge.className = "card text-white bg-success mb-3";
                    sensorstatus.innerHTML = data[i].sensors[g].status;
                }
            }
        }

    }

}

refreshDevice();
setInterval(refreshDevice, 3000);
