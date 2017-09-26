/// <reference path="SupprimerArbitre.js" />
/// <reference path="SupprimerArbitre.js" />


$('#BtNiveau').on('click', function () {
    var dataClient = {};//les données du coté serveur, controller.cs


    dataClient.TextNom = document.getElementById('nom').value;
    dataClient.TextClub = document.getElementById('club').value;
    dataClient.Touslesniveaux = document.getElementById('cb_Tous').checked;
    dataClient.Federal = document.getElementById('cb_Federal').checked;
    dataClient.Stagiaire = document.getElementById('cb_Stagiaire').checked;
    dataClient.ACF = document.getElementById('cb_ACF').checked;
    dataClient.Territorial = document.getElementById('cb_Territorial').checked;
    dataClient.PreFederal = document.getElementById('cb_PreFederal').checked;

    $.ajax({
        url: "http://localhost:55189/ConsulterModifierArbitre/Afficher",
        type: 'Get',
        contentType: 'application/json; charset=UTF-8',
        datatype: 'json'
        ,
        data: dataClient, //data coté client qu'on a ci-dessous
        success: function (data, status) {

            var html = '<table id="tableau" class="table"><caption>Liste des arbitres</caption><tr class="nomColonne"><th>Nom</th><th>Prenom</th><th>NiveauArbitre</th><th>Club</th><th>Téléphone</th><th>Adresse</th><th>Modifier</th><th>Supprimer</th></tr>';
            for (i = 0; i < data.length; i++) {
                html += '<tr><td>' + data[i].Nom + '</td><td>' + data[i].Prenom + '</td><td>' + data[i].NiveauArbitre + '</td><td>'
                    + data[i].Club + '</td><td>' + data[i].Telephone + '</td><td>' +
                     (data[i].AdresseArb == null?"":data[i].AdresseArb.Ville) +
                    '</td><td>' +
                    '<a id="modifierArbitre" onclick="modifierArbitre()" style="color: lightgreen;" href="/NouvelArbitre/EditerArbitre/' + data[i].ArbitreId + '">Modifier</a>' + '</td><td>' +
                    '<a "id="supprimerArbitre" onclick="supprimerArbitre()" style="color: red" style="cursor: pointer"; href="/ConsulterModifierArbitre/supprimerArbitre/' + data[i].ArbitreId + '">Supprimer</a>' + '</td></tr>';

            }

            html += '</table>';
            $('#tableauDiv').html(html);
        },
        error: function (resultat, status, error) { alert('erreur'); }
    });
    //$('#tableau').css('background-color', 'orange');
});

$('#cb_Tous').on('change', function () {

    if (this.checked == true) {
        initCb(true);
    }
    else {
        initCb(false);
        ;
    }

})
function initCb(value) {
    document.getElementById('cb_Federal').checked = value;
    document.getElementById('cb_Stagiaire').checked = value;
    document.getElementById('cb_ACF').checked = value;
    document.getElementById('cb_Territorial').checked = value;
    document.getElementById('cb_PreFederal').checked = value;

    document.getElementById('cb_Federal').disabled = value;
    document.getElementById('cb_Stagiaire').disabled = value;
    document.getElementById('cb_ACF').disabled = value;
    document.getElementById('cb_Territorial').disabled = value;
    document.getElementById('cb_PreFederal').disabled = value;
}





