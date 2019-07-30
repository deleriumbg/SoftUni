function githubRepos() {
    $('#repos').empty();
    $.ajax({
        method: 'GET',
        url: `https://api.github.com/users/${$('#username').val()}/repos`,
        success: handleSuccess,
        error: handleError
    });

    function handleSuccess(res) {
        for (let repo of res) {
            $('<li>').append($(`<a href="${repo.html_url}">${repo.full_name}</a>`)).appendTo($('#repos'));
        }
    }
    function handleError(err) {
        console.error(err);
    }
}