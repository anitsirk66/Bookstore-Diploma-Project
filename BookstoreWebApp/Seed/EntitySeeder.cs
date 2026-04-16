using BookstoreProjectData;
using BookstoreProjectData.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace BookstoreWebApp.Seed
{
    public class EntitySeeder
    {
        public static async Task SeedAsync(BookstoreContext context)
        {
            if (!await context.Genres.AnyAsync())
            {
                var genres = new List<Genre>
                {
                    new Genre
                    {
                         Id = Guid.NewGuid(),
                         Name = "Children's",
                         Description = "Literary works created for children."
                    },
                    new Genre
                    {
                         Id = Guid.NewGuid(),
                         Name = "Historical",
                         Description = "bla"
                    },
                    new Genre
                    {
                         Id = Guid.NewGuid(),
                         Name = "Comedy",
                         Description = "ant to entertain and sometimes c be contained in all genres."
                    },
                    new Genre
                    {
                         Id = Guid.NewGuid(),
                         Name = "Classic",
                         Description = "rt of an accepted literary canon and widely taught in schools."
                    },
                    new Genre
                    {
                         Id = Guid.NewGuid(),
                         Name = "Fantasy",
                         Description = "ften including magical elements, magical creatures, or the supernatural. "
                    },
                    new Genre
                    {
                         Id = Guid.NewGuid(),
                         Name = "Thriller",
                         Description = "Tyts."
                    },
                    new Genre
                    {
                         Id = Guid.NewGuid(),
                         Name = "Romance",
                         Description = "Focmistic, emotionally satisfying ending."
                    }
                };
                await context.Genres.AddRangeAsync(genres);
                await context.SaveChangesAsync();
            }
            if (!await context.Authors.AnyAsync())
            {
                var authors = new List<Author>
                {
                    new Author
                    {
                         Id = Guid.NewGuid(),
                         FullName = "Lewis Carroll",
                         ImageUrl = "https://cdn2.penguin.com.au/covers/original/9780141354828.jpg",
                         Biography = "Charles Lutwidge Dodgson, better known by his pen name Lewis Carroll, was an English author, poet, mathematician, photographer and reluctant Anglican deacon.",
                         Nationality = "British"
                    },
                    new Author
                    {
                         Id = Guid.NewGuid(),
                         FullName = "George Orwell",
                         ImageUrl = "https://cdn2.penguin.com.au/covers/original/9780141354828.jpg",
                         Biography = "English novelist and essayist known for his dystopian works 1984 and Animal Farm, exploring themes of totalitarianism and political ideology.",
                         Nationality = "British"
                    },
                    new Author
                    {
                         Id = Guid.NewGuid(),
                         FullName = "E.B. White",
                         ImageUrl = "https://cdn2.penguin.com.au/covers/original/9780141354828.jpg",
                         Biography = "American writer and essayist, widely known for his contributions to children’s literature, including Charlotte’s Web and Stuart Little.",
                         Nationality = "American"
                    },
                    new Author
                    {
                        Id = Guid.NewGuid(),
                        FullName = "Markus Zusak",
                        ImageUrl = "https://cdn2.penguin.com.au/covers/original/9780141354828.jpg",
                        Biography = "Australian novelist recognized internationally for The Book Thief, a historical novel set during World War II.",
                        Nationality = "Australian"
                    },
                    new Author
                    {
                        Id = Guid.NewGuid(),
                        FullName = "Anthony Doerr",
                        ImageUrl = "https://cdn2.penguin.com.au/covers/original/9780141354828.jpg",
                        Biography = "American novelist and short story writer, winner of the Pulitzer Prize for Fiction for All the Light We Cannot See.",
                        Nationality = "American"
                    },
                    new Author
                    {
                        Id = Guid.NewGuid(),
                        FullName = "Terry Pratchett",
                        ImageUrl = "https://cdn2.penguin.com.au/covers/original/9780141354828.jpg",
                        Biography = "British novelist famous for the comedic fantasy Discworld series, blending satire, humor, and social commentary.",
                        Nationality = "British"
                    },
                    new Author
                    {
                        Id = Guid.NewGuid(),
                        FullName = "Douglas Adams",
                        ImageUrl = "https://cdn2.penguin.com.au/covers/original/9780141354828.jpg",
                        Biography = "English author and humorist best known for The Hitchhiker’s Guide to the Galaxy, a science fiction comedy series.",
                        Nationality = "British"
                    },
                    new Author
                    {
                        Id = Guid.NewGuid(),
                        FullName = "Jane Austen",
                        ImageUrl = "https://cdn2.penguin.com.au/covers/original/9780141354828.jpg",
                        Biography = "English novelist known for romantic fiction that critiques the British landed gentry, including Pride and Prejudice and Sense and Sensibility.",
                        Nationality = "British"
                    },
                    new Author
                    {
                        Id = Guid.NewGuid(),
                        FullName = "J. R. R. Tolkien",
                        ImageUrl = "https://cdn2.penguin.com.au/covers/original/9780141354828.jpg",
                        Biography = "English writer and philologist, author of The Hobbit and The Lord of the Rings, and a foundational figure in modern high fantasy literature.",
                        Nationality = "British"
                    },
                    new Author
                    {
                        Id = Guid.NewGuid(),
                        FullName = "George R. R. Martin",
                        ImageUrl = "https://cdn2.penguin.com.au/covers/original/9780141354828.jpg",
                        Biography = "American novelist and screenwriter best known for the epic fantasy series A Song of Ice and Fire, adapted into the TV series Game of Thrones.",
                        Nationality = "American"
                    },
                    new Author
                    {
                        Id = Guid.NewGuid(),
                        FullName = "Dan Brown",
                        ImageUrl = "https://cdn2.penguin.com.au/covers/original/9780141354828.jpg",
                        Biography = "American author of thriller novels, including The Da Vinci Code, known for blending history, art, and conspiracy themes.",
                        Nationality = "American"
                    },
                    new Author
                    {
                        Id = Guid.NewGuid(),
                        FullName = "Gillian Flynn",
                        ImageUrl = "https://cdn2.penguin.com.au/covers/original/9780141354828.jpg",
                        Biography = "American author and screenwriter known for psychological thrillers such as Gone Girl.",
                        Nationality = "American"
                    },
                    new Author
                    {
                        Id = Guid.NewGuid(),
                        FullName = "Jojo Moyes",
                        ImageUrl = "https://cdn2.penguin.com.au/covers/original/9780141354828.jpg",
                        Biography = "British novelist known for romantic fiction, especially the internationally successful novel Me Before You.",
                        Nationality = "British"
                    },
                    new Author
                    {
                        Id = Guid.NewGuid(),
                        FullName = "Nicholas Sparks",
                        ImageUrl = "https://cdn2.penguin.com.au/covers/original/9780141354828.jpg",
                        Biography = "American novelist known for romantic drama novels, many of which have been adapted into films, including The Notebook.",
                        Nationality = "American"
                    }
                };
                await context.Authors.AddRangeAsync(authors);
                await context.SaveChangesAsync();
            }
            
            if (!await context.Books.AnyAsync())
            {
                var childrensGenre = await context.Genres
                    .FirstAsync(g => g.Name == "Children's");
                var ebwhite = await context.Authors.FirstAsync(a => a.FullName == "E.B. White");
                var lewisCarroll = await context.Authors
                    .FirstAsync(a => a.FullName == "Lewis Carroll");

                var historical = await context.Genres
                    .FirstAsync(g => g.Name == "Historical");
                var markuszusak = await context.Authors
                    .FirstAsync(a => a.FullName == "Markus Zusak");
                var anthonydoerr = await context.Authors
                    .FirstAsync(a => a.FullName == "Anthony Doerr");

                var comedy = await context.Genres
                    .FirstAsync(g => g.Name == "Comedy");
                var terrypratchett = await context.Authors
                    .FirstAsync(a => a.FullName == "Terry Pratchett");
                var douglasadams = await context.Authors
                    .FirstAsync(a => a.FullName == "Douglas Adams");

                var classic = await context.Genres
                    .FirstAsync(g => g.Name == "Classic");
                var georgeorwell = await context.Authors
                    .FirstAsync(a => a.FullName == "George Orwell");
                var janeausten = await context.Authors
                    .FirstAsync(a => a.FullName == "Jane Austen");

                var fantasy = await context.Genres
                    .FirstAsync(g => g.Name == "Fantasy");
                var tolkien = await context.Authors
                    .FirstAsync(a => a.FullName == "J. R. R. Tolkien");
                var rrmartin = await context.Authors
                    .FirstAsync(a => a.FullName == "George R. R. Martin");

                var thriller = await context.Genres
                    .FirstAsync(g => g.Name == "Thriller");
                var danbrown = await context.Authors
                    .FirstAsync(a => a.FullName == "Dan Brown");
                var gillianflynn = await context.Authors
                    .FirstAsync(a => a.FullName == "Gillian Flynn");

                var romance = await context.Genres
                    .FirstAsync(g => g.Name == "Romance");
                var jojomoyes = await context.Authors
                    .FirstAsync(a => a.FullName == "Jojo Moyes");
                var nicholassparks = await context.Authors
                    .FirstAsync(a => a.FullName == "Nicholas Sparks");

                var books = new List<Book>
                {
                    new Book
                    {
                        Id = Guid.NewGuid(),
                        Title = "Alice's Adventures in Wonderland",
                        Price = 19,
                        CoverImageUrl = "https://mir-s3-cdn-cf.behance.net/project_modules/max_1200/fa761c72213835.5be04304160a1.png",
                        Synopsis = "On a quiet summer afternoon, young Alice tumbles down a rabbit hole into a fantastical world unlike anything she has ever known. In Wonderland, logic is twisted, language plays tricks, and nothing is quite as it seems. She encounters peculiar characters such as the hurried White Rabbit, the mischievous Cheshire Cat, the eccentric Mad Hatter, and the fearsome Queen of Hearts, whose temper is as unpredictable as the world she rules. As Alice navigates a series of strange encounters and surreal challenges, she questions her own identity and struggles to make sense of a place governed by nonsense and absurdity. Through whimsy and satire, the story explores imagination, curiosity, and the bewildering journey from childhood innocence toward self-awareness.",
                        AuthorId = lewisCarroll.Id,
                        GenreId = childrensGenre.Id
                       
                    }, //children's
                    new Book
                    {
                        Id = Guid.NewGuid(),
                        Title = "Charlotte's Web",
                        Price = 20,
                        CoverImageUrl = "https://cdn2.penguin.com.au/covers/original/9780141354828.jpg",
                        Synopsis = "Wilbur, the runt of the litter, is saved from an early death by a compassionate young girl named Fern. When Wilbur is sent to live in her uncle’s barn, he fears his fate as a farm animal raised for slaughter. There, he forms an unlikely but profound friendship with Charlotte, a wise and gentle spider. Determined to save Wilbur, Charlotte weaves miraculous messages into her web, convincing the humans that Wilbur is no ordinary pig. As seasons change and life on the farm continues, the story tenderly explores themes of friendship, sacrifice, mortality, and the quiet heroism found in simple acts of love. It is a touching meditation on the cycles of life and the enduring power of loyalty.",
                        AuthorId = ebwhite.Id,
                        GenreId = childrensGenre.Id
                    },
                    new Book
                    {
                        Id = Guid.NewGuid(),
                        Title = "The Book Thief",
                        Price = 21,
                        CoverImageUrl = "https://explainedthis.com/wp-content/uploads/2023/03/The-Book-Thief-summary-1313x2048.jpg",
                        Synopsis = "In Nazi Germany, young Liesel Meminger is sent to live with foster parents after her family is torn apart by war. Haunted by loss and surrounded by fear, Liesel discovers comfort in stolen books, even though reading is forbidden in many circumstances. With the help of her foster father, she learns to read and begins sharing stories with neighbors and a Jewish man hidden in their basement. Narrated by Death itself, the novel offers a haunting yet deeply human perspective on the brutality of war. Through words, Liesel finds resistance, hope, and connection in a world overshadowed by violence. The story explores the power of language to destroy and to heal, and the resilience of the human spirit in the darkest times.",
                        AuthorId = markuszusak.Id,
                        GenreId = historical.Id
                    }, //historical
                    new Book
                    {
                        Id = Guid.NewGuid(),
                        Title = "All the Light We Cannot See",
                        Price = 22,
                        CoverImageUrl = "https://m.media-amazon.com/images/I/81aATRwSdqL._SL1500_.jpg",
                        Synopsis = "Marie-Laure, a blind French girl, flees Paris with her father as Nazi forces invade France, carrying with them a mysterious and possibly cursed diamond from the Museum of Natural History. Meanwhile, Werner, a gifted German orphan with a talent for engineering, is recruited into the Hitler Youth and trained to track resistance fighters using radio technology. Their lives unfold on parallel paths shaped by war, morality, and survival. As their stories slowly converge in the walled city of Saint-Malo, the novel reveals the invisible threads that connect strangers in times of chaos. Lyrical and deeply moving, it reflects on the unseen light of kindness, courage, and humanity that persists even amid destruction.",
                        AuthorId = anthonydoerr.Id,
                        GenreId = historical.Id
                    },
                    new Book
                    {
                        Id = Guid.NewGuid(),
                        Title = "Good Omens",
                        Price = 23,
                        CoverImageUrl = "https://cdn.penguin.com.au/covers/original/9780552171892.jpg",
                        Synopsis = "As the apocalypse approaches, an angel named Aziraphale and a demon named Crowley find themselves in an unusual predicament: they have grown rather fond of Earth. Having lived among humans for centuries, enjoying bookstores, fine dining, and fast cars, they are reluctant to see the world end. When they discover that the Antichrist has been misplaced, they join forces in a hilariously misguided attempt to prevent Armageddon. Along the way, prophecies misfire, witch-hunters bumble about, and cosmic forces clash in absurd and unexpected ways. With sharp wit and playful satire, the novel pokes fun at good and evil, destiny and free will, suggesting that humanity may be far more complicated—and more worth saving—than celestial beings imagine.",
                        AuthorId = terrypratchett.Id,
                        GenreId = comedy.Id
                    },//comedy
                    new Book
                    {
                        Id = Guid.NewGuid(),
                        Title = "The Hitchhiker’s Guide to the Galaxy",
                        Price = 24,
                        CoverImageUrl = "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1653798065i/61184202.jpg",
                        Synopsis = "Arthur Dent’s ordinary life is abruptly shattered when Earth is demolished to make way for a hyperspace bypass. Rescued at the last moment by his eccentric friend Ford Prefect—who turns out to be an alien researcher—Arthur is thrust into a wildly unpredictable journey across the galaxy. Armed only with a towel and the electronic guidebook known as The Hitchhiker’s Guide to the Galaxy, he encounters paranoid androids, two-headed presidents, and the search for the ultimate answer to life, the universe, and everything. Blending absurd humor with surprisingly sharp philosophical insights, the novel satirizes bureaucracy, technology, and human insignificance in an incomprehensibly vast cosmos.",
                        AuthorId = douglasadams.Id,
                        GenreId = comedy.Id
                    },
                    new Book
                    {
                        Id = Guid.NewGuid(),
                        Title = "1984",
                        Price = 25,
                        CoverImageUrl = "https://s3.amazonaws.com/adg-bucket/1984-george-orwell/3423-medium.jpg",
                        Synopsis = "In the oppressive superstate of Oceania, Winston Smith works at the Ministry of Truth, where history is constantly rewritten to serve the Party’s agenda. Under the watchful eye of Big Brother, independent thought is a crime, and language itself is manipulated to limit freedom of expression. Secretly longing for truth and rebellion, Winston begins a forbidden relationship and dares to question the regime. But in a society built on surveillance, propaganda, and psychological control, even love can be weaponized. The novel presents a chilling vision of totalitarianism, exploring how power can distort reality and strip individuals of identity, autonomy, and hope.",
                        AuthorId = georgeorwell.Id,
                        GenreId = classic.Id
                    },  //classic
                    new Book
                    {
                        Id = Guid.NewGuid(),
                        Title = "Pride and Prejudice",
                        Price = 26,
                        CoverImageUrl = "https://readaloudrevival.com/wp-content/uploads/2016/05/Pride-and-Prejudice.png",
                        Synopsis = "In early 19th-century England, Elizabeth Bennet is intelligent, spirited, and unwilling to marry without affection. When the wealthy and reserved Mr. Darcy enters her social circle, misunderstandings and wounded pride create tension between them. As family pressures mount and societal expectations shape courtship, both Elizabeth and Darcy must confront their own flaws and prejudices. Through sharp wit and keen social observation, the novel examines class, morality, gender roles, and the importance of self-knowledge. Ultimately, it is a timeless exploration of love that grows not from first impressions, but from humility, growth, and mutual respect.",
                        AuthorId = janeausten.Id,
                        GenreId = classic.Id
                    },
                    new Book
                    {
                        Id = Guid.NewGuid(),
                        Title = "The Hobbit",
                        Price = 19.99m,
                        CoverImageUrl = "https://m.media-amazon.com/images/I/81uEDUfKBZL.jpg",
                        Synopsis = "Bilbo Baggins is content with his quiet life in the Shire until the wizard Gandalf and thirteen dwarves arrive at his door with a daring proposal. Reluctantly joining their quest to reclaim treasure guarded by the dragon Smaug, Bilbo is swept into a journey across dangerous mountains, dark forests, and goblin-infested caves. Along the way, he faces trolls, giant spiders, elves, and the enigmatic creature Gollum—through whom he acquires a mysterious ring of great power. What begins as an unwanted adventure becomes a transformative journey of courage and self-discovery. The novel celebrates bravery, friendship, and the hidden strength found in the most unlikely hero.",
                        AuthorId = tolkien.Id,
                        GenreId = fantasy.Id
                    }, //fantasy
                    new Book
                    {
                        Id = Guid.NewGuid(),
                        Title = "A Game of Thrones",
                        Price = 19.99m,
                        CoverImageUrl = "https://m.media-amazon.com/images/I/81GY-97b9zL.jpg",
                        Synopsis = "In the land of Westeros, summers last for years and winters can span a lifetime. Noble houses vie for control of the Iron Throne, weaving webs of political intrigue, betrayal, and shifting alliances. As tensions rise between powerful families, a looming supernatural threat gathers beyond the northern Wall. Through multiple perspectives, the novel reveals complex characters driven by ambition, loyalty, honor, and survival. Blending gritty realism with epic fantasy, the story explores the cost of power and the fragile line between heroism and villainy in a brutal and unpredictable world.",
                        AuthorId = rrmartin.Id,
                        GenreId = fantasy.Id
                    },
                    new Book
                    {
                        Id = Guid.NewGuid(),
                        Title = "The Da Vinci Code",
                        Price = 19.99m,
                        CoverImageUrl = "https://danbrown.com/wp-content/uploads/2024/10/Dan-Brown_The-Da-Vinci-Code-book-cover_2024.jpg",
                        Synopsis = "When a curator is murdered inside the Louvre Museum, symbologist Robert Langdon is drawn into a labyrinth of hidden symbols, cryptic clues, and secret societies. Teaming up with cryptologist Sophie Neveu, he uncovers a trail embedded in Renaissance art that points to a long-guarded religious secret. As they race across Europe, pursued by both law enforcement and shadowy adversaries, the mystery deepens into a conspiracy that challenges accepted history and belief. Blending art, history, theology, and suspense, the novel delivers a fast-paced thriller centered on hidden truths and the power of knowledge.",
                        AuthorId = danbrown.Id,
                        GenreId = thriller.Id
                    }, //thriller
                    new Book
                    {
                        Id = Guid.NewGuid(),
                        Title = "Gone Girl",
                        Price = 19.99m,
                        CoverImageUrl = "https://images.huffingtonpost.com/2014-08-12-GONE_GIRL.jpg",
                        Synopsis = "On their fifth wedding anniversary, Amy Dunne disappears without a trace, leaving behind signs of a struggle. Her husband Nick quickly becomes the prime suspect as media scrutiny intensifies and shocking secrets emerge. Through alternating perspectives, the novel reveals the carefully constructed facades within their marriage. As manipulation, resentment, and deception come to light, the story transforms into a chilling psychological thriller about identity, performance, and the dark complexities of modern relationships. It is a gripping exploration of how well we can ever truly know the person we love.",
                        AuthorId = gillianflynn.Id,
                        GenreId = thriller.Id
                    },
                    new Book
                    {
                        Id = Guid.NewGuid(),
                        Title = "Me Before You",
                        Price = 19.99m,
                        CoverImageUrl = "https://fontmeme.com/images/me-before-you-book-cover.jpg",
                        Synopsis = "Louisa Clark lives a modest, predictable life until she becomes caregiver to Will Traynor, a once-adventurous man left paralyzed after an accident. Initially distant and bitter, Will challenges Louisa’s worldview, while she slowly brings warmth and spontaneity into his guarded existence. As their bond deepens, both are forced to confront difficult questions about dignity, independence, and the meaning of a fulfilling life. Emotional and thought-provoking, the novel explores love not as simple romance, but as a transformative force that demands courage, compassion, and painful choices.",
                        AuthorId = jojomoyes.Id,
                        GenreId = romance.Id
                    }, //romance
                    new Book
                    {
                        Id = Guid.NewGuid(),
                        Title = "The Notebook",
                        Price = 19.99m,
                        CoverImageUrl = "https://static1.srcdn.com/wordpress/wp-content/uploads/2023/06/the-notebook-movie-poster.jpg",
                        Synopsis = "Noah Calhoun and Allie Nelson fall deeply in love one summer, despite coming from different social backgrounds. When circumstances and family pressures separate them, years pass, and life takes them in different directions. Yet their love endures, tested by time, distance, and the realities of adulthood. Framed through the reading of an old notebook, the story unfolds as a reflection on memory, devotion, and the resilience of true love. Tender and nostalgic, it portrays romance not just as passion, but as steadfast commitment through life’s trials.",
                        AuthorId = nicholassparks.Id,
                        GenreId = romance.Id
                    },
                };
                await context.Books.AddRangeAsync(books);
                await context.SaveChangesAsync();
            };
            if (!await context.Publishers.AnyAsync())
            {
                var publishers = new List<Publisher>
                {
                     new Publisher
                     {
                         Id = Guid.NewGuid(),
                         Name = "Bloomsbury Publishing",
                         Description = "no description"
                     },
                     new Publisher
                     {
                         Id = Guid.NewGuid(),
                         Name = "Harper & Brothers",
                         Description = "no description"
                     },
                     new Publisher
                     {
                         Id = Guid.NewGuid(),
                         Name = "Workman Publishing",
                         Description = "no description"
                     },
                     new Publisher
                     {
                         Id = Guid.NewGuid(),
                         Name = "Bantam Books",
                         Description = "no description"
                     }
                };
                await context.Publishers.AddRangeAsync(publishers);
                await context.SaveChangesAsync();
            }
            if (true)
            {
                var allTheLight = await context.Books.FirstAsync(b => b.Title == "All the Light We Cannot See");//
                //var hitchhikersGuide = await context.Books.FirstAsync(b => b.Title == "The Hitchhiker’s Guide to the Galaxy");//
                var book1984 = await context.Books.FirstAsync(b => b.Title == "1984");//
                var pridePrejudice = await context.Books.FirstAsync(b => b.Title == "Pride and Prejudice");//
                var hobbit = await context.Books.FirstAsync(b => b.Title == "The Hobbit");//
                var gameOfThrones = await context.Books.FirstAsync(b => b.Title == "A Game of Thrones");//
                var daVinciCode = await context.Books.FirstAsync(b => b.Title == "The Da Vinci Code");//
                var goneGirl = await context.Books.FirstAsync(b => b.Title == "Gone Girl");//
                var meBeforeYou = await context.Books.FirstAsync(b => b.Title == "Me Before You");
                var theNotebook = await context.Books.FirstAsync(b => b.Title == "The Notebook");
                allTheLight.CoverImageUrl = "https://m.media-amazon.com/images/I/81aATRwSdqL._SL1500_.jpg";
                //hitchhikersGuide.CoverImageUrl = "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1653798065i/61184202.jpg";
                book1984.CoverImageUrl = "https://s3.amazonaws.com/adg-bucket/1984-george-orwell/3423-medium.jpg";
                pridePrejudice.CoverImageUrl = "https://readaloudrevival.com/wp-content/uploads/2016/05/Pride-and-Prejudice.png";
                hobbit.CoverImageUrl = "https://m.media-amazon.com/images/I/81uEDUfKBZL.jpg";
                gameOfThrones.CoverImageUrl = "https://m.media-amazon.com/images/I/81GY-97b9zL.jpg";
                daVinciCode.CoverImageUrl = "https://danbrown.com/wp-content/uploads/2024/10/Dan-Brown_The-Da-Vinci-Code-book-cover_2024.jpg";
                goneGirl.CoverImageUrl = "https://images.huffingtonpost.com/2014-08-12-GONE_GIRL.jpg";
                meBeforeYou.CoverImageUrl = "https://fontmeme.com/images/me-before-you-book-cover.jpg";
                theNotebook.CoverImageUrl = "https://static1.srcdn.com/wordpress/wp-content/uploads/2023/06/the-notebook-movie-poster.jpg";

                await context.SaveChangesAsync();
            }
            if (!await context.Publishers_Books.AnyAsync())
            {
                var bloomsbury = await context.Publishers.FirstAsync(p => p.Name == "Bloomsbury Publishing");
                var harper = await context.Publishers.FirstAsync(p => p.Name == "Harper & Brothers");
                var workman = await context.Publishers.FirstAsync(p => p.Name == "Workman Publishing");
                var bantam = await context.Publishers.FirstAsync(p => p.Name == "Bantam Books");

                var aliceBook = await context.Books.FirstAsync(b => b.Title == "Alice's Adventures in Wonderland");//
                var charlotteWeb = await context.Books.FirstAsync(b => b.Title == "Charlotte's Web"); //
                var bookThief = await context.Books.FirstAsync(b => b.Title == "The Book Thief"); //
                var allTheLight = await context.Books.FirstAsync(b => b.Title == "All the Light We Cannot See");//
                var goodOmens = await context.Books.FirstAsync(b => b.Title == "Good Omens"); //
                var hitchhikersGuide = await context.Books.FirstAsync(b => b.Title == "The Hitchhiker’s Guide to the Galaxy");//
                var book1984 = await context.Books.FirstAsync(b => b.Title == "1984");//
                var pridePrejudice = await context.Books.FirstAsync(b => b.Title == "Pride and Prejudice");//
                var hobbit = await context.Books.FirstAsync(b => b.Title == "The Hobbit");//
                var gameOfThrones = await context.Books.FirstAsync(b => b.Title == "A Game of Thrones");//
                var daVinciCode = await context.Books.FirstAsync(b => b.Title == "The Da Vinci Code");//
                var goneGirl = await context.Books.FirstAsync(b => b.Title == "Gone Girl");//
                var meBeforeYou = await context.Books.FirstAsync(b => b.Title == "Me Before You");
                var theNotebook = await context.Books.FirstAsync(b => b.Title == "The Notebook");

                var pub_book = new List<Publisher_Book>
                {
                    new Publisher_Book
                    {
                        PublisherId = bloomsbury.Id,
                        BookId = aliceBook.Id,
                        Language = "English"
                    },
                     new Publisher_Book
                    {
                        PublisherId = bloomsbury.Id,
                        BookId = bookThief.Id,
                        Language = "English"
                    },
                      new Publisher_Book
                    {
                        PublisherId = bloomsbury.Id,
                        BookId = goodOmens.Id,
                        Language = "English"
                    },
                     new Publisher_Book
                    {
                        PublisherId = harper.Id,
                        BookId = charlotteWeb.Id,
                        Language = "English"
                    },
                     new Publisher_Book
                    {
                        PublisherId = harper.Id,
                        BookId = allTheLight.Id,
                        Language = "English"
                    },
                     new Publisher_Book
                    {
                        PublisherId = harper.Id,
                        BookId = pridePrejudice.Id,
                        Language = "English"
                    },
                     new Publisher_Book
                    {
                        PublisherId = bantam.Id,
                        BookId = book1984.Id,
                        Language = "English"
                    },
                     new Publisher_Book
                    {
                        PublisherId = bantam.Id,
                        BookId = goneGirl.Id,
                        Language = "English"
                    },
                      new Publisher_Book
                    {
                        PublisherId = bantam.Id,
                        BookId = hobbit.Id,
                        Language = "English"
                    },
                       new Publisher_Book
                    {
                        PublisherId = workman.Id,
                        BookId = hitchhikersGuide.Id,
                        Language = "English"
                    },
                        new Publisher_Book
                    {
                        PublisherId = workman.Id,
                        BookId = gameOfThrones.Id,
                        Language = "English"
                    },
                         new Publisher_Book
                    {
                        PublisherId = workman.Id,
                        BookId = daVinciCode.Id,
                        Language = "English"
                    },
                          new Publisher_Book
                    {
                        PublisherId = workman.Id,
                        BookId = meBeforeYou.Id,
                        Language = "English"
                    },
                     new Publisher_Book
                    {
                        PublisherId = bloomsbury.Id,
                        BookId = theNotebook.Id,
                        Language = "English"
                    }
                };
                await context.Publishers_Books.AddRangeAsync(pub_book);
                await context.SaveChangesAsync();
            };
            if (!await context.Events.AnyAsync())
            {
                var markus = await context.Authors
                    .FirstAsync(a => a.FullName == "Markus Zusak");
                var danbrown = await context.Authors
                    .FirstAsync(a => a.FullName == "Dan Brown");

                var events = new List<Event>
                {
                    new Event
                    {
                        Id = Guid.NewGuid(),
                        Name = "Meet and Greet with Markus Zusak",
                        DateAndTime = DateTime.UtcNow,
                        AuthorId = markus.Id,
                        Link = "https://translate.google.com/?sl=en&tl=de&op=translate"
                    },
                    new Event
                    {
                        Id = Guid.NewGuid(),
                        Name = "Meet and Greet with Dan Brown",
                        DateAndTime = DateTime.UtcNow,
                        AuthorId = danbrown.Id,
                        Link = "https://translate.google.com/?sl=en&tl=de&op=translate"
                    }
                };

                await context.Events.AddRangeAsync(events);
                await context.SaveChangesAsync();
            }
        }
    }
}

