var dateMatch = document.getElementById("dateTag").value;
var club = document.getElementById("listeClub").value;
var divison = document.getElementById("listeDiv").value;
var arbitre = document.getElementById("listeArb").value;



document.getElementById("dateTag").onselect =
    function () {
        var listId = [];
        var listIndispo = $('.indisponible');
        listIndispo.each(function () {
            listId.push(this.id);
        });
      
        var x = {};
        x.Nom = $('#nom')[0].value;
        x.Prenom = $('#prenom')[0].value;
        x.DateNaissance = $('#dateNaissance')[0].value;
        x.Club = $('#club')[0].value;
        x.Niveau = $('#niveau')[0].value;
        x.Numero = $('#numero')[0].value;
        x.Voie = $('#voie')[0].value;
        x.CodePostal = $('#codePostal')[0].value;
        x.Ville = $('#ville')[0].value;
        x.Telephone = $('#telephone')[0].value;
        x.Courriel = $('#courriel')[0].value;
        x.ListIndispo = listId;



        $.ajax(
            {
                url: 'http://localhost:55189/NouvelArbitre/AjouterArbitre',
                type: 'POST',
                data: JSON.stringify({ formulaire: x }),
                contentType: "application/json; charset=utf-8",
                //contentType: "application/x-www-form-urlencoded; charset=UTF-8",
                //dataType: 'json',
                success: function (data, status) {
                    alert(data);
                },
                error: function (resultat, status, error) { alert(resultat.responseText); },
                complete: function () { },

            }
        );
    };