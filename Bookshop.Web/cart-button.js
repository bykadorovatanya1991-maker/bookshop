function onCartButtonClicked() {
  window.location.href = "/cart.html";
}

function updateTotalItemsInTheCart() {
  const itemsInTheCartElement = document.getElementById("itemsInTheCart");
  const cart = JSON.parse(localStorage.getItem("cart")) || [];
  const totalBookPrices = cart.map((cartRecord) => {
    const totalBookPrice = cartRecord.count;
    return totalBookPrice;
  });
  itemsInTheCartElement.innerText = `${Math.sumPrecise(totalBookPrices)}`;
}
updateTotalItemsInTheCart();