const cartWrapper = document.getElementById("cartWrapper");
const cartString = localStorage.getItem("cart");
const cart = JSON.parse(cartString) || [];
console.log(cart);

const query = new URLSearchParams(cart.map((x) => ["ids", x.id])).toString();
// "ids=1&ids=2&ids=3"

fetch(`https://localhost:6767/books?${query}`)
  .then((response) => response.json())
  .then((books) => {
    console.log(books);

    books.forEach((book) => {
      addBook(book);
    });
  });

function addBook(book) {
  const cartWrapperElement = document.getElementById("cartWrapper");

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
  imageElement.classList.add("book-image");

  const cartRecord = cart.find((x) => x.id == book.id);
  cartRecord.count;

  imageElement.src = book.image;
  titleElement.innerText = book.title + ` (${cartRecord.count})`;
  authorElement.innerText = book.author;

  cartWrapperElement.appendChild(bookElement);
}

var toBuyWrapperElement = document.getElementById("toBuyWrapper");
const itemQuantityElement = document.createElement("div");

toBuyWrapperElement.appendChild;
toBuyWrapperElement.innerText = `Items(${cart.length})`;
