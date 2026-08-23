const urlParams = new URLSearchParams(window.location.search);
const id = urlParams.get("id");

console.log(id);

fetch("http://localhost:8000/authors/" + id)
  .then((response) => response.json())
  .then((data) => {
    console.log(data);
    const authorImageElement = document.getElementById("authorImage");
    const authorDescriptionElement = document.getElementById("authorDescription");
    const authorBooksNumberElement = document.getElementById("authorBooksNumber");


    authorImageElement.src = data.image;
    authorDescriptionElement.innerText = data.name;
    authorBooksNumberElement.innerText = data.books;

  })