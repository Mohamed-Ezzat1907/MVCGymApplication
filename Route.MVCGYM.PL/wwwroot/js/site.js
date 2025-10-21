// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const body = document.body;
const toggleBtn = document.getElementById("darkToggle");
const icon = toggleBtn.querySelector("i");

// Load from localStorage
if (localStorage.getItem("darkMode") === "true") {
    body.classList.add("dark-mode");
    icon.classList.replace("bi-moon", "bi-sun");
}

toggleBtn.addEventListener("click", () => {
    body.classList.toggle("dark-mode");
    const isDark = body.classList.contains("dark-mode");
    localStorage.setItem("darkMode", isDark);
    icon.classList.toggle("bi-moon");
    icon.classList.toggle("bi-sun");
});