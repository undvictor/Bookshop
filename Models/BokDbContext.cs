using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bokbutiken.Models
{
    public class BokDbContext : IdentityDbContext<IdentityUser>
    {
        public BokDbContext(DbContextOptions<BokDbContext> options) : base(options)
        {

        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //seed categories
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 1, CategoryName = "Fiction" });
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 2, CategoryName = "Science" });
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 3, CategoryName = "Nature" });

            //seed books
            modelBuilder.Entity<Book>().HasData(new Book
            {
                BookId = 1,
                Name = "Pride and prejudice",
                Price = 170.99M,
                ShortDescription = "Jane Austin",
                LongDescription = "Pride and Prejudice, which opens with one of the most famous sentences in English Literature, is an ironic novel of manners.In it the garrulous and emptyheaded Mrs Bennet has only one aim - that of finding a good match for each of her five daughters.In this she is mocked by her cynical and indolent husband. With its wit, its social precision and, above all, its irresistible heroine, Pride and Prejudice has proved one of the most enduringly popular novels in the English language. ",
                CategoryId = 1,
                ImageUrl = "Pride_and_prejudice.jpg",
                Instock = true,
                IsBookOfTheWeek = true,
                ThumbnailImageUrl = ""

            });
            modelBuilder.Entity<Book>().HasData(new Book
            {
                BookId = 2,
                Name = "The Outsider",
                Price = 199.99M,
                ShortDescription = "Albert Camus",
                LongDescription = "In The Outsider (1942), his classic existentialist novel, Camus explores thealienation of an individual who refuses to conform to social norms.Meursault, his anti - hero, will not lie.When his mother dies, he refuses to show his emotions simply to satisfy the expectations of others.And when he commits a random act of violence on a sun - drenched beach near Algiers, his lack of remorse compounds his guilt in the eyes of society and the law.Yet he is as much a victim as a criminal.",
                CategoryId = 1,
                ImageUrl = "The_Outsider.jpg",
                Instock = true,
                IsBookOfTheWeek = true,
                ThumbnailImageUrl = ""

            });
            modelBuilder.Entity<Book>().HasData(new Book
            {
                BookId = 3,
                Name = "The picture of Dorian Gray",
                Price = 149.994M,
                ShortDescription = "Oscar Wilde",
                LongDescription = "The Picture of Dorian Gray is the only published book written by Oscar Wilde. It was first published in Lippincott's Monthly Magazine on June 20, 1890. Later, Wilde was asked to edit this version, and it was published again in April 1891.[1] The story is often incorrectly called The Portrait of Dorian Gray.",
                CategoryId = 1,
                ImageUrl = "Picture_of_dorian_gray.jpg",
                Instock = true,
                IsBookOfTheWeek = true,
                ThumbnailImageUrl = ""

            });
            modelBuilder.Entity<Book>().HasData(new Book
            {
                BookId = 4,
                Name = "Orlando",
                Price = 249.99M,
                ShortDescription = "Virginia Woolf",
                LongDescription = "His longing for passion, adventure and fulfilment takes him out of his own time. Chasing a dream through the centuries, he bounds from Elizabethan England and imperial Turkey to the modern world.Will he find happiness with the exotic Russian Princess Sasha ? Or is the dashing explorer Shelmerdine the ideal man ? And what form will Orlando take on the journey - a nobleman, traveller, writer? Man or... woman?",
                CategoryId = 3,
                ImageUrl = "Orlando.jpg",
                Instock = true,
                IsBookOfTheWeek = false,
                ThumbnailImageUrl = ""

            });

            modelBuilder.Entity<Book>().HasData(new Book
            {
                BookId = 5,
                Name = "Naked Lunch",
                Price = 176.49M,
                ShortDescription = "William S. Burroughs",
                LongDescription = "Nightmarish and fiercely funny, William Burroughs' virtuoso, taboo-breaking masterpiece Naked Lunch follows Bill Lee through Interzone: a surreal, orgiastic wasteland of drugs, depravity, political plots, paranoia, sadistic medical experiments and endless, gnawing addiction.One of the most shocking novels ever written, Naked Lunch is a cultural landmark, now in a restored edition incorporating Burroughs' notes on the text, alternate drafts and outtakes from the original.",
                CategoryId = 2,
                ImageUrl = "Naked_lunch.jpg",
                Instock = true,
                IsBookOfTheWeek = false,
                ThumbnailImageUrl = ""

            });
            modelBuilder.Entity<Book>().HasData(new Book
            {
                BookId = 6,
                Name = "Les Miserables",
                Price = 399.99M,
                ShortDescription = "Victor Hugo",
                LongDescription = "Victor Hugo's tale of injustice, heroism and love follows the fortunes of Jean Valjean, an escaped convict determined to put his criminal past behind him. But his attempts to become a respected member of the community are constantly put under threat: by his own conscience, when, owing to a case of mistaken identity, another man is arrested in his place; and by the relentless investigations of the dogged Inspector Javert. It is not simply for himself that Valjean must stay free, however, for he has sworn to protect the baby daughter of Fantine, driven to prostitution by poverty.",
                CategoryId = 1,
                ImageUrl = "Les_miserables.jpg",
                Instock = true,
                IsBookOfTheWeek = false,
                ThumbnailImageUrl = ""

            });
            modelBuilder.Entity<Book>().HasData(new Book
            {
                BookId = 7,
                Name = "The Handmaid’s Tale",
                Price = 17.64M,
                ShortDescription = "Margaret Atwood",
                LongDescription = "The Republic of Gilead offers Offred only one function: to breed. If she deviates, she will, like dissenters, be hanged at the wall or sent out to die slowly of radiation sickness.But even a repressive state cannot obliterate desire - neither Offred's nor that of the two men on which her future hangs. Brilliantly conceived and executed, this powerful evocation of twenty - first centry America gives full rein to Margaret Atwood's devastating irony, wit and  astute perception.",
                CategoryId = 2,
                ImageUrl = "Handmaids tale.jpg",
                Instock = true,
                IsBookOfTheWeek = false,
                ThumbnailImageUrl = ""

            });
            modelBuilder.Entity<Book>().HasData(new Book
            {
                BookId = 8,
                Name = "Great Gatsby",
                Price = 99.99M,
                ShortDescription = "Margaret Atwood",
                LongDescription = "The Republic of Gilead offers Offred only one function: to breed. If she deviates, she will, like dissenters, be hanged at the wall or sent out to die slowly of radiation sickness.But even a repressive state cannot obliterate desire - neither Offred's nor that of the two men on which her future hangs.Brilliantly conceived and executed, this powerful evocation of twenty - first century America gives full rein to Margaret Atwood's devastating irony, wit and astute perception.",
                CategoryId = 1,
                ImageUrl = "Great_Gatsby.jpg",
                Instock = true,
                IsBookOfTheWeek = false,
                ThumbnailImageUrl = ""

            });

            modelBuilder.Entity<Book>().HasData(new Book
            {
                BookId = 9,
                Name = "Crime and punishment",
                Price = 349.99M,
                ShortDescription = "Fyodor Dostovjeskij",
                LongDescription = "Crime and Punishment is one of the greatest and most readable novels ever written.From the beginning we are locked into the frenzied consciousness of Raskolnikov who, against his better instincts, is inexorably drawn to commit a brutal double murder. From that moment on,                we share his conflicting feelings of self - loathing and pride, of contempt for and need of others, and of terrible despair and hope of redemption: and, in a remarkable transformation of the detective novel, we follow his agonised efforts to probe and confront both his own motives for, andthe consequences of, his crime.",
                CategoryId = 1,
                ImageUrl = "Crime_and_Punishment.jpg",
                Instock = true,
                IsBookOfTheWeek = false,
                ThumbnailImageUrl = ""

            });
            modelBuilder.Entity<Book>().HasData(new Book
            {
                BookId = 10,
                Name = "The Catcher In The Rye",
                Price = 179.99M,
                ShortDescription = "J.D. Salinger",
                LongDescription = "The brilliant, funny, meaningful novel that established J.D. Salinger as a leading voice in American literature--and that has instilled in millions of readers around the world a lifelong love of books. If you really want to hear about it, the first thing you will probably want to know is where I was born, and what my lousy childhood was like, were occupied and all before they had me, and all that David Copperfield kind of crap, but I don't feel like going into it, if you want to know the truth.",
                CategoryId = 3,
                ImageUrl = "Catcher_in_the_rye.jpg",
                Instock = true,
                IsBookOfTheWeek = false,
                ThumbnailImageUrl = ""

            });
            modelBuilder.Entity<Book>().HasData(new Book
            {
                BookId = 11,
                Name = "Animal farm",
                Price = 249.49M,
                ShortDescription = "George Orwell",
                LongDescription = "When the downtrodden animals of Manor Farm overthrow their master Mr Jones and take over the farm themselves, they imagine it is the beginning of life of freedom and equality.But gradually a cunning, ruthless elite among them, masterminded by the pigs Napoleon and Snowball, starts to take control. Soon the other animals discover that they are not all as equal as they thought, with another.",
                CategoryId = 3,
                ImageUrl = "Animal_Farm.jpg",
                Instock = true,
                IsBookOfTheWeek = false,
                ThumbnailImageUrl = ""

            });
            modelBuilder.Entity<Book>().HasData(new Book
            {
                BookId = 12,
                Name = "1984",
                Price = 198.4M,
                ShortDescription = "George Orwell",
                LongDescription = "Winston Smith works for the Ministry of Truth in London, chief city of Airstrip One.Big Brother stares out from every poster, the Thought Police uncover every act of betrayal.When Winston finds love with Julia, he discovers that life does not have to be dull and deadening, and awakens to new possibilities. Winston and Julia begin to question the Party; they are drawn towards conspiracy.Yet Big Brother will not tolerate dissent - even in the mind. For those with original thoughts they invented Room 101. . .",
                CategoryId = 3,
                ImageUrl = "1984.jpg",
                Instock = true,
                IsBookOfTheWeek = false,
                ThumbnailImageUrl = ""

            });


        }

    }
}
