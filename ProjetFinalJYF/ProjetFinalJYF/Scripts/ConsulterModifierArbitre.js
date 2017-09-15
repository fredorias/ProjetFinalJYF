
$('#BtNiveau').on('click', function () {
    var data = {};//les données du coté serveur, controller.cs

    data.Federal = document.getElementById('cb_Federal').checked;
    data.Stagiaire = document.getElementById('cb_Stagiaire').checked;
    data.ACF = document.getElementById('cb_ACF').checked;
    data.Territorial = document.getElementById('cb_Territorial').checked;
    data.PreFederal = document.getElementById('cb_PreFederal').checked;
    $.ajax({
        url: "http://localhost:55189/ConsulterModifierArbitre/ConsulterModifier",
        type: 'Get',
        contentType: 'application/json; charset=UTF-8',
        datatype: 'json',
        data: data, //data coté client qu'on a ci-dessous
        success: function (data, status) {

            var html = '<table id="tableau"><caption>Liste des Arbitres</caption><tr class="nomColonne"><th>Nom</th><th>Prenom</th><th>NiveauArbitre</th><th>Club</th><th>Téléphone</th><th>Adresse</th><th>DDN</th><th>Modifier</th><th>Supprimer</th></tr>';
            for (i = 0; i < data.length; i++) {
                html += '<tr><td>' + data[i].Nom + '</td><td>' + data[i].Prénom + '</td><td>' + data[i].NiveauArbitre + '</td><td>'
                    + data[i].Club + '</td><td>' + data[i].Téléphone + '</td><td>' + data[i].Adresse + '</td><td>' + data[i].DDN + '</td><td>' +
                    '<input type="button" id="modifierArbitre" onclick="modifierArbitre()" style="color: green;" value="Modifier" />' + '</td><td>' +
                    '<input type="button" style="background: url(Images/images.png)" id="supprimerArbitre" onclick="supprimerArbitre()" />' + '</td></tr>';
            }
            //<input type="button" id="supprimerArbitre" onclick="supprimerArbitre()" style="color: red;" value="Supprimer" />

            html += '</table>';
            $('#tableauDiv').html(html);

        },
        Error: function (resultat, status, error) { $('#test').html(error); }
    });
    //$('#tableau').css('background-color', 'orange');
});

