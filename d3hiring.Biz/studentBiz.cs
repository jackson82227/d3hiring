using d3hiring.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace d3hiring.Biz
{
    public class studentBiz
    {
        /// <summary>
        /// Get student by email
        /// </summary>
        /// <param name="db"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public student getStudentByEmail(d3hiringDb db, String email)
        {
            var student = db.students.FirstOrDefault(x => x.email.Equals(email, StringComparison.OrdinalIgnoreCase));
            return student;
        }

        /// <summary>
        /// Register student by email
        /// </summary>
        /// <param name="db"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public student registerStudentByEmail(d3hiringDb db, String email)
        {
            var student = db.students.FirstOrDefault(x => x.email.Equals(email, StringComparison.OrdinalIgnoreCase));
            if (student == null)
            {
                //if student not found in parent table, register to parent table first.
                student = db.students.Add(new student() { email = email });
            }

            return student;
        }

        /// <summary>
        /// Set active to 0
        /// </summary>
        /// <param name="db"></param>
        /// <param name="email"></param>
        public student suspendStudentByEmail(d3hiringDb db, String email)
        {
            var student = db.students.FirstOrDefault(x => x.email.Equals(email, StringComparison.OrdinalIgnoreCase));
            if (student != null)
            {
                student.active = 0;
            }
            return student;
        }

    }
}
