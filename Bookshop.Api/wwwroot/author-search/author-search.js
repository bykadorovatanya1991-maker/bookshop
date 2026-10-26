getAuthors();
function getAuthors(searchQuery) {
  let url = "/api/authors"; //endpoint adress
  if (searchQuery !== null && searchQuery !== undefined && searchQuery !== "") {
    url += "?searchString=" + searchQuery; //query parameters
  }
  fetch(url) //http get request using url
    .then((response) => response.json())
    .then((authors) => {
      //books here as array
      console.log(authors);

      const authorsWrapperElement = document.getElementById("authorsWrapper");
      authorsWrapperElement.replaceChildren();

      authors.forEach((author) => {
        addAuthor(author);
      });
    });
}

function addAuthor(author) {
  const authorsWrapperElement = document.getElementById("authorsWrapper");

  const authorElement = document.createElement("div");

  const imageElement = document.createElement("img");
  const firstLastNameElement = document.createElement("div");
  const firstNameElement = document.createElement("div");
  const lastNameElement = document.createElement("div");

  firstLastNameElement.appendChild(firstNameElement);
  firstLastNameElement.appendChild(lastNameElement);

  authorElement.appendChild(imageElement);
  authorElement.appendChild(firstLastNameElement);


  authorElement.classList.add("author");
  firstLastNameElement.classList.add("author-first-last-name");
  firstNameElement.classList.add("author-first-name");
  lastNameElement.classList.add("author-last-name");

  authorElement.addEventListener("click", (x) => {
    console.log("author", x);
    x.stopPropagation();
    window.location.href = "../author/author.html?id=" + author.id;
  });

  imageElement.src = "../" + author.image;
  firstNameElement.innerText = author.firstName;
  lastNameElement.innerText = author.lastName;

  authorsWrapperElement.appendChild(authorElement);
}
