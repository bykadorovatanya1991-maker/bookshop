getBooks();

function onSearchButtonClicked() {
  let searchQuery = document.getElementById("searchInput").value;
  getBooks(searchQuery);
}

function getBooks(searchQuery) {
  let url = "https://localhost:7059/books";
  if (searchQuery !== null && searchQuery !== undefined && searchQuery !== "") {
    url += "?searchString=" + searchQuery;
  }
  fetch(url)
    .then((response) => response.json())
    .then((books) => {
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
