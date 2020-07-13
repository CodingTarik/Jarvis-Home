
window.setInterval(refreshDevice,
    5000
);

function refreshDevice() {
    var elements = document.getElementsByClassName("devicename");
    for (let item of elements) {
        RefreshDeviceStatus(item.innerHTML);
    }

}
function RefreshDeviceStatus(devicename) {
    console.log("Refreshing status for: " + devicename);
    $.ajax({ type: "GET", dataType: "json", url: location.origin+"/api/devicestatus/" + devicename, success: success });
}

function success(data) {
    var spanElement = document.getElementById(data.name + "-status");
    console.log(data.onlineStatus);
    if (data.onlineStatus == false) {
        spanElement.className = "badge badge-danger";
        spanElement.innerHTML = "Offline";
    }
    else {
        spanElement.className = "badge badge-success";
        spanElement.innerHTML = "Online";
    }
}

refreshDevice();
