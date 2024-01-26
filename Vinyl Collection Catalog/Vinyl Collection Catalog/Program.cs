using System;

namespace VinylCatalog
{

    public class CatalogProgram
    {
        static void Main(string[] args)
        {
            outputProgramInformation();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nWhat is your name?");
            Console.ResetColor();
            string userName = Console.ReadLine();
            
            bool stop = false;
            List<Album> albumList = new List<Album>();

            while (stop != true) {

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"\n{userName}, what action would you like to take?");
                Console.ResetColor();

                string userChoice;
                requestUserChoice();
                userChoice = Console.ReadLine();

                if (userChoice == "1")
                {
                    string albumName = requestAlbumInformation("name");
                    string artistName = requestArtistInformation("name");
                    string albumYear = requestAlbumInformation("year");
                    string albumGenre = requestAlbumInformation("genre");

                    Album newAlbum = new Album(albumName, artistName, albumYear, albumGenre);
                    albumList.Add(newAlbum);

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nNew Album Added:");
                    Console.WriteLine(outputAlbumInformation(newAlbum));
                    Console.ResetColor();
                }

                else if (userChoice == "2")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nCurrent Albums in Catalog:");

                    checkForAlbums(albumList);

                    foreach (var album in albumList)
                    {
                        Console.WriteLine(outputAlbumInformation(album));
                    }
                    Console.ResetColor();

                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("\nPlease enter the name of the album you would like to delete: ");
                    Console.ResetColor();
                    string albumName = Console.ReadLine();

                    List<Album> newAlbumList = new List<Album>();

                    foreach (var album in albumList)
                    {
                        if (album.getAlbum().ToLower() != albumName.ToLower())
                        {
                            newAlbumList.Add(album);
                        }
                    }

                    albumList = newAlbumList;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\n{albumName} was deleted from the Catalog.");
                    Console.ResetColor();
                }

                else if (userChoice == "3")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nCurrent Albums in Catalog:");

                    checkForAlbums(albumList);

                    foreach (var album in albumList)
                    {
                        Console.WriteLine(outputAlbumInformation(album));
                    }
                    Console.ResetColor();
                }

                else if (userChoice == "4")
                {

                    List<string> genreNames = new List<string>();

                    foreach (var album in albumList)
                    {
                        genreNames.Add(album.getGenre());
                    }

                    var distinctGenreNames = genreNames.Distinct().ToList();

                    

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nCurrent genres in Catalog:");

                    checkForAlbums(albumList);

                    foreach (var genreName in distinctGenreNames)
                    {
                        Console.WriteLine($"\n{genreName}");
                    }
                    Console.ResetColor();

                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("\nWhat genre of albums would you like to view?");
                    Console.ResetColor();
                    string albumGenre = Console.ReadLine();

                    Console.ForegroundColor = ConsoleColor.Green;
                    foreach (var album in albumList)
                    {
                        if (album.getGenre().ToLower() == albumGenre.ToLower())
                        {
                            Console.WriteLine(outputAlbumInformation(album));
                        }
                    }
                    Console.ResetColor();
                }

                else if (userChoice == "5")
                {

                    List<string> artistNames = new List<string>();

                    foreach (var album in albumList)
                    {
                        artistNames.Add(album.getArtist());
                    }

                    var distinctArtistNames = artistNames.Distinct().ToList();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nCurrent artists with albums in Catalog:");

                    checkForAlbums(albumList);

                    foreach (var artistName in distinctArtistNames)
                    {
                        Console.WriteLine($"\n{artistName}");
                    }
                    Console.ResetColor();

                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("\nWhat artist would you like to view all albums for?");
                    Console.ResetColor();
                    string albumArtistName = Console.ReadLine();

                    Console.ForegroundColor = ConsoleColor.Green;
                    foreach (var album in albumList)
                    {
                        if (album.getArtist().ToLower() == albumArtistName.ToLower())
                        {
                            Console.WriteLine(outputAlbumInformation(album));
                        }
                    }
                    Console.ResetColor();
                }

                else if (userChoice == "6")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nThank you for using the catalog!");
                    stop = true;
                    Console.ResetColor();
                }
            }
        }

        static void outputProgramInformation()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Vinyl Catalog by Sean O'Connor");
            Console.WriteLine("Version 1.1.0");
            Console.ResetColor();
        }
        static void requestUserChoice()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n1. Add Album\n2. Remove Album\n3. Display all Albums in Collection\n4. Display all Albums of a Certain Genre\n5. Display all Albums for a Certain Artist\n6. Quit");
            Console.WriteLine("Please enter choice:");
            Console.ResetColor();
        }

        static string requestAlbumInformation(string informationRequest)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"\nPlease enter album {informationRequest.ToLower()}:");
            Console.ResetColor();
            string albumInformation = Console.ReadLine();
            return albumInformation;
        }

        static string requestArtistInformation(string informationRequest)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"\nPlease enter artist {informationRequest.ToLower()}:");
            Console.ResetColor();
            string artistInformation = Console.ReadLine();
            return artistInformation;
        }

        static string outputAlbumInformation(Album album)
        {
            return ($"\nAlbum: {album.getAlbum()} by {album.getArtist()}\nYear: {album.getYear()}\nGenre: {album.getGenre()}");
        }

        static void checkForAlbums(List<Album> albumList)
        {
            if (albumList.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nThere are currently no albums in the catalog.");
                Console.ResetColor();
            }
        }

    }

    public class Album
    {

        private string albumName { get; set; }
        private string artistName { get; set; }
        private string albumYear { get; set; }
        private string albumGenre { get; set; }

        public Album(string albumName, string artistName, string albumYear, string albumGenre)
        {
            this.albumName = albumName;
            this.artistName = artistName;
            this.albumYear = albumYear;
            this.albumGenre = albumGenre;
        }

        public void setAlbum()
        {
            Console.WriteLine("\nPlease enter album name:");
            string albumName = Console.ReadLine();

        }

        public void setArtist() {
            Console.WriteLine("\nPlease enter artist name:");
            string artistName = Console.ReadLine();
        }

        public void setYear()
        {
            Console.WriteLine("\nPlease enter album year:");
            string albumYear = Console.ReadLine();
        }

        public void setGenre()
        {
            Console.WriteLine("\nPlease enter album genre:");
            string albumGenre = Console.ReadLine();
        }

        public string getAlbum()
        {
            return (albumName);
        }

        public string getArtist()
        {
            return (artistName);
        }

        public string getYear()
        {
            return (albumYear);
        }

        public string getGenre()
        {
            return (albumGenre);
        }


    }
}


