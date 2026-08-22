const urlParams = new URLSearchParams(window.location.search);
const id = urlParams.get("id");

console.log(id);

fetch("http://localhost:8000/books/" + id)
  .then((response) => response.json())
  .then((data) => {
    console.log(data);
    const titleElement = document.getElementById("title");
    const authorElement = document.getElementById("author");
    const descriptionElement = document.getElementById("description");
    const imageElement = document.getElementById("image");

    titleElement.innerText = data.title;
    authorElement.innerText = data.author;
    descriptionElement.innerText = data.description;
    imageElement.src = data.image;
  });

