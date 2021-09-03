// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function reply(id) {
    var form = document.getElementById("reply");
    form.style.display = "block";
    var comment = form.getElementsByTagName("textarea");
    var txt = comment.item(0);
    txt.value = `>>${id}
`
}

function close() {
    var form = document.getElementById("reply");
    form.style.display = "none";
}
