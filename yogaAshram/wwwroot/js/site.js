// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


showInPopup = (url, title) => {
    $.ajax({
        type: 'GET',
        url: url,
        success: function (res) {
            $('#form-modal2 .modal-body').html(res);
            $('#form-modal2 .modal-title').html(title);
            $('#form-modal2').modal('show');
        }
    })
}

jQueryAjaxPost = form => {
    try {
        $.ajax({
            type: 'POST',
            url: form.action,
            data: new FormData(form),
            contentType: false,
            processData: false,
            success: function (res2) {
                if (res2.isValid) {
                    $('#view-all').html(res2.html)
                    $('#form-modal2 .modal-body').html('');
                    $('#form-modal2 .modal-title').html('');
                    $('#form-modal2').modal('hide');
                }
                else
                    $('#form-modal2 .modal-body').html(res2.html);
            },
            error: function (err) {
                console.log(err)
            }
        })
        //to prevent default form submit event
        return false;
    } catch (ex) {
        console.log(ex)
    }
}



function openBranch(branchId) {
    $('#branchDetails-' + branchId).toggle('slow', function () {
        if ($('#branchDetails-' + branchId).css('display') !== 'none') {
            $('#branchButton-' + branchId).text("Скрыть");
        }
        else if ($('#branchDetails-' + branchId).css('display') !== 'block') {
            $('#branchButton-' + branchId).text("Открыть");
        }
    });
}

function openName(positionId) {
    $('#divName-' + positionId).toggle('slow', function () {
        var name = $('#nameValue-' + positionId).text();
        $('#nameInput-' + positionId).val(name);
    });
}


function editName(postId) {
    $.ajax({
        url : '@Url.Action("Edit", "Branch")',
        type : 'POST',
        data : {
            'id' : postId,
            'name' : $("#nameInput-" + postId).val()
        },
        success: setTimeout(function(){
            $("#nameReload-" + postId).load(" #nameReload-" + postId);
            $("#namePosition-" + postId).load(" #namePosition-" + postId);
            $("#centerReload-" + postId).load(" #centerReload-" + postId);
        }, 900)
    })
}

function openAddress(positionId) {
    $('#divAddress-' + positionId).toggle('slow', function () {
        var address = $('#addressValue-' + positionId).text();
        $('#addressInput-' + positionId).val(address);
    });
}


function editAddress(postId) {
    $.ajax({
        url : '@Url.Action("Edit", "Branch")',
        type : 'POST',
        data : {
            'id' : postId,
            'address' : $("#addressInput-" + postId).val()
        },
        success: setTimeout(function(){
            $("#addressReload-" + postId).load(" #addressReload-" + postId);
        }, 900)
    })
}

function openInfo(positionId) {
    $('#divInfo-' + positionId).toggle('slow', function () {
        var info = $('#infoValue-' + positionId).text();
        $('#infoInput-' + positionId).val(info);
    });
}


function editInfo(postId) {
    $.ajax({
        url : '@Url.Action("Edit", "Branch")',
        type : 'POST',
        data : {
            'id' : postId,
            'info' : $("#infoInput-" + postId).val()
        },
        success: setTimeout(function(){
            $("#infoReload-" + postId).load(" #infoReload-" + postId);
        }, 900)
    })
}




function openAdmin(branchId) {
    $('#divAdmin-' + branchId).toggle('slow', function() {

    });
}



function editSeller(postId) {
    $.ajax({
        url : '@Url.Action("Edit", "Branch")',
        type : 'POST',
        data : {
            'id' : postId,
            'adminId' : $("#adminId-" + postId).val()
        },
        success: setTimeout(function(){
            $("#adminReload-" + postId).load(" #adminReload-" + postId);
        }, 900)
    })
}


$("#changePasswordBtn").on("click", function () {
    $("#changePasswordModal").modal('show');
})

var adminIds =  $('#adminIdArray').text();
$.each(adminIds.split(' '), function(index, value) {
    $('select > option').filter(function () {
        return $(this).val() == value
    }).prop('disabled', true)
});


function validateAdmin(adminId){
    var e = document.getElementById("adminId-"  + adminId);
    var value = e.options[e.selectedIndex].value;

    if (value === "no") {
        $('#submitBtn-' + adminId).prop('disabled', true);

    }
    else {
        $('#submitBtn-'+ adminId).prop('disabled', false);
    }
}



function validateAdminIds(){
    var e = document.getElementById("adminId");
    var value = e.options[e.selectedIndex].value;
    console.log(value);
    if (value === "no") {
        $('#send').prop('disabled', true);

    }
    else {
        $('#send').prop('disabled', false);
    }
}



