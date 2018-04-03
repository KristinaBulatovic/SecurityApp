using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Security
{
    class SQLite
    {
        SQLiteConnection sql_conn;
        public void Connection_SQLite(string url)
        {
            sql_conn = new SQLiteConnection("Data Source= " + url + ";Version=3;");
            sql_conn.Open();
        }
        public bool Read_SQLite(string username, string password, string account)
        {
            Connection_SQLite("sqlite.db");

            string sql = "select * from login";
            SQLiteCommand command = new SQLiteCommand(sql, sql_conn);
            SQLiteDataReader reader = command.ExecuteReader();

            bool t = false;

            while (reader.Read())
            {

                if (account == "login")
                {
                    while (reader.Read())
                    {

                        if (username == reader.GetString(0) && password == reader.GetString(1))
                        {
                            t = true;
                        }
                    }
                }
                else if (account == "signup")
                {
                    while (reader.Read())
                    {

                        if (username == reader.GetString(0))
                        {
                            t = true;
                        }
                    }
                }
            }

            return t;
        }

        public string Add_SQLite(string userename, string password)
        {
            Connection_SQLite("sqlite.db");
            using (SQLiteConnection con = new SQLiteConnection(sql_conn))
            {
                try
                {
                    SQLiteCommand cmd = new SQLiteCommand();
                    cmd.CommandText = "INSERT INTO login (korisnicko_ime,lozinka) VALUES (@korisnicko_ime,@lozinka)";
                    cmd.Connection = con;

                    bool t = Read_SQLite(userename, password, "signup");
                    if (!t)
                    {
                        cmd.Parameters.Add(new SQLiteParameter("@korisnicko_ime", userename));
                        cmd.Parameters.Add(new SQLiteParameter("@lozinka", password));

                        if (cmd.ExecuteNonQuery() == 1)
                        {
                            return "Uspešno ste napravili nalog...";
                        }
                        else return "Greška pri pravljenju naloga!!!";
                    }
                    else return "Korisničko ime već postoji!";
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }

            }
        }

        public string Username_SQLite(string username)
        {
            Connection_SQLite("sqlite.db");

            string sql = "select * from login";
            SQLiteCommand command = new SQLiteCommand(sql, sql_conn);
            SQLiteDataReader reader = command.ExecuteReader();

            string p = "";
            while (reader.Read())
            {

                if (username == reader.GetString(0))
                {
                    p = reader.GetString(0);
                }
            }

            return p;
        }

        public string Password_SQLite(string password)
        {
            Connection_SQLite("sqlite.db");

            string sql = "select * from login";
            SQLiteCommand command = new SQLiteCommand(sql, sql_conn);
            SQLiteDataReader reader = command.ExecuteReader();

            string p = "";
            while (reader.Read())
            {

                if (password == reader.GetString(1))
                {
                    p = reader.GetString(1);
                }
            }

            return p;
        }

        public string Delete_SQLite(string username, string table)
        {
            Connection_SQLite("sqlite.db");
            using (SQLiteConnection con = new SQLiteConnection(sql_conn))
            {
                try
                {
                    SQLiteCommand cmd = new SQLiteCommand();
                    cmd.CommandText = "DELETE FROM " + table + " where korisnicko_ime = '" + username + "'";
                    cmd.Connection = con;
                    if (cmd.ExecuteNonQuery() == 0)
                    {
                        return "User Delete Successfuly .......";
                    }
                    else return "User wasn't delete successfuly!";
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
        }

        public void Close_SQLite()
        {
            sql_conn.Close();
        }

        public string pitanje(int id)
        {
            Connection_SQLite("security.db");

            string sql = "select * from kviz";
            SQLiteCommand command = new SQLiteCommand(sql, sql_conn);
            SQLiteDataReader reader = command.ExecuteReader();

            string p = "";
            while (reader.Read())
            {

                if (id.ToString() == reader.GetString(0))
                {
                    p = reader.GetString(1);
                }
            }

            return p;
        }

        public string odgovori(int id, int odgovor)
        {
            Connection_SQLite("security.db");

            string sql = "select * from kviz";
            SQLiteCommand command = new SQLiteCommand(sql, sql_conn);
            SQLiteDataReader reader = command.ExecuteReader();

            string p = "";
            while (reader.Read())
            {

                if (id.ToString() == reader.GetString(0))
                {
                    p = reader.GetString(odgovor);
                }
            }

            return p;
        }

        public string tacan_odgovor(int id)
        {
            Connection_SQLite("security.db");

            string sql = "select * from kviz";
            SQLiteCommand command = new SQLiteCommand(sql, sql_conn);
            SQLiteDataReader reader = command.ExecuteReader();

            string p = "";
            while (reader.Read())
            {

                if (id.ToString() == reader.GetString(0))
                {
                    p = reader.GetString(6);
                }
            }

            return p;
        }

        public string url(string br_slike)
        {
            Connection_SQLite("security.db");

            string sql = "select * from memorija";
            SQLiteCommand command = new SQLiteCommand(sql, sql_conn);
            SQLiteDataReader reader = command.ExecuteReader();

            string p = "";
            while (reader.Read())
            {

                if (br_slike.ToString() == reader.GetString(0))
                {
                    p = reader.GetString(1);
                }
            }

            return p;
        }

        public string napad_odbrana(string id, int br) //int br = 1(napad), 2(odbrana)
        {
            Connection_SQLite("sqlite.db");

            string sql = "select * from napadi";
            SQLiteCommand command = new SQLiteCommand(sql, sql_conn);
            SQLiteDataReader reader = command.ExecuteReader();

            string p = "";
            while (reader.Read())
            {

                if (id.ToString() == reader.GetString(0))
                {
                    p = reader.GetString(br);
                }
            }
            string[] words = p.Split(new string[] { "\n" }, StringSplitOptions.None);
            p = "";
            foreach(string s in words)
            {
                if(s.Length>1)
                p += s.Substring(0, s.Length - 2) + Environment.NewLine;
            }
            return p;
        }

        public string iks_oks(int id) //int id = 1(iks), 2(oks)
        {
            Connection_SQLite("security.db");

            string sql = "select * from iksoks";
            SQLiteCommand command = new SQLiteCommand(sql, sql_conn);
            SQLiteDataReader reader = command.ExecuteReader();

            string p = "";
            while (reader.Read())
            {

                if (id.ToString() == reader.GetString(0))
                {
                    p = reader.GetString(1);
                }
            }
            return p;
        }
    }
} 
