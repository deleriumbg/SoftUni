function attachEvents(){
    $('#btnLoadTowns').click(loadTowns);

    function loadTowns(){
        let towns = $('#towns').val().split(', ');

        // Compile template
        let template = $('#towns-template').html();
        let compiledTemplate = Handlebars.compile(template);

        // Create context
        let context = {
            towns
        };

        // Add to HTML
        $('#root').html(compiledTemplate(context));
    }
}