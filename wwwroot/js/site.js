// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


// Auto close the success alert after 2 seconds
$(document).ready(function () {
  setTimeout(function () {
    $("#Myalert").fadeOut("slow");
  }, 1500); // 1500 milliseconds = 1.5 seconds
});
