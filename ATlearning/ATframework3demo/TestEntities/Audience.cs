﻿namespace ATframework3demo.TestEntities
{
    public class Audience
    {
        public Audience(AudienceType type)
        {
            title = $"{new Random().Next(1000000000)}";
            this.type = type;
        }

        public string title { get; set; }
        
        public AudienceType type { get; set; }

        public string GetTypeName()
        {
            switch (this.type)
            {
                case AudienceType.Lecture:
                    return "Лекционная";
                case AudienceType.Practice:
                    return "Практическая";
                case AudienceType.Online:
                    return "Онлайн";
                default:
                    return "";
            }
        }
    }

    public enum AudienceType
    {
        Lecture,
        Practice,
        Online
    };
}
