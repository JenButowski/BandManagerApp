using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BandManagerApp.DataContexsts;
using BandManagerApp.DataEntities;
using BandManagerApp.Engines;

namespace BandManagerApp.GUIs.ConsoleGUI
{
    class ConsoleGraphic
    {
        public Manager PrintUserLogForm(DBContext context, ManagerEngine managerEngine)
        {
            Console.WriteLine("Введите логин :");
            string login = Console.ReadLine();
            Console.WriteLine("Введите пароль :");
            string password = Console.ReadLine();
            return managerEngine.CheckManagerData(context, login, password);
        }

        public void PrintBands(DBContext context, BandEngine bandEngine, Manager manager)
        {
            var bands = bandEngine.GetBands(context, manager);
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

        public void AddConcerttoTour(DBContext context, ConcertEngine concertEngine, TourEngine tourEngine)
        {
            Console.WriteLine("Введите название тура :");
            string tourName = Console.ReadLine();
            var tour = tourEngine.GetTourbyName(context, tourName);
            Console.WriteLine();
            Console.WriteLine($"Создание концерта в {tour.Name}");
            Console.WriteLine("Введите город :");
            string city = Console.ReadLine();
            Console.WriteLine("Введите время начала концерта :");
            string startDate = Console.ReadLine();
            Console.WriteLine("Введите время окончания концерта :");
            string endDate = Console.ReadLine();
            var concert = new Concert { City = city, StartDate = DateTime.Parse(startDate), EndDate = DateTime.Parse(endDate), TourId = tour.Id };

            if (concertEngine.AddConcertToTour(context, concert) != false)
                Console.WriteLine("Коцерт добавлен");
            else
                Console.WriteLine("Произошла ошибка; Концерт не добавлен");
        }

        public void PrintSongInfobyName(DBContext context, SongEngine songEngine)
        {
            Console.WriteLine("Введите имя композиции :");
            string name = Console.ReadLine();
            var song = songEngine.GetSongbyName(context, name);

            if (song != null)
                Console.WriteLine($"{song.Name} {song.Band.Name} {song.MusicAuthor} {song.TextAuthor} {song.IssueDate.ToString("yyyy/MM/dd")}");
            else
                Console.WriteLine("Такой песни не существует");
        }

        public void PrintBandSongs(DBContext context, SongEngine songEngine, BandEngine bandEngine)
        {
            Console.WriteLine("Введите название группы");
            string bandName = Console.ReadLine();
            var band = bandEngine.GetBandbyName(context, bandName);
            var songs = songEngine.GetSongsbyBand(context, band);
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

        public void PrintTourInfo(DBContext context, TourEngine tourEngine)
        {
            try
            {
                Console.WriteLine("Введите название тура :");
                string tourName = Console.ReadLine();
                var tour = tourEngine.GetTourbyName(context, tourName);
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

        public void PrintFormtoAddSong(DBContext context, SongEngine songEngine, BandEngine bandEngine)
        {
            Console.WriteLine("Введите название группы :");
            string bandName = Console.ReadLine();
            var band = bandEngine.GetBandbyName(context, bandName);
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

            if (songEngine.AddSong(context, song) != false)
                Console.WriteLine("Песня добавлена");
            else
                Console.WriteLine("Ошибка добавления");
        }

        public void PritDeedList(Dictionary<int, string> deedList)
        {
            int counter = 2;
            Console.WriteLine("Список действий :");

            foreach (var deed in deedList)
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
