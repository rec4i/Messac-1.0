$(document).ready(function () {

    
    $('input[id=Giriş]').click(function () {
        $.ajax(
            {
                type: "POST",
                url: '/api/Users/authenticate',
                contentType: "application/json; charset=utf-8",
                data: '{"Username":"'+  $('input[id=Kullanıcı_Ad]').val() +'" ,"Password":"'+ $('input[id=Kullanıcı_Şifre]').val()+'"}'  ,
                success: function (response) {
                    console.log(response.role)
                    if(response.role=="Admin"){
                        window.location.href = '/Anasayfa';
                    }
                    if(response.role=="User"){
                        window.location.href = '/Anasayfa';
                    }
                    if(response.role=="il"){
                        window.location.href = '/Anasayfa';
                    }
                    if(response.role=="İlçe"){
                        window.location.href = '/Anasayfa';
                    }
                   
                },
                error: function (data) {
                    console.log(data);
                }
            }
        );
    })


})