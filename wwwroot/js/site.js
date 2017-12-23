// Write your JavaScript code.
$(function() {
    $("#add-item-button").on("click", addItem);

    function addItem() {
        $("#add-item-error").hide();
        var newTitle = $("#add-item-title").val();

        $.post("/toDo/AddItem", {title : newTitle}, function(){
            window.location = "/toDo";
        })
        .fail(function(data){
            if (data && data.responseJSON) {
                var firstError = data.responseJSON[object.keys(data.responseJSON)[0]];
                $("#add-item-error").text(firstError);
                $("#add-item-error").show();
            }
        });
    }

    $(".done-checkbox").on("click", function(e) {
        markCompleted(e.target);
    });

    function markCompleted(checkbox) {
        checkbox.disabled = true;

        $.post("/toDo/MarkDone", {id : checkbox.name}, function() {
            var row = checkbox.parentElement.parentElement;
            $(row).addClass("done");
        });
    }
});