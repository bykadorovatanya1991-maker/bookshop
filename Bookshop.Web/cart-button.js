function onCartButtonClicked() {
  window.location.href = "/cart.html";
}

function updateTotalItemsInTheCart() {
  const itemsInTheCartElement = document.getElementById("itemsInTheCart");
  const cart = JSON.parse(localStorage.getItem("cart")) || [];
  const totalBookItems = cart.map((cartRecord) => cartRecord.count);
  itemsInTheCartElement.innerText = `${Math.sumPrecise(totalBookItems)}`;
}
updateTotalItemsInTheCart();
