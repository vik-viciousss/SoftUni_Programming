using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        private List<Student> students;

        private int capacity;

        public Classroom(int capacity)
        {
            this.capacity = capacity;
            this.students = new List<Student>();
        }

        public int Count { get { return this.students.Count; } }

        public string RegisterStudent(Student student)
        {
            if (this.students.Count < this.capacity)
            {
                this.students.Add(student);
                return $"Added student {student.FirstName} {student.LastName}";
            }

            return $"No seats in the classroom";
        }

        public string DismissStudent(string firstName, string lastName)
        {
            Student studentToDismiss = this.students.FirstOrDefault(s => s.FirstName == firstName && s.LastName == lastName);

            if (studentToDismiss != null)
            {
                this.students.Remove(studentToDismiss);
                return $"Dismissed student {firstName} {lastName}";
            }
            else
            {
                return $"Student not found";
            }
        }

        public string GetSubjectInfo(string subject)
        {
            List<Student> enrolledForSubject = this.students.Where(s => s.Subject == subject).ToList();

            if (enrolledForSubject.Count == 0)
            {
                return "No students enrolled for the subject";
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Subject: {subject}");
            sb.AppendLine("Students:");

            foreach (var student in enrolledForSubject)
            {
                sb.AppendLine($"{student.FirstName} {student.LastName}");
            }

            return sb.ToString();
        }

        public int GetStudentsCount()
        {
            return this.Count;
        }

        public Student GetStudent(string firstName, string lastName)
        {
            return this.students.FirstOrDefault(s => s.FirstName == firstName && s.LastName == lastName);
        }
    }
}
