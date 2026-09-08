const urlParams = new URLSearchParams(window.location.search);
const id = urlParams.get("id");

console.log(id);

fetch("http://localhost:8000/authors/" + id)
  .then((response) => response.json())
  .then((data) => {
    console.log(data);
    const authorImageElement = document.getElementById("authorImage");
    const authorNameElement = document.getElementById("authorName");

    const authorBornElement = document.getElementById("authorBorn");
    const authorDeadElement = document.getElementById("authorDead");
    const authorBooksNumberElement =
      document.getElementById("authorBooksNumber");

    authorImageElement.src = data.image;
    authorNameElement.innerText = data.name;

    authorBornElement.innerText = data.born;
    authorDeadElement.innerText = data.dead;
    authorBooksNumberElement.innerText = data.booksCount;

    //author's books
    data.books.forEach((x) => {
      const authorBooksWrapperElement =
        document.getElementById("authorBooksWrapper");
      const imageTitleWrapperElement = document.createElement("div");
      const bookImageElement = document.createElement("img");
      const bookTitleElement = document.createElement("div");
      imageTitleWrapperElement.append(bookImageElement, bookTitleElement);
      authorBooksWrapperElement.appendChild(imageTitleWrapperElement);

      bookImageElement.src = x.image;
      bookTitleElement.innerText = x.title;
    });
  });

let authorTextBornDeadElement = document.getElementById("authorBornDead");
authorTextOverviewElement = "'.authorBornElement' + '-' +  `authorDeadElement`";

function backButtonClicked() {
  window.history.back();
}
