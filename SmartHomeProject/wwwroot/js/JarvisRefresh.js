
function refreshDevice() {


    $.ajax({ type: "GET", dataType: "json", url: location.origin + "/api/devicestatus/", success: success });

}


function success(data) {


    
    for (i = 0; i < data.length; i++) {
        

        if (data[i].deviceFunctions == null) {

        }
        else {
            for (k = 0; k < data[i].deviceFunctions.length; k++) {
                


                if (data[i].deviceFunctions[k].status == true) {
                    if (data[i].onlineStatus == false) {
                        var id = "(" + data[i].name + data[i].deviceFunctions[k].functionID + ")" + "button";
                        document.getElementById(id).className = "btn btn-info";
                        document.getElementById(id).value = "OFFLINE";
                        document.getElementById(id).disabled = true;
                        var id = "(" + data[i].name + data[i].deviceFunctions[k].functionID + ")" + "card";
                        document.getElementById(id).className = "card text-white bg-danger mb-3";
                    }
                    else
                    {
                        var id = "(" + data[i].name + data[i].deviceFunctions[k].functionID + ")" + "card";
                        document.getElementById(id).className = "card text-white bg-success mb-3";
                        var id = "(" + data[i].name + data[i].deviceFunctions[k].functionID + ")" + "button";
                        document.getElementById(id).className = "btn btn-danger";
                        document.getElementById(id).value = "Ausschalten";
                    }

                }
                else {
                    var id = "(" + data[i].name + data[i].deviceFunctions[k].functionID + ")" + "card";
                    document.getElementById(id).className = "card text-white bg-danger mb-3";
                    if (data[i].onlineStatus == false) {
                        var id = "(" + data[i].name + data[i].deviceFunctions[k].functionID + ")" + "button";
                        document.getElementById(id).className = "btn btn-info";
                        document.getElementById(id).value = "OFFLINE";
                        document.getElementById(id).disabled = true;

                    }
                    else {
                        var id = "(" + data[i].name + data[i].deviceFunctions[k].functionID + ")" + "button";
                        document.getElementById(id).className = "btn btn-success";
                        document.getElementById(id).value = "Einschalten";
                    }

                }



            }

        }

        if (data[i].onlineStatus == false) {
            var id = "(" + data[i].name + ")" + "head";
            document.getElementById(id).innerHTML = data[i].name + " OFFLINE!!";


        }

    }

}

refreshDevice();