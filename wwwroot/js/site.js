// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const hamBurger = document.querySelector(".toggle-btn");
//let isCollapsed = true;

$(function () {
    //if (localStorage.getItem('navbarstatus')) {
    //    document.querySelector("#sidebar").classList.remove("expand");
    //} else {
    //    document.querySelector("#sidebar").classList.add("expand");
    //}
    hamBurger.addEventListener("click", function () {
        document.querySelector("#sidebar").classList.toggle("expand");
        //if (isCollapsed) isCollapsed = true; else isCollapsed = false;
        //localStorage.setItem('navbarstatus', isCollapsed);
    });
});

