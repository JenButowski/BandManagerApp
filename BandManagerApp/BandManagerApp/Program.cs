﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BandManagerApp.DataContexsts;
using BandManagerApp.DataEntities;
using BandManagerApp.Engines;
using BandManagerApp.GUIs.ConsoleGUI;

namespace BandManagerApp
{
    class Program
    {
        #region engines
        private static BandEngine bandEngine = new BandEngine();

        private static ConcertEngine concertEngine = new ConcertEngine();

        private static ManagerEngine managerEngine = new ManagerEngine();

        private static SongEngine songEngine = new SongEngine();

        private static TourEngine tourEngine = new TourEngine();
        #endregion

        private static ConsoleGraphic consoleGraphic = new ConsoleGraphic();

        private static Dictionary<int, string> deedsList = new Dictionary<int, string>
        {
            { 0, "Список групп" },
            { 1, "Информация о туре" },
            { 2, "Добавить концерт в тур" },
            { 3, "Список песен группы" },
            { 4, "Информация о песни"},
            { 5, "Добавить песню в группу"}
        };

        static void Main(string[] args)
        {
        ProgStart:

            var context = new DBContext();
            var manager = consoleGraphic.PrintUserLogForm(context, managerEngine);

            if (manager != null)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Добро пожаловать {manager.Name} {manager.Surname}");
                Console.ResetColor();
                Console.WriteLine();

            DeedMenu:

                Console.Clear();
                consoleGraphic.PritDeedList(deedsList);

                int deedValue = int.Parse(Console.ReadLine());

                switch (deedValue)
                {
                    case 0:
                        Console.Clear();
                        Console.WriteLine($"{deedsList[deedValue]} :");
                        consoleGraphic.PrintBands(context, bandEngine, manager);
                        Console.WriteLine("Нажмите любую кнопку чтобы перейти в меню");
                        Console.ReadLine();
                        goto DeedMenu;
                    case 1:
                        Console.Clear();
                        consoleGraphic.PrintTourInfo(context, tourEngine);
                        Console.WriteLine("Нажмите любую кнопку чтобы перейти в меню");
                        Console.ReadLine();
                        goto DeedMenu;
                    case 2:
                        Console.Clear();
                        Console.WriteLine($"{deedsList[deedValue]} :");
                        consoleGraphic.AddConcerttoTour(context, concertEngine, tourEngine);
                        Console.WriteLine("Нажмите любую кнопку чтобы перейти в меню");
                        Console.ReadLine();
                        goto DeedMenu;
                    case 3:
                        Console.Clear();
                        Console.WriteLine($"{deedsList[deedValue]} :");
                        consoleGraphic.PrintBandSongs(context, songEngine, bandEngine);
                        Console.WriteLine("Нажмите любую кнопку чтобы перейти в меню");
                        Console.ReadLine();
                        goto DeedMenu;
                    case 4:
                        Console.Clear();
                        Console.WriteLine($"{deedsList[deedValue]} :");
                        consoleGraphic.PrintSongInfobyName(context, songEngine);
                        Console.WriteLine("Нажмите любую кнопку чтобы перейти в меню");
                        Console.ReadLine();
                        goto DeedMenu;
                    case 5:
                        Console.Clear();
                        consoleGraphic.PrintFormtoAddSong(context, songEngine, bandEngine);
                        Console.WriteLine();
                        Console.WriteLine("Нажмите любую кнопку чтобы перейти в меню");
                        Console.ReadLine();
                        goto DeedMenu;
                }
            }
            else
            {
                Console.Clear();
                Console.Beep();
                Console.WriteLine("Неправильный логин или пароль, попробуйте еще раз");
                goto ProgStart;
            }
        }
    }
}
