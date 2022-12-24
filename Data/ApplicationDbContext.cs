using FPTLibrary.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FPTLibrary.Data
{
    public class ApplicationDbContext : IdentityDbContext <AspNetUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Order> Orders { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            SeedBook(builder);
            SeedCategory(builder);
            SeedUser(builder);
            SeedRole(builder);
            SeedOrder(builder);
        }

        private void SeedUser(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetUser>().HasData(
                new AspNetUser { Name = "Admin", Image = "https://guantanamocity.org/wp-content/uploads/2020/12/huong-dan-tao-anh-dai-dien-hoat-hinh-tren-facebook-cach-tao-avatar-facebook-1.png", Email = "admin@gmail.com", PhoneNumber = "0321169923", Roles = "Admin" },
                new AspNetUser { Name = "Customer", Image = "https://guantanamocity.org/wp-content/uploads/2020/12/huong-dan-tao-anh-dai-dien-hoat-hinh-tren-facebook-cach-tao-avatar-facebook-1.png", Email = "customer@gmail.com", PhoneNumber = "0321333923", Roles = "Customer" }
            );  ;
        }
        public void SeedOrder(ModelBuilder builder)
        {
            builder.Entity<Order>().HasData(
                new Order { Id = 1, BookId = 1, Quantity = 2, Order_Date = DateTime.Parse("2021-10-12"), Payment = Payment.Cash },
                new Order { Id = 2, BookId = 2, Quantity = 20, Order_Date = DateTime.Parse("2022-01-02"), Payment = Payment.Visa },
                new Order { Id = 3, BookId = 5, Quantity = 30, Order_Date = DateTime.Parse("2022-03-05"), Payment = Payment.Mastercard }
                );
        }
        private void SeedRole(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "HN", Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Id = "HCM", Name = "Store Owner", NormalizedName = "STORE OWNER" },
                new IdentityRole { Id = "DN", Name = "Customer", NormalizedName = "CUSTOMER" }
            );
        }
        public void SeedCategory(ModelBuilder builder)
        {
            builder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Politics", Image = "https://cdn-amz.fadoglobal.io/images/I/81o791tFXeS.jpg" },
                new Category { Id = 2, Name = "Horror", Image = "https://cdn2.f-cdn.com/contestentries/1121968/17989453/59a8471fb17b9_thumb900.jpg" },
                new Category { Id = 3, Name = "Romance", Image = "https://www.inquirer.com/resizer/rJ2GQrjd5GR5ruMdmhLbBdJesCY=/filters:format(webp)/cloudfront-us-east-1.images.arcpublishing.com/pmn/SRCJLCGZVBBPTJSRAFMSX34GOM.jpg" },
                new Category { Id = 4, Name = "Science", Image = "https://cdn0.fahasa.com/media/catalog/product/t/h/the_science_book_big_ideas_simply_explained_1_2021_08_28_12_21_00.jpg" },
                new Category { Id = 5, Name = "Science fiction & mystery", Image = "https://m.media-amazon.com/images/I/41m0T7VZwAL.jpg" },
                new Category { Id = 6, Name = "Sport", Image = "https://www.casino.org/news/wp-content/uploads/2021/06/Screen-Shot-2021-06-24-at-11.57.05-AM.png" }
                );
        }
        public void SeedBook(ModelBuilder builder)
        {
            builder.Entity<Book>().HasData(
                new Book { Id = 1, Name = "Your Name", Image = "https://upload.wikimedia.org/wikipedia/vi/b/b3/Your_Name_novel.jpg", CategoryId = 3, Author = "Makoto Shinkai", Published_Date = DateTime.Parse("2016-03-07"), Price = 500, Quantity = 30, Description = "A comet appears and mysteriously affects and connects the lives of two teenagers of the same age, a boy in the big, bustling city of Tokyo and a girl in a country village where life is slow but idyllic. They find for unknown reasons, they wake up in each other's bodies for weeks at a time. At first, they both think these experiences are just vivid dreams, but when the reality of their situations sinks in, they learn to adjust and even enjoy it. Soon they start to communicate and try to leave notes about who they are and what they are doing. But as they discover more about each other and the other's life, they uncover some disturbing hints that their distance is more than just physical and tragedy haunts them." },
                new Book { Id = 2, Name = "Dracula", Image = "https://thebookmarketng.com/wp-content/uploads/2020/08/dracula.jpg", CategoryId = 2, Author = "Bram Stoker", Published_Date = DateTime.Parse("1897-09-11"), Price = 700, Quantity = 10, Description = "The novel has no single protagonist, but opens with solicitor Jonathan Harker taking a business trip to stay at the castle of a Transylvanian noble, Count Dracula. Harker escapes the castle after discovering that Dracula is a vampire, and the Count moves to England and plagues the seaside town of Whitby. A small group, led by Abraham Van Helsing, hunt Dracula and, in the end, kill him." },
                new Book { Id = 3, Name = "The Mueller Report", Image = "https://m.media-amazon.com/images/P/B07PB76691.01._SCLZZZZZZZ_SX500_.jpg", CategoryId = 1,Published_Date = DateTime.Parse("2013-08-09"), Author = "Rosalind S. Helderman", Price = 300, Quantity = 20, Description = "One of the most urgent and important investigations ever conducted, the Mueller inquiry focuses on Donald Trump, his presidential campaign, and Russian interference in the 2016 election, and draws on the testimony of dozens of witnesses and the work of some of the country’s most seasoned prosecutors." },
                new Book { Id = 4, Name = "IT", Image= "https://d28hgpri8am2if.cloudfront.net/book_images/onix/cvr9781982127794/it-9781982127794_hr.jpg", CategoryId=2, Author = "Stephen King", Published_Date = DateTime.Parse("1986-12-09"), Price = 800, Quantity = 60, Description = "IT tells the story of seven friends who face an evil shape shifting entity that feeds on the fears of children. One of IT’s favorite disguises is a circus clown called Pennywise, otherwise known as 'Bob Gray'." },
                new Book { Id = 5, Name = "Hyperion", Image = "https://m.media-amazon.com/images/P/0399178619.01._SCLZZZZZZZ_SX500_.jpg", CategoryId = 4, Author = "Dan Simmons", Published_Date = DateTime.Parse("1990-01-03"), Price = 400, Quantity = 10, Description = "On the world called Hyperion, beyond the reach of galactic law, waits a creature called the Shrike. There are those who worship it. There are those who fear it. And there are those who have vowed to destroy it. In the Valley of the Time Tombs, where huge, brooding structures move backward through time, the Shrike waits for them all. On the eve of Armageddon, with the entire galaxy at war, seven pilgrims set forth on a final voyage to Hyperion seeking the answers to the unsolved riddles of their lives. Each carries a desperate hope—and a terrible secret. And one may hold the fate of humanity in his hands." },
                new Book { Id = 6, Name = "Ender's Game", Image = "https://images-na.ssl-images-amazon.com/images/I/81+IUsYtGTL.jpg", CategoryId = 4, Author = "Orson Scott Card", Published_Date = DateTime.Parse("1994-07-15"), Price = 350, Quantity = 30, Description = "In order to develop a secure defense against a hostile alien race's next attack, government agencies breed child geniuses and train them as soldiers. A brilliant young boy, Andrew Ender Wiggin lives with his kind but distant parents, his sadistic brother Peter, and the person he loves more than anyone else, his sister Valentine. Peter and Valentine were candidates for the soldier-training program but didn't make the cut--young Ender is the Wiggin drafted to the orbiting Battle School for rigorous military training. Ender's skills make him a leader in school and respected in the Battle Room, where children play at mock battles in zero gravity. Yet growing up in an artificial community of young soldiers, Ender suffers greatly from isolation, rivalry from his peers, pressure from the adult teachers, and an unsettling fear of the alien invaders. His psychological battles include loneliness, fear that he is becoming like the cruel brother he remembers, and fanning the flames of devotion to his beloved sister. Is Ender the general Earth needs? But Ender is not the only result of the genetic experiments. The war with the Buggers has been raging for a hundred years, and the quest for the perfect general has been underway for almost as long. Ender's two older siblings are every bit as unusual as he is, but in very different ways. Between the three of them lie the abilities to remake a world. If the world survives, that is. " },
                new Book { Id = 7, Name = "Bird at the Buzzer", Image = "https://upload.wikimedia.org/wikipedia/en/a/a3/Bird_at_the_Buzzer_cover.jpg", Author = "Jeff Goldberg", Published_Date = DateTime.Parse("2011-08-06"), CategoryId = 6, Quantity = 15, Price = 200, Description = "The main subject of the book is the Big East Tournament championship game of 2001, although the book intersperses play by play coverage of the game with background information on the entire season, as well as commentary on the players, coaches and other aspects of the two programs. The game featured in the book was neither the first nor the last meeting of the two teams in the season.[3] In January, UConn played Notre Dame at Notre Dame. The UConn team was undefeated, and ranked number one in the country at the start of the game. Notre Dame won 92–76, remained undefeated, and moved from third to the number one ranking at the next poll.[4] Both teams would also meet in the semifinals of the NCAA Tournament, with Notre Dame prevailing and then going on to win the national championship. All of the meetings between the two teams that year were important games for each team, but the game in March had multiple story lines—a tournament championship at stake, a close game in which neither team led by more than eight points at any time, a devastating injury to one of the game's best players, and finally, a game that was decided by a single basket scored in the final moments, by one of the best players in the sport, Sue Bird." }
                );
        }
    }
}
