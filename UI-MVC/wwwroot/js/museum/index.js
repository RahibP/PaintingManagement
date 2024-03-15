const loadMuseumsBtn = document.getElementById('loadMuseums');

loadMuseums();

loadMuseumsBtn.addEventListener('click', loadMuseums);

function loadMuseums() {
    fetch("https://localhost:7118/api/museums", {
        method: "GET",
        headers: {
            "Accept": "application/json"
        }
    })
        .then(response => response.json())
        .then(data => showMuseums(data))
        .catch(reason => alert("The call to the API failed: " + reason + "."));
}

function showMuseums(museums) {
    const tableBody = document.getElementById('museumTableBody');
    tableBody.innerHTML = "";
    museums.forEach(museum => addMuseum(museum));
}

function addMuseum(museum) {
    const tableBody = document.getElementById('museumTableBody');
    
    tableBody.innerHTML += `
        <tr>
            <td>${museum.name}</td>
            <td>${museum.address}</td>
            <td>${museum.websiteUrl}</td>
        </tr>
    `;
}