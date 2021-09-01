using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NoteTakingApp.DataAccess;
using NoteTakingApp.DataAccess.Entities;
using NoteTakingApp.Domain;

namespace NoteTakingApp.ConsoleApp
{
    // Entity Framework Core
    // database-first approach steps...
    /*
     * 1. recommended: have a separate data access library project.
     * 2. install Microsoft.EntityFrameworkCore.Design and Microsoft.EntityFrameworkCore.SqlServer
     *    to the project you'll put the EF model in.
     * 3. using Git Bash / terminal, from the project folder run (split into several lines for clarity):
     *    dotnet ef dbcontext scaffold <connection-string-in-quotes>
     *      Microsoft.EntityFrameworkCore.SqlServer
     *      --force
     *      --no-onconfiguring
     *    https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/dotnet#dotnet-ef-dbcontext-scaffold
     *    (if you don't have dotnet ef installed, run: "dotnet tool install --global dotnet-ef")
     *    (this will fail if your projects do not compile)
     * 4. any time you change the structure of the tables (DDL), go to step 3.
     */

    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = File.ReadAllText("C:/revature/notesdb-connection-string.txt");

            var options = new DbContextOptionsBuilder<NotesDbContext>()
                .LogTo(message => Debug.WriteLine(message))
                .UseSqlServer(connectionString)
                .Options;
            using var context = new NotesDbContext(options);

            IRepository repo = new Repository(context);

            Console.WriteLine("Welcome to the Note Taking App");

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("1: List notes");
                Console.WriteLine("2: List SQL notes");
                Console.WriteLine("3: Add new note");
                Console.WriteLine("4: Add new SQL note");
                Console.WriteLine("5: Quit");
                Console.WriteLine();
                Console.Write("> ");

                string input = Console.ReadLine();

                if (input == "1")
                {
                    ListNotes(repo);
                }
                else if (input == "2")
                {
                    ListNotes(null);
                }
                else if (input == "3")
                {
                    AddNewNote(null);
                }
                else if (input == "4")
                {
                    AddNewNote(null);
                }
                else if (input == "5")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Input not recognized, try again");
                }
            }
        }

        private static void AddNewNote(NotesDbContext context, string tag = null)
        {
            Console.WriteLine();
            Console.WriteLine("Enter note contents:");
            Console.Write("> ");

            string input2 = Console.ReadLine();
            var note = new DataAccess.Entities.Note { Text = input2 };

            context.Notes.Add(note);
            context.SaveChanges();
        }

        private static void ListNotes(IRepository repo, string tag = null)
        {
            var notes = repo.GetNotes();

            Console.WriteLine();
            if (notes.Count == 0)
            {
                Console.WriteLine("(none)");
            }
            else
            {
                foreach (var note in notes)
                {
                    var tags = $"[{string.Join(", ", note.Tags)}]";
                    Console.WriteLine($"{tags} {note.Text}");
                }
            }
        }
    }
}
