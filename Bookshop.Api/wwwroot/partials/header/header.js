async function loadHeader({ placeholder, onSearch } = {}) {
  const container = document.getElementById("site-header");
  const response = await fetch("/partials/header/header.html");

  if (!response.ok) {
    console.error("Header failed to load:", response.status);
    return;
  }

  container.innerHTML = await response.text();

  updateTotalItemsInTheCart();

  if (!onSearch) {
    document.getElementById("searchWrapper").hidden = true;
    return;
  }

  const input = document.getElementById("searchInput");
  input.placeholder = placeholder;

  document
    .getElementById("searchButton")
    .addEventListener("click", () => onSearch(input.value));
  input.addEventListener("keydown", (event) => {
    if (event.key === "Enter") {
      onSearch(input.value);
    }
  });
  input.addEventListener("input", () => {
    // clear scenario
    if (!input.value) {
      onSearch();
    }
  });
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
