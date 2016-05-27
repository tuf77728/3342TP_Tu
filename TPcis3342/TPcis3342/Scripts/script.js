$(document).ready(function () {

    $('.chatHead').click(function () {
        $('.chatBody').slideToggle('slow');
    });

    $('.messageHead').click(function () {
        $('.messageWrap').slideToggle('slow');
    });

    $(".close").click(function () {
        $('.messageBox').hide();
    });

    $(".chatUser").click(function () {
        $('.messageWrap').show();
        $('.messageBox').show();
    });

    $('#txtMessageInput').keypress(
        function (e) {
            if (e.keyCode == 13) {
                var message = $(this).val();
                $(this).val('');
                    if(message!='')
                        $("<div class='messageInput1'>" + message + "</div>").insertBefore('.messageInsert');
                        $('.messageBody').scrollTop($('.messageBody')[0].scrollHeight);
            }
        });
});