//$(document).ready(function () {
//    $('#sidebarCollapse').on('click', function () {
//        $('#sidebar').toggleClass('active');
//    });
//});
//let arrow = document.querySelectorAll(".arrow");
//for (var i = 0; i < arrow.length; i++) {
//    arrow[i].addEventListener("click", (e) => {
//        let arrowParent = e.target.parentElement.parentElement;//selecting main parent of arrow
//        arrowParent.classList.toggle("showMenu");
//    });
//}
//let sidebar = document.querySelector(".sidebar");
//let sidebarBtn = document.querySelector(".bx-menu");
//console.log(sidebarBtn);
//sidebarBtn.addEventListener("click", () => {
//    sidebar.classList.toggle("close");
//});
//let toggleBtn = document.querySelector(".toggle-btn");
//let sidebar = document.querySelector(".sidebar");

//toggleBtn.addEventListener("click", () => {
//    sidebar.classList.toggle("close");
//});
const body = document.querySelector('body'),
    sidebar = body.querySelector('nav'),
    toggle = body.querySelector(".toggle"),
    searchBtn = body.querySelector(".search-box"),
    modeSwitch = body.querySelector(".toggle-switch"),
    modeText = body.querySelector(".mode-text");
toggle.addEventListener("click", () => {
    sidebar.classList.toggle("close");
})
searchBtn.addEventListener("click", () => {
    sidebar.classList.remove("close");
})
modeSwitch.addEventListener("click", () => {
    body.classList.toggle("dark");
    if (body.classList.contains("dark")) {
        modeText.innerText = "Light mode";
    } else {
        modeText.innerText = "Dark mode";
    }
});