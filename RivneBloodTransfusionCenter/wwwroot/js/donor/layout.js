const body = document.querySelector("body"),
    sidebar = body.querySelector("nav.sidebar"),
    navbar = body.querySelector(".navbar");

const toggleNavbarShift = () => {
    navbar.classList.toggle(
        "shifted",
        !sidebar.classList.contains("close")
    );
};

const toggleSidebar = () => {
    sidebar.classList.toggle("close");
    toggleNavbarShift();
};

document
    .querySelector(".toggle")
    .addEventListener("click", toggleSidebar);

document.querySelector(".search-box").addEventListener("click", () => {
    sidebar.classList.remove("close");
    toggleNavbarShift();
});

document.querySelector(".toggle-switch").addEventListener("click", () => {
    body.classList.toggle("dark");
    if (body.classList.contains("dark")) {
        modeText.innerText = "Light mode";
    } else {
        modeText.innerText = "Dark mode";
    }
});
window.addEventListener("resize", toggleNavbarShift);

document.addEventListener("DOMContentLoaded", function () {
    const navLinks = document.querySelectorAll(".nav-links a");

    navLinks.forEach((link) => {
        link.addEventListener("click", () => {
            navLinks.forEach((otherLink) => {
                otherLink.style.borderBottom = "none";
            });
            link.style.borderBottom = "2px solid var(--primary-color)";
        });
    });
});
document.addEventListener("DOMContentLoaded", function () {
    const menuLinks = document.querySelectorAll(".menu-links a");

    menuLinks.forEach((link) => {
        link.addEventListener("click", () => {
            menuLinks.forEach((otherLink) => {
                otherLink.style.borderBottom = "none";
            });
            link.style.borderBottom = "2px solid var(--primary-color)";
        });
    });
});