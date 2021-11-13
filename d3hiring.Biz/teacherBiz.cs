using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using d3hiring.Data;

namespace d3hiring.Biz
{
    public class teacherBiz
    {
        /// <summary>
        /// Get Teacher by Email
        /// </summary>
        /// <param name="db"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public teacher getTeacherByEmail(d3hiringDb db, String email)
        {
            var teacher = db.teachers.FirstOrDefault(x => x.email.Equals(email, StringComparison.OrdinalIgnoreCase));
            return teacher;
        }

        /// <summary>
        /// Register Teacher by Email
        /// </summary>
        /// <param name="db"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public teacher registerTeacherByEmail(d3hiringDb db, String email)
        {
            var teacher = db.teachers.FirstOrDefault(x => x.email.Equals(email, StringComparison.OrdinalIgnoreCase));
            if (teacher == null)
            {
                //if teacher not found in parent table, register to parent table first.
                teacher = db.teachers.Add(new teacher() { email = email });
            }

            return teacher;
        }
    }
}
