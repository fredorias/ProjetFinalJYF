$('#sourceMatch').on('click', function () {
    $.ajax({
        url: "http://localhost:55189/Calendrier/SourceMatch",
        type: 'Get',
        contentType: 'application/json; charset=UTF-8',
        datatype: 'json'
        ,
        success: function (data, status) {
            console.log(data);
            alert(data);
            setTimeout("location.reload(true);", 0);//recharge la page à la fin de la méthode
        },
        error: function (resultat, status, error) { console.log(error); alert('erreur'); }
    });

});