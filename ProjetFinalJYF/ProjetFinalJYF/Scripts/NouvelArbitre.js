function convertCodeToDate(code) {
    // Compute parts
    var parts = code.split('_');
    var weekDay = parts[1] == 'S' ? 6 : 0;

    // Premier jour du mois
    var aujourdhui = new Date();
    var maxOccurence = parts[2];
    var mois = parts[0] - 1;
    var annee = aujourdhui.getFullYear() + parseInt(parts[3]);
    var leJour = new Date(annee, mois, 1);

    // Contrôle
    if (mois < 0 || mois > 12) return null;

    var occurence = 0;
    var fin = false;
    while (!fin) {
        if (leJour.getDay() == weekDay) occurence++;
        if (occurence == maxOccurence) fin = true;
        else leJour.setDate(leJour.getDate() + 1);
        if (leJour.getMonth() != mois) return null;
    }
    return leJour;
}

function formatDate(d) {
    var j;
    switch (d.getDay()) {
        case 0: j = 'Dim'; break;
        case 6: j = 'Sam'; break;
        default: j = '???'; break;
    }
    return j + ' ' + d.getDate();
};

var tousLesTd = $('td[class*=journee]');

$(tousLesTd).each(function () {
    var td = $(this)[0];
    var d = convertCodeToDate(td.id);
    if (d == null) {
        td.innerText = ' ';
        $(this).removeClass('disponible');
    }
    else
        td.innerText = formatDate(d);


    td.addEventListener('click', function () {
        if ($(this).hasClass('disponible')) {
            $(this).removeClass('disponible');
            $(this).addClass('indisponible');
        }
        else {
            $(this).removeClass('indisponible');
            $(this).addClass('disponible');
        }
    });
});

document.getElementById('boutonValider').onclick =
    function () {
        var listId = [];
        var listIndispo = $('.indisponible');
        listIndispo.each(function () {
            listId.push(this.id);
        });
        //var formArbitreData =
        //        "{" +
        //"\"Nom\":\"" + $('#nom')[0].value + "\", " +
        //"\"Prenom\":\"" + $('#prenom')[0].value + "\", " +
        //"\"DateNaissance\":\"" + $('#dateNaissance')[0].value + "\", " +
        //"\"Club\":\"" + $('#club')[0].value + "\", " +
        //"\"Niveau\":\"" + $('#niveau')[0].value + "\", " +
        //"\"Numero\":\"" + $('#numero')[0].value + "\", " +
        //"\"Voie\":\"" + $('#voie')[0].value + "\", " +
        //"\"CodePostal\":\"" + $('#codePostal')[0].value + "\", " +
        //"\"Ville\":\"" + $('#ville')[0].value + "\", " +
        //"\"Telephone\":\"" + $('#telephone')[0].value + "\", " +
        //"\"Courriel\":\"" + $('#courriel')[0].value + "\"" +
        //"\"listIndispo\":" + listId + "" +
        //"}";
        var formArbitreData = JSON.stringify({
            "Nom": $('#nom')[0].value,
            "Prenom": $('#prenom')[0].value,
            "DateNaissance": $('#dateNaissance')[0].value,
            "Club": $('#club')[0].value,
            "Niveau": $('#niveau')[0].value,
            "Numero": $('#numero')[0].value,
            "Voie:": $('#voie')[0].value,
            "CodePostal": $('#codePostal')[0].value,
            "Ville": $('#ville')[0].value,
            "Telephone": $('#telephone')[0].value,
            "Courriel": $('#courriel')[0].value,
            "listIndispo": listId
        });

        $.ajax(
            {
                url: 'http://localhost:55189/NouvelArbitre/AjouterArbitre',
                type: 'POST',
                data: formArbitreData,
                contentType: 'application/json',
                dataType: 'json',
                success: function (data, status) {
                    alert(data);
                },
                error: function (resultat, status, error) { alert(resultat.responseText); },
                complete: function () { },

            }
        );
    };




