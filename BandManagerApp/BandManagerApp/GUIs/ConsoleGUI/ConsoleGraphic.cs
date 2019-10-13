using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BandManagerApp.DataEntities;
using BandManagerApp.Engines;

namespace BandManagerApp.GUIs.ConsoleGUI
{
    class ConsoleGraphic
    {
        public Manager PrintUserLogForm(ManagerEngine managerEngine)
        {
            Console.WriteLine("Введите логин :");
            string login = Console.ReadLine();
            Console.WriteLine("Введите пароль :");
            string password = Console.ReadLine();
            return managerEngine.CheckManagerData(login, password);
        }

        public void PrintBands(BandEngine bandEngine, Manager manager)
        {
            var bands = bandEngine.GetBands(manager);
            int counter = 2;

            foreach (var band in bands)
            {
                if (counter % 2 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine($"{band.Name} {band.Country} {band.PlayGenre} {band.DateofCreation.ToString("yyyy/MM/dd")}");
                    Console.ResetColor();
                    Console.WriteLine();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine($"{band.Name} {band.Country} {band.PlayGenre} {band.DateofCreation.ToString("yyyy/MM/dd")}");
                    Console.ResetColor();
                    Console.WriteLine();
                }
                counter++;
            }
        }

        public void AddConcerttoTour(ConcertEngine concertEngine, TourEngine tourEngine)
        {
            Console.WriteLine("Введите название тура :");
            string tourName = Console.ReadLine();
            var tour = tourEngine.GetTourbyName(tourName);
            Console.WriteLine();
            Console.WriteLine($"Создание концерта в {tour.Name}");
            Console.WriteLine("Введите город :");
            string city = Console.ReadLine();
            Console.WriteLine("Введите время начала концерта :");
            string startDate = Console.ReadLine();
            Console.WriteLine("Введите время окончания концерта :");
            string endDate = Console.ReadLine();
            var concert = new Concert { City = city, StartDate = DateTime.Parse(startDate), EndDate = DateTime.Parse(endDate), TourId = tour.Id };

            if (concertEngine.AddConcertToTour(concert) != false)
                Console.WriteLine("Коцерт добавлен");
            else
                Console.WriteLine("Произошла ошибка; Концерт не добавлен");
        }

        public void PrintSongInfobyName(SongEngine songEngine)
        {
            Console.WriteLine("Введите имя композиции :");
            string name = Console.ReadLine();
            var song = songEngine.GetSongbyName(name);

            if (song != null)
                Console.WriteLine($"{song.Name} {song.Band.Name} {song.MusicAuthor} {song.TextAuthor} {song.IssueDate.ToString("yyyy/MM/dd")}");
            else
                Console.WriteLine("Такой песни не существует");
        }

        public void PrintBandSongs(SongEngine songEngine, BandEngine bandEngine)
        {
            Console.WriteLine("Введите название группы");
            string bandName = Console.ReadLine();
            var band = bandEngine.GetBandbyName(bandName);
            var songs = songEngine.GetSongsbyBand(band);
            int counter = 2;
            Console.WriteLine($"Список песен {band.Name} :");

            foreach (var song in songs)
            {
                if (counter % 2 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine($"{song.Name} {song.Band.Name} {song.MusicAuthor} {song.TextAuthor} {song.IssueDate.ToString("yyyy/MM/dd")}");
                    Console.ResetColor();
                    Console.WriteLine();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine($"{song.Name} {song.Band.Name} {song.MusicAuthor} {song.TextAuthor} {song.IssueDate.ToString("yyyy/MM/dd")}");
                    Console.ResetColor();
                    Console.WriteLine();
                }
                counter++;
            }
        }

        public void PrintTourInfo(TourEngine tourEngine)
        {
            try
            {
                Console.WriteLine("Введите название тура :");
                string tourName = Console.ReadLine();
                var tour = tourEngine.GetTourbyName(tourName);
                int counter = 2;
                Console.WriteLine($"{tour.Name} {tour.StartDate.ToString("yyyy/MM/dd")} {tour.StartDate.ToString("yyyy/MM/dd")}");
                Console.WriteLine();
                Console.WriteLine("Концерты тура :");

                foreach (var concert in tour.Concerts)
                {
                    if (counter % 2 == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine($"{concert.City} {concert.StartDate} {concert.EndDate}");
                        Console.ResetColor();
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine($"{concert.City} {concert.StartDate} {concert.EndDate}");
                        Console.ResetColor();
                        Console.WriteLine();
                    }
                    counter++;
                }
            }
            catch
            {
                Console.WriteLine("Тур с таким названием не существует");
            }
        }

        public void PrintFormtoAddSong(SongEngine songEngine, BandEngine bandEngine)
        {
            Console.WriteLine("Введите название группы :");
            string bandName = Console.ReadLine();
            var band = bandEngine.GetBandbyName(bandName);
            Console.WriteLine($"Создание песни в {band.Name}");
            Console.WriteLine("Введите имя песни :");
            string name = Console.ReadLine();
            Console.WriteLine("Введите композитора :");
            string musicAuthorName = Console.ReadLine();
            Console.WriteLine("Введите автора текста :");
            string textAuthorName = Console.ReadLine();
            Console.WriteLine("Введите дату создания песни :");
            string issueDate = Console.ReadLine();
            var song = new Song
            {
                Name = name,
                MusicAuthor = musicAuthorName,
                TextAuthor = textAuthorName,
                IssueDate = DateTime.Parse(issueDate),
                BandId = band.Id
            };

            if(songEngine.AddSong(song) != false)
                Console.WriteLine("Песня добавлена");
            else
                Console.WriteLine("Ошибка добавления");
        }

        public void PritDeedList(Dictionary<int,string> deedList)
        {
            int counter = 2;
            Console.WriteLine("Список действий :");

            foreach(var deed in deedList)
            {
                if (counter % 2 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine($"{deed.Value} - {deed.Key}");
                    Console.ResetColor();
                    Console.WriteLine();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine($"{deed.Value} - {deed.Key}");
                    Console.ResetColor();
                    Console.WriteLine();
                }
                counter++;
            }
        }
    }
}
