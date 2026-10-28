const urlParams = new URLSearchParams(window.location.search);
const id = +urlParams.get("id");

console.log(id);

fetch("/api/books/" + id)
  .then((response) => response.json())
  .then((data) => {
    console.log(data);
    const titleElement = document.getElementById("title");
    const authorElement = document.getElementById("author");
    const descriptionElement = document.getElementById("description");
    const imageElement = document.getElementById("image");
    const priceElement = document.getElementById("price");

    titleElement.innerText = data.title;
    authorElement.innerText =
      data.author.firstName + " " + data.author.lastName;
    descriptionElement.innerText = data.description;
    imageElement.src = data.image;
    priceElement.innerText = `${data.price}€`;

    document.querySelector(".author").addEventListener("click", (x) => {
      window.location.href = "/author/author.html?id=" + data.author.id;
    });
  });

function onBuyButtonClicked() {
  let cartString = localStorage.getItem("cart"); // string
  console.log(cartString);

  const cart = JSON.parse(cartString) || [];
  console.log(cart);

  const existingBookRecord = cart.find((x) => x.id == id);

  if (existingBookRecord != null) {
    existingBookRecord.count++;
  } else {
    cart.push({ id: id, count: 1 }); // {id: 1. count: 5}
  }

  cartString = JSON.stringify(cart);
  console.log(cartString);

  localStorage.setItem("cart", cartString);

  const buyAlertElement = document.getElementById("buyAlert");
  buyAlertElement.style.display = "block";
  setTimeout(() => {
    buyAlertElement.style.display = "none";
  }, 4000);

  updateTotalItemsInTheCart();
}

loadHeader();
