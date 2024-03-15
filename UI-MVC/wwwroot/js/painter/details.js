window.onload = function () { LoadData(); LoadPaintings(); };


const btn = document.getElementById('addPaintingtoPainter');
if (btn)
    btn.addEventListener('click', (event) => AddPaintingToPainter());


function LoadPaintings() {
    const urlParams = new URLSearchParams(window.location.search);
    const myParam = urlParams.get('id');
    fetch("https://localhost:7118/api/Paintings?id=" + myParam, {
        method: "GET",
        headers: {
            "Accept": "application/json"
        }
    })
        .then(response => response.json())
        .then(data => bindData(data))
        .catch(reason => alert("Call failed: " + reason));
}
function bindData(data) {
    $('[name = "paintingid"]').html("");
    for (let i = 0; i < data.length; i++) {
        let opt = new Option(data[i].text, data[i].value);
        $('#paintingselect').append(opt);
    }
}
function LoadData() {
    const urlParams = new URLSearchParams(window.location.search);
    const myParam = urlParams.get('id');
    $.ajax({
        type: "Get",
        url: 'ReloadData',
        data: "id=" + myParam,
        success: function (result) {
            debugger
            if (result != null) {
                $("#paintingTableBody").html(result);
                LoadPaintings();
                $('#isSigned').prop('checked', false);
            }
        },
        error: function () {

        }
    });
}
function AddPaintingToPainter() {
    debugger;
    const urlParams = new URLSearchParams(window.location.search);
    const painterId = urlParams.get('id');
    let valdata = $("#paintingform").serialize();
    $.ajax({
        type: "Get",
        url: 'https://localhost:7118/api/Paintings/AddPainting',
        data: 'painterid='+painterId+'&'+valdata,
        success: function (result) {
            LoadData();
        },
        error: function () {
            alert("Error while adding data");
        }
    });
}