﻿

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

            var html = '<table id="tableau"><caption>Liste des Arbitres</caption><tr class="nomColonne"><th>Nom</th><th>Prenom</th><th>NiveauArbitre</th><th>Club</th><th>Téléphone</th><th>Adresse</th><th>DDN</th><th>Modifier</th><th>Supprimer</th></tr>';
            for (i = 0; i < data.length; i++) {
                html += '<tr><td>' + data[i].Nom + '</td><td>' + data[i].Prenom + '</td><td>' + data[i].NiveauArbitre + '</td><td>'
                    + data[i].Club + '</td><td>' + data[i].Telephone + '</td><td>' +
                     (data[i].AdresseArb == null?"":data[i].AdresseArb.Ville) +
                    '</td><td>' + data[i].DateNaissance + '</td><td>' +
                    '<a id="modifierArbitre" onclick="modifierArbitre()" style="color: green;" href="/NouvelArbitre/EditerArbitre/' + data[i].ArbitreId + '">Modifier</a>' + '</td><td>' +
                    '<a style="background: url(Images/images.png)" id="supprimerArbitre" onclick="supprimerArbitre()">Supprimer</a>' + '</td></tr>';
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

//document.getElementById('boutonEnregistre').onclick = // Bouton à créer
//    function () {
//        var listId = [];
//        var listIndispo = $('.indisponible');
//        listIndispo.each(function () {
//            listId.push(this.id);
//        });
        

//        var x = {};
//        x.Nom = $('#nom')[0].value;
//        x.Prenom = $('#prenom')[0].value;
//        x.DateNaissance = $('#dateNaissance')[0].value;
//        x.Club = $('#club')[0].value;
//        x.Niveau = $('#niveau')[0].value;
//        x.Numero = $('#numero')[0].value;
//        x.Voie = $('#voie')[0].value;
//        x.CodePostal = $('#codePostal')[0].value;
//        x.Ville = $('#ville')[0].value;
//        x.Telephone = $('#telephone')[0].value;
//        x.Courriel = $('#courriel')[0].value;
//        x.ListIndispo = listId;



//        $.ajax(
//            {
//                url: 'http://localhost:55189/NouvelArbitre/AjouterArbitre',
//                type: 'POST',
//                data: JSON.stringify({ formulaire: x }),
//                contentType: "application/json; charset=utf-8",
//                success: function (data, status) {
//                    alert("OK");
//                },
//                error: function (resultat, status, error) { alert(resultat.responseText); },
//                complete: function () { },

//            }
//        );
//    };


