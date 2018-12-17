using System;
using System.Collections.Generic;
using System.Linq;

namespace ObservableMvvm
{
    public class SantasBloggerService
    {
        private Random RandomGenerator = new Random();
        private int newBloggerId = 0;

        private List<BloggerInfo> allBloggers;

        public SantasBloggerService()
        {
            allBloggers = new List<BloggerInfo>
            {
                new BloggerInfo{ Id = newBloggerId++, Name = "Duane Newman", Blog = "http://duanenewman.net/", NaughtyThreshold = -100 },
                new BloggerInfo{ Id = newBloggerId++, Name = "Matthew Groves", Blog = "https://crosscuttingconcerns.com/", NaughtyThreshold = 0 },
                new BloggerInfo{ Id = newBloggerId++, Name = "Lukáš Lánský", Blog = "https://programming.lansky.name/", NaughtyThreshold = RandomGenerator.Next(25,150) },
                new BloggerInfo{ Id = newBloggerId++, Name = "Steve Smith", Blog = "https://ardalis.com/", NaughtyThreshold = RandomGenerator.Next(25,150) },
                new BloggerInfo{ Id = newBloggerId++, Name = "Hilary Weaver-Robb", Blog = "https://g33klady.com/", NaughtyThreshold = RandomGenerator.Next(25,150) },
                new BloggerInfo{ Id = newBloggerId++, Name = "Shahed Chowdhuri", Blog = "https://wakeupandcode.com/", NaughtyThreshold = RandomGenerator.Next(25,150) },
                new BloggerInfo{ Id = newBloggerId++, Name = "Bill Sempf", Blog = "https://sempf.net/", NaughtyThreshold = RandomGenerator.Next(25,150) },
                new BloggerInfo{ Id = newBloggerId++, Name = "Luis Antonio Beltran", Blog = "https://luisbeltran.mx/", NaughtyThreshold = RandomGenerator.Next(25,150) },
                new BloggerInfo{ Id = newBloggerId++, Name = "Tim Corey", Blog = "https://www.iamtimcorey.com/", NaughtyThreshold = RandomGenerator.Next(25,150) },
                new BloggerInfo{ Id = newBloggerId++, Name = "Matthew Jones", Blog = "https://exceptionnotfound.net/", NaughtyThreshold = RandomGenerator.Next(25,150) },
                new BloggerInfo{ Id = newBloggerId++, Name = "James Hickey", Blog = "https://www.blog.jamesmichaelhickey.com/", NaughtyThreshold = RandomGenerator.Next(25,150) },
                new BloggerInfo{ Id = newBloggerId++, Name = "Calvin Allen", Blog = "https://www.calvinallen.net/", NaughtyThreshold = RandomGenerator.Next(25,150) },
                new BloggerInfo{ Id = newBloggerId++, Name = "Brant Burnett", Blog = "https://btburnett.com/", NaughtyThreshold = RandomGenerator.Next(25,150) },
                new BloggerInfo{ Id = newBloggerId++, Name = "Isaac Levin", Blog = "https://www.isaaclevin.com/", NaughtyThreshold = RandomGenerator.Next(25,150) },
                new BloggerInfo{ Id = newBloggerId++, Name = "Ryan Overton", Blog = "https://onyxprime.github.io/", NaughtyThreshold = RandomGenerator.Next(25,150) },
                new BloggerInfo{ Id = newBloggerId++, Name = "James Hickey", Blog = "https://www.blog.jamesmichaelhickey.com/", NaughtyThreshold = RandomGenerator.Next(25,150) },
                new BloggerInfo{ Id = newBloggerId++, Name = "Carl Layton", Blog = "https://www.carlserver.com/", NaughtyThreshold = RandomGenerator.Next(25,150) },
                new BloggerInfo{ Id = newBloggerId++, Name = "Jeremy Sinclair", Blog = "https://sinclairinat0r.com", NaughtyThreshold = RandomGenerator.Next(25,150) },
                new BloggerInfo{ Id = newBloggerId++, Name = "Ian Russell", Blog = "https://github.com/ijrussell/blog", NaughtyThreshold = RandomGenerator.Next(25,150) },
                new BloggerInfo{ Id = newBloggerId++, Name = "James Curran", Blog = "https://honestillusion.com/", NaughtyThreshold = RandomGenerator.Next(25,150) },
                new BloggerInfo{ Id = newBloggerId++, Name = "Caleb Jenkins", Blog = "http://developingux.com/", NaughtyThreshold = RandomGenerator.Next(25,150) },
                new BloggerInfo{ Id = newBloggerId++, Name = "Chris Woodruff", Blog = "http://www.chriswoodruff.com/", NaughtyThreshold = RandomGenerator.Next(25,150) },
                new BloggerInfo{ Id = newBloggerId++, Name = "Andrew Lock", Blog = "http://andrewlock.net/", NaughtyThreshold = RandomGenerator.Next(25,150) },
                new BloggerInfo{ Id = newBloggerId++, Name = "Simon Timms", Blog = "https://blog.simontimms.com/", NaughtyThreshold = RandomGenerator.Next(25,150) },
                new BloggerInfo{ Id = newBloggerId++, Name = "Ed Charbeneau", Blog = "https://edcharbeneau.com/", NaughtyThreshold = RandomGenerator.Next(25,150) },
                new BloggerInfo{ Id = newBloggerId++, Name = "Andres Paz", Blog = "https://www.linkedin.com/in/andrespaz/", NaughtyThreshold = RandomGenerator.Next(25,150) },
                new BloggerInfo{ Id = newBloggerId++, Name = "Amber Race", Blog = "https://ambertests.com/", NaughtyThreshold = RandomGenerator.Next(25,150) },
                new BloggerInfo{ Id = newBloggerId++, Name = "Brian Jackett", Blog = "https://briantjackett.com/", NaughtyThreshold = RandomGenerator.Next(25,150) },
                new BloggerInfo{ Id = newBloggerId++, Name = "Lee Englestone", Blog = "http://www.manchesterdeveloper.com/", NaughtyThreshold = RandomGenerator.Next(25,150) },
                new BloggerInfo{ Id = newBloggerId++, Name = "Daniel Oliver", Blog = "https://www.olivercoding.com/", NaughtyThreshold = RandomGenerator.Next(25,150) },
                new BloggerInfo{ Id = newBloggerId++, Name = "Michael Eaton", Blog = "https://samestuffdifferentday.com/", NaughtyThreshold = 150 }, //I'd make it lower if I thought you'd give a f*ck ;)
                new BloggerInfo{ Id = newBloggerId++, Name = "Kevin Griffin", Blog = "https://kevgriffin.com/", NaughtyThreshold = RandomGenerator.Next(25,150) },
                new BloggerInfo{ Id = newBloggerId++, Name = "Barret Blake", Blog = "https://barretblake.com/", NaughtyThreshold = RandomGenerator.Next(25,150) },
                new BloggerInfo{ Id = newBloggerId++, Name = "Doug Mair", Blog = "https://dougmair.blogspot.com/", NaughtyThreshold = RandomGenerator.Next(25,150) },
                new BloggerInfo{ Id = newBloggerId++, Name = "Gérald Barré", Blog = "https://www.meziantou.net/", NaughtyThreshold = RandomGenerator.Next(25,150) },
                new BloggerInfo{ Id = newBloggerId++, Name = "David Pine ", Blog = "https://davidpine.net/", NaughtyThreshold = RandomGenerator.Next(25,150) },
                new BloggerInfo{ Id = newBloggerId++, Name = "Caio Proiete", Blog = "https://caioproiete.net/", NaughtyThreshold = RandomGenerator.Next(25,150) },
                new BloggerInfo{ Id = newBloggerId++, Name = "Jonathan Danylko", Blog = "https://www.danylkoweb.com/", NaughtyThreshold = RandomGenerator.Next(25,150) },
                new BloggerInfo{ Id = newBloggerId++, Name = "Huzaifa Asif", Blog = "https://twitter.com/Huzaifa_Asif", NaughtyThreshold = RandomGenerator.Next(25,150) },
                new BloggerInfo{ Id = newBloggerId++, Name = "Baskar Rao", Blog = "https://baskarrao.wordpress.com/", NaughtyThreshold = RandomGenerator.Next(25,150) },
                new BloggerInfo{ Id = newBloggerId++, Name = "Eric Potter", Blog = "http://humbletoolsmith.com/", NaughtyThreshold = RandomGenerator.Next(25,150) },
                new BloggerInfo{ Id = newBloggerId++, Name = "Takayoshi Tanaka", Blog = "https://www.tanaka733.net/", NaughtyThreshold = RandomGenerator.Next(25,150) },
                new BloggerInfo{ Id = newBloggerId++, Name = "Szymon Rozga", Blog = "https://szymonrozga.com/", NaughtyThreshold = RandomGenerator.Next(25,150) },
                new BloggerInfo{ Id = newBloggerId++, Name = "Jim Wilcox", Blog = "http://granitestatehacker.kataire.com/", NaughtyThreshold = RandomGenerator.Next(25,150) },
                new BloggerInfo{ Id = newBloggerId++, Name = "Chris Bohatka", Blog = "https://chrisbohatka.com/", NaughtyThreshold = RandomGenerator.Next(25,150) },
                new BloggerInfo{ Id = newBloggerId++, Name = "Damian Łączak", Blog = "http://damian.laczak.net.pl/blog/", NaughtyThreshold = RandomGenerator.Next(25,150) },
                new BloggerInfo{ Id = newBloggerId++, Name = "Chris Sainty", Blog = "https://codedaze.io/", NaughtyThreshold = RandomGenerator.Next(25,150) },
                new BloggerInfo{ Id = newBloggerId++, Name = "Gregor Suttie", Blog = "https://gregorsuttie.com/", NaughtyThreshold = RandomGenerator.Next(25,150) },
            };

        }

        public List<Blogger> GetSantasBloggers()
        {
            return allBloggers
                .Select(b => new Blogger
                {
                    Id = b.Id,
                    Name = b.Name,
                    Blog = b.Blog,
                    NaughtyNiceRating = GetNaughtyRating(b)
                }).Where(b => b.NaughtyNiceRating != NaughtyOrNice.Coal)
                .ToList();
        }

        private NaughtyOrNice GetNaughtyRating(BloggerInfo b)
        {
            var rangeMin = b.NaughtyThreshold < 50 ? -5 : -10;
            var rangeMax = b.NaughtyThreshold > 100 ? 5 : 10;
            var ratingChange = RandomGenerator.Next(rangeMin, rangeMax);
            b.NaughtyThreshold += ratingChange;
            //return rating > b.NaughtyThreshold ? NaughtyOrNice.Nice : rating == b.NaughtyThreshold ? NaughtyOrNice.AlmostNaughty : NaughtyOrNice.Naughty;
            return b.NaughtyThreshold < 75 ? NaughtyOrNice.Nice : b.NaughtyThreshold < 100 ? NaughtyOrNice.Naughty : NaughtyOrNice.Coal;
        }
    }

}
