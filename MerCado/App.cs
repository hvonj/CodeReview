using System;
using System.Collections.Generic;
using System.Text;
using MerCado.Domain;



namespace MerCado
{
    public class App
    {
        DataAccess dataAccess = new DataAccess();

        internal void Run()
        {
            Console.WriteLine("Användarnamn:");
            String UserId1 = Console.ReadLine();
            Console.WriteLine("Lösenord:");

            Console.ForegroundColor = ConsoleColor.Black;
            string Pass = Console.ReadLine();
            Console.ResetColor();


            String UserIdCorrect = "Mercado";
            String PassCorrect = "Mercado1";
            int MaxAttempts = 3;



            if (UserId1 != UserIdCorrect && Pass != PassCorrect)
            {
                MaxAttempts++;
            }
            else
            {
                PageMainMenu();
            }

            Console.ReadKey();

        }

        private void PageMainMenu()
        {
            Header("Huvudmeny");

            WriteLine("A) Personer");
            WriteLine("B) Marknadsundersökningar");
            WriteLine("C) Företag");
            WriteLine();
            WriteLine("D) Svara på undersökning");

            ConsoleKey command = Console.ReadKey(true).Key;
            switch (command)
            {
                case ConsoleKey.A:
                    PagePersons();
                    break;
                case ConsoleKey.B:
                    PageResearches();
                    break;
                case ConsoleKey.C:
                    PageCompanies();
                    break;
                case ConsoleKey.D:
                    PageAnswerQuestions();
                    break;
                default:
                    PageMainMenu();
                    break;
            }

        }










        private void PagePersons()
        {
            Header("Personer");

            WriteLine("A) Lägg till person");
            WriteLine("B) Ändra person");
            WriteLine("C) Ta bort person");
            WriteLine("D) Sök personer i databasen");
            WriteLine("E) Visa alla personer i databasen");
            WriteLine("F) Återgå till huvudmenyn");

            ConsoleKey command = Console.ReadKey(true).Key;

            if (command == ConsoleKey.A)
            {
                PageCreatePerson();
            }
            if (command == ConsoleKey.B)
            {
                PageChangePerson();
            }
            if (command == ConsoleKey.C)
            {
                PageDeletePerson();
            }
            if (command == ConsoleKey.D)
            {
                PageSearchPersons();
            }
            if (command == ConsoleKey.E)
            {
                PageShowAllPersons();
            }
            if (command == ConsoleKey.F)
            {
                PageMainMenu();
            }
        }

        private void PageCreatePerson()
        {
            Header("Skapa person");
            Write("Vilken ålder har personen? ");

            int age = 0;

            while (true)
            {
                try
                {
                    age = int.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception)
                {
                    WriteLine("Du måste ange en siffra! ");
                }
            }

            

            string gender;
            while (true)
            {
                Write("Vilket kön har personen (female/male/other)? ");
                string x = Console.ReadLine().ToLower();
                if (x == "female" || x == "male" || x == "other")
                {
                    gender = x;
                    break;
                }
            }

            Write("Var bor personen? ");
            string location = Console.ReadLine();
            Write("Vad har personen för email? ");
            string email = Console.ReadLine();

            dataAccess.CreatePerson(age, gender, location, email);


            Header("Personen är skapad! ");


            Write("Tryck Enter för att återgå till huvudmenyn.\n\n");

            Console.ReadKey();
            PageMainMenu();

        }

        private void PageChangePerson()
        {
            Header("Ändra en person");

            ShowAllPersons();
            WriteLine();

            int personID = 0;
            while (true)
            {
                try
                {
                    Write("Vilken person vill du ändra? ");
                    personID = int.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception)
                {
                    WriteLine("Du måste ange en siffra! ");
                }
            }

            int age = 0;
            while (true)
            {
                try
                {
                    Write("Vilken ny ålder vill du sätta? ");
                    age = int.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception)
                {
                    WriteLine("Du måste ange en siffra! ");
                }
            }

            string gender;
            while (true)
            {
                Write("Vilket kön vill du ändra till (female/male/other)? ");
                string x = Console.ReadLine().ToLower();
                if (x == "female" || x == "male" || x == "other")
                {
                    gender = x;
                    break;
                }
            }

            Write("Vilken ny plats vill du ändra till? ");
            string location = Console.ReadLine();
            Write("Vilken ny email vill du ändra till? ");
            string email = Console.ReadLine();

            dataAccess.ChangePerson(personID, age, gender, location, email);

            Header("Personen är ändrad! ");

            Write("Tryck Enter för att återgå till huvudmenyn.\n\n");

            Console.ReadKey();
            PageMainMenu();
        }

        private void PageDeletePerson()
        {
            Header("Ta bort person");

            ShowAllPersons();
            WriteLine();

            int personID = 0;
            while (true)
            {
                try
                {
                    Write("Vilken person vill du ta bort? ");
                    personID = int.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception)
                {
                    WriteLine("Du måste ange en siffra! ");
                }
            }

            dataAccess.DeletePerson(personID);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Personen är borttagen! \n");
            Console.ResetColor();

            Write("Tryck Enter för att återgå till huvudmenyn.\n\n");

            Console.ReadKey();
            PageMainMenu();
        }

        private void PageSearchPersons()
        {
            Header("Sök efter person");
            WriteLine();

            int personID = 0;
            int age = 0;
            string gender = null;
            string location = null;
            string email = null;

            while (true)
            {
                WriteLine();
                WriteLine("Vad vill du söka på? ");
                WriteLine();
                WriteLine("[ID]".PadRight(6) + "[Age]".PadRight(7) + "[Gender]".PadRight(10) + "[Location]".PadRight(12) + "[Email]");
                WriteLine();

                string searchFor = Console.ReadLine().ToLower();

                if (searchFor == "id")
                {
                    Write("Vilket ID vill du söka på? ");
                    personID = int.Parse(Console.ReadLine());
                    break;
                }
                else if (searchFor == "age")
                {
                    Write("Vilken ålder vill du söka på? ");
                    age = int.Parse(Console.ReadLine());
                    break;
                }
                else if (searchFor == "gender")
                {
                    Write("Vilket kön vill du söka på? ");
                    gender = Console.ReadLine();
                    break;
                }
                else if (searchFor == "location")
                {
                    Write("Vilken plats vill du söka på? ");
                    location = Console.ReadLine();
                    break;
                }
                else if (searchFor == "email")
                {
                    Write("Vilken email vill du söka på? ");
                    email = Console.ReadLine();
                    break;
                }
            }

            while (true)
            {
                WriteLine();
                WriteLine("Vad mer vill du söka på? ");
                WriteLine();
                WriteLine("[ID]".PadRight(6) + "[Age]".PadRight(7) + "[Gender]".PadRight(10) + "[Location]".PadRight(12) + "[Email]");
                WriteLine();

                string searchForTwo = Console.ReadLine().ToLower();

                if (searchForTwo == "id")
                {
                    Write("Vilket ID vill du söka på? ");
                    personID = int.Parse(Console.ReadLine());
                    break;
                }
                else if (searchForTwo == "age")
                {
                    Write("Vilken ålder vill du söka på? ");
                    age = int.Parse(Console.ReadLine());
                    break;
                }
                else if (searchForTwo == "gender")
                {
                    Write("Vilket kön vill du söka på? ");
                    gender = Console.ReadLine();
                    break;
                }
                else if (searchForTwo == "location")
                {
                    Write("Vilken plats vill du söka på? ");
                    location = Console.ReadLine();
                    break;
                }
                else if (searchForTwo == "email")
                {
                    Write("Vilken email vill du söka på? ");
                    email = Console.ReadLine();
                    break;
                }
            }

            List<Person> people = dataAccess.GetPersonOnCertainInput(personID, age, gender, location, email);

            WriteLine();
            WriteLine("ID".PadRight(8) + "Age".PadRight(10) + "Gender".PadRight(15) + "Location".PadRight(20) + "Email".PadRight(25));
            WriteLine();

            foreach (var item in people)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine($"{item.ID.ToString().PadRight(8)}{item.age.ToString().PadRight(10)}{item.gender.ToString().PadRight(15)}{item.location.PadRight(20)}{item.email}");
                Console.ResetColor();
            }

            WriteLine();

            Write("Tryck Enter för att återgå till huvudmenyn.\n\n");

            Console.ReadKey();
            PageMainMenu();
        }

        private void PageShowAllPersons()
        {
            Header("Alla personer i databasen");

            WriteLine();
            ShowAllPersons();
            WriteLine();

            Write("Tryck Enter för att återgå till huvudmenyn.\n\n");

            Console.ReadKey();
            PageMainMenu();
        }
















        private void PageResearches()
        {
            Header("Marknadsundersökningar");

            WriteLine("A) Lägg till enkät");
            WriteLine("B) Ta bort enkät");
            WriteLine("C) Visa alla enkäter");
            WriteLine("D) Visa alla från ett företag");
            WriteLine("E) Återgå till huvudmenyn");

            ConsoleKey command = Console.ReadKey(true).Key;

            switch (command)
            {
                case ConsoleKey.A:
                    PageCreateSurvey();
                    break;
                case ConsoleKey.B:
                    PageDeleteSurvey();
                    break;
                case ConsoleKey.C:
                    PageShowAllSurveys();
                    break;
                case ConsoleKey.D:
                    PageShowCompanySurveys();
                    break;
                case ConsoleKey.E:
                    PageMainMenu();
                    break;
                default:
                    PageResearches();
                    break;
            }
        }

        private void PageCreateSurvey()
        {
            Header("Skapa marknadsundersökning");
            ShowAllCompanies();

            int companyId = 0;

            while (true)
            {
                try
                {
                    WriteLine("Vilket företag vill du göra en undersökning för? ");
                    companyId = int.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception)
                {
                    WriteLine("Du måste ange en siffra! ");
                }
            }

            int researchId = dataAccess.CreateSurveyTest(companyId);

            WriteLine("Skriv frågor till du är nöjd, avsluta med 'exit' ");
            WriteLine();

            bool genericOrNot;
            string question;
            int questionType = 0;
            int questionID = 0;

            while (true)
            {
                Write("Vad är frågan? ");
                question = Console.ReadLine();

                if (question == "exit")
                {
                    break;
                }

                while (true)
                {
                    Write("Är frågan en återkommande fråga (yes/no)? ");
                    string x = Console.ReadLine().ToLower();
                    if (x == "yes")
                    {
                        genericOrNot = true;
                        break;
                    }
                    else if (x == "no")
                    {
                        genericOrNot = false;
                        break;
                    }
                }

                while (true)
                {
                    try
                    {
                        Write("Vad är det för typ av fråga? [1 till 5] --> tryck 1, [1 till 10] --> tryck 2, [yes or no] --> tryck 3: ");
                        questionType = int.Parse(Console.ReadLine());
                        if (questionType == 1 || questionType == 2 || questionType == 3)
                        {
                            break;
                        }
                    }
                    catch (Exception)
                    {
                        WriteLine("Du måste ange en giltig siffra! ");
                    }
                }

                WriteLine();

                questionID = dataAccess.CreateQuestion(question, genericOrNot, questionType);

                dataAccess.CreateIntoQuestions(questionID, researchId);
            }

            Header("Undersökningen är skapad!");

            Console.ReadKey();
            PageMainMenu();
        }

        private void PageDeleteSurvey()
        {
            ShowAllSurveys();
            WriteLine("\nVilken maknadsundersökning vill du ta bort? Tryck ID");

            int surveyID = 0;

            while (true)
            {
                try
                {
                    surveyID = int.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception)
                {
                    WriteLine("Du måste ange en siffra! ");
                }
            }

            WriteLine("Är du säker på att du vill ta bort den? Ja/Nej");
            string svar = Console.ReadLine().ToLower();

            if (svar == "ja")
            {
                dataAccess.DeleteSurvey(surveyID);
            }
            else
            {
                WriteLine("Borttagningen misslyckades ");
                Console.ReadKey();
                PageResearches();
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\nMarknadsundersökningen raderad!");
            Console.ResetColor();
            Console.ReadLine();
            PageMainMenu();
        }

        private void PageShowAllSurveys()
        {
            ShowAllSurveys();

            Write("\nTryck Enter för att återgå till huvudmenyn.\n\n");

            Console.ReadKey();
            PageMainMenu();

        }

        private void PageShowCompanySurveys()
        {
            int companyID = 0;
            Header("Företag");
            ShowAllCompanies();

            Write("Vilket företag vill du se marknadsundersökningar om?");
            WriteLine();

            while (true)
            {
                try
                {
                    companyID = int.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception)
                {
                    WriteLine("Du måste välja ett företag");
                }
            }

            Dictionary<int, string> comSurv = dataAccess.CompanySurveysOneCompany(companyID);
            WriteLine();

            foreach (var item in comSurv)
            {
                WriteLine($"{item.Key.ToString().PadRight(15)} {item.Value}");
            }

            Write("\nTryck Enter för att återgå till huvudmenyn.\n\n");
            Console.ReadKey();
            PageMainMenu();
        }



















        private void PageCompanies()
        {
            Header("Företag");

            WriteLine("A) Lägg till företag");
            WriteLine("B) Ändra företagsnamn");
            WriteLine("C) Ta bort företag");
            WriteLine("D) Visa alla företag i databasen");
            WriteLine("E) Återgå till huvudmenyn");

            ConsoleKey command = Console.ReadKey(true).Key;

            if (command == ConsoleKey.A)
            {
                PageCreateCompany();
            }
            else if (command == ConsoleKey.B)
            {
                PageChangeCompany();
            }
            else if (command == ConsoleKey.C)
            {
                PageDeleteCompany();
            }
            else if (command == ConsoleKey.D)
            {
                PageShowAllCompanies();
            }
            else if (command == ConsoleKey.E)
            {
                PageMainMenu();
            }
            else
            {
                PageCompanies();
            }


        }

        private void PageCreateCompany()
        {
            Console.Clear();
            Company newpost = new Company();
            Header("Företagsnamn? ");
            newpost.name = Console.ReadLine();

            dataAccess.CreateCompany(newpost);
            Header($"Tack, {newpost.name} är registrerat!\n");
            Write("Tryck Enter för att återgå till huvudmenyn.\n\n");

            Console.ReadKey();

            PageMainMenu();

        }

        private void PageChangeCompany()
        {
            Header("Ändra ett företag");
            ShowAllCompanies();

            int companyId = 0;

            while (true)
            {
                try
                {
                    Write("Vilket företag vill du uppdatera? \n");
                    companyId = int.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception)
                {
                    WriteLine("Du måste skriva en siffra! ");
                }
            }

            Company change = null;

            while (true)
            {
                change = dataAccess.GetCompanybyId(companyId);

                if (change != null)
                {
                    break;
                }

                WriteLine("Företaget finns inte! ");
                Console.ReadKey();

                PageChangeCompany();
            }


            WriteLine("Det nuvarande företagsnamnet är: " + change.name);

            Write("Skriv in ett nytt företagsnamn: ");

            string newTitle = Console.ReadLine();

            change.name = newTitle;

            dataAccess.UpdateCompany(change);

            Header("Företagsnamnet är uppdaterad.");

            Write("Tryck Enter för att återgå till huvudmenyn.\n\n");

            Console.ReadKey();
            PageMainMenu();

        }

        private void PageDeleteCompany()
        {
            Header("Ta bort ett företag");

            ShowAllCompanies();
            WriteLine();

            int companyID = 0;

            while (true)
            {
                try
                {
                    Write("Vilket företag vill du ta bort? \n");
                    companyID = int.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception)
                {
                    WriteLine("Du måste skriva en siffra! ");
                }
            }

            dataAccess.DeleteCompany(companyID);

            WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Företaget är raderat!");
            Console.ForegroundColor = ConsoleColor.White;
            WriteLine();

            Write("Tryck Enter för att återgå till huvudmenyn.\n\n");

            Console.ReadKey();
            PageMainMenu();
        }

        private void PageShowAllCompanies()
        {
            Header("Alla företag");

            ShowAllCompanies();

            Write("\nTryck Enter för att återgå till huvudmenyn.\n\n");

            Console.ReadKey();
            PageMainMenu();
        }











        private void PageAnswerQuestions()
        {
            Header("Svara på marknadsundersökning ");

            ShowAllSurveys();
            WriteLine();
            Write("Vilken undersökning vill du svara på? ");
            int researchId = int.Parse(Console.ReadLine());

            ShowAllPersons();
            WriteLine();
            Write("Vem vill du ska svara på undersökningen? ");
            int personId = int.Parse(Console.ReadLine());

            dataAccess.CreateMRtable(researchId, personId);

            List<Question> questionsForOneMarketresearch = dataAccess.GetAllQuestionsForOneResearch(researchId);
            List<int> questionIDs = dataAccess.GetAllQustionIDsForOneResearch(researchId);

            WriteLine();
            WriteLine($"Fråga".PadRight(65) + "FrågeTypsID");
            WriteLine();

            foreach (var item in questionsForOneMarketresearch)
            {
                WriteLine(item.question.ToString().PadRight(65) + item.questionTypeID);
                WriteLine();
                Write("Svara på frågan tack (1 - 10): ");

                int answer = 0;
                while (true)
                {
                    try
                    {
                        answer = int.Parse(Console.ReadLine());
                        break;
                    }
                    catch (Exception)
                    {
                        WriteLine("Du måste ange en siffra! ");
                    }
                }

                WriteLine();

                dataAccess.CreateAnswers(answer, personId, item.ID, researchId);
            }

            Header("Tack för att du svarade på undersökningen! ");
            Write("Tryck Enter för att återgå till huvudmenyn.\n\n");
            Console.ReadKey();
            PageMainMenu();
        }












        private void ShowAllSurveys()
        {
            Header("Marknadsundersökningar");
            Dictionary<int, string> marknadsUndersökningar = dataAccess.AllSurveys();

            WriteLine($"Företagsnamn".PadRight(15) + "MarknadsundersökningsID");
            WriteLine();
            foreach (var item in marknadsUndersökningar)
            {
                WriteLine($"{item.Value.PadRight(15)} {item.Key.ToString()}");
            }
        }
        private void ShowAllPersons()
        {
            List<Person> list = dataAccess.GetallPersonsBreif();

            WriteLine("ID".PadRight(8) + "Age".PadRight(10) + "Gender".PadRight(15) + "Location".PadRight(20) + "Email".PadRight(25));
            WriteLine();

            foreach (var item in list)
            {
                WriteLine($"{item.ID.ToString().PadRight(8)}{item.age.ToString().PadRight(10)}{item.gender.ToString().PadRight(15)}{item.location.PadRight(20)}{item.email}");
            }
        }
        private void ShowAllCompanies()
        {
            List<Company> list = dataAccess.GetAllCompany();

            foreach (Company item in list)
            {
                WriteLine(item.CompanyID.ToString().PadRight(5) + item.name.PadRight(30));
            }
            WriteLine();

        }


        private void Header(string v)
        {
            Console.Clear();
            WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(v.ToUpper());
            WriteLine();
        }
        private void WriteLine(string v = "")
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(v);
        }
        private void Write(string v = "")
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(v);
        }
    }
}


