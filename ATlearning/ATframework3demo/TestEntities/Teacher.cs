﻿using atFrameWork2.TestEntities;
using System.Collections.ObjectModel;

namespace ATframework3demo.TestEntities
{
    public class Teacher : ScheduleUser
    {
        public Teacher()
            : base()
        {
            role = UserRole.Teacher;
        }
        public List<string> subjects { get; set; }
    }
}
