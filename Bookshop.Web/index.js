getBooks();

const inputElement = document.getElementById("searchInput");
inputElement.addEventListener("keydown", (event) => {
  if (event.key === "Enter") {
    onSearchButtonClicked();
  }
});

function onSearchButtonClicked() {
  let searchQuery = document.getElementById("searchInput").value; //string
  getBooks(searchQuery);
}

// hoisting (подъём)
function getBooks(searchQuery) {
  let url = "https://localhost:6767/books"; //endpoint address
  if (searchQuery !== null && searchQuery !== undefined && searchQuery !== "") {
    url += "?searchString=" + searchQuery; //query parameters
  }
  fetch(url) //http get request using url
    .then((response) => response.json())
    .then((books) => {
      //books here as array
      console.log(books);

      const booksWrapperElement = document.getElementById("booksWrapper");
      booksWrapperElement.replaceChildren();

      books.forEach((book) => {
        addBook(book);
      });
    });
}

function addBook(book) {
  const booksWrapperElement = document.getElementById("booksWrapper");

  const bookElement = document.createElement("div");

  const imageElement = document.createElement("img");
  const titleElement = document.createElement("div");
  const authorElement = document.createElement("div");
  const priceElement = document.createElement("div");

  bookElement.appendChild(imageElement);
  bookElement.appendChild(titleElement);
  bookElement.appendChild(authorElement);
  bookElement.appendChild(priceElement);

  bookElement.classList.add("book");
  titleElement.classList.add("book-title");
  authorElement.classList.add("book-author");
  priceElement.classList.add("book-price");

  bookElement.addEventListener("click", (x) => {
    console.log("book", x);
    x.stopPropagation();
    window.location.href = "/book.html?id=" + book.id;
  });

  imageElement.src = book.image;
  titleElement.innerText = book.title;
  authorElement.innerText = book.author;
  priceElement.innerText = `${book.price}€`;

  booksWrapperElement.appendChild(bookElement);
}
