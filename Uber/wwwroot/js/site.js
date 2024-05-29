
document.onreadystatechange = (event) => {
    document.getElementById("find-me").addEventListener("click", findMe);
};
function findMe() {
    const status = document.getElementById("status");
    function success(position) {
        const latitude = position.coords.latitude;
        const longitude = position.coords.longitude;

        document.getElementById("latitude").value = latitude;
        document.getElementById("longitude").value = longitude;

        status.textContent = `Latitude: ${latitude} °, Longitude: ${longitude} °`;
    }

    function error() {
        status.textContent = "Unable to retrieve your location";
    }

    if (!navigator.geolocation) {
        status.textContent = "Geolocation is not supported by your browser";
    } else {
        status.textContent = "Locating…";
        navigator.geolocation.getCurrentPosition(success, error);
    }
}
