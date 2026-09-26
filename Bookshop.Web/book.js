const urlParams = new URLSearchParams(window.location.search);
const id = urlParams.get("id");

console.log(id);

fetch("https://localhost:7059/books/" + id)
  .then((response) => response.json())
  .then((data) => {
    console.log(data);
    const titleElement = document.getElementById("title");
    const authorElement = document.getElementById("author");
    const descriptionElement = document.getElementById("description");
    const imageElement = document.getElementById("image");

    titleElement.innerText = data.title;
    authorElement.innerText =
      data.author.firstName + " " + data.author.lastName;
    descriptionElement.innerText = data.description;
    imageElement.src = data.image;

    document.querySelector(".author").addEventListener("click", (x) => {
      window.location.href = "/author/author.html?id=" + data.author.id;
    });
  });

function backButtonClicked() {
  //window.history.back();
  window.location.href = "/index.html";
}
