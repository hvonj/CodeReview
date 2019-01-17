using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using MerCado.Domain;

namespace MerCado
{
    class DataAccess
    {
        private const string conString = "Server=(localdb)\\mssqllocaldb; Database=MerCado";



        internal void CreatePerson(int age, string gender, string location, string email)
        {
            var sql = @"INSERT INTO PERSON (Age, Gender, Location, Email) 
                        VALUES (@Age, @Gender, @Location, @Email)";

            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))

            {
                connection.Open();
                command.Parameters.Add(new SqlParameter("Age", age));
                command.Parameters.Add(new SqlParameter("Gender", gender));
                command.Parameters.Add(new SqlParameter("Location", location));
                command.Parameters.Add(new SqlParameter("Email", email));
                command.ExecuteNonQuery();
            }
        }

        internal void ChangePerson(int personID, int age, string gender, string location, string email)
        {
            var sql = @"UPDATE person 
                        SET age=@age, gender=@gender, location=@location, email=@email
                        WHERE personid=@ID";

            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))

            {
                connection.Open();
                command.Parameters.Add(new SqlParameter("age", age));
                command.Parameters.Add(new SqlParameter("gender", gender));
                command.Parameters.Add(new SqlParameter("location", location));
                command.Parameters.Add(new SqlParameter("email", email));
                command.Parameters.Add(new SqlParameter("id", personID));
                command.ExecuteNonQuery();
            }
        }

        internal void DeletePerson(int personID)
        {
            var sql = @"DELETE PERSON
                           WHERE PersonID=@ID"; 

            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();
                command.Parameters.Add(new SqlParameter("ID", personID));
                command.ExecuteNonQuery();
            }
        }

       
        internal List<Person> GetPersonOnCertainInput(int personID, int age, string gender, string location, string email)
        {
            string sql;

            while (true)
            {

                List<ParamValue> param = new List<ParamValue>();

                if (personID != 0)
                    param.Add(new ParamValue { Param = "personid", Value = personID });

                if (age != 0)
                    param.Add(new ParamValue { Param = "age", Value = age });

                if (gender != null)
                    param.Add(new ParamValue { Param = "gender", Value = gender });

                if (location != null)
                    param.Add(new ParamValue { Param = "location", Value = location });

                if (email != null)
                    param.Add(new ParamValue { Param = "email", Value = email });

                var paramlist = new List<string>();

                foreach (ParamValue pv in param)
                    paramlist.Add(pv.Param + "=@" + pv.Param);

                sql = @"SELECT * FROM Person WHERE " + string.Join(" AND ", paramlist);


                using (SqlConnection connection = new SqlConnection(conString))
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();


                    foreach (ParamValue pv in param)
                        command.Parameters.Add(new SqlParameter(pv.Param, pv.Value));

                    SqlDataReader reader = command.ExecuteReader();

                    List<Person> list = new List<Person>();

                    while (reader.Read())
                    {
                        var p = new Person
                        {
                            ID = reader.GetSqlInt32(0).Value,
                            age = reader.GetSqlInt32(1).Value,
                            gender = Enum.Parse<Gender>(reader.GetSqlString(2).Value, true),
                            location = reader.GetSqlString(3).Value,
                            email = reader.GetSqlString(4).Value
                        };
                        list.Add(p);
                    }
                    return list;
                }
            }
        }

        public List<Person> GetallPersonsBreif()
        {
            var sql = @"SELECT * 
                        FROM Person";
            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                List<Person> list = new List<Person>();

                while (reader.Read())
                {
                    var p = new Person
                    {
                        ID = reader.GetSqlInt32(0).Value,
                        age = reader.GetSqlInt32(1).Value,
                        gender = Enum.Parse<Gender>(reader.GetSqlString(2).Value, true),
                        location = reader.GetSqlString(3).Value,
                        email = reader.GetSqlString(4).Value
                    };
                    list.Add(p);
                }
                return list;
            }
        }

        internal void CreateSurvey(int companyId)
        {

            string sql = @"INSERT INTO marketresearch(CompanyID) VALUES (@ID)";


            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();
                command.Parameters.Add(new SqlParameter("ID", companyId));
                command.ExecuteNonQuery();

            }

        }


        internal void DeleteSurvey(int surveyID)
        {

            string sql = @"DELETE MARKETRESEARCH WHERE ResearchID=@ID";
            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();
                command.Parameters.Add(new SqlParameter("ID", surveyID));
                command.ExecuteNonQuery();
            }
        }


        internal Dictionary<int, string> AllSurveys()
        {
            string sql = @"SELECT MARKETRESEARCH.ResearchID, Company.name FROM MARKETRESEARCH JOIN COMPANY ON COMPANY.CompanyID = MARKETRESEARCH.CompanyID";
            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                Dictionary<int, string> researches = new Dictionary<int, string>();
                int x = 0;
                string y;

                while (reader.Read())
                {

                    x = reader.GetSqlInt32(0).Value;
                    y = reader.GetSqlString(1).Value;


                    researches.Add(x, y);
                }
                return researches;
            }
        }


        internal Dictionary<int, string> CompanySurveysOneCompany(int companyID)
        {
            string sql = @"SELECT MARKETRESEARCH.ResearchID, Company.name FROM MARKETRESEARCH JOIN COMPANY ON COMPANY.CompanyID = MARKETRESEARCH.CompanyID WHERE Company.CompanyID=@ID";
            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();
                command.Parameters.Add(new SqlParameter("ID", companyID));
                SqlDataReader reader = command.ExecuteReader();

                Dictionary<int, string> researches = new Dictionary<int, string>();
               

                while (reader.Read())
                {

                   int y = reader.GetSqlInt32(0).Value;
                  string  x = reader.GetSqlString(1).Value;



                    researches.Add(y, x);
                }
                return researches;
            }
        }

        public void CreateCompany(Company newpost)
        {
            var sql = @"INSERT INTO Company

                    (Name)
                    VALUES(@Name)";


            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))

            {
                connection.Open();
                command.Parameters.Add(new SqlParameter("Name", newpost.name));


                command.ExecuteNonQuery();
            }
        }

        internal void UpdateCompany(Company change)
        {
            var sql = @"UPDATE Company SET Name=@Name WHERE companyID=@ID";

            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))

            {
                connection.Open();
                command.Parameters.Add(new SqlParameter("Name", change.name));
                command.Parameters.Add(new SqlParameter("ID", change.CompanyID));


                command.ExecuteNonQuery();
            }
        }

        internal void DeleteCompany(int companyID)
        {
            var sql = @"DELETE COMPANY
                           WHERE CompanyID=@ID"; 

            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();
                command.Parameters.Add(new SqlParameter("ID", companyID));
                command.ExecuteNonQuery();
            }
        }

        internal List<Company> GetAllCompany()
        {

            var sql = @"SELECT * 
                        FROM Company";
            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                List<Company> list = new List<Company>();

                while (reader.Read())

                {
                    var p = new Company
                    {
                        CompanyID = reader.GetSqlInt32(0).Value,
                        name = reader.GetSqlString(1).Value,

                    };
                    list.Add(p);
                }
                return list;
            }
        }

        internal Company GetCompanybyId(int companyId)
        {
            var sql = @"SELECT [companyId], [Name]
                        FROM Company 
                        WHERE companyId=@Id";

            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();
                command.Parameters.Add(new SqlParameter("Id", companyId));

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    var bp = new Company
                    {
                        CompanyID = reader.GetSqlInt32(0).Value,
                        name = reader.GetSqlString(1).Value,
                    };
                    return bp;
                }
                return null;
            }
        }

        internal int CreateQuestion(string question, bool genericOrNot, int questionType)
        {
            var sql = @"INSERT INTO Question (Question, QuestionTypeid, GenericQuestion)
                        OUTPUT INSERTED.questionID 
                        VALUES (@question, @questiontypeid, @genericquestion)";

            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))

            {
                connection.Open();
                command.Parameters.Add(new SqlParameter("question", question));
                command.Parameters.Add(new SqlParameter("genericquestion", genericOrNot));
                command.Parameters.Add(new SqlParameter("questiontypeid", questionType));
                int questionid = (int)command.ExecuteScalar();
                return questionid;
            }
        }

        internal void CreateIntoQuestions(int questioniD, int researchID)
        {
            var sql = @"INSERT INTO Questions (researchID, questionID) 
                        VALUES (@researchid, @questionid)";

            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))

            {
                connection.Open();
                command.Parameters.Add(new SqlParameter("researchid", researchID));
                command.Parameters.Add(new SqlParameter("questionid", questioniD));
                command.ExecuteNonQuery();
            }

        }
        internal List<MarketResearch> SurveyByID(int researchID)
        {
            {
                var sql = @"SELECT [ResearchID], [CompanyID]
                        FROM MarketResarch 
                        WHERE ResearchID=@Id";

                using (SqlConnection connection = new SqlConnection(conString))
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    command.Parameters.Add(new SqlParameter("Id", researchID));
                    SqlDataReader reader = command.ExecuteReader();
                    List<MarketResearch> mrlist = new List<MarketResearch>();
                    while (reader.Read())
                    {
                        var mr = new MarketResearch
                        {
                            researchID = reader.GetSqlInt32(0).Value,
                            companyID = reader.GetSqlInt32(1).Value,

                        };
                        mrlist.Add(mr);
                    }
                    return mrlist;
                }
            }
        }
        internal int CreateSurveyTest(int companyId)
        {
            string sql = @" INSERT INTO marketresearch (CompanyID) 
                            OUTPUT INSERTED.Researchid
                            VALUES (@ID)";


            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();
                command.Parameters.Add(new SqlParameter("ID", companyId));
                int researchId = (int)command.ExecuteScalar();
                return researchId;
            }
        }

        internal List<Question> GetAllQuestionsForOneResearch(int researchId)
        {
            string sql = @"SELECT QUESTION.Question, QUESTION.Questiontypeid, QUESTION.QuestionId 
                            FROM QUESTION 
                            JOIN QUESTIONS 
                            ON QUESTIONS.Questionid = QUESTION.Questionid
                            WHERE Researchid=@researchid";

            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();
                command.Parameters.Add(new SqlParameter("researchid", researchId));
                SqlDataReader reader = command.ExecuteReader();


                List<Question> questions = new List<Question>();

                while (reader.Read())
                {
                    var q = new Question
                    {
                        question = reader.GetSqlString(0).Value,
                        questionTypeID = reader.GetSqlInt32(1).Value,
                        ID = reader.GetSqlInt32(2).Value,

                    };


                    questions.Add(q);
                }
                return questions;
            }
        }

        internal List<int> GetAllQustionIDsForOneResearch(int researchId)
        {
            string sql = @"SELECT Questionid 
                            FROM QUESTIONS 
                            WHERE Researchid=@researchid";

            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();
                command.Parameters.Add(new SqlParameter("researchid", researchId));
                SqlDataReader reader = command.ExecuteReader();

                List<int> questionIDs = new List<int>();

                while (reader.Read())
                {
                    int x = reader.GetSqlInt32(0).Value;
                    questionIDs.Add(x);
                }
                return questionIDs;
            }
        }

        internal void CreateAnswers(int answer, int personId, int questionIDs, int researchId)
        {
            var sql = @"INSERT INTO ANSWER (questionID, researchid, personid, answer) 
                        VALUES (@Questionid, @researchid, @personid, @answer)";

            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();

                command.Parameters.Add(new SqlParameter("Questionid", questionIDs));
                command.Parameters.Add(new SqlParameter("researchid", researchId));
                command.Parameters.Add(new SqlParameter("personid", personId));
                command.Parameters.Add(new SqlParameter("answer", answer));

                command.ExecuteNonQuery();

            }
        }

        internal void CreateMRtable(int researchId, int personId)
        {
            var sql = @"INSERT INTO PERSONMR (researchID, PersonID) 
                        VALUES (@researchid, @personid)";

            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))

            {
                connection.Open();
                command.Parameters.Add(new SqlParameter("researchid", researchId));
                command.Parameters.Add(new SqlParameter("personid", personId));
                command.ExecuteNonQuery();
            }
        }
    }
}

