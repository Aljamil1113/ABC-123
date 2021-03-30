// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {

$((function () {
    var url;
    var redirectUrl;
    var target;

    $('body').append(`
                    <div class="modal fade" id="deleteModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
                    <div class="modal-dialog" role="document">
                        <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                            <h4 class="modal-title" id="myModalLabel"></h4>
                        </div>
                        <div class="modal-body delete-modal-body">
                            
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default" data-dismiss="modal" id="cancel-delete">Cancel</button>
                            <button type="button" class="btn btn-danger" id="confirm-delete">Delete</button>
                        </div>
                        </div>
                    </div>
                    </div>`);

    //Delete Action
    $(".delete").on('click', (e) => {
        e.preventDefault();

        target = e.target;
        var Id = $(target).data('id');
        var controller = $(target).data('controller');
        var action = $(target).data('action');
        var bodyMessage = $(target).data('body-message');
        redirectUrl = $(target).data('redirect-url');

        url = "/" + controller + "/" + action + "?id=" + Id;
        $(".delete-modal-body").text(bodyMessage);
        $("#deleteModal").modal('show');
    });

    $("#confirm-delete").on('click', () => {
        $.get(url)
            .done((result) => {
                if (!redirectUrl) {
                    return $(target).parent().parent().hide("slow");
                }
                window.location.href = redirectUrl;
            })
            .fail((error) => {
                if (redirectUrl)
                    window.location.href = redirectUrl;
            }).always(() => {
                $("#deleteModal").modal('hide');
            });
    });

}()));




    jQueryAjaxDelete = form => {
        if (confirm('Are you sure to delete this record ?')) {
            try {
                $.ajax({
                    type: 'POST',
                    url: form.action,
                    data: new FormData(form),
                    contentType: false,
                    processData: false,
                    success: function (res) {
                        location.reload(true);
                        //$('#viewAll').html(res.html);
                        //table.parents('tr').remove();
                    },
                    error: function (err) {
                        console.log(err)
                    }
                })
            } catch (ex) {
                console.log(ex)
            }
        }

        //prevent default form submit event
        return false;
    }






});