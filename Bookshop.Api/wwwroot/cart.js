const cartString = localStorage.getItem("cart");
const cart = JSON.parse(cartString) || [];
console.log(cart);

const query = new URLSearchParams(cart.map((x) => ["ids", x.id])).toString();
// "ids=1&ids=2&ids=3"

let lastLoadedBooks;

fetch(`/api/books?${query}`)
  .then((response) => response.json())
  .then((books) => {
    console.log(books);
    lastLoadedBooks = books;

    books.forEach((book) => {
      addBook(book);
    });

    updateTotal();
  });

function addBook(book) {
  const cartWrapperElement = document.getElementById("cartWrapper");

  const bookElement = document.createElement("div");
  const bookDetailsWrapperElement = document.createElement("div");

  const imageElement = document.createElement("img");
  const titleElement = document.createElement("div");
  const authorElement = document.createElement("div");
  const priceAndQuantityElement = document.createElement("div");
  const priceElement = document.createElement("div");
  const quantityElement = document.createElement("input");
  quantityElement.type = "number";
  const deleteElement = document.createElement("button");
  deleteElement.innerHTML = ' <i class="bi bi-trash3" aria-hidden="true"></i>';

  bookElement.appendChild(imageElement);
  bookElement.appendChild(bookDetailsWrapperElement);
  bookDetailsWrapperElement.appendChild(titleElement);
  bookDetailsWrapperElement.appendChild(authorElement);
  priceAndQuantityElement.appendChild(priceElement);
  priceAndQuantityElement.appendChild(quantityElement);
  bookDetailsWrapperElement.appendChild(priceAndQuantityElement);
  priceAndQuantityElement.appendChild(deleteElement);

  cartWrapperElement.classList.add("cart-wrapper")
  bookElement.classList.add("book");
  bookDetailsWrapperElement.classList.add("book-details");
  titleElement.classList.add("book-title");
  authorElement.classList.add("book-author");
  priceElement.classList.add("book-price");
  quantityElement.classList.add("book-quantity");
  priceAndQuantityElement.classList.add("price-and-quantity");
  imageElement.classList.add("book-image");
  deleteElement.classList.add("btn");
  deleteElement.classList.add("btn-danger");
  deleteElement.classList.add("btn-delete");

  const cartRecord = cart.find((x) => x.id == book.id);

  imageElement.src = book.image;
  titleElement.innerText = book.title;
  authorElement.innerText = book.author;
  priceElement.innerText = `${book.price}€ x`;

  quantityElement.min = 1;
  quantityElement.value = cartRecord.count;
  quantityElement.addEventListener("change", () => {
    let count = quantityElement.value;
    if (count < 1) {
      quantityElement.value = 1;
    }
    cartRecord.count = +quantityElement.value;
    localStorage.setItem("cart", JSON.stringify(cart));
    updateTotal();
  });

  deleteElement.addEventListener("click", () => {
    const deleteRecord = cart.findIndex((x) => x.id == book.id);
    cart.splice(deleteRecord, 1);
    localStorage.setItem("cart", JSON.stringify(cart));
    bookElement.remove();
    updateTotal();
  });

  cartWrapperElement.appendChild(bookElement);
}

function updateTotal() {
  const totalPriceElement = document.getElementById("totalPrice");
  const totalBookPrices = cart.map((cartRecord) => {
    const book = lastLoadedBooks.find((book) => cartRecord.id == book.id);
    const totalBookPrice = book.price * cartRecord.count;
    return totalBookPrice;
  });
  totalPriceElement.innerText =
    "Total: " + `${Math.sumPrecise(totalBookPrices)}` + "€";
}

var totalPriceElement = document.getElementById("totalPrice");
const itemQuantityElement = document.createElement("div");

function showContactDetails() {
  if (cart.length === 0) {
    alert("Your cart is empty");
    return;
  } else {
    const contactDetailsWrapperElement = document.getElementById(
      "contactDetailsWrapper",
    );
    contactDetailsWrapperElement.classList.remove(
      "contact-details-wrapper-hidden",
    );
    document
      .getElementById("contactDetailsWrapper")
      .scrollIntoView({ behavior: "smooth", block: "start" });
  }
}

function onSubmitClicked(event) {
  event.preventDefault();
  const phoneInputElement = document.getElementById("phoneInput");
  const emailInputElement = document.getElementById("emailInput");

  const request = {
    email: emailInputElement.value,
    phoneNumber: phoneInputElement.value,
    orderItems: cart.map((x) => {
      return { bookId: x.id, quantity: x.count };
    }),
  };

  fetch("/api/orders", {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(request),
  });
}
