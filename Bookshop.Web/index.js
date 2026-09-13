fetch("http://localhost:8000/books")
  .then((response) => response.json())
  .then((books) => {
    console.log(books);
    books.forEach((book) => {
      addBook(book);
    });
  });

function addBook(book) {
  const booksWrapperElement = document.getElementById("booksWrapper");

  const bookElement = document.createElement("div");

  const imageElement = document.createElement("img");
  const titleElement = document.createElement("div");
  const authorElement = document.createElement("div");

  bookElement.appendChild(imageElement);
  bookElement.appendChild(titleElement);
  bookElement.appendChild(authorElement);

  bookElement.classList.add("book");
  titleElement.classList.add("book-title");
  authorElement.classList.add("book-author");

  bookElement.addEventListener("click", (x) => {
    console.log("book", x);
    x.stopPropagation();
    window.location.href = "/book.html?id=" + book.id;
  });

  imageElement.src = book.image;
  titleElement.innerText = book.title;
  authorElement.innerText = book.author;

  booksWrapperElement.appendChild(bookElement);
}

const body = document.getElementsByTagName("body")[0];
body.addEventListener("click", (x) => {
  console.log("abobus");
});
