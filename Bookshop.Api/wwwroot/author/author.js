const urlParams = new URLSearchParams(window.location.search);
const id = urlParams.get("id");

console.log(id);

fetch("/api/authors/" + id)
  .then((response) => response.json())
  .then((data) => {
    console.log(data);
    const authorImageElement = document.getElementById("authorImage");
    const authorNameElement = document.getElementById("authorName");

    const authorBornElement = document.getElementById("authorBorn");
    const authorDeadElement = document.getElementById("authorDead");
    const authorBiographyElement = document.getElementById("authorBiography");
    const authorBooksNumberElement =
      document.getElementById("authorBooksNumber");

    authorImageElement.src = data.image;
    authorNameElement.innerText = data.firstName + " " + data.lastName;
    const birthDate = new Date(data.dateOfBirth).toLocaleDateString("eng-GB", {
      day: "numeric",
      month: "long",
      year: "numeric",
    });
    authorBornElement.innerText = birthDate;
    const deathDate = new Date(data.dateOfDeath).toLocaleDateString("eng-GB", {
      day: "numeric",
      month: "long",
      year: "numeric",
    });
    authorDeadElement.innerHTML = deathDate;
    authorBiographyElement.innerText = data.biography;
    authorBooksNumberElement.innerText = `Available books: ${data.books.length}`;

    //author's books
    data.books.forEach((x) => {
      const authorBooksWrapperElement =
        document.getElementById("authorBooksWrapper");
      const bookWrapperElement = document.createElement("div");
      const bookImageElement = document.createElement("img");
      const bookTitleElement = document.createElement("div");
      const bookPriceElement = document.createElement("div");

      bookWrapperElement.append(
        bookImageElement,
        bookTitleElement,
        bookPriceElement,
      );

      bookWrapperElement.classList.add("book");
      bookImageElement.classList.add("book-image");
      bookTitleElement.classList.add("book-title");
      bookPriceElement.classList.add("book-price");

      authorBooksWrapperElement.appendChild(bookWrapperElement);

      bookWrapperElement.addEventListener("click", (event) => {
        console.log("book", event);
        event.stopPropagation();
        window.location.href = "/book/book.html?id=" + x.id;
      });

      bookImageElement.src = x.image;
      bookTitleElement.innerText = x.title;
      bookPriceElement.innerHTML = `${x.price}€`;
    });
  });

let authorTextBornDeadElement = document.getElementById("authorBornDead");
authorTextOverviewElement = "'.authorBornElement' + '-' +  `authorDeadElement`";

loadHeader();
