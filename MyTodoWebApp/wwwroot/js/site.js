$(document).ready(function()
{
    //wire up all the checkboxes to run markcompleted
    $('.done-checkbox').on('click', function(e)
    {
        markCompleted(e.Target);
    });
});

function markCompleted(checkbox)
{
    checkbox.disabled= true;

    var row = checkbox.closest('tr');
    $(row).addClass('done');

    var form = checkbox.closest('form');
    form.submit();
}