using d3hiring.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace d3hiring.Biz
{
    public class lessonBiz
    {

        /// <summary>
        /// Update lesson with teacher and student
        /// </summary>
        /// <param name="db"></param>
        /// <param name="teacher"></param>
        /// <param name="student"></param>
        public void registerStudentToLesson(d3hiringDb db, teacher teacher, student student)
        {
            //Check if student already exist in the lesson.
            var studentLesson = db.lessons.FirstOrDefault(x => x.idstudent == student.idstudent && x.idteacher == teacher.idteacher);
            if(studentLesson == null)
            {
                //Student not register before. Add to DB.
                db.lessons.Add(new lesson()
                {
                    teacher = teacher,
                    student = student
                });
            }
        }

        /// <summary>
        /// Get all students in a lesson
        /// </summary>
        /// <param name="db"></param>
        /// <param name="teacher"></param>
        /// <returns></returns>
        public List<String> getStudentsByTeacherInLesson(d3hiringDb db, teacher teacher)
        {
            var students = new List<String>();
            var lessons = db.lessons.Include("student").Where(x => x.idteacher == teacher.idteacher);
            if (lessons.Any())
            {
                foreach (var lesson in lessons)
                {
                    students.Add(lesson.student.email);
                }
            }
            return students;
        }


        /// <summary>
        /// Get Active Student (distincted) by teacher email
        /// </summary>
        /// <param name="db"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public HashSet<String> getActiveStudentsByTeacherInLesson(d3hiringDb db, String email)
        {
            var students = new HashSet<String>();
            var lessons = db.lessons.Include("student").Include("teacher")
                .Where(x => x.student.active == 1 &&  x.teacher.email.Equals(email,StringComparison.OrdinalIgnoreCase));

            if (lessons.Any())
            {
                foreach (var lesson in lessons)
                {
                    students.Add(lesson.student.email);
                }
            }
            return students;
        }

    }
}
