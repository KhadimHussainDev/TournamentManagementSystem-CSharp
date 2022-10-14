using System;
using System.IO;

namespace TournamentManagement
{
    internal class Program
    {
        static int MAX_RECORD = 20;
        static string[] team_name = new string[MAX_RECORD];
        static string[] owner_name = new string[MAX_RECORD];
        static string[] team_player1_name = new string[MAX_RECORD];
        static string[] team_player2_name = new string[MAX_RECORD];
        static int[] team_player1_age = new int[MAX_RECORD];
        static int[] team_player2_age = new int[MAX_RECORD];
        static int[] team_played_matches = new int[MAX_RECORD];
        static int[] team_won_matches = new int[MAX_RECORD];
        static int[] team_lost_matches = new int[MAX_RECORD];
        static int[] team_points = new int[MAX_RECORD];
        static string[] team_name_point = new string[MAX_RECORD];

        static string[] sorted_team_name = new string[MAX_RECORD];
        static string[] sorted_owner_name = new string[MAX_RECORD];
        static string[] sorted_team_player1_name = new string[MAX_RECORD];
        static string[] sorted_team_player2_name = new string[MAX_RECORD];
        static int[] sorted_team_player1_age = new int[MAX_RECORD];
        static int[] sorted_team_player2_age = new int[MAX_RECORD];
        static int[] sorted_team_played_matches = new int[MAX_RECORD];
        static int[] sorted_team_won_matches = new int[MAX_RECORD];
        static int[] sorted_team_lost_matches = new int[MAX_RECORD];
        static int[] sorted_team_points = new int[MAX_RECORD];
        static int team_count = 0;
        static string[] tounamentName = new string[MAX_RECORD];
        static int tournamentCount = 0;
        static int[] tournamentStartDate = new int[MAX_RECORD];
        static int[] tournamentStartMonth = new int[MAX_RECORD];
        static string[] smteam1name = new string[MAX_RECORD];
        static string[] smteam2name = new string[MAX_RECORD];
        static int[] smdate = new int[MAX_RECORD];
        static int[] smmonth = new int[MAX_RECORD];
        static int[] smtime = new int[MAX_RECORD];
        static int smcount = 0;
        static bool loading = true;
        static string userName = "Pakistan";
        static string password = "92";
        static string[] fail = new string[1] { "" };

        public static object STD_OUTPUT_HANDLE { get; private set; }

        static void Main(string[] args)
        {

            if (loading)
            {
                loadData();
                loading = false;
            }

            Console.Clear();
            char login = logIn();
            if (login == '1')
            {

                if (athentication())
                {
                    clearScreen();
                    admin();
                }
                else
                {
                    Console.WriteLine("Invalid Username or Password.\nTry Again.\n");
                    clearScreen();
                    Main(fail);
                }
            }
            else if (login == '2')
            {
                clearScreen();
                user();
            }
            else if (login == 'E')
            {
                Exit();
            }
            else
            {
                Console.WriteLine("Invalid Option.\nTry Again.\n");
                clearScreen();
                Main(fail);
            }
        }
        static void clearScreen()
        {
            //____clear screen_____
            Console.Write("Press Any Key To Continue...");
            Console.ReadKey();
            Console.Clear();

        }
        static void header()
        {
            // Header

            Console.WriteLine("********************************************");
            Console.WriteLine("*       Tournament Management System       *");
            Console.WriteLine("********************************************");

        }
        static char adminMenu()
        {
            // Admin Menu
            header();
            Console.WriteLine("------ Admin Menu ------");
            Console.WriteLine("Choose An Option : ");
            Console.WriteLine("1.Add Teams.");
            Console.WriteLine("2.View All Teams.");
            Console.WriteLine("3.Manage Teams.");
            Console.WriteLine("4.Schedule Matches.");
            Console.WriteLine("5.View Schedule.");
            Console.WriteLine("6.Edit Point Table.");
            Console.WriteLine("7.View Point Table.");
            Console.WriteLine("8.Add Tournaments.");
            Console.WriteLine("9.View Tournaments.");
            Console.WriteLine("S.Search Team.");
            Console.WriteLine("P.Change Password.");
            Console.WriteLine("C.Change Profile.");
            Console.WriteLine("E.Exit.");
            char option;
            Console.WriteLine("Your Option : ");
            option = Char.Parse(Console.ReadLine());
            return option;
        }
        static char logIn()
        {
            // Login Page
            char login_option;
            header();
            Console.WriteLine("------ Log In Page ------");
            Console.WriteLine("Are you Admin or User : ");
            Console.WriteLine("1.Admin");
            Console.WriteLine("2.User");
            Console.WriteLine("E.Exit");
            Console.WriteLine("Your Option : ");
            login_option = Char.Parse(Console.ReadLine());
            return login_option;
        }
        static char userMenu()
        {
            // User Menu
            header();
            Console.WriteLine("------ User Menu ------");
            Console.WriteLine("Choose An option : ");
            Console.WriteLine("1.View All Teams.");
            Console.WriteLine("2.View Schedule.");
            Console.WriteLine("3.View Point Table.");
            Console.WriteLine("4.View Tournaments.");
            Console.WriteLine("S.Search Team.");
            Console.WriteLine("C.Change Profile.");
            Console.WriteLine("E.Exit.");

            Console.WriteLine("Your Option : ");
            char option;
            option = Char.Parse(Console.ReadLine());
            return option;
        }
        static void admin()
        {
            // Admin Portion
            Console.Clear();
            while (true)
            {
                char option = adminMenu();

                if (option == 'E')
                {
                    Exit();
                }
                clearScreen();
                header();
                if (option == '1')
                {
                    // Add Team
                    addTeam();
                }
                else if (option == '2')
                {
                    // Display Teams
                    if (team_count >= 1)
                    {
                        Console.WriteLine("Admin Menu > View All Teams :");
                        displayTeams();
                        recomendation();
                    }
                    else
                    {
                        Console.WriteLine("You should add at least 1 team to view it.");
                    }
                }

                else if (option == '3')
                {
                    // Manage Teams
                    manageTeams();
                }
                else if (option == '4')
                {
                    // Schedule Matches
                    scheduleMatches();
                }
                else if (option == '5')
                {
                    // View Match Schedule
                    if (smcount >= 1)
                    {
                        matchSchedule();
                    }
                    else
                    {
                        Console.WriteLine("Currently No Schedule is Available.");
                    }
                }
                else if (option == '6')
                {
                    // Edit Point Table
                    editPointTable();
                }
                else if (option == '7')
                {
                    // Display Point Table
                    if (team_count >= 2)
                    {
                        displayPointTable();
                    }
                    else
                    {
                        Console.WriteLine("You Should Add At Least 2 Teams to view point Table.");
                    }
                }
                else if (option == 'C')
                {
                    // Login Page
                    Console.Clear();
                    Main(fail);
                }
                else if (option == 'P')
                {
                    changePassword();
                }
                else if (option == '8')
                {
                    addTournaments();
                }
                else if (option == '9')
                {
                    tournaments();
                }
                else if (option == 'S')
                {
                    searchTeam();
                }
                else
                {
                    Console.WriteLine("You Choosed Invalid Option .");
                }
                clearScreen();
            }
        }
        static void user()
        {
            // User Portion
            while (true)
            {
                Console.Clear();
                char option1 = userMenu();
                if (option1 == 'E')
                {
                    Exit();
                }
                clearScreen();
                header();
                if (option1 == '1')
                {
                    // View All Teams
                    if (team_count >= 1)
                    {
                        Console.WriteLine("User Menu > View All Teams :");
                        displayTeams();
                        recomendation();
                    }
                    else
                    {
                        Console.WriteLine("Not Enough Data To Show.");
                    }
                }
                else if (option1 == '2')
                {
                    // View Match Schedule
                    if (smcount >= 1)
                    {
                        matchSchedule();
                    }
                    else
                    {
                        Console.WriteLine("Currently No Schedule is Available.");
                    }
                }
                else if (option1 == '3')
                {
                    // Display Point Table
                    if (team_count < 2)
                    {
                        Console.WriteLine("Not Enough Data To Show.");
                    }
                    else
                    {
                        displayPointTable();
                    }
                }
                else if (option1 == 'C')
                {
                    // Change Profile
                    Console.Clear();
                    Main(fail);
                }
                else if (option1 == '4')
                {
                    tournaments();
                }
                else if (option1 == 'S')
                {
                    searchTeam();
                }
                else
                {
                    Console.WriteLine("Invalid Option.");
                }
                clearScreen();
            }
        }

        static void addTeam()
        {
            // Add Team Information
            string teamName = "\0";
            string ownerName = "";
            string player1_name = "";
            string player2_name = "";
            int player1_age;
            int player2_age;
            Console.Write("Admin Menu > Add Teams :");
            Console.Write("\n");
            Console.Write("Enter Team Name : ");

            teamName = Console.ReadLine();
            Console.Write("Enter Name of Owner : ");
            ownerName = Console.ReadLine();
            Console.Write("Enter Players : ");
            Console.Write("\n");
            Console.Write("Enter Name of Captain :");
            player1_name = Console.ReadLine();
            Console.Write("Enter His Age :");
            player1_age = int.Parse(Console.ReadLine());
            Console.Write("Enter Name of Vice Captain :");

            player2_name = Console.ReadLine();
            Console.Write("Enter His Age :");
            player2_age = int.Parse(Console.ReadLine());
            // Add Team Information into Array
            addIntoArray(teamName, ownerName, player1_name, player1_age, player2_name, player2_age);
        }
        static void addIntoArray(string teamName, string ownerName, string player1_name, int player1_age, string player2_name, int player2_age)
        {
            // Add Team Information into Array
            team_name[team_count] = teamName;
            team_name_point[team_count] = teamName;
            owner_name[team_count] = ownerName;
            team_player1_name[team_count] = player1_name;
            team_player1_age[team_count] = player1_age;
            team_player2_name[team_count] = player2_name;
            team_player2_age[team_count] = player2_age;
            team_count++;
        }
        static void displayTeams()
        {
            // Display Teams



            Console.Write("{0,-10}", "No.");
            Console.Write("{0,-25}", "Teams");
            Console.WriteLine("{0,-25}", "Owners");


            for (int i = 0; i < team_count; i++)
            {
                Console.Write("{0,-10}", i + 1);
                Console.Write("{0,-25}", team_name[i]);
                Console.WriteLine("{0,-25}", owner_name[i]);
            }
        }
        static void removeTeam()
        {
            // Remove Team
            Console.Write("Admin Menu > Manage Team > Remove Team : ");
            Console.Write("\n");
            displayTeams();
            Console.Write("Choose Team You Want To Remove i.e 1 : ");
            int edit;
            edit = int.Parse(Console.ReadLine());
            int idx = -1;
            if (edit <= team_count)
            {
                for (int i = 0; i < team_count; i++)
                {
                    if (team_name[edit - 1] == team_name_point[i])
                    {
                        idx = i;
                    }
                }
                team_name_point[idx] = "\0";
                sorted_team_played_matches[idx] = 0;
                sorted_team_won_matches[idx] = 0;
                sorted_team_lost_matches[idx] = 0;
                sorted_team_points[idx] = 0;
                team_name[edit - 1] = "\0";
                owner_name[edit - 1] = "\0";
                team_player1_name[edit - 1] = "\0";
                team_player1_age[edit - 1] = 0;
                team_player2_name[edit - 1] = "\0";
                team_player2_age[edit - 1] = 0;
                Console.Write("Team Was Removed.");
                Console.Write("\n");
                reArrangeTeams();
            }
            else
            {
                Console.Write("Invalid Team.");
                Console.Write("\n");
            }
        }
        static void editTeam()
        {
            // Edit Team
            Console.Write("Admin Menu > Manage Team > Edit Team : ");
            Console.Write("\n");
            displayTeams();
            Console.Write("Choose Team You Want To Edit i.e 1 : ");
            int edit;
            edit = int.Parse(Console.ReadLine());
            if (edit <= team_count)
            {

                Console.Write("Update Team Informations : ");
                Console.Write("\n");
                Console.Write("Enter Team Name : ");

                team_name[edit - 1] = Console.ReadLine();
                team_name_point[edit - 1] = team_name[edit - 1];
                Console.Write("Enter Name of Owner : ");
                owner_name[edit - 1] = Console.ReadLine();
                Console.Write("Enter Players : ");
                Console.Write("\n");
                Console.Write("Enter Name of Captain :");
                team_player1_name[edit - 1] = Console.ReadLine();
                Console.Write("Enter His Age :");
                team_player1_age[edit - 1] = int.Parse(Console.ReadLine());
                Console.Write("Enter Name of Vice Captain :");

                team_player2_name[edit - 1] = Console.ReadLine();
                Console.Write("Enter His Age :");
                team_player2_age[edit - 1] = int.Parse(Console.ReadLine());
            }
            else
            {
                Console.Write("Invalid Team.");
                Console.Write("\n");
            }
        }
        static void manageTeams()
        {
            // Manage Teams
            if (team_count >= 1)
            {
                Console.Write("Admin Menu > Manage Teams :");
                Console.Write("\n");
                Console.Write("Choose one Option : ");
                Console.Write("\n");
                Console.Write("1.Edit Team.");
                Console.Write("\n");
                Console.Write("2.Remove Team.");
                Console.Write("\n");
                char op;
                Console.Write("Your Option : ");
                op = Console.ReadLine()[0];

                if (op == '2')
                {
                    removeTeam();

                } // End of op==2 ie Remove Team
                else if (op == '1')
                {
                    editTeam();

                } // End of op==1 ie Edit Team
                else
                {
                    Console.Write("Invalid Option");
                    Console.Write("\n");
                }
            }

            else
            {
                Console.Write("You Should Add At Least 1 Team To Manage it.");
                Console.Write("\n");
            }
        }
        static void scheduleMatches()
        {
            // Schedule Matches
            string team1name = "";
            string team2name = "";
            int date;
            int month;
            int time;
            bool check = false;
            Console.Write("Main Menu > Schedule Matches : ");
            Console.Write("\n");
            if (team_count >= 2)
            {
                displayTeams();
                Console.Write("Enter Name of First Team : ");

                team1name = Console.ReadLine();
                Console.Write("Enter Name of 2nd Team : ");
                team2name = Console.ReadLine();
                if (team1name != team2name)
                {
                    for (int i = 0; i < team_count; i++)
                    {
                        if (team1name == team_name[i])
                        {
                            for (int j = 0; j < team_count; j++)
                            {
                                if (team2name == team_name[j])
                                {

                                    while (true)
                                    {
                                        Console.Write("Enter Date (1-31) : ");
                                        date = int.Parse(Console.ReadLine());
                                        if (date < 1 || date > 31)
                                        {
                                            Console.Write("Invalid Date.\nTry Again.");
                                            Console.Write("\n");
                                            continue;
                                        }
                                        break;
                                    }
                                    while (true)
                                    {
                                        Console.Write("Enter Month (1-12) : ");
                                        month = int.Parse(Console.ReadLine());
                                        if (month < 1 || month > 12)
                                        {
                                            Console.Write("Invalid Month.\nTry Again.");
                                            Console.Write("\n");
                                            continue;
                                        }
                                        break;
                                    }
                                    time = date + (month * 30);
                                    Console.Write("Match is Added in Schedule.");
                                    Console.Write("\n");
                                    scheduleInArray(team1name, team2name, date, month, time);
                                    check = true;
                                    break;
                                }
                            }
                        }
                    }
                    if (!check)
                    {
                        Console.Write("Team Names Not Found in added Teams.\nTry Again.");
                        Console.Write("\n");
                        Console.Write("Press Any Key to Try Again and 'e' to go to Admin Menu...");
                        char ch;
                        ch = Char.Parse(Console.ReadLine());
                        if (ch == 'e')
                        {
                            admin();
                        }
                        Console.Clear();
                        header();
                        scheduleMatches();
                    }
                }
                else
                {
                    Console.Write("A Team Cannot Play With Itself.");
                    Console.Write("\n");
                    Console.Write("Press Any Key to Try Again and 'e' to go to Admin Menu...");
                    char ch;
                    ch = Char.Parse(Console.ReadLine());
                    if (ch == 'e')
                    {
                        admin();
                    }
                    Console.Clear();
                    header();
                    scheduleMatches();
                }
            }
            else
            {
                Console.Write("Please Enter At Least 2 Teams To Schedule Matches.");
                Console.Write("\n");
            }
        }
        static void matchSchedule()
        {
            // Sort Matches with respect to Date
            for (int i = 0; i < smcount; i++)
            {
                for (int j = i + 1; j < smcount; j++)
                {
                    if (smtime[i] > smtime[j])
                    {
                        swapInt(ref smtime[i], ref smtime[j]);
                        swapInt(ref smdate[i], ref smdate[j]);
                        swapInt(ref smmonth[i], ref smmonth[j]);
                        swapStr(ref smteam1name[i], ref smteam1name[j]);
                        swapStr(ref smteam2name[i], ref smteam2name[j]);
                    }
                }
            }
            displaySchedule();
        }
        static void displaySchedule()
        {
            // Display Schedule
            Console.Write("Match Schedule : ");
            Console.Write("\n");
            for (int i = 0; i < smcount; i++)
            {
                int a = 5;
                if (i < 16)
                {
                    a = i + 2;
                }
                else
                {
                    i = i / 15;
                    a = i + 1;
                }


                Console.Write("Match No.");
                Console.Write(i + 1);
                Console.Write(" : ");
                Console.Write("{0,-25}", smteam1name[i]);
                Console.Write("{0,-25}", "vs\t");
                Console.Write("{0,-25}", smteam2name[i]);
                Console.Write("{0,-25}", " on ");
                Console.Write("{0,-25}", smdate[i]);
                Console.Write("{0,-25}", "/");
                Console.Write("{0,-25}", smmonth[i]);
                Console.WriteLine("{0,-25}", "/2022");
            }

        }
        static void editPointTable()
        {
            // Edit Point Table
            Console.Write("Admin Menu > Edit Point Table : ");
            Console.Write("\n");
            if (team_count >= 2)
            {
                displayTeams();
                Console.Write("Choose Team You Want To Edit i.e 1 : ");
                int edit;
                edit = int.Parse(Console.ReadLine());
                if (edit <= team_count)
                {
                    teamMatch(edit);
                    recomendation();
                }
                else
                {
                    Console.Write("Invalid Team.");
                    Console.Write("\n");
                }
            }
            else
            {
                Console.Write("You Should Add Two Teams To Edit Point Table.");
                Console.Write("\n");
            }
        }
        static void displayPointTable()
        {
            // Display Point Table (Sorted)
            Console.Write("Point Table : ");
            Console.Write("\n");
            Console.Write("\n");

            Console.Write("{0,-25}", "TeamName");
            Console.Write("{0,-25}", "Total Played Matches");
            Console.Write("{0,-25}", "Won Matches");
            Console.Write("{0,-25}", "Lost Matches");
            Console.WriteLine("{0,-25}", "Points");
            sorting();

            for (int i = 0; i < team_count; i++)
            {
                Console.Write("{0,-25}", team_name_point[i]);
                Console.Write("{0,-25}", sorted_team_played_matches[i]);
                Console.Write("{0,-25}", sorted_team_won_matches[i]);
                Console.Write("{0,-25}", sorted_team_lost_matches[i]);
                Console.WriteLine("{0,-25}", sorted_team_points[i]);
            }
        }
        static void sorting()
        {
            // Sort Point Table
            for (int i = 0; i < team_count; i++)
            {
                for (int j = i + 1; j < team_count; j++)
                {
                    if (sorted_team_points[i] < sorted_team_points[j])
                    {
                        swapInt(ref sorted_team_points[i], ref sorted_team_points[j]);
                        swapInt(ref sorted_team_played_matches[i], ref sorted_team_played_matches[j]);
                        swapInt(ref sorted_team_won_matches[i], ref sorted_team_won_matches[j]);
                        swapInt(ref sorted_team_lost_matches[i], ref sorted_team_lost_matches[j]);
                        swapStr(ref team_name_point[i], ref team_name_point[j]);
                    }
                }
            }
        }

        static void reArrangeTeams()
        {
            // ReArrange Teams After team is removed
            for (int i = 0; i < team_count; i++)
            {
                for (int j = i + 1; j < team_count; j++)
                {
                    if (team_name[i] == "\0")
                    {
                        swapStr(ref team_name[i], ref team_name[j]);
                        swapStr(ref team_name_point[i], ref team_name_point[j]);
                        swapStr(ref owner_name[i], ref owner_name[j]);
                        swapStr(ref team_player1_name[i], ref team_player1_name[j]);
                        swapInt(ref team_player1_age[i], ref team_player1_age[j]);
                        swapStr(ref team_player2_name[i], ref team_player2_name[j]);
                        swapInt(ref team_player2_age[i], ref team_player2_age[j]);
                    }
                }
            }
            for (int i = 0; i < team_count; i++)
            {
                for (int j = i + 1; j < team_count; j++)
                {
                    if (team_name_point[i] == "\0")
                    {
                        swapStr(ref team_name_point[i], ref team_name_point[j]);
                        swapInt(ref sorted_team_played_matches[i], ref sorted_team_played_matches[j]);
                        swapInt(ref sorted_team_won_matches[i], ref sorted_team_won_matches[j]);
                        swapInt(ref sorted_team_lost_matches[i], ref sorted_team_lost_matches[j]);
                        swapInt(ref sorted_team_points[i], ref sorted_team_points[j]);
                    }
                }
            }
            team_count--;
        }
        static void storeTeamsInFile()
        {
            // Store Teams Data in txt File
            string path = "E:\\2nd Semester\\Projects In C#\\TournamentManagement\\Data Files\\TeamInformation.txt";
            StreamWriter sw = new StreamWriter(path, false);
            for (int i = 0; i < team_count; i++)
            {
                sw.WriteLine(team_name[i] + "," + owner_name[i] + "," + team_player1_name[i] + "," + team_player1_age[i] + "," + team_player2_name[i] + "," + team_player2_age[i]);
            }
            sw.Flush();
            sw.Close();
        }
        static void loadTeamsFromFile()
        {
            // Load Teams Data in txt File
            string teamName = "\0";
            string ownerName = "";
            string player1_name = "";
            string player2_name = "";
            int player1_age;
            int player2_age;
            string line = "";

            string path = "E:\\2nd Semester\\Projects In C#\\TournamentManagement\\Data Files\\TeamInformation.txt";
            StreamReader sr = new StreamReader(path);
            while (!sr.EndOfStream)
            {
                line = sr.ReadLine();
                teamName = parsing(line, 1);
                ownerName = parsing(line, 2);
                player1_name = parsing(line, 3);
                player1_age = int.Parse(parsing(line, 4));
                player2_name = parsing(line, 5);
                player2_age = int.Parse(parsing(line, 6));

                addIntoArray(teamName, ownerName, player1_name, player1_age, player2_name, player2_age);
            }
            sr.Close();
        }
        static void storePointsInFile()
        {
            // Store Teams Points Data in txt File
            string path = "E:\\2nd Semester\\Projects In C#\\TournamentManagement\\Data Files\\TeamPoints.txt";
            StreamWriter sw = new StreamWriter(path, false);
            for (int i = 0; i < team_count; i++)
            {
                sw.WriteLine(team_name_point[i] + "," + sorted_team_played_matches[i] + "," + sorted_team_won_matches[i] + "," + sorted_team_lost_matches[i] + "," + sorted_team_points[i]);

            }
            sw.Flush();
            sw.Close();
        }
        static void loadPointsFromFile()
        {
            // Load Teams Points Data in txt File
            string path = "E:\\2nd Semester\\Projects In C#\\TournamentManagement\\Data Files\\TeamPoints.txt";
            StreamReader sr = new StreamReader(path);
            string line = "";
            int i = 0;
            while (!sr.EndOfStream)
            {
                line = sr.ReadLine();
                team_name_point[i] = parsing(line, 1);
                sorted_team_played_matches[i] = int.Parse(parsing(line, 2));
                sorted_team_won_matches[i] = int.Parse(parsing(line, 3));
                sorted_team_lost_matches[i] = int.Parse(parsing(line, 4));
                sorted_team_points[i] = int.Parse(parsing(line, 5));
                i++;
            }
            sr.Close();
        }
        static void scheduleInArray(string team1name, string team2name, int date, int month, int time)
        {
            // Add Schedule in Array
            smteam1name[smcount] = team1name;
            smteam2name[smcount] = team2name;
            smdate[smcount] = date;
            smmonth[smcount] = month;
            smtime[smcount] = time;
            smcount++;
        }
        static void storeScheduleInFile()
        {
            string path = "E:\\2nd Semester\\Projects In C#\\TournamentManagement\\Data Files\\TeamSchedule.txt";
            StreamWriter sw = new StreamWriter(path, false);
            // Store Teams Schedule Data in txt File
            for (int i = 0; i < smcount; i++)
            {
                sw.WriteLine(smteam1name[i] + "," + smteam2name[i] + "," + smdate[i] + "," + smmonth[i] + "," + smtime[i]);

            }
            sw.Flush();
            sw.Close();
        }
        static void loadScheduleFromFile()
        {
            // Load Teams Schedule Data in txt File
            string path = "E:\\2nd Semester\\Projects In C#\\TournamentManagement\\Data Files\\TeamSchedule.txt";
            StreamReader sw = new StreamReader(path);
            string team1name = "";
            string team2name = "";
            string line = "";
            int date;
            int month;
            int time;
            while (!sw.EndOfStream)
            {
                line = sw.ReadLine();
                team1name = parsing(line, 1);
                team2name = parsing(line, 2);
                date = int.Parse(parsing(line, 3));
                month = int.Parse(parsing(line, 4));
                time = int.Parse(parsing(line, 5));

                scheduleInArray(team1name, team2name, date, month, time);
            }

            sw.Close();
        }
        static void storeData()
        {
            // Store All Data in txt files
            storePassword();
            storeScheduleInFile();
            storePointsInFile();
            storeTeamsInFile();
            storeTournamentInFile();
        }
        static void loadData()
        {
            // Load All Data from txt files
            loadTeamsFromFile();
            loadPassword();
            loadScheduleFromFile();
            loadPointsFromFile();
            loadTournamentFromFile();
        }
        static void Exit()
        {
            // Exit Program

            Console.Write("Thanks For Using... \n");
            storeData();
            Console.Write("Press Any Key To Exit ....");
            Console.ReadKey();
            Console.Clear();
            Environment.Exit(1);
        }
        static void changePassword()
        {
            bool find = false;
            Console.Write("Change Password : ");
            Console.Write("\n");
            string username = "";
            string pasword = "";
            Console.Write("Enter your Old username: ");

            username = Console.ReadLine();
            Console.Write("Enter your Old password: ");
            pasword = Console.ReadLine();
            if (username == userName && pasword == password)
            {
                Console.Write("Enter your New username: ");
                username = Console.ReadLine();
                Console.Write("Enter your New password: ");
                pasword = Console.ReadLine();
                for (int i = 0; pasword[i] != '\0'; i++)
                {
                    if (pasword[i] == ',')
                    {
                        find = true;
                    }
                }
                for (int i = 0; username[i] != '\0'; i++)
                {
                    if (username[i] == ',')
                    {
                        find = true;
                    }
                }
                if (find)
                {
                    Console.Write("You Cannot Add Comma in Your Username or Password.");
                    Console.Write("\n");
                }
                else
                {
                    userName = username;
                    password = pasword;
                    Console.Write("Password Changed Successfully.\n");
                }
            }
            else
            {
                Console.Write("Invalid Username or Password.\n");
            }
        }
        static void loadPassword()
        {
            string path = "E:\\2nd Semester\\Projects In C#\\TournamentManagement\\Data Files\\Password.txt";
            StreamReader sr = new StreamReader(path);
            string user = "";
            string pass = "";
            string line = "";
            line = sr.ReadLine();
            user = parsing(line, 1);
            pass = parsing(line, 2);

            sr.Close();
            if (user != "\0")
            {
                userName = user;
                password = pass;
            }
        }
        static void storePassword()
        {
            string path = "E:\\2nd Semester\\Projects In C#\\TournamentManagement\\Data Files\\Password.txt";
            StreamWriter sw = new StreamWriter(path, false);

            sw.WriteLine(userName + "," + password);


            sw.Close();
        }

        static void teamMatch(int edit)
        {
            int total;
            int won;
            Console.Write("No. of Total Played Matches : ");
            total = int.Parse(Console.ReadLine());
            Console.Write("Won Matches :");
            won = int.Parse(Console.ReadLine());
            if (won <= total)
            {
                team_won_matches[edit - 1] = won;
                team_played_matches[edit - 1] = total;
                team_lost_matches[edit - 1] = team_played_matches[edit - 1] - team_won_matches[edit - 1];
                team_points[edit - 1] = 2 * team_won_matches[edit - 1];
                int idx = 0;
                for (int i = 0; i < team_count; i++)
                {
                    if (team_name[edit - 1] == team_name_point[i])
                    {
                        idx = i;
                    }
                }

                sorted_team_won_matches[idx] = team_won_matches[edit - 1];
                sorted_team_played_matches[idx] = team_played_matches[edit - 1];
                sorted_team_lost_matches[idx] = team_lost_matches[edit - 1];
                sorted_team_points[idx] = team_points[edit - 1];
                Console.Write("Point Table updated Successfully.");
                Console.Write("\n");
            }
            else
            {
                Console.Write("Won Matches Cannot exceed Total Matches.\n");
                Console.Write("Enter Carrect Information.\n");
                teamMatch(edit);
            }
        }
        static void tournaments()
        {
            Console.Write("Tournaments : ");
            Console.Write("\n");
            if (tournamentCount == 0)
            {
                Console.Write("Due To Covid-19 Tounaments are Postponed.");
                Console.Write("\n");
                Console.Write("For New Updates Keep Visiting.");
                Console.Write("\n");
            }
            else
            {
                for (int i = 0; i < tournamentCount; i++)
                {
                    Console.Write("-->The ");
                    Console.Write(tounamentName[i]);
                    Console.Write(" is Starting From ");
                    Console.Write(tournamentStartDate[i]);
                    Console.Write("/");
                    Console.Write(tournamentStartMonth[i]);
                    Console.Write("/2022");
                    Console.Write("\n");
                }

            }
        }
        static void addTournaments()
        {
            Console.Write("Add Tournaments : ");
            Console.Write("\n");
            string name = "";
            int date;
            int month;
            Console.Write("Enter Name Of Tournament : ");

            name = Console.ReadLine();
            while (true)
            {
                Console.Write("Enter Starting Date (1-31) : ");
                date = int.Parse(Console.ReadLine());
                if (date < 1 || date > 31)
                {
                    Console.Write("Invalid Date.\nTry Again.");
                    Console.Write("\n");
                    continue;
                }
                break;
            }
            while (true)
            {
                Console.Write("Enter Starting Month (1-12) : ");
                month = int.Parse(Console.ReadLine());
                if (month < 1 || month > 12)
                {
                    Console.Write("Invalid Month.\nTry Again.");
                    Console.Write("\n");
                    continue;
                }
                break;
            }
            Console.Write("Tournament is Added Successfully.");
            Console.Write("\n");
            addTournamentsIntoArrays(name, date, month);
        }
        static void addTournamentsIntoArrays(string name, int date, int month)
        {
            tounamentName[tournamentCount] = name;
            tournamentStartDate[tournamentCount] = date;
            tournamentStartMonth[tournamentCount] = month;
            tournamentCount++;
        }
        static void storeTournamentInFile()
        {
            string path = "E:\\2nd Semester\\Projects In C#\\TournamentManagement\\Data Files\\Tournament.txt";
            StreamWriter sw = new StreamWriter(path, false);
            for (int i = 0; i < tournamentCount; i++)
            {
                sw.WriteLine(tounamentName[i] + "," + tournamentStartDate[i] + "," + tournamentStartMonth[i]);

            }
            sw.Flush();
            sw.Close();
        }
        static void loadTournamentFromFile()
        {
            string path = "E:\\2nd Semester\\Projects In C#\\TournamentManagement\\Data Files\\Tournament.txt";
            StreamReader sr = new StreamReader(path);
            string line = "";

            string name = "";
            int date;
            int month;
            while (!sr.EndOfStream)
            {
                line = sr.ReadLine();
                name = parsing(line, 1);
                date = int.Parse(parsing(line, 2));
                month = int.Parse(parsing(line, 3));

                addTournamentsIntoArrays(name, date, month);

            }
            sr.Close();
        }
        static void searchTeam()
        {
            string name = "";
            bool b = true;
            Console.Write("Search Team : ");
            Console.Write("\n");
            Console.Write("Enter the Name of Team : ");

            name = Console.ReadLine();
            for (int i = 0; i < team_count; i++)
            {
                if (team_name[i] == name)
                {
                    Console.Write("TeamName\tOwner\n");

                    Console.Write(team_name[i]);
                    Console.Write("\t\t");
                    Console.Write(owner_name[i]);
                    Console.Write("\n");
                    b = false;
                }
            }
            if (b)
            {
                Console.Write("No Team found With This Name. ");
                Console.Write("\n");
            }
        }
        static bool athentication()
        {
            string username = "";
            string password1 = "";

            Console.Write("Enter username : ");
            username = Console.ReadLine();
            Console.Write("Enter Password : ");
            password1 = Console.ReadLine();
            if (userName == username && password == password1)
            {
                Console.Write("Congratulations! Login Successful.");
                Console.Write("\n");
                return true;
            }
            return false;
        }
        static string parsing(string line, int field)
        {
            int comma = 1;
            string item = "";
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == ',')
                {
                    comma++;
                }
                else if (field == comma)
                {
                    item = item + line[i];
                }
            }
            return item;
        }
        static void recomendation()
        {
            Console.Write("\n");

            Console.Write("Recomendation : ");
            Console.Write("\n");

            Console.Write("\n");
            Console.Write("Do You Want to view Point Table ?? ('y' for yes and any key to skip ) : ");
            char ch;
            ch = Console.ReadKey().KeyChar;

            Console.Write("\n");
            if (ch == 'y' || ch == 'Y')
            {
                clearScreen();
                header();
                displayPointTable();
            }
        }
        static void swapInt(ref int a, ref int b)
        {
            int temp;
            temp = a;
            a = b;
            b = temp;
        }
        static void swapStr(ref string a, ref string b)
        {
            string temp;
            temp = a;
            a = b;
            b = temp;
        }


    }
}