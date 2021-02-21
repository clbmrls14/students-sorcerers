using StudentsAndSorcerers.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StudentsAndSorcerers.API.Services
{
    public class ValidationService
    {
        public Regex RegexItem = new Regex("^[a-zA-Z0-9' ]*$");
        public const int MAX_YEAR = 9999;
        public const int MIN_YEAR = 1;

        public const int MAX_STAT = 13;
        public const int MAX_EXPERIENCE = 1200;
        public const int MAX_HEALTH = 5;

        public static readonly string[] STAT_LIST = { 
            "order", "chaos", "current_health", "math", "reading", "writing", "science", "history" 
        };

        public bool ValidateClassroom(Classroom classroom)
        {
            if ((classroom.Year >= MIN_YEAR) && (classroom.Year <= MAX_YEAR))
            {
                if (ValidateString(classroom.Title))
                {
                    return true;
                }
            }
            return false;
        }

        public bool ValidateStudent(Student student)
        {
            if (ValidateString(student.Name))
            {
                if (ValidateStats(student))
                {
                    return true;
                }
            }
            return false;
        }

        public bool ValidateLog(Log log)
        {
            if (ValidateStudent(log.Student))
            {
                if (STAT_LIST.Contains(log.StatChanged.ToLower()))
                {
                   if ((log.StatValue == 1) || (log.StatValue == -1))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool ValidateString(String field)
        {
            if (RegexItem.IsMatch(field))
            {
                return true;
            }
            return false;
        }

        public bool ValidateStats(Student student)
        {
            if ((student.Level <= MAX_STAT) && (student.Level > 0))
            {
                if (student.CurrentHealth <= MAX_HEALTH)
                {
                    if (student.Experience <= MAX_EXPERIENCE)
                    {
                        if ((student.Order <= MAX_STAT) &&
                            (student.Chaos <= MAX_STAT) &&
                            (student.Math <= MAX_STAT) &&
                            (student.Reading <= MAX_STAT) &&
                            (student.Writing <= MAX_STAT) &&
                            (student.Science <= MAX_STAT) &&
                            (student.History <= MAX_STAT))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}
