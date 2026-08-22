var books = [
  {
    id: 1,
    title: "Sujokkwan",
    author: "Yu Re Hyuk",
    image: "book images/Schachnovelle.jpg",
  },
  {
    id: 2,
    title: "Annyeong, Peter Pan",
    author: "Jeon Gyeong Cheol",
    image: "book images/annyeong pitho pen.jpg",
  },
  {
    id: 3,
    title: "Jeolchang",
    author: "Gu Byeong Mo",
    image: "book images/jeolchang.jpg",
  },

  {
    id: 4,
    title: "Und Nietzsche weinte",
    author: "Irvin D. Yalom",
    image: "book images/Und Nietzsche weinte.jpg",
  },
  {
    id: 5,
    title: "Das Bildnis des Dorian Gray",
    author: "Oscar Wilde",
    image: "book images/Das Bildnis des Dorian Gray.webp",
  },
  {
    id: 6,
    title: "Madame Bovary",
    author: "Gustave Flaubert",
    image: "book images/madame bovary.webp",
  },
  {
    id: 7,
    title: "Schachnovelle",
    author: "Stafan Zweig",
    image: "book images/Schachnovelle.jpg",
  },
];

books.forEach((book) => {
  addBook(book);
});

function addBook(book) {

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

  imageElement.src = book.image;
  titleElement.textContent = book.title;
  authorElement.textContent = book.author;

  const booksWrapperElement = document.getElementById("booksWrapper");
  booksWrapperElement.appendChild(bookElement);
}



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
