async function loadHeader() {
  const placeholder = document.getElementById("site-header");
  const response = await fetch("/partials/header/header.html");

  if (!response.ok) {
    console.error("Header failed to load:", response.status);
    return;
  }

  placeholder.innerHTML = await response.text();

  updateTotalItemsInTheCart();
}

function toggleMenu() {
  const navElement = document.getElementsByTagName("nav")[0];
  navElement.classList.toggle("open");
}

function onCartButtonClicked() {
  window.location.href = "/cart.html";
}

function updateTotalItemsInTheCart() {
  const itemsInTheCartElement = document.getElementById("itemsInTheCart");
  const cart = JSON.parse(localStorage.getItem("cart")) || [];
  const totalBookItems = cart.map((cartRecord) => cartRecord.count);
  itemsInTheCartElement.innerText = `${Math.sumPrecise(totalBookItems)}`;
}

loadHeader();
