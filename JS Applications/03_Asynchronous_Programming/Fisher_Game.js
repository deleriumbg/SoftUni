function attachEvents() {
    const baseUrl = "https://baas.kinvey.com/appdata/kid_ByWBhnTGH/biggestCatches";
    const username = "guest";
    const password = "guest";
    const headers = {"Authorization":`Basic ${btoa(username + ":" + password)}}`,
                     "Content-Type": "application/json"};

    $('.load').click(loadCatches);
    $('.add').click(addCatch);

    function loadCatches() {
        let request = {
            url: baseUrl,
            method: "GET",
            headers: headers
        };

        $.ajax(request)
            .then(displayCatches);

        function displayCatches(catches) {
            $('#catches').empty();

            for(let c of catches){
                $('#catches')
                    .append($('<div>').addClass("catch").attr("data-id", c._id)
                        .append($('<label>').text("Angler"))
                        .append($('<input>').attr("type", "text").addClass("angler").val(c.angler))
                        .append($('<label>').text("Weight"))
                        .append($('<input>').attr("type", "number").addClass("weight").val(c.weight))
                        .append($('<label>').text("Species"))
                        .append($('<input>').attr("type", "text").addClass("species").val(c.species))
                        .append($('<label>').text("Location"))
                        .append($('<input>').attr("type", "text").addClass("location").val(c.location))
                        .append($('<label>').text("Bait"))
                        .append($('<input>').attr("type", "text").addClass("bait").val(c.bait))
                        .append($('<label>').text("Capture Time"))
                        .append($('<input>').attr("type", "number").addClass("captureTime").val(c.captureTime))
                        .append($('<button>').addClass("update").text("Update").click(updateCatch))
                        .append($('<button>').addClass("delete").text("Delete").click(deleteCatch))
                    );
            }
        }
    }

    function addCatch() {
        let inputs = $(this).parent().find('input');

        let request = {
            url: baseUrl,
            method: "POST",
            headers: headers,
            data: JSON.stringify({
                angler: $(inputs[0]).val(),
                weight: Number($(inputs[1]).val()),
                species: $(inputs[2]).val(),
                location: $(inputs[3]).val(),
                bait: $(inputs[4]).val(),
                captureTime: Number($(inputs[5]).val())
            })
        };

        $.ajax(request)
            .then(loadCatches);

        for(let input of inputs){
            $(input).val('');
        }
    }

    function updateCatch() {
        let inputs = $(this).parent().find('input');
        let catchId = $(this).parent().attr('data-id');

        let request = {
            url: baseUrl + "/" + catchId,
            method: "PUT",
            headers: headers,
            data: JSON.stringify({
                angler: $(inputs[0]).val(),
                weight: $(inputs[1]).val(),
                species: $(inputs[2]).val(),
                location: $(inputs[3]).val(),
                bait: $(inputs[4]).val(),
                captureTime: $(inputs[5]).val()
            })
        };

        $.ajax(request)
            .then(loadCatches)
    }

    function deleteCatch() {
        let catchId = $(this).parent().attr('data-id');

        let request = {
            url: baseUrl + "/" + catchId,
            method: "DELETE",
            headers: headers
        };

        $.ajax(request)
            .then(loadCatches)
    }
}