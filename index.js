var books = [
  { id: 1, title: "Sujokkwan", author: "Yu Re Hyuk" },
  { id: 2, title: "Annyeong, Peter Pan", author: "Jeon Gyeong Cheol" },
  { id: 3, title: "Jeolchang", author: "Gu Byeong Mo" },

  { id: 4, title: "Und Nietzsche weinte", author: "Irvin D. Yalom" },
  { id: 5, title: "Das Bildnis des Dorian Gray", author: "Oscar Wilde" },
  { id: 6, title: "Madame Bovary", author: "Gustave Flaubert" },
  { id: 7, title: "Schachnovelle", author: "Stafan Zweig" },
  { id: 8, title: "Super Book", author: "Haruki" },
];

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

imageElement.src = "book images/Schachnovelle.jpg";
titleElement.textContent = "schachnovelle";
authorElement.textContent = "stefan zweig";

const booksWrapperElement = document.getElementById("booksWrapper");
booksWrapperElement.appendChild(bookElement);

// const buttonElement = document.createElement("button");

// const paragraphElement = document.createElement("p");
// paragraphElement.appendChild(buttonElement)

// const booksWrapperElement = document.getElementById("booksWrapper");
// booksWrapperElement.appendChild(paragraphElement);

// const buttonElement = document.createElement("button");

// const paragraphElement = document.createElement("p");

// const booksWrapperElement = document.getElementById("booksWrapper");

// booksWrapperElement.appendChild(paragraphElement);
// paragraphElement.appendChild(buttonElement)
