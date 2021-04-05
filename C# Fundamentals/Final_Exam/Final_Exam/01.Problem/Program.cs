using System;
using System.Text;

namespace _01.Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            string email = Console.ReadLine();

            string command = Console.ReadLine();
            StringBuilder sb = new StringBuilder();

            while (command != "Complete")
            {
                string[] tokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (tokens[0] == "Make")
                {
                    if (tokens[1] == "Upper")
                    {
                        foreach (var ch in email)
                        {
                            if (char.IsLetter(ch))
                            {
                                sb.Append(ch.ToString().ToUpper());
                            }
                            else
                            {
                                sb.Append(ch.ToString());
                            }
                        }

                        email = sb.ToString();
                        sb = new StringBuilder();

                        Console.WriteLine(email);
                    }
                    else if (tokens[1] == "Lower")
                    {
                        foreach (var ch in email)
                        {
                            if (char.IsLetter(ch))
                            {
                                sb.Append(ch.ToString().ToLower());
                            }
                            else
                            {
                                sb.Append(ch.ToString());
                            }
                        }

                        email = sb.ToString();
                        sb = new StringBuilder();

                        Console.WriteLine(email);
                    }
                }
                else if (tokens[0] == "GetDomain")
                {
                    string domain = email.Substring(email.Length - (int.Parse(tokens[1])));

                    Console.WriteLine(domain);
                }
                else if (tokens[0] == "GetUsername")
                {
                    int index = email.IndexOf('@');

                    if (index > -1)
                    {
                        string username = email.Substring(0, index);

                        Console.WriteLine(username);
                    }
                    else
                    {
                        Console.WriteLine($"The email {email} doesn't contain the @ symbol.");
                    }
                }
                else if (tokens[0] == "Replace")
                {
                    char[] arr = tokens[1].ToCharArray();
                    char oldChar = arr[0];

                    email = email.Replace(oldChar, '-');

                    Console.WriteLine(email);
                }
                else if (tokens[0] == "Encrypt")
                {
                    foreach (var ch in email)
                    {
                        int currCode = ch;
                        string currString = currCode.ToString();

                        sb.Append(currString + ' ');
                    }

                    Console.WriteLine(sb);
                    sb = new StringBuilder();
                }

                command = Console.ReadLine();
            }
        }
    }
}
