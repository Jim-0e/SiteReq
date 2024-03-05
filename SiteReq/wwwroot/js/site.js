// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const app = document.querySelector('h1')

app.style.color = 'red'


const apps = document.querySelector('.wrapper')




fetch('https://api.github.com/search/repositories?q=subject')
 .then(data => console.log(data))
