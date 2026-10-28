using Bookshop.Domain.Models;
using Microsoft.EntityFrameworkCore;

public class BookshopDbContext : DbContext
{
    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //optionsBuilder.UseInMemoryDatabase("Bookshop");
        optionsBuilder.UseSqlServer("Server=.;Database=Bookshop;Trusted_Connection=True;TrustServerCertificate=True;");
    }

    public static void Seed()
    {
        using (var dbContext = new BookshopDbContext())
        {
            if (dbContext.Authors.Count() == 0) {
                var authors = new List<Author> { 
                    new Author {FirstName = "Theodor", LastName="Storm", DateOfBirth = new DateOnly(1817, 9, 14), DateOfDeath= new DateOnly(1888,7,4), Image="images/authors/storm.webp", Biography="An influential German-Frisian writer, lyric poet, and judge who stood as a central figure of 19th-century German poetic realism. He is renowned for his atmospheric, deeply moving depictions of the North German coastal landscape and themes of memory, unfulfilled love, and human isolation. His crowning achievement is the gothic masterpiece novella Der Schimmelreiter (The Rider on the White Horse), published shortly before his death."  },
                    new Author {FirstName = "Ovid", LastName="", DateOfBirth = new DateOnly(1, 3, 20), DateOfDeath = new DateOnly(17,1,1),Image="images/authors/ovid.webp", Biography="A major Roman poet of the Augustan era, he is celebrated for his wit, elegance, and mastery of mythological storytelling. His magnum opus, the Metamorphoses, remains one of our most important sources of classical myth and has profoundly influenced Western art for centuries. Banished to the Black Sea late in life, his final writings reflect a deep, enduring melancholy." },
                    new Author {FirstName = "Stefan", LastName="Zweig", DateOfBirth = new DateOnly(1881, 11, 28), DateOfDeath = new DateOnly(1942, 2,22),Image="images/authors/stefanZweig.webp", Biography="A phenomenally popular Austrian novelist, playwright, and biographer, he was a passionate humanist who witnessed the tragic collapse of European culture during the World Wars. Renowned for his psychological insight, his novellas (like Chess Story) and his memoir The World of Yesterday capture a profound nostalgia for a lost, borderless Europe." },
                    new Author {FirstName = "Oscar", LastName="Wilde", DateOfBirth = new DateOnly(1854, 10, 16), DateOfDeath = new DateOnly(1900, 11, 30),Image="images/authors/oscarWilde.webp",Biography="A brilliant Irish wit, dramatist, and poet, he became the flamboyant figurehead of the late-Victorian Aesthetic movement. Best known for his sparkling society comedies and his cautionary novel The Picture of Dorian Gray, his glittering career was tragically cut short by imprisonment and exile due to his homosexuality." },
                    new Author {FirstName = "Gustave", LastName="Flaubert", DateOfBirth = new DateOnly(1821, 12, 12), DateOfDeath = new DateOnly(1880, 5, 8),Image="images/authors/gustaveFlaubert.gif", Biography="A master of French realism, he revolutionized modern prose fiction through his obsessive dedication to style and \"le mot juste\" (the right word). His influential debut novel Madame Bovary exposed the crushing banality of provincial life and the dangers of romantic disillusionment, enduring a famous obscenity trial."  },
                    new Author {FirstName = "Irvin D.", LastName="Yalom", DateOfBirth = new DateOnly(1931, 6, 13),Image="images/authors/IrvinYalom.gif",Biography="An American psychiatrist, author, and professor emeritus at Stanford University, he is a pioneer in the field of existential psychotherapy. Through acclaimed psychological fiction like When Nietzsche Wept and The Schopenhauer Cure, he brilliantly utilizes narrative to explore deep philosophical dilemmas and the therapeutic process."  },
                    new Author {FirstName = "Eduard", LastName="von Keyserling", DateOfBirth = new DateOnly(1855, 5, 14),DateOfDeath = new DateOnly(1918, 9, 28),Image="images/authors/eduardVonKeyserling.gif", Biography="A Baltic-German writer, he stands as the foremost representative of German literary Impressionism. His dreamlike, melancholic novels and novellas, such as Waves (Wellen), beautifully capture the decaying lifestyle and emotional isolation of the pre-WWI European aristocracy." },
                    new Author {FirstName = "George", LastName="Eliot", DateOfBirth = new DateOnly(1819, 11, 22),DateOfDeath = new DateOnly(1880, 12, 22),Image="images/authors/geirgeEliot.gif", Biography="The pen name of Mary Ann Evans, she was one of the leading novelists of the Victorian era who used a male pseudonym to ensure her work was taken seriously. Acclaimed for her intellectual depth and psychological realism, her masterpiece Middlemarch is widely considered one of the greatest novels in the English language." },
                    new Author {FirstName = "Thomas", LastName="Hardy", DateOfBirth = new DateOnly(1840, 6, 2),DateOfDeath = new DateOnly(1928, 1, 11),Image="images/authors/thomasHardy.gif",Biography="An English novelist and poet, his tragic works are primarily set in his semi-fictional, rural region of Wessex. Masterpieces like Tess of the d'Urbervilles and Jude the Obscure sharply critique strict Victorian morality while exploring humanity’s struggle against indifferent cosmic and social forces."  },
                    new Author {FirstName = "F. Scott", LastName="Fitzgerald", DateOfBirth = new DateOnly(1896, 9, 24),DateOfDeath = new DateOnly(1940, 12, 21),Image="images/authors/scottFitzgerald.gif",Biography=" An iconic American writer of the \"Lost Generation,\" he was the definitive chronicler of the Jazz Age’s glitz, excess, and underlying disillusionment. His brilliant, melancholic masterpiece The Great Gatsby remains the ultimate critique of the American Dream and the transience of youth."  },
                    new Author {FirstName = "Nikolai", LastName="Gogol", DateOfBirth = new DateOnly(1809, 4, 1),DateOfDeath = new DateOnly(1852, 3, 4),Image="images/authors/gogol.gif",Biography="A Ukrainian-born writer who wrote in Russian, he blended realism with satire, surrealism, and the grotesque. His groundbreaking works, including the short story \"The Overcoat\" and the novel Dead Souls, exposed bureaucratic absurdity and laid the foundation for the golden age of Russian prose."  },
                    new Author {FirstName = "Johann Wolfgang", LastName="von Goethe", DateOfBirth = new DateOnly(1749, 8, 28),DateOfDeath = new DateOnly(1832, 3, 22),Image="images/authors/goethe.gif", Biography="A titan of world literature, this German polymath, poet, and dramatist shaped the Sturm und Drang movement and Weimar Classicism. His vast body of work includes the foundational romantic novel The Sorrows of Young Werther and his monumental philosophical tragedy Faust. He is widely regarded as Germany's greatest literary figure." },
                    new Author {FirstName = "Theodor", LastName="Fontane", DateOfBirth = new DateOnly(1819, 12, 30),DateOfDeath = new DateOnly(1898, 9, 20),Image="images/authors/fontanegif.gif", Biography="A crucial novelist and poet, he is considered the master of 19th-century German poetic realism. Through celebrated social novels like Effi Briest, he delivered sharp yet sympathetic critiques of the rigid Prussian aristocratic codes and marital constraints of his time." },
                    new Author {FirstName = "Fjodor", LastName="Dostojewski", DateOfBirth = new DateOnly(1821, 11, 11),DateOfDeath = new DateOnly(1881, 2, 9),Image="images/authors/dostoyevsky.gif",Biography="A giant of world literature, he explored the darkest recesses of the human psyche, existential anxiety, and spiritual redemption. His philosophically charged novels, such as Crime and Punishment and The Brothers Karamazov, deeply influenced 20th-century psychology and existentialist thought."  },
                };

                dbContext.Authors.AddRange(authors);

                dbContext.SaveChanges();
            }

            if (dbContext.Books.Count() == 0)
            {
                var TheodorStormAuthorId = dbContext.Authors.Where(x => x.FirstName == "Theodor" && x.LastName == "Storm").Select(x => x.Id).First();
                var EduardvonKeyserlingAuthorId = dbContext.Authors.Where(x => x.FirstName == "Eduard" && x.LastName == "von Keyserling").Select(x => x.Id).First();
                var OvidAuthorId = dbContext.Authors.Where(x => x.FirstName == "Ovid" && x.LastName == "").Select(x => x.Id).First();
                var StefanZweigAuthorId = dbContext.Authors.Where(x => x.FirstName == "Stefan" && x.LastName == "Zweig").Select(x => x.Id).First();
                var IrvinDYalomAuthorId = dbContext.Authors.Where(x => x.FirstName == "Irvin D." && x.LastName == "Yalom").Select(x => x.Id).First();
                var OscarWildeAuthorId = dbContext.Authors.Where(x => x.FirstName == "Oscar" && x.LastName == "Wilde").Select(x => x.Id).First();
                var GustaveFlaubertAuthorId = dbContext.Authors.Where(x => x.FirstName == "Gustave" && x.LastName == "Flaubert").Select(x => x.Id).First();
                var GeorgeEliotAuthorId = dbContext.Authors.Where(x => x.FirstName == "George" && x.LastName == "Eliot").Select(x => x.Id).First();
                var ThomasHardyAuthorId = dbContext.Authors.Where(x => x.FirstName == "Thomas" && x.LastName == "Hardy").Select(x => x.Id).First();
                var FScottFitzgeraldAuthorId = dbContext.Authors.Where(x => x.FirstName == "F. Scott" && x.LastName == "Fitzgerald").Select(x => x.Id).First();
                var NikolaiGogolAuthorId = dbContext.Authors.Where(x => x.FirstName == "Nikolai" && x.LastName == "Gogol").Select(x => x.Id).First();
                var JohannWolfgangvonGoetheAuthorId = dbContext.Authors.Where(x => x.FirstName == "Johann Wolfgang" && x.LastName == "von Goethe").Select(x => x.Id).First();
                var TheodorFontaneAuthorId = dbContext.Authors.Where(x => x.FirstName == "Theodor" && x.LastName == "Fontane").Select(x => x.Id).First();
                var FjodorDostojewskiAuthorId = dbContext.Authors.Where(x => x.FirstName == "Fjodor" && x.LastName == "Dostojewski").Select(x => x.Id).First();

                var books = new List<Book>
                {
                    new Book {Title="Der Schimmelreiter", AuthorId = TheodorStormAuthorId, Image= "images/books/Der Schimmelreiter.jpg", Price = 8, Description= "Der Schimmelreiter (translated as The Rider on the White Horse or The Dykemaster) is a famous 1888 Gothic fiction novella by German writer Theodor Storm.\r\nSet on the windswept coast of North Friesland, the book explores the tragic battle between human reason, nature, and social superstition.",  Language="German"},
                    new Book {Title="Wellen", AuthorId= EduardvonKeyserlingAuthorId, Image= "images/books/Wellen.jpg", Price = 12, Description= "This 1911 German novel follows an aristocratic countess who causes a massive scandal by abandoning her elderly husband to live with a penniless painter at a Baltic Sea resort. As her new life collides with a vacationing noble family, the relentless crashing of the ocean waves symbolizes the untamable human passions that break against rigid societal rules.", Language="German"},
                    new Book {Title="Metamorphosen", AuthorId= OvidAuthorId, Image= "images/books/Metamorphosen.jpg",Price = 13.80M, Description= "Written in 8 CE, this monumental Roman epic poem weaves together over 250 myths to chronicle the history of the world from its creation to the deification of Julius Caesar. Every story centers on the theme of physical transformation, illustrating how humans and gods are changed into animals, plants, or stones by intense emotions like love, pride, and divine wrath.", Language="German" },
                    new Book {Title="Die Welt von Gestern", AuthorId= StefanZweigAuthorId, Image= "images/books/Die Welt von Gestern.jpg",Price = 13, Description= "Written shortly before the author's death in exile, this poignant 1942 memoir chronicles the cultural brilliance of Vienna and Europe before it was destroyed by two world wars. Through personal recollections, Stefan Zweig captures the tragic shift from an era of artistic optimism and security into a dark age of totalitarianism and hatred.",  Language="German" },
                    new Book {Title="Das Bildnis des Dorian Gray", AuthorId= OscarWildeAuthorId, Image= "images/books/Das Bildnis des Dorian Gray.webp",Price = 12, Description= "This 1890 Gothic classic tells the story of a handsome young man who sells his soul so that a painted portrait will age and bear the scars of his sins while he remains eternally youthful. Oscar Wilde uses Dorian’s spiral into hidden cruelty and debauchery to explore the destructive consequences of pure hedonism, vanity, and aestheticism.", Language="German" },
                    new Book {Title="Madame Bovary", AuthorId= GustaveFlaubertAuthorId, Image= "images/books/madame bovary.webp",Price = 13, Description= "This groundbreaking 1856 French novel follows Emma Bovary, a doctor’s wife who engages in empty adulterous affairs and ruins her family financially to escape the banality of provincial life. Gustave Flaubert uses her tragic disillusionment to critique the romantic delusions of the middle class while pioneering the style of modern literary realism.", Language="French" },
                    new Book {Title="Schachnovelle", AuthorId= StefanZweigAuthorId, Image= "images/books/Schachnovelle.jpg",Price = 9, Description= "Set on a passenger liner, this intense 1941 novella depicts a chess match between the arrogant world champion and a mysterious stranger who survived psychological torture by Nazi captors. Stefan Zweig uses the game of chess as a powerful psychological battleground to symbolize the clash between brutal tyranny and the fragile human mind.", Language="German" },
                    new Book {Title="Und Nietzsche weinte", AuthorId= IrvinDYalomAuthorId, Image= "images/books/Und Nietzsche weinte.jpg",Price = 12, Description= "This 1992 historical fiction novel imagines a series of secret therapeutic meetings in 1882 Vienna between the brilliant but despairing philosopher Friedrich Nietzsche and the renowned physician Dr. Josef Breuer. Irvin D. Yalom expertly blends philosophy and early psychoanalysis to show how both men end up saving each other from their deep existential dread and loneliness.",  Language="German"},
                    new Book {Title= "Verwirrung der Gefühle", AuthorId= StefanZweigAuthorId, Image= "images/books/Verwirrung der Gefuehle.jpg",Price = 10, Description= "This 1927 novella follows a young university student who develops an intense, admiring bond with his brilliant but unpredictable professor. As the student is drawn deeper into the professor's academic circle, he becomes caught in a painful web of unspoken passions, hidden secrets, and emotional confusion.", Language="German"},
                    new Book {Title="Adam Bede", AuthorId= GeorgeEliotAuthorId, Image= "images/books/Adam Bede.jpg", Price = 14, Description= "Set in a rural English community in 1799, this 1859 novel revolves around an upright, hardworking carpenter whose life is upended by a tragic love triangle. Through a story of seduction, betrayal, and eventual redemption, George Eliot explores the severe, lifelong moral consequences of individual human actions on an entire village.", Language="German" },
                    new Book {Title="Clyms Heimkehr", AuthorId= ThomasHardyAuthorId, Image= "images/books/Clyms Heimkehr.jpg", Price = 12, Description= "This 1878 Victorian novel tells the story of Clym Yeobright, a young man who leaves his glamorous life in Paris to return to his brooding, isolated English homeland. His idealistic desire to educate the local peasants clashes tragically with the desperate ambitions of his volatile new wife, who longs only to escape the desolate countryside.", Language="German" },
                    new Book {Title="Der große Gatsby", AuthorId= FScottFitzgeraldAuthorId, Image= "images/books/Der Grosse Gatsby.jpg", Price = 10, Description= "Set during the roaring twenties, this 1925 American classic follows the mysterious millionaire Jay Gatsby and his obsessive pursuit of his former love, Daisy Buchanan. Through opulent parties and ultimate heartbreak, F. Scott Fitzgerald paints a devastating portrait of the disillusionment, corruption, and decay of the American Dream.", Language="German" },
                    new Book {Title="Die Mühle am Floss", AuthorId= GeorgeEliotAuthorId, Image= "images/books/Die Muehle am Floss.jpg", Price = 18, Description= "This deeply emotional novel centers on the close yet tumultuous relationship between the passionate, free-spirited Maggie Tulliver and her rigidly traditional brother, Tom. As their family mill faces financial ruin, Maggie struggles against societal expectations and family loyalty, leading to a devastating and unforgettable climax.", Language="German" },
                    new Book {Title="Die toten Seelen", AuthorId= NikolaiGogolAuthorId, Image= "images/books/Die Toten Seelen.jpg", Price = 14, Description= "This 1842 satirical masterpiece follows a cunning swindler named Chichikov who travels across the Russian countryside buying up \"dead souls\"—deceased serfs who are legally still counted as alive on the tax rolls. Nikolai Gogol uses this absurdly brilliant premise to expose the deep moral corruption, greed, and spiritual emptiness of the 19th-century Russian aristocracy.", Language="German" },
                    new Book {Title="Die Wahlverwandtschaften", AuthorId= JohannWolfgangvonGoetheAuthorId, Image= "images/books/Die Wahlverwandtschaften.jpg", Price = 12.85M, Description= "This 1809 psychological novel explores a wealthy couple whose stable marriage is destabilized when they invite two guests to live on their grand country estate. Goethe uses the scientific concept of chemical reactions to show how human passions and fatal attraction can break apart marriages just as inevitably as natural laws.", Language="German" },
                    new Book {Title="Effi Briest", AuthorId= TheodorFontaneAuthorId, Image= "images/books/Effi Briest.jpg", Price = 12, Description= "A cornerstone of German realism, this 1894 masterpiece tells the tragic story of a young, vivacious woman trapped in a suffocating, loveless marriage to a rigid and older government official. When a brief past affair is discovered years later, social conventions and an unbending code of honor relentlessly destroy Effi’s life and health.", Language="German" },
                    new Book {Title="Schuld und Sühne", AuthorId= FjodorDostojewskiAuthorId, Image= "images/books/Schuld und Suehne.jpg", Price = 15, Description= "This profound 1866 psychological thriller follows Raskolnikov, a destitute student in St. Petersburg who murders a cruel pawnbroker to prove his theory that superior men are above the law. What follows is a harrowing exploration of absolute guilt, intense paranoia, and the agonizing spiritual journey toward redemption and confession.", Language="German" },
                };

                dbContext.Books.AddRange(books);

                dbContext.SaveChanges();
            }
        }
    }
};




public abstract class Employee
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public decimal Salary { get; set; }
}

public class CleaningManager : Employee // Uborschik
{
    public List<string> RoomsToClean { get; set; }
}

public class Programmer : Employee
{
    public string ComputerName { get; set; }
}

public class Manager : Employee
{
    public List<Employee> Slaves { get; set; }
}