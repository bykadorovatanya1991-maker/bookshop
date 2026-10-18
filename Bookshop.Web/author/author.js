const urlParams = new URLSearchParams(window.location.search);
const id = urlParams.get("id");

console.log(id);

fetch("https://localhost:6767/authors/" + id)
  .then((response) => response.json())
  .then((data) => {
    console.log(data);
    const authorImageElement = document.getElementById("authorImage");
    const authorNameElement = document.getElementById("authorName");

    const authorBornElement = document.getElementById("authorBorn");
    const authorDeadElement = document.getElementById("authorDead");
    const authorBiographyElement = document.getElementById("authorBiography");
    const authorBooksNumberElement =
      document.getElementById("authorBooksNumber");

    authorImageElement.src = "/" + data.image;
    authorNameElement.innerText = data.firstName + " " + data.lastName;
    authorBornElement.innerText = data.dateOfBirth;
    authorDeadElement.innerText = data.dateOfDeath;
    authorBiographyElement.innerText = data.biography;
    authorBooksNumberElement.innerText = `Available books: ${data.books.length}`;

    //author's books
    data.books.forEach((x) => {
      const authorBooksWrapperElement =
        document.getElementById("authorBooksWrapper");
      const imageTitleWrapperElement = document.createElement("div");
      const bookImageElement = document.createElement("img");
      const bookTitleElement = document.createElement("div");
      imageTitleWrapperElement.append(bookImageElement, bookTitleElement);

      imageTitleWrapperElement.classList.add("book")
      bookImageElement.classList.add("book-image")
      bookTitleElement.classList.add("book-title")
      authorBooksWrapperElement.appendChild(imageTitleWrapperElement);

      bookImageElement.src = "/" + x.image;
      bookTitleElement.innerText = x.title;
    });
  });

let authorTextBornDeadElement = document.getElementById("authorBornDead");
authorTextOverviewElement = "'.authorBornElement' + '-' +  `authorDeadElement`";

function backButtonClicked() {
  window.history.back();
}
