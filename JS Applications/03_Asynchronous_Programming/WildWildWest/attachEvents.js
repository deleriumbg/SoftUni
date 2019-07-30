function attachEvents() {
    const baseUrl = 'https://baas.kinvey.com/';
    const appKey = 'kid_B1n0E8cu4';
    const username = 'tanya';
    const password = '123456';
    const endpoint = 'players';
    const headers = {
        'Authorization': `Basic ${btoa(username + ':' + password)}`,
        'Content-Type': 'application/json' 
    };

    let allPlayers;
    let playerId;
    let selectedPlayer;

    loadGame();

    $('#reload').on('click', reload);
    $('#save').on('click', saveGame);
    $('#addPlayer').on('click', addPlayer);

    function loadGame(id) {
         $.ajax({
             url: baseUrl + 'appdata/' + appKey + '/' + endpoint,
             headers,
             method: 'GET'
         }).then((data) => {
             $('#players').empty();
             allPlayers = data;
             for (let player of data) {
                 let div = $(`
                <div class="player" data-id="${player._id}">
                    <div class="row">
                        <label>Name:</label>
                        <label class="name">${player.name}</label>
                    </div>
                    <div class="row">
                        <label>Money:</label>
                        <label class="money">${player.money}</label>
                    </div>
                    <div class="row">
                        <label>Bullets:</label>
                        <label class="bullets">${player.bullets}</label>
                    </div>
                </div>
            `);
                 let playBtn = $('<button class="play">Play</button>');
                 let deleteBtn = $('<button class="delete">Delete </button>');
                 playBtn.on('click', selectPlayer);
                 deleteBtn.on('click', deletePlayer);

                 div.append(playBtn);
                 div.append(deleteBtn);
                 $('#players').append(div);
             }

             $('#save').css('display', 'block');
             $('#reload').css('display', 'block');
             $('#canvas').css('display', 'block');

            if (id) {
                selectedPlayer = allPlayers.filter(player => player._id == id)[0];
            } else {
                selectedPlayer = allPlayers[0];
            }
            
            playerId = selectedPlayer._id;
            loadCanvas(selectedPlayer);
         }).catch(err => {
             console.log(err);
         })
    }

    function reload() {
        if (selectedPlayer.money >= 60) {
            selectedPlayer.money -= 60;
            selectedPlayer.bullets += 6;
        }
    }

    async function saveGame() {
        try {
            await $.ajax({
                url: baseUrl + 'appdata/' + appKey + '/' + endpoint + '/' + playerId,
                method: 'PUT',
                headers,
                data: JSON.stringify(selectedPlayer)
            })
        } catch(err) {
            console.log(err);
        }
    }

    async function addPlayer() {
        try {
            let name = $('#addName').val();
            console.log(name);
            await $.ajax({
                url: baseUrl + 'appdata/' + appKey + '/' + endpoint,
                method: 'POST',
                headers,
                data: JSON.stringify({
                    name,
                    bullets: 6,
                    money: 500
                })
            })
        } catch(err) {
            console.log(err);
        }

        allPlayers();
    } 

    function selectPlayer() {
        let id = $(this).parent().data('id');
        clearInterval(canvas.intervalId);
        loadGame(id);
    }

    async function deletePlayer() {
        let id = $(this).parent().data('id');
        try {
            await $.ajax({
                url: baseUrl + 'appdata/' + appKey + '/' + endpoint + '/' + id,
                method: 'DELETE',
                headers
            });
        } catch (err) {
            console.log(err);
        }
    }
}